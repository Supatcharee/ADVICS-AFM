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
using System.IO;
using System.Drawing;

namespace RubixWebAPI.Controllers.Operation
{
    public class ConfirmProductStoringController : ApiController
    {
        ConfirmProductStoring obj = new ConfirmProductStoring();
        ReceivingEntry rec = new ReceivingEntry();

        struct SaveChangesStruct
        {
            public tbt_TransitInstructionItems transit;
            public EntityState entityState;
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DataLoading(int? OwnerID, int? WarehouseID, string ReceivingNo, int? LineNo, int? SupplierID, bool ShowConfirm, int? isAfterMarket, DateTime? TransitDateFrom, DateTime? TransitDateTo, int? isPackingMaterial, int? isPart)
        {
            List<sp_DSRS010_ConfirmProductStoring_SearchAll_Result> ResultReturn;

            try
            {
                ResultReturn = obj.DataLoading(OwnerID, WarehouseID, ReceivingNo, LineNo, SupplierID, ShowConfirm, isAfterMarket, TransitDateFrom, TransitDateTo, isPackingMaterial, isPart);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetTransItem(string ReceivingNo, int Installment, int OwnerID, int LineNo)
        {
            tbt_TransitInstructionItems ResultReturn;

            try
            {
                ResultReturn = obj.GetTransItem(ReceivingNo, Installment, OwnerID, LineNo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LoadTransitConfirm(int OwnerID, string ReceivingNo, int Installment, int LineNo, int rcvSeq)
        {
            List<sp_DSRS010_ConfirmProductStoring_LoadTransitConfirm_Result> ResultReturn;

            try
            {
                ResultReturn = obj.LoadTransitConfirm(OwnerID, ReceivingNo, Installment, LineNo, rcvSeq);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LoadSuggestion(string ReceivingNo, int LineNo, int receiveSeq)
        {
            List<sp_DSRS010_ConfirmProductStoring_LoadSuggest_Result> ResultReturn;

            try
            {
                ResultReturn = obj.LoadSuggestion(ReceivingNo, LineNo, receiveSeq);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LoadDefaultTransitConfirm(int LocationID)
        {
            sp_DSRS010_ConfirmProductStoring_LoadStockByLocation_Result ResultReturn;

            try
            {
                ResultReturn = obj.LoadDefaultTransitConfirm(LocationID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage UploadFile(string FileName, string ReceivingNo)
        {
            //string rcvUploadPath = Path.Combine(CSI.Business.Common.SystemConfig.GetMainImagePath(), obj.GetReceivingCOAPath(), CompanyName, ReceivingNo);

            try
            {
                //var ImageBytes = Request.Content.ReadAsByteArrayAsync().ContinueWith(bytes => Image.FromStream(new MemoryStream(bytes.Result)));
                var content = Request.Content.ReadAsByteArrayAsync().Result;
                //if (!Directory.Exists(rcvUploadPath))
                //{
                //    Directory.CreateDirectory(rcvUploadPath);
                //}

                //ImageBytes.Result.Save(Path.Combine(rcvUploadPath, FileName));

                rec.AddNewCOA(ReceivingNo, FileName, content);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
                
        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage Confirm(string UserLogin)
        {
            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            List<sp_DSRS010_ConfirmProductStoring_SearchAll_Result> list = JsonConvert.DeserializeObject<List<sp_DSRS010_ConfirmProductStoring_SearchAll_Result>>(strParameterData);

            int ResultReturn;

            try
            {
                ResultReturn = obj.Confirm(list, UserLogin);
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
        public HttpResponseMessage Confirm(int OwnerID, string ReceivingNo, int Installment, int LineNo, int transitSeq, int WarehouseID,
                                           string PalletNo, int ProductID, int ProductConditionID, string UpdateUser)
        {
            try
            {
                obj.Confirm(OwnerID, ReceivingNo, Installment, LineNo, transitSeq, WarehouseID, PalletNo, ProductID, ProductConditionID, UpdateUser);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage ClearData()
        {
            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            List<sp_DSRS010_ConfirmProductStoring_SearchAll_Result> list = JsonConvert.DeserializeObject<List<sp_DSRS010_ConfirmProductStoring_SearchAll_Result>>(strParameterData);

            try
            {
                obj.ClearData(list);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
        
        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LoadAllFileName(string ReceivingNo)
        {
            DataTable ResultReturn;

            try
            {
                ResultReturn = rec.LoadCOAList(ReceivingNo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LoadCOAImage(int COA_ID)
        {
            byte[] ResultReturn;

            try
            {
                ResultReturn = rec.LoadCOAImage(COA_ID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }
        
        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LoadAllLocation(int? OwnerID, int? WarehouseID)
        {
            ObjectResult<sp_common_LoadByLocationType_Result> ResultReturn;

            try
            {
                ResultReturn = obj.LoadAllLocation(OwnerID,WarehouseID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage ReprintReceivingLabelDataLoading(int? OwnerID, int? WarehouseID, string ArrivalDateFrom, string ArrivalDateTo)
        {
            DataTable ResultReturn;

            try
            {
                ResultReturn = obj.ReprintReceivingLabelDataLoading(OwnerID, WarehouseID, ArrivalDateFrom, ArrivalDateTo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }
    }
}