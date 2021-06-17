using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Test_66bit
{
    public class ChatHub : Hub
    {
        public async Task Send(string message)
        {
            await Clients.All.SendAsync("Receive", message);
        }
    }
}