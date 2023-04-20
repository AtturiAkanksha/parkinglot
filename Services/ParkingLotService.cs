using ParkingLot.Enums;
using ParkingLot.Interfaces;
using ParkingLot.Models;

namespace ParkingLot.Services
{
    public class ParkingLotService : IParkingLotService
    {
        ParkingSpace parkingSpace;

        public ParkingLotService()
        {
            parkingSpace = new ParkingSpace();
            parkingSpace.Slots = new List<ParkingSlot>();
        }

        public List<ParkingSlot> InitialiseLot(int slotsInput,int slotType)
        {
            for ( int i= 0; i< slotsInput; i++ )
            {
                ParkingSlot newSlot = new ParkingSlot();
                newSlot.SlotType= (SlotType)slotType;
                newSlot.IsAvailable = true;
                parkingSpace.Slots.Add(newSlot);
            }
            return parkingSpace.Slots;
        }

        public int CountAvailableSlots(SlotType type)
        {
            int count;
            count = parkingSpace.Slots.Where(slot => slot.SlotType == type && slot.IsAvailable == true).Count();
            return count;
        }
    }
}
