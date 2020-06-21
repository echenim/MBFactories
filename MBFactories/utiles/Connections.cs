using MBFactories.utiles.Contracts;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace MBFactories.utiles
{
    internal class Connections:IConnections
    {
        private string _host_name;
        private int _port;
        private string _user_name;
        private string _password;
        private string _virtual_host;

        public Connections(string hostname, int port, string username, string password, string virtualhost)
        {
            _host_name = hostname;
            _port = port;
            _user_name = username;
            _password = password;
            _virtual_host = virtualhost;

        }

        public ConnectionFactory OpenConnection(string hostname, int port, string username, string password, string virtualhost)
        {
            return new ConnectionFactory
            {
                HostName = _host_name,
                Port = _port,
                UserName = _user_name,
                Password = _password,
                VirtualHost = _virtual_host,
                RequestedHeartbeat = new TimeSpan(60)
            };
        }
    }
}
