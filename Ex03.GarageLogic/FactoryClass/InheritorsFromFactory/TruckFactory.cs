using Ex03.GarageLogic.Classes;
using Ex03.GarageLogic.VehicleClasses;

namespace Ex03.GarageLogic.FactoryClass.InheritorsFromFactory
{
    public class TruckFactory : Factory
    {
        public override Vehicle CreateVehicle()
        {
            return new Truck();
        }
    }
}
