
using Ex03.GarageLogic.Classes;
using Ex03.GarageLogic.VehicleClasses;

namespace Ex03.GarageLogic.FactoryClass.InheritorsFromFactory
{
    public sealed class CarFactory : Factory
    {
        public override Vehicle CreateVehicle()
        {
            return new Car();
        }
    }
}
