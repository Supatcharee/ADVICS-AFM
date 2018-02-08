using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO;
using System.Data;

namespace Rubix.Framework
{
    public class AppConfig
    {
        #region Private member
        private static IniConfiguration m_ini = null;
        private static string _userID = string.Empty;
        private static string _password = string.Empty;

        private static string _DatabaseServerName = string.Empty;
        private static string _DatabaseName = string.Empty;
        private static string _DatabaseUserName = string.Empty;
        private static string _DatabasePassword = string.Empty;

        private static DevExpress.XtraBars.BarStaticItem bs;
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

                public const string LOCALE = "LOCALE";
                public const string DEFAULT_LANGUAGE_PATH = "DEFAULT_LANGUAGE_PATH";
                public const string LANGUAGE_ENGLISH = "en-US";

                public const string SCREEN_THEME_STYLE = "SCREEN_THEME_STYLE";
                public const string GRID_THEME_STYLE = "GRID_THEME_STYLE";
                public const string GRID_PAINT_STYLE = "GRID_PAINT_STYLE";

                public const string USER_ID = "USER_ID";
                public const string PASSWORD = "PASSWORD";
                public const string OWNER_ID = "OWNER_ID";
                public const string WAREHOUSE_ID = "WAREHOUSE_ID";
                public const string DISPLAY_PERIOD_MONTH = "DISPLAY_PERIOD_MONTH";

                public const string REMEMBER_USER_ID = "REMEMBER_USER";
                public const string REMEMBER_PASSWORD = "REMEMBER_PASSWORD";

                //public const string RUBIX_WEB_AUTHENTICATE = "WEB_AUTHENTICATE";
                public const string WEB_API_ADDRESS = "WEB_API_ADDRESS";
                public const string WEB_API_URL = "WEB_API_URL";
                public const string AUTO_UPDATE_URL = "AUTO_UPDATE_URL";

