using Ex03.GarageLogic.Classes;

namespace Ex03.GarageLogic.GarageClass
{
    public class CostumerInfo
    {
        private Owner Owner { set; get; }
        public eVehicleStatus VehicleStatus { set; get; }
        public Vehicle Vehicle { set; get; }

        public CostumerInfo(string i_OwnerName, string i_OwnerPhone, Vehicle i_Vehicle)
        {
            Owner = new Owner(i_OwnerName, i_OwnerPhone);
            Vehicle = i_Vehicle;
            VehicleStatus = eVehicleStatus.Repair;
        }

        public override string ToString()
        {
            return string.Format(
                "{0}\n" +
                "Vehicle Status: {1}%\n" +
                "Vehicle: {2}\n",
                Owner.ToString(),
                VehicleStatus.ToString(),
                Vehicle.ToString()
            );
        }
    }
}
