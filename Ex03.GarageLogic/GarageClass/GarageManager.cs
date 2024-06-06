using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic.Classes;
using Ex03.GarageLogic.VehicleClasses;

namespace Ex03.GarageLogic.GarageClass
{
    public class GarageManager
    {
        public List<VehicleInformation> VehiclesInGarage { set; get; }
        
        public GarageManager()
        {
            VehiclesInGarage = new List<VehicleInformation>();
        }

        public bool IsInGarage(string i_LicenseNumber)
        {
            VehicleInformation foundVehicle = VehiclesInGarage.FirstOrDefault(i_VehicleData => i_VehicleData.Vehicle.Equals(new Car(i_LicenseNumber)));

            return foundVehicle != null;
        }

        
    }

}
