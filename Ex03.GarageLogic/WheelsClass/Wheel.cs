using System;

namespace Ex03.GarageLogic.WheelsClass
{
    public sealed class Wheel
    {
        private string ManufacturerName { set; get; }
        private float CurrentAirPressure { set; get; }
        private float MaxAirPressure { set; get; }

        public void Inflate(float i_ToInflate)
        {
            float newPressure = i_ToInflate + CurrentAirPressure;

            CurrentAirPressure = newPressure <= MaxAirPressure ? newPressure : CurrentAirPressure;
        }

        public void InflateToMax()
        {
            CurrentAirPressure = MaxAirPressure;
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
