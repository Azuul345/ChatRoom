using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoom

{
    public enum UserRole 
    {
        Admin,
        Regular
    }
    public class User
    {

        public string Name { get; private set; }
        public string Password { get; private set; }

        public UserRole Role { get; private set; }

        public User(string name, string password, UserRole role)
        {
            Name = name;
            Password = password;
            Role = role;

        }


        public static User RegisterNewChatter(string name, string password, UserRole role)
        {
            return new User(name, password, role);

        }

    }
}
