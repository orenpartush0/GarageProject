
using System;
using Ex03.ConsoleUi.UI;
using Ex03.GarageLogic.Classes;
using Ex03.GarageLogic.Engines;
using Ex03.GarageLogic.EnginesClass;
using Ex03.GarageLogic.VehicleClasses;


namespace Ex03.ConsoleUI.FactoryClass.InheritorsFromFactory
{
    public class CarFactory : Factory
    {
        protected override float MaxEnergy => 45;
        protected override float NumOfWheels => 5;
        protected override float WheelMaxPressure => 31;

        private const eFuelType k_FuelType = eFuelType.Octan95;
        
        protected override Engine setEngine()
        {
            return new FuelEngine(k_FuelType, MaxEnergy);
        }

        protected override void setVehicleSpecificConfiguration(Vehicle i_Vehicle)
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
