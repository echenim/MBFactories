using System;
using System.Text;
using MBFactories.Contracts;
using MBFactories.utiles;
using MBFactories.utiles.Contracts;
using RabbitMQ.Client;


namespace MBFactories
{
    public class Factories:IFactories
    {
        private ConnectionFactory _conn;

        public Factories()
        {
        }

        public Factories(string _hostname, int _port, string _username, string _password, string _virtualhost)
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

        public string Consum(string queue_name)
        {
            throw new NotImplementedException();
        }

        public void Publish(string queue_name, string data)
        {
            using(var conn = _conn.CreateConnection())
            {
                using(var channel = conn.CreateModel())
                {
                    channel.QueueDeclare(queue: queue_name,
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);
                    var message = data;
                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish(exchange: "",
                                         routingKey: queue_name,
                                         basicProperties: null,
                                         body: body);
                }
            }
        }
    }
}
