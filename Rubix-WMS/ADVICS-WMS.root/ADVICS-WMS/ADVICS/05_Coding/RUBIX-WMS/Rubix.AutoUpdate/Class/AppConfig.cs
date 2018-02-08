using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Windows.Forms;
using System.IO;
using System.Configuration;

namespace Rubix.AutoUpdate
{
    public class AppConfig
    {
        #region Private member
        private static IniConfiguration m_ini = null;
        private static string _userID = string.Empty;
        private static string _password = string.Empty;
        private static string _token = string.Empty;
        private static string _RubixWebAPI = string.Empty;

        private static string _DatabaseServerName = string.Empty;
        private static string _DatabaseName = string.Empty;
        private static string _DatabaseUserName = string.Empty;
        private static string _DatabasePassword = string.Empty;
        #endregion

        #region Properties
        private AppConfig() { }
        private static IniConfiguration Instance
        {
            get
            {
                if (m_ini == null)
                {
                    m_ini = new IniConfiguration(AppConfig.ConfigFileName);
                }
                return m_ini;
            }
        }
        private static string ConfigFileName
        {
            get
            {
                return AppDomain.CurrentDomain.BaseDirectory + "config.ini";
            }
        } 
        #endregion

        #region ConfigName
        private class ConfigName
        {
            public class Application
            {
                public const string SECTION = "Application";
                public const string PROGRAM_VERSION = "PROGRAM_VERSION";
                public const string RUBIX_AUTO_UPDATE_URL = "AUTO_UPDATE_URL";
            }
        }
        #endregion
        
        #region Get Set Data
        public static string ProgramVersion
        {
            get
            {
                return Instance.GetValue(ConfigName.Application.SECTION, ConfigName.Application.PROGRAM_VERSION); ;
            }
            set
            {
                Instance.SetValue(ConfigName.Application.SECTION, ConfigName.Application.PROGRAM_VERSION, value);
            }
        }

        public static string RubixAutoUpdateURL
        {
            get
            {
                return Instance.GetValue(ConfigName.Application.SECTION, ConfigName.Application.RUBIX_AUTO_UPDATE_URL);
            }
        }
        #endregion

        public static void AddNewConfig(string ConfigParamName, object ConfigParamvalue)
        {
            Instance.SetValue(ConfigName.Application.SECTION, ConfigParamName, ConfigParamvalue);
        }
    }

    public class IniConfiguration
    {
        #region Win32 API method
        [DllImport("kernel32")]
        static extern int WritePrivateProfileString(string section, string key, string value, string fileName);
        [DllImport("kernel32")]
        static extern int WritePrivateProfileString(string section, string key, int value, string fileName);
        [DllImport("kernel32")]
        static extern int WritePrivateProfileString(string section, int key, string value, string fileName);
        [DllImport("kernel32")]
        static extern int GetPrivateProfileString(string section, string key, string defaultValue, StringBuilder result, int size, string fileName);
        [DllImport("kernel32")]
        static extern int GetPrivateProfileString(string section, int key, string defaultValue, [MarshalAs(UnmanagedType.LPArray)] byte[] result, int size, string fileName);
        [DllImport("kernel32")]
        static extern int GetPrivateProfileString(int section, string key, string defaultValue, [MarshalAs(UnmanagedType.LPArray)] byte[] result, int size, string fileName);
        #endregion

        #region Member Declaration
        private string m_strIniFileName = string.Empty;
        #endregion

        public IniConfiguration(string strIniFileName)
        {
            m_strIniFileName = strIniFileName;
        }

        public void SetValue(string strSection, string strEntry, object value)
        {
            if (value == null)
                return;
            WritePrivateProfileString(strSection, strEntry, value.ToString(), m_strIniFileName);
        }

        public string GetValue(string strSection, string strEntry)
        {
            object oValue = GetValueObject(strSection, strEntry);
            if (oValue == null)
            {
                return string.Empty;
            }
            else
            {
                return oValue.ToString();
            }
        }

        public object GetValueObject(string strSection, string strEntry)
        {
            int iMaxSize = 250;
            while (true)
            {
                StringBuilder result = new StringBuilder(iMaxSize);
                iMaxSize *= 2;
                int iReturnedSize = GetPrivateProfileString(strSection, strEntry, string.Empty, result, iMaxSize, m_strIniFileName);
                if (iReturnedSize < iMaxSize - 1)
                {
                    if (iReturnedSize <= 0)
                        return null;
                    return result.ToString();
                }
            }
        }

        public void RemoveEntry(string strSection, string strEntry)
        {
            WritePrivateProfileString(strSection, strEntry, 0, m_strIniFileName);
        }

        public void RemoveSection(string strSection)
        {
            WritePrivateProfileString(strSection, 0, string.Empty, m_strIniFileName);
        }

        public string[] GetEntryNames(string strSection)
        {
            for (int maxSize = 500; true; maxSize *= 2)
            {
                byte[] bytes = new byte[maxSize];
                int size = GetPrivateProfileString(strSection, 0, string.Empty, bytes, maxSize, m_strIniFileName);

                if (size < maxSize - 2)
                {
                    // Convert the buffer to a string and split it
                    string entries = Encoding.ASCII.GetString(bytes, 0, size - (size > 0 ? 1 : 0));
                    if (entries == "")
                        return new string[0];
                    return entries.Split(new char[] { '\0' });
                }
            }
        }

        public string[] GetSectionNames()
        {
            for (int maxSize = 500; true; maxSize *= 2)
            {
                byte[] bytes = new byte[maxSize];
                int size = GetPrivateProfileString(0, "", "", bytes, maxSize, m_strIniFileName);

                if (size < maxSize - 2)
                {
                    // Convert the buffer to a string and split it
                    string sections = Encoding.ASCII.GetString(bytes, 0, size - (size > 0 ? 1 : 0));
                    if (sections == "")
                        return new string[0];
                    return sections.Split(new char[] { '\0' });
                }
            }
        }
    }
}
