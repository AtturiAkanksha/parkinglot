using ParkingLot.Enums;
using ParkingLot.Interfaces;
using ParkingLot.Models;

namespace ParkingLot.Services
{
    public class TicketService : ITicketService
    {
        public List<Ticket> ticketsList = new List<Ticket>();

        public Ticket GenerateTicket(string vehicleNumber, int slotNumber, VehicleType typeOfVehicle)
        {
            Ticket ticketObject = new Ticket();
            ticketObject.InTime = DateTime.Now;
            ticketObject.Id = Guid.NewGuid();
            ticketObject.SlotNumber = slotNumber;
            ticketObject.VehicleNumber = vehicleNumber;
            ticketObject.VehicleType = typeOfVehicle;
            ticketsList.Add(ticketObject);
            return ticketObject;
        }
    }
}
