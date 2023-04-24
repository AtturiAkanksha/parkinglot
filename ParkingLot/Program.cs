using ParkingLot.Enums;
using ParkingLot.Models;
using ParkingLot.Services;

namespace ParkingLot
{
    class Program
    {
        static int typeOfVehicle;
        static ParkingLotService parkingLotService;
        static ValidationOperations validationOperations;
        static ParkingSlotService parkingSlotService;
        static TicketService ticketService;
        public Program()
        {
        }

        private static void GetInput()
        {
            Console.WriteLine("Welcome to ABC parking");
            Console.WriteLine("*********************************************");
            foreach (int slotType in Enum.GetValues(typeof(SlotType)))
            {
                ReadInput(slotType);
            }
        }

        public static void ReadInput(int slotType)
        {
            Console.WriteLine($"Enter number of slots for {(SlotType)slotType}");
            string count = Console.ReadLine();
            bool isValid = ValidateInput(count);
            if (!isValid)
            {
                ReadInput(slotType);
            }
            else
            {
                parkingLotService.InitialiseLot(int.Parse(count), slotType);
            }
        }

        private static bool ValidateInput(string slotsCount)
        {
            if (!int.TryParse(slotsCount, out var result))
            {
                Console.WriteLine("Input is not in integer format");
                return false;
            }
            else if (result < 0)
            {
                Console.WriteLine("Please, enter a number greater than zero");
                return false;
            }
            return true;
        }

        private static  void ParkVehicle()
        {
            Console.WriteLine("Enter vehicletype:\n 1.TwoWheeler \n 2.FourWheeler \n 3.HeavyWheeler");
            try
            {
               typeOfVehicle = int.Parse(Console.ReadLine());
                validationOperations.ValidateVehicleType(typeOfVehicle);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
           
            ParkingSlot getAllotedSlot = parkingLotService.AllotSlot((VehicleType)Enum.ToObject(typeof(VehicleType), typeOfVehicle));
            if (getAllotedSlot == null)
            {
                Console.WriteLine("no slots are available for particular vehicle type");
            }
            else
            {
                Console.WriteLine("Enter vehicle number:");
                string? vehicleNumber = Console.ReadLine();
                try
                {
                    validationOperations.ValidateVehicleNumber(vehicleNumber);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
                Vehicle vehicle = parkingSlotService.ParkVehicle(getAllotedSlot, (VehicleType)Enum.ToObject(typeof(VehicleType), typeOfVehicle), vehicleNumber.ToUpper());
                Ticket ticket = ticketService.GenerateTicket(vehicle, getAllotedSlot);
                DisplayTicket(ticket);
            }
        }

        private static void  DisplayTicket(Ticket ticket)
        {
                Console.WriteLine("The slot for your vehicle is booked");
                Console.WriteLine("Ticket ID:" + ticket.Id);
                Console.WriteLine("slot number:" + ticket.SlotNumber);
                Console.WriteLine("vehicle number:" + ticket.VehicleNumber);
                Console.WriteLine("Intime:" + ticket.InTime);
                Console.WriteLine("*************************************************************************");
        }

        private static void Unpark()
        {
            Console.WriteLine("Enter vehicle number:");
            string? vehicleNumber = Console.ReadLine();
            try
            {
                validationOperations.ValidateVehicleNumber(vehicleNumber);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            ParkingSlot slot = parkingLotService.VehicleIsAvailable(vehicleNumber.ToUpper());

            if (slot != null)
            {
                parkingSlotService.Unpark(slot);
                Ticket ticket = ticketService.UpdateTicket(vehicleNumber.ToUpper());
                Console.WriteLine("your vehicle is unparked");
                Console.WriteLine("out time:" + ticket.OutTime);

            }
            else
            {
                Console.WriteLine("no vehicle is parked  with given vehicle number");
            }
            Console.WriteLine("*********************************************");
        }

        private static void CheckAvailability()
        {
            foreach (var slotType in Enum.GetNames(typeof(SlotType)))
            {
               int availableSlotsCount = parkingLotService.CountAvailableSlots((SlotType)Enum.Parse(typeof(SlotType), slotType));
               Console.WriteLine($"{slotType}:"+ availableSlotsCount);
            }
            Console.WriteLine("*********************************************");
        }

        public static void Main(string[] args)
        {
            ticketService = new TicketService();
            parkingLotService = new ParkingLotService();
            validationOperations = new ValidationOperations();
            parkingSlotService = new ParkingSlotService();
            GetInput();
            string? option;

            while (true)
            {
                Console.WriteLine("select any one of the options: \n 1.Display slots available \n 2.Park the vehicle \n 3.Un-park the vehicle");
                option = Console.ReadLine();
               
                switch (option)
                {
                    case "1":
                        CheckAvailability();
                        break;
                    case "2":
                        ParkVehicle();
                        break;
                    case "3":
                        Unpark();
                        break;

                    default:
                        Console.WriteLine("Value didn't match earlier.");
                        Console.WriteLine("*********************************************");
                        break;
                }
            }
        }
    }
}

