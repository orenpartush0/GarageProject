using System.Collections.Generic;
using System.Linq;
using Ex03.GarageLogic.EnginesClasses;
using Ex03.GarageLogic.WheelsClass;

namespace Ex03.GarageLogic.Classes
{
    public abstract class Vehicle
    {
        public string LicenseNumber { set; get; }
        public string ModelName { set; get; }
        public List<Wheel> Wheels { set; get; }
        public Engine Engine { set; get; }

        public Vehicle(string i_LicenseNumber, Engine i_Engine)
        {
            LicenseNumber = i_LicenseNumber;
            Engine = i_Engine;
        }

        internal Vehicle(Engine i_Engine)
        {
            Engine = i_Engine;
        }

        public override bool Equals(object i_Obj)
        {
            bool equals = false;

            Vehicle toCompareTo = i_Obj as Vehicle;
            if (!(toCompareTo is null))
            {
                equals = toCompareTo.LicenseNumber == this.LicenseNumber;
            }

            return equals;
        }

        public static bool operator ==(Vehicle i_Obj1, object i_Obj2)
        {
            return i_Obj1.Equals(i_Obj2);
        }

        public static bool operator !=(Vehicle i_Obj1, object i_Obj2)
        {
            return !(i_Obj1 == i_Obj2);
        }

        public override int GetHashCode()
        {
            return int.Parse(this.LicenseNumber);
        }

        public override string ToString()
        {
            return string.Format(
                "License Number: {0}\n" +
                "Model Name: {1}\n" +
                "Engine: {2}\n" +
                "Wheels:\n{3}",
                LicenseNumber,
                ModelName,
                Engine.ToString(),
                string.Join("\n", Wheels.Select(wheel => wheel.ToString()))
            );
        }
    }
}
