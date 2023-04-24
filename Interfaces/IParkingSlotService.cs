using ParkingLot.Enums;
using ParkingLot.Models;

namespace ParkingLot.Interfaces
{
    public interface IParkingSlotService
    {
        Vehicle ParkVehicle(ParkingSlot slot, VehicleType type, string vehicleNumber);
        public void Unpark(ParkingSlot slot);
    }
}
