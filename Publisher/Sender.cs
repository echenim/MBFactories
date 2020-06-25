using MBFactories.Domain;
using MBFactories.PublisherAndSubscribers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Publisher
{
    public class Sender
    {
        PubSub _send;
        public Sender()
        {
            _send = new PubSub("192.168.1.91", 5672, "admin", "password", "rabbitMqVirtualHost");
        }

        public void Publish()
        {
            var _data = new Transactions
            {
                Id = Guid.NewGuid().ToString().Replace("-", "").ToUpper(),
                AccountNumber = $"{00}{20 * new Random(DateTime.Now.Second * DateTime.Now.AddMilliseconds(3).Millisecond).Next(100000, 999999)}",
                AccountIdentifier = $"STB{4 * new Random(DateTime.Now.Second * DateTime.Now.AddMilliseconds(13).Millisecond).Next(1000, 9999)}",
                Amount = (decimal)(14.45 * new Random(DateTime.Now.Second * DateTime.Now.AddMilliseconds(8).Millisecond).Next(1000, 9999)),
                TransactionFee = (decimal)2.4500,
                TransactionDate = DateTime.Now,

            };
          
             _send.Pub("FBNKEXCH", _data);
        }

    }
}
