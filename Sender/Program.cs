using System;
using System.Text;
using RabbitMQ.Client;


namespace Sender
{
    class Program
    {
        static void Main(string[] args)
        {
            const string queue_name = "Hello";
            var factory = new ConnectionFactory { 
                HostName = "192.168.226.132",
                Port= 5672,
                UserName = "admin",
                Password ="password",
                VirtualHost = "rabbitMqVirtualHost",
                RequestedHeartbeat = new TimeSpan(60)
            };
           
            using (var connection = factory.CreateConnection())
            {
                using(var channel = connection.CreateModel())
                {

                    channel.QueueDeclare(queue: queue_name,
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);
                    var message = "Hello Admin";
                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish(exchange: "",
                                         routingKey:queue_name,
                                         basicProperties: null,
                                         body:body);


                }
            }
           
            Console.ReadLine();
        }
    }
}
