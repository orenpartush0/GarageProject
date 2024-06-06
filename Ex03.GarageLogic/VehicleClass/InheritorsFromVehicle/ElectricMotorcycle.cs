using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic.Classes;
using Ex03.GarageLogic.Engines;

namespace Ex03.GarageLogic.VehicleClasses
{
    public class ElectricMotorcycle : Vehicle
    {
        public LicenseType LicenseType { set; get; }
        public int EngineDisplacementInCC { set; get; }
        public Battery Battery { set; get; }

        public ElectricMotorcycle(string i_LicenseNumber) : base(i_LicenseNumber) { }

        public override string ToString()
        {
            return base.ToString() + string.Format(
                       "\nLicense Type: {0}\n" +
                       "Engine Displacement: {1} cc\n" +
                       "Battery: {2}",
                       LicenseType,
                       EngineDisplacementInCC,
                       Battery);
        }
    }
}
