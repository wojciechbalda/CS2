using System.Collections.Generic;
using System.Linq;

namespace Aplikacja
{
    public class UserService
    {
        private List<User> users = new List<User>();
        
        public User AddUser(string firstName, string lastName, string type)
        {
            User user;
            
            if (type == "employee")
                user = new Employee(firstName, lastName);
            else
                user = new Student(firstName, lastName);
            
            users.Add(user);
            return user;
        }
        
        public User GetUserById(int id)
        {
            return users.FirstOrDefault(user => user.Id == id);
        }

        public List<User> GetAllUsers()
        {
            return users;
        }
    }
}