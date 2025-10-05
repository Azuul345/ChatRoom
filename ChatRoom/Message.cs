using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoom
{
    public class Message
    {


        public string Text { get; internal set; }
        public DateTime Timestamp { get; private set; }
        public User User { get; private set; }

        public Message(string text, User user)
        {
            Text = text;
            Timestamp = DateTime.Now;
            User = user;
            
        }

    }
}
