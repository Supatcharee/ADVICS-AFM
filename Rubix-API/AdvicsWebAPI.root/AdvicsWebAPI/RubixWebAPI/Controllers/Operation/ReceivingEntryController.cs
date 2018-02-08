using System;
using System.Collections.Generic;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using CSI.Business.Operation;
using System.Data.Objects;
using CSI.Business.DataObjects;
using System.Net.Http;
using System.Net;
using System.Data;
using Rubix.Framework;
using Newtonsoft.Json;
using System.Drawing;
using System.IO;
using System.Threading;

namespace RubixWebAPI.Controllers.Operation
{
    public class ReceivingEntryController : ApiController
    {
        ReceivingEntry obj = new ReceivingEntry();

        struct GetReceivingInstructionDetailStruct
        {
            public DataTable Detail;
            public string StatusName;
        }

        struct SaveChangesStruct
        {
            public DataTable ReceivingInstructionHeader;
            public string XMLReceivingInstructionDetail;
            public string XMLReceivingTransportation;
            public string XMLReceivingOtherCharge;
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DataLoading(int? OwnerID, string ReceivingNo, int? ProductID, int? SupplierID, DateTime? From, DateTime? To, int StatusFilter, int? WarehouseID, string InvoiceNo)
        {
            DataTable ResultReturn;
            try
            {
                ResultReturn = obj.DataLoading(OwnerID, ReceivingNo, ProductID, SupplierID, From, To, StatusFilter, WarehouseID, InvoiceNo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetReceivingInstructionHeader(string ReceivingNo, int Installment)
        {
            DataTable ResultReturn;
            try
            {
                ResultReturn = obj.GetReceivingInstructionHeader(ReceivingNo, Installment);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }


        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetTransportCharge(int? OwnerID, int? WarehouseID, int TransportTypeID)
        {
            DataTable ResultReturn;
            try
            {
                ResultReturn = obj.GetTransportCharge(OwnerID, WarehouseID, TransportTypeID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }
        
        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetReceivingInstructionDetail(string ReceivingNo, int Installment, int OwnerID)
        {
            DataTable ResultReturn;
            string StatusName;
            GetReceivingInstructionDetailStruct stc;
            try
            {
                ResultReturn = obj.GetReceivingInstructionDetail(ReceivingNo, Installment, OwnerID, out StatusName);
                stc.Detail = ResultReturn;
                stc.StatusName = StatusName;
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, stc);
        }
        
        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LoadProductInfo(int ProductID)
        {
            DataTable ResultReturn;
            try
            {
                ResultReturn = obj.LoadProductInfo(ProductID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LoadUnit(int? ProductID)
        {
            DataTable ResultReturn;
            try
            {
                ResultReturn = obj.LoadUnit(ProductID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage CanDelete(string ReceivingNo, int Installment, int OwnerID)
        {
            bool ResultReturn;
            try
            {
                ResultReturn = obj.CanDelete(ReceivingNo, Installment, OwnerID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage CanDeleteDetail(string ReceivingNo, int Installment, int OwnerID, int LineNo)
        {
            bool ResultReturn;
            try
            {
                ResultReturn = obj.CanDeleteDetail(ReceivingNo, Installment, OwnerID, LineNo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage CanUpdateDetail(string ReceivingNo, int Installment, int OwnerID, int LineNo)
        {
            bool ResultReturn;
            try
            {
                ResultReturn = obj.CanUpdateDetail(ReceivingNo, Installment, OwnerID, LineNo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage CanAddDetail(string ReceivingNo, int Installment, int OwnerID)
        {
            bool ResultReturn;
            try
            {
                ResultReturn = obj.CanAddDetail(ReceivingNo, Installment, OwnerID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage CanUpdate(string ReceivingNo, int Installment, int OwnerID)
        {
            bool ResultReturn;
            try
            {
                ResultReturn = obj.CanUpdate(ReceivingNo, Installment, OwnerID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage SaveChanges() 
        {
            string ResultReturn;
            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            SaveChangesStruct stc = JsonConvert.DeserializeObject<SaveChangesStruct>(strParameterData);

            try
            {
                ResultReturn = obj.SaveChanges(stc.ReceivingInstructionHeader, stc.XMLReceivingInstructionDetail, stc.XMLReceivingTransportation, stc.XMLReceivingOtherCharge);
            }
            catch (Exception ex)
            {                
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage UploadReceivingFile(string FileName, string ReceivingNo)
        {
            try
            {
                var content = Request.Content.ReadAsByteArrayAsync().Result;
                obj.AddNewCOA(ReceivingNo, FileName, content);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage Delete(string ReceivingNo, int Installment)
        {
            try
            {
                obj.Delete(ReceivingNo, Installment);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
        
        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetReceivingTransDetail(string ReceivingNo, int Installment)
        {
            DataTable ResultReturn;

            try
            {
                ResultReturn = obj.GetReceivingTransDetail(ReceivingNo, Installment);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetReceivingOtherDetail(string ReceivingNo, int Installment)
        {
            DataTable ResultReturn;
            try
            {
                ResultReturn = obj.GetReceivingOtherDetail(ReceivingNo, Installment);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetUnitOfMeasure(int unitID, int ProductID)
        {
            DataTable ResultReturn;
            try
            {
                ResultReturn = obj.GetUnitOfMeasure(unitID, ProductID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }
                        
        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetMaxLineNo(string ReceivingNo)
        {
            int ResultReturn;
            try
            {
                ResultReturn = obj.GetMaxLineNo(ReceivingNo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }
            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }
        
        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage UnplanReceivingEntryDataLoading(int? OwnerID, string ReceivingNo, int? ProductID, DateTime? ArrivalDateFrom, DateTime? ArrivalDateTo, int? SupplierID, int? WarehouseID, string InvoiceNo)
        {
            List<sp_CRCS030_UnplanReceivingEntry_SearchAll_Result> ResultReturn;
            try
            {
                ResultReturn = obj.UnplanReceivingEntryDataLoading(OwnerID, ReceivingNo, ProductID, ArrivalDateFrom, ArrivalDateTo, SupplierID, WarehouseID, InvoiceNo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LoadPONo(int OwnerID, int WarehouseID, int SupplierID, string POIssueDateFrom, string POIssueDateTo)
        {
            DataTable ResultReturn;
            try
            {
                ResultReturn = obj.LoadPONo(OwnerID, WarehouseID, SupplierID, POIssueDateFrom, POIssueDateTo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }
            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LoadDetailPDSNo(string PDSNo)
        {
            DataTable ResultReturn;
            try
            {
                ResultReturn = obj.LoadDetailPDSNo(PDSNo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }
            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

    }

}