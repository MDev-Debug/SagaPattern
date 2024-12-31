using Microsoft.AspNetCore.SignalR;

namespace Hubs;
public class ChatHub : Hub
{
    public override Task OnConnectedAsync()
    {
        return Clients.All.SendAsync($" {Environment.GetEnvironmentVariable("SERVER").ToString()}");
    }
    public async Task SendMessage(string user, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", user, message + $" {Environment.GetEnvironmentVariable("SERVER").ToString()}");
    }
}
