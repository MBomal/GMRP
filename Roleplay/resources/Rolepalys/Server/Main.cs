using GTANetworkServer;
using GTANetworkShared;
using System.Linq;
using Roleplay.Server.DatabaseManager;
using Roleplay.Server.Job;
using System.Threading;
using Roleplay.Server.VehicleControler;
using Roleplay.Data;
using Roleplay.Server.Character;
using Roleplay.Server.Item;
using System;

namespace Roleplay.Server
{
    class Main : Script
    {
        private readonly Vector3 CameraVinewood = new Vector3(695.5733, 955.9597, 380.969);
        private readonly Vector3 Rotation = new Vector3();
        public Main()
        {
            API.onResourceStart += OnResourceStart;
            API.onResourceStop += OnResourceStop;
            API.onPlayerConnected += OnPlayerConnected;
            API.onPlayerFinishedDownload += onPlayerDownload;
            API.onPlayerDisconnected += OnPlayerDisconnected;
            API.onClientEventTrigger += API_onClientEventTrigger;
            ColShape camera1 = API.createSphereColShape(new Vector3(819.6917, 1276.67, 360.4718),1f);

        }

        private void API_onClientEventTrigger(Client sender, string eventName, params object[] arguments)
        {
            if (eventName == "CHARFINISHED")
            {
                API.consoleOutput("Test");
                CharacterData newcharData = new CharacterData();
                var accountData = EntityManager.GetAccount(sender.handle);
                newcharData.AccountId = accountData.AccountData.Id;
                newcharData.SexeChar = (int)arguments[0];
                newcharData.VisageMere = (int)arguments[1];
                newcharData.VisagePere = (int)arguments[2];
                newcharData.CheveuxChar = (int)arguments[3];
                newcharData.ColCheveux = (int)arguments[4];
                newcharData.ColYeux = (int)arguments[5];
                newcharData.VisageColor = (int)arguments[6];
                newcharData.EyeBrown = (int)arguments[7];
                newcharData.EyeBrownColor = (int)arguments[8];
                newcharData.Nom = (string)arguments[9];
                newcharData.Prenom = (string)arguments[10];
                CharacterManager characterManager = new CharacterManager(newcharData, sender);
                ContextFactory.Instance.Character.Add(newcharData);
                ContextFactory.Instance.SaveChanges();
                SpawnManager.SpawnManager.SpawnParDefaut(sender);

            }
            if (eventName == "tptoplayer")
            {
                API.consoleOutput("tptoplayer");
                Admin.Command.TpToPlayer(sender, (string)arguments[0]);
            }
            else if (eventName == "tpplayer")
            {
                API.consoleOutput("tpplayer");
                Admin.Command.TpPlayer(sender, (string)arguments[0]);
            }
            else if (eventName == "kickplayer")
            {
                API.consoleOutput("tpplayer");
                Admin.Command.KickPlayer(sender, (string)arguments[0]);
            }else if (eventName == "givemoney")
            {
                API.consoleOutput("givemoney");
                Admin.Command.GiveMoney((string)arguments[0], Int32.Parse((string)arguments[1]));
            }
            else if (eventName == "setrank")
            {
                Admin.Command.SetAdminRank((string)arguments[0], Int32.Parse((string)arguments[1]));
            }
            else if (eventName == "invisible")
            {
                Admin.Command.SetInvisible(sender);
            }
            else if (eventName == "invincible")
            {
                Admin.Command.SetInvincible(sender);
            }
            else if (eventName == "onKeyDown")
            {
                if ((int)arguments[0] == 0)
                {
                    Admin.Command.AdminCommand(sender);
                }
            }
        }

        private void onPlayerDownload(Client player)
        {
            API.setEntityData(player, "Telechargement", true);
            API.setEntityInvincible(player, true);
            player.freeze(true);

            API.triggerClientEvent(player, "createCamera",CameraVinewood,Rotation);
        }

        private void OnResourceStop()
        {
        }

        private void OnResourceStart()
        {
            ContextFactory.SetConnectionParameters("127.0.0.1", "root", "", "example_database");
            VehicleManager.LoadVehicles();
            JobManager.LoadJobs();
            Distributeur.SpawnDistrib();
            
        }

        private void OnPlayerConnected(Client player)
        {
            API.sendChatMessageToPlayer(player, "~b~Bienvenue sur le serveur Taper /register pous vous enregister ou /login pour vous connecter");
            EntityManager.Add(player);
        }
        private void OnPlayerDisconnected(Client player, string reason)
        {
            EntityManager.Remove(player);
        }
    }
}
