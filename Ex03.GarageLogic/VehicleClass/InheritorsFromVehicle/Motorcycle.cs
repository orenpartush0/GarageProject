using System;
using Ex03.GarageLogic.Classes;
using Ex03.GarageLogic.Engines;

namespace Ex03.GarageLogic.VehicleClasses
{
    public class Motorcycle : Vehicle
    {
        public LicenseType LicenseType { set; get; }
        public int EngineDisplacementInCC { set; get; }

        public Motorcycle(string i_LicenseNumber) : base(i_LicenseNumber, new FuelEngine()) { }

        public override string ToString()
        {
            return base.ToString() + string.Format(
                       "\nLicense Type: {0}\n" +
                       "Engine Displacement: {1} cc\n",
                       LicenseType,
                       EngineDisplacementInCC
                       );
        }
    }
}
