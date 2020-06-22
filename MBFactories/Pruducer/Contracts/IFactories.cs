using System;
using System.Collections.Generic;
using System.Text;

namespace MBFactories.Producer.Contracts
{
    public interface IFactories<T>
    {
        void  Publish(string queue_name, T data);
        void Publish(string queue_name, List<T> data);
        //void Publish(string queue_name, Dictionary<T,T> data);

    }
}
