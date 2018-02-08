using System;
using System.Collections.Generic;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing;
using System.Security.Cryptography;
using System.Data;
using System.Globalization;

namespace Rubix.Framework
{
    public class DataUtil
    {
        private static NumberFormatInfo m_numInfo = null;
        private static TripleDES alg;
        private static byte[] key;
        static DataUtil()
        {
            key = new byte[] { 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48 };
            alg = TripleDES.Create();
            alg.Key = key;
            alg.Mode = CipherMode.ECB;
        }
        public static Nullable<T> Convert<T>(object input) 
            where T : struct 
        { 
            if (input == null)
                return null;
            if (input is Nullable<T> || input is T)
                return (Nullable<T>)input;
            else
            {
                try
                {
                    Type typeParameterType = typeof(T);
                    if (typeParameterType == typeof(int))
                    {
                        int result;
                        if (!int.TryParse(input.ToString(), out result))
                            return null;
                    }
                    else if (typeParameterType == typeof(decimal))
                    {
                        decimal result;
                        if (!decimal.TryParse(input.ToString(), out result))
                            return null;
                    }
                    T test = (T)System.Convert.ChangeType(input, typeParameterType);
                    return new Nullable<T>(test);
                }
                catch
                {
                }
            }
            return null;
        }

        public  static DateTime CombineDateAndTime(DateTime date, DateTime time) 
        {
            DateTime combinedDatetime = date.Date;
            return combinedDatetime.Add(time.TimeOfDay);
        }

        public static List<T> CloneListOfComplexType<T>(List<T> list)
            where T : System.Data.Objects.DataClasses.ComplexObject
        {
            if (list == null)
                return null;
            List<T> newList = new List<T>();
            foreach (T data in list)
            {
                T newData = Clone<T>(data);
                newList.Add(newData);
            }
            return newList;
        }

        public static T Clone<T>(T source)
        {
            if (!typeof(T).IsSerializable)
            {
                throw new ArgumentException("The type must be serializable.", "source");
            }
            // Don't serialize a null object, simply return the default for that object
            if (Object.ReferenceEquals(source, null))
            {
                return default(T);
            }
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            using (stream)
            {
                formatter.Serialize(stream, source);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }

        public static T CopyEntity<T>(T data) where T : EntityObject
        {
            if (data == null)
                return null;

            Type type = data.GetType();

            T result = (T)Activator.CreateInstance(type);
            Type typeResult = result.GetType();

            PropertyInfo[] propInfos = type.GetProperties(BindingFlags.Public | (BindingFlags.GetProperty & BindingFlags.SetProperty) | BindingFlags.Instance);
            foreach (PropertyInfo prop in propInfos)
            {
                // Show Data
                //txtProperties.AppendText(string.Format("{0} [{1}]", prop.Name, prop.PropertyType.Name));

                if ((prop.PropertyType.IsValueType
                    || prop.PropertyType.IsGenericTypeDefinition
                    || prop.PropertyType.FullName.Contains("System.String")
                    || prop.PropertyType.FullName.Contains("System.Byte[]")
                    )
                    && !prop.PropertyType.FullName.Contains("System.Data.EntityState"))
                {
                    object objValue = prop.GetValue(data, null);

                    typeResult.GetProperty(prop.Name).SetValue(result, objValue, null);
                }
            }

            return result;
        }

        public static T CopyEntity<T>(T from, T to) where T : EntityObject
        {
            if (from == null)
                return null;

            Type type = from.GetType();
            
            Type typeResult = to.GetType();

            PropertyInfo[] propInfos = type.GetProperties(BindingFlags.Public | (BindingFlags.GetProperty & BindingFlags.SetProperty) | BindingFlags.Instance);
            foreach (PropertyInfo prop in propInfos)
            {
                // Show Data
                //txtProperties.AppendText(string.Format("{0} [{1}]", prop.Name, prop.PropertyType.Name));

                if ((prop.PropertyType.IsValueType
                    || prop.PropertyType.IsGenericTypeDefinition
                    || prop.PropertyType.FullName.Contains("System.String")
                    || prop.PropertyType.FullName.Contains("System.Byte[]")
                    )
                    && !prop.PropertyType.FullName.Contains("System.Data.EntityState"))
                {
                    object objValue = prop.GetValue(from, null);

                    typeResult.GetProperty(prop.Name).SetValue(to, objValue, null);
                }
            }

            return to;
        }

        public static string ToHtmlColorCode(Color color)
        {
            return string.Format("{0}{1}{2}", color.R.ToString("X2"), color.G.ToString("X2"), color.B.ToString("X2"));
        }

        public static string Encrypt(string password)
        {
            System.Security.Cryptography.SHA1 enc = System.Security.Cryptography.SHA1.Create();
            byte[] hashVal = enc.ComputeHash(Encoding.UTF8.GetBytes(password));
            return System.Convert.ToBase64String(hashVal);
        }

        public static bool IsValidDecimal(string decimalString, int dbPrecision, int dbScale)
        {
            decimal result; 
            if (Decimal.TryParse(decimalString, out result))
            {
                uint[] bits = (uint[])(object)decimal.GetBits(result);


                decimal mantissa =
                    (bits[2] * 4294967296m * 4294967296m) +
                    (bits[1] * 4294967296m) +
                    bits[0];

                uint scale = (bits[3] >> 16) & 31;
                uint precision = 0;
                if (result != 0m)
                {
                    for (decimal tmp = mantissa; tmp >= 1; tmp /= 10)
                    {
                        precision++;
                    }
                }
                else
                {
                    precision = scale + 1;
                }

                uint trailingZeros = 0;
                for (decimal tmp = mantissa;
                     tmp % 10m == 0 && trailingZeros < scale;
                     tmp /= 10)
                {
                    trailingZeros++;
                }

                if (precision - trailingZeros - (scale - trailingZeros) + 3 <= dbPrecision && scale - trailingZeros <= dbScale)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public static bool IsTime(string timeString)
        {
            const int HOUR = 0;
            const int MINUTE = 0;
            string [] timePart = timeString.Split(':');
            int result;
            if (Int32.TryParse(timePart[HOUR], out result))
            {
                if (result < 0 || result > 23)
                    return false;
            }
            else
                return false;
            if (Int32.TryParse(timePart[MINUTE], out result))
            {
                if (result < 0 || result > 59)
                    return false;
            }
            else
                return false;

            return true;
        }
        
        public static string SymmetricDecrypt(string input)
        {
            byte[] clearData;
            string result;
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, alg.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(System.Convert.FromBase64String(input), 0, System.Convert.FromBase64String(input).Length);
                    cs.FlushFinalBlock();
                    clearData = ms.ToArray();
                    ms.Close();
                    cs.Close();
                    result = System.Text.Encoding.UTF8.GetString(clearData);
                }
            }
            return result;
        }

        public static string SymmetricEncrypt(string input)
        {
            byte[] clearData = System.Text.Encoding.UTF8.GetBytes(input);
            string result;
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, alg.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(clearData, 0, clearData.Length);
                    cs.FlushFinalBlock();
                    byte[] CipherBytes = ms.ToArray();
                    ms.Close();
                    cs.Close();
                    result = System.Convert.ToBase64String(CipherBytes);
                }
            }
            return result;
        }

