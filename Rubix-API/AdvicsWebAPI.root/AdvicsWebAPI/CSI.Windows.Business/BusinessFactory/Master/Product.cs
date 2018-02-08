using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using System.Collections;
using System.Data;

namespace CSI.Business.Master
{
    public struct ProductStruct
    {
        //Header
        public int? ProductID;
        public int? OwnerID;
        public int? ProductTypeID;
        public string Model;
        public string ProductCode;
        public string ProductShortCode;
        public string ProductName;
        public int? ProductGroupID;
        public int? SupplierID;
        public int? ProductCategoryID;
        public int? ClassificationID;
        public int? MinOrder;
        public int? TypeOfUnit;
        public int? PalletTypeID;
        public int? ItemExpiredTypeID;
        public int? ShelfLife;
        public decimal? SafetyStock;
        public int? UnitLevelReceivingLabel;
        public int? LotControl;
        public int? KanbanControl;
        public int? FreeOfCharge;
        public decimal? EstimateValue;
        public string Remark;
        public byte[] ImageFile;
        public byte[] QCImageFile;
        public string CurrentUser;

        //XML
        public string TransitXML;
        public string CargoXML;
        public string PackingXML;

        //Sale
        public int CustomerID;
        public Decimal? SalePrice;
        public int CurrencyID_Sale;
        public DateTime EffectiveDate_Sale;
        public DateTime? ImplementDate_Sale;
        public string Incoterm_Sale;
        public string HSCode;
        public int? PVID;
        public string Remark_Sale;

        //Purchase
        public Decimal? PurchasePrice;
        public int CurrencyID_Purchase;
        public string Incoterm_Purchase;
        public DateTime EffectiveDate_Purchase;
        public DateTime? ImplementDate_Purchase;
        public string Remark_Purchase;
        
    }
    
    public class ProductInfomation
    {
        //Header
        public int? ProductID { get; set; }
        public int? OwnerID { get; set; }
        public int? ProductTypeID { get; set; }
        public string Model { get; set; }
        public string ProductCode { get; set; }
        public string ProductShortCode { get; set; }
        public string ProductName { get; set; }
        public int? ProductGroupID { get; set; }
        public int? SupplierID { get; set; }
        public int? ProductCategoryID { get; set; }
        public int? ClassificationID { get; set; }
        public int? MinOrder { get; set; }
        public int? TypeOfUnit { get; set; }
        public int? PalletTypeID { get; set; }
        public int? ItemExpiredTypeID { get; set; }
        public int? ShelfLife { get; set; }
        public decimal? SafetyStock { get; set; }
        public int? UnitLevelReceivingLabel { get; set; }
        public int? LotControl { get; set; }
        public int? KanbanControl { get; set; }
        public int? FreeOfCharge { get; set; }
        public decimal? EstimateValue { get; set; }
        public string Remark { get; set; }
        public byte[] ImageFile { get; set; }
        public byte[] QCImageFile { get; set; }
        public string CurrentUser { get; set; }
        public bool IsShowGrossWeight { get; set; }
        public decimal? PackingTime { get; set; }
        public decimal? PrepareTime { get; set; }
        public decimal? PalletizeTime { get; set; }
        public int? ShipTagTypeID { get; set; }
        public decimal? WeightMinimumOrder { get; set; }
        public decimal? M3MinimumOrder { get; set; }
        public int? isSpecial { get; set; }

        //XML
        public string TransitXML { get; set; }
        public string CargoXML { get; set; }
        public string PackingXML { get; set; }

        //Sale
        public int? CustomerID { get; set; }
        public Decimal? SalePrice { get; set; }
        public int CurrencyID_Sale { get; set; }
        public DateTime EffectiveDate_Sale { get; set; }
        public DateTime? ImplementDate_Sale { get; set; }
        public string Incoterm_Sale { get; set; }
        public string HSCode { get; set; }
        public int? PVID { get; set; }
        public string Remark_Sale { get; set; }

        //Purchase
        public Decimal? PurchasePrice { get; set; }
        public int CurrencyID_Purchase { get; set; }
        public string Incoterm_Purchase { get; set; }
        public DateTime EffectiveDate_Purchase { get; set; }
        public DateTime? ImplementDate_Purchase { get; set; }
        public string Remark_Purchase { get; set; }


    }

    public class Product
    {
        #region Member
        private sp_XMSS050_Product_SearchAll_Result ta_Result = null;
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

        public sp_XMSS050_Product_SearchAll_Result ResultData
        {
            get
            {
                if (ta_Result == null)
                {
                    ta_Result = new sp_XMSS050_Product_SearchAll_Result();
                }
                return ta_Result;
            }
            set { ta_Result = value; }
        }

        #endregion

