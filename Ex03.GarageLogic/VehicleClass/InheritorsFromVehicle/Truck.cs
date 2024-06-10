using System;
using Ex03.GarageLogic.Classes;
using Ex03.GarageLogic.Engines;
using Ex03.GarageLogic.EnginesClasses;

namespace Ex03.GarageLogic.VehicleClasses
{
    public class Truck : Vehicle
    {
        public float CargoVolume { set; get; }
        public bool IsCarryingHazardousMaterials { set; get; }

        public Truck(Engine i_Engine, string i_LicenseNumber) : base(i_LicenseNumber, i_Engine) { }

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
