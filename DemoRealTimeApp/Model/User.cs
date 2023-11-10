using System;

namespace DemoRealTimeApp.Model
{
    public class User
    {
        public string UserName { get; set; }
        public string ConnectId { get; set; }

        public User(string userName, string connectId)
        {
            UserName = userName;
            ConnectId = connectId;
        }

        public static class UserList
        {
            public static List<User> Users = new List<User>();

            public static void AddUser(User user)
            {
                Users.Add(user);
            }
            public static User GetUser(string UserName)
            {
                return Users.FirstOrDefault(u => u.UserName == UserName);
            }

            public static User GGetUseConnectID(string ConnectId)
            {
                return Users.FirstOrDefault(u => u.ConnectId == ConnectId);
            }
        }
    }
}
