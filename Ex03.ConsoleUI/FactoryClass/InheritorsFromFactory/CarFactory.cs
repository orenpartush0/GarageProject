
using System;
using System.Collections.Generic;
using System.Linq;
using Ex03.ConsoleUI;
using Ex03.GarageLogic.Classes;
using Ex03.GarageLogic.Engines;
using Ex03.GarageLogic.EnginesClasses;
using Ex03.GarageLogic.VehicleClasses;
using Ex03.GarageLogic.WheelsClass;

namespace Ex03.GarageLogic.FactoryClass.InheritorsFromFactory
{
    public class CarFactory : Factory
    {
        private const float k_FuelTankCapacityInLiters = 45;
        private const float k_NumOfWheels = 5;
        private const float k_MaxWheelsAirPressure = 31;

        private const eFuelType k_FuelType = eFuelType.Octan95;
        internal override Engine setEngine()
        {
            return new FuelEngine(k_FuelType, k_FuelTankCapacityInLiters);
        }

        internal override void setWheels(ref Vehicle i_Vehicle)
        {
            setWheelsWithConfiguration(ref i_Vehicle, k_NumOfWheels, k_MaxWheelsAirPressure);
        }

        internal override void setVehicleSpecificConfiguration(ref Vehicle i_Vehicle)
        {
            ((Car)i_Vehicle).Color = getCarColor();
            ((Car)i_Vehicle).NumberOfDoors = getCarNumOfDoors();
        }

        private eColors getCarColor()
        {
            Console.WriteLine("Please enter your car color");
            MenuCollection.PrintMenu<eColors>();
            MenuCollection.CheckUserInputByMenu(Console.ReadLine(), out int userChoice, MenuCollection.k_ColorsMenuMaxOption);
            Console.Clear();

            return (eColors)userChoice;
        }

        private eNumberOfDoors getCarNumOfDoors()
        {
            Console.WriteLine("How many doors does your car have?");
            MenuCollection.PrintMenu<eNumberOfDoors>();
            MenuCollection.CheckUserInputByMenu(Console.ReadLine(), out int userChoice, MenuCollection.k_DoorsMenuMaxOption);
            Console.Clear();

            return (eNumberOfDoors)userChoice;
        }


    }
}
