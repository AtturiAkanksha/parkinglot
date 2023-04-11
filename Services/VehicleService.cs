using ParkingLot.Enums;
using ParkingLot.Models;

namespace ParkingLot.Services
{
    public class VehicleService
    {
        TicketService ticketService;

        public VehicleService()
        {
            ticketService = new TicketService();
        }

        private Vehicle CreateVehicle(VehicleType type)
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

        public ParkingSlot? SlotAllotment(VehicleType type,  List<ParkingSlot> slots)
        {
            ParkingSlot?  slot = slots.FirstOrDefault(slot => slot.SlotType.ToString() == type.ToString() && slot.IsAvailable == true);
            if (slot != null)
            {
                slot.IsAvailable = false;
                int index = slots.IndexOf(slot);
                slot.SlotNumber = index + 1;
                return slot;
            }
            return null;
        }

        public Vehicle ParkVehicle(ParkingSlot slot, VehicleType type, string vehicleNumber)
        {
            Vehicle vehicle = CreateVehicle(type);
            vehicle.VehicleNumber = vehicleNumber;
            vehicle.VehicleType = type;
            slot.Vehicle = vehicle;
            return vehicle;
        }
        
        public Ticket TicketGeneration(Vehicle vehicle, ParkingSlot slot)
        {
            string? vehicleNumber = vehicle.VehicleNumber;
            int slotNumber = slot.SlotNumber;
            VehicleType vehicleType = vehicle.VehicleType;
            Ticket ticket = ticketService.GenerateTicket(vehicleNumber, slotNumber, vehicleType);
            return ticket;
        }

        public bool UnparkVehicle(string vehicleNumberCheck, List<ParkingSlot> slots)
        {
            ParkingSlot? slot = slots.FirstOrDefault(slot => slot.Vehicle != null && slot.Vehicle.VehicleNumber == vehicleNumberCheck);
            if (slot != null)
            {
                slot.Vehicle = null;
                slot.IsAvailable = true;
                return true;
            }
            return false;
        }

        public void UpdateTicket(string vehicleNumberCheck)
        {
            Ticket? ticket = ticketService.ticketsList.FirstOrDefault(ticket => ticket.VehicleNumber == vehicleNumberCheck);
            if (ticket != null) { 
                ticket.OutTime = DateTime.Now;
            }
        }
    }
}
