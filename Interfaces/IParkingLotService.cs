using ParkingLot.Enums;
using ParkingLot.Models;

namespace ParkingLot.Interfaces
{
    public interface IParkingLotService
    {
        int CountAvailableSlots(SlotType type);
        void InitialiseLot(int slots,int type);
        ParkingSlot VehicleIsAvailable(string vehicleNumber);
        ParkingSlot? AllotSlot(VehicleType type);
    }
}
