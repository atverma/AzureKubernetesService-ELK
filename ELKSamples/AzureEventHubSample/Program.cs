using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.EventHubs;
using Newtonsoft.Json;

namespace EventHubSample
{
    class Program
    {
        // Update connection string : "AZURE_EVENT_HUB_CONNECTION_STRING;EntityPath=EventHubName"
        static string connectionString = "Endpoint={AZURE_EVENT_HUB_CONNECTION_STRING};EntityPath=logstash";
        static bool isRunning;

        static void Main(string[] args)
        {
            Console.WriteLine("Starting sending messages to Azure event hub");
            isRunning = true;
            SendingRandomMessages();
            Console.ReadLine();
            isRunning = false;
            Console.WriteLine("Stopping sending messages. Press any key to exit!");
            Console.ReadLine();
        }

        async static Task SendingRandomMessages()
        {
            var eventHubClient = EventHubClient.CreateFromConnectionString(connectionString);
            Random random = new Random(1);

            while (isRunning)
            {
                try
                {
                    var message = JsonConvert.SerializeObject(new SampleData() { ID = random.Next(), Name = $"Sample Name {random.Next()}" });
                    Console.WriteLine("{0} > Sending message: {1}", DateTime.Now, message);
                    await eventHubClient.SendAsync(new EventData(Encoding.UTF8.GetBytes(message)));
                }
                catch (Exception exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("{0} > Exception: {1}", DateTime.Now, exception.Message);
                    Console.ResetColor();
                }

                Thread.Sleep(500);
            }
        }
    }
}

public class SampleData
{
    public int ID { get; set; }
    public string Name { get; set; }
}
