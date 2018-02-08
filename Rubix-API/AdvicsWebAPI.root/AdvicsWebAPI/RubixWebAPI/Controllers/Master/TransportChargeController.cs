using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using CSI.Business.Master;
using System.Data.Objects;
using CSI.Business.DataObjects;
using System.Net.Http;
using System.Net;
using System.Data;
using Newtonsoft.Json;

namespace RubixWebAPI.Controllers.Master
{
    public class TransportChargeController : ApiController
    {
        struct TransportChargeStruct
        {
            public sp_XMSS190_TransportCharge_SearchAll_Result ResultData;
            public string resultXML;
        }
        TransportCharge obj = new TransportCharge();

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DataLoading(int? OwnerID, int? WarehouseID, int? CustomerID)
        {
            ObjectResult<sp_XMSS190_TransportCharge_SearchAll_Result> ResultReturn;

            try
            {
                ResultReturn = obj.DataLoading(OwnerID, WarehouseID, CustomerID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);

        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LoadDialog(int OwnerID, int WarehouseID, DateTime EffectiveDate, int TruckCompID, int CustomerID)
        {
            List<sp_XMSS190_TransportCharge_SearchByCondition_Result> ResultReturn;

            try
            {
                ResultReturn = obj.LoadDialog(OwnerID, WarehouseID, EffectiveDate, TruckCompID, CustomerID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LoadTransportCharge(int? OwnerID, int CustomerID, int TruckCompanyID)
        {
            DataTable ResultReturn;

            try
            {
                ResultReturn = obj.LoadTransportCharge(OwnerID, CustomerID, TruckCompanyID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        //[HttpPost, HttpGet, APIAuthorize]
        //public HttpResponseMessage GetFinalDestinationID(int? iOwnerIID, int? CustomerID)
        //{
        //    List<sp_XMSS190_TransportCharge_GetFinalDestinationID_Result> ResultReturn;

        //    obj.CustomerID = CustomerID;

        //    try
        //    {
        //        ResultReturn = obj.GetFinalDestinationID(iOwnerIID);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
        //    }

        //    return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        //}

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetTransportTypeID(String strTransportTypeName, int? TruckCompanyID)
        {
            DataTable ResultReturn;
            obj.TruckCompanyID = TruckCompanyID;

            try
            {
                ResultReturn = obj.GetTransportTypeID(strTransportTypeName);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage SaveTransportChargeData()
        {
            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            TransportChargeStruct stc = JsonConvert.DeserializeObject<TransportChargeStruct>(strParameterData);

            obj.ResultData = stc.ResultData;

            try
            {
                obj.SaveTransportChargeData(stc.resultXML);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage Delete(int OwnerID, int WarehouseID, DateTime EffectiveDate)
        {
            obj.OwnerID = OwnerID;
            obj.WarehouseID = WarehouseID;
            obj.EffectiveDate = EffectiveDate;

            try
            {
                obj.Delete();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage CheckExistBeforeSave(int? OwnerID, int? WarehouseID, DateTime? iEffectiveDate, int? CustomerID, int? truckCompanyID)
        {
            Boolean ResultReturn;

            try
            {
                ResultReturn = obj.CheckExistBeforeSave(OwnerID, WarehouseID, iEffectiveDate, CustomerID, truckCompanyID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }
    }
}