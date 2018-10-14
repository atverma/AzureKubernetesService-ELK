using System;
using StackExchange.Redis;

namespace AzureRedisCacheSample
{
    class Program
    {
        static string redisConnectionString = "YOUR_STACKEXCHANGE.REDIS_CONNECTION_STRING";
        static string channel = "messages";

        static void Main(string[] args)
        {
            Console.WriteLine("Starting Redis Publisher!");

            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(redisConnectionString);
            ISubscriber sub = redis.GetSubscriber();

            sub.Subscribe(channel, (channelName, msg) =>
            {
                Console.WriteLine($"Local receiver: { (string)msg}");
            });

            string message = string.Empty;

            do
            {
                Console.WriteLine("Enter message to send to Channel.");
                message = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(message))
                {
                    Console.WriteLine("Stopping ...");
                    break;
                }

                sub.Publish(channel, message);
            }
            while (!string.IsNullOrWhiteSpace(message));

            Console.WriteLine("Publisher stopped.");
        }
    }
}