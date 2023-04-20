using ParkingLot.Enums;
using ParkingLot.Models;

namespace ParkingLot.Interfaces
{
    public interface IParkingLotService
    {
        int CountAvailableSlots(SlotType type);
        List<ParkingSlot> InitialiseLot(int slots,int type);

    }
}
