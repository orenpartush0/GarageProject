using Ex03.GarageLogic.Classes;
using Ex03.GarageLogic.Engines;
using Ex03.GarageLogic.VehicleClasses;
using System;
using Ex03.ConsoleUI.FactoryClass;
using Ex03.GarageLogic.EnginesClass;

namespace Ex03.GarageLogic.FactoryClass.InheritorsFromFactory
{
    public class TruckFactory : Factory
    {
        private const float k_FuelTankCapacityInLiters = 120;
        protected override float NumOfWheels => 12;
        protected override float WheelMaxPressure => 28;

        private const eFuelType k_FuelType = eFuelType.Soler;
        
        protected override Engine setEngine()
        {
            return new FuelEngine(k_FuelType, k_FuelTankCapacityInLiters);
        }

        private float getCargoVolume()
        {
            Console.WriteLine("Please enter truck cargo volume");
            if(!float.TryParse(Console.ReadLine(), out float truckCargoVolume))
            {
                throw new FormatException("Invalid input");
            }

            Console.Clear();

            return truckCargoVolume;
        }

        private bool isCarryingHazardousMaterials()
        {
            Console.WriteLine("Does the truck contain hazardous cargo?(y/n)");
            string answer = Console.ReadLine();
            Console.Clear();
            if (answer.Length != 1 || (answer[0] != 'y' && answer[0] != 'n'))
            {
                throw new ArgumentException("invalid input");
            }

            return answer == "y";
        }

        protected override void setVehicleSpecificConfiguration(Vehicle i_Vehicle)
        {
            ((Truck)i_Vehicle).CargoVolume = getCargoVolume();
            ((Truck)i_Vehicle).IsCarryingHazardousMaterials = isCarryingHazardousMaterials();
        }
    }
}
