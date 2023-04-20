using ParkingLot.Enums;
using ParkingLot.Interfaces;
using ParkingLot.Models;

namespace ParkingLot.Services
{
    public class ParkingSlotService: IParkingSlotService
    {
      

        public ParkingSlot? AllotSlot(VehicleType type, List<ParkingSlot> slots)
        {
            ParkingSlot? slot = slots.FirstOrDefault(slot => slot.SlotType.ToString() == type.ToString() && slot.IsAvailable == true);
            if (slot != null)
            {
                slot.IsAvailable = false;
                int index = slots.IndexOf(slot);
                slot.SlotNumber = index + 1;
                return slot;
            }
            return null;
        }
    }
}
