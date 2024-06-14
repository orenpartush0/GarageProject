
using Ex03.GarageLogic;
using Ex03.GarageLogic.Classes;
using Ex03.GarageLogic.Engines;
using Ex03.GarageLogic.EnginesClasses;
using Ex03.GarageLogic.FactoryClass.InheritorsFromFactory;
using Ex03.GarageLogic.WheelsClass;
using System.Collections.Generic;

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
