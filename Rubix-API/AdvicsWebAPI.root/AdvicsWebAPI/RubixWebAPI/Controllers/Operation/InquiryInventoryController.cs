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
    public class InquiryInventoryController : ApiController
    {
        InquiryInventory obj = new InquiryInventory();

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DataLoading(int? OwnerID, int? WarehouseID, int? ZoneID, int? ProductID, int? ProductConditionID, int? Location)
        {
            List<sp_ESTS030_InquiryInventory_SearchAll_Result> ResultReturn;
            try
            {
                ResultReturn = obj.DataLoading(OwnerID, WarehouseID, ZoneID, ProductID, ProductConditionID, Location);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }
            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetInventoryStatus(int? OwnerID, int? WarehouseID, int? ProductID, int? ProductConditionID, string ProductCode)
        {
            sp_ESTS000_InventoryStatusProcess_Result ResultReturn;
            try
            {
                ResultReturn = obj.GetInventoryStatus(OwnerID,
                                                       WarehouseID,
                                                       ProductID,
                                                       ProductConditionID,
                                                       ProductCode);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }
            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DataLoadingByItem(int? OwnerID, int? WarehouseID, int? ZoneID, int? ProductID, int? ProductConditionID)
        {
            List<sp_ESTS030_InquiryInventory_ByItem_SearchAll_Result> ResultReturn;
            try
            {
                ResultReturn = obj.DataLoadingByItem(OwnerID,
                                                       WarehouseID,
                                                       ZoneID,
                                                       ProductID,
                                                       ProductConditionID,
                                                       null, null);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }
            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        //[HttpPost, HttpGet, APIAuthorize]
        //public HttpResponseMessage DataLoadingByItemDataTable(int? OwnerID, int? WarehouseID, int? ProductID, int? ProductConditionID, bool? IgnorePrefix)
        //{
        //    DataTable ResultReturn;
        //    try
        //    {
        //        ResultReturn = obj.DataLoadingByItemDataTable(OwnerID, WarehouseID, ProductID, ProductConditionID, IgnorePrefix, null, null);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
        //    }
        //    return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        //}
    }
}