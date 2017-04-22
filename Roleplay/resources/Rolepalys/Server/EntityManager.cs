using GTANetworkServer;
using GTANetworkShared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Roleplay.Server.VehicleControler;
using Roleplay.Server.User;
using Roleplay.Server.Job;
using Roleplay.Server.Markers;
using Roleplay.Server.Character;

namespace Roleplay.Server
{
    public class EntityManager
    {
        private static List<VehicleManager> _VehicleManager = new List<VehicleManager>();
        private static List<AccountManager> _AccountManager = new List<AccountManager>();
        private static List<MarkerManager> _MarkerManager = new List<MarkerManager>();
        private static List<CharacterManager> _CharacterManager = new List<CharacterManager>();
        private static List<Client> _Client = new List<Client>();

        internal static void Add(MarkerManager marker)
        {
            _MarkerManager.Add(marker);
        }

        internal static void Add(CharacterManager characterManager)
        {
            _CharacterManager.Add(characterManager);
        }

        internal static object GetCharacter(int id)
        {
            return _CharacterManager.Find(x => x.CharacterData.AccountId == id);
        }
        //Client
        public static List<Client> GetClientList()
        {
            return _Client;
        }
        internal static void Remove(Client player)
        {
            _Client.Remove(player);
        }
        internal static void Add(Client player)
        {
            _Client.Add(player);
        }
        public static Client GetClient(string SocialClub)
        {
            return _Client.Find(x => x.socialClubName == SocialClub);
        }

        private static List<JobManager> _JobManager = new List<JobManager>();


        internal static void Add(AccountManager account)
        {
            _AccountManager.Add(account);
        }

        internal static void Add(JobManager jobManager)
        {
            _JobManager.Add(jobManager);
        }
        internal static void Add(VehicleManager vehicle)
        {
            _VehicleManager.Add(vehicle);
        }

        public static AccountManager GetAccount(NetHandle account)
        {
            return _AccountManager.Find(x => x.Client.handle == account);
        }
        public static AccountManager GetAccount(int id)
        {
            return _AccountManager.Find(x => x.AccountData.Id == id);
        }
        public static JobManager GetJob(int id)
        {
            return _JobManager.Find(x => x.JobInfo.Id == id);
        }

        public static VehicleManager GetVehicle(NetHandle vehicle)
        {
            return _VehicleManager.Find(x => x.Vehicle.handle == vehicle);
        }
    }
}
