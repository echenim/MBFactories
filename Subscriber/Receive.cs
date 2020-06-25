using MBFactories.Consumer;
using MBFactories.Domain;
using MBFactories.PublisherAndSubscribers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Subscriber
{
    public class Receive
    {
        PubSub _receive;
        public Receive()
        {
            _receive = new PubSub("192.168.1.91", 5672, "admin", "password", "rabbitMqVirtualHost");
        }

        public void Consumer()
        {
            _receive.Sub("FBNKEXCH");
        }

    }
}
