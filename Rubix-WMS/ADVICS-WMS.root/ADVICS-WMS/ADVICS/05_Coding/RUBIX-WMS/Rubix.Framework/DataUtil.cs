using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing;
using System.Security.Cryptography;
using Microsoft.Win32;
using System.Management;

namespace Rubix.Framework
{
    public class DataUtil
    {
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

        public static bool IsDate(string DateString)
        {
            bool isdate = true;
            try
            {
                string[] arrDate = DateString.Split('/');
                DateTime dt = DateTime.Parse(string.Format("{2}/{1}/{0}", arrDate[0], arrDate[1], arrDate[2]));
            }
            catch (Exception ex)
            {
                isdate = false;
            }

            return isdate;
        }

        public static DateTime ConvertToDate(string DateString)
        {
            try
            {
                string[] arrDate = DateString.Split('/');
                return DateTime.Parse(string.Format("{2}/{1}/{0}", arrDate[0], arrDate[1], arrDate[2]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        #region Symmetric Cryptography (Triple DES)

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
                    result = Encoding.UTF8.GetString(clearData);
                }
            }
            return result;
        }

        public static string SymmetricEncrypt(string input)
        {
            byte[] clearData = Encoding.UTF8.GetBytes(input);
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


        /// <summary>
        /// เข้ารหัสด้วย TripleDES
        /// </summary>
        /// <param name="keyHash">Key ที่ใช้เข้ารหัส</param>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string SymmetricEncrypt(string keyHash, string input)
        {
            byte[] byteInput = Encoding.ASCII.GetBytes(input);
            string result;
            using (MemoryStream ms = new MemoryStream())
            {
                using (TripleDES tripleDES = TripleDES.Create())
                {
                    tripleDES.Key = Encoding.ASCII.GetBytes((keyHash + "!@#$%^&*()_+|").PadRight(24, '฿').Substring(0, 24));
                    tripleDES.Mode = CipherMode.ECB;

                    using (CryptoStream cs = new CryptoStream(ms, tripleDES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(byteInput, 0, byteInput.Length);
                        cs.FlushFinalBlock();

                        byte[] CipherBytes = ms.ToArray();
                        ms.Close();
                        cs.Close();
                        result = System.Convert.ToBase64String(CipherBytes);
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// ถอดรหัสด้วย TripleDEC
        /// </summary>
        /// <param name="keyHash">Key ที่ใช้ถอดรหัส</param>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string SymmetricDecrypt(string keyHash, string input)
        {
            byte[] clearData;
            string result;
            using (MemoryStream ms = new MemoryStream())
            {
                using (TripleDES tripleDES = TripleDES.Create())
                {
                    tripleDES.Key = Encoding.ASCII.GetBytes((keyHash + "!@#$%^&*()_+|").PadRight(24, '฿').Substring(0, 24));
                    tripleDES.Mode = CipherMode.ECB;

                    using (CryptoStream cs = new CryptoStream(ms, tripleDES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        byte[] byteInput = System.Convert.FromBase64String(input);
                        cs.Write(byteInput, 0, byteInput.Length);
                        cs.FlushFinalBlock();
                        clearData = ms.ToArray();

                        ms.Close();
                        cs.Close();
                        result = Encoding.ASCII.GetString(clearData);
                    }
                }
            }
            return result;
        }        

        #endregion
        
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

        public static string GetMainboardSerialNumber()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from Win32_BaseBoard");
            foreach (ManagementObject share in searcher.Get())
            {
                if (share.Properties.Count > 0)
                {
                    foreach (PropertyData PC in share.Properties)
                    {
                        if (PC.Name.ToUpper() == "SERIALNUMBER")
                        {
                            if (PC.Value != null && PC.Value.ToString() != "")
                            {
                                return PC.Value.ToString();
                            }
                        }
                    }
                }
            }
            return string.Empty;
        }
        
        public static bool CheckValidRegisterSerialNumber()
        {
            try
            {
                string mainboard_ssid = GetMainboardSerialNumber();

                // อ่านข้อความจาก Registry ซึ่งจะเป็นข้อความที่เข้ารหัสด้วย TripleDES
                string CipherText = ReadRegisterSerialNumber();

                // แยกข้อมูลของ MainboardSerial และ Serial (ข้อความทั้งสองได้เข้ารหัสด้วย MD5 ไว้แล้ว)
                string[] arrPlainText = SymmetricDecrypt(mainboard_ssid, CipherText).Split('|');

                // Compare between data in Registry and MainboardSerial
                if (arrPlainText[0] == DataUtil.MD5Encrypt(mainboard_ssid))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        #region Registry : Serial

        public static void WriteRegisterSerialNumber(string Value)
        {
            RegistryKey r = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft", true);
            //string strRegistryKey = (string)r.GetValue("SER_V");
            //if (strRegistryKey == null)
            {
                /* Write information into registry contains data following:
                 * 
                 * 
                 * +---------------------------+--------------+
                 * |   Mainboard Serial (MD5)  | Serial (MD5) |
                 * +---------------------------+--------------+
                 *   ||                               ||
                 *   \/                               \/
                 *  Encrypt all data with TripleDES by Key: Mainboard Serial
                 * 
                 */
                string mainboard_ssid = GetMainboardSerialNumber();

                string md5Mainboard = DataUtil.MD5Encrypt(mainboard_ssid);
                string md5Company = DataUtil.MD5Encrypt(Value);

                string regText = string.Format("{0}|{1}", md5Mainboard, md5Company);
                r.SetValue("SER_V", SymmetricEncrypt(mainboard_ssid, regText));
            }
        }

        /// <summary>
        /// อ่านข้อความ SerialNumber จาก Registry ซึ่งจะเป็นข้อความที่เข้ารหัส TripleDES ไว้อยู่
        /// </summary>
        /// <returns></returns>
        public static string ReadRegisterSerialNumber()
        {
            //HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Microsoft
            RegistryKey r = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft", true);
            string strRegistryKey = (string)r.GetValue("SER_V");

            if (strRegistryKey != null)
            {
                return strRegistryKey;
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// ดึงข้อมูล Serial และ MainboardSerial จากที่เก็บใน Registry
        /// </summary>
        /// <param name="Serial">ข้อมูล MD5</param>
        /// <param name="MainboardSerial">ข้อมูล MD5</param>
        /// <returns>หากอ่านข้อมูลได้สมบูรณ์จะคืนค่า True, แต่ถ้าไม่ใช่จะคืนค่า False</returns>
        public static bool GetDataMD5FromRegistry(out string Serial, out string MainboardSerial)
        {
            Serial = null;
            MainboardSerial = null;

            try
            {                
                string mainboard_ssid = GetMainboardSerialNumber();
                string strRegSerialNumber = ReadRegisterSerialNumber();

                if (string.IsNullOrEmpty(strRegSerialNumber))
                    return false;

                // แยกข้อมูลของ MainboardSerial และ Serial (ข้อความทั้งสองได้เข้ารหัสด้วย MD5 ไว้แล้ว)
                string[] arrData = SymmetricDecrypt(mainboard_ssid, strRegSerialNumber).Split('|');

                MainboardSerial = arrData[0];
                Serial = arrData[1];
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

       
        #endregion

    }
}
