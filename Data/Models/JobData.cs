using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel;

namespace Roleplay.Data
{
    public class JobData
    {
        [Key]
        public int Id { get; set; }
        public string Nom { get; set; }
        public float PosX { get; set; }
        public float PosY { get; set; }
        public float PosZ { get; set; }
        public string Skin { get; set; }
        public int Blip { get; set; }

    }
}
