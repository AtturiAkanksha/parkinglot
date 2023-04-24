using ParkingLot.Enums;

namespace ParkingLot.Models
{
    public class ParkingSlot {
        public int SlotNumber { get; set; }
        public SlotType SlotType { get; set; }

        private bool isAvailable = true;
        public bool IsAvailable
        {
                get { return isAvailable; }
                set { isAvailable = value; }
        }
        public Vehicle? Vehicle { get ; set; }
    }

}
