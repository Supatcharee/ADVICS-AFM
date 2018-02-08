using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using Newtonsoft.Json;
using System.Collections;
using System.Data;

namespace CSI.Business.Master
{
    public class Currency
    {
        #region Member

        #endregion

        #region Properties

        public int   CurrencyID    { get; set; }
        public string CurrencyCode  { get; set; }
        public string CurrencyName  { get; set; }
        public string Remark        { get; set; }
        public string CurrentUser   { get; set; }


        #endregion

        public DataTable DataLoading(string CurrencyCode, string CurrencyName)
        {
            Hashtable hs = new Hashtable();
            hs.Add("CurrencyCode", CurrencyCode);
            hs.Add("CurrencyName", CurrencyName);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Currency/DataLoading", hs);
                return JsonConvert.DeserializeObject<DataTable>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveData(string CurrencyXML, string CreateUser)
        {  
            Hashtable hs = new Hashtable();
            hs.Add("CreateUser", CreateUser);

            try
            {
                RubixWebAPI.ExecuteObjectResult("Currency/SaveData", hs, CurrencyXML);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean CheckExistCurrencyCode(int? CurrencyID, String CurrencyCode)
        {

            Hashtable hs = new Hashtable();
            hs.Add("CurrencyID", CurrencyID);
            hs.Add("CurrencyCode", CurrencyCode);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Currency/CheckExistCurrencyCode", hs);
                return JsonConvert.DeserializeObject<Boolean>(strResult);
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

                RubixWebAPI.ExecuteObjectResult("Currency/DeleteData", JsonConvert.SerializeObject(this.CurrencyID));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int? CheckReference(int CurrencyID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("CurrencyID", CurrencyID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Currency/CheckReference", hs);
                return JsonConvert.DeserializeObject<int>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
