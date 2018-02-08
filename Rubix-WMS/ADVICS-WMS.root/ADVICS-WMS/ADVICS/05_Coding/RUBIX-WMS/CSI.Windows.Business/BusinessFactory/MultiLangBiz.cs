using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Collections;
using Newtonsoft.Json;

namespace CSI.Business
{
    public class MultiLangBiz
    {
        public DataSet LoadMultilang(string CurrentLanguage, string FormName = "")
        {
            Hashtable hs = new Hashtable();
            hs.Add("CurrentLanguage", CurrentLanguage);
            hs.Add("FormName", FormName);

            return RubixWebAPI.ExecuteDataSet("MultiLang/LoadMultilang", hs);
        }

        public DataTable LoadAlllanguage()
        {
            return RubixWebAPI.ExecuteDataTable("MultiLang/LoadAlllanguage");
        }

        public DataTable LoadAllFormName()
        {
            return RubixWebAPI.ExecuteDataTable("MultiLang/LoadAllFormName");
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
            RubixWebAPI.ExecuteDataTable("MultiLang/AddNewMultiLang", hs);
        }

        public void UpdateMultiLang(DataTable dt)
        {
            RubixWebAPI.ExecuteObjectResult("MultiLang/UpdateMultiLang", JsonConvert.SerializeObject(dt));
        }

        public DataTable SearchMultiLang(string FORM_ID, string CTRL_TYPE, string LANG)
        {
            Hashtable hs = new Hashtable();
            hs.Add("FORM_ID", FORM_ID);
            hs.Add("CTRL_TYPE", CTRL_TYPE);
            hs.Add("LANG", LANG);
            return RubixWebAPI.ExecuteDataTable("MultiLang/SearchMultiLang", hs);
        }
    }
}
