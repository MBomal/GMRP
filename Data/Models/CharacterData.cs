using System;
using System.Collections.Generic;
using System.Text;

namespace Roleplay.Data
{
    public class CharacterData
    {
        public int Id { get; set; }

        public string Nom { get; set; }

        public string Prenom { get; set; }

        public int AccountId { get; set; }

        public int SexeChar { get; set; }
        
        public int VisageMere { get; set; }

        public int VisagePere { get; set; }

        public int CheveuxChar { get; set; }

        public int ColCheveux { get; set; }

        public int ColYeux { get; set; }
        
        public int VisageColor { get; set; }

        public int EyeBrown { get; set; }

        public int EyeBrownColor { get; set; }

        public int Cash { get; set; }

        public int JobId { get; set; }

        public CharacterData()
        {

        }
    }
}
