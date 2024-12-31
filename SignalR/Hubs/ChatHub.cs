using Microsoft.AspNetCore.SignalR;

namespace Hubs;
public class ChatHub : Hub
{
    public async Task SendMessage(string id, string message)
    {
        await Clients.Group(id).SendAsync("ReceiveMessage", message + $" {Environment.GetEnvironmentVariable("SERVER").ToString()}");
    }
}
