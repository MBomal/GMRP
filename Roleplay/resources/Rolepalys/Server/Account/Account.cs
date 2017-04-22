using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Roleplay.Data;

namespace Roleplay.Server.Account
{
    [Table("account")]
    public class Account : IAccountData
    {
        public Account() { }

        [Key]
        public string Id { get; set; }

        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string SocialClub { get; set; }
        public virtual ICollection<Character> Character { get; set; }

    }
}
