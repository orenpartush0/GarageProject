using System;
using Ex03.GarageLogic.Engines;

namespace Ex03.GarageLogic.EnginesClasses
{
    public abstract class Engine
    {
        public float CurrentEnergyLevelPercentage { set; get; }
        private float MaxEnergyLevel { set; get; }

        protected Engine(float i_MaxEnergyLevel)
        {
            MaxEnergyLevel = i_MaxEnergyLevel;
        }

        public Tuple<float, float> Energize(float i_EnergySource)
        {
            ValueOutOfRangeException.CheckValue(i_EnergySource,0,MaxEnergyLevel - CurrentEnergyLevelPercentage);
            float newCapacity = i_EnergySource + ((CurrentEnergyLevelPercentage * MaxEnergyLevel) / 100);
            CurrentEnergyLevelPercentage = (newCapacity / MaxEnergyLevel) * 100;
            Tuple<float, float> beforeAndAfterEnergize = Tuple.Create(newCapacity, MaxEnergyLevel);

            return beforeAndAfterEnergize;
        }

        public new abstract string GetType();

        public new virtual string ToString()
        {
            return string.Format(
                "Current Energy Level: {0}\n" +
                "Max Energy Level: {1}",
                CurrentEnergyLevelPercentage,
                MaxEnergyLevel
            );
        }

        public abstract string PowerSource();

    }
}
