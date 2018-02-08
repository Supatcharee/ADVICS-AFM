using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using System.Data;
using CSI.Business;
using System.Collections;
using Newtonsoft.Json;
using System.IO;
using System.Drawing;
using Rubix.Framework;
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
        public DateTime ImplementDate_Sale;
        public string Incoterm_Sale;
        public string HSCode;
        public int? PVID;
        public string Remark_Sale;

        //Purchase
        public Decimal? PurchasePrice;
        public int CurrencyID_Purchase;
        public string Incoterm_Purchase;
        public DateTime EffectiveDate_Purchase;
        public DateTime ImplementDate_Purchase;
        public string Remark_Purchase;

    }

    public class ProductInfomation
    {
        //Header
        public int? ProductID{ get; set; }
        public int? OwnerID{ get; set; }
        public int? ProductTypeID{ get; set; }
        public string Model{ get; set; }
        public string ProductCode{ get; set; }
        public string ProductShortCode{ get; set; }
        public string ProductName{ get; set; }
        public int? ProductGroupID{ get; set; }
        public int? SupplierID{ get; set; }
        public int? ProductCategoryID{ get; set; }
        public int? ClassificationID{ get; set; }
        public int? MinOrder{ get; set; }
        public int? TypeOfUnit{ get; set; }
        public int? PalletTypeID{ get; set; }
        public int? ItemExpiredTypeID{ get; set; }
        public int? ShelfLife{ get; set; }
        public decimal? SafetyStock{ get; set; }
        public int? UnitLevelReceivingLabel{ get; set; }
        public int? LotControl{ get; set; }
        public int? KanbanControl{ get; set; }
        public int? FreeOfCharge{ get; set; }
        public decimal? EstimateValue{ get; set; }
        public string Remark{ get; set; }
        public byte[] ImageFile{ get; set; }
        public byte[] QCImageFile { get; set; }
        public string CurrentUser{ get; set; }
        public bool IsShowGrossWeight { get; set; }
        public decimal? PackingTime { get; set; }
        public decimal? PrepareTime { get; set; }
        public decimal? PalletizeTime { get; set; }
        public int? ShipTagTypeID { get; set; }
        public decimal? WeightMinimumOrder { get; set; }
        public decimal? M3MinimumOrder { get; set; }
        public int? isSpecial { get; set; }

        //XML
        public string TransitXML{ get; set; }
        public string CargoXML{ get; set; }
        public string PackingXML{ get; set; }

        //Sale
        public int? CustomerID{ get; set; }
        public Decimal? SalePrice{ get; set; }
        public int CurrencyID_Sale{ get; set; }
        public DateTime EffectiveDate_Sale{ get; set; }
        public DateTime? ImplementDate_Sale{ get; set; }
        public string Incoterm_Sale{ get; set; }
        public string HSCode{ get; set; }
        public int? PVID{ get; set; }
        public string Remark_Sale{ get; set; }

        //Purchase
        public Decimal? PurchasePrice{ get; set; }
        public int CurrencyID_Purchase{ get; set; }
        public string Incoterm_Purchase{ get; set; }
        public DateTime EffectiveDate_Purchase{ get; set; }
        public DateTime? ImplementDate_Purchase{ get; set; }
        public string Remark_Purchase{ get; set; }


    }

    public class Product
    {
        #region Member
        
        #endregion

        #region Properties
        public int? ProductID { get; set; }
        public string ProductCode { get; set; }
        public DataRow SelectedRow { get; set; }
        
        #endregion

        public DataTable DataLoading(int? OwnerID, String ProductCode, String ProductName, int? SupplierID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("ProductCode", ProductCode);
            hs.Add("ProductName", ProductName);
            hs.Add("SupplierID", SupplierID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Product/DataLoading", hs);
                return JsonConvert.DeserializeObject<DataTable>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet DataLoadingDetail(int ProductID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ProductID", ProductID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Product/DataLoadingDetail", hs);
                return JsonConvert.DeserializeObject<DataSet>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public byte[] LoadImage(int ProductID)
        {
            //-------------------------------------------------------------------------
            ControlUtil.LMethod = "LoadImage(int ProductID)";
            ControlUtil.LStart = "START";
            ControlUtil.LStartCurrentDateDate = DateTime.Now.ToString("dd/MM/yy HH:mm:ss tt");
            ControlUtil.LParameter = "ProductID = "+ ProductID;
            ControlUtil.LogFileStart(ControlUtil.LMethod, ControlUtil.LStart, ControlUtil.LStartCurrentDateDate, ControlUtil.LParameter);
            //----------------------------------------------------------------------------
            Hashtable hs = new Hashtable();
            hs.Add("ProductID", ProductID);

            try
            {
                //---------------------------------------------------------
                ControlUtil.LParameter = String.Format("ProductID = {0};API/BusinessFactory/Product/LoadImage", ProductID);
                //---------------------------------------------------------

                string strResult = RubixWebAPI.ExecuteObjectResult("Product/LoadImage", hs);
                //---------------------------------------------------------
                ControlUtil.LEnd = "END";
                ControlUtil.LEndCurrentDate = DateTime.Now.ToString("dd/MM/yy HH:mm:ss tt");
                ControlUtil.LogFileEnd(ControlUtil.LMethod, ControlUtil.LEnd, ControlUtil.LEndCurrentDate);
                //---------------------------------------------------------
                return JsonConvert.DeserializeObject<byte[]>(strResult);
            }
            catch (Exception ex)
            {
                //-------------------------------------------------------------------------------------------------------
                ControlUtil.LMethod = "Exception --> LoadImage(int ProductID)";
                ControlUtil.LStart = "Start Exception";
                ControlUtil.LStartCurrentDateDate = DateTime.Now.ToString("dd/MM/yy HH:mm:ss tt");
                ControlUtil.LParameter = String.Format("Exception Message is {0}; StackTrace is {1}", ex.Message, ex.StackTrace);
                ControlUtil.LogFileStart(ControlUtil.LMethod, ControlUtil.LStart, ControlUtil.LStartCurrentDateDate, ControlUtil.LParameter);

                ControlUtil.LEnd = "End Exception";
                ControlUtil.LEndCurrentDate = DateTime.Now.ToString("dd/MM/yy HH:mm:ss tt");
                ControlUtil.LogFileEnd(ControlUtil.LMethod, ControlUtil.LEnd, ControlUtil.LEndCurrentDate);
                //-----------------------------------------------------------------------------------------------------

                throw ex;
            }
            
        }

        public byte[] LoadQCImage(string ProductCode)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ProductCode", ProductCode);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Product/LoadQCImage", hs);
                return JsonConvert.DeserializeObject<byte[]>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet LoadMaterial(int? ProductID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ProductID", ProductID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Product/LoadMaterial", hs);
                return JsonConvert.DeserializeObject<DataSet>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet LoadComboBoxData()
        {
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Product/LoadComboBoxData");
                return JsonConvert.DeserializeObject<DataSet>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveData(ProductInfomation productInfo)
        {
            try
            {
                RubixWebAPI.ExecuteObjectResult("Product/SaveData", JsonConvert.SerializeObject(productInfo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean CheckExistProduct(int OwnerID, int? ProductID, String ProductCode)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("ProductID", ProductID);
            hs.Add("ProductCode", ProductCode);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Product/CheckExistProduct", hs);
                return JsonConvert.DeserializeObject<Boolean>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean CheckReference(int? ProductID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ProductID", ProductID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Product/CheckReference", hs);
                return JsonConvert.DeserializeObject<Boolean>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteData(int? ProductID, String CurrentUser)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ProductID", ProductID);
            hs.Add("CurrentUser", CurrentUser);

            try
            {
                RubixWebAPI.ExecuteObjectResult("Product/DeleteData", hs);

                //return JsonConvert.DeserializeObject<Boolean>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //try
            //{
            //    RubixWebAPI.ExecuteObjectResult("Product/DeleteData", JsonConvert.SerializeObject(ProductID));
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }
    }
}
