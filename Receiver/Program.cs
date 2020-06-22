using System;
using System.Linq;
using System.Reflection;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using MBFactories.utiles;
using MBFactories.Domain;

namespace Receiver
{
    class Program
    {
        static void Main(string[] args)
        {
            new Receive().Consumer();
        }
    }
}
