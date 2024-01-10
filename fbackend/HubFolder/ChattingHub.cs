using Microsoft.AspNetCore.SignalR;

namespace fbackend.HubFolder
{
    public class ChattingHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {

            await Clients.All.SendAsync("ReceiveMessage",user, message);
        }
    }
}
