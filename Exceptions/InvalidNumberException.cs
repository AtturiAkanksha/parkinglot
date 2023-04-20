
namespace ParkingLot.Exceptions
{
    public class InvalidNumberException:Exception
    {
        public InvalidNumberException() : base("Please enter a number greater than zero") { }
    }
}
