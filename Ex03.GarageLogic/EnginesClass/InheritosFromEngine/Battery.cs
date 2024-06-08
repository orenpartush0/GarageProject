using System;
using Ex03.GarageLogic.EnginesClasses;

namespace Ex03.GarageLogic.Engines
{
    public sealed class Battery : Engine
    {
        private const EngineEnum k_Type = EngineEnum.Battery;
        private const string k_PowerSource = "Electricity";

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
