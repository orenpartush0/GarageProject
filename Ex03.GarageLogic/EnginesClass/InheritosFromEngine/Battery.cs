using System;
using Ex03.GarageLogic.EnginesClasses;

namespace Ex03.GarageLogic.Engines
{
    public sealed class Battery : Engine
    {
        private const eEngine k_Type = eEngine.Battery;
        private const string k_PowerSource = "Electricity";

        public Battery(float i_MaxEnergyLevel)
            : base(i_MaxEnergyLevel) { }

        public override string GetType()
        {
            return k_Type.ToString();
        }

        public override string PowerSource()
        {
            return k_PowerSource;
        }
    }
}
