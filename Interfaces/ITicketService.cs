using ParkingLot.Enums;
using ParkingLot.Models;

namespace ParkingLot.Interfaces
{
    public interface ITicketService
    {
        Ticket GenerateTicket(string vehicleNumber, int slotNumber, VehicleType typeOfVehicle);
    }
}
