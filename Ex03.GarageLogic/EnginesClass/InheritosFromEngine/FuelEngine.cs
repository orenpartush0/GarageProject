using System;
using Ex03.GarageLogic.EnginesClasses;


namespace Ex03.GarageLogic.Engines
{
    public sealed class FuelEngine : Engine
    {
        public FuelEngine(eFuelType i_FuelType, float i_MaxEnergyLevel)
            : base(i_MaxEnergyLevel)
        {
            FuelType = i_FuelType;
        }

        private const eEngine k_Type = eEngine.FuelEngine;

        public eFuelType FuelType { set; get; }

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
                "{0}\n" +
                "Fuel type: {1}\n",
                base.ToString(),
                FuelType.ToString()
                );
        }
    }
}
