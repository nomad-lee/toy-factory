using BaseProject.Data;
using BaseProject.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace BaseProject.Hubs
{
    public class AiHub : Hub
    {
        private readonly BaseDbContext _dbContext;
        static int currentx = 0;
        public static int globalKind;

        public AiHub(BaseDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SendMessage1(string message)
        {
            /*await Console.Out.WriteLineAsync(message);*/
            await Clients.All.SendAsync("ReceiveAiMessage", message);
        }
        public async Task SendAi(int kind, int x, int score)
        {
            Console.Out.WriteLine("kind : " + Convert.ToString(kind) + "x : " + Convert.ToString(x) + "score : " + Convert.ToString(score));
            if (x > 0)
            {
                if (x < currentx - 10)
                {
                    if (kind == 2)
                    {
                        Console.WriteLine("표창 증가");
                        await Console.Out.WriteLineAsync("kind : " + Convert.ToString(kind) + "x : " + Convert.ToString(x) + "score : " + Convert.ToString(score));
                        var result = _dbContext.Product_Models.Where(p => p.Name == "NinjaStar").FirstOrDefault();
                        if (score > 80)
                        {
                            globalKind = kind;
                        }
                        else
                        {
                        }
                        currentx = x;
                    }
                    else if (kind == 3)
                    {
                        Console.WriteLine("부메랑 증가");
                        var result = _dbContext.Product_Models.Where(p => p.Name == "Boomerang").FirstOrDefault();
                        if (score > 80)
                        {
                            globalKind = kind;
                        }
                        else
                        {
                        }
                        currentx = x;
                    }
                }
                else
                {
                    currentx = x;
                }
            }
        }

    }
}