using ParkingLot.Enums;
using ParkingLot.Models;

namespace ParkingLot.Interfaces
{
    public interface IVehicleService
    {
        Vehicle CreateVehicle(VehicleType type);
    }

}


