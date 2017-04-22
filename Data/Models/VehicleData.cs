using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Roleplay.Data
{
    public class VehicleData
    {
        [Key]
        public int Id { get; set; }

        public int Model { get; set; }

        public float PosX { get; set; }

        public float PosY { get; set; }

        public float PosZ { get; set; }

        public float Rot { get; set; }

        public int Color1 { get; set; }

        public int Color2 { get; set; }

        public int OwnerId { get; set; }

        public bool IsRentable { get; set; }

        public int RentalPrice { get; set; }

        public int JobID { get; set; }

        public int RentalOwner { get; set; }

        public bool IsBuyable { get; set;}

        public int SalePrice { get; set; }

        public VehicleData()
        {
        }
    }
}