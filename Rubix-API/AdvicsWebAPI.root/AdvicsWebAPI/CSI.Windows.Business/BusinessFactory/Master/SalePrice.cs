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
    public class SalePrice
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

        #region Generic Function
        public DataTable DataLoading(int? OwnerID, int? CusmoterID, DateTime? EffectiveFrom, DateTime? EffectiveTo)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("OwnerID", OwnerID);
                hs.Add("CustomerID", CusmoterID);
                hs.Add("EffectiveDateForm", EffectiveFrom);
                hs.Add("EffectiveDateTo", EffectiveTo);
                return Database.ExecuteDataSet("sp_XMSS320_SalePrice_Search", hs).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean CheckExist(int? SalePriceID, int CustomerID, int ProductID, DateTime EffectiveDate)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("SalePriceID", SalePriceID);
                hs.Add("CustomerID", CustomerID);
                hs.Add("ProductID", ProductID);
                hs.Add("EffectiveDate", EffectiveDate);
                return Convert.ToInt16(Database.ExecuteScalar("sp_XMSS320_SalePrice_CheckExist", hs)) == 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int CheckCurrency(int CustomerID, int ProductID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("CustomerID", CustomerID);
                hs.Add("ProductID", ProductID);
                return Convert.ToInt16(Database.ExecuteScalar("sp_XMSS320_SalePrice_CheckCurrency", hs));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveData(string SalePriceXML, string CreateUser)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("SalePriceXML", SalePriceXML);
                hs.Add("CreateUser", CreateUser);
                Database.ExecuteNonQuery("sp_XMSS320_SalePrice_Save", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveImportData(string SalePriceXML, string CreateUser)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("XMLSave", SalePriceXML);
                hs.Add("CurrentUser", CreateUser);
                Database.ExecuteNonQuery("sp_XMSS320_SalePrice_Import_Save", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteData(int SalePriceID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("SalePriceID", SalePriceID);
                Database.ExecuteNonQuery("sp_XMSS320_SalePrice_Delete", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 
        #endregion
    }
}
