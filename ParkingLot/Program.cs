using ParkingLot.Enums;
using ParkingLot.Models;
using ParkingLot.Services;

namespace ParkingLot
{
    class Program
    {
        static int typeOfVehicle;
        static int slotsInput;
        static List<ParkingSlot> slots;
        static ParkingLotService parkingLotService;
        static ValidationService validationService;
        static VehicleService vehicleService;
        static ParkingSlotService parkingSlotService;
        static TicketService ticketService;
        private static void SlotsInput()
        {
            Console.WriteLine("Welcome to ABC parking");
            Console.WriteLine("*********************************************");
            foreach (int slotType in Enum.GetValues(typeof(SlotType))) {
                Console.WriteLine($"Enter number of {(SlotType)slotType} Slots:");
                try
                {
                    slotsInput = int.Parse(Console.ReadLine());
                    validationService.ValidatePositiveNumber(slotsInput);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a number");
                    SlotsInput();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    SlotsInput();
                }
                slots = parkingLotService.InitialiseLot(slotsInput, slotType);
            }
        }
        private static  void ParkVehicle()
        {
            Console.WriteLine("Enter vehicletype:\n 1.TwoWheeler \n 2.FourWheeler \n 3.HeavyWheeler");
            try
            {
               typeOfVehicle = int.Parse(Console.ReadLine());
                validationService.ValidateVehicleType(typeOfVehicle);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            Console.WriteLine("Enter vehicle number:");
            string? vehicleNumber = Console.ReadLine();
            try
            {
                validationService.ValidateVehicleNumber(vehicleNumber!);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            ParkingSlot getAllotedSlot = parkingSlotService.AllotSlot((VehicleType)Enum.ToObject(typeof(VehicleType), typeOfVehicle), slots);
            if (getAllotedSlot == null)
            {
                Console.WriteLine("no slots are available for particular vehicle type");
            }
            else
            {
                Vehicle vehicle = vehicleService.ParkVehicle(getAllotedSlot, (VehicleType)Enum.ToObject(typeof(VehicleType), typeOfVehicle), vehicleNumber);
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
            string? vehicleNumberCheck = Console.ReadLine();
            try
            {
                validationService.ValidateVehicleNumber(vehicleNumberCheck!);
            }
            catch(Exception e) 
            {
                Console.WriteLine(e.Message);
                return;
            }
            bool isAvailable = vehicleService.UnparkVehicle(vehicleNumberCheck!, slots);
            Ticket ticket = ticketService.UpdateTicket(vehicleNumberCheck!);
            if (isAvailable == true)
            {
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
            validationService = new ValidationService();
            vehicleService= new VehicleService();
            parkingSlotService = new ParkingSlotService();
            slots = new List<ParkingSlot>();
            SlotsInput();
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

