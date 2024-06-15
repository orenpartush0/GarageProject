using Ex03.GarageLogic.Classes;
using Ex03.GarageLogic.EnginesClass;

namespace Ex03.GarageLogic.VehicleClasses
{
    public class Car : Vehicle
    {
        public eColors Color { set; get; }
        public eNumberOfDoors NumberOfDoors { set; get; }

        public Car(Engine i_Engine, string i_LicenseNumber) : base(i_LicenseNumber, i_Engine) { }

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
