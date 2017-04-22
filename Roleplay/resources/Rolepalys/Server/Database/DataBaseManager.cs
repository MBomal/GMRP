using GTANetworkServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roleplay.Server.User;
using Roleplay.Data;

namespace Roleplay.Server.DatabaseManager
{
    class DataBaseManager : Script
    {
        public static bool DoesAccountExist(string username)
        {
            if (ContextFactory.Instance.Account.Where(x => x.Username == username).FirstOrDefault() == null) return false;
            return true;
        }
        public static bool RegisterAccount(Client sender, string username, string hash)
        {
            if (!DoesAccountExist(username))
            {
                AccountData account = new AccountData();
                account.Username = username;
                account.Password = hash;
                new AccountManager(account, sender);
                return true;
            }
            return false;
        }
    }
}
