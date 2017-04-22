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
    public class VehicleCommand : Script
    {
        [Command("vspawn")]
        public void VspawnCommand(Client player, VehicleHash model, int color1, int color2, int ownerId,int jobid,bool rentable, int rentalPrice, bool buyable, int price)
        {
            Data.VehicleData NewVehicleData = new Data.VehicleData();
            NewVehicleData.Model = model.GetHashCode();
            NewVehicleData.PosX = player.position.X;
            NewVehicleData.PosY = player.position.Y;
            NewVehicleData.PosZ = player.position.Z;
            NewVehicleData.Rot = player.rotation.Z;
            NewVehicleData.IsRentable = rentable;
            NewVehicleData.Color1 = color1;
            NewVehicleData.Color2 = color2;
            NewVehicleData.OwnerId = ownerId;
            NewVehicleData.JobID = jobid;
            NewVehicleData.RentalOwner = -1;
            NewVehicleData.IsBuyable = buyable;
            NewVehicleData.SalePrice = price;
            VehicleManager VehicleManager = new VehicleManager(NewVehicleData, API.createVehicle(model, player.position, player.rotation, color1, color2));
            ContextFactory.Instance.Vehicles.Add(NewVehicleData);
            ContextFactory.Instance.SaveChanges();

        }
        [Command("v")]
        public void VCommand(Client player, string engine, int price = 0)
        {
            if (player.isInVehicle)
            {
                AccountManager account = EntityManager.GetAccount(player.handle);
                if (account == null)
                {
                    API.sendChatMessageToPlayer(player, "Vous n'êtes pas connectés au serveur");
                    return;
                }
                VehicleManager vehicle = EntityManager.GetVehicle(player.vehicle);

            if (vehicle.vehicleData.OwnerId == account.AccountData.Id || vehicle.vehicleData.RentalOwner == account.AccountData.Id || vehicle.vehicleData.JobID == account.AccountData.JobId)
            {
                if (engine == "moteur")
                {
                    if (player.vehicleSeat != -1)
                    {
                        API.sendChatMessageToPlayer(player, "~r~[~w~INFO~r~]~g~ Vous devez être dans le siege conducteur afin de demarrer le vehicule");
                    }
                    else if (API.getVehicleEngineStatus(vehicle.Vehicle))
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
                        API.sendChatMessageToPlayer(player, "~r~[~w~INFO~r~]~g~ Vous n'avez pas acces a ce vehicule");
                    }
                }

                if (engine == "garer")
                {
                    if (vehicle.vehicleData.OwnerId == account.AccountData.Id)
                    { 
                            vehicle.vehicleData.PosX = player.position.X;
                            vehicle.vehicleData.PosY = player.position.Y;
                            vehicle.vehicleData.PosZ = player.position.Z;
                            vehicle.vehicleData.Rot = player.rotation.Z;
                            ContextFactory.Instance.SaveChanges();
                    }
                }
               /* if (engine == "vendre")
                {
                    vehicle.vehicleData.IsBuyable = true;
                    vehicle.vehicleData.SalePrice = price;
                    ContextFactory.Instance.SaveChanges();
                }
                */
            }
            else if(engine == "acheter")
            {
                    if (vehicle.vehicleData.IsBuyable)
                    {
                        if (account.AccountData.Cash >= vehicle.vehicleData.SalePrice)
                        {
                            account.AccountData.Cash -=vehicle.vehicleData.SalePrice;
                            vehicle.vehicleData.OwnerId = account.AccountData.Id;
                            vehicle.vehicleData.IsBuyable = false;
                            ContextFactory.Instance.SaveChanges();
                            API.sendChatMessageToPlayer(player, "~r~[~w~INFO~r~]~g~ Felicitation vous venez d'acquérir un nouveau vehicule");

                        }
                        else
                        {
                            API.sendChatMessageToPlayer(player, "~r~[~w~INFO~r~]~g~ Vous n'avez pas assez d'argent pour acheter ce vehicule");
                        }
                    }
                    else
                    {
                        API.sendChatMessageToPlayer(player, "~r~[~w~INFO~r~]~g~ Ce vehicule n'est pas en vente");
                    }
            }
            else if (engine == "louer")
            {
                    if(vehicle.vehicleData.IsRentable == true && vehicle.vehicleData.RentalOwner == -1)
                    {
                    if(account.AccountData.Cash >= vehicle.vehicleData.RentalPrice)
                    {
                        account.AccountData.Cash -= vehicle.vehicleData.RentalPrice;
                        vehicle.vehicleData.RentalOwner = account.AccountData.Id;
                        ContextFactory.Instance.SaveChanges();
                        API.sendChatMessageToPlayer(player, "~r~[~w~INFO~r~]~g~ Felicitation, vous louez a présent ce vehicule");
                    }
                    }
                    else
                    {
                        API.sendChatMessageToPlayer(player, "~r~[~w~INFO~r~]~g~ Ce vehicule n'est pas louable ou est deja loué par une autre personne");
                    }
            }
            else
            {
                API.sendChatMessageToPlayer(player, "~r~[~w~INFO~r~]~g~ Vous n'êtes pas le propriétaire de ce véhicule");
            }
                
            }
        }
    }
}