        public static string MD5Encrypt(string input)
        {
            try
            {
                byte[] data = null;
                using (MD5 enc = System.Security.Cryptography.MD5.Create())
                {
                    data = enc.ComputeHash(Encoding.UTF8.GetBytes(input));
                }


                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sb.AppendFormat("{0:X2}", data[i]);
                }
                return sb.ToString();
            }
            catch
            {
                throw;
            }
        }

        public static decimal ConvertTextToDecimal(string data)
        {
            //int len = GetStringLength(data.Trim());
            decimal dec;
            if (!decimal.TryParse(data, NumberStyles.Currency | NumberStyles.AllowTrailingSign, m_numInfo, out dec))
                return 0;
            else
                return dec;
        }

        #region CommonFunction
        public static bool IsNull(object data)
        {
            if (data == null || data == DBNull.Value)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string IsNull(DataRow dr, int col, string value)
        {
            if (dr.IsNull(col) || dr.HasErrors)
                return value;
            else
                return dr[col].ToString();

        }

        public static object IsNull(object data, object value)
        {
            if (IsNull(data))
                return value;
            else
                return data;
        }
        
        public static bool IsNullOrEmpty(object obj)
        {
            if (IsNull(obj) || obj.ToString().Trim().Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsNullOrEmptyOrNeg(object obj)
        {
            if (IsNullOrEmpty(obj))
            {
                return true;
            }
            if (ConvertTextToDecimal(obj.ToString()) < 0)
            {
                return true;
            }
            return false;
        }

        public static bool IsNullOrEmptyOrZero(object obj)
        {
            if (IsNullOrEmpty(obj))
            {
                return true;
            }
            if (ConvertTextToDecimal(obj.ToString()) == 0)
            {
                return true;
            }
            return false;
        }

        public static bool IsNullOrEmptyOrZeroOrNeg(object obj)
        {
            if (IsNullOrEmpty(obj))
            {
                return true;
            }
            if (ConvertTextToDecimal(obj.ToString()) <= 0)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region Convert DataType
        public static int? ToInt(object value)
        {
            if (IsNullOrEmpty(value))
            {
                return null;
            }
            else
            {
                return System.Convert.ToInt32(value);
            }
        }

        public static DateTime? ToDateTime(object value)
        {
            if (IsNullOrEmpty(value))
            {
                return null;
            }
            else
            {
                return System.Convert.ToDateTime(value);
            }
        }
        public static string ToString(object value)
        {
            if (IsNullOrEmpty(value))
            {
                return string.Empty;
            }
            else
            {
                return value.ToString();
            }
        }
        #endregion

    }
}
