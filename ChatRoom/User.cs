using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoom
{
    public class User
    {

        //private string _name;
        //private string _password;

        public string Name { get; private set; }
        public string Password { get; private set; }

        public User(string name, string password)
        {
            Name = name;
            Password = password;

        }


        //public static User RegisterNewChatter(string name, string password)
        //{
        //    return new User(name, password);
            
        //}


    }
}
