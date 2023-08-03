using Microsoft.AspNetCore.Mvc;
using MQTTnet.Client;
using MQTTnet;
using MQTTnet.Client.Options;

namespace BaseProject.Controllers
{
    public class MqttController : Controller
    {
        public async Task<IActionResult> Cmd()
        {
            return View();

        }
        public async Task<IActionResult> Main(string cmd)
        {
            MqttFactory mqttFactory = new MqttFactory();
            IMqttClient client = mqttFactory.CreateMqttClient();
            IMqttClientOptions options = new MqttClientOptionsBuilder()
                                        .WithTcpServer("10.10.10.104", 1883)
                                        .WithCleanSession()
                                        .Build();

            client.UseConnectedHandler(async e => {
                Console.WriteLine("연결 성공!");
            });

            client.UseDisconnectedHandler(e => {
                Console.WriteLine("연결 해제 성공!");
            });

            await client.ConnectAsync(options);
            await PublishMessage(client, cmd);
            await client.DisconnectAsync();
            return Redirect("/mqtt/cmd");
        }

        static async Task PublishMessage(IMqttClient client, string cmd)
        {


            MqttApplicationMessage applicationMessage = new MqttApplicationMessageBuilder()
                                                            .WithTopic("abcd") // 전송할 토픽
                                                            .WithPayload(cmd)  // 전송할 메시지
                                                            .WithAtLeastOnceQoS()
                                                            .Build();
            if (client.IsConnected)
            {
                await client.PublishAsync(applicationMessage);
            }

        }
    }
}
