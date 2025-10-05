namespace ChatRoom
{
    internal class Program
    {

        static List<User> allUsers = new();
        static List<ChatRoom> chatRooms = new();

        static User? currentUser;
        static ChatRoom? currentRoom;
        static void Main(string[] args)
        {
     
            DisplayMenu();


            Console.ReadKey();
        }


        public static void DisplayMenu()
        {
            bool running = true;
            while (running) 
            {
                Console.WriteLine("Would you like to: \n(1): Login \n(2): Register \n(3): Create new Chatroom" +
                "\n(4):Display all chatrooms  \n(5): Join Chatroom   \n(6) Delete Chatroom \n(7)Logout");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        //{
                        Console.Write("Enter user name: ");
                        string uName = Console.ReadLine();
                        Console.Write("Enter password: ");
                        string password = Console.ReadLine();
                        bool ok = Login(uName, password, allUsers);
                        if (ok)
                        {
                            foreach (var u in allUsers)
                            {
                                if (u.Name == uName && u.Password == password)
                                {
                                    currentUser = u;
                                    break;
                                }
                            }
                            Console.WriteLine($"{currentUser.Name} has logged in");
                        }
                        else
                        {
                            Console.WriteLine("Wrong credentials");
                        }
                        break;
                    //}?
                    case "2":
                        Console.Write("Add User name: ");
                        string userName = Console.ReadLine();
                        Console.Write("Add Password: ");
                        string userPassword = Console.ReadLine();
                        var user = User.RegisterNewChatter(userName, userPassword, UserRole.Regular);
                        allUsers.Add(user);
                        Console.WriteLine($"{user.Name} has been registred");
                        break;
                    case "3":
                        var chatroom = CreateChatRoom();
                        chatRooms.Add(chatroom);
                        Console.WriteLine($"Chatroom {chatroom.Name} has been created");
                        break;
                    case "4":
                        if(chatRooms.Count == 0)
                        {
                            Console.WriteLine("no rooms created");
                            break;
                        }
                        DisplayChatrooms(chatRooms);
                        break;
                    case "5":
                        
                        if (chatRooms.Count == 0)
                        {
                            Console.WriteLine("no rooms avalible");
                            break;
                        }
                        DisplayChatrooms(chatRooms);
                        Console.WriteLine("Choose a ChatRoom to enter");
                        int roomIndex = int.Parse(Console.ReadLine());
                        if (roomIndex > chatRooms.Count)
                        {
                            Console.WriteLine("Number chosen is invalid");
                        }
                        currentRoom = chatRooms[roomIndex];
                        currentRoom.Join(currentUser);  
                        RoomMenu();
                        break;
                    case "6":
                        if (chatRooms.Count == 0)
                        {
                            Console.WriteLine("no rooms avalible");
                            break;
                        }
                        DisplayChatrooms(chatRooms);
                        Console.WriteLine("Choose a ChatRoom to delete");
                        int index = int.Parse(Console.ReadLine());
                        if (index >= chatRooms.Count || index < 0)
                        {
                            Console.WriteLine("Number chosen is invalid");
                        }
                        DeleteChatroom(chatRooms[index], chatRooms);
                        break;
                    case "7":
                        if (currentUser == null) { Console.WriteLine("No user logged in."); break; }
                        if (currentRoom != null)
                        {
                            currentRoom.Logout(currentUser);
                            currentRoom = null;
                        }
                        Console.WriteLine($"{currentUser.Name} logged out.");
                        currentUser = null;
                        break;
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
            
        }


        static void RoomMenu()
        {
            while(currentRoom != null)
            {
                Console.WriteLine("\nRoom menu:");
                Console.WriteLine("1) Show messages");
                Console.WriteLine("2) Send message");
                Console.WriteLine("3) Edit message");
                Console.WriteLine("4) Delete message");
                Console.WriteLine("5) Leave room");
                Console.Write("Choice: ");
                string c = Console.ReadLine();

                switch (c)
                {
                    case "1":
                        currentRoom.DisplayMessages();
                        break;
                    case "2":
                        Console.Write("Enter message: ");
                        string message = Console.ReadLine();
                        currentRoom.SendMessage(currentUser, message);
                        break;
                    case "3":
                        Console.WriteLine("Enter message index to edit");
                        int i = int.Parse(Console.ReadLine());
                        Console.Write("Enter message");
                        string messageEdit = Console.ReadLine();
                        currentRoom.EditMessage(currentRoom.Messages[i], messageEdit);
                        break;
                    case "4":
                        Console.WriteLine("Enter message index to delete");
                        int j = int.Parse(Console.ReadLine());
                        currentRoom.DeleteMessage(currentRoom.Messages[j]);
                        break;
                    case "5":
                        currentRoom = null;
                        break;
                }


            }


        }



        static public ChatRoom CreateChatRoom()
        {
            Console.Write("Enter name of Chat Room: ");
            string name = Console.ReadLine();
            return new ChatRoom(name);

        }


        static public void DisplayChatrooms(List<ChatRoom> chatrooms)
        {
            for (int i = 0; i < chatrooms.Count; i++)
            {
                Console.WriteLine($"{i} {chatrooms[i].Name}");
            }
        }


        static public bool Login(string username, string password, List<User> userList)
        {
            foreach (User user in userList)
            {
                if (user.Name == username && user.Password == password)
                {
                    return true;
                }
            }
            return false;
        }

        static public void DeleteChatroom(ChatRoom chatroom, List<ChatRoom> chatrooms)
        {
            chatrooms.Remove(chatroom);
        }


    }
}
