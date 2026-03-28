using System;
using System.Collections.Generic;
using System.Linq;

namespace Aplikacja
{
    public class RentalService
    {
        private List<Rental> rentals = new List<Rental>();
        private UserService userService;
        private DeviceService deviceService;
        
        public RentalService(UserService muserService, DeviceService mdeviceService)
        {
            userService = muserService;
            deviceService = mdeviceService;
        }
        
        public void RentDevice(int userId, int deviceId, int days, DateTime currentDate)
        {
            User user = userService.GetUserById(userId);
            Device device = deviceService.GetDeviceById(deviceId);
            
            if (user == null || device == null)
                throw new Exception("User or device not found");
            
            if (!device.IsAvailableToRent)
                throw new Exception("Device is not available to rent");
            
            int userLimit = user.MaxRentals();
            
            int userActiveRentals = rentals.Count(r => (r.Person == user) && (r.ReturnDate == null));

            if (userLimit == userActiveRentals)
            {
                throw new Exception("Osoba przekroczyła limit wypożyczeń. Wypożyczenie zakończone porażką");
            }

            Rental rental = new Rental(currentDate, currentDate.AddDays(days), device, user);
            device.IsAvailableToRent = false;
            rentals.Add(rental);
        }

        public void ReturnDevice(int deviceId, DateTime returnDate)
        {
            Rental rental = rentals.FirstOrDefault(r => r.Item.Id == deviceId && r.ReturnDate == null);
            
            if (rental == null)
                throw new Exception("Nie ma aktualnie wypożyczenia dla podanego sprzętu");

            if (rental.PlannedReturnDate < returnDate)
            {
                int penaltyFee = 100;
                Console.WriteLine("Przedmiot zwrócony po terminie. Wyliczamy karę.");
                int extraDays = (returnDate - rental.PlannedReturnDate).Days;
                rental.Penalty = extraDays * penaltyFee;
            }
            
            rental.ReturnDate = returnDate;
            rental.Item.IsAvailableToRent = true;
        }

        public List<Rental> GetAllRentals()
        {
            return rentals;
        }
        
        public List<Rental> GetActiveRentals(int userId)
        {
            return rentals.Where(r => r.Person.Id == userId && r.ReturnDate == null).ToList();
        }
    }
}