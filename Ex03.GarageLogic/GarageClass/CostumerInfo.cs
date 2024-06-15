using System;
using Ex03.GarageLogic.Classes;
using Ex03.GarageLogic.EnginesClasses;
using Garage;

namespace Ex03.GarageLogic.GarageClass
{
    public class CostumerInfo
    {
        public Owner Owner { get; set; }
        public eVehicleStatus VehicleStatus { set; get; }
        public Vehicle Vehicle { set; get; }

        public CostumerInfo(string i_OwnerName, string i_OwnerPhone, Vehicle i_Vehicle)
        {
            Owner = new Owner(i_OwnerName, i_OwnerPhone);
            Vehicle = i_Vehicle;
            VehicleStatus = eVehicleStatus.Repair;
        }

        public override string ToString()
        {
            return string.Format(
                "{0}\n" +
                "Vehicle Status: {1}%\n" +
                "Vehicle: {2}\n",
                Owner,
                VehicleStatus.ToString(),
                Vehicle.ToString()
            );
        }
    }
}
