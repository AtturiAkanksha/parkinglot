using ParkingLot.Enums;

namespace ParkingLot.Models
{
    public class ParkingSlot { 
        public int SlotNumber { get; set; }
        public SlotType SlotType { get; set; }
        public Boolean IsAvailable = true;
        public Vehicle? Vehicle;
    }

}
