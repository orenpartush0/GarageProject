using System;


namespace Ex03.GarageLogic.EnginesClass
{
    public abstract class Engine
    {
        protected abstract eEngine Type { get; }

        public float CurrentEnergyLevelPercentage { set; get; }
        private float MaxEnergyLevel { get; }

        protected Engine(float i_MaxEnergyLevel)
        {
            MaxEnergyLevel = i_MaxEnergyLevel;
        }

        public Tuple<float, float> Energize(float i_EnergySource)
        {
            float currentEnergyLevelLiters = (CurrentEnergyLevelPercentage * MaxEnergyLevel) / 100;
            ValueOutOfRangeException.CheckValue(i_EnergySource, 0, MaxEnergyLevel - currentEnergyLevelLiters);
            CurrentEnergyLevelPercentage = ((i_EnergySource + currentEnergyLevelLiters) / MaxEnergyLevel) * 100;
            currentEnergyLevelLiters = (CurrentEnergyLevelPercentage * MaxEnergyLevel) / 100;
            Tuple<float, float> beforeAndAfterEnergize = Tuple.Create(currentEnergyLevelLiters, MaxEnergyLevel);

            return beforeAndAfterEnergize;
        }

        public new string GetType()
        {
            return Type.ToString();
        }

        public new virtual string ToString()
        {
            return string.Format(
                "Type : {0}\n" +
                "Current Energy Level: {1}\n" +
                "Max Energy Level: {2}",
                Type.ToString(),
                CurrentEnergyLevelPercentage,
                MaxEnergyLevel
            );
        }

        public abstract string PowerSource();

    }
}