                public const string COMPANY_NAME = "COMPANY_NAME";

            }
        }
        #endregion
        
        #region Get Set Data
        public static string Locale
        {
            get
            {
                string strValue = Instance.GetValue(ConfigName.Application.SECTION, ConfigName.Application.LOCALE);
                if (string.IsNullOrWhiteSpace(strValue))
                {
                    strValue = "en-Us";
                    AppConfig.Locale = strValue;
                }
                return strValue;
            }
            set
            {
                Instance.SetValue(ConfigName.Application.SECTION,ConfigName.Application.LOCALE, value);
            }
        }

        public static MultiLanguage CurrentLanguage
        {
            get;
            set;
        }

        public static string DefaultLanguagePath
        {
            get
            {
                try
                {
                    string strValue = Instance.GetValue(ConfigName.Application.SECTION, ConfigName.Application.DEFAULT_LANGUAGE_PATH);
                    if (string.IsNullOrWhiteSpace(strValue))
                    {
                        AppConfig.DefaultLanguagePath = ConfigName.Application.LANGUAGE_ENGLISH;
                        return ConfigName.Application.LANGUAGE_ENGLISH;
                    }
                    else
                    {
                        return strValue;
                    }
                }
                catch
                {
                    AppConfig.DefaultLanguagePath = ConfigName.Application.LANGUAGE_ENGLISH;
                    return ConfigName.Application.LANGUAGE_ENGLISH;
                }
            }
            set
            {
                Instance.SetValue(ConfigName.Application.SECTION, ConfigName.Application.DEFAULT_LANGUAGE_PATH, value.ToString());
            }
        }

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

        public static string ScreenThemeStyle
        {
            get
            {
                string strValue = Instance.GetValue(ConfigName.Application.SECTION, ConfigName.Application.SCREEN_THEME_STYLE);
                if (string.IsNullOrWhiteSpace(strValue))
                {
                    AppConfig.ScreenThemeStyle = "Money Twins";
                    return ConfigName.Application.SCREEN_THEME_STYLE;
                }
                else
                {
                    return strValue;
                }
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
                string strValue = Instance.GetValue(ConfigName.Application.SECTION, ConfigName.Application.GRID_THEME_STYLE);
                if (string.IsNullOrWhiteSpace(strValue))
                {
                    AppConfig.GridThemeStyle = "(Default)";
                    return ConfigName.Application.GRID_THEME_STYLE;
                }
                else
                {
                    return strValue;
                }
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
                string strValue = Instance.GetValue(ConfigName.Application.SECTION, ConfigName.Application.GRID_PAINT_STYLE);
                if (string.IsNullOrWhiteSpace(strValue))
                {
                    AppConfig.GridPaintStyle = "Default";
                    return ConfigName.Application.GRID_PAINT_STYLE;
                }
                else
                {
                    return strValue;
                }
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
                //Assembly asm = Assembly.LoadFrom(AppConfig.ExePath);
                //string version = asm.GetName().Version.ToString();
                //asm = null;
                return Instance.GetValue(ConfigName.Application.SECTION, ConfigName.Application.PROGRAM_VERSION); ;
            }
            set
            {
                Instance.SetValue(ConfigName.Application.SECTION, ConfigName.Application.PROGRAM_VERSION, value);
            }
        }

        public static string ExePath
        {
            get
            {
                return Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Rubix.Screen.dll");
            }
        }

        public static string Fullname
        {
            get
            {
                return string.Format("{0} {1}", Firstname, Lastname);
            }
        }

        public static string Name
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(Lastname) &&  Lastname.Length > 0) 
                {
                    return string.Format("{0} {1}.", Firstname, Lastname.Substring(0, 1));
                }
                else
                {
                    return Firstname;
                }
            }
        }

        public static string Firstname
        {
            get;
            set; 
        }

        public static string Lastname
        {
            get;
            set; 
        }

        public static string UserLogin
        {
            get
            {
                try
                {
                    if (AppConfig.RememberUserLogin != null)
                    {
                        if (AppConfig.RememberUserLogin)
                        {
                            _userID = Instance.GetValue(ConfigName.Application.SECTION, ConfigName.Application.USER_ID);
                        }
                        return (_userID == null ? string.Empty : _userID);
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
                catch (Exception ex)
                {                    
                    return string.Empty;
                }
            }
            set
            {
                if (AppConfig.RememberUserLogin)
                {
                    Instance.SetValue(ConfigName.Application.SECTION, ConfigName.Application.USER_ID, value);
                }
                else
                {
                    _userID = value;
                }
            }
        }

        public static string Password
        {
            get
            {
                if (AppConfig.RememberPassword)
                {
                    _password = Instance.GetValue(ConfigName.Application.SECTION, ConfigName.Application.PASSWORD);
                }
                return _password;
            }
            set
            {
                if (AppConfig.RememberPassword)
                {
                    Instance.SetValue(ConfigName.Application.SECTION, ConfigName.Application.PASSWORD, value);
                }
                else
                {
                    _password = value;
                }
            }
        }

        public static bool RememberUserLogin
        {
            get
            {
                string strValue = Instance.GetValue(ConfigName.Application.SECTION, ConfigName.Application.REMEMBER_USER_ID);
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
                string strValue = Instance.GetValue(ConfigName.Application.SECTION, ConfigName.Application.REMEMBER_PASSWORD);
                return strValue.Equals("1");
            }
            set
            {
                Instance.SetValue(ConfigName.Application.SECTION, ConfigName.Application.REMEMBER_PASSWORD, (value ? "1" : "0"));
            }
        }

        public static int? DefaultOwnerID { get; set; }
        
        public static int? DefaultWarehouseID { get; set; }
        
        public static int DisplayPeriodMonth
        {
            get
            {
                try
                {
                    string strValue = Instance.GetValue(ConfigName.Application.SECTION, ConfigName.Application.DISPLAY_PERIOD_MONTH);
                    if (string.IsNullOrWhiteSpace(strValue))
                    {
                        AppConfig.DisplayPeriodMonth = 0;
                        return Convert.ToInt32(ConfigName.Application.DISPLAY_PERIOD_MONTH);
                    }
                    else
                    {
                        return Convert.ToInt32(strValue);
                    }
                }
                catch (Exception ex)
                {
                    return 0;
                }
            }
            set
            {
                Instance.SetValue(ConfigName.Application.SECTION, ConfigName.Application.DISPLAY_PERIOD_MONTH, value);
            }
        }
                
        public static string RubixWebAuthenticate
        {
            get
            {
                //return Instance.GetValue(ConfigName.Application.RUBIX_WEB_AUTHENTICATE);
                return string.Empty;
            }
        }

        public static string RubixWebApiAddress
        {
            get
            {
                return Instance.GetValue(ConfigName.Application.SECTION, ConfigName.Application.WEB_API_ADDRESS);
            }
        }

        public static string RubixWebApiUrl
        {
            //get { return (_RubixWebAPI == null ? string.Empty : _RubixWebAPI); }
            //set { _RubixWebAPI = value; }
            set
            {
                Instance.SetValue(ConfigName.Application.SECTION, ConfigName.Application.WEB_API_URL, value);
            }
            get
            {
                return Instance.GetValue(ConfigName.Application.SECTION, ConfigName.Application.WEB_API_URL);
            }
        }

        public static string RubixAutoUpdateURL
        {
            get
            {
                return Instance.GetValue(ConfigName.Application.SECTION, ConfigName.Application.AUTO_UPDATE_URL);
            }
        }

        public static string CompanyCode { get; set; }

        public static string CompanyName { get; set; }

        public static string DatabaseServerName
        {
            get { return (_DatabaseServerName == null ? string.Empty : _DatabaseServerName); }
            set { _DatabaseServerName = value; }
        }

        public static string DatabaseName
        {
            get { return (_DatabaseName == null ? string.Empty : _DatabaseName); }
            set { _DatabaseName = value; }
        }

        public static string DatabaseUserName
        {
            get { return (_DatabaseUserName == null ? string.Empty : _DatabaseUserName); }
            set { _DatabaseUserName = value; }
        }

        public static string DatabasePassword
        {
            get { return (_DatabasePassword == null ? string.Empty : _DatabasePassword); }
            set { _DatabasePassword = value; }
        }

        public static DataTable DomainList
        {
            get;
            set;
        }

        public static string DomainUsername { get; set; }

        public static string DomainPassword { get; set; }

        public static bool IsDomainLogin { get; set; }
        
        public static DevExpress.XtraBars.BarStaticItem LastestDailyPost
        {
            get 
            {
                bs.Caption = Util.GetGlobalText("A0004");            
                return bs; 
            }
            set 
            { 
                bs = value; 
            }
        }

        public static int AuthenLevel { get; set; }

        //0 = login
        //1 = MainMenu
        //2 = Form Base
        //3 = Dialog Base
        public static int? SplashScreenType { get; set; }
        public static DevExpress.XtraSplashScreen.SplashScreenManager SplashScreenManager { get; set; }

        public static ILogoutable MainScreen { get; set; }
        #endregion
    }

    public class IniConfiguration
    {
        //----------------OLD Config is XML
        //public void SetValue(string ConfigName, object Configvalue)
        //{
        //    if (Configvalue == null)
        //    {
        //        return;
        //    }

        //    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        //    if (ConfigurationManager.AppSettings[ConfigName] != null)
        //    {
        //        config.AppSettings.Settings.Remove(ConfigName);
        //    }

        //    config.AppSettings.Settings.Add(ConfigName, Configvalue.ToString());
        //    config.Save(ConfigurationSaveMode.Modified);
        //    ConfigurationManager.RefreshSection("appSettings");
        //}
        
        //public string GetValue(string ConfigName)
        //{
        //    return ConfigurationManager.AppSettings[ConfigName];
        //}
        
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
