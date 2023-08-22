using Microsoft.AspNetCore.SignalR;

namespace BaseProject.Hubs
{
    public class ImageHub : Hub
    {
        public async Task SendMessage(string message)
        {
            /*await Console.Out.WriteLineAsync(message);*/
            await Clients.All.SendAsync("ReceiveMessage", message);
        }

    }
}
