namespace Aplikacja
{
    public class Phone : Device
    {
        public string OperatingSystemName { get; set; }
        public bool IsESIMSupportAvailable { get; set; }

        public Phone(string name, int purchasePrice, int productionYear, int rentalPrice, bool isAvailableToRent,
            string operatingSystemName, bool isEsimSupportAvailable) :
            base(name, purchasePrice, productionYear, rentalPrice, isAvailableToRent)
        {
            OperatingSystemName = operatingSystemName;
            IsESIMSupportAvailable = isEsimSupportAvailable;
        }
        
        public override string ToString()
        {
            string esimText = IsESIMSupportAvailable ? "wspiera" : "nie wspiera"; 
            string text =
                $"Telefon {Name} z systemem operacyjnym {OperatingSystemName}, który {esimText} Esim - wyprodukowany w {ProductionYear}";
            return text;
        }
    }
}