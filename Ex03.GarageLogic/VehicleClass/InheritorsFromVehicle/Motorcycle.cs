using Ex03.GarageLogic.Classes;
using Ex03.GarageLogic.EnginesClass;


namespace Ex03.GarageLogic.VehicleClasses
{
    public class Motorcycle : Vehicle
    {
        public eLicenseType LicenseType { set; get; }
        public int EngineDisplacementInCC { set; get; }

        public Motorcycle(Engine i_Engine, string i_LicenseNumber) : base(i_LicenseNumber, i_Engine) { }

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
