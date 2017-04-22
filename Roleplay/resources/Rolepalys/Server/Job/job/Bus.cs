using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTANetworkServer;
using GTANetworkShared;
using System.Threading;
using Roleplay.Server.DatabaseManager;

namespace Roleplay.Server.Job
{
    public class Bus : Script
    {

        public static void ServiceBus(Client player)
        {
            API.shared.setPlayerSkin(player, API.shared.pedNameToModel("Nigel"));
            player.setData("SERVICE", true);
            ColShape colShape;
            Vector3[] array2 = new Vector3[] { new Vector3(-541.8779, -653.6155, 33.26973), new Vector3(-517.2524, -659.1254, 33.25596), new Vector3(-498.4512, -663.3369, 33.04462), new Vector3(-481.1889, -667.2081, 32.62642), new Vector3(-466.0343, -667.0591, 32.31685) };

            bool colision = false;
            foreach (var markers in ContextFactory.Instance.JobMarkers.ToList())
            {
                if(markers.JobId == 1)
                {
                    colision = false;
                    API.shared.triggerClientEvent(player, "jobmarker", new Vector3(markers.PosX,markers.PosY,markers.PosZ));
                    colShape = API.shared.createCylinderColShape(new Vector3(markers.PosX, markers.PosY, markers.PosZ), 1f, 1f);
                    colShape.onEntityEnterColShape += (shape, entity) =>
                    {
                        var players = API.shared.getPlayerFromHandle(entity);

                        if (players == null)
                        {
                            return;
                        }
                        else
                        {
                            if (players.handle == player.handle)
                            {
                                API.shared.triggerClientEvent(player, "removeJobMarker");
                                colision = true;
                            }
                        }

                    };
                    while (colision == false)
                    {
                        Thread.Sleep(3000);
                    }
                    API.shared.deleteColShape(colShape);
                }

            }
        }
    }
}
