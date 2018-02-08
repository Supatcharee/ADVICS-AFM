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
    public class SalePrice
    {
        struct ImportSave
        {
            public string XML;
            public string CurrentUser;
        }

        public DataTable DataLoading(int? OwnerID, int? CustomerID, DateTime? EffectiveFrom, DateTime? EffectiveTo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("CustomerID", CustomerID);
            hs.Add("EffectiveFrom", EffectiveFrom);
            hs.Add("EffectiveTo", EffectiveTo);

            try
            {
                return RubixWebAPI.ExecuteDataTable("SalePrice/DataLoading", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean CheckExist(int? SalePriceID, int CustomerID, int ProductID, DateTime EffectiveDate)
        {
            Hashtable hs = new Hashtable();
            hs.Add("SalePriceID", SalePriceID);
            hs.Add("CustomerID", CustomerID);
            hs.Add("ProductID", ProductID);
            hs.Add("EffectiveDate", EffectiveDate);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("SalePrice/CheckExist", hs);
                return JsonConvert.DeserializeObject<bool>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int CheckCurrency(int CustomerID, int ProductID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("CustomerID", CustomerID);
            hs.Add("ProductID", ProductID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("SalePrice/CheckCurrency", hs);
                return JsonConvert.DeserializeObject<int>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveData(string SalePriceXML, string CreateUser)
        {
            Hashtable hs = new Hashtable();
            hs.Add("CreateUser", CreateUser);

            try
            {
                RubixWebAPI.ExecuteObjectResult("SalePrice/SaveData", hs, SalePriceXML);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveImportData(string SalePriceXML, string CreateUser)
        {
            ImportSave stc = new ImportSave();
            stc.CurrentUser = CreateUser;
            stc.XML = SalePriceXML;

            try
            {
                RubixWebAPI.ExecuteObjectResult("SalePrice/SaveImportData", JsonConvert.SerializeObject(stc));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteData(int SalePriceID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("SalePriceID", SalePriceID);

            try
            {
                RubixWebAPI.ExecuteObjectResult("SalePrice/DeleteData", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
