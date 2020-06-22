using MBFactories.utiles.Contracts;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace MBFactories.utiles
{
    internal class Connections
    {
        //private string _host_name;
        //private int _port;
        //private string _user_name;
        //private string _password;
        //private string _virtual_host;

        //public Connections()
        //{

        //}
        //public Connections(string hostname, int port, string username, string password, string virtualhost)
        //{
        //    _host_name = hostname;
        //    _port = port;
        //    _user_name = username;
        //    _password = password;
        //    _virtual_host = virtualhost;

        //}

        //public ConnectionFactory OpenConnection()
        //{
        //    return new ConnectionFactory
        //    {
        //        HostName = _host_name,
        //        Port = _port,
        //        UserName = _user_name,
        //        Password = _password,
        //        VirtualHost = _virtual_host,
        //        RequestedHeartbeat = new TimeSpan(60)
        //    };
        //}

        public ConnectionFactory OpenConnection(string _hostname, int _port, string _username, string _password, string _virtualhost)
        {
            return new ConnectionFactory
            {
                HostName = _hostname,
                Port = _port,
                UserName = _username,
                Password = _password,
                VirtualHost = _virtualhost,
                RequestedHeartbeat = new TimeSpan(60)
            };
        }
    }
}
