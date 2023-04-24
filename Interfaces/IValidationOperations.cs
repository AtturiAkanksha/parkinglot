
namespace ParkingLot.Interfaces
{
    public interface IValidationOperations
    {
        void ValidateVehicleType(int vehicleType);
        void ValidateVehicleNumber(string vehicleNumber);
    }
}
