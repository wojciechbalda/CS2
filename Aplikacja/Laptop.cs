namespace Aplikacja
{
    public class Laptop : Device
    {
        public string ProcessorName { get; set; }
        public string RamSize { get; set; }
        
        public Laptop(string name, int purchasePrice, int productionYear, int rentalPrice, bool isAvailableToRent, string processorName, string ramSize) : base(name, purchasePrice, productionYear, rentalPrice, isAvailableToRent)
        {
            ProcessorName = processorName;
            RamSize = ramSize;
        }
        
        public override string ToString()
        {
            string text =
                $"Laptop {Name} z procesorem {ProcessorName} i ramem {RamSize} GB - wyprodukowany w {ProductionYear}";
            return text;
        }
    }
}