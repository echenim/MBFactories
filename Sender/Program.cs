using System;
using System.Text;
using MBFactories;
using MBFactories.Contracts;
using MBFactories;
using RabbitMQ.Client;


namespace Sender
{
    class Program
    {

        IFactories _send = new Factories("192.168.226.132", 5672, "admin", "password", "rabbitMqVirtualHost");
        static void Main(string[] args)
        {
            var send = new Senders();
            send.Publish();
            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}
