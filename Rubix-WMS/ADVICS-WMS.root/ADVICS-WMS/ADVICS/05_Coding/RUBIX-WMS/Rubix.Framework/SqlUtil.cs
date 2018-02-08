using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace Rubix.Framework
{
    public class SqlUtil
    {
        public static TransactionOptions GetTransactionOptions()
        {
            TransactionOptions op = new TransactionOptions();
            op.Timeout = new TimeSpan(0, 30, 0);
            return op;
        }
    }
}
