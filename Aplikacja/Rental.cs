using System;

namespace Aplikacja
{
    public class Rental
    {
        private static int count = 0;
        
        public DateTime DateOfRent { get; set; }
        public DateTime PlannedReturnDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int StandardFee { get; set; }
        public int Penalty { get; set; }
        public int Id { get; set; }
        public Device Item { get; set; }
        public User Person { get; set; }

        public Rental(DateTime dateOfRent, DateTime plannedReturnDate, Device item, User person)
        {
            DateOfRent = dateOfRent;
            PlannedReturnDate = plannedReturnDate;
            Id = count++;
            Item =  item;
            Person = person;
            Penalty = 0;
            StandardFee = item.RentalPrice;
        }
        
        public override string ToString()
        {
            string personData = Person.ToString();
            string rentedItemData = Item.ToString();
            string message;
            
            if (ReturnDate != null)
            {
                string returnDateText = ReturnDate.Value.ToString("dd.MM.yyyy");
                string inactiveRentalTitle = $"Wypożyczenie#{Id} dla {personData} zostało zakończone. Trwało od {DateOfRent.ToString("dd.MM.yyyy")} i zwrot był zaplanowany do {PlannedReturnDate.ToString("dd.MM.yyyy")}. Faktyczna data zwrócenia przedmiotu to {returnDateText}\n";
                int totalCost = StandardFee + Penalty;
                message = $"za wypożyczenie zapłacono ${totalCost} zł w czym kara wynosiła {Penalty} zł\n\tWypożyczony sprzęt to: {rentedItemData}";
                return inactiveRentalTitle + message;
            }
            
            string activeRentalTitle = $"Wypożyczenie#{Id} dla {personData} obecnie jest aktywne od {DateOfRent.ToString("dd.MM.yyyy")} i jest zaplanowane do {PlannedReturnDate.ToString("dd.MM.yyyy")}\n";
            message = $"\tWypożyczony sprzęt to: {rentedItemData}";
            return activeRentalTitle + message;
        }
    }
}