using MBFactories.Consumer;
using MBFactories.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Receiver
{
    public class Receive
    {
        Factories _receive;
        public Receive()
        {
            _receive = new Factories("192.168.226.132", 5672, "admin", "password", "rabbitMqVirtualHost");
        }

        public void Consumer()
        {
            _receive.Consumer("FBNK");
        }

    }
}
