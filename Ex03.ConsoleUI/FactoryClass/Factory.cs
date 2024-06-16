using Ex03.ConsoleUI.FactoryClass.InheritorsFromFactory;
using Ex03.GarageLogic.Classes;
using Ex03.GarageLogic.FactoryClass.InheritorsFromFactory;
using System;
using System.Collections.Generic;
using Ex03.GarageLogic.GarageClass;
using Ex03.GarageLogic.VehicleCtreator;
using Ex03.GarageLogic.WheelsClass;
using System.Linq;
using Ex03.GarageLogic;
using Ex03.GarageLogic.EnginesClass;

namespace Ex03.ConsoleUI.FactoryClass
{
    public abstract class Factory
    {
        private const int k_PhoneNumberLength = 10;

        protected abstract float MaxEnergy { get; }

        protected abstract float WheelMaxPressure { get; }

        protected abstract float NumOfWheels { get; }

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
            else if (strPhoneNumber.Length != k_PhoneNumberLength || intPhoneNumber < 0)
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

        private float getCurrentEnergy(eVehicle i_VehicleType, Vehicle i_Vehicle)
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

            ValueOutOfRangeException.CheckValue(floatCurrentEnergy, 0, 100);

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
            i_Gm.AddVehicleToGarage(new CostumerInfo(ownerName, phoneNumber, vehicle) , i_LicenseNumber);
        }

        private string getOwnerName()
        {
            Console.WriteLine("Please enter the car owner's name");
            string ownerName = Console.ReadLine();
            Console.Clear();

            return ownerName;
        }

        protected abstract void setVehicleSpecificConfiguration(Vehicle i_Vehicle);

        private float[] getWheelsPressure(float i_WheelsNumber)
        {
            Console.WriteLine("Please enter the wheels pressure, separated by a comma or one pressure for all wheels: ");

            return wheelsPressureToArray((int)i_WheelsNumber);
        }

        private string[] getManufacturer(float i_WheelsNumber)
        {
            Console.WriteLine("Please enter the wheels manufacturer, separated by a comma or one manufacturer for all wheels: ");

            return wheelsDataToArray((int)i_WheelsNumber);
        }

        private string[] wheelsDataToArray(int i_ArrayLength)
        {
            string input = Console.ReadLine();
            string[] splitInput = input.Split(',');

            if (splitInput.Length != i_ArrayLength && splitInput.Length != 1)
            {
                throw new FormatException($"Input must contain state for {i_ArrayLength} wheels.");
            }

            return splitInput.Length == 1 ? Enumerable.Repeat(splitInput[0], i_ArrayLength).ToArray() : splitInput;
        }

        private float[] wheelsPressureToArray(int i_ArrayLength)
        {
            string[] pressures = wheelsDataToArray(i_ArrayLength);
            if (!pressures.All(i_Str => float.TryParse(i_Str, out _)))
            {
                throw new FormatException("Input must contain only numeric digits.");
            }

            return pressures.Select(float.Parse).ToArray();
        }

        private void setWheels(Vehicle i_Vehicle)
        {
            i_Vehicle.Wheels = new List<Wheel>((int)NumOfWheels);
            string[] manufacturers = getManufacturer(NumOfWheels);
            float[] airPressures = getWheelsPressure(NumOfWheels);
            foreach (int i in Enumerable.Range(0, (int)NumOfWheels))
            {
                i_Vehicle.Wheels.Add(new Wheel(manufacturers[i], airPressures[i], WheelMaxPressure));
            }
        }

        protected abstract Engine setEngine();
    }
}
