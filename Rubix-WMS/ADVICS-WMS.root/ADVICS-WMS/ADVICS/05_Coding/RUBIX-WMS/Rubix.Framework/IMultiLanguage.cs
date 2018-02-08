using System;
namespace Rubix.Framework
{
    /// <summary>
    /// Summary description for IMultiLanguage.
    /// </summary>
    public interface IMultiLanguage
    {
        void OnLanguageChange(object sender, LanguageChangeEventArgs e);
    }

    public class LanguageChangeEventArgs : EventArgs
    {
        private MultiLanguage m_MultiLanguage;
        public LanguageChangeEventArgs(MultiLanguage MultiLanguage)
        {
            m_MultiLanguage = MultiLanguage;
        }
        public MultiLanguage MultiLanguage
        {
            get
            {
                return m_MultiLanguage;
            }
        }

    }

    public interface ILogoutable
    {
        void OnLogout();
    }

}
