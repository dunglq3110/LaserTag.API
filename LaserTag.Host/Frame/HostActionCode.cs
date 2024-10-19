using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaserTag.Host.Frame
{
    public enum HostActionCode
    {
        //Player credential
        InitialConnection = 0,
        UpdatePlayerData = 1,
        PlayerDisconnected = 2,

        //Game control
        StartMatch = 10,
        NewMatch = 11,
        EndMatch = 12,
        StartRound = 13,
        BattlePhase = 14,
        PauseRound = 15,
        ResumeRound = 16,
        EndRound = 17,

        //Action specific
        SendUpgradesData = 21,
        SendPlayerCredentials = 22,
        SendPlayerAttributes = 23,

        //Client specific
        PlayerBuyUpgrade = 101,
        PlayerGameLog = 102,

        GameMessage = 200,


    }
}
