using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using Newtonsoft.Json;

namespace CSI.Business.Master
{
    public class PurchasePrice
    {
        struct ImportSave
        {
            public string XML;
            public string CurrentUser;
        }

        public DataTable DataLoading(int? OwnerID, int? SupplierID, DateTime? EffectiveFrom, DateTime? EffectiveTo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("SupplierID", SupplierID);
            hs.Add("EffectiveFrom", EffectiveFrom);
            hs.Add("EffectiveTo", EffectiveTo);

            try
            {
                return RubixWebAPI.ExecuteDataTable("PurchasePrice/DataLoading", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean CheckExist(int? PurchasePriceID, int SupplierID, int ProductID, DateTime EffectiveDate)
        {
            Hashtable hs = new Hashtable();
            hs.Add("PurchasePriceID", PurchasePriceID);
            hs.Add("SupplierID", SupplierID);
            hs.Add("ProductID", ProductID);
            hs.Add("EffectiveDate", EffectiveDate);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("PurchasePrice/CheckExist", hs);
                return JsonConvert.DeserializeObject<bool>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int CheckCurrency( int SupplierID, int ProductID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("SupplierID", SupplierID);
            hs.Add("ProductID", ProductID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("PurchasePrice/CheckCurrency", hs);
                return JsonConvert.DeserializeObject<int>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveData(string PurchasePriceXML, string CreateUser)
        {
            Hashtable hs = new Hashtable();
            hs.Add("CreateUser", CreateUser);

            try
            {
                RubixWebAPI.ExecuteObjectResult("PurchasePrice/SaveData", hs, PurchasePriceXML);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveImportData(string PurchasePriceXML, string CreateUser)
        {
            ImportSave stc = new ImportSave();
            stc.CurrentUser = CreateUser;
            stc.XML = PurchasePriceXML;

            try
            {
                RubixWebAPI.ExecuteObjectResult("PurchasePrice/SaveImportData", JsonConvert.SerializeObject(stc));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteData(int PurchasePriceID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("PurchasePriceID", PurchasePriceID);

            try
            {
                RubixWebAPI.ExecuteObjectResult("PurchasePrice/DeleteData", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
