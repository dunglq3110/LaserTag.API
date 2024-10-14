using LaserTag.Host.Dtos;
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
namespace LaserTag.Host.Logic
{
    public class PlayerClientSession : WebSocketBehavior
    {
        public Player Player { get; set; } = new Player();

        
        protected override void OnClose(CloseEventArgs e)
        {
            base.OnClose(e);
        }

        protected override void OnMessage(MessageEventArgs e)
        {
            var frame = JsonConvert.DeserializeObject<HostFrameData<object>>(e.Data);
            if (frame != null && frame.MessageType == MessageType.Request)
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
                    case HostActionCode.PlayerShootLog:
                        HandleUpdatePlayerData(e.Data);
                        break;
                    case HostActionCode.PlayerHitLog:
                        HandleUpdatePlayerData(e.Data);
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
                        .SetActionCode(HostActionCode.InitialConnection)
                        .SetMessageType(MessageType.Success)
                        .SetMessage("You are added, Enjoy!")
                        .Build();
                    string data = JsonConvert.SerializeObject(response);
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
                string data = JsonConvert.SerializeObject(response);
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
                string data = JsonConvert.SerializeObject(response);
                SendData(data);
            }
            catch (Exception ex)
            {
                var response = new HostFrameDataBuilder<object>()
                        .SetActionCode(HostActionCode.InitialConnection)
                        .SetMessageType(MessageType.Error)
                        .SetMessage(ex.Message)
                        .Build();
                string data = JsonConvert.SerializeObject(response);
                SendData(data);

            }
        }


        private void HandlePlayerBuyUpgrade(string frameData)
        {
            // Do something with the data
            try
            {
                var frame = JsonConvert.DeserializeObject<HostFrameData<List<int>>>(frameData);
                foreach(var item in frame.Data)
                {
                    GameManager.Instance.PlayerBuyUpgrade(Player.Id, item);
                }
                var response = new HostFrameDataBuilder<object>()
                    .SetActionCode(HostActionCode.PlayerBuyUpgrade)
                    .SetMessageType(MessageType.Success)
                    .SetMessage("Your upgrades applied!!")
                    .Build();
                string data = JsonConvert.SerializeObject(response);
                SendData(data);
            }
            catch (Exception ex)
            {
                var response = new HostFrameDataBuilder<object>()
                        .SetActionCode(HostActionCode.InitialConnection)
                        .SetMessageType(MessageType.Error)
                        .SetMessage(ex.Message)
                        .Build();
                string data = JsonConvert.SerializeObject(response);
                SendData(data);

            }
        }

        #endregion



    }
}
