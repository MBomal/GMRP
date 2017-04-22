using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel;

namespace Roleplay.Data
{
    public class JobMarker 
    {
        [Key]
        public int Id { get; set; }
        public float PosX { get; set; }
        public float PosY { get; set; }
        public float PosZ { get; set; }
        public int  JobId { get; set; }

    }
}
