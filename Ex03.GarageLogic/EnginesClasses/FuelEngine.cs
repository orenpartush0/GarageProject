using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic.Engines
{
    public sealed class FuelEngine
    {
        public FuelType FuelType { set; get; }
        public float CurrentFuelQuantityLiters { set; get; }
        public float MaxFuelCapacityLiters { set; get; }

        public void Fuel(float i_toFuel)
        {
            float newCapacity = i_toFuel + CurrentFuelQuantityLiters;

            CurrentFuelQuantityLiters = newCapacity <= MaxFuelCapacityLiters ? newCapacity : CurrentFuelQuantityLiters;
        }
    }
}
