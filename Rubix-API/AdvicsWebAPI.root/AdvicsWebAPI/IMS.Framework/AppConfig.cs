using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Windows.Forms;
using System.IO; 
namespace Rubix.Framework
{
    public class AppConfig
    {
        #region Private member
        private static IniConfiguration m_ini = null;

        private static string _userID = string.Empty;
        private static string _password = string.Empty;
        private static int? _warehouseID = 0;
        private static string _firstname = string.Empty;
        private static string _lastname = string.Empty;

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

        private static string _DatabaseName = string.Empty;
        private static string _DatabaseUserName = string.Empty;
        private static string _DatabasePassword = string.Empty;
        private static string _DatabaseServerName = string.Empty;
        #endregion

        #region ConfigName
        private class ConfigName
        {
            #region Application
            public class Application
            {
                public const string SECTION = "Application";
                public const string LOCALE = "Locale";
                public const string SCREEN_THEME_STYLE = "ScreenThemeStyle";
                public const string GRID_THEME_STYLE = "GridThemeStyle";
                public const string GRID_PAINT_STYLE = "GridPaintStyle";

                public const string USER_ID = "UserID";
                public const string PASSWORD = "Password";
                public const string CUSTOMER_ID = "CustomerID";
                public const string DISTRIBUTIONCENTER_ID = "DistributionCenterID";

                public const string REMEMBER_USER_ID = "RememberUser";
                public const string REMEMBER_PASSWORD = "RememberPassword";
            }
            #endregion
        }
        #endregion

        public static string IPAddress
        {
            get
            {
                System.Net.IPAddress ip = System.Net.Dns.GetHostAddresses(System.Net.Dns.GetHostName()).Where(c => c.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).FirstOrDefault();
                if (ip == null)
                    return string.Empty;
                else
                    return ip.ToString();
            }
        }
        #region Get Set Data
        public static string Locale
        {
            get
            {
                string strValue = Instance.GetValueString(ConfigName.Application.SECTION, ConfigName.Application.LOCALE);
                if (string.IsNullOrWhiteSpace(strValue)) 
                {
                    strValue = "en-Us";
                    AppConfig.Locale = strValue;
                }
                return strValue;
            }
            set
            {
                Instance.SetValue(ConfigName.Application.SECTION, ConfigName.Application.LOCALE, value);
            }
        }

        public static string ScreenThemeStyle
        {
            get
            {
                string strValue = Instance.GetValueString(ConfigName.Application.SECTION, ConfigName.Application.SCREEN_THEME_STYLE);
                return strValue;
            }
            set
            {
                Instance.SetValue(ConfigName.Application.SECTION, ConfigName.Application.SCREEN_THEME_STYLE, value);
            }
        }
        public static string GridThemeStyle
        {
            get
            {
                string strValue = Instance.GetValueString(ConfigName.Application.SECTION, ConfigName.Application.GRID_THEME_STYLE);
                return strValue;
            }
            set
            {
                Instance.SetValue(ConfigName.Application.SECTION, ConfigName.Application.GRID_THEME_STYLE, value);
            }
        }
        public static string GridPaintStyle
        {
            get
            {
                string strValue = Instance.GetValueString(ConfigName.Application.SECTION, ConfigName.Application.GRID_PAINT_STYLE);
                return strValue;
            }
            set
            {
                Instance.SetValue(ConfigName.Application.SECTION, ConfigName.Application.GRID_PAINT_STYLE, value);
            }
        }

        public static string ProgramVersion
        {
            get
            {
                Assembly asm = Assembly.LoadFrom(AppConfig.ExePath);
                string version = asm.GetName().Version.ToString();
                asm = null;
                return version;
            }
        }

        public static string ExePath
        {
            get
            {
                return Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "IMS.exe");
            }
        }

        public static string Fullname
        {
            get
            {
                return string.Format("{0} {1}", _firstname, _lastname);
            }
        }

