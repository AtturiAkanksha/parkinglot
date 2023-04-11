
namespace ParkingLot.Interfaces
{
    public interface IValidationServicecs
    {
        void ValidateSlots(int count);
        void ValidateVehicleType(int vehicleType);
        void ValidateVehicleNumber(string vehicleNumber);
    }
}
