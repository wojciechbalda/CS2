namespace Aplikacja
{
    abstract public class User
    { 
        private static int count = 0;
        
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Type { get; set; }
        

        public User(string firstName, string lastName, string type)
        {
            Id = count++;
            FirstName = firstName;
            LastName = lastName;
            Type = type;
        }

        public abstract int MaxRentals();
    }
}