using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Roleplay.Data
{
    public class AccountData
    {
        [Key]
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string SocialClub { get; set; }

        public int Cash { get; set; }

        public int JobId { get; set; }

        public int CharacterId { get; set; }

        public int AdminRank { get; set; }

        public AccountData()
        {

        }
    }
}
