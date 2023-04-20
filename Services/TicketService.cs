using ParkingLot.Enums;
using ParkingLot.Interfaces;
using ParkingLot.Models;
namespace ParkingLot.Services
{
    public class TicketService : ITicketService
    {

        ParkingSpace parkingSpace;
        public TicketService()
        {
            parkingSpace = new ParkingSpace();
            parkingSpace.Tickets = new List<Ticket>();
        }
        public Ticket GenerateTicket(Vehicle vehicle, ParkingSlot slot)
        {
            Ticket ticketObject = new Ticket();
            ticketObject.InTime = DateTime.Now;
            ticketObject.Id = Guid.NewGuid();
            ticketObject.SlotNumber = slot.SlotNumber;
            ticketObject.VehicleNumber = vehicle.VehicleNumber;
            ticketObject.VehicleType = vehicle.VehicleType;
            parkingSpace.Tickets.Add(ticketObject);
            return ticketObject;
        }

        public Ticket UpdateTicket(string vehicleNumber)
        {
            Ticket? ticket = parkingSpace.Tickets.FirstOrDefault(ticket => ticket.VehicleNumber == vehicleNumber);
            if (ticket != null)
            {
                ticket.OutTime = DateTime.Now;
                return ticket;
            }
            return null;
        }
    }
}
