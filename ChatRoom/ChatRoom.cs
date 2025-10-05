using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoom
{
    public  class ChatRoom : IChat
    {

        public  string Name { get; private set; }
        public  List<Message> Messages { get; private set; }

        public List<User> Users { get; private set; } = new List<User>();


        public ChatRoom(string name)
        {
            Name = name;
            Messages = new List<Message>();       
        }

        public void DeleteMessage(Message message)
        {
            Messages.Remove(message);
        }

        public void EditMessage(Message message, string newText)
        {
            message.Text = newText;
        }

        public void Logout(User user)
        {
            Users.Remove(user);
        }


        public void Join(User user)
        {
            Users.Add(user);
        }
        
        public void DisplayMessages()
        {
            foreach (var message in Messages)
            {
                Console.WriteLine($"{message.Timestamp} {message.User.Name} \n{message.Text}");
            }
        }

        public void SendMessage(User user, string text)
        {
            Message message = new Message(text, user);
            Messages.Add(message);
        }
    }
}
