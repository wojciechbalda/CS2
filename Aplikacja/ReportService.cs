using System;
using System.Collections.Generic;
using System.Linq;

namespace Aplikacja
{
    public class ReportService
    {
        public DeviceService deviceService { get; set; }
        public UserService userService { get; set; }
        public  RentalService rentalService { get; set; }
        

        public ReportService(DeviceService mdeviceService, UserService muserService, RentalService mrentalService)
        {
            deviceService = mdeviceService;
            userService = muserService;
            rentalService = mrentalService;
        }
        
        public void GenerateBasicReport()
        {
            Console.WriteLine("\nGenerowanie raportu ...");
            int numberOfAvailableDevicesToRent = deviceService.GetAllDevices().Count(d => d.IsAvailableToRent);
            int numberOfAllDevices = deviceService.GetAllDevices().Count;
            int numberOfRentals = rentalService.GetAllRentals().Count;
            int numberOfUsers = userService.GetAllUsers().Count;
            
            Console.WriteLine($"\tObecnie w bazie wypożyczalni istnieje {numberOfUsers} użytkowników.");
            Console.WriteLine($"\tCi użytkownicy łącznie dokonali {numberOfRentals} wypożyczeń");
            Console.WriteLine($"\tZ kolei obecnie wypożyczalnia posiada {numberOfAllDevices} przedmiotów");
            Console.WriteLine($"\tZ czego {numberOfAvailableDevicesToRent} przedmiotów jest obecnie niewypożyczona");
        }

        public void ShowAllDevicesWithTheirStatus()
        {
            List<Device> devices = deviceService.GetAllDevices();

            Console.WriteLine("\nOto urządzenia z naszej wypożyczalni wraz z informacją o tym czy są wypożyczone:");
            foreach (Device device in devices)
            {
                string text = device.IsAvailableToRent ? "Niewypożyczone" : "Wypożyczone";
                Console.WriteLine($"\t{device} ({text})");
            }
        }

        public void ShowAllDevicesAvailableToRent()
        {
            List<Device> devices = deviceService.GetAvailableDevices();
            
            Console.WriteLine("\nLista przedmiotów, które można obecnie wypożyczyć: ");
            foreach (Device device in devices)
            {
                if (device.IsAvailableToRent)
                    Console.WriteLine($"{device}");
            }
        }

        public void ShowActiveUserRentals(int userId)
        {
            List<Rental> rentals = rentalService.GetActiveRentals(userId);
            User user = userService.GetUserById(userId);
            
            Console.WriteLine($"\nAktywne wypożyczenia dla {user} to:");
            
            foreach (Rental rental in rentals)
            {
                Console.WriteLine($"\t{rental}");
            }
        }

        public void ShowOverdueRentals(DateTime currentDate)
        {
            
            
            List<Rental> rentals = rentalService.GetAllRentals().Where(r => r.ReturnDate == null && currentDate > r.PlannedReturnDate).ToList();

            Console.WriteLine("\nPrzeterminowane wypożyczenia nie zwrócone na ten moment to: ");
            foreach (Rental rental in rentals)
            {
                Console.WriteLine($"\t{rental}");
            }
        }
    }
}