using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using CSI.Business.Operation;
using System.Data.Objects;
using CSI.Business.DataObjects;
using System.Net.Http;
using System.Net;
using System.Data;
using Newtonsoft.Json;

namespace RubixWebAPI.Controllers.Operation
{
    public class CorrectInventoryController : ApiController
    {
        CorrectInventory obj = new CorrectInventory();

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DataLoading(int? OwnerID, int? WarehouseID, string ReceivingNo, int? ProductID, string PalletNo)
        {
            List<sp_ESTS010_InventoryAdjustment_SearchAll_Result> ResultReturn;

            try
            {
                ResultReturn = obj.DataLoading(OwnerID, WarehouseID, ReceivingNo, ProductID, PalletNo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetInventoryStatus(int? OwnerID, int? WarehouseID, int? ProductID, int? ProductConditionID)
        {
            sp_ESTS000_InventoryStatusProcess_Result ResultReturn;

            try
            {
                ResultReturn = obj.GetInventoryStatus(OwnerID, WarehouseID, ProductID, ProductConditionID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage SaveStockMoveMent(int? OwnerID, int? WarehouseID, String RefSlipNo, int? ProductID,
                                                    int? ProductConditionID, String Action, decimal? Adjustment, String PalletNo)
        {
            try
            {
                obj.SaveStockMoveMent(OwnerID, WarehouseID, RefSlipNo, ProductID, ProductConditionID, Action, Adjustment, PalletNo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage SaveStockByLocation(int? OwnerID, int? WarehouseID, int? LocationID, int? ProductID,
                                                        int? ProductConditionID, String PalletNo, decimal? AfterAdjustment)
        {
            try
            {
                obj.SaveStockByLocation(OwnerID, WarehouseID, LocationID, ProductID, ProductConditionID, PalletNo, AfterAdjustment);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage SaveStockHistory(int? OwnerID, int? WarehouseID, String RefSlipNo, int? ProductID, int? ProductConditionID,
                                                    int? LocationID, String Action, decimal? Adjustment, decimal? AfterAdjustment)
        {
            try
            {
                obj.SaveStockHistory(OwnerID, WarehouseID, RefSlipNo, ProductID, ProductConditionID, LocationID, Action, Adjustment, AfterAdjustment);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
        
        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage SaveData(int? OwnerID, int? WarehouseID, string ReceivingNo, int? ProductID, int? ProductConditionID,
                                            int? LocationID, string LotNo, decimal? Adjustment, bool FullCapacity,
                                            String PalletNo, String UpdateUser, DateTime? ExpiredDate, String CreateUser,
                                            String Remark)
        {
            try
            {
                obj.SaveData(OwnerID, WarehouseID, ReceivingNo, ProductID, ProductConditionID, LocationID, LotNo, Adjustment, FullCapacity, PalletNo, UpdateUser, ExpiredDate, CreateUser, Remark);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
   
        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LoadZone(int? OwnerID, int? WarehouseID, int? Floor)
        {
            DataTable ResultReturn;

            try
            {
                ResultReturn = obj.LoadZone(OwnerID, WarehouseID, Floor);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LoadRack(int? ZoneID)
        {
            DataTable ResultReturn;

            try
            {
                ResultReturn = obj.LoadRack(ZoneID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LoadLocationCode(int? ZoneID)
        {
            DataTable ResultReturn;

            try
            {
                ResultReturn = obj.LoadLocationCode(ZoneID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LoadLocationID(String LocationCode)
        {
            int? ResultReturn;

            try
            {
                ResultReturn = obj.LoadLocationID(LocationCode);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LoadLotNo(int OwnerID, int WarehouseID, int LocationID, int ProductID, int ProductConditionID)
        {
            DataTable ResultReturn;

            try
            {
                ResultReturn = obj.LoadLotNo(OwnerID, WarehouseID, LocationID, ProductID, ProductConditionID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LoadZoneByItem(int OwnerID, int WarehouseID, int ProductID)
        {
            DataTable ResultReturn;

            try
            {
                ResultReturn = obj.LoadZoneByItem(OwnerID, WarehouseID, ProductID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }
        
        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LoadDefaultUnit()
        {
            DataTable ResultReturn;

            try
            {
                ResultReturn = obj.LoadDefaultUnit();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LoadAllDefaultUnit(int ProductID)
        {
            DataTable ResultReturn;

            try
            {
                ResultReturn = obj.LoadAllDefaultUnit(ProductID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetConvertRatio(int? ConvertFrom, int ConvertTo, int? ProductID)
        {
            decimal? ResultReturn;

            try
            {
                ResultReturn = obj.GetConvertRatio(ConvertFrom, ConvertTo, ProductID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LoadExpiryDate(String palletNo)
        {
            DateTime? ResultReturn;

            try
            {
                ResultReturn = obj.LoadExpiryDate(palletNo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }
    }
}