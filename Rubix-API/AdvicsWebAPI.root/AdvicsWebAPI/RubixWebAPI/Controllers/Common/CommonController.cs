using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using CSI.Business.Common;
using System.Data.Objects;
using CSI.Business.DataObjects;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using Rubix.Framework;
using System.Data;
using CSI.Business;

namespace RubixWebAPI.Controllers.Common
{
    public class CommonController : ApiController
    {  
        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LastestDailyPost()
        {
            BusinessCommon bu = new BusinessCommon();

            DataTable ResultReturn;
            try
            {
                ResultReturn = bu.LastestDailyPost();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage ClassificationDataLoading(int? OwnerID)
        {
            Classification cs = new Classification();

            ObjectResult<sp_common_LoadClassification_Result> ResultReturn;
            try
            {
                ResultReturn = cs.DataLoading(OwnerID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet]
        public HttpResponseMessage OwnerDataLoading(int? WarehouseID)
        {
            Owner ow = new Owner();
            ObjectResult<sp_common_LoadOwner_Result> ResultReturn;
            try
            {
                ResultReturn = ow.DataLoading(WarehouseID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage CustomerDataLoading(int? CustomerID, int? OwnerID)
        {
            Customer cs = new Customer();
            ObjectResult<sp_common_LoadCustomer_Result> ResultReturn;
            try
            {
                ResultReturn = cs.DataLoading(CustomerID, OwnerID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage FinalDestinationDataLoading(int? OwnerID)
        {
            FinalDestination obj = new FinalDestination();
            ObjectResult<sp_common_LoadFinalDestination_Result> ResultReturn;
            try
            {
                ResultReturn = obj.DataLoading(OwnerID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage FinalDestinationDataLoading(int? OwnerID, int? CustomerID)
        {
            FinalDestination obj = new FinalDestination();
            ObjectResult<sp_common_LoadFinalDestination_Result> ResultReturn;
            try
            {
                ResultReturn = obj.DataLoading(OwnerID, CustomerID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage PackagingDataLoading()
        {
            Packaging obj = new Packaging();
            ObjectResult<sp_common_LoadPackaging_Result> ResultReturn;
            try
            {
                ResultReturn = obj.DataLoading();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage PackingNoDataLoading(string ShipmentNo, DateTime? ShippingDateFrom, DateTime? ShippingDateTo, DateTime? PackingDateFrom, DateTime? PackingDateTo)
        {
            Packaging obj = new Packaging();
            ObjectResult<sp_common_LoadPackingNo_Result> ResultReturn;
            try
            {
                string strParameterData = Request.Content.ReadAsStringAsync().Result;
                List<int?> StatusIdList = JsonConvert.DeserializeObject<List<int?>>(strParameterData);
                ResultReturn = obj.PackingNoDataLoading(ShipmentNo, ShippingDateFrom, ShippingDateTo, PackingDateFrom, PackingDateTo, StatusIdList);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }
        
        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage PackagingGetPackage(string PackageCode)
        {
            Packaging obj = new Packaging();
            tbm_Package tbm = new tbm_Package();
            tbm_Package ResultReturn;
            try
            {
                ResultReturn = obj.GetPackage(PackageCode);
                tbm = DataUtil.CopyEntity(ResultReturn, tbm);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, tbm);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage ProductDataLoading(int? OwnerID)
        {
            Product obj = new Product();
            ObjectResult<sp_common_LoadProduct_Result> ResultReturn;
            try
            {
                ResultReturn = obj.DataLoading(OwnerID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage ProductGetProductInfo(string ProductCode, int? OwnerID)
        {
            Product obj = new Product();
            tbm_Product ResultReturn;
            try
            {
                ResultReturn = obj.GetProductInfo(ProductCode, OwnerID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage ProductIsUnitInProduct(int ProductID, int UnitID)
        {
            Product obj = new Product();
            Boolean ResultReturn;
            try
            {
                ResultReturn = obj.IsUnitInProduct(ProductID, UnitID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage ProductIsProductOK(int ProductID)
        {
            Product obj = new Product();
            Boolean ResultReturn;
            try
            {
                ResultReturn = obj.IsProductOK(ProductID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage ProductIsPackageInProduct(int ProductID, int PackageID)
        {
            Product obj = new Product();
            Boolean ResultReturn;
            try
            {
                ResultReturn = obj.IsPackageInProduct(ProductID, PackageID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage TypeOfUnitGetUnitInfo(string UnitCode)
        {
            TypeOfUnit obj = new TypeOfUnit();
            tbm_TypeOfUnit ResultReturn;
            tbm_TypeOfUnit tbm = new tbm_TypeOfUnit();
            try
            {
                ResultReturn = obj.GetUnitInfo(UnitCode);
                tbm = DataUtil.CopyEntity(ResultReturn, tbm);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, tbm);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage ProductConditionDataLoading(int? ProductID)
        {
            ProductCondition obj = new ProductCondition();
            ObjectResult<sp_common_LoadProductCondition_Result> ResultReturn;
            try
            {
                ResultReturn = obj.DataLoading(ProductID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage ProductConditionGetProductConditionInfo(string ProductConditionCode)
        {
            ProductCondition obj = new ProductCondition();
            tbm_ProductCondition ResultReturn;
            tbm_ProductCondition ResultReturnCopy;
            try
            {
                ResultReturn = obj.GetProductConditionInfo(ProductConditionCode);

                ResultReturnCopy = DataUtil.CopyEntity(ResultReturn);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturnCopy);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage ProductConditionGetProductConditionInfoByID(int ProductConditionID)
        {
            ProductCondition obj = new ProductCondition();
            tbm_ProductCondition ResultReturn;
            try
            {
                ResultReturn = obj.GetProductConditionInfoByID(ProductConditionID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage PickingDataLoading(String ShipmentNo)
        {
            Picking obj = new Picking();
            ObjectResult<sp_common_LoadPickingNo_Result> ResultReturn;
            try
            {
                string strParameterData = Request.Content.ReadAsStringAsync().Result;
                List<int?> StatusIdList = JsonConvert.DeserializeObject<List<int?>>(strParameterData);

                ResultReturn = obj.DataLoading(ShipmentNo, StatusIdList);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage PickingDataLoading(int? OwnerID, int? WarehouseID)
        {
            Picking obj = new Picking();
            ObjectResult<sp_ISHS060_LoadPickingNo_Result> ResultReturn;
            try
            {
                ResultReturn = obj.DataLoading(OwnerID, WarehouseID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage SupplierDataLoading(int? OwnerID)
        {
            Supplier obj = new Supplier();
            ObjectResult<sp_common_LoadSupplier_Result> ResultReturn;
            try
            {
                ResultReturn = obj.DataLoading(OwnerID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage TruckCompanyDataLoading()
        {
            TruckCompany obj = new TruckCompany();
            ObjectResult<sp_common_LoadTruckCompany_Result> ResultReturn;
            try
            {
                ResultReturn = obj.DataLoading();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage ProductGroupDataLoading()
        {
            ProductGroup obj = new ProductGroup();
            ObjectResult<sp_common_LoadProductGroup_Result> ResultReturn;
            try
            {
                ResultReturn = obj.DataLoading();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage ItemCategoryDataLoading(int? ProductGroupID)
        {
            ItemCategory obj = new ItemCategory();
            ObjectResult<sp_common_LoadProductCategory_Result> ResultReturn;
            try
            {
                ResultReturn = obj.DataLoading(ProductGroupID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet] //ไม่มี authorize เพราะว่าใช้ในหน้า login
        public HttpResponseMessage WarehouseDataLoading(int? OwnerID)
        {
            Warehouse obj = new Warehouse();
            ObjectResult<sp_common_LoadWarehouse_Result> ResultReturn;
            try
            {
                ResultReturn = obj.DataLoading(OwnerID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage ZoneDataLoading(int? OwnerID, int? WarehouseID, int? Floor)
        {
            Zone obj = new Zone();
            ObjectResult<sp_common_LoadZone_Result> ResultReturn;
            try
            {
                ResultReturn = obj.DataLoading(OwnerID, WarehouseID, Floor);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage ScanTypeDataLoading()
        {
            ScanType obj = new ScanType();
            ObjectResult<sp_common_LoadScanType_Result> ResultReturn;
            try
            {
                ResultReturn = obj.DataLoading();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage ShipmentDataLoading(int? OwnerID, int? CustomerID, DateTime? ShippingDateFrom, DateTime? ShippingDateTo, DateTime? PickDateFrom, DateTime? PickDateTo, DateTime? PackingDateFrom, DateTime? PackingDateTo)
        {
            Shipment obj = new Shipment();
            ObjectResult<sp_common_LoadShippingNo_Result> ResultReturn;

            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            List<int?> StatusIdList = JsonConvert.DeserializeObject<List<int?>>(strParameterData);

            try
            {
                ResultReturn = obj.DataLoading(OwnerID, CustomerID, ShippingDateFrom, ShippingDateTo, PickDateFrom, PickDateTo, PackingDateFrom, PackingDateTo, StatusIdList);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage TransportTypeDataLoading(int? TruckCompanyID)
        {
            CSI.Business.Common.TransportType obj = new CSI.Business.Common.TransportType();
            ObjectResult<sp_common_LoadTransportType_Result> ResultReturn;

            try
            {
                ResultReturn = obj.DataLoading(TruckCompanyID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage PortInformationLoadPortOfDischarge()
        {
            PortInformation obj = new PortInformation();
            ObjectResult<sp_common_LoadPortOfDischarge_Result> ResultReturn;

            try
            {
                ResultReturn = obj.LoadPortOfDischarge();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage PortInformationLoadPortOfLoading()
        {
            PortInformation obj = new PortInformation();
            ObjectResult<sp_common_LoadPortOfLoading_Result> ResultReturn;

            try
            {
                ResultReturn = obj.LoadPortOfLoading();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage PortInformationLoadPort()
        {
            PortInformation obj = new PortInformation();
            ObjectResult<sp_common_LoadPort_Result> ResultReturn;

            try
            {
                ResultReturn = obj.LoadPort();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }
           
        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LotInformationDataLoading(int? ProductID, int? WarehouseID)
        {
            LotInformation obj = new LotInformation();
            ObjectResult<sp_common_LoadLot_Result> ResultReturn;

            try
            {
                ResultReturn = obj.DataLoading(ProductID, WarehouseID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LotByLocationInformationDataLoading(int? ProductID, int? WarehouseID)
        {
            LotInformation obj = new LotInformation();
            ObjectResult<sp_common_LoadLotByLocation_Result> ResultReturn;

            try
            {
                ResultReturn = obj.DataLoadingByLocation(ProductID, WarehouseID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage UserDataLoading()
        {
            User obj = new User();
            ObjectResult<sp_common_LoadUser_Result> ResultReturn;

            try
            {
                ResultReturn = obj.DataLoading();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage ShipmentAreaDataLoading(int? WarehouseID)
        {
            ShipmentArea obj = new ShipmentArea();
            ObjectResult<sp_common_LoadShipmentArea_Result> ResultReturn;

            try
            {
                ResultReturn = obj.DataLoading(WarehouseID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LocationDataLoading(int? OwnerID, int? WarehouseID, int? ZoneID)
        {
            Location obj = new Location();
            ObjectResult<sp_common_LoadLocation_Result> ResultReturn;

            try
            {
                ResultReturn = obj.DataLoading(OwnerID, WarehouseID, ZoneID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage ReceiveDataLoading(int? OwnerID, int? WarehouseID)
        {
            Receive obj = new Receive();
            ObjectResult<sp_common_LoadReceiving_Result> ResultReturn;

            try
            {
                ResultReturn = obj.DataLoading(OwnerID, WarehouseID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage PalletDataLoading(int? OwnerID, int? WarehouseID, string ReceivingNo)
        {
            Pallet obj = new Pallet();
            ObjectResult<sp_common_LoadPallet_Result> ResultReturn;

            try
            {
                ResultReturn = obj.DataLoading(OwnerID, WarehouseID, ReceivingNo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }
                
        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage SystemConfigReadConfigString(string ConfigItem)
        {
            String ResultReturn;

            try
            {
                ResultReturn = SystemConfig.ReadConfigString(ConfigItem);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }
        
        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage AttentionDataLoading(int OwnerID)
        {
            Attention obj = new Attention();
            List<sp_common_LoadAttention_Result> ResultReturn;

            try
            {
                ResultReturn = obj.DataLoading(OwnerID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage AttentionGetOwnerName(int OwnerID)
        {
            Attention obj = new Attention();
            string ResultReturn;

            try
            {
                ResultReturn = obj.GetOwnerName(OwnerID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }
        
        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage UnitConvertGetRatioToInventoryUnit(int? FromUnitID, int? ProductID)
        {
            decimal? ResultReturn;

            try
            {
                ResultReturn = UnitConvert.GetRatioToInventoryUnit(FromUnitID, ProductID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DateValidatorIsTrancyValidTransactionDate(DateTime? TransactionDate, bool CanAdvance)
        {
            bool ResultReturn;

            try
            {
                ResultReturn = DateValidator.IsTrancyValidTransactionDate(TransactionDate, CanAdvance);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LoadUnitSale(int? ProductID)
        {
            DataSet ResultReturn;
            TypeOfUnit obj = new TypeOfUnit();
            try
            {
                ResultReturn = obj.LoadUnitSale(ProductID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LoadUnitPurchase(int? ProductID)
        {
            DataSet ResultReturn;
            TypeOfUnit obj = new TypeOfUnit();
            try
            {
                ResultReturn = obj.LoadUnitPurchase(ProductID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LoadTypeOfUnit()
        {
            DataTable ResultReturn;
            TypeOfUnit obj = new TypeOfUnit();
            try
            {
                ResultReturn = obj.LoadTypeOfUnit();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage ProductPriceDataLoading(int? OwnerID, int? WarehouseID, int? SupplierID, string PriceType)
        {
            ProductPrice obj = new ProductPrice();
            //
            ObjectResult<sp_common_LoadProductPrice_Result> ResultReturn;
            try
            {
                ResultReturn = obj.DataLoading(OwnerID, WarehouseID, SupplierID, PriceType);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage CheckStatus()
        {
            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            string XmlCheckBookStatus = JsonConvert.DeserializeObject<string>(strParameterData);
            Picking obj = new Picking();
            DataTable ResultReturn;
            try
            {
                ResultReturn = obj.CheckStatus(XmlCheckBookStatus);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }
            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

    }
}