using GTANetworkServer;
using System.Linq;
using Roleplay.Server.DatabaseManager;
using GTANetworkShared;
using Roleplay.Data;
using System;
using System.Collections.Generic;
using Roleplay.Server;
using Roleplay.Server.User;

namespace Roleplay.Server.VehicleControler
{
    public class VehicleManager : Script
    {
        public Data.VehicleData vehicleData;
        public Vehicle Vehicle;

        public VehicleManager()
        {
            API.onPlayerEnterVehicle += OnPlayerEnterVehicle;
        }

        public VehicleManager(Data.VehicleData VehicleData , Vehicle vehicle)
        {
            this.vehicleData = VehicleData;
            Vehicle = vehicle;
            API.setVehicleEngineStatus(vehicle, false);
            EntityManager.Add(this);

        }
        private void OnPlayerExitVehicle(Client player, NetHandle vehicle)
        {
        }

        private void OnPlayerEnterVehicle(Client player, NetHandle vehicle)
        {
            API.sendChatMessageToPlayer(player, "~r~[~w~INFO~r~]~g~ Pour demarrer le vehicule taper /v moteur");
            VehicleManager vehicleInfo = EntityManager.GetVehicle(vehicle);
            AccountManager playerInfo = EntityManager.GetAccount(player.handle);
            if (vehicleInfo.vehicleData.IsBuyable)
            {
                API.sendChatMessageToPlayer(player, "~r~[~w~INFO~r~]~g~ Ce vehicule est en vente pour la somme de " + vehicleInfo.vehicleData.SalePrice+ "$ vous pouvez l'acheter avec la commande /v acheter");
            }
            else if(vehicleInfo.vehicleData.IsRentable)
            {
                if(vehicleInfo.vehicleData.RentalOwner == -1)
                {
                    API.sendChatMessageToPlayer(player, "~r~[~w~INFO~r~]~g~ Ce vehicule est en location pour la somme de " + vehicleInfo.vehicleData.RentalPrice + "$ vous pouvez le louer via la commande /v louer");
                }
                else if(vehicleInfo.vehicleData.RentalOwner == playerInfo.AccountData.Id)
                {
                    API.sendChatMessageToPlayer(player, "~r~[~w~INFO~r~]~g~ Vous êtes le locataire de ce vehicule");
                }
            }
        }

        private void OnVehicleExplode(NetHandle entity)
        {
            throw new NotImplementedException();
        }

        public static void LoadVehicles()
        {
            foreach (var vehicle in ContextFactory.Instance.Vehicles.ToList())
            {
                if (vehicle.IsRentable == true)
                {
                    vehicle.RentalOwner = -1;
                }
                VehicleManager VehicleController = new VehicleManager(vehicle, API.shared.createVehicle((VehicleHash)vehicle.Model, new Vector3(vehicle.PosX, vehicle.PosY, vehicle.PosZ), new Vector3(0.0f, 0.0f, vehicle.Rot), vehicle.Color1, vehicle.Color2));

            }
            API.shared.consoleOutput("[GM] Véhicule initialisez : " + ContextFactory.Instance.Vehicles.Count());
        }

    }
}