using ParkingLot.Enums;
using ParkingLot.Interfaces;
using ParkingLot.Models;

namespace ParkingLot.Services
{
    public class ParkingSlotService : IParkingSlotService
    {

        VehicleService vehicleService = new VehicleService();

        public Vehicle ParkVehicle(ParkingSlot slot, VehicleType type, string vehicleNumber)
        {
            Vehicle vehicle = vehicleService.CreateVehicle(type);
            slot.Vehicle = vehicle;
            slot.Vehicle.VehicleNumber = vehicleNumber;
            slot.Vehicle.VehicleType = type;
            return vehicle;
        }

        public void Unpark(ParkingSlot slot)
        {
            slot.Vehicle = null;
            slot.IsAvailable = true;
        }
    }
}