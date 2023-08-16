using BaseProject.Data;
using BaseProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BaseProject.Hubs
{
    public class IotHub : Hub
    {
        private readonly BaseDbContext baseDbContext;
        static int oldDistance = 0;
        static int count = 0;
        static int flag = 0;

        public IotHub(BaseDbContext baseDbContext)
        {
            this.baseDbContext = baseDbContext;
        }
        /*public async Task SendStatus(float distance, int kind)*/
        public async Task SendStatus(float distance)
        {
            await Console.Out.WriteLineAsync(Convert.ToString(Math.Truncate(distance * 100) / 100) + "cm");
            //await Console.Out.WriteLineAsync("oldStatus : " + oldStatus);
            /*await Clients.All.SendAsync("SendSonicWave", status);*/

            if (flag == 0) // 생산품 대기중
            {
                if ((int)distance < 30) // 인식거리가 30cm 이하면 생산품으로 인식
                {
                    flag = 1; // 생산품 지나가는 중
                    await Console.Out.WriteLineAsync("물건 인식!");
                }
                else
                {
                }
            }
            else // flag true 물건 지나가는 중
            {
                if ((int)distance - oldDistance > 30) // 이전값과 거리차가 30cm 이상이면 물건 지나감으로 인식
                {
                    flag = 0;
                    count++;
                    //db에 저장
                    IoT_Data_Model iot = new IoT_Data_Model();
                    iot.IoTModelId = 2023;
                    iot.Data = count;
                    iot.CreateTime = DateTime.Now;

                    baseDbContext.IoT_Data_Models.Add(iot);
                    baseDbContext.SaveChanges();

                    await Console.Out.WriteLineAsync("Count!!");

                    await Clients.All.SendAsync("moveservo", 3);

                    /*await Clients.Caller.SendAsync("moveServo", 3);*/
                }
                else
                {
                    await Console.Out.WriteLineAsync("지나가는 중");
                }
            }
            oldDistance = (int)distance;
            //await Console.Out.WriteLineAsync("flag : " + Convert.ToString(flag));
        }
    }
}

