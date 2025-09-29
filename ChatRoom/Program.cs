namespace ChatRoom
{
    internal class Program
    {
        static void Main(string[] args)
        {

            User u = RegisterNewChatter("nn","12344");







            Console.ReadKey();
        }





        public static ChatRoom CreateChatRoom()
        {
            Console.Write("Enter name of Chat Room: ");
            string name = Console.ReadLine();
            return new ChatRoom(name);

        }

        public static User Login(List<User> users, User chatter)
        {
            foreach(User u in users)
            {
                if (u.Name == chatter.Name && u.Password == chatter.Password)
                {
                    User user = u;
                    return u;
                }
            }
            Console.WriteLine("Unable to find User");
            return null;

        }


        public static User RegisterNewChatter(string name, string password)
        {
            return new User(name, password);

        }

    }
}
