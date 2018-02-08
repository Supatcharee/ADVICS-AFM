using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Newtonsoft.Json;
using System.Data;
using Microsoft.Win32;
using System.Management;
using System.IO;
using System.Security.Cryptography;

namespace Rubix.AutoUpdate
{
    public class AutoUpdateBiz
    {
        public DataSet LoadUpdateData(string ProgramVersion)
        {
            string SerialNo;
            string MainBoardNo;

            GetDataMD5FromRegistry(out SerialNo, out MainBoardNo);
            
            Hashtable hs = new Hashtable();
            hs.Add("Serial", SerialNo);
            hs.Add("CurrentVersion", ProgramVersion);

            try
            {
                string strResult = RubixWebAPI.ExecuteAutoUpdateObjectResult("AutoUpdate/LoadUpdateData", hs);
                return JsonConvert.DeserializeObject<DataSet>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool GetDataMD5FromRegistry(out string Serial, out string MainboardSerial)
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

        private string GetMainboardSerialNumber()
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

        private string ReadRegisterSerialNumber()
        {
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

        private string SymmetricDecrypt(string keyHash, string input)
        {
            byte[] clearData;
            string result;
            using (MemoryStream ms = new MemoryStream())
            {
                using (TripleDES tripleDES = TripleDES.Create())
                {
                    tripleDES.Key = Encoding.ASCII.GetBytes(keyHash.PadRight(24, ' ').Substring(0, 24));
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
        
    }
}
