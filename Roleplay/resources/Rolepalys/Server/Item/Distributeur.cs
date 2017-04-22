using GTANetworkServer;
using GTANetworkShared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roleplay.Server.Item
{
    class Distributeur : Script
    {

        public static void SpawnDistrib()
        {
            Vector3 PositionDistrib = new Vector3(-531.8618, -689.9785, 33.24417);
            Vector3 RotationDistrib = new Vector3(0, 0, -90.80214);
            API.shared.createObject(-870868698, PositionDistrib, RotationDistrib);
            var myBlip = API.shared.createBlip(PositionDistrib);
            var m_colShape = API.shared.createCylinderColShape(PositionDistrib, 2.0f, 3.0f);
            m_colShape.onEntityEnterColShape += (shape, entity) =>
            {
                var players = API.shared.getPlayerFromHandle(entity);

                if (players == null)
                {
                    return;
                }
                else
                {
                    API.shared.sendChatMessageToPlayer(players, "Taper /ATM ouvrir le menu atm");
                }

            };

        }
        [Command("atm")]
        public void RegisterCommand(Client player)
        {
            API.shared.triggerClientEvent(player, "atm");
        }
    }
}
