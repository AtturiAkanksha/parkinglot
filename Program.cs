using ParkingLot.Enums;
using ParkingLot.Exceptions;
using ParkingLot.Models;
using ParkingLot.Services;

namespace ParkingLot
{
    class Program
    {
        public VehicleService vehicleService;
        public ParkingService? parkingService;
        public ValidationService validationService;
        int typeOfVehicle;
        List<ParkingSlot> slots;

        public Program()
        {
            validationService = new ValidationService();
            vehicleService = new VehicleService();
        }

        private List<ParkingSlot> GetInitializedLot()
        {
            Console.WriteLine("Welcome to ABC parking");
            Console.WriteLine("*********************************************");
            slots = new List<ParkingSlot>();
            foreach (var slotType in Enum.GetNames(typeof(SlotType)))
            {
                Console.WriteLine("Enter no. of slots for " + slotType);
                try
                {
                    int count = Convert.ToInt32(Console.ReadLine());
                    validationService.ValidateSlots(count);
                    for (int i = 0; i < count; i++)
                    {
                        ParkingSlot newSlot = new ParkingSlot();
                        newSlot.SlotType = (SlotType)Enum.Parse(typeof(SlotType), slotType);
                        slots.Add(newSlot);
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    GetInitializedLot();
                    break;
                }
            }
            return slots;
        }
        private void ParkVehicle()
        {
            Console.WriteLine("Enter vehicletype:\n 1.TwoWheeler \n 2.FourWheeler \n 3.HeavyWheeler");
            try
            {
                typeOfVehicle = Convert.ToInt32(Console.ReadLine());
                validationService.ValidateVehicleType(typeOfVehicle);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                ParkVehicle();
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
                ParkVehicle();
            }

            ParkingSlot getAllotedSlot = vehicleService.SlotAllotment((VehicleType)Enum.ToObject(typeof(VehicleType), typeOfVehicle), slots);
            if (getAllotedSlot == null)
            {
                Console.WriteLine("no slots are available for particular vehicle type");
            }
            else
            {
                Vehicle vehicle = vehicleService.ParkVehicle(getAllotedSlot, (VehicleType)Enum.ToObject(typeof(VehicleType), typeOfVehicle), vehicleNumber);
                Ticket ticket = vehicleService.TicketGeneration(vehicle, getAllotedSlot);
                DisplayTicket(ticket);
            }
        }
        private void  DisplayTicket(Ticket ticket)
        {
            
                Console.WriteLine("The slot for your vehicle is booked");
                Console.WriteLine("Ticket ID:" + ticket.Id);
                Console.WriteLine("slot number:" + ticket.SlotNumber);
                Console.WriteLine("vehicle number:" + ticket.VehicleNumber);
                Console.WriteLine("Intime:" + ticket.InTime);
                Console.WriteLine("*************************************************************************");
        }

        private void Unpark()
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
                Unpark();
            }
            bool isAvailable = vehicleService.UnparkVehicle(vehicleNumberCheck!, slots);
            vehicleService.UpdateTicket(vehicleNumberCheck!);
            if (isAvailable == true)
            {
                Console.WriteLine("your vehicle is unparked");
                Console.WriteLine("out time:" + DateTime.Now);

            }
            else
            {
                Console.WriteLine("no vehicle is parked  with given vehicle number");
            }
            Console.WriteLine("*********************************************");
        }

        private void CheckAvailability()
        {
            foreach (var slotType in Enum.GetNames(typeof(SlotType)))
            {
                int count = parkingService.GetCount((SlotType)Enum.Parse(typeof(SlotType), slotType));
                Console.WriteLine($"{slotType}:"+ count);
            }
            Console.WriteLine("*********************************************");
        }

        public static void Main(string[] args)
        {
            Program program = new Program();
            List<ParkingSlot> slots = program.GetInitializedLot();
            program.parkingService = new ParkingService(slots);
            string? option;

            while (true)
            {
                Console.WriteLine("select any one of the options: \n 1.Display slots available \n 2.Park the vehicle \n 3.Un-park the vehicle");
                option = Console.ReadLine();
               
                switch (option)
                {
                    case "1":
                        program.CheckAvailability();
                        break;
                    case "2":
                        program.ParkVehicle();
                        break;
                    case "3":
                        program.Unpark();
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

