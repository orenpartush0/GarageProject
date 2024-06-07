using System;
using Ex03.GarageLogic.Classes;
using Ex03.GarageLogic.EnginesClasses;

namespace Ex03.GarageLogic.GarageClass
{
    public class VehicleInformation
    {
        public string OwnerName { get; }
        public string OwnerPhoneNumber { set; get; }
        public VehicleStatus VehicleStatus { set; get; }
        public Vehicle Vehicle { set; get; }

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
