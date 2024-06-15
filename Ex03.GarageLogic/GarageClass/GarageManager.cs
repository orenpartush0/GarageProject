using System;
using System.Collections.Generic;
using System.Linq;
using Ex03.GarageLogic.VehicleClasses;
using Ex03.GarageLogic.WheelsClass;

namespace Ex03.GarageLogic.GarageClass
{
    public class GarageManager
    {
        public Dictionary<string, CostumerInfo> VehiclesInGarage { set; get; }

        public GarageManager()
        {
            VehiclesInGarage = new Dictionary<string, CostumerInfo>();
        }

        public bool IsInGarage(string i_LicenseNumber)
        {
            return VehiclesInGarage.ContainsKey(i_LicenseNumber);
        }

        public List<string> GetVehicleLicenseNumberListWithFiltering(eVehicleStatus? i_Filter = null)
        {
            return VehiclesInGarage
                .Where(vehicle => i_Filter == null || vehicle.Value.VehicleStatus == i_Filter)
                .Select(vehicle => vehicle.Key)
                .ToList();
        }

        public Tuple<eVehicleStatus, eVehicleStatus> ChangeVehicleStatus(string i_LicenseNumber, eVehicleStatus i_NewStatus)
        {
            if (!this.IsInGarage(i_LicenseNumber))
            {
                throw new ArgumentException("This vehicle has not been serviced in the garage.");
            }

            eVehicleStatus before = VehiclesInGarage[i_LicenseNumber].VehicleStatus;
            Tuple<eVehicleStatus, eVehicleStatus> BeforeAndAfterStatus = new Tuple<eVehicleStatus, eVehicleStatus>(before, i_NewStatus);
            VehiclesInGarage[i_LicenseNumber].VehicleStatus = i_NewStatus;

            return BeforeAndAfterStatus;
        }

        public float? FillTires(string i_LicenseNumber)
        {
            float? newAirPression = null;

            if (!this.IsInGarage(i_LicenseNumber))
            {
                throw new ArgumentException("This vehicle has not been serviced in the garage.");
            }
            foreach (Wheel wheel in VehiclesInGarage[i_LicenseNumber].Vehicle.Wheels)
            {
              newAirPression = wheel.InflateToMax();
            }

            return newAirPression;
        }

        public void CheckIfVehicleIsServiced(string i_LicenseNumber)
        {
            if (!this.IsInGarage(i_LicenseNumber))
            {
                throw new ArgumentException("This vehicle has not been serviced in the garage.");
            }
        }

        public Tuple<float, float> RefuelVehicle(string i_LicenseNumber, float i_FuelToFill, eFuelType? i_FuelType)
        {
            if (VehiclesInGarage[i_LicenseNumber].Vehicle.Engine.GetType() == "Battery" && i_FuelType != null )
            {
                throw new ArgumentException("This vehicle is actually an electric vehicle.");
            }
            else if (VehiclesInGarage[i_LicenseNumber].Vehicle.Engine.GetType() != "Battery" && i_FuelType == null)
            {
                throw new ArgumentException("This vehicle is not an electric vehicle.");
            }
            else if (i_FuelType != null && VehiclesInGarage[i_LicenseNumber].Vehicle.Engine.PowerSource() != i_FuelType.ToString())
            {
                throw new ArgumentException("Wrong Fuel");
            }
            else
            {
                return VehiclesInGarage[i_LicenseNumber].Vehicle.Engine.Energize(i_FuelToFill);
            }
        }

        public string GetDataOnVehicleByLicenseNumber(string i_LicenseNumber)
        {
            return VehiclesInGarage[i_LicenseNumber].ToString();
        }
    }
}
