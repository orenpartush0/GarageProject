using Ex03.GarageLogic.EnginesClass;

namespace Ex03.GarageLogic.Engines
{
    public sealed class Battery : Engine
    {
        protected override eEngine Type => eEngine.Battery;

        private const string k_PowerSource = "Electricity";

        public Battery(float i_MaxEnergyLevel)
            : base(i_MaxEnergyLevel) { }

        public override string PowerSource()
        {
            return k_PowerSource;
        }
    }
}
