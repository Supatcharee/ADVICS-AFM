using System;
using System.Data;
using System.Collections;
namespace Rubix.Framework
{
    public class MultiLanguage
    {

        private static DataSet m_dsLang = null;
        private bool m_bUseMultiLang = true;
        private LanguageControlDAOForMutiLan m_LangCtrl = new LanguageControlDAOForMutiLan();

        public enum eType
        {
            Form, Menu, Global
        }
        public MultiLanguage()
        {

        }

        public void LoadMultiLang(DataSet ds)
        {
            m_dsLang = m_LangCtrl.GetLangDataSet(ds);
        }
 
        public string GetText(eType Type, string strFormName, string strItemName, string strInputText)
        {
            if (m_dsLang == null || (Type != eType.Global && !m_bUseMultiLang))
            {
                return strInputText;
            }
            DataTable dt = null;

            switch (Type)
            {
                case eType.Form:
                    dt = m_dsLang.Tables["Screen"];
                    string strFilter = "form_id = '" + strFormName + "'";
                    DataRow[] drs = dt.Select(strFilter);

                    foreach (DataRow dr in drs)
                    {
                        if (dr["CTRL_ID"].ToString().Equals(strItemName))
                        {
                            return IsNull(dr["LANG_WORD"].ToString(), IsNull(dr["ORIGIN"].ToString(), strInputText));
                        }
                    }
                    break;
                case eType.Global:
                    dt = m_dsLang.Tables["Global"];
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["CTRL_ID"].ToString().Equals(strItemName))
                        {
                            return IsNull(dr["LANG_WORD"].ToString(), IsNull(dr["ORIGIN"].ToString(), strInputText));
                        }
                    }
                    break;
                case eType.Menu:
                    dt = m_dsLang.Tables["Menu"];
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["CTRL_ID"].ToString().Equals(strItemName))
                        {
                            return IsNull(dr["LANG_WORD"].ToString(), IsNull(dr["ORIGIN"].ToString(), strInputText));
                        }
                    }
                    break;
            }
            return strInputText;            
        }
        public string GetFormText(string strFormName, string strItemName)
        {
            return this.GetText(MultiLanguage.eType.Form, strFormName, strItemName, "NO MSG ID");
        }
        public string GetFormText(string strFormName, string strItemName, string strDefaultText)
        {
            return this.GetText(MultiLanguage.eType.Form, strFormName, strItemName, strDefaultText);
        }
        public string GetMenuText(string strItemName)
        {
            return this.GetText(MultiLanguage.eType.Menu, string.Empty, strItemName, "NO MSG ID");
        }
        public string GetMenuText(string strItemName, string strDefaultText)
        {
            return this.GetText(MultiLanguage.eType.Menu, string.Empty, strItemName, strDefaultText);
        }
        public string GetGlobalText(string strMsgNo)
        {
            return this.GetText(MultiLanguage.eType.Global, string.Empty, strMsgNo, strMsgNo);
        }
        public string GetGlobalText(string strMsgNo, string strDefaultText)
        {
            string strResult = string.Empty;
            strResult = this.GetText(MultiLanguage.eType.Global, string.Empty, strMsgNo, strDefaultText);

            try
            {
                return strResult;
            }
            catch (Exception)
            {
#if DEBUG
                throw new Exception(strResult + "\n Message does not match with Message parameters");
#else 
                return strResult;
#endif
            }
        }
        public string GetGlobalText(string strMsgNo, string strDefaultText, params string[] strParams)
        {
            string strResult = string.Empty;
            //if (strMsgNo.Contains("MSG"))
            //    strResult = "YMPPD-" + strMsgNo.Substring(3, 4) + " : " + this.GetText(MultiLanguage.eType.Global, string.Empty, strMsgNo, strDefaultText);
            //else
                strResult = this.GetText(MultiLanguage.eType.Global, string.Empty, strMsgNo, strDefaultText);

            try
            {
                return string.Format(strResult, strParams);
            }
            catch (Exception)
            {
#if DEBUG
                throw new Exception(strResult + "\n Message does not match with Message parameters");
#else 
                return strResult;
#endif
            }
        }

        /// <summary>
        /// Used only in this class
        /// </summary>
        /// <param name="strInput"></param>
        /// <param name="strDefault"></param>
        /// <returns></returns>
        private string IsNull(string strInput, string strDefault)
        {
            if (strInput.Equals(string.Empty))
            {
                return strDefault;
            }
            return strInput;
        }
    }

    #region MultiLanguageData DTO
    public class MultiLanguageData
    {
        private ArrayList m_ArrForms = new ArrayList();
        private ArrayList m_ArrMenus = new ArrayList();
        private ArrayList m_ArrGlobals = new ArrayList();
        public MultiLanguageData() { }
        public ArrayList ArrForms { get { return m_ArrForms; } set { m_ArrForms = value; } }
        public ArrayList ArrMenus { get { return m_ArrMenus; } set { m_ArrMenus = value; } }
        public ArrayList ArrGlobals { get { return m_ArrGlobals; } set { m_ArrGlobals = value; } }

        public class FormData
        {
            private string m_FormName = string.Empty;
            private ArrayList m_ArrFormControls = new ArrayList();
            public FormData() { }
            public string FormName { get { return m_FormName; } set { m_FormName = value; } }
            public ArrayList ArrFormControls { get { return m_ArrFormControls; } set { m_ArrFormControls = value; } }

            public class ControlData
            {
                private string m_ControlName = string.Empty;
                private string m_ControlText = string.Empty;
                public ControlData() { }
                public string ControlName { get { return m_ControlName; } set { m_ControlName = value; } }
                public string ControlText { get { return m_ControlText; } set { m_ControlText = value; } }
            }

        }
        public class MenuData
        {
            private string m_MenuItemName = string.Empty;
            private string m_MenuItemText = string.Empty;
            public MenuData() { }
            public string MenuItemName { get { return m_MenuItemName; } set { m_MenuItemName = value; } }
            public string MenuItemText { get { return m_MenuItemText; } set { m_MenuItemText = value; } }
        }
        public class GlobalData
        {
            private string m_GlobalItemName = string.Empty;
            private string m_GlobalItemText = string.Empty;
            public GlobalData() { }
            public string GlobalItemName { get { return m_GlobalItemName; } set { m_GlobalItemName = value; } }
            public string GlobalItemText { get { return m_GlobalItemText; } set { m_GlobalItemText = value; } }
        }
    }
    #endregion

    public class LanguageControlDAOForMutiLan
    {
        public DataSet GetLangDataSet(DataSet ds)
        {
            ds.Tables[0].TableName = "Menu";
            ds.Tables[1].TableName = "Global";
            ds.Tables[2].TableName = "Screen";

            return ds;            
        }
    }
}
