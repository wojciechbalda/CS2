using System;

namespace Aplikacja
{
    public class Monitor : Device
    {
        public int ScreenSizeInInches { get; set; }
        public int RefreshRate { get; set; }

        public Monitor(string name, int purchasePrice, int productionYear, int rentalPrice, bool isAvailableToRent, int screenSizeInInches, int refreshRate) :
            base(name, purchasePrice, productionYear, rentalPrice, isAvailableToRent)
        {
            ScreenSizeInInches = screenSizeInInches;
            RefreshRate = refreshRate;
        }

        public override string ToString()
        {
            string text =
                $"Monitor {Name} {ScreenSizeInInches}'' z odświeżaniem {RefreshRate} Hz - wyprodukowany w {ProductionYear}";
            return text;
        }
    }
}