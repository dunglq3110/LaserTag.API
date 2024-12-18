﻿using LaserTag.Host.Dtos;
using LaserTag.Host.Extensions;
using LaserTag.Host.Frame;
using LaserTag.Host.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;
using System.Windows;
using LaserTag.Host.Helper;
namespace LaserTag.Host.Logic
{
    public class PlayerClientSession : WebSocketBehavior
    {
        public Player Player { get; set; } = new Player();


        protected override void OnClose(CloseEventArgs e)
        {
            GameManager.Instance.NotifyAllPlayerInfo($"Player: {Player.Name} Disconected");
            GameManager.Instance.RemovePlayer(Player);
            base.OnClose(e);
        }

        protected override void OnMessage(MessageEventArgs e)
        {
            var frame = JsonConvert.DeserializeObject<HostFrameData<object>>(e.Data);
            if (frame != null)
            {
                switch (frame.ActionCode)
                {
                    case HostActionCode.InitialConnection:
                        HandleInitialConnection(e.Data);
                        break;
                    case HostActionCode.UpdatePlayerData:
                        HandleUpdatePlayerData(e.Data);
                        break;
                    case HostActionCode.PlayerBuyUpgrade:
                        HandlePlayerBuyUpgrade(e.Data);
                        break;
                    case HostActionCode.PlayerGameLog:
                        HandlePlayerGameLog(e.Data);
                        break;
                    case HostActionCode.HeartBeat:
                        HandleHearthBeat();
                        break;
                    default:
                        // Handle other message types here
                        break;
                }
            }
            else
            {

            }
        }

        protected override void OnOpen()
        {
            base.OnOpen();
        }
        public void SendData(string data)
        {
            Send(data);
        }
        #region Event handlers
        private void HandleHearthBeat()
        {
            try
            {
                var response = new HostFrameDataBuilder<object>()
                    .SetActionCode(HostActionCode.HeartBeat)
                    .SetMessageType(MessageType.Success)
                    .Build();

                // Add logging

                // Ensure the connection is open
                if (State == WebSocketState.Open)
                {
                    string data = JsonConvert.SerializeObject(response, Formatting.Indented);
                    Console.WriteLine($"Sending data: {data}");

                    // Use the Send method from WebSocketBehavior
                    Send(data);

                    // Additional verification
                    Console.WriteLine("Heartbeat sent successfully");
                }
                else
                {
                    Console.WriteLine($"Cannot send heartbeat - connection state: {State}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending heartbeat: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
            }
        }
        private void HandleInitialConnection(string frameData)
        {
            // Do something with the data
            try
            {
                var frame = JsonConvert.DeserializeObject<HostFrameData<AddPlayerRequest>>(frameData);
                if (GameManager.Instance.CheckAddNewPlayer(frame.Data))
                {
                    Player.Id = GameManager.Instance.PlayerClients.Count + 1;
                    Player.ConnectionId = ID;
                    Player.Name = frame.Data.Name;
                    Player.MacVest = frame.Data.MacVest;
                    Player.MacGun = frame.Data.MacGun;

                    GameManager.Instance.AddPlayer(this);
                    var response = new HostFrameDataBuilder<object>()
                        .SetActionCode(HostActionCode.GameMessage)
                        .SetMessageType(MessageType.Success)
                        .SetMessage("You are added, Enjoy!")
                        .Build();
                    string data = JsonConvert.SerializeObject(response, Formatting.Indented);
                    SendData(data);
                }
            }
            catch (Exception ex)
            {
                var response = new HostFrameDataBuilder<object>()
                        .SetActionCode(HostActionCode.InitialConnection)
                        .SetMessageType(MessageType.Error)
                        .SetMessage(ex.Message)
                        .Build();
                string data = JsonConvert.SerializeObject(response, Formatting.Indented);
                SendData(data);

            }
        }
        private void HandleUpdatePlayerData(string frameData)
        {
            // Do something with the data
            try
            {
                var frame = JsonConvert.DeserializeObject<HostFrameData<UpdatePlayerRequest>>(frameData);
                Player.Name = frame.Data.Name;
                Player.MacVest = frame.Data.MacVest;
                Player.MacGun = frame.Data.MacGun;
                var response = new HostFrameDataBuilder<object>()
                    .SetActionCode(HostActionCode.InitialConnection)
                    .SetMessageType(MessageType.Success)
                    .SetMessage("You profile updated! , Enjoy!")
                    .Build();
                string data = JsonConvert.SerializeObject(response, Formatting.Indented);
                SendData(data);
            }
            catch (Exception ex)
            {
                var response = new HostFrameDataBuilder<object>()
                        .SetActionCode(HostActionCode.InitialConnection)
                        .SetMessageType(MessageType.Error)
                        .SetMessage(ex.Message)
                        .Build();
                string data = JsonConvert.SerializeObject(response, Formatting.Indented);
                SendData(data);

            }
        }

        private void HandlePlayerBuyUpgrade(string frameData)
        {
            // Do something with the data
            try
            {
                var frame = JsonConvert.DeserializeObject<HostFrameData<List<int>>>(frameData);
                foreach (var item in frame.Data)
                {
                    GameManager.Instance.PlayerBuyUpgrade(Player.Id, item);
                }
                var response = new HostFrameDataBuilder<object>()
                    .SetActionCode(HostActionCode.PlayerBuyUpgrade)
                    .SetMessageType(MessageType.Success)
                    .SetMessage("Your upgrades applied!!")
                    .Build();
                string data = JsonConvert.SerializeObject(response, Formatting.Indented);
                SendData(data);
            }
            catch (Exception ex)
            {
                var response = new HostFrameDataBuilder<object>()
                        .SetActionCode(HostActionCode.InitialConnection)
                        .SetMessageType(MessageType.Error)
                        .SetMessage(ex.Message)
                        .Build();
                string data = JsonConvert.SerializeObject(response, Formatting.Indented);
                SendData(data);

            }
        }


        #endregion

        #region Handle Player Game Log
        private void HandlePlayerGameLog(string frameData)
        {
            try
            {
                var frame = JsonConvert.DeserializeObject<HostFrameData<string>>(frameData);

                // Split the data by the "|" separator to get multiple hex strings
                string[] hexStrings = frame.Data.Split('|');

                foreach (var hexString in hexStrings)
                {
                    // Convert each hex string into a byte array
                    byte[] buffer = GameHelper.StringToByteArray(hexString);
                    if (buffer.Length < 2) throw new Exception("Error: Data is too short.");

                    // Get the first byte as the message type
                    ReportType messageType = (ReportType)(buffer[0] & 0x0F);
                    Console.WriteLine($"Received header via binary message notify: {messageType}");

                    // Process each message type in the switch case
                    byte[] payload = buffer.ToArray();  // You might already have the full buffer here

                    switch (messageType)
                    {
                        case ReportType.HealthArmorReport:
                            HandleHealthArmorReport(payload);
                            break;
                        case ReportType.DamageReport:
                            HandleDamageReport(payload);
                            break;
                        case ReportType.HealingReport:
                            HandleHealingReport(payload);
                            break;
                        case ReportType.SSketchReport:
                            HandleSSketchReport(payload);
                            break;
                        case ReportType.BulletReport:
                            HandleBulletReport(payload);
                            break;
                        default:
                            Console.WriteLine("Unknown message type.");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                var response = new HostFrameDataBuilder<object>()
                        .SetActionCode(HostActionCode.InitialConnection)
                        .SetMessageType(MessageType.Error)
                        .SetMessage(ex.Message)
                        .Build();
                string data = JsonConvert.SerializeObject(response, Formatting.Indented);
                SendData(data);
            }
        }


        private void HandleHealthArmorReport(byte[] buffer)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                GameManager gmInstance = GameManager.Instance;
                var healthArmorReport = GameHelper.DecodeGunReport<HealthArmorReport>(buffer);
                Player player = gmInstance.AllPlayers.FirstOrDefault(p => p.Id == healthArmorReport.id);
                if (player == null) return;
                player.CurrentHealth = healthArmorReport.health;
                player.CurrentArmor = healthArmorReport.armor;
                SendSyncData();
            });
        }

        private void HandleBulletReport(byte[] buffer)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                GameManager gmInstance = GameManager.Instance;
                var bulletReport = GameHelper.DecodeGunReport<BulletReport>(buffer);
                Player player = gmInstance.AllPlayers.FirstOrDefault(p => p.Id == bulletReport.id);
                if (player == null) return;
                player.CurrentBullet = bulletReport.normalBullets;
                player.CurrentSSketchBullet = bulletReport.ssketchBullets;
                ShootLog shootLog = new ShootLog
                {
                    Id = gmInstance.ShootLogs.Count(),
                    Shooter = player,
                    Round = gmInstance.CurrentRound,
                    Time = DateTime.Now,
                };
                gmInstance.ShootLogs.Add(shootLog);
                SendSyncData();
            });

        }

        private void HandleDamageReport(byte[] buffer)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                var damageReport = GameHelper.DecodeGunReport<DamageReport>(buffer);
                GameManager gmInstance = GameManager.Instance;
                var shooter = gmInstance.AllPlayers.FirstOrDefault(p => p.Id == damageReport.taggerId);
                var target = gmInstance.AllPlayers.FirstOrDefault(p => p.Id == damageReport.victimId);
                if (shooter != null && target != null)
                {
                    HitLog hitLog = new HitLog
                    {
                        Id = GameManager.Instance.HitLogs.Count(),
                        Shooter = shooter,
                        Target = target,
                        Round = gmInstance.CurrentRound,
                        HitType = HitType.Normal,
                        Damage = damageReport.damage,
                        Time = DateTime.Now
                    };
                    gmInstance.HitLogs.Add(hitLog);
                    shooter.Credit += damageReport.damage;
                }
            });

        }

        private void HandleHealingReport(byte[] buffer)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                var healingReport = GameHelper.DecodeGunReport<HealingReport>(buffer);
                GameManager gmInstance = GameManager.Instance;
                var shooter = gmInstance.AllPlayers.FirstOrDefault(p => p.Id == healingReport.healerId);
                var target = gmInstance.AllPlayers.FirstOrDefault(p => p.Id == healingReport.healedId);
                if (shooter != null && target != null)
                {
                    HitLog hitLog = new HitLog
                    {
                        Shooter = shooter,
                        Target = target,
                        Round = gmInstance.CurrentRound,
                        HitType = HitType.Healing,
                        Damage = healingReport.healAmount,
                        Time = DateTime.Now
                    };
                    gmInstance.HitLogs.Add(hitLog);
                    shooter.Credit += healingReport.healAmount;
                }
            });

        }

        private void HandleSSketchReport(byte[] buffer)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                var ssketchReport = GameHelper.DecodeGunReport<SSketchReport>(buffer);
                GameManager gmInstance = GameManager.Instance;
                var shooter = gmInstance.AllPlayers.FirstOrDefault(p => p.Id == ssketchReport.taggerId);
                var target = gmInstance.AllPlayers.FirstOrDefault(p => p.Id == ssketchReport.victimId);
                if (shooter != null && target != null)
                {
                    HitLog hitLog = new HitLog
                    {
                        Shooter = shooter,
                        Target = target,
                        Round = gmInstance.CurrentRound,
                        HitType = HitType.Normal,
                        Damage = ssketchReport.damage,
                        Time = DateTime.Now
                    };
                    gmInstance.HitLogs.Add(hitLog);
                    shooter.Credit += ssketchReport.damage;
                }
            });

        }

        public void SendSyncData()
        {
            try
            {
                var response = new HostFrameDataBuilder<object>()
                    .SetActionCode(HostActionCode.SendSyncPlayerData)
                    .SetMessageType(MessageType.Success)
                    .SetData(new SyncPlayerDTO(Player))
                    .Build();
                if (State == WebSocketState.Open)
                {
                    string data = JsonConvert.SerializeObject(response, Formatting.Indented);

                    Send(data);

                }
                else
                {
                    Console.WriteLine($"Cannot send sync data - connection state: {State}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending sync data: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
            }

            #endregion


        }
    }
}
