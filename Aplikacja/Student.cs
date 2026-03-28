namespace Aplikacja
{
    public class Student : User
    {
        public override int MaxRentals()
        {
            return 2;
        }

        public Student(string firstName, string lastName) : base(firstName, lastName, "student")
        {
            
        }
        
        public override string ToString()
        {
            string text =
                $"student {FirstName} {LastName}";
            return text;
        }
    }
}
