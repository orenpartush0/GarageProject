using System;
using Ex03.GarageLogic.EnginesClasses;


namespace Ex03.GarageLogic.Engines
{
    public sealed class FuelEngine : Engine
    {
        private const EngineEnum k_Type = EngineEnum.FuelEngine;

        public FuelType FuelType { set; get; }

        public override string GetType()
        {
            return k_Type.ToString();
        }

        public override string PowerSource()
        {
            return FuelType.ToString();
        }

        public override string ToString()
        {
            return string.Format(
                "{1}\n" +
                "Fuel type: {2}\n",
                base.ToString(),
                FuelType.ToString()
                );
        }
    }
}
