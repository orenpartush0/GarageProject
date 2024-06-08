﻿


using Ex03.GarageLogic.Classes;
using Ex03.GarageLogic.VehicleClasses;

namespace Ex03.GarageLogic.FactoryClass.InheritorsFromFactory
{
    internal class ElectricCarFactory : Factory
    {
        public override Vehicle CreateVehicle()
        {
            return new ElectricCar();
        }
    }
}
