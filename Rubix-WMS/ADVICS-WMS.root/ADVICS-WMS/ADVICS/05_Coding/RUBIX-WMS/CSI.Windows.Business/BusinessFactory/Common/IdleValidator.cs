using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using System.Collections;
using Newtonsoft.Json;

namespace CSI.Business.BusinessFactory.Common
{
    public class IdleValidator
    {
        public struct IdleValidatorStruct
        {
            public string Table;
            public string Column;
            public string Key;

        }

        private string table;
        private string column;
        private string key;
        private string SQLParam;
        private Dictionary<string, DateTime?> valueDic;

        public IdleValidator(string tableName, string columnName, params string[] keysColumn)
        {
            this.table = tableName;
            this.column = columnName;
            key = string.Empty;
            for (int i = 0; i < keysColumn.Length; i++)
            {
                key += string.Format("{0}='{1}{2}{3}' ", keysColumn[i],"{", i,"}");
                if (i != keysColumn.Length - 1)
                    key += " AND ";
            }
            valueDic = new Dictionary<string, DateTime?>();
        }

        public void ClearTicket()
        {
            valueDic.Clear();
        }

        public void ReNewTicket()
        {
            Hashtable hs = new Hashtable();
            try
            {
                foreach (string val in valueDic.Keys)
                {
                    IdleValidatorStruct data = new IdleValidatorStruct();
                    data.Table = this.table;
                    data.Column = this.column;
                    data.Key = SQLParam;

                    string strResult = RubixWebAPI.ExecuteObjectResult("IdleValidator/LastUpdateDate", JsonConvert.SerializeObject(data));
                    DateTime? lastUpdate = JsonConvert.DeserializeObject<DateTime?>(strResult);
                    valueDic[val] = lastUpdate;

                    hs.Clear();
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }               
        }

        //public void PushTicket(params string[] val)
        //{
        //    string value = string.Empty;
        //    DateTime? lastUpdate;
        //    SQLParam = this.key;
        //    for (int i = 0; i < val.Length; i++)
        //    {
        //        value += val[i];
        //        SQLParam = SQLParam.Replace("{" + i + "}", val[i]);
        //        if (i != val.Length - 1)
        //        {
        //            value += "#;#";
        //        }
        //    }
        //    if (!valueDic.ContainsKey(value))
        //    {
        //        IdleValidatorStruct data = new IdleValidatorStruct();
        //        data.Table = this.table;
        //        data.Column = this.column;
        //        data.Key = SQLParam;

        //        string strResult = RubixWebAPI.ExecuteObjectResult("IdleValidator/LastUpdateDate", JsonConvert.SerializeObject(data));
        //        lastUpdate = JsonConvert.DeserializeObject<DateTime?>(strResult);
        //        valueDic.Add(value, lastUpdate);
        //    }
        //}

        public void PushTicket(DateTime? lastUpdate, params string[] val)
        {
            string value = string.Empty;
            for (int i = 0; i < val.Length; i++)
            {
                value += val[i];
                if (i != val.Length - 1)
                    value += "#;#";
            }
            if (!valueDic.ContainsKey(value))
            {
                valueDic.Add(value, lastUpdate);
            }
        }
                
        public bool ValidateTicket(params string[] val)
        {
            string value = string.Empty;
            SQLParam = this.key;
            for (int i = 0; i < val.Length; i++)
            {
                value += val[i];
                SQLParam = SQLParam.Replace("{" + i + "}", val[i]);
                if (i != val.Length - 1)
                {
                    value += "#;#";
                }
            }
            if (valueDic.ContainsKey(value))
            {
                DateTime? ticketDate = valueDic[value];
                if (Convert.ToDateTime(ticketDate) == DateTime.MinValue)
                {
                    ticketDate = null;
                }
                DateTime? lastUpdate;    
            
                IdleValidatorStruct data = new IdleValidatorStruct();
                data.Table = this.table;
                data.Column = this.column;
                data.Key = SQLParam;

                string strResult = RubixWebAPI.ExecuteObjectResult("IdleValidator/LastUpdateDate", JsonConvert.SerializeObject(data));
                //lastUpdate = JsonConvert.DeserializeObject<DateTime?>(strResult);

                if (strResult.Trim() != string.Empty)
                {
                    return true;
                }
                else if (!ticketDate.HasValue || (ticketDate.HasValue &&  Convert.ToDateTime(ticketDate).ToString("yyyy/MM/dd HH:mm:ss:ffffff") == strResult ))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
}
