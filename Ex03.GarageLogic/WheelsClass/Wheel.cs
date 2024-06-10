using System;

namespace Ex03.GarageLogic.WheelsClass
{
    public sealed class Wheel
    {
        public string ManufacturerName { set; get; }
        public float CurrentAirPressure { set; get; }
        public float MaxAirPressure { set; get; }

        public void Inflate(float i_ToInflate)
        {
            float newPressure = i_ToInflate + CurrentAirPressure;

            if(newPressure > MaxAirPressure)
            {
                throw new ArgumentException("Too much air pressure in the wheel");
            }

            CurrentAirPressure = newPressure;
        }

        public float InflateToMax()
        {
            CurrentAirPressure = MaxAirPressure;

            return CurrentAirPressure;
        }

        public override string ToString()
        {
            return string.Format(
                "Manufacturer Name: {0}\n" +
                "Current Air Pressure: {1} PSI\n" +
                "Max Air Pressure: {2} PSI",
                ManufacturerName,
                CurrentAirPressure,
                MaxAirPressure
            );
        }
    }
}
