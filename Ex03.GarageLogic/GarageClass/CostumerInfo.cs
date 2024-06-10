using System;
using Ex03.GarageLogic.Classes;
using Ex03.GarageLogic.EnginesClasses;

namespace Ex03.GarageLogic.GarageClass
{
    public class CostumerInfo
    {
        public string OwnerName { set; get; }
        public string OwnerPhoneNumber { set; get; }
        public eVehicleStatus VehicleStatus { set; get; }
        public Vehicle Vehicle { set; get; }

        public CostumerInfo(string i_OwnerName, string i_OwnerPhone, Vehicle i_Vehicle)
        {
            OwnerName = i_OwnerName;
            OwnerPhoneNumber = i_OwnerPhone;
            Vehicle = i_Vehicle;
            VehicleStatus = eVehicleStatus.Repair;
        }

        public override string ToString()
        {
            return string.Format(
                "Owner Name: {0}\n" +
                "Owner Phone Number: {1}\n" +
                "Vehicle Status: {2}%\n" +
                "Vehicle: {3}\n",
                OwnerName,
                OwnerPhoneNumber,
                VehicleStatus.ToString(),
                Vehicle.ToString()
            );
        }
    }
}
