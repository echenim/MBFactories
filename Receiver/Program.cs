using System;
using System.Linq;
using System.Reflection;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Receiver
{
    class Program
    {
        static void Main(string[] args)
        {
            const string queue_name = "Hello";
            var factory = new ConnectionFactory
            {
                HostName = "192.168.226.132",
                Port = 5672,
                UserName = "admin",
                Password = "password",
                VirtualHost = "rabbitMqVirtualHost",
                RequestedHeartbeat = new TimeSpan(60)
            };

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: queue_name,
                                        durable: false,
                                        exclusive: false,
                                        autoDelete: false,
                                        arguments: null);

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                      {
                          var body = ea.Body.ToArray();
                          var message = Encoding.UTF8.GetString(body.ToArray());
                          Console.WriteLine(" [x] Received {0}", message);
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
