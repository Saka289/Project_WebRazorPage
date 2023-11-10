using DemoRealTimeApp.Model;
using Microsoft.AspNetCore.SignalR;
using static DemoRealTimeApp.Model.User;

namespace DemoRealTimeApp.Pages.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMess(string user, string message)
        {
            //await Clients.All.SendAsync("ReceivedMess", user, message);
            User u = UserList.GetUser(user);
            User caller = UserList.GGetUseConnectID(Context.ConnectionId);
            if (u is null)
            {
                return;
            }
            await Clients.Client(u.ConnectId).SendAsync("ReceivedMess", caller.UserName, message);
        }

        public void SetUserName(string userName)
        {
            UserList.AddUser(new User(userName, Context.ConnectionId));
        }
    }
}
