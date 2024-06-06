﻿using System;
using System.Collections.Generic;
using System.Linq;
using Ex03.GarageLogic.WheelsClass;

namespace Ex03.GarageLogic.Classes
{
    public abstract class Vehicle
    {
        private readonly string r_LicenseNumber;
        public string ModelName { get; }
        public float EnergySourceRemainingPercentage { set; get; }
        public List<Wheel> Wheels { set; get; }

        internal Vehicle(string i_LicenseNumber)
        {
            r_LicenseNumber = i_LicenseNumber;
        }

        public override bool Equals(object i_Obj)
        {
            bool equals = false;

            Vehicle toCompareTo = i_Obj as Vehicle;
            if (!(toCompareTo is  null))
            {
                equals = toCompareTo.r_LicenseNumber == this.r_LicenseNumber;
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
            return int.Parse(this.r_LicenseNumber);
        }

        public override string ToString()
        {
            return string.Format(
                "License Number: {0}\n" +
                "Model Name: {1}\n" +
                "Energy Source Remaining Percentage: {2}%\n" +
                "Owner Name: {3}\n" +
                "Owner Phone Number: {4}\n" +
                "Vehicle Status: {5}\n" +
                "Wheels: {6}",
                r_LicenseNumber,
                ModelName,
                EnergySourceRemainingPercentage,
                string.Join(", ", Wheels.Select(wheel => wheel.ToString()))
            );
        }
    }
}
