using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Collections;

namespace CSI.Business.BusinessFactory.Common
{
    public class IdleValidator
    {
        public string ReturnValue(string TableName, string ColumnName, string Key)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("TableName", TableName);
                hs.Add("ColumnName", ColumnName);
                hs.Add("Key", Key);
                Hashtable hsRef = new Hashtable();
                hsRef.Add("LastUpdateDate", string.Empty);

                Database.ExecuteNonQuery("sp_VerifyData", hs, ref hsRef);
                if (hsRef["LastUpdateDate"] == DBNull.Value)
                {
                    return null;
                }
                else
                {
                    return Convert.ToDateTime(hsRef["LastUpdateDate"], new System.Globalization.CultureInfo("en-US")).ToString("yyyy/MM/dd HH:mm:ss:ffffff");
                }
            }
            catch (Exception ex)
            {                
                throw ex;
            }

        }
    }
}
