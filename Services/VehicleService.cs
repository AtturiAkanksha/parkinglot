using ParkingLot.Enums;
using ParkingLot.Interfaces;
using ParkingLot.Models;

namespace ParkingLot.Services
{
    public class VehicleService : IVehicleService
    {
        public Vehicle CreateVehicle(VehicleType type)
        {
            switch (type)
            {
                case VehicleType.TwoWheeler:
                    return new TwoWheeler();
                case VehicleType.FourWheeler:
                    return new FourWheeler();
                case VehicleType.HeavyWheeler:
                    return new HeavyWheeler();
                default:
                    return new Vehicle();
            }
        }
    }
}