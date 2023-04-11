using ParkingLot.Enums;
using ParkingLot.Models;

namespace ParkingLot.Interfaces
{
    public interface IVehicleService
    {
        Vehicle GetVehicle(VehicleType type);
        Ticket ParkVehicle(VehicleType type, string vehicleNumber, List<ParkingSlot> slots);
        bool UnparkVehicle(string vehicleNumberCheck, List<ParkingSlot> slots);
        Ticket UpdateTicket(string vehicleNumberCheck);

    }

}


