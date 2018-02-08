using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using System.Collections;
using System.Data;

namespace CSI.Business.BusinessFactory.Master
{
    public class Currency
    {
        #region Member
        private BusinessCommon ims = null; 
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

        public int?   CurrencyID        { get; set; }
        public string CurrencyCode      { get; set; }
        public string CurrencyName      { get; set; }
        public string Remark            { get; set; }
        public string CurrentUser       { get; set; }

        #endregion
        
        #region Generic Function
        public DataTable DataLoading(String CurrencyCode, String CurrencyName)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("CurrencyCode", CurrencyCode);
                hs.Add("CurrencyName", CurrencyName);
                DataTable tb = Database.ExecuteDataSet("sp_XMSS340_Currency_Search", hs).Tables[0];
                return tb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveData(string CurrencyXML, string CreateUser)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("CurrencyXML", CurrencyXML);
                hs.Add("CreateUser", CreateUser);
                Database.ExecuteNonQuery("sp_XMSS340_Currency_Save", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean CheckExistCurrencyCode(int? CurrencyID, String CurrencyCode)
        {
            try
            {

                Hashtable hs = new Hashtable();
                hs.Add("CurrencyID", CurrencyID);
                hs.Add("CurrencyCode", CurrencyCode);
                return Convert.ToInt16(Database.ExecuteScalar("sp_XMSS340_Currency_CheckExist", hs))== 1;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeleteData()
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("CurrencyID", CurrencyID);
                Database.ExecuteNonQuery("sp_XMSS340_Currency_Delete", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int? CheckReference()
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("CurrencyID", CurrencyID);
                return Convert.ToInt32(Database.ExecuteScalar("sp_XMSS340_Currency_CheckReference", hs));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        #endregion

    }
}
