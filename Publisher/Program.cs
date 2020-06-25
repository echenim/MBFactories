using MBFactories.PublisherAndSubscribers;
using System;
using System.Timers;

namespace Publisher
{
    class Program
    {
        private static Timer timer;
        // IFactories _send = new Factories("192.168.226.132", 5672, "admin", "password", "rabbitMqVirtualHost");
        static void Main(string[] args)
        {


            timer = new System.Timers.Timer();
            timer.Interval = 3000;

            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;

            Console.WriteLine("Press the Enter key to exit anytime... ");
            Console.ReadLine();


        }

        private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            var send = new Sender();
            send.Publish();
            
            Console.WriteLine("New Data Published: {0} \n", e.SignalTime);
        }
    }
}
