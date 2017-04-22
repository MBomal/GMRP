using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roleplay.Server.Markers

{
    class MarkerManager
    {
        public Data.JobMarker MarkerInfos;
        public MarkerManager()
        {
        }

        public MarkerManager(Data.JobMarker markerInfo)
        {
            this.MarkerInfos = markerInfo;
            EntityManager.Add(this);

        }
    }
}
