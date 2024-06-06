using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic.Classes;

namespace Ex03.GarageLogic.GarageClass
{
    public class VehicleInformation
    {
        public string OwnerName { get; }
        public string OwnerPhoneNumber { set; get; }
        public VehicleStatus VehicleStatus { set; get; }
        public Vehicle Vehicle { set; get; }
    }
}
