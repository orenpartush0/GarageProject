using System;
using Ex03.GarageLogic.Classes;
using Ex03.GarageLogic.Engines;

namespace Ex03.GarageLogic.VehicleClasses
{
    public class Truck : Vehicle
    {
        public float CargoVolume { set; get; }
        public bool IsCarryingHazardousMaterials { set; get; }

        public Truck(string i_LicenseNumber) : base(i_LicenseNumber, new FuelEngine()) { }

        public override string ToString()
        {
            return base.ToString() + string.Format(
                       "\nCargo Volume: {0} cubic meters\n" +
                       "Is Carrying Hazardous Materials: {1}",
                       CargoVolume,
                       IsCarryingHazardousMaterials ? "Yes" : "No");
        }
    }
}
