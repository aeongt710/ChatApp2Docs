using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace ChatApp2Docs.Chat
{
    public class ChatHub: Hub
    {
        public async Task SendMessage(string message)
        {
            string a = Context.User.Identity.Name;
            await Clients.All.SendAsync("ReceivePublicMessage", a , message);
        }
        public async Task SendSpecificMessage(string toUser,  string message)
        {
            string name = Context.User.Identity.Name;
            await Clients.Group(name).SendAsync("ReceivePrivateMessage",name ,message);
            await Clients.Group(toUser).SendAsync("ReceivePrivateMessage", name, message);
        }
        public override async Task<Task> OnConnectedAsync()
        {
            string name = Context.User.Identity.Name;
            await Groups.AddToGroupAsync(Context.ConnectionId, name);
            return base.OnConnectedAsync();
        }
    }
}
