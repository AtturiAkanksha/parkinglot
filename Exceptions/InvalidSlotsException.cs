using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Exceptions
{
    public class InvalidSlotsException:Exception
    {
        public InvalidSlotsException():base("Please enter a number greater than zero.") 
            { }
    }
}
