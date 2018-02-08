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
    public class PurchasePrice
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
        #endregion

        public DataTable DataLoading(int? OwnerID,int? SupplierID, DateTime? EffectiveFrom, DateTime? EffectiveTo)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("OwnerID", OwnerID);
                hs.Add("SupplierID", SupplierID);
                hs.Add("EffectiveDateForm", EffectiveFrom);
                hs.Add("EffectiveDateTo", EffectiveTo);
                return Database.ExecuteDataSet("sp_XMSS330_PurchasePrice_Search", hs).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean CheckExist(int? PurchasePriceID, int SupplierID, int ProductID, DateTime EffectiveDate)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("PurchasePriceID", PurchasePriceID);
                hs.Add("SupplierID", SupplierID);
                hs.Add("ProductID", ProductID);
                hs.Add("EffectiveDate", EffectiveDate);
                return Convert.ToInt16(Database.ExecuteScalar("sp_XMSS330_PurchasePrice_CheckExist", hs)) == 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int CheckCurrency(int SupplierID, int ProductID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("SupplierID", SupplierID);
                hs.Add("ProductID", ProductID);
                return Convert.ToInt16(Database.ExecuteScalar("sp_XMSS330_PurchasePrice_CheckCurrency", hs));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveData(string PurchasePriceXML, string CreateUser)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("PurchasePriceXML", PurchasePriceXML);
                hs.Add("CreateUser", CreateUser);
                Database.ExecuteNonQuery("sp_XMSS330_PurchasePrice_Save", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveImportData(string PurchasePriceXML, string CreateUser)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("XMLSave", PurchasePriceXML);
                hs.Add("CurrentUser", CreateUser);
                Database.ExecuteNonQuery("sp_XMSS330_PurchasePrice_Import_Save", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteData(int PurchasePriceID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("PurchasePriceID", PurchasePriceID);
                Database.ExecuteNonQuery("sp_XMSS330_PurchasePrice_Delete", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
