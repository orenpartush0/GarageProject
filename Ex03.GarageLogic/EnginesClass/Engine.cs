using System;
using Ex03.GarageLogic.Engines;

namespace Ex03.GarageLogic.EnginesClasses
{
    public abstract class Engine
    {
        public float CurrentEnergyLevel { set; get; }
        public float MaxEnergyLevel { set; get; }

        public void Energize(float i_EnergySource)
        {
            float newCapacity = i_EnergySource + CurrentEnergyLevel;

            if (newCapacity > MaxEnergyLevel)
            {
                throw new ArgumentException("Too much " + this.GetType() == EngineEnum.Battery.ToString() ? "charge" : "fuel");
            }

            CurrentEnergyLevel = newCapacity;
        }

        public new abstract string GetType();

        public new virtual string ToString()
        {
            return string.Format(
                "Current Energy Level: {0}\n" +
                "Max Energy Level: {1}",
                CurrentEnergyLevel,
                MaxEnergyLevel
            );
        }

        public abstract string PowerSource();

    }
}
