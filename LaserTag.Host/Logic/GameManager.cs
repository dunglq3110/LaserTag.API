using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp.Server;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using LaserTag.Host.Models;
using LaserTag.Host.Dtos;
using System.Windows;
using LaserTag.Host.Frame;
using Newtonsoft.Json;

namespace LaserTag.Host.Logic
{
    public partial class GameManager : ObservableObject
    {
        #region Singleton
        private static GameManager _instance;
        
        private GameManager() 
        {
            //InitData();
            InitDataAttribute();
            InitDataUpgrade();
            InitDataGameConfig();
        }

        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GameManager();
                }
                return _instance;
            }
        }
        #endregion

        #region Websocket
        
        private WebSocketServer _wssv;

        [ObservableProperty]
        private string ipAddress;
        public void StartWebSocketServer()
        {
            try
            {
                // Check if WebSocketServer is already initialized
                if (_wssv == null)
                {
                    IpAddress = GetLocalIPv4();
                    _wssv = new WebSocketServer($"ws://{IpAddress}:8080");
                    _wssv.AddWebSocketService<PlayerClientSession>("/LaserTag");
                    _wssv.Start();
                }
                else
                {
                    // WebSocketServer is already running, do nothing
                }
            }
            catch (Exception ex)
            {
                // Handle exception if necessary
            }
        }

        private string GetLocalIPv4()
        {
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("8.8.8.8", 65530);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                return endPoint.Address.ToString();
            }
        }
        #endregion

        #region Game logic

        #region Player Operations
        [ObservableProperty]
        private ObservableCollection<Player> team1Players = [];

        [ObservableProperty]
        private ObservableCollection<Player> team2Players = [];

        [ObservableProperty]
        private ObservableCollection<Player> team3Players = [];

        [ObservableProperty]
        private ObservableCollection<Player> team4Players = [];
        
        [ObservableProperty]
        private ObservableCollection<Player> allPlayers = [];

        public Dictionary<string, PlayerClientSession> PlayerClients = [];

        public void MovePlayer(Player player, ObservableCollection<Player> sourceTeam, ObservableCollection<Player> targetTeam)
        {
            sourceTeam.Remove(player);
            targetTeam.Add(player);
            var response = new HostFrameDataBuilder<object>()
                        .SetActionCode(HostActionCode.UpdatePlayerData)
                        .SetMessageType(MessageType.Info)
                        .SetMessage("Player " + player.Name + " Move to team __")
                        .Build();
            //NotifyAllPlayerExcept(response, player.ConnectionId);
            string data = JsonConvert.SerializeObject(response);
            NotifyAllPlayer(data);
        }

        public void AddPlayer(PlayerClientSession playerClientSession)
        {
            PlayerClients[playerClientSession.ID] = playerClientSession;

            Application.Current.Dispatcher.Invoke(() =>
            {
                Team1Players.Add(playerClientSession.Player);
                AllPlayers.Add(playerClientSession.Player);
            });

            var response = new HostFrameDataBuilder<object>()
                        .SetActionCode(HostActionCode.InitialConnection)
                        .SetMessageType(MessageType.Info)
                        .SetMessage("Player " + playerClientSession.Player.Name + " Joined the room!!")
                        .Build();
            //NotifyAllPlayerExcept(response, player.ConnectionId);
            string data = JsonConvert.SerializeObject(response);
            NotifyAllPlayer(data);

        }

        public void RemovePlayer(Player player)
        {
        }

        public void NotifyAllPlayer(string data)
        {
            foreach (var playerClient in PlayerClients)
            {
                playerClient.Value.SendData(data);
            }
        }

        public void NotifyAllPlayerExcept(string data, params string[] excludedKeys)
        {
            // Convert the array of excluded keys to a HashSet for fast lookup
            var excludedKeySet = new HashSet<string>(excludedKeys);

            foreach (var playerClient in PlayerClients)
            {
                // Check if the player's key (ID) is not in the excluded list
                if (!excludedKeySet.Contains(playerClient.Key))
                {
                    playerClient.Value.SendData(data);
                }
            }
        }
        #endregion

        #region Upgrade & player attribute logic

        [ObservableProperty]
        private ObservableCollection<Config> defaultPlayerAttribute = [];

        [ObservableProperty]
        private ObservableCollection<GameAttribute> gameAttributes = [];

        [ObservableProperty]
        private ObservableCollection<Upgrade> upgrades = [];

        [ObservableProperty]
        private ObservableCollection<UpgradeAttribute> upgradeAttributes = [];

        [ObservableProperty]
        private ObservableCollection<PlayerUpgrades> playerUpgrades = [];

        private Dictionary<int, Dictionary<string, int>> playerUpgradeCache = new Dictionary<int, Dictionary<string, int>>();

        public void PlayerBuyUpgrade(int playerId, int upgradeId)
        {
            var player = AllPlayers.FirstOrDefault(p => p.Id == playerId);
            var upgrade = Upgrades.FirstOrDefault(u => u.Id == upgradeId);

            if (player == null || upgrade == null)
            {
                throw new ArgumentException("Player or Upgrade not found.");
            }

            if (player.Credit < upgrade.Cost)
            {
                throw new InvalidOperationException("Insufficient funds to buy the upgrade.");
            }

            var playerUpgrade = new PlayerUpgrades
            {
                Player = player,
                Upgrade = upgrade
            };

            PlayerUpgrades.Add(playerUpgrade);
            player.Credit -= upgrade.Cost;

            // Update the upgrade cache
            if (!playerUpgradeCache.ContainsKey(playerId))
            {
                playerUpgradeCache[playerId] = new Dictionary<string, int>();
            }

            foreach (var attribute in upgrade.Attributes)
            {
                if (!playerUpgradeCache[playerId].ContainsKey(attribute.GameAttribute.CodeName))
                {
                    playerUpgradeCache[playerId][attribute.GameAttribute.CodeName] = 0;
                }
                playerUpgradeCache[playerId][attribute.GameAttribute.CodeName] += attribute.Value;
            }
        }

        public void AssignPlayerAttributeAfterUpgrades()
        {
            foreach (var player in AllPlayers)
            {
                Dictionary<string, int> playerUpgrades = new Dictionary<string, int>();
                if (playerUpgradeCache.ContainsKey(player.Id))
                {
                    playerUpgrades = playerUpgradeCache[player.Id];
                }

                foreach (var attribute in GameAttributes)
                {
                    // Get the default value from Config
                    var defaultConfig = DefaultPlayerAttribute.FirstOrDefault(c => c.CodeName == attribute.CodeName);
                    int baseValue = defaultConfig != null ? int.Parse(defaultConfig.Value1) : 0;

                    // Get the upgrade value from the cache
                    int upgradeValue = playerUpgrades.ContainsKey(attribute.CodeName) ? playerUpgrades[attribute.CodeName] : 0;

                    // Calculate total value
                    int totalValue = baseValue + upgradeValue;

                    // Set or update the player's attribute
                    var existingAttribute = player.PlayerAttributes.FirstOrDefault(pa => pa.GameAttribute.Id == attribute.Id);
                    if (existingAttribute != null)
                    {
                        existingAttribute.Value = totalValue;
                    }
                    else
                    {
                        player.AddAttribute(attribute, totalValue);
                    }

                    // Update CurrentHealth and CurrentBullet based on max values
                    if (attribute.CodeName == "health_max")
                    {
                        player.CurrentHealth = totalValue;
                    }
                    else if (attribute.CodeName == "bullet_max")
                    {
                        player.CurrentBullet = totalValue;
                    }
                }
            }
        }

        public void PrepareForNewRound()
        {
            // Reset current health and bullets to max values for each player
            foreach (var player in AllPlayers)
            {
                var maxHealth = player.GetAttributeValue("health_max") ?? 100; // Default to 100 if not set
                var maxBullet = player.GetAttributeValue("bullet_max") ?? 10;  // Default to 10 if not set

                player.CurrentHealth = maxHealth;
                player.CurrentBullet = maxBullet;
            }
        }

        public void SendPlayerAttributes()
        {
            foreach (var player in AllPlayers)
            {
                var attributesData = new Dictionary<string, int>();

                // Populate the dictionary with the player's attributes
                foreach (var attribute in player.PlayerAttributes)
                {
                    attributesData[attribute.GameAttribute.CodeName] = attribute.Value;
                }

                // Create the HostFrameData using the builder
                var attributesFrame = new HostFrameDataBuilder<Dictionary<string, int>>()
                    .SetActionCode(HostActionCode.SendPlayerAttributes) // Assuming 23 is the correct enum value
                    .SetMessageType(MessageType.Info)
                    .SetMessage("Player attributes!!")
                    .SetData(attributesData)
                    .Build();

                // Serialize and send the data to the player
                string serializedFrame = JsonConvert.SerializeObject(attributesFrame);
                PlayerClients[player.ConnectionId].SendData(serializedFrame);
            }
        }

        #endregion

        #region Game play
        [ObservableProperty]
        private Match match;

        [ObservableProperty]
        private ObservableCollection<Round> rounds = [];

        [ObservableProperty]
        private ObservableCollection<Config> gameConfigs = [];

        [ObservableProperty]
        private Round currentRound;

        [ObservableProperty]
        private int roundPermach;

        [ObservableProperty]
        private int timePerRound; //in seconds




        public void StartGame()
        {
            
            SendTeamCredential();
            Match = new Match();

            var gameStartFrame = new HostFrameDataBuilder<Object>()
                       .SetActionCode(HostActionCode.StartMatch)
                       .SetMessageType(MessageType.Info)
                       .SetMessage("Game start!!")
                       .Build();
            string data = JsonConvert.SerializeObject(gameStartFrame);
            NotifyAllPlayer(data);
        }

        public void StartRoundBuyPhase()
        {
            //BattlePhase
            CurrentRound = new Round();
            Rounds.Add(CurrentRound);
            var newRoundFrame = new HostFrameDataBuilder<Object>()
                       .SetActionCode(HostActionCode.StartRound)
                       .SetMessageType(MessageType.Info)
                       .SetMessage("Round started!!")
                       .Build();
            NotifyAllPlayer(JsonConvert.SerializeObject(newRoundFrame));

            foreach (var player in AllPlayers)
            {
                var upgradesFrame = new HostFrameDataBuilder<ListUpgradesDTO>()
                       .SetActionCode(HostActionCode.SendUpgradesData)
                       .SetMessageType(MessageType.Info)
                       .SetMessage("Equipment upgrades!!")
                       .SetData(new ListUpgradesDTO
                       {
                           Credit = player.Credit,
                           Upgrades = Upgrades.ToList()
                       })
                       .Build();
                PlayerClients[player.ConnectionId].SendData(JsonConvert.SerializeObject(upgradesFrame));
            }
            PrepareForNewRound();
            //player buy some upgrades
/*            PlayerBuyUpgrade(1, 1);
            PlayerBuyUpgrade(2, 1);
            PlayerBuyUpgrade(2, 2);*/
        }

        public void BattlePhase()
        {
            AssignPlayerAttributeAfterUpgrades();
            SendPlayerAttributes();
            var battlePhaseFrame = new HostFrameDataBuilder<Object>()
                       .SetActionCode(HostActionCode.BattlePhase)
                       .SetMessageType(MessageType.Info)
                       .SetMessage("Battle Phase!!")
                       .Build();
            NotifyAllPlayer(JsonConvert.SerializeObject(battlePhaseFrame));
        }
        public void EndRound()
        {
            CurrentRound.EndTime = DateTime.Now;
            var endRoundFrame = new HostFrameDataBuilder<Object>()
                       .SetActionCode(HostActionCode.StartRound)
                       .SetMessageType(MessageType.Info)
                       .SetMessage("Round ended!!")
                       .Build();
            var data = JsonConvert.SerializeObject(endRoundFrame);
            NotifyAllPlayer(data);
        }
        public void PauseRound()
        {
            var endRoundFrame = new HostFrameDataBuilder<Object>()
                       .SetActionCode(HostActionCode.PauseRound)
                       .SetMessageType(MessageType.Info)
                       .SetMessage("Round Paused!!")
                       .Build();
            var data = JsonConvert.SerializeObject(endRoundFrame);
            NotifyAllPlayer(data);
        }

        public void ResumeRound()
        {
            var endRoundFrame = new HostFrameDataBuilder<Object>()
                       .SetActionCode(HostActionCode.ResumeRound)
                       .SetMessageType(MessageType.Info)
                       .SetMessage("Round Resume!!")
                       .Build();
            var data = JsonConvert.SerializeObject(endRoundFrame);
            NotifyAllPlayer(data);
        }

        public void EndMatch()
        {
            var endRoundFrame = new HostFrameDataBuilder<Object>()
                       .SetActionCode(HostActionCode.EndMatch)
                       .SetMessageType(MessageType.Info)
                       .SetMessage("Match End!!")
                       .Build();
            var data = JsonConvert.SerializeObject(endRoundFrame);
            NotifyAllPlayer(data);
        }

        public void SendTeamCredential()
        {
            // Initialize the list of PlayerCredentialResponse
            List<PlayerCredentialResponse> credentials = [];

            // Loop through allPlayers and assign team IDs based on which team the player is in
            foreach (var player in AllPlayers)
            {
                string teamId = string.Empty;

                if (Team1Players.Contains(player))
                {
                    teamId = "01";  // Team 1
                }
                else if (Team2Players.Contains(player))
                {
                    teamId = "02";  // Team 2
                }
                else if (Team3Players.Contains(player))
                {
                    teamId = "03";  // Team 3
                }
                else if (Team4Players.Contains(player))
                {
                    teamId = "04";  // Team 4
                }

                // Create PlayerCredentialResponse for the player
                var credential = new PlayerCredentialResponse
                {
                    PlayerId = player.Id.ToString(),
                    MacGun = player.MacGun,
                    MacVest = player.MacVest,
                    TeamId = teamId
                };

                // Add to the credentials list
                credentials.Add(credential);
            }
            var hostFrameData = new HostFrameDataBuilder<List<PlayerCredentialResponse>>()
                        .SetActionCode(HostActionCode.UpdatePlayerData)
                        .SetMessageType(MessageType.Response)
                        .SetMessage("Player Credentials")
                        .SetData(credentials)
                        .Build();
            string data = JsonConvert.SerializeObject(hostFrameData);
            NotifyAllPlayer(data);
            // Loop through the PlayerClients and send the credentials to each player

        }

        

        #endregion

        #endregion



        public void Test()
        {
            
            var test1 = AllPlayers;
            
        }

        #region InitData
        public void InitDataAttribute()
        {
            // Step 1: Load the Config data (simulated from the seeded database)
            var configData = new List<Config>
            {
                //Default player attributes
                new Config { Id = 1, Name = "Default Player Damage", CodeName = "damage_value", Value1 = "10" },
                new Config { Id = 2, Name = "Default Player Max Bullet", CodeName = "bullet_max", Value1 = "10" },
                new Config { Id = 3, Name = "Player Fire Level", CodeName = "fire_level", Value1 = "0" },
                new Config { Id = 4, Name = "Max Health", CodeName = "health_max", Value1 = "100" },
                new Config { Id = 5, Name = "Armor", CodeName = "armor_value", Value1 = "50" },
                new Config { Id = 6, Name = "Initial money", CodeName = "money_init", Value1 = "1000" },
               
            };

            // Add to the existing ObservableCollection
            foreach (var config in configData)
            {
                DefaultPlayerAttribute.Add(config);
            }

            // Step 2: Create a list of GameAttributes (simulated attribute definitions from the attribute table)
            var newGameAttributes = new List<GameAttribute>
            {
                new GameAttribute { Id = 1, Name = "Damage Value", CodeName = "damage_value", IsGun = true },
                new GameAttribute { Id = 2, Name = "Max Bullet", CodeName = "bullet_max", IsGun = true },
                new GameAttribute { Id = 3, Name = "Fire Level", CodeName = "fire_level", IsGun = true },
                new GameAttribute { Id = 4, Name = "Max Health", CodeName = "health_max", IsGun = false },
                new GameAttribute { Id = 5, Name = "Armor", CodeName = "armor_value", IsGun = false }
            };

            // Add to the existing ObservableCollection
            foreach (var gameAttribute in newGameAttributes)
            {
                GameAttributes.Add(gameAttribute);
            }


        }
        public void InitDataUpgrade()
        {
            var newUpgrades = new List<Upgrade>
            {
                new Upgrade
                {
                    Id = 1,
                    Name = "Attack plus",
                    Cost = 500,
                    Description = "Increases attack attributes.",
                    Attributes = new List<UpgradeAttribute>()
                },
                new Upgrade
                {
                    Id = 2,
                    Name = "Defense plus",
                    Cost = 400,
                    Description = "Increases defense attributes.",
                    Attributes = new List<UpgradeAttribute>()
                }
            };

            var upgradeAttributes = new List<UpgradeAttribute>
            {
                new UpgradeAttribute
                {
                    Id = 1,
                    GameAttribute = GameAttributes.First(g => g.Id == 1), // Damage Value 
                    Value = 10
                },
                new UpgradeAttribute
                {
                    Id = 2,
                    GameAttribute = GameAttributes.First(g => g.Id == 2), // Max Bullet 
                    Value = 5
                },
                new UpgradeAttribute
                {
                    Id = 6,
                    GameAttribute = GameAttributes.First(g => g.Id == 4), // Max Health 
                    Value = 50
                },
                new UpgradeAttribute
                {
                    Id = 7,
                    GameAttribute = GameAttributes.First(g => g.Id == 5), // Armor
                    Value = 50
                }
            };

            // Associate UpgradeAttributes with their corresponding Upgrades
            newUpgrades[0].Attributes.Add(upgradeAttributes[0]); // Attack plus - Damage Value
            newUpgrades[0].Attributes.Add(upgradeAttributes[1]); // Attack plus - Max Bullet
            newUpgrades[1].Attributes.Add(upgradeAttributes[2]); // Defense plus - Max Health
            newUpgrades[1].Attributes.Add(upgradeAttributes[3]); // Defense plus - Armor

            // Set the Upgrade reference for each UpgradeAttribute
            foreach (var upgrade in newUpgrades)
            {
                foreach (var attribute in upgrade.Attributes)
                {
                    attribute.Upgrade = upgrade;
                }
            }

            // Update the ObservableCollections
            Upgrades = new ObservableCollection<Upgrade>(newUpgrades);
            UpgradeAttributes = new ObservableCollection<UpgradeAttribute>(upgradeAttributes);
        }
        public void InitDataGameConfig()
        {
            var configs = new List<Config>
            {
                new Config { Id = 7, Name = "Rounds per match", CodeName = "round_per_match", Value1 = "3" },
                new Config { Id = 8, Name = "Time per round", CodeName = "time_round", Value1 = "10" },
            };

            // Add to the existing ObservableCollection
            foreach (var config in configs)
            {
                GameConfigs.Add(config);
            }
        }
        #endregion
    }
}
