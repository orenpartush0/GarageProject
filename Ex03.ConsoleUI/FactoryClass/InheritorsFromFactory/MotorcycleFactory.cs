
using Ex03.ConsoleUI;
using Ex03.GarageLogic.Classes;
using Ex03.GarageLogic.Engines;
using Ex03.GarageLogic.EnginesClasses;
using Ex03.GarageLogic.VehicleClasses;
using Ex03.GarageLogic.WheelsClass;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex03.GarageLogic.FactoryClass.InheritorsFromFactory
{
    public class MotorcycleFactory : Factory
    {
        private const float k_FuelTankCapacityInLiters = 5.5f;
        private const float k_NumOfWheels = 2;
        private const float k_MaxWheelsAirPressure = 33;

        private const eFuelType k_FuelType = eFuelType.Octan98;
        internal override Engine setEngine()
        {
            return new FuelEngine(k_FuelType, k_FuelTankCapacityInLiters);
        }

        internal override void setWheels(Vehicle i_Vehicle)
        {
            setWheelsWithConfiguration(i_Vehicle, k_NumOfWheels, k_MaxWheelsAirPressure);
        }

        internal override void setVehicleSpecificConfiguration(Vehicle i_Vehicle)
        {
            ((Motorcycle)i_Vehicle).LicenseType = getMotorcycleLicense();
            ((Motorcycle)i_Vehicle).EngineDisplacementInCC = getDisplacementInCc();
        }

        private int getDisplacementInCc()
        {
            Console.WriteLine("Please enter your motorcycle displacement in CC");
            if(!int.TryParse(Console.ReadLine(), out int displacementInCc))
            {
                throw new FormatException("invalid input");
            };

            Console.Clear();

            return displacementInCc;
        }

        private eLicenseType getMotorcycleLicense()
        {
            Console.WriteLine("Please enter your motorcycle license");
            MenuCollection.PrintMenu<eLicenseType>();
            MenuCollection.CheckUserInputByMenu(Console.ReadLine(), out int userChoice, MenuCollection.k_LicenseTypeMenuMaxOption);
            Console.Clear();

            return (eLicenseType)userChoice;
        }
    }
}
