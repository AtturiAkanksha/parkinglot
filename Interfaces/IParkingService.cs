using ParkingLot.Enums;

namespace ParkingLot.Interfaces
{
    public interface IParkingService
    {
        int GetCount(SlotType type);
    }
}
