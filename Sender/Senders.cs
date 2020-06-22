using MBFactories;
using MBFactories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sender
{
   public class Senders
    {
        IFactories _send;
        public Senders()
        {
            _send = new Factories("192.168.226.132", 5672, "admin", "password", "rabbitMqVirtualHost");
        }

        public void Publish()
        {
            _send.Publish("Kilo", "Much I do About nothing");
        }
    }
}
