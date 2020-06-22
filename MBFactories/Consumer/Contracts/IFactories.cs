using System;
using System.Collections.Generic;
using System.Text;

namespace MBFactories.Consumer.Contracts
{
    public interface IFactories<T>
    {
        void  Consumer(string queue_name);
    }
}
