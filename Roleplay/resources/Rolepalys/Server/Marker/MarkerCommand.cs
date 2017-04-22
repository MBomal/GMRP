using GTANetworkServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roleplay.Server.DatabaseManager;
namespace Roleplay.Server.Markers
{
    class MarkerCommand : Script
    {
        [Command("creermarker")]
        public void VspawnCommand(Client player,int jobid)
        {
            Data.JobMarker NewMarker = new Data.JobMarker();
            NewMarker.JobId = jobid;
            NewMarker.PosX = player.position.X;
            NewMarker.PosY = player.position.Y;
            NewMarker.PosZ = player.position.Z;
            MarkerManager newMarker = new MarkerManager(NewMarker);
            ContextFactory.Instance.JobMarkers.Add(NewMarker);
            ContextFactory.Instance.SaveChanges();
        }
    }
}
