using System;
using System.Collections.Generic;
using System.Linq;
using Ex03.GarageLogic.VehicleClasses;

namespace Ex03.GarageLogic.GarageClass
{
    public class GarageManager
    {
        public Dictionary<string, VehicleInformation> VehiclesInGarage { set; get; }

        public GarageManager()
        {
            VehiclesInGarage = new Dictionary<string, VehicleInformation>();
        }

        public bool IsInGarage(string i_LicenseNumber)
        {
            return VehiclesInGarage.ContainsKey(i_LicenseNumber);
        }

        public List<string> GetAllVehicleLicenseNumberInGarage()
        {
            List<string> AllLicenseNumbers = new List<string>();

            foreach (KeyValuePair<string, VehicleInformation> vehicle in VehiclesInGarage)
            {
                AllLicenseNumbers.Add(vehicle.Key);
            }

            return AllLicenseNumbers;
        }

        public List<string> GetVehicleLicenseNumberListWithFiltering(VehicleStatus i_Filter)
        {
            List<string> AllLicenseNumbers = new List<string>();

            foreach (KeyValuePair<string, VehicleInformation> vehicle in VehiclesInGarage)
            {
                if (vehicle.Value.VehicleStatus == i_Filter)
                {
                    AllLicenseNumbers.Add(vehicle.Key);
                }
            }

            return AllLicenseNumbers;
        }


    }

}
