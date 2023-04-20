
namespace ParkingLot.Exceptions
{
    public class InvalidVehicleNumberException : Exception
    {
        public InvalidVehicleNumberException(string vehicleNumber)
              : base(string.Format("Invalid Vehicle Number:{0}", vehicleNumber))
        {
        }
    }
}
