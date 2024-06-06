using System;

namespace Ex03.GarageLogic.EnginesClasses
{
    internal abstract class Engine
    {
        public float CurrentEnergyLevel { set; get; }
        public float MaxEnergyLevel { set; get; }

        public void Energize(float i_EnergySource)
        {
            float newCapacity = i_EnergySource + CurrentEnergyLevel;

            CurrentEnergyLevel = newCapacity <= MaxEnergyLevel ? newCapacity : CurrentEnergyLevel;
        }
    }
}
