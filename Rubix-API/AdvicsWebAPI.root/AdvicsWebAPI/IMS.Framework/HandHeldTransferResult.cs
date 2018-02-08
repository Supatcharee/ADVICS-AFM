using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rubix.Framework
{
    public class HandHeldTransferResult<T>
    where T : System.Data.DataRow
    {
        public int CurrentRecord { get; set; }
        public int MaxRecord { get; set; }
        public string Message { get; set; }
        public T Result { get; set; }
    }
}
