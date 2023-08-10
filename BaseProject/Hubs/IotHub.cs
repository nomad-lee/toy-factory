using Microsoft.AspNetCore.SignalR;

namespace BaseProject.Hubs
{
    public class IotHub : Hub
    {
        // 비동기 통신, 클라이언트에서 호출할 메소드
        public async Task Block(int message)
        {
            // 클라이언트에게 메시지 전송
            await Clients.All.SendAsync("Block", message);
        }
        public async Task Belt_0ne(string message)
        {
            await Clients.All.SendAsync("Belt_0ne", message);
        }
        public async Task Belt_two(string message)
        {
            await Clients.All.SendAsync("Belt_two", message);
        }
        public async Task Belt_three(string message)
        {
            await Clients.All.SendAsync("Belt_three", message);
        }
        
    }
}
