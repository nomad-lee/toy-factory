using BaseProject.Data;
using BaseProject.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.SignalR;

namespace BaseProject.Hubs
{
    public class IotHub : Hub
    {
        private readonly BaseDbContext _dbContext;

        public IotHub(BaseDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task SendIotStatus(float status)
        {
            var num = Math.Truncate(status * 100) / 100;
            await Console.Out.WriteLineAsync(Convert.ToString(num) + "cm");
            await Clients.All.SendAsync("SendStatus", status);

            IoT_Data_Model iot = new IoT_Data_Model();
            iot.IoTModelId = 2023;
            iot.Data = (int)num;
            iot.CreateTime = DateTime.Now;

            _dbContext.IoT_Data_Models.Add(iot);
            _dbContext.SaveChanges();
        }


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
