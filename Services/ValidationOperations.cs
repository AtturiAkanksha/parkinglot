using ParkingLot.Exceptions;
using ParkingLot.Interfaces;
using System.Text.RegularExpressions;

namespace ParkingLot.Services
{
    public class ValidationOperations: IValidationOperations
    {
        public void ValidateVehicleType(int vehicleType)
        {
            if (vehicleType <= 0 || vehicleType > 3)
                throw new InvalidVehicleTypeException();
        }

        public void ValidateVehicleNumber(string vehicleNumber)
        {
            Regex regex = new Regex("^[A-Z|a-z]{2}\\s?[0-9]{1,2}\\s?[A-Z|a-z]{0,3}\\s?[0-9]{4}$");
            if (!regex.IsMatch(vehicleNumber))
                throw new InvalidVehicleNumberException(vehicleNumber);
        }
     
    }
}
