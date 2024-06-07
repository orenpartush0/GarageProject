using System;
using Ex03.GarageLogic.EnginesClasses;

namespace Ex03.GarageLogic.Engines
{
    public sealed class Battery : Engine
    {
        private const string k_Type = "Battery";
        private const string k_PowerSource = "Electricity";

        public override string GetType()
        {
            return k_Type;
        }

        public override string PowerSource()
        {
            return k_PowerSource;
        }
    }
}
