using System;
using System.Collections.Generic;
using System.Linq;
using Ex03.GarageLogic.VehicleClasses;
using Ex03.GarageLogic.WheelsClass;

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

        public Tuple<VehicleStatus, VehicleStatus> ChangeVehicleStatus(string i_LicenseNumber, VehicleStatus i_NewStatus)
        {
            if (!this.IsInGarage(i_LicenseNumber))
            {
                throw new ArgumentException("This vehicle has not been serviced in the garage.");
            }

            VehicleStatus before = VehiclesInGarage[i_LicenseNumber].VehicleStatus;
            Tuple<VehicleStatus, VehicleStatus> BeforeAndAfterStatus = new Tuple<VehicleStatus, VehicleStatus>(before, i_NewStatus);
            VehiclesInGarage[i_LicenseNumber].VehicleStatus = i_NewStatus;

            return BeforeAndAfterStatus;
        }

        public void FillTires(string i_LicenseNumber)
        {
            if (!this.IsInGarage(i_LicenseNumber))
            {
                throw new ArgumentException("This vehicle has not been serviced in the garage.");
            }
            foreach (Wheel wheel in VehiclesInGarage[i_LicenseNumber].Vehicle.Wheels)
            {
                wheel.InflateToMax();
            }
        }

        public void RefuelVehicle(string i_LicenseNumber, float i_FuelToFill, FuelType i_FuelType)
        {
            if (!this.IsInGarage(i_LicenseNumber))
            {
                throw new ArgumentException("This vehicle has not been serviced in the garage.");
            }
            else if (VehiclesInGarage[i_LicenseNumber].Vehicle.Engine.GetType() == "Battery" && i_FuelType != FuelType.Electricity)
            {
                throw new ArgumentException("This vehicle is actually an electric vehicle.");
            }
            else if (VehiclesInGarage[i_LicenseNumber].Vehicle.Engine.PowerSource() != i_FuelType.ToString())
            {
                throw new ArgumentException("Wrong Fuel");
            }
            else
            {
                VehiclesInGarage[i_LicenseNumber].Vehicle.Engine.Energize(i_FuelToFill);
            }
        }

        public string GetDataOnVehicleByLicenseNumber(string i_LicenseNumber)
        {
            return VehiclesInGarage[i_LicenseNumber].ToString();
        }
    }
}
