using System;
using System.Collections.Generic;
using System.Text;

namespace MBFactories.Contracts
{
    public interface IFactories
    {
       void  Publish(string queue_name, string data);
        string Consum(string queue_name);
    }
}
