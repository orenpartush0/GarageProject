using Ex03.GarageLogic.Classes;
using Ex03.GarageLogic.EnginesClasses;
using Ex03.GarageLogic.VehicleClasses;

namespace Ex03.GarageLogic.VehicleCtreator
{
    public class VehicleCreator
    {
        public static Vehicle CreateVehicle(eVehicle i_VehicleType, string i_LicenseNumber, Engine i_Engine)
        {
            Vehicle vehicle = null;
            switch (i_VehicleType)
            {
                case eVehicle.Car:
                    vehicle = new Car(i_Engine, i_LicenseNumber);
                    break;
                case eVehicle.ElectricCar:
                    vehicle = new Car(i_Engine, i_LicenseNumber);
                    break;
                case eVehicle.ElectricMotorcycle:
                    vehicle = new Motorcycle(i_Engine, i_LicenseNumber);
                    break;
                case eVehicle.Motorcycle:
                    vehicle = new Motorcycle(i_Engine, i_LicenseNumber);
                    break;
                case eVehicle.Truck:
                    vehicle = new Truck(i_Engine, i_LicenseNumber);
                    break;

            }

            return vehicle;
        }
    }
}
