using ParkingLot.Exceptions;
using System.Text.RegularExpressions;

namespace ParkingLot.Services
{
    public class ValidationService
    {
        public void ValidateSlots(int count)
        {
            if (count <= 0)
                throw new InvalidSlotsException();
        }

        public void ValidateVehicleType(int vehicleType)
        {
            if (vehicleType < 0 || vehicleType > 3)
                throw new InvalidVehicleTypeException();
        }

        public void ValidateVehicleNumber(string vehicleNumber)
        {
            Regex regex = new Regex("[0-9]{4}");
            if (!regex.IsMatch(vehicleNumber))
                throw new InvalidVehicleNumberException(vehicleNumber);
        }
    }
}
