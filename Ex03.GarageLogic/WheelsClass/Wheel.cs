using System;

namespace Ex03.GarageLogic.WheelsClass
{
    public sealed class Wheel
    {
        private string ManufacturerName { get; }
        private float CurrentAirPressure { set; get; }
        private float MaxAirPressure { get; }

        public Wheel(string i_ManufacturerName, float i_CurrentAirPressure, float i_MaxAirPressure) { 
            ManufacturerName = i_ManufacturerName;
            CurrentAirPressure = i_CurrentAirPressure;
            MaxAirPressure = i_MaxAirPressure;
        }

        public void Inflate(float i_ToInflate)
        {
            ValueOutOfRangeException.CheckValue(i_ToInflate, 0, MaxAirPressure - CurrentAirPressure);
            CurrentAirPressure = CurrentAirPressure + i_ToInflate;
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
