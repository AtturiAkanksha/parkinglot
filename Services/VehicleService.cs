using ParkingLot.Enums;
using ParkingLot.Models;

namespace ParkingLot.Services
{
    public class VehicleService
    {

        private Vehicle CreateVehicle(VehicleType type)
        {
            switch (type)
            {
                case VehicleType.TwoWheeler:
                    return new TwoWheeler();
                case VehicleType.FourWheeler:
                    return new FourWheeler();
                case VehicleType.HeavyWheeler:
                    return new HeavyWheeler();
                default:
                    return new Vehicle();
            }
        }

        public Vehicle ParkVehicle(ParkingSlot slot, VehicleType type, string vehicleNumber)
        {
            Vehicle vehicle = CreateVehicle(type);
            vehicle.VehicleNumber = vehicleNumber;
            vehicle.VehicleType = type;
            slot.Vehicle = vehicle;
            return vehicle;
        }

        public bool UnparkVehicle(string vehicleNumberCheck, List<ParkingSlot> slots)
        {
            ParkingSlot? slot = slots.FirstOrDefault(slot => slot.Vehicle != null && slot.Vehicle.VehicleNumber == vehicleNumberCheck);
            if (slot != null)
            {
                slot.Vehicle = null;
                slot.IsAvailable = true;
                return true;
            }
            return false;
        }

       
    }
}
