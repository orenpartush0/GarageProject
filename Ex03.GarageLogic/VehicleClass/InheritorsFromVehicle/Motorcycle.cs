using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic.Classes;
using Ex03.GarageLogic.Engines;

namespace Ex03.GarageLogic.VehicleClasses
{
    public class Motorcycle : Vehicle
    {
        public LicenseType LicenseType { set; get; }
        public int EngineDisplacementInCC { set; get; }
        public FuelEngine FuelEngine { get; }

        public Motorcycle(string i_LicenseNumber) : base(i_LicenseNumber) { }

        public override string ToString()
        {
            return base.ToString() + string.Format(
                       "\nLicense Type: {0}\n" +
                       "Engine Displacement: {1} cc\n" +
                       "Fuel Engine: {2}",
                       LicenseType,
                       EngineDisplacementInCC,
                       FuelEngine);
        }
    }
}