        public DataTable DataLoading(int? OwnerID, String ProductCode, String ProductName, int? SupplierID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("OwnerID", OwnerID);
                hs.Add("ProductCode", ProductCode);
                hs.Add("ProductName", ProductName);
                hs.Add("SupplierID", SupplierID);

                return Database.ExecuteDataSet("sp_XMSS050_Product_SearchAll", hs).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet LoadMaterial(int? ProductID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ProductID", ProductID);
                return Database.ExecuteDataSet("sp_XMSS050_Product_LoadMaterial", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void SaveData(ProductInfomation proInfo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ProductID", proInfo.ProductID);
            hs.Add("OwnerID", proInfo.OwnerID);
            hs.Add("ProductTypeID", proInfo.ProductTypeID);
            hs.Add("Model", proInfo.Model);
            hs.Add("ProductCode", proInfo.ProductCode);
            hs.Add("ProductShortCode", proInfo.ProductShortCode);
            hs.Add("ProductName", proInfo.ProductName);
            hs.Add("ProductGroupID", proInfo.ProductGroupID);
            hs.Add("SupplierID", proInfo.SupplierID);
            hs.Add("ProductCategoryID", proInfo.ProductCategoryID);
            hs.Add("ClassificationID", proInfo.ClassificationID);
            hs.Add("MinOrder", proInfo.MinOrder);
            hs.Add("TypeOfUnit", proInfo.TypeOfUnit);
            hs.Add("PalletTypeID", proInfo.PalletTypeID);
            hs.Add("ItemExpiredTypeID", proInfo.ItemExpiredTypeID);
            hs.Add("ShelfLife", proInfo.ShelfLife);
            hs.Add("SafetyStock", proInfo.SafetyStock);
            hs.Add("UnitLevelReceivingLabel", proInfo.UnitLevelReceivingLabel);
            hs.Add("LotControl", proInfo.LotControl);
            hs.Add("KanbanControl", proInfo.KanbanControl);
            hs.Add("FreeOfCharge", proInfo.FreeOfCharge);
            hs.Add("EstimateValue", proInfo.EstimateValue);
            hs.Add("Remark", proInfo.Remark);
            hs.Add("IsShowGrossWeight", proInfo.IsShowGrossWeight);
            hs.Add("PackingTime", proInfo.PackingTime);
            hs.Add("PrepareTime", proInfo.PrepareTime);
            hs.Add("PalletizeTime", proInfo.PalletizeTime);
            hs.Add("ShipTagType", proInfo.ShipTagTypeID);
            hs.Add("WeightMinimumOrder", proInfo.WeightMinimumOrder);
            hs.Add("M3MinimumOrder", proInfo.M3MinimumOrder);
            hs.Add("isSpecial", proInfo.isSpecial);

            if (proInfo.ImageFile != null)
            {
                hs.Add("ImageFile", proInfo.ImageFile);
            }
            else
            {
                hs.Add("ImageFile", new System.Byte[1]);
            }

            if (proInfo.QCImageFile != null)
            {
                hs.Add("QCImageFile", proInfo.QCImageFile);
            }
            else
            {
                hs.Add("QCImageFile", new System.Byte[1]);
            }

            hs.Add("CurrentUser", proInfo.CurrentUser);

            //Sale Price
            hs.Add("CustomerID", proInfo.CustomerID);
            hs.Add("SalePrice", proInfo.SalePrice);
            hs.Add("CurrencyID_Sale", proInfo.CurrencyID_Sale);
            hs.Add("EffectiveDate_Sale", proInfo.EffectiveDate_Sale);
            if (proInfo.ImplementDate_Sale != null)
            {
                hs.Add("ImplementDate_Sale", proInfo.ImplementDate_Sale);
            }
            else
            {
                hs.Add("ImplementDate_Sale", DBNull.Value);
            }
            hs.Add("Incoterm_Sale", proInfo.Incoterm_Sale);
            hs.Add("HSCode", proInfo.HSCode);
            hs.Add("PVID", proInfo.PVID);
            hs.Add("Remark_Sale", proInfo.Remark_Sale);

            //Purchase Price
            hs.Add("PurchasePrice", proInfo.PurchasePrice);
            hs.Add("CurrencyID_Purchase", proInfo.CurrencyID_Purchase);
            hs.Add("Incoterm_Purchase", proInfo.Incoterm_Purchase);
            hs.Add("EffectiveDate_Purchase", proInfo.EffectiveDate_Purchase);
            if (proInfo.ImplementDate_Purchase != null)
            {
                hs.Add("ImplementDate_Purchase", proInfo.ImplementDate_Purchase);
            }
            else
            {
                hs.Add("ImplementDate_Purchase", DBNull.Value);
            }
            hs.Add("Remark_Purchase", proInfo.Remark_Purchase);
            

            hs.Add("TransitXML", proInfo.TransitXML);
            hs.Add("CargoXML", proInfo.CargoXML);
            hs.Add("PackingXML", proInfo.PackingXML);
            Database.ExecuteNonQuery("sp_XMSS050_Product_Save", hs);
        }

        public DataSet LoadComboBoxData()
        {
            try
            {
                return Database.ExecuteDataSet("sp_XMSS050_Product_InitComboBox");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet DataLoadingDetail(int ProductID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ProductID", ProductID);

                return Database.ExecuteDataSet("sp_XMSS050_Product_SearchDetail", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean CheckExistProduct(int OwnerID, int? ProductID, string ProductCode)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("OwnerID", OwnerID);
                hs.Add("ProductID", ProductID);
                hs.Add("ProductCode", ProductCode);

                return Convert.ToInt32(Database.ExecuteScalar("sp_XMSS050_Product_CheckExist", hs)) == 1 ? true : false ;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean CheckReference(int ProductID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ProductID", ProductID);
                return Convert.ToInt32(Database.ExecuteScalar("sp_XMSS050_Product_CheckReference", hs)) == 1 ? true : false;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void DeleteData(int? ProductID, String CurrentUser)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ProductID", ProductID);
                hs.Add("CurrentUser", CurrentUser);
                Database.ExecuteNonQuery("sp_XMSS050_Product_Delete", hs);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public byte[] LoadImage(int ProductID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ProductID", ProductID);

                return (byte[])Database.ExecuteDataSet("sp_XMSS050_Product_LoadImage", hs).Tables[0].Rows[0]["ImageFile"];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public byte[] LoadQCImage(string ProductCode)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ProductCode", ProductCode);

                return (byte[])Database.ExecuteDataSet("sp_XMSS050_Product_LoadQCImage", hs).Tables[0].Rows[0]["QCPicture"];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
