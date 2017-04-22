using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTANetworkServer;
using GTANetworkShared;
using Roleplay.Server.DatabaseManager;
using Roleplay.Data;

namespace Roleplay.Server.User
{
    public class AccountManager
    {
        public Data.AccountData AccountData;
        public Client Client { get; set; }

        public AccountManager()
        {

        }

        public AccountManager(AccountData account,Client client)
        {
            AccountData = account;
            Client = client;
            Client.setData("ACCOUNT", this);
            EntityManager.Add(this);
            ContextFactory.Instance.SaveChanges();
        }
        public static bool DoesPlayerHaveCharacter(Client player,AccountManager account)
        {
            var characterdata = ContextFactory.Instance.Character.Where(x => x.AccountId == account.AccountData.Id).FirstOrDefault();
            if(characterdata == null)
            {
                return false;
            }
            else
            {
                API.shared.triggerClientEvent(player, "setplayerskin", characterdata.SexeChar, characterdata.VisageMere, characterdata.VisagePere, characterdata.CheveuxChar, characterdata.ColCheveux, characterdata.ColYeux, characterdata.VisageColor, characterdata.EyeBrown, characterdata.EyeBrownColor);
                return true;
            }
        }
     
    }
}
