using ParkingLot.Models;

namespace ParkingLot.Interfaces
{
    public interface ITicketService
    {
        Ticket GenerateTicket(Vehicle vehicle, ParkingSlot slot);
        Ticket UpdateTicket(string vehicleNumber);
    }
}
