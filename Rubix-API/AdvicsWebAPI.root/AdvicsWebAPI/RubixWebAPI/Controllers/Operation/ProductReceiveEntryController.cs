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
    public class ProductReceiveEntryController : ApiController
    {
        ProductReceiveEntry obj = new ProductReceiveEntry();

        struct GetDetailReturnStruct
        {
            public List<sp_CRCS051_ConfirmReceivingDetail_Get_Result> list;
            public DateTime rcvDate;
            public int? palletQty;
        }

        struct DataLoadingstr
        {
            public int? OwnerID;
            public int? WarehouseID;
            public int? SupplierID;
            public string ReceivingNo;
            public int? LineNo;
            public int ReceivingCompleted;
            public DateTime? ReceivingDateFrom;
            public DateTime? ReceivingDateTo;
            public string PDSNo;
            public string PONo;
            public string CustomerPONo;
            public DateTime? CustomerPOIssueDateFrom;
            public DateTime? CustomerPOIssueDateTo;
            public int isAfterMarket;
            public int isPackingMaterial;
            public int isPart;
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DataLoading()
        {
            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            DataLoadingstr stc = JsonConvert.DeserializeObject<DataLoadingstr>(strParameterData);

            List<sp_CRCS050_ProductReceiveEntry_SearchAll_Result> ResultReturn;

            try
            {
                ResultReturn = obj.DataLoading(stc.OwnerID
                                            , stc.WarehouseID
                                            , stc.SupplierID
                                            , stc.ReceivingNo
                                            , stc.LineNo
                                            , stc.ReceivingCompleted
                                            , stc.ReceivingDateFrom
                                            , stc.ReceivingDateTo
                                            , stc.PDSNo, stc.PONo
                                            , stc.CustomerPONo
                                            , stc.CustomerPOIssueDateFrom
                                            , stc.CustomerPOIssueDateTo
                                            , stc.isAfterMarket
                                            , stc.isPackingMaterial
                                            , stc.isPart);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetReceivingReport(string receivingNo)
        {
            ObjectResult<sp_RPT001_ReceivingReport_GetData_Result> ResultReturn;

            try
            {
                ResultReturn = obj.GetReceivingReport(receivingNo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }
        
        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage CanSaveReceiveQty(decimal qty, decimal? receiveQty)
        {
            bool ResultReturn;

            try
            {
                ResultReturn = obj.CanSaveReceiveQty(qty, receiveQty);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage IsAllLineOfReceiving(int OwnerID, string ReceivingNo, int Installment, int SelectCnt)
        {
            bool ResultReturn;

            try
            {
                ResultReturn = obj.IsAllLineOfReceiving(OwnerID, ReceivingNo, Installment, SelectCnt);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage IsReadyToConfirm()
        {
            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            sp_CRCS050_ProductReceiveEntry_SearchAll_Result data = JsonConvert.DeserializeObject<sp_CRCS050_ProductReceiveEntry_SearchAll_Result>(strParameterData);
            
            bool ResultReturn;

            try
            {
                ResultReturn = obj.IsReadyToConfirm(data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage CheckWorkMethod(int? OwnerID, int? WarehouseID)
        {
            int? ResultReturn;

            try
            {
                ResultReturn = obj.CheckWorkMethod(OwnerID, WarehouseID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetDetail(string receivingNo, int Installment)
        {
            List<sp_CRCS051_ConfirmReceivingDetail_Get_Result> ResultReturn;
            GetDetailReturnStruct stc;
            DateTime rcvDate;
            int? palletQty;

            try
            {
                ResultReturn = obj.GetDetail(receivingNo, Installment, out rcvDate, out palletQty);
                stc.list = ResultReturn;
                stc.rcvDate = rcvDate;
                stc.palletQty = palletQty;
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, stc);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage SaveDetail(string receivingNo, DateTime? receivingDate, int? noOfPallet, bool isConfirmCompletely, string UserLogin, int Installment)
        {
            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            string xml = JsonConvert.DeserializeObject<string>(strParameterData);

            try
            {
                obj.SaveDetail(receivingNo, receivingDate, noOfPallet, isConfirmCompletely, xml, UserLogin, Installment);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage UnplanReceivingEntry_GetExpiryDate(int ProductID)
        {
            DateTime? ResultReturn;
            try
            {
                ResultReturn = obj.UnplanReceivingEntry_GetExpiryDate(ProductID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }
    }
}