using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic.Classes;

namespace Ex03.GarageLogic
{
    internal abstract class Factory
    {
        public abstract Vehicle CreateVehicle();
    }
}
