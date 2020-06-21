using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace MBFactories.utiles.Contracts
{
    internal interface IConnections
    {
      ConnectionFactory  OpenConnection(string hostname, int port, string username, string password, string virtualhost);
    }
}
