using Ex03.GarageLogic.EnginesClass;


namespace Ex03.GarageLogic.Engines
{
    public sealed class FuelEngine : Engine
    {
        protected override eEngine Type => eEngine.FuelEngine;

        public FuelEngine(eFuelType i_FuelType, float i_MaxEnergyLevel)
            : base(i_MaxEnergyLevel)
        {
            FuelType = i_FuelType;
        }

        public eFuelType FuelType { set; get; }

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
