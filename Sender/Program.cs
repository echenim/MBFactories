using System;
using System.Text;
using MBFactories;
using MBFactories.Producer.Contracts;
using MBFactories.Producer;
using RabbitMQ.Client;
using System.Timers;

namespace Sender
{
    class Program
    {
        private static Timer timer;
       // IFactories _send = new Factories("192.168.226.132", 5672, "admin", "password", "rabbitMqVirtualHost");
        static void Main(string[] args)
        {
            

            timer = new System.Timers.Timer();
            timer.Interval = 20000;

            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;

            Console.WriteLine("Press the Enter key to exit anytime... ");
            Console.ReadLine();


        }

        private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            var send = new Senders();
            send.Publish();
            Console.WriteLine("New Data Published: {0}", e.SignalTime);
        }
    }
}
