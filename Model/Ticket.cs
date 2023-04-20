using ParkingLot.Enums;

namespace ParkingLot.Models
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public DateTime InTime { get; set; }
        public DateTime OutTime { get; set; }
        public string? VehicleNumber { get; set; }
        public VehicleType VehicleType { get; set; }
        public int SlotNumber { get; set; }
    }
}