        public static string Name
        {
            get
            {
                if (_lastname.Length > 0)
                {
                    return string.Format("{0} {1}.", _firstname, _lastname.Substring(0, 1));
                }
                else
                {
                    return _firstname;
                }
            }
        }

        public static string Firstname
        {
            get
            {
                return _firstname;
            }
            set
            {
                _firstname = value;
            }
        }

        public static string Lastname
        {
            get
            {
                return _lastname;
            }
            set
            {
                _lastname = value;
            }
        }

        public static string UserLogin
        {
            get
            {
                if(AppConfig.RememberUserLogin)
                    _userID = Instance.GetValueString(ConfigName.Application.SECTION, ConfigName.Application.USER_ID);
                return _userID;
            }
            set
            {
                if (AppConfig.RememberUserLogin)
                    Instance.SetValue(ConfigName.Application.SECTION, ConfigName.Application.USER_ID, value);
                else
                    _userID = value;
            }
        }
        public static string Password
        {
            get
            {
                if (AppConfig.RememberPassword)
                    _password = Instance.GetValueString(ConfigName.Application.SECTION, ConfigName.Application.PASSWORD);
                return _password;
            }
            set
            {
                if (AppConfig.RememberPassword)
                    Instance.SetValue(ConfigName.Application.SECTION, ConfigName.Application.PASSWORD, value);
                else
                    _password = value;
            }
        }

        public static int? WarehouseID
        {
            get
            {
                return _warehouseID;
            }
            set
            {
                _warehouseID = value;
            }
        }

        public static bool RememberUserLogin
        {
            get
            {
                string strValue = Instance.GetValueString(ConfigName.Application.SECTION, ConfigName.Application.REMEMBER_USER_ID);
                return strValue.Equals("1");
            }
            set
            {
                Instance.SetValue(ConfigName.Application.SECTION, ConfigName.Application.REMEMBER_USER_ID, (value ? "1" : "0"));
            }
        }
        public static bool RememberPassword
        {
            get
            {
                string strValue = Instance.GetValueString(ConfigName.Application.SECTION, ConfigName.Application.REMEMBER_PASSWORD);
                return strValue.Equals("1");
            }
            set
            {
                Instance.SetValue(ConfigName.Application.SECTION, ConfigName.Application.REMEMBER_PASSWORD, (value ? "1" : "0"));
            }
        }
        public static string DefaultCustomerCode
        {
            get
            {
                string strValue = Instance.GetValueString(ConfigName.Application.SECTION, ConfigName.Application.CUSTOMER_ID);
                return strValue;
            }
            set
            {
                Instance.SetValue(ConfigName.Application.SECTION, ConfigName.Application.CUSTOMER_ID, value);
            }
        }
        public static string DefaultDistributionCenterCode
        {
            get
            {
                string strValue = Instance.GetValueString(ConfigName.Application.SECTION, ConfigName.Application.DISTRIBUTIONCENTER_ID);
                return strValue;
            }
            set
            {
                Instance.SetValue(ConfigName.Application.SECTION, ConfigName.Application.DISTRIBUTIONCENTER_ID, value);
            }
        }

        public static string DatabaseServerName
        {
            get { return _DatabaseServerName; }
            set { _DatabaseServerName = value; }
        }
        public static string DatabaseName
        {
            get { return _DatabaseName; }
            set{_DatabaseName = value;}
        }
        public static string DatabaseUserName
        {
            get { return _DatabaseUserName; }
            set { _DatabaseUserName = value; }
        }
        public static string DatabasePassword
        {
            get { return _DatabasePassword; }
            set { _DatabasePassword = value; }
        }
        #endregion
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

        public string GetValueString(string strSection, string strEntry)
        {
            object oValue = GetValue(strSection, strEntry);
            if (oValue == null)
            {
                return string.Empty;
            }
            else
            {
                return oValue.ToString();
            }
        }

        public object GetValue(string strSection, string strEntry)
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
