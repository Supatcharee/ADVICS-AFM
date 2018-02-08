using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Collections;

namespace CSI.Business
{
    public class MultiLangBiz
    {
        #region Member
        private BusinessCommon ims = null; // For Connection
        #endregion

        #region Properties
        private BusinessCommon Database
        {
            get
            {
                if (ims == null)
                {
                    ims = new BusinessCommon();
                }
                return ims;
            }
        }
        #endregion

        public DataSet LoadMultilang(string CurrentLanguage, string FormName)
        {
            Hashtable hs = new Hashtable();
            hs.Add("CurrentLanguage", CurrentLanguage);
            hs.Add("FormName", FormName == string.Empty ? null : FormName);
            return Database.ExecuteDataSet("sp_Load_Multilang", hs);
        }

        public DataTable LoadAlllanguage()
        {
            return Database.ExecuteDataSet("sp_ADM050_Load_All_Language").Tables[0];
        }

        public DataTable LoadAllFormName()
        {
            return Database.ExecuteDataSet("sp_ADM050_Load_All_FormName").Tables[0];
        }

        public void AddNewMultiLang(string FORM_ID, string CTRL_ID, string CTRL_TYPE, string ORIGIN, string FORM_NAME, string LANG_WORD, string CREATED_BY)
        {
            Hashtable hs = new Hashtable();
            hs.Add("FORM_ID", FORM_ID);
            hs.Add("CTRL_ID", CTRL_ID);
            hs.Add("CTRL_TYPE", CTRL_TYPE);
            hs.Add("ORIGIN", ORIGIN);
            hs.Add("FORM_NAME", FORM_NAME);
            hs.Add("LANG_WORD", LANG_WORD);
            hs.Add("CREATED_BY", CREATED_BY);
            Database.ExecuteNonQuery("sp_ADM050_AddNewMultiLang", hs);
        }

        public void UpdateMultiLang(string MAP_ID, string LANG_ID, string LANG_WORD, string UPDATED_BY)
        {
            Hashtable hs = new Hashtable();
            hs.Add("MAP_ID", MAP_ID);
            hs.Add("LANG_ID", LANG_ID);
            hs.Add("LANG_WORD", LANG_WORD);
            hs.Add("UPDATED_BY", UPDATED_BY);
            Database.ExecuteNonQuery("sp_ADM050_UpdateMultiLang", hs);
        }

        public DataTable SearchMultiLang(string FORM_ID, string CTRL_TYPE, string LANG)
        {
            Hashtable hs = new Hashtable();
            hs.Add("FORM_ID", FORM_ID);
            hs.Add("CTRL_TYPE", CTRL_TYPE);
            hs.Add("LANG", LANG);
            return Database.ExecuteDataSet("sp_ADM050_SearchMultiLang", hs).Tables[0];
        }
    }
}
