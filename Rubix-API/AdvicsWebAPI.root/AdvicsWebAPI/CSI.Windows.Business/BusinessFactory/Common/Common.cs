/*
 * 20130117:
 * 1. add config for get whether show qty level1
 * 22 Jan 2013: 
 * 1. add new class for manage unit convert
 * 23 Jan 2013:
 * 1. modify DataLoading of class Shipment
 * 30 Jan 2013:
 * 1. add new class for validate date
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using System.Data;
using System.Collections;
using System.Transactions;
using Rubix.Framework;
namespace CSI.Business.Common
{
    public class Classification
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

        public ObjectResult<sp_common_LoadClassification_Result> DataLoading(int? CustomerID)
        {
            return Database.CommonEntity.sp_common_LoadClassification(CustomerID);
        }
    }

    public class Owner
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

        public ObjectResult<sp_common_LoadOwner_Result> DataLoading(int? WarehouseID)
        {
            return Database.CommonEntity.sp_common_LoadOwner(WarehouseID);
        }
    }

    public class Customer
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

        public ObjectResult<sp_common_LoadCustomer_Result> DataLoading(int? CustomerID,int? OwnerID)
        {
            return Database.CommonEntity.sp_common_LoadCustomer(CustomerID,OwnerID);
        }
    }


    public class FinalDestination
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

        public ObjectResult<sp_common_LoadFinalDestination_Result> DataLoading(int? CustomerID)
        {
            return Database.CommonEntity.sp_common_LoadFinalDestination(ownerID:  null, customerID: CustomerID);
        }
        public ObjectResult<sp_common_LoadFinalDestination_Result> DataLoading(int? OwnerID, int? CustomerID)
        {
            return Database.CommonEntity.sp_common_LoadFinalDestination(ownerID: OwnerID, customerID: CustomerID);
        }
    }

    public class Packaging
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

        public ObjectResult<sp_common_LoadPackaging_Result> DataLoading()
        {
            return Database.CommonEntity.sp_common_LoadPackaging();
        }

        public tbm_Package GetPackage(string PackageCode)
        {
            return Database.MasterEntity.tbm_Package.SingleOrDefault(c => c.PackageCode == PackageCode);
        }

        public ObjectResult<sp_common_LoadPackingNo_Result> PackingNoDataLoading(string ShipmentNo, DateTime? ShippingDateFrom, DateTime? ShippingDateTo, DateTime? PackingDateFrom, DateTime? PackingDateTo, List<int?> StatusIDList)
        {
            DataTable dt = new DataTable("dtStatus");
            DataSet ds = new DataSet("dsStatus");

            dt.Columns.Add("StatusID", typeof(int));

            if (StatusIDList != null && StatusIDList.Count != 0)
            {
                foreach (int status in StatusIDList)
                {
                    dt.Rows.Add(status);
                }
            }
            ds.Tables.Add(dt);

            return Database.CommonEntity.sp_common_LoadPackingNo(ShipmentNo, ShippingDateFrom, ShippingDateTo, PackingDateFrom, PackingDateTo, ds.GetXml());
        }

    }

    public class Product
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

        public ObjectResult<sp_common_LoadProduct_Result> DataLoading(int? OwnerID)
        {
            return Database.CommonEntity.sp_common_LoadProduct(OwnerID);
        }
        public DataTable LoadSalePrice(int? ProductID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ProductID", ProductID);
                DataTable tb = Database.ExecuteDataSet("sp_common_LoadSalePrice", hs).Tables[0];
                return tb;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public tbm_Product GetProductInfo(string productCode)
        {
            return GetProductInfo(productCode, null);
        }
        public tbm_Product GetProductInfo(string productCode, int? OwnerID)
        {
            tbm_Product result = null;
            tbm_Product prd = Database.MasterEntity.tbm_Product.SingleOrDefault(c => c.ProductCode == productCode && c.DeleteFlag == 0 && (!OwnerID.HasValue || c.OwnerID == OwnerID));
            if (prd != null)
            {
                result = DataUtil.CopyEntity(prd);
            }
            return result;
        }

        public bool IsUnitInProduct(int productID, int unitID)
        {
            tbm_ProductDefaultUnit pdu = Database.MasterEntity.tbm_ProductDefaultUnit.FirstOrDefault(c => c.ProductID == productID);
            if (pdu == null)
                return false;
            if (pdu.TypeOfUnitLevel1.HasValue && pdu.TypeOfUnitLevel1.Value == unitID)
                return true;
            if (pdu.TypeOfUnitLevel2.HasValue && pdu.TypeOfUnitLevel2.Value == unitID)
                return true;
            if (pdu.TypeOfUnitLevel3.HasValue && pdu.TypeOfUnitLevel3.Value == unitID)
                return true;
            if (pdu.TypeOfUnitLevel4.HasValue && pdu.TypeOfUnitLevel4.Value == unitID)
                return true;
            return false;
        }
        public bool IsProductOK(int productID)
        {
            tbm_ProductDefaultUnit pdu = Database.MasterEntity.tbm_ProductDefaultUnit.FirstOrDefault(c => c.ProductID == productID);
            if (pdu == null)
                return false;
            if (pdu.TypeOfUnitInventory.HasValue &&
                (
                (pdu.TypeOfUnitLevel1.HasValue && pdu.TypeOfUnitInventory.Value == pdu.TypeOfUnitLevel1.Value)
                || (pdu.TypeOfUnitLevel2.HasValue && pdu.TypeOfUnitInventory.Value == pdu.TypeOfUnitLevel2.Value)
                || (pdu.TypeOfUnitLevel3.HasValue && pdu.TypeOfUnitInventory.Value == pdu.TypeOfUnitLevel3.Value)
                || (pdu.TypeOfUnitLevel4.HasValue && pdu.TypeOfUnitInventory.Value == pdu.TypeOfUnitLevel4.Value)
                ))
                return true;
            return false;
        }

        public bool IsPackageInProduct(int productID, int packageID)
        {
            tbm_ProductDefaultUnit pdu = Database.MasterEntity.tbm_ProductDefaultUnit.FirstOrDefault(c => c.ProductID == productID && c.PackageID == packageID);
            if (pdu == null)
                return false;
            return true;
        }
    }

    public class ProductPrice
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

        public ObjectResult<sp_common_LoadProductPrice_Result> DataLoading(int? OwnerID, int? WarehouseID, int? SupplierID, string PriceType)
        {
            ObjectResult<sp_common_LoadProductPrice_Result> ob = Database.CommonEntity.sp_common_LoadProductPrice(OwnerID, WarehouseID, SupplierID, PriceType);
            return ob;
        }
        //public DataTable LoadSalePrice(int? ProductID)
        //{
        //    try
        //    {
        //        Hashtable hs = new Hashtable();
        //        hs.Add("ProductID", ProductID);
        //        DataTable tb = Database.ExecuteDataSet("sp_common_LoadSalePrice", hs).Tables[0];
        //        return tb;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

        public tbm_Product GetProductInfo(string productCode)
        {
            return GetProductInfo(productCode, null);
        }
        public tbm_Product GetProductInfo(string productCode, int? OwnerID)
        {
            tbm_Product result = null;
            tbm_Product prd = Database.MasterEntity.tbm_Product.FirstOrDefault(c => c.ProductCode == productCode && c.DeleteFlag == 0 && (!OwnerID.HasValue || c.OwnerID == OwnerID));
            if (prd != null)
            {
                result = DataUtil.CopyEntity(prd);
            }
            return result;
        }

        public bool IsUnitInProduct(int productID, int unitID)
        {
            tbm_ProductDefaultUnit pdu = Database.MasterEntity.tbm_ProductDefaultUnit.FirstOrDefault(c => c.ProductID == productID);
            if (pdu == null)
                return false;
            if (pdu.TypeOfUnitLevel1.HasValue && pdu.TypeOfUnitLevel1.Value == unitID)
                return true;
            if (pdu.TypeOfUnitLevel2.HasValue && pdu.TypeOfUnitLevel2.Value == unitID)
                return true;
            if (pdu.TypeOfUnitLevel3.HasValue && pdu.TypeOfUnitLevel3.Value == unitID)
                return true;
            if (pdu.TypeOfUnitLevel4.HasValue && pdu.TypeOfUnitLevel4.Value == unitID)
                return true;
            return false;
        }
        public bool IsProductOK(int productID)
        {
            tbm_ProductDefaultUnit pdu = Database.MasterEntity.tbm_ProductDefaultUnit.FirstOrDefault(c => c.ProductID == productID);
            if (pdu == null)
                return false;
            if (pdu.TypeOfUnitInventory.HasValue &&
                (
                (pdu.TypeOfUnitLevel1.HasValue && pdu.TypeOfUnitInventory.Value == pdu.TypeOfUnitLevel1.Value)
                || (pdu.TypeOfUnitLevel2.HasValue && pdu.TypeOfUnitInventory.Value == pdu.TypeOfUnitLevel2.Value)
                || (pdu.TypeOfUnitLevel3.HasValue && pdu.TypeOfUnitInventory.Value == pdu.TypeOfUnitLevel3.Value)
                || (pdu.TypeOfUnitLevel4.HasValue && pdu.TypeOfUnitInventory.Value == pdu.TypeOfUnitLevel4.Value)
                ))
                return true;
            return false;
        }

        public bool IsPackageInProduct(int productID, int packageID)
        {
            tbm_ProductDefaultUnit pdu = Database.MasterEntity.tbm_ProductDefaultUnit.FirstOrDefault(c => c.ProductID == productID && c.PackageID == packageID);
            if (pdu == null)
                return false;
            return true;
        }
    }

    public class TypeOfUnit
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

        public tbm_TypeOfUnit GetUnitInfo(string unitCode)
        {                       
            return Database.MasterEntity.tbm_TypeOfUnit.SingleOrDefault(c => c.UnitCode == unitCode);
        }

        public DataSet LoadUnitSale(int? ProductID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ProductID", ProductID);
                return Database.ExecuteDataSet("sp_common_LoadUnit_Sale", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet LoadUnitPurchase(int? ProductID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ProductID", ProductID);
                return Database.ExecuteDataSet("sp_common_LoadUnit_Purchase", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LoadTypeOfUnit()
        {
            try
            {
                return Database.ExecuteDataSet("sp_common_LoadTypeOfUnit").Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public class ProductCondition
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

        public ObjectResult<sp_common_LoadProductCondition_Result> DataLoading()
        {
            return DataLoading(productID: null);
        }
        public ObjectResult<sp_common_LoadProductCondition_Result> DataLoading(int? productID)
        {
            return Database.CommonEntity.sp_common_LoadProductCondition(productID: productID);
        }
        public tbm_ProductCondition GetProductConditionInfo(string productConditionCode)
        {
            return Database.MasterEntity.tbm_ProductCondition.SingleOrDefault(c => c.ProductConditionCode == productConditionCode);
        }
        public tbm_ProductCondition GetProductConditionInfoByID(int productConditionID)
        {
            return Database.MasterEntity.tbm_ProductCondition.SingleOrDefault(c => c.ProductConditionID == productConditionID);
        }
    }
    
    public class Picking
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

        public ObjectResult<sp_common_LoadPickingNo_Result> DataLoading(String ShipmentNo, List<int?> StatusIDList)
        {
            DataTable dt = new DataTable("dtStatus");
            DataSet ds = new DataSet("dsStatus");

            dt.Columns.Add("StatusID", typeof(int));

            if (StatusIDList != null && StatusIDList.Count != 0)
            {
                foreach (int status in StatusIDList)
                {
                    dt.Rows.Add(status);
                }
            }
            ds.Tables.Add(dt);

            return Database.CommonEntity.sp_common_LoadPickingNo(ShipmentNo, ds.GetXml());
        }

        public ObjectResult<sp_ISHS060_LoadPickingNo_Result> DataLoading(int? OwnerID, int? WarehouseID)
        {
            return Database.ShippingEntity.sp_ISHS060_LoadPickingNo(OwnerID, WarehouseID);
        }

        public DataTable CheckStatus(string XmlCheckBookStatus)
        {
            Hashtable hs = new Hashtable();
            hs.Add("XmlCheckBookStatus", XmlCheckBookStatus);

            try
            {
                return Database.ExecuteDataSet("sp_common_CheckStatusPicking_ForBooking", hs).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public class Supplier
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

        public ObjectResult<sp_common_LoadSupplier_Result> DataLoading(int? OwnerID)
        {
            return Database.CommonEntity.sp_common_LoadSupplier(OwnerID);
        }
    }

    public class TruckCompany
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

        public ObjectResult<sp_common_LoadTruckCompany_Result> DataLoading()
        {
            return Database.CommonEntity.sp_common_LoadTruckCompany();
        }
    }

    public class ProductGroup
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

        public ObjectResult<sp_common_LoadProductGroup_Result> DataLoading()
        {
            return Database.CommonEntity.sp_common_LoadProductGroup();
        }
    }

    public class ItemCategory
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

        public ObjectResult<sp_common_LoadProductCategory_Result> DataLoading(int? ProductGroupID)
        {
            return Database.CommonEntity.sp_common_LoadProductCategory(ProductGroupID);
        }
    }
    public class Warehouse
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

        public ObjectResult<sp_common_LoadWarehouse_Result> DataLoading(int? OwnerID)
        {
            return Database.CommonEntity.sp_common_LoadWarehouse(OwnerID);
        }
    }

    public class Zone
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

        public ObjectResult<sp_common_LoadZone_Result> DataLoading(int? OwnerID, int? WarehouseID, int? Floor)
        {
            return Database.CommonEntity.sp_common_LoadZone(OwnerID, WarehouseID, Floor);
        }
    }

    public class ScanType
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

        public ObjectResult<sp_common_LoadScanType_Result> DataLoading()
        {
            return Database.CommonEntity.sp_common_LoadScanType();
        }
    }

    public class Shipment
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

        public ObjectResult<sp_common_LoadShippingNo_Result> DataLoading(int? OwnerID, int? CustomerID, DateTime? ShippingDateFrom, DateTime? ShippingDateTo
                                                                        , DateTime? PickDateFrom, DateTime? PickDateTo
                                                                        , DateTime? PackingDateFrom, DateTime? PackingDateTo, List<int?> StatusIDList)
        {
            DataTable dt = new DataTable("dtStatus");
            DataSet ds = new DataSet("dsStatus");

            dt.Columns.Add("StatusID", typeof(int));

            if (StatusIDList != null && StatusIDList.Count !=0)
            {
                foreach (int status in StatusIDList)
                {
                    dt.Rows.Add(status);
                }
            }            
            ds.Tables.Add(dt);

            return Database.CommonEntity.sp_common_LoadShippingNo(OwnerID, CustomerID, ShippingDateFrom, ShippingDateTo, PickDateFrom, PickDateTo, PackingDateFrom, PackingDateTo, ds.GetXml());
        }
    }

    public class TransportType
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

        public ObjectResult<sp_common_LoadTransportType_Result> DataLoading(int? truckCompanyID)
        {
            return Database.CommonEntity.sp_common_LoadTransportType(truckCompanyID);
        }
    }

    public class PortInformation
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

        public ObjectResult<sp_common_LoadPortOfDischarge_Result> LoadPortOfDischarge()
        {
            return Database.CommonEntity.sp_common_LoadPortOfDischarge();
        }

        public ObjectResult<sp_common_LoadPortOfLoading_Result> LoadPortOfLoading()
        {
            return Database.CommonEntity.sp_common_LoadPortOfLoading();
        }

        public ObjectResult<sp_common_LoadPort_Result> LoadPort()
        {
            return Database.CommonEntity.sp_common_LoadPort();
        }
    }

    public class LotInformation
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

        public ObjectResult<sp_common_LoadLot_Result> DataLoading(int? ProductID, int? warehouseID)
        {
            return Database.CommonEntity.sp_common_LoadLot(productID: ProductID, warehouseID: warehouseID);

        }

        public ObjectResult<sp_common_LoadLotByLocation_Result> DataLoadingByLocation(int? ProductID, int? warehouseID)
        {
            return Database.CommonEntity.sp_common_LoadLotByLocation(productID: ProductID, warehouseID: warehouseID);

        }

    }

    public class User
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

        public ObjectResult<sp_common_LoadUser_Result> DataLoading()
        {
            return Database.CommonEntity.sp_common_LoadUser();
        }
    }
    public class ShipmentArea
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

        public ObjectResult<sp_common_LoadShipmentArea_Result> DataLoading(int? DCID)
        {
            return Database.CommonEntity.sp_common_LoadShipmentArea(DCID);
        }
    }

    public class Location
    {
        public ObjectResult<sp_common_LoadLocation_Result> DataLoading(int? OwnerID, int? WarehouseID, int? ZoneID)
        {
            return Database.CommonContext.sp_common_LoadLocation(ownerID: OwnerID, warehouseID: WarehouseID, zoneID: ZoneID);
        }
    }

    public class Receive
    {
        public ObjectResult<sp_common_LoadReceiving_Result> DataLoading(int? OwnerID, int? warehouseID)
        {
            return Database.CommonContext.sp_common_LoadReceiving(ownerID: OwnerID, warehouseID: warehouseID);
        }
    }

    public class Pallet
    {
        public ObjectResult<sp_common_LoadPallet_Result> DataLoading(int? OwnerID, int? warehouseID, string receivingNo)
        {
            return Database.CommonContext.sp_common_LoadPallet(ownerID: OwnerID, warehouseID: warehouseID, receivingNo: receivingNo);
        }
    }

    public class SystemConfig
    {
        public static tbs_SystemConfig LoadConfig(string configItem)
        {
            ObjectQuery<tbs_SystemConfig> query = (ObjectQuery<tbs_SystemConfig>)Database.CommonContext.tbs_SystemConfig.Where(c => c.ConfigItem == configItem);
            return query.Execute(MergeOption.NoTracking).SingleOrDefault();
        }
        
        public static string ReadConfigString(string configItem)
        {
            tbs_SystemConfig config = Common.SystemConfig.LoadConfig(configItem);
            if (config != null)
            {
                return config.ConfigValue;
            }
            return string.Empty;
        }
        
        public static int MaxPackagePerProduct()
        {
            tbs_SystemConfig config = Common.SystemConfig.LoadConfig("MaxPackagePerProduct");
            if (config != null)
            {
                int result;
                if (int.TryParse(config.ConfigValue, out result))
                    return result;
            }
            return 1;
        }
       
        public static string GetShowQtyLevel1()
        {
            tbs_SystemConfig config = Common.SystemConfig.LoadConfig("ShowQtyLevel1");
            if (config != null)
            {
                return config.ConfigValue;
            }
            return string.Empty;
        }
        
        public static string GetDefaultLV1Unit()
        {

            tbs_SystemConfig config = Common.SystemConfig.LoadConfig("DefaultLV1UnitID");
            if (config != null)
            {
                return config.ConfigValue;
            }
            return string.Empty;
        }
    }

    public class Attention 
    {
        public List<sp_common_LoadAttention_Result> DataLoading(int OwnerID)
        {
            List<sp_common_LoadAttention_Result> list = Database.CommonContext.sp_common_LoadAttention(ownerID: OwnerID).ToList();
            
            // split comma if exist
            List<string> uniqueAttention = new List<string>();
            foreach (sp_common_LoadAttention_Result data in list)
            {
                string[] attentionList = data.attention.Split(',');
                foreach (string s in attentionList)
                {
                    if (false == uniqueAttention.Contains(s.Trim()))
                    {
                        uniqueAttention.Add(s.Trim());
                    }
                }
            }

            // generate return list
            List<sp_common_LoadAttention_Result> returnList = new List<sp_common_LoadAttention_Result>();
            foreach (string s in uniqueAttention)
            {
                sp_common_LoadAttention_Result data = new sp_common_LoadAttention_Result { attention = s };
                returnList.Add(data);
            }
            return returnList;
        }

        public string GetOwnerName(int OwnerID)
        {
            tbm_Owner owner = Database.MasterContext.tbm_Owner.FirstOrDefault(c => c.OwnerID == OwnerID);
            if (owner != null)
            {
                return owner.OwnerName;
            }
            else
            {
                return string.Empty;
            }
        }
    }

    public class UnitConvert
    {
        public static decimal? GetRatioToInventoryUnit(int? fromUnitId, int? productId)
        {
            return Database.CommonContext.sp_GetUnitConvertRatio(fromUnitID: fromUnitId, productID: productId).Single().Ratio;
        }
    }

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

        public DataTable DataLoading()
        {
            return null;
            //return Database.CommonEntity.sp_common_LoadSalePrice();
        }
    }
    
    public class DateValidator
    {
        public static bool IsTrancyValidTransactionDate(DateTime? transactionDate, bool canAdvance)
        {
            bool noError = true;

            if (transactionDate != null && transactionDate.HasValue)
            {
                DateTime firstDateInCurrentMonth = Database.GetFirstDateOfCurrentMonth();
                if (transactionDate.Value.Date.CompareTo(firstDateInCurrentMonth) >= 0)
                {
                    if (false == canAdvance)
                    {
                        DateTime currentDate = Database.GetSystemDate();
                        // 18 Feb 2013: Comment for temp input advance one day transaction
                        //if (transactionDate.Value.Date.CompareTo(currentDate) > 0)
                        if (transactionDate.Value.Date.CompareTo(currentDate/*.AddDays(1)*/) > 0)
                        // end 18 Feb 2013
                        {
                            // transaction date has not come
                            noError = false;
                        }
                    }

                }
                else // transaction is in previous month
                {
                    // 18 Feb 2013: Comment for temp input past transaction
                    //noError = false;
                    // end 18 Feb 2013
                }
            }
            else  // transaction date is null 
            { 
                noError = false;
            }

            return noError;
        }

        public static bool IsTrancyValidTransactionDate(DateTime? transactionDate)
        {
            return IsTrancyValidTransactionDate(transactionDate, false);
        }

    }
}
