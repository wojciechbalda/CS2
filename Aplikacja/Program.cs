using System;

namespace Aplikacja
{
  internal class Program
  {
    public static void Main(string[] args)
    {
      UserService userService = new UserService();
      DeviceService deviceService = new DeviceService();
      RentalService rentalService = new RentalService(userService, deviceService);
      ReportService reportService = new ReportService(deviceService, userService, rentalService);
      
      Device laptop =  deviceService.AddDevice(new Laptop("Dell", 1000, 2020, 100, true, "Intel i7", "8 MB"));
      Device laptop2 =  deviceService.AddDevice(new Laptop("Lenovo", 1000, 2020, 100, true, "Intel i5", "16 MB"));
      Device monitor = deviceService.AddDevice(new Monitor("Monitor Acer Nitro XF273U", 1199, 2024, 200, true, 27, 320));
      Device phone = deviceService.AddDevice(new Phone("Samsung Galaxy S26", 7399, 2026, 300, true, "Android", true));

      User employee1 = userService.AddUser("Kacper", "Nowak", "employee");
      User student1 = userService.AddUser("Kacper", "Kowalski", "student");
      

      rentalService.RentDevice(student1.Id, laptop.Id, 7, new DateTime(2026, 3, 10));
      rentalService.RentDevice(student1.Id, monitor.Id, 1, new DateTime(2026, 3, 10));
      rentalService.RentDevice(employee1.Id, phone.Id, 20, new DateTime(2026, 3, 10));

      foreach (Rental ren in rentalService.GetAllRentals())
      {
        Console.WriteLine(ren);
      }
      
      try
      {
        rentalService.RentDevice(student1.Id, laptop2.Id, 7, new DateTime(2026, 3, 10));
      }
      catch (Exception e)
      {
        Console.WriteLine("Wypożyczenie zakończone niepowodzeniem");
      }
      
      rentalService.ReturnDevice(monitor.Id, new DateTime(2026, 3, 13));
      
      reportService.GenerateBasicReport();
      reportService.ShowActiveUserRentals(student1.Id);
      reportService.ShowAllDevicesAvailableToRent();
      reportService.ShowOverdueRentals(new DateTime(2026, 03, 20));
      reportService.ShowAllDevicesWithTheirStatus();
    }
  }
}