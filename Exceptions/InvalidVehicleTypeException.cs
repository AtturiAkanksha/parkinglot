
namespace ParkingLot.Exceptions
{
    public class InvalidVehicleTypeException:Exception
    {
        public InvalidVehicleTypeException()
             : base("Please enter a correct option")
        {
        }
    }
}
