using ParkingLot.Enums;

namespace ParkingLot.Models
{
    public class Vehicle
    {
        public VehicleType VehicleType { get; set; }
        public string? VehicleNumber { get; set; }
    }
    public class TwoWheeler : Vehicle
    {
    }
    public class FourWheeler : Vehicle
    {
    }
    public class HeavyWheeler : Vehicle
    {
    }
}
