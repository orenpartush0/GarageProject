using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic.Engines
{
    public sealed class Battery
    {
        public float BatteryTimeHours { set; get; }
        public float MaxBatteryTime { set; get; }

        public void Fuel(float i_ToCharge)
        {
            float newCapacity = i_ToCharge + BatteryTimeHours;

            BatteryTimeHours = newCapacity <= MaxBatteryTime ? newCapacity : MaxBatteryTime;
        }
    }
}
