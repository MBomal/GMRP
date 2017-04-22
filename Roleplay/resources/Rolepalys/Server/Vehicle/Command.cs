using Roleplay.Data;
using System;
using System.Collections.Generic;
using Roleplay.Server;
using Roleplay.Server.User;
using GTANetworkServer;
using Roleplay.Server.DatabaseManager;
using GTANetworkShared;

namespace Roleplay.Server.VehicleControler
{
    public class Command : Script
    {
        [Command("vspawn")]
        public void VspawnCommand(Client player, VehicleHash model, int color1, int color2, int ownerId)
        {
            Data.VehicleData NewVehicleData = new Data.VehicleData();
            NewVehicleData.Model = model.GetHashCode();
            NewVehicleData.PosX = player.position.X;
            NewVehicleData.PosY = player.position.Y;
            NewVehicleData.PosZ = player.position.Z;
            NewVehicleData.Color1 = color1;
            NewVehicleData.Color2 = color2;
            NewVehicleData.OwnerId = ownerId;
            VehicleManager VehicleManager = new VehicleManager(NewVehicleData, API.createVehicle(model, player.position, player.rotation, color1, color2));
            ContextFactory.Instance.Vehicles.Add(NewVehicleData);
            ContextFactory.Instance.SaveChanges();

        }
        [Command("v", GreedyArg = true)]
        public void VCommand(Client player, string engine)
        {
            if (player.isInVehicle)
            {
                AccountManager account = EntityManager.GetAccount(player.handle);
                if (account == null)
                {
                    API.sendChatMessageToPlayer(player, "Vous n'êtes pas connectés au serveur");
                }
                VehicleManager vehicle = EntityManager.GetVehicle(player.vehicle);
                if (player.vehicleSeat != -1)
                {
                    API.sendChatMessageToPlayer(player, "Vous devez être dans le siege conducteur afin de demarrer le vehicule");
                }
                else if (vehicle.vehicleData.OwnerId == account.AccountData.Id)
                {
                    if (engine == "moteur")
                    {
                        if (API.getVehicleEngineStatus(vehicle.Vehicle))
                        {
                            var msg = "~p~" + player.name + " Tourne sa clé dans le contact et arrete le véhicule";
                            var players = API.getPlayersInRadiusOfPlayer(30, player);
                            foreach (Client c in players)
                            {
                                API.sendChatMessageToPlayer(c, msg);
                            }
                            player.vehicle.engineStatus = false;
                        }
                        else if (!API.getVehicleEngineStatus(vehicle.Vehicle))
                        {
                            var msg = "~p~" + player.name + " Insere sa clé dans le contact, la tourne et demarre le vehicule";
                            var players = API.getPlayersInRadiusOfPlayer(30, player);

                            foreach (Client c in players)
                            {
                                API.sendChatMessageToPlayer(c, msg);
                            }
                            player.vehicle.engineStatus = true;
                        }
                        else
                        {
                            API.sendChatMessageToPlayer(player, "Vous n'avez pas acces a ce vehicule");
                        }
                    }

                    if (engine == "garer")
                    {
                        vehicle.vehicleData.PosX = player.position.X;
                        vehicle.vehicleData.PosY = player.position.Y;
                        vehicle.vehicleData.PosZ = player.position.Z;
                        ContextFactory.Instance.SaveChanges();
                    }

                }
                else
                {
                    API.sendChatMessageToPlayer(player, "Vous n'êtes pas le propriétaire de ce véhicule");
                }
                
            }
        }
    }
}
