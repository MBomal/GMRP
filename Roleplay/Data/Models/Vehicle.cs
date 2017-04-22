using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data
{
    public class Vehicle
    {
        public int Id { get; set; }

        public int Model { get; set; }

        public float PosX { get; set; }

        public float PosY { get; set; }

        public float PosZ { get; set; }

        public float Rot { get; set; }

        public int Color1 { get; set; }

        public int Color2 { get; set; }

        public Vehicle()
        {
        }
    }
}
