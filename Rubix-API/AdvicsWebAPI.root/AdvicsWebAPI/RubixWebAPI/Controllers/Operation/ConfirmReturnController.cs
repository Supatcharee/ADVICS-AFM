using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using CSI.Business.BusinessFactory.Operation;
using System.Data.Objects;
using CSI.Business.DataObjects;
using System.Net.Http;
using System.Net;
using System.Data;
using Newtonsoft.Json;

namespace RubixWebAPI.Controllers.Operation
{
    public class ConfirmReturnController : ApiController
    {
        ConfirmReturn obj = new ConfirmReturn();

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage Search(int? OwnerID, int? WarehouseID, string shipmentNo, string pickingNo, DateTime? shipFrom, DateTime? shipTo)
        {
            List<sp_ISHS070_ReturnPick_Get_Result> ResultReturn;

            try 
            {
                ResultReturn = obj.Search(OwnerID, WarehouseID, shipmentNo, pickingNo, shipFrom, shipTo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetDetail(string shipmentNo, string pickingNo, int productID)
        {
            sp_ISHS071_ReturnPick_Get_Result ResultReturn;

            try
            {
                ResultReturn = obj.GetDetail(shipmentNo, pickingNo, productID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LoadDefaultTransitConfirm(int locationID)
        {
            sp_DSRS010_ConfirmProductStoring_LoadStockByLocation_Result ResultReturn;

            try
            {
                ResultReturn = obj.LoadDefaultTransitConfirm(locationID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage Confirm(string shipmentNo, string pickingNo, int lineNo, int OwnerID,
                                    int WarehouseID, int productID, string lotNo, string palletNo, string user)
        {

            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            List<ConfirmReturn> detail = JsonConvert.DeserializeObject<List<ConfirmReturn>>(strParameterData);

            try
            {
                obj.Confirm(shipmentNo, pickingNo, lineNo, OwnerID, WarehouseID, productID, lotNo, palletNo, detail, user);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

    }
}