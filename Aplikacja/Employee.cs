namespace Aplikacja
{
    public class Employee : User
    {
        public override int MaxRentals()
        {
            return 2;
        }

        public Employee(string firstName, string lastName) : base(firstName, lastName, "employee")
        {
            
        }
        
        public override string ToString()
        {
            string text =
                $"pracownik {FirstName} {LastName}";
            return text;
        }
    }
}