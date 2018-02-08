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
using Newtonsoft.Json;
namespace CSI.Business.Common
{
    public class LastestDaily
    {
        public DataTable LastestDailyPost()
        {
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Common/LastestDailyPost");
                return JsonConvert.DeserializeObject<DataTable>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public class Classification
    {
        public List<sp_common_LoadClassification_Result> DataLoading(int? OwnerID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Common/ClassificationDataLoading", hs);
                return JsonConvert.DeserializeObject<List<sp_common_LoadClassification_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public class Owner
    {
        public List<sp_common_LoadOwner_Result> DataLoading(int? WarehouseID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("WarehouseID", WarehouseID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Common/OwnerDataLoading", hs);
                return JsonConvert.DeserializeObject<List<sp_common_LoadOwner_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public class Customer
    {
        public List<sp_common_LoadCustomer_Result> DataLoading(int? CustomerID, int? OwnerID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("CustomerID", CustomerID);
            hs.Add("OwnerID", OwnerID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Common/CustomerDataLoading", hs);
                return JsonConvert.DeserializeObject<List<sp_common_LoadCustomer_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    
    public class FinalDestination
    {
        public List<sp_common_LoadFinalDestination_Result> DataLoading(int? OwnerID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Common/FinalDestinationDataLoading", hs);
                return JsonConvert.DeserializeObject<List<sp_common_LoadFinalDestination_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<sp_common_LoadFinalDestination_Result> DataLoading(int? OwnerID, int? CustomerID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("CustomerID", CustomerID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Common/FinalDestinationDataLoading", hs);
                return JsonConvert.DeserializeObject<List<sp_common_LoadFinalDestination_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public class Packaging
    {
        public List<sp_common_LoadPackaging_Result> DataLoading()
        {
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Common/PackagingDataLoading");
                return JsonConvert.DeserializeObject<List<sp_common_LoadPackaging_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<sp_common_LoadPackingNo_Result> PackingNoDataLoading(string ShipmentNo, DateTime? ShippingDateFrom, DateTime? ShippingDateTo, DateTime? PackingDateFrom, DateTime? PackingDateTo, List<int?> StatusIDList)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ShipmentNo", ShipmentNo);
                hs.Add("ShippingDateFrom", ShippingDateFrom);
                hs.Add("ShippingDateTo", ShippingDateTo);
                hs.Add("PackingDateFrom", PackingDateFrom);
                hs.Add("PackingDateTo", PackingDateTo);
                string strResult = RubixWebAPI.ExecuteObjectResult("Common/PackingNoDataLoading", hs, JsonConvert.SerializeObject(StatusIDList));
                return JsonConvert.DeserializeObject<List<sp_common_LoadPackingNo_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public tbm_Package GetPackage(string PackageCode)
        {
            Hashtable hs = new Hashtable();
            hs.Add("PackageCode", PackageCode);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Common/PackagingGetPackage", hs);
                return JsonConvert.DeserializeObject<tbm_Package>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public class Product
    {
        public List<sp_common_LoadProduct_Result> DataLoading(int? OwnerID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Common/ProductDataLoading", hs);
                return JsonConvert.DeserializeObject<List<sp_common_LoadProduct_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public tbm_Product GetProductInfo(string ProductCode)
        {
            return GetProductInfo(ProductCode, null);
        }

        public tbm_Product GetProductInfo(string ProductCode, int? OwnerID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ProductCode", ProductCode);
            hs.Add("OwnerID", OwnerID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Common/ProductGetProductInfo", hs);
                return JsonConvert.DeserializeObject<tbm_Product>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IsUnitInProduct(int ProductID, int UnitID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ProductID", ProductID);
            hs.Add("UnitID", UnitID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Common/ProductIsUnitInProduct", hs);
                return JsonConvert.DeserializeObject<bool>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IsProductOK(int ProductID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ProductID", ProductID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Common/ProductIsProductOK", hs);
                return JsonConvert.DeserializeObject<bool>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IsPackageInProduct(int ProductID, int PackageID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ProductID", ProductID);
            hs.Add("PackageID", PackageID); 

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Common/ProductIsPackageInProduct", hs);
                return JsonConvert.DeserializeObject<bool>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }

    public class ProductPrice
    {
        public List<sp_common_LoadProductPrice_Result> DataLoading(int? OwnerID, int? WarehouseID, int? SupplierID,string PriceType)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("SupplierID", SupplierID);
            hs.Add("PriceType", PriceType);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Common/ProductPriceDataLoading", hs);
                return JsonConvert.DeserializeObject<List<sp_common_LoadProductPrice_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public tbm_Product GetProductInfo(string ProductCode)
        {
            return GetProductInfo(ProductCode, null);
        }

        public tbm_Product GetProductInfo(string ProductCode, int? OwnerID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ProductCode", ProductCode);
            hs.Add("OwnerID", OwnerID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Common/ProductGetProductInfo", hs);
                return JsonConvert.DeserializeObject<tbm_Product>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IsUnitInProduct(int ProductID, int UnitID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ProductID", ProductID);
            hs.Add("UnitID", UnitID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Common/ProductIsUnitInProduct", hs);
                return JsonConvert.DeserializeObject<bool>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IsProductOK(int ProductID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ProductID", ProductID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Common/ProductIsProductOK", hs);
                return JsonConvert.DeserializeObject<bool>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IsPackageInProduct(int ProductID, int PackageID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ProductID", ProductID);
            hs.Add("PackageID", PackageID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Common/ProductIsPackageInProduct", hs);
                return JsonConvert.DeserializeObject<bool>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public class TypeOfUnit
    {
        public tbm_TypeOfUnit GetUnitInfo(string UnitCode)
        {
            Hashtable hs = new Hashtable();
            hs.Add("UnitCode", UnitCode);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Common/TypeOfUnitGetUnitInfo", hs);
                return JsonConvert.DeserializeObject<tbm_TypeOfUnit>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet LoadUnitSale(int? ProductID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ProductID", ProductID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Common/LoadUnitSale", hs);
                return JsonConvert.DeserializeObject<DataSet>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet LoadUnitPurchase(int? ProductID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ProductID", ProductID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Common/LoadUnitPurchase", hs);
                return JsonConvert.DeserializeObject<DataSet>(strResult);
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
                string strResult = RubixWebAPI.ExecuteObjectResult("Common/LoadTypeOfUnit");
                return JsonConvert.DeserializeObject<DataTable>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public class ProductCondition
    {
        public List<sp_common_LoadProductCondition_Result> DataLoading()
        {
            return DataLoading(ProductID: null);
        }

        public List<sp_common_LoadProductCondition_Result> DataLoading(int? ProductID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ProductID", ProductID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Common/ProductConditionDataLoading", hs);
                return JsonConvert.DeserializeObject<List<sp_common_LoadProductCondition_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public tbm_ProductCondition GetProductConditionInfo(string ProductConditionCode)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ProductConditionCode", ProductConditionCode);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Common/ProductConditionGetProductConditionInfo", hs);
                return JsonConvert.DeserializeObject<tbm_ProductCondition>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public tbm_ProductCondition GetProductConditionInfoByID(int ProductConditionID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ProductConditionID", ProductConditionID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Common/ProductConditionGetProductConditionInfoByID", hs);
                return JsonConvert.DeserializeObject<tbm_ProductCondition>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    
    public class Picking
    {
        public List<sp_common_LoadPickingNo_Result> DataLoading(String ShipmentNo, List<int?> StatusIDList)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ShipmentNo", ShipmentNo);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Common/PickingDataLoading", hs, JsonConvert.SerializeObject(StatusIDList));
                return JsonConvert.DeserializeObject<List<sp_common_LoadPickingNo_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<sp_common_LoadPickingNo_Result> DataLoading(int? OwnerID, int? WarehouseID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Common/PickingDataLoading", hs);
                return JsonConvert.DeserializeObject<List<sp_common_LoadPickingNo_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public class Supplier
    {
        public List<sp_common_LoadSupplier_Result> DataLoading(int? OwnerID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Common/SupplierDataLoading", hs);
                return JsonConvert.DeserializeObject<List<sp_common_LoadSupplier_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public class TruckCompany
    {
        public List<sp_common_LoadTruckCompany_Result> DataLoading()
        {
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Common/TruckCompanyDataLoading");
                return JsonConvert.DeserializeObject<List<sp_common_LoadTruckCompany_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public class ProductGroup
    {

        public List<sp_common_LoadProductGroup_Result> DataLoading()
        {
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Common/ProductGroupDataLoading");
                return JsonConvert.DeserializeObject<List<sp_common_LoadProductGroup_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public class ItemCategory
    {
        public List<sp_common_LoadProductCategory_Result> DataLoading(/*int? ItemCateID,*/int? ProductGroupID)
        {
            Hashtable hs = new Hashtable();
            //hs.Add("ItemCateID", ItemCateID);
            hs.Add("ProductGroupID", ProductGroupID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Common/ItemCategoryDataLoading", hs);
                return JsonConvert.DeserializeObject<List<sp_common_LoadProductCategory_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public class Warehouse
    {
        public List<sp_common_LoadWarehouse_Result> DataLoading(int? OwnerID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Common/WarehouseDataLoading", hs);
                return JsonConvert.DeserializeObject<List<sp_common_LoadWarehouse_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public class Zone
    {
        public List<sp_common_LoadZone_Result> DataLoading(int? OwnerID, int? WarehouseID, int? Floor)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("Floor", Floor);
            
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Common/ZoneDataLoading", hs);
                return JsonConvert.DeserializeObject<List<sp_common_LoadZone_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public class ScanType
    {
        public List<sp_common_LoadScanType_Result> DataLoading()
        {
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Common/ScanTypeDataLoading");
                return JsonConvert.DeserializeObject<List<sp_common_LoadScanType_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public class Shipment
    {
        public List<sp_common_LoadShippingNo_Result> DataLoading(int? OwnerID, int? CustomerID, DateTime? ShippingDateFrom, DateTime? ShippingDateTo, DateTime? PickDateFrom, DateTime? PickDateTo, DateTime? PackingDateFrom, DateTime? PackingDateTo, List<int?> StatusIDList)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("CustomerID", CustomerID);
            hs.Add("ShippingDateFrom", ShippingDateFrom);
            hs.Add("ShippingDateTo", ShippingDateTo);
            hs.Add("PickDateFrom", PickDateFrom);
            hs.Add("PickDateTo", PickDateTo);
            hs.Add("PackingDateFrom", PackingDateFrom);
            hs.Add("PackingDateTo", PackingDateTo);
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Common/ShipmentDataLoading", hs, JsonConvert.SerializeObject(StatusIDList));
                return JsonConvert.DeserializeObject<List<sp_common_LoadShippingNo_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public class TransportType
    {
        public List<sp_common_LoadTransportType_Result> DataLoading(int? TruckCompanyID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("TruckCompanyID", TruckCompanyID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Common/TransportTypeDataLoading", hs);
                return JsonConvert.DeserializeObject<List<sp_common_LoadTransportType_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public class PortInformation
    {
        public List<sp_common_LoadPortOfDischarge_Result> LoadPortOfDischarge()
        {
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Common/PortInformationLoadPortOfDischarge");
                return JsonConvert.DeserializeObject<List<sp_common_LoadPortOfDischarge_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<sp_common_LoadPortOfLoading_Result> LoadPortOfLoading()
        {
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Common/PortInformationLoadPortOfLoading");
                return JsonConvert.DeserializeObject<List<sp_common_LoadPortOfLoading_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<sp_common_LoadPort_Result> LoadPort()
        {
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Common/PortInformationLoadPort");
                return JsonConvert.DeserializeObject<List<sp_common_LoadPort_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public class LotInformation
    {
        public List<sp_common_LoadLot_Result> DataLoading(int? ProductID, int? WarehouseID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ProductID", ProductID);
            hs.Add("WarehouseID", WarehouseID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Common/LotInformationDataLoading", hs);
                return JsonConvert.DeserializeObject<List<sp_common_LoadLot_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
        
    public class User
    {
        public List<sp_common_LoadUser_Result> DataLoading()
        {
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Common/UserDataLoading");
                return JsonConvert.DeserializeObject<List<sp_common_LoadUser_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public class ShipmentArea
    {
        public List<sp_common_LoadShipmentArea_Result> DataLoading(int? WarehouseID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("WarehouseID", WarehouseID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Common/ShipmentAreaDataLoading", hs);
                return JsonConvert.DeserializeObject<List<sp_common_LoadShipmentArea_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public class Location
    {
        public List<sp_common_LoadLocation_Result> DataLoading(int? OwnerID)
        {
            return DataLoading(OwnerID, null, null);
        }

        public List<sp_common_LoadLocation_Result> DataLoading(int? OwnerID, int? WarehouseID)
        {
            return DataLoading(OwnerID, WarehouseID, null);
        }

        public List<sp_common_LoadLocation_Result> DataLoading(int? OwnerID, int? WarehouseID, int? ZoneID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("ZoneID", ZoneID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Common/LocationDataLoading", hs);
                return JsonConvert.DeserializeObject<List<sp_common_LoadLocation_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public class Receive
    {
        public List<sp_common_LoadReceiving_Result> DataLoading(int? OwnerID, int? WarehouseID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Common/ReceiveDataLoading", hs);
                return JsonConvert.DeserializeObject<List<sp_common_LoadReceiving_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public class Pallet
    {
        public List<sp_common_LoadPallet_Result> DataLoading(int? OwnerID, int? WarehouseID, string ReceivingNo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("ReceivingNo", ReceivingNo);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Common/PalletDataLoading", hs);
                return JsonConvert.DeserializeObject<List<sp_common_LoadPallet_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public class SystemConfig
    {
        public static string ReadConfigString(string ConfigItem)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ConfigItem", ConfigItem);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Common/SystemConfigReadConfigString", hs);
                return JsonConvert.DeserializeObject<string>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public static string GetShowQtyLevel1()
        {
            return ReadConfigString("ShowQtyLevel1");
        }        

        public static string GetDefaultLV1Unit()
        {
            return ReadConfigString("DefaultLV1UnitID");
        }
    }

    public class Attention 
    {
        public List<sp_common_LoadAttention_Result> DataLoading(int OwnerID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Common/AttentionDataLoading", hs);
                return JsonConvert.DeserializeObject<List<sp_common_LoadAttention_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetOwnerName(int OwnerID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Common/AttentionGetOwnerName", hs);
                return JsonConvert.DeserializeObject<string>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public class UnitConvert
    {
        public static decimal? GetRatioToInventoryUnit(int? FromUnitID, int? ProductID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("FromUnitID", FromUnitID);
            hs.Add("ProductID", ProductID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Common/UnitConvertGetRatioToInventoryUnit", hs);
                return JsonConvert.DeserializeObject<decimal?>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public class Status
    {
        public static int NewSaleOrder = 1;
        public static int ConfirmSaleOrder = 5;
        public static int NewPurchaseOrder = 10;
        public static int ConfirmPurchaseOrder = 15;
        public static int NewReceivingEntry = 20;
        public static int ReceiveInstrunctionIssued = 40;
        public static int IncompleteReceiving = 50;
        public static int CompleteReceiving = 55;
        public static int CompleteTransit = 60;
        public static int NewShippingEntry= 65;
        public static int StockHold = 70;
        public static int PickingInstructionIssued = 75;        
        public static int InCompletePicking = 80;
        public static int CompletePicking = 85;
        public static int PackingInnstructionIssued = 100;
        public static int InCompletePacking = 105;
        public static int CompletePacking = 110;
        public static int DocumentShippingIssued = 130;
        public static int InCompleteShipping = 140;
        public static int CompleteShipping = 145;
        public static int DeliveryNoteIssued = 147;
        public static int CompleteSaleOrder = 150;
        public static int OrderCancel = 160;

    }

    public class DateValidator
    {
        public static bool IsTrancyValidTransactionDate(DateTime? TransactionDate, bool CanAdvance)
        {
            Hashtable hs = new Hashtable();
            hs.Add("TransactionDate", TransactionDate);
            hs.Add("CanAdvance", CanAdvance);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Common/DateValidatorIsTrancyValidTransactionDate", hs);
                return JsonConvert.DeserializeObject<bool>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool IsTrancyValidTransactionDate(DateTime? TransactionDate)
        {
            return IsTrancyValidTransactionDate(TransactionDate, false);
        }

    }


    public class LotByLocationInformation
    {

        public List<sp_common_LoadLotByLocation_Result> DataLoading(int? ProductID, int? WarehouseID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ProductID", ProductID);
            hs.Add("WarehouseID", WarehouseID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Common/LotByLocationInformationDataLoading", hs);
                return JsonConvert.DeserializeObject<List<sp_common_LoadLotByLocation_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
