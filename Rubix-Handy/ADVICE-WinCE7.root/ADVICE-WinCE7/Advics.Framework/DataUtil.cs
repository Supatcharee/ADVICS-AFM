using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Advics.Framework
{
    public class DataUtil
    {
        public static string Encrypt(string password)
        {
            System.Security.Cryptography.SHA1 enc = System.Security.Cryptography.SHA1.Create();
            byte[] hashVal = enc.ComputeHash(Encoding.UTF8.GetBytes(password));
            return System.Convert.ToBase64String(hashVal);
        }
    }
}
