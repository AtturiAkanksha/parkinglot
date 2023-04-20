
namespace ParkingLot.Interfaces
{
    public interface IValidationService
    {
        void ValidatePositiveNumber(int count);
        void ValidateVehicleType(int vehicleType);
        void ValidateVehicleNumber(string vehicleNumber);
    }
}
