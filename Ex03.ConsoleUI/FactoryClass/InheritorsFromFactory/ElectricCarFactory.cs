using Ex03.GarageLogic.Engines;
using Ex03.GarageLogic.EnginesClass;


namespace Ex03.ConsoleUI.FactoryClass.InheritorsFromFactory
{
    internal sealed class ElectricCarFactory: CarFactory
    {
        protected override float MaxEnergy => 3.5f;

        protected override Engine setEngine()
        {
            return new Battery(MaxEnergy);
        }

    }
}
