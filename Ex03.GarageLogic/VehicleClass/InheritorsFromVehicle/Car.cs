using System;
using Ex03.GarageLogic.Classes;
using Ex03.GarageLogic.Engines;

namespace Ex03.GarageLogic.VehicleClasses
{
    public class Car : Vehicle
    {
        public Colors Color { set; get; }
        public NumberOfDoors NumberOfDoors { get; }

        public Car(string i_LicenseNumber) : base(i_LicenseNumber, new FuelEngine()) { }

        public override string ToString()
        {
            return base.ToString() + string.Format(
                       "\nColor: {0}\n" +
                       "Number of Doors: {1}\n",
                       Color,
                       NumberOfDoors
                       );
        }


    }
}
