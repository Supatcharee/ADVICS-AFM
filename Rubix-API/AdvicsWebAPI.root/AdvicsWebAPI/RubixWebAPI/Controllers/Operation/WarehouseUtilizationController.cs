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
using Rubix.Framework;

namespace RubixWebAPI.Controllers.Operation
{
    public class WarehouseUtilizationController : ApiController
    {
        WarehouseUtilization obj = new WarehouseUtilization();
        
        //[HttpPost, HttpGet, APIAuthorize]
        //public HttpResponseMessage GetSummary(int WarehouseID)
        //{

        //    List<sp_ESTS070_InquiryWarehouseUtilization_Get_Result> ResultReturn;
        //    try
        //    {
        //        ResultReturn = obj.GetSummary(WarehouseID);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
        //    }

        //    return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        //}

        //[HttpPost, HttpGet, APIAuthorize]
        //public HttpResponseMessage GetDetail(int WarehouseID, int? ZoneID)
        //{
        //    List<sp_ESTS070_InquiryWarehouseUtilization_Detail_Get_Result> ResultReturn;
        //    try
        //    {
        //        ResultReturn = obj.GetDetail(WarehouseID, ZoneID);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
        //    }

        //    return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        //}

        //[HttpPost, HttpGet, APIAuthorize]
        //public HttpResponseMessage GetPageInfo(string LayoutWarehouse)
        //{
        //    List<sp_ESTS070_InquiryWarehouseUtilization_PageInfo_Get_Result> ResultReturn;
        //    try
        //    {
        //        ResultReturn = obj.GetPageInfo(LayoutWarehouse);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
        //    }

        //    return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        //}

        //[HttpPost, HttpGet, APIAuthorize]
        //public HttpResponseMessage GetZoneDetail(int WarehouseID, int ZoneID, string LocationPrefix)
        //{
        //    List<sp_ESTS070_InquiryWarehouseUtilization_Zone_Detail_Get_Result> ResultReturn;
        //    try
        //    {
        //        ResultReturn = obj.GetZoneDetail(WarehouseID, ZoneID, LocationPrefix);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
        //    }

        //    return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        //}

        //[HttpPost, HttpGet, APIAuthorize]
        //public HttpResponseMessage GetWarehouseLayout(string LayoutWarehouse, int Page)
        //{
        //    ObjectResult<sp_ESTS070_InquiryWarehouseUtilization_GetLayout_Result> ResultReturn;
        //    try
        //    {
        //        ResultReturn = obj.GetWarehouseLayout(LayoutWarehouse, Page);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
        //    }
        //    return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        //}

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage SpaceUtilization_Load(int WarehouseID)
        {
            DataSet ResultReturn;
            try
            {
                ResultReturn = obj.SpaceUtilization_Load(WarehouseID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }
            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }
    }
}