using Ex03.ConsoleUI.FactoryClass.InheritorsFromFactory;
using Ex03.GarageLogic.Classes;
using Ex03.GarageLogic.FactoryClass.InheritorsFromFactory;
using System;
using System.Collections.Generic;
using Ex03.GarageLogic.EnginesClasses;
using Ex03.GarageLogic.GarageClass;
using Ex03.GarageLogic.VehicleCtreator;
using Ex03.GarageLogic.WheelsClass;
using System.Linq;

namespace Ex03.GarageLogic
{
    public abstract class Factory
    {
        private const int k_PhoneNumberLength = 10;

        public static Factory createFactory(eVehicle i_VehicleType)
        {
            Factory factory = null;
            switch (i_VehicleType)
            {
                case eVehicle.Car:
                    factory = new CarFactory();
                    break;
                case eVehicle.ElectricCar:
                    factory = new ElectricCarFactory();
                    break;
                case eVehicle.Motorcycle:
                    factory = new MotorcycleFactory();
                    break;
                case eVehicle.ElectricMotorcycle:
                    factory = new ElectricMotorcycleFactory();
                    break;
                case eVehicle.Truck:
                    factory = new TruckFactory();
                    break;

            }

            return factory;
        }
        private string getPhoneNumber()
        {
            Console.WriteLine("Please enter owner phone number (10 digits)");
            string strPhoneNumber = Console.ReadLine();
            Console.Clear();

            if (!int.TryParse(strPhoneNumber, out int intPhoneNumber))
            {
                throw new FormatException("Invalid input");
            }
            else if (strPhoneNumber.Length != k_PhoneNumberLength)
            {
                throw new ArgumentException("Invalid input");
            }

            return strPhoneNumber;
        }

        private string getModel()
        {
            Console.WriteLine("Please enter the model name");
            string model = Console.ReadLine();
            Console.Clear();

            return model;
        }

        private float getCurrentEnergy(eVehicle i_VehicleType , Vehicle i_Vehicle)
        {
            bool needTobeCharged =
                i_VehicleType == eVehicle.ElectricCar || i_VehicleType == eVehicle.ElectricMotorcycle;
            Console.WriteLine($"In percentage, how much " + (needTobeCharged ? "electricity" : "fuel") + " is in the vehicle right now?");
            string currentEnergy = Console.ReadLine();
            Console.Clear();
            if (!float.TryParse(currentEnergy, out float floatCurrentEnergy))
            {
                throw new FormatException("Invalid input");
            }
            else if(floatCurrentEnergy > 100)
            {
                throw new ValueOutOfRangeException(0,100);
            }

            return floatCurrentEnergy;
        }

        public void SetVehicleData(eVehicle i_VehicleType, string i_LicenseNumber, GarageManager i_Gm)
        {
            Engine engine = setEngine();
            Vehicle vehicle = VehicleCreator.CreateVehicle(i_VehicleType, i_LicenseNumber, engine);
            vehicle.ModelName = getModel();
            vehicle.Engine.CurrentEnergyLevelPercentage = getCurrentEnergy(i_VehicleType, vehicle);
            string phoneNumber = getPhoneNumber();
            string ownerName = getOwnerName();
            setWheels(vehicle);
            setVehicleSpecificConfiguration(vehicle);
            i_Gm.VehiclesInGarage.Add(i_LicenseNumber, new CostumerInfo(ownerName, phoneNumber, vehicle));
        }

        private string getOwnerName()
        {
            Console.WriteLine("Please enter the car owner's name");
            string ownerName = Console.ReadLine();
            Console.Clear();

            return ownerName;
        }

        internal abstract void setVehicleSpecificConfiguration(Vehicle i_Vehicle);

        internal void setWheelsWithConfiguration(Vehicle i_Vehicle, float i_NumOfWheels, float i_MaxWheelsAirPressure)
        {
            i_Vehicle.Wheels = new List<Wheel>((int)i_NumOfWheels);
            foreach (int _ in Enumerable.Range(0, (int)i_NumOfWheels))
            {
                i_Vehicle.Wheels.Add(new Wheel());
            }
            Console.WriteLine("What is the name of the manufacturer that produced the tires?");
            string manufacturerName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("How much air pressure would you like to add to the tires?");
            if (!float.TryParse(Console.ReadLine(), out float airPressure))
            {
                throw new FormatException("Invalid input");
            }

            Console.Clear();
            foreach (Wheel wheel in i_Vehicle.Wheels)
            {
                wheel.MaxAirPressure = i_MaxWheelsAirPressure;
                wheel.Inflate(airPressure);
                wheel.ManufacturerName = manufacturerName;
            }
        }

        internal abstract void setWheels(Vehicle i_Vehicle);
        internal abstract Engine setEngine();
    }
}
