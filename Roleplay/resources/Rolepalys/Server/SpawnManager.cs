using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GTANetworkServer;
using GTANetworkShared;
using Roleplay.Server.DatabaseManager;

namespace Roleplay.SpawnManager
{
    public class SpawnManager : Script
    {

        public SpawnManager()
        {
        }
        public static void SpawnParDefaut(Client player)
        {
            Vector3 position = new Vector3(-556.1747, -630.0729, 34.67398); //X Y Z Position de spawn
            player.position = position;
        }
    }
}

