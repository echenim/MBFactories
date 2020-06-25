using MBFactories.Domain;
using MBFactories.utiles;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace MBFactories.PublisherAndSubscribers
{
    public class PubSub
    {
        private ConnectionFactory _conn;
        public PubSub(string _hostname, int _port, string _username, string _password, string _virtualhost)
        {
            _conn = new ConnectionFactory
            {
                HostName = _hostname,
                Port = _port,
                UserName = _username,
                Password = _password,
                VirtualHost = _virtualhost,
                RequestedHeartbeat = new TimeSpan(60)
            };
        }


        public void Pub(string exchange_name, Transactions data)
        {
            using (var conn = _conn.CreateConnection())
            {
                using (var channel = conn.CreateModel())
                {
                    channel.ExchangeDeclare(exchange: exchange_name, type: ExchangeType.Fanout);


                    //var properties = channel.CreateBasicProperties();
                    //properties.Persistent = true;
                    var message = data;
                    var body = Extensionz.ToByteArray(data);
                    channel.BasicPublish(exchange: exchange_name,
                                         routingKey: "",
                                         basicProperties: null,
                                         body: body);
                }
            }
        }

        public void Sub(string exchange_name)
        {
            using (var conn = _conn.CreateConnection())
            {
                using (var channel = conn.CreateModel())
                {
                    channel.ExchangeDeclare(exchange: exchange_name, type: ExchangeType.Fanout);

                    var queue_name = channel.QueueDeclare().QueueName;

                    channel.QueueBind(queue: queue_name,
                                      exchange: exchange_name,
                                       routingKey: "");

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body.ToArray();
                        var message = Extensionz.ToObject(body);
                       // channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                        Console.WriteLine($"{message.Id} | {message.AccountIdentifier} | {message.AccountNumber} | {message.Amount} | {message.TransactionFee} | {message.TransactionDate}");
                    };
                    channel.BasicConsume(queue: queue_name,
                                         autoAck: true,
                                         consumer: consumer);

                    Console.WriteLine(" Press [enter] to exit.");
                    Console.ReadLine();
                }
            }
        }



    }
}
