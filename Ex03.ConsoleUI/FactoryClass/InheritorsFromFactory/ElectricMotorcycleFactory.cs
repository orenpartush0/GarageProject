using Ex03.GarageLogic.Engines;
using Ex03.GarageLogic.EnginesClass;


namespace Ex03.ConsoleUI.FactoryClass.InheritorsFromFactory
{
    internal sealed class ElectricMotorcycleFactory : MotorcycleFactory
    {
        private const float k_MaxBatteryTimeConsumption = 2.5f;

        protected override Engine setEngine()
        {
            return new Battery(k_MaxBatteryTimeConsumption);
        }

    }
}
