using System;
using System.Collections.Generic;
using System.Text;

namespace MBFactories.Domain
{

    [Serializable]
    public class Transactions
    {
        public string Id { get; set; }
        public string AccountIdentifier { get; set; }
        public string AccountNumber { get; set; }
        public decimal Amount { get; set; }
        public decimal TransactionFee { get; set; }
        public DateTime TransactionDate { get; set; }

    }
}
