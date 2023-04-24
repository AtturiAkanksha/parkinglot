using ParkingLot.Enums;
using ParkingLot.Interfaces;
using ParkingLot.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace ParkingLot.Services
{
    public class ParkingLotService : IParkingLotService
    {
        ParkingSpace parkingSpace;

        public ParkingLotService()
        {
            parkingSpace = new ParkingSpace();
            parkingSpace.Slots = new List<ParkingSlot>();
        }

        public void InitialiseLot(int slotCount, int slotType)
        {
            for (int i = 0; i < slotCount; i++)
            {
                ParkingSlot newSlot = new ParkingSlot();
                newSlot.SlotType = (SlotType)slotType;
                newSlot.IsAvailable = true;
                parkingSpace.Slots.Add(newSlot);
                int index = parkingSpace.Slots.IndexOf(newSlot);
                newSlot.SlotNumber = index + 1;
            }
        }

        public int CountAvailableSlots(SlotType type)
        {

            return parkingSpace.Slots.Where(slot => slot.SlotType == type && slot.IsAvailable).Count();

        }

        public ParkingSlot VehicleIsAvailable(string vehicleNumber)
        {
            return parkingSpace.Slots.FirstOrDefault(slot => slot.Vehicle != null && slot.Vehicle.VehicleNumber == vehicleNumber);

        }

        public ParkingSlot? AllotSlot(VehicleType type)
        {
            ParkingSlot? slot = parkingSpace.Slots.FirstOrDefault(slot => slot.SlotType.ToString() == type.ToString() && slot.IsAvailable);
            if (slot != null)
            {
                slot.IsAvailable = false;
                return slot;
            }
            return null;
        }
    }
}