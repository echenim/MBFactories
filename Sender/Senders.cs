using MBFactories.Domain;
using MBFactories.Producer;
using MBFactories.Producer.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sender
{
   public class Senders
    {
      
        Factories _send;
        public Senders()
        {
            _send = new Factories("192.168.1.91", 5672, "admin", "password", "rabbitMqVirtualHost");
        }

        public void Publish()
        {
           var _data = new Transactions
            {
               Id = Guid.NewGuid().ToString().Replace("-","").ToUpper(),
               AccountNumber = $"{00}{20* new Random(12).Next(100000, 999999)}",
               AccountIdentifier = $"FBN{4* new Random(34).Next(1000, 9999)}",
               Amount = (decimal)(14.45* new Random(34).Next(1000,9999)),
               TransactionFee = (decimal)2.4500,
               TransactionDate = DateTime.Now,

            };           
            _send.Publish("FBNK", _data);
        }

    }
}
