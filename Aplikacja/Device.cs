namespace Aplikacja
{
    public class Device
    {
        private static int count = 0;
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public int PurchasePrice { get; set; }
        public int ProductionYear { get; set; }
        public int RentalPrice { get; set; }
        public bool IsAvailableToRent { get; set; }

        public Device(string name, int purchasePrice, int productionYear, int rentalPrice, bool isAvailableToRent)
        {
            Id = count++;
            Name = name; 
            PurchasePrice = purchasePrice;
            ProductionYear = productionYear;
            RentalPrice = rentalPrice;
            IsAvailableToRent = isAvailableToRent;
        }
    }
}