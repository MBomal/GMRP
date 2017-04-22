using GTANetworkServer;
using Roleplay.Server.DatabaseManager;
using System.Linq;
using Roleplay.SpawnManager;
using Roleplay.Data;
using System;
using Roleplay.Server.User;
using GTANetworkShared;

namespace Roleplay.Server.Account
{
    public class AccountCommands : Script
    {
        public AccountManager accountManager;
        private Vector3 Camera = new Vector3(800.294, 1170.92, 322.407);
        private Vector3 CameraRot = new Vector3(0f, 0f, -62.2813);
        private Vector3 PosJoueur = new Vector3(402.612, -996.3103, -99.00027);
        [Command("register", GreedyArg = true)]
        public void RegisterCommand(Client player, string username, string hash)
        {
            AccountData account = new AccountData();
            account.Username = username;
            account.Password = hash;
            account.SocialClub = player.socialClubName;
            ContextFactory.Instance.Account.Add(account);
            ContextFactory.Instance.SaveChanges();
            new AccountManager(account, player);
            API.setEntityInvincible(player, false);
            player.freeze(false);
            API.triggerClientEvent(player, "exitCamera");
            SpawnManager.SpawnManager.SpawnParDefaut(player);
            API.shared.sendChatMessageToPlayer(player, "~r~[~w~INFO~r~]~g~ Vous êtes a présent enregistrer et connecter au serveur");
            API.triggerClientEvent(player, "StarCharacterCustomizationTrigger", player);
            player.position = PosJoueur;
            player.rotation = new Vector3(0, 0, 177.1582);
        }
        [Command("login", GreedyArg = true)]
        public void LoginCommand(Client player, string name, string password)
        {
            if (API.shared.getEntityData(player, "ACCOUNT") != null)
            {
                API.shared.sendChatMessageToPlayer(player, "~r~SERVER: ~w~Vous êtes deja connecté");
                return;
            }
            var accountData = ContextFactory.Instance.Account.Where(x => x.Username == name).FirstOrDefault();
            if (accountData != null && (password == accountData.Password))
            {

                AccountManager infoCompte = new AccountManager(accountData, player);
                API.shared.sendChatMessageToPlayer(player, "~r~[~w~INFO~r~]~g~ Vous êtes maintenant connecté au serveur");
                API.setEntityInvincible(player, false);
                player.freeze(false);
                if (AccountManager.DoesPlayerHaveCharacter(player,infoCompte))
                {
                    API.triggerClientEvent(player, "exitCamera");
                    SpawnManager.SpawnManager.SpawnParDefaut(player);
                    return;
                }
                else
                {
                    API.triggerClientEvent(player, "StarCharacterCustomizationTrigger", player);
                    player.position = new Vector3(402.612, -996.3103, -99.00027);
                    player.rotation = new Vector3(0,0, 177.1582);
                }
            }
            else
            {
                API.shared.sendChatMessageToPlayer(player, "~r~ERROR:~w~ Mot de passe incorrect ou compte inexistant");
            }
        }
    }
}
