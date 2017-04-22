using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roleplay.Server.DatabaseManager;
using GTANetworkServer;
using GTANetworkShared;
using Roleplay.Data;

namespace Roleplay.Server.Character
{
    public class CharacterManager : Script
    {
            public Data.CharacterData CharacterData;
            public Client Client { get; set; }

            public CharacterManager()
            {
            }

        public CharacterManager(CharacterData character, Client client)
            {
                CharacterData = character;
                Client = client;
                EntityManager.Add(this);
                client.setData("CHAR", this);
                ContextFactory.Instance.SaveChanges();
            }

    }
}
