using GTANetworkServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roleplay.Server.User;
using Roleplay.Server.DatabaseManager;
using Roleplay.Server.VehicleControler;
using Roleplay.Server.Job;
using GTANetworkShared;
using System.Threading;

namespace Roleplay.Server.Job
{
    public class Command : Script
    {
        [Command("creerjob")]
        public void CommanndCreerJob(Client player, string nom,string skin, int blip)
        {
            AccountManager account = player.getData("ACCOUNT");

            Data.JobData jobData = new Data.JobData();
            JobManager jobController = new JobManager(jobData);
            jobData.Nom = nom;

            jobData.PosX = player.position.X;
            jobData.PosY = player.position.Y;
            jobData.PosZ = player.position.Z;
            jobData.Skin = skin;
            jobData.Blip = blip;
            ContextFactory.Instance.Job.Add(jobData);
            ContextFactory.Instance.SaveChanges();

            jobController.CreateWorldEntity();
            player.sendChatMessage("~g~Server: ~w~ Added job: " + nom);

        }
        [Command("join")]
        public void JoinCommand(Client player)
        {
            AccountManager account = player.getData("ACCOUNT");


            JobManager job;
            if ((job = player.getData("JOB")) != null)
            {

                account.AccountData.JobId = job.JobInfo.Id;
                player.sendChatMessage("~g~WOT");

            }
            else
            {
                API.sendChatMessageToPlayer(player, "Vous n'ête pas dans un marker");
            }

        }
        [Command("service")]
        public void ServiceCommand(Client player)
        {
            AccountManager account = EntityManager.GetAccount(player.handle);
            JobManager job;
            VehicleManager vehicle = EntityManager.GetVehicle(player.vehicle);
            if(vehicle != null)
            {
                if (account == null)
                {
                    API.sendChatMessageToPlayer(player, "Impossibl de trouver l'utilisateur");
                    return;
                }
                job = EntityManager.GetJob(account.AccountData.JobId);
                if(job == null)
                {
                    API.sendChatMessageToPlayer(player, "Impossibl de trouver le job");
                    return;
                }
                if (account.AccountData.JobId == vehicle.vehicleData.JobID && job != null)
                {
                    if(job.JobInfo.Id == 1)
                    {
                        Bus.ServiceBus(player);
                    }
                }


            }

        }

    }
}
