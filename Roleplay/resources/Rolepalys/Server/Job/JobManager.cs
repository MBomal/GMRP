using GTANetworkServer;
using GTANetworkShared;
using Roleplay.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roleplay.Server.DatabaseManager;

namespace Roleplay.Server.Job
{
    public class JobManager : Script
    {
        public Data.JobData JobInfo;

        Marker marker;
        ColShape colShape;
        TextLabel textLabel;
        Blip blip;

        public JobManager()
        {

        }

        public JobManager(Data.JobData job)
        {
            JobInfo = job;
            EntityManager.Add(this);
        }
        public static void LoadJobs()
        {
            foreach (var jobs in ContextFactory.Instance.Job)
            {
                JobManager jobManager = new JobManager(jobs);
                jobManager.CreateWorldEntity();
            }
            API.shared.consoleOutput("[GM] Jobs initialisez : " + ContextFactory.Instance.Job.Count());

        }

        public void CreateWorldEntity()
        {
            marker = API.createMarker(1, new Vector3(JobInfo.PosX, JobInfo.PosY, JobInfo.PosZ) - new Vector3(0, 0, 1f), new Vector3(), new Vector3(), new Vector3(1f, 1f, 1f), 100, 255, 255, 255);
            blip = API.createBlip(new Vector3(JobInfo.PosX, JobInfo.PosY, JobInfo.PosZ));
            API.setBlipSprite(blip, JobInfo.Blip);
            textLabel = API.createTextLabel("~p~ Metier : " + JobInfo.Nom, new Vector3(JobInfo.PosX, JobInfo.PosY, JobInfo.PosZ) + new Vector3(0.0f, 0.0f, 0.5f),15.0f,0.5f);
            CreateColShape();

        }

        public void CreateColShape()
        {
            colShape = API.createCylinderColShape(new Vector3(JobInfo.PosX, JobInfo.PosY, JobInfo.PosZ),5f,5f);
            colShape.onEntityEnterColShape += (shape, entity) =>
            {
                var player = API.getPlayerFromHandle(entity);

                if (player == null)
                {
                    return;
                }
                else
                {
                    player.sendChatMessage("Taper /join pour obtenir ce metier");
                    player.setData("JOB", this);
                }
            };
            colShape.onEntityExitColShape += (shape, entity) =>
            {
                var player = API.getPlayerFromHandle(entity);
                if (player == null)
                {
                    return;
                }
                else
                {
                    player.resetData("JOB");

                }
            };

        }
    }
}
