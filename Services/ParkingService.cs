using ParkingLot.Enums;
using ParkingLot.Interfaces;
using ParkingLot.Models;

namespace ParkingLot.Services
{
    public class ParkingService : IParkingService
    {
        ParkingSpace parkingSpace = new ParkingSpace();

        public ParkingService(List<ParkingSlot> slots)
        {
            parkingSpace.Slots = slots;
        }

        public int GetCount(SlotType type)
        {
            int count = 0;
            count = parkingSpace.Slots.Where(slot => slot.SlotType == type && slot.IsAvailable == true).Count();
            return count;
        }
    }
}
