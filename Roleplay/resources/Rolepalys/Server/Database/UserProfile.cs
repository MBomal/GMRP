using System.ComponentModel.DataAnnotations;

namespace Roleplay.Server.DatabaseManager
{
    public class UserProfile
    {
        [Key]
        public int Id { get; set; }

        public string SocialClubName { get; set; }

        public string Password { get; set; }

        public string LastIp { get; set; }
        
        public string LastDisplayName { get; set; }

        public bool Online { get; set; }

        public float PosX { get; set; }

        public float PosY { get; set; }

        public float PosZ { get; set; }

    }
}
