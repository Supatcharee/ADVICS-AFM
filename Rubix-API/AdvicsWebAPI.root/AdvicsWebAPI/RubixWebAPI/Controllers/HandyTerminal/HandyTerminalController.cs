using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using Rubix.Framework;
using Newtonsoft.Json;
using CSI.Business.HandyTerminal;

namespace RubixWebAPI.Controllers
{
    public class HandyTerminalController : ApiController
    {
        struct ReceivingConfirm
        {
            public string ReceivingNo;
            public int Installment;
            public int ProductID;
            public decimal ReceiveQty;
            public int? LocationID;
            public string UserName;
        }

        struct Transitstc
        {
            public string PDSNo;
            public string RunningNo;
            public string LocationCode;
            public string UserName;
        }

        struct Pickingstc
        {
            public string PickingNo; 
            public string ShipmentNo;
            public int Installment;
            public int LineNo;
            public int LocationID;
            public int ProductID; 
            public int ProductConditionID;
            public string PalletNo;
            public string LotNo;
            public int WarehouseID;
            public int PickingLineSeq;
            public decimal PickQty;
            public int UnitOfOrderQty;
            public string xmlRMTag;
            public string UserName;
        }

        struct StructTrackingSearch
        {
            public string ILabel;
        }

        struct PickingPackingMaterial
        {
            public string xmlRMTag;
            public string UserID;
        }

        private HandyTerminal obj = new HandyTerminal();

        #region Login
        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage UserLogin(string UserName)
        {
            DataTable objResult;

            try
            {
                objResult = obj.UserLogin(UserName);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, objResult);
        } 
        #endregion

        #region Permission
        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LoadMainMenu(string UserID, string Permission)
        {
            DataTable objResult;

            try
            {
                objResult = obj.LoadMainMenu(UserID, Permission);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, objResult);
        } 
        #endregion

        #region Receiving
         [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage ReceivingEntry_SearchBy_ReceivingDate(string ReceivingDate, string UserLogin)
        {
            DataTable objResult;

            try
            {
                objResult = obj.ReceivingEntry_SearchBy_ReceivingDate(ReceivingDate, UserLogin);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, objResult);
        }

         [HttpPost, HttpGet, APIAuthorize]
         public HttpResponseMessage ReceivingEntry_SearchBy_ReceivingNo(string ReceivingNo, int Installment)
         {
             DataSet objResult;

             try
             {
                 objResult = obj.ReceivingEntry_SearchBy_ReceivingNo(ReceivingNo, Installment);
             }
             catch (Exception ex)
             {
                 return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
             }

             return Request.CreateResponse(HttpStatusCode.OK, objResult);
         }

         [HttpPost, HttpGet, APIAuthorize]
         public HttpResponseMessage ReceivingConfirmDetail_Save()
         {
             string strParameterData = Request.Content.ReadAsStringAsync().Result;
             ReceivingConfirm stc = JsonConvert.DeserializeObject<ReceivingConfirm>(strParameterData);
             try
             {
                 obj.ReceivingConfirmDetail_Save(stc.ReceivingNo, stc.Installment, stc.ProductID, stc.ReceiveQty, stc.LocationID, stc.UserName);
             }
             catch (Exception ex)
             {
                 return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
             }

             return Request.CreateResponse(HttpStatusCode.OK);
         }

         [HttpPost, HttpGet, APIAuthorize]
         public HttpResponseMessage ReceivingConfirmDetail_RMTagSave(string ReceivingNo, int? IsCompleteFlag)
         {
             string strParameterData = Request.Content.ReadAsStringAsync().Result;
             try
             {
                 obj.ReceivingConfirmDetail_RMTagSave(ReceivingNo, IsCompleteFlag, strParameterData);
             }
             catch (Exception ex)
             {
                 return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
             }

             return Request.CreateResponse(HttpStatusCode.OK);
         } 
        #endregion

        #region Transit
         [HttpPost, HttpGet, APIAuthorize]
         public HttpResponseMessage TransitEntry_Search(string PDSNo, string RunningNo)
         {
             DataSet ResultReturn;
             try
             {
                 ResultReturn = obj.TransitEntry_Search(PDSNo, RunningNo);
             }
             catch (Exception ex)
             {
                 return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
             }

             return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
         }

         [HttpPost, HttpGet, APIAuthorize]
         public HttpResponseMessage TransitConfirmationDetail_Save()
         {
             string strParameterData = Request.Content.ReadAsStringAsync().Result;
             Transitstc stc = JsonConvert.DeserializeObject<Transitstc>(strParameterData);

             try
             {
                 obj.TransitConfirmationDetail_Save(stc.PDSNo, stc.RunningNo, stc.LocationCode, stc.UserName);
             }
             catch (Exception ex)
             {
                 return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
             }

             return Request.CreateResponse(HttpStatusCode.OK);
         }
        #endregion

        #region Picking
         [HttpPost, HttpGet, APIAuthorize]
         public HttpResponseMessage PickingEntry_SearchBy_PickingDate(string PickingDate, string UserLogin)
         {
             DataTable objResult;

             try
             {
                 objResult = obj.PickingEntry_SearchBy_PickingDate(PickingDate, UserLogin);
             }
             catch (Exception ex)
             {
                 return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
             }

             return Request.CreateResponse(HttpStatusCode.OK, objResult);
         }

         [HttpPost, HttpGet, APIAuthorize]
         public HttpResponseMessage PickingEntry_SearchBy_PickingNo(string PickingNo, int Installment)
         {
             DataSet objResult;

             try
             {
                 objResult = obj.PickingEntry_SearchBy_PickingNo(PickingNo, Installment);
             }
             catch (Exception ex)
             {
                 return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
             }

             return Request.CreateResponse(HttpStatusCode.OK, objResult);
         }

         [HttpPost, HttpGet, APIAuthorize]
         public HttpResponseMessage PickingConfirmationDetail_Save()
         {
             string strParameterData = Request.Content.ReadAsStringAsync().Result;
             Pickingstc stc = JsonConvert.DeserializeObject<Pickingstc>(strParameterData);

             try
             {
                 obj.PickingConfirmationDetail_Save(stc.PickingNo, stc.Installment, stc.ProductID, stc.PickQty, stc.xmlRMTag, stc.UserName);
             }
             catch (Exception ex)
             {
                 return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
             }

             return Request.CreateResponse(HttpStatusCode.OK);
         }

         [HttpPost, HttpGet, APIAuthorize]
         public HttpResponseMessage PickingPackingMaterial_Save()
         {
             string strParameterData = Request.Content.ReadAsStringAsync().Result;
             PickingPackingMaterial stc = JsonConvert.DeserializeObject<PickingPackingMaterial>(strParameterData);

             try
             {
                 obj.PickingPackingMaterial_Save(stc.xmlRMTag,stc.UserID);
             }
             catch (Exception ex)
             {
                 return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
             }

             return Request.CreateResponse(HttpStatusCode.OK);
         }
        #endregion


       #region Tracking

         [HttpPost, HttpGet, APIAuthorize]
         public HttpResponseMessage Tracking_Search()
         {
             string strParameterData = Request.Content.ReadAsStringAsync().Result;
             StructTrackingSearch stc = JsonConvert.DeserializeObject<StructTrackingSearch>(strParameterData);
             DataSet objResult;
             try
             {
                 objResult = obj.Tracking_Search(stc.ILabel);
             }
             catch (Exception ex)
             {
                 return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
             }

             return Request.CreateResponse(HttpStatusCode.OK,objResult);
         }
         #endregion


       #region TransitAfterPack


         [HttpPost, HttpGet, APIAuthorize]
         public HttpResponseMessage TransitPack_SaveUpdate(string PalletNo, string LocationCode, int Flag, string UserName)
         {
            

             try
             {
                 obj.TransitPack_SaveUpdate(PalletNo, LocationCode, Flag, UserName);
             }
             catch (Exception ex)
             {
                 return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
             }

             return Request.CreateResponse(HttpStatusCode.OK);
         }

         [HttpPost, HttpGet, APIAuthorize]
         public HttpResponseMessage TransitPack_CheckPalletOrLocation(string PalletNo, string LocationCode)
         {
             DataTable objResult;

             try
             {
                 objResult = obj.TransitPack_CheckPalletOrLocation(PalletNo, LocationCode);
             }
             catch (Exception ex)
             {
                 return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
             }

             return Request.CreateResponse(HttpStatusCode.OK, objResult);
         }

         [HttpPost, HttpGet, APIAuthorize]
         public HttpResponseMessage GetDetailByPallet(string PalletNo)
         {
             DataSet objResult;

             try
             {
                 objResult = obj.GetDetailByPallet(PalletNo);
             }
             catch (Exception ex)
             {
                 return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
             }

             return Request.CreateResponse(HttpStatusCode.OK, objResult);
         }
        #endregion


       #region PickForShip

         [HttpPost, HttpGet, APIAuthorize]
         public HttpResponseMessage PickShip_Update(string PalletNo, string LocationCode, int Flag, string UserName)
         {


             try
             {
                 obj.PickShip_Update(PalletNo, LocationCode, Flag, UserName);
             }
             catch (Exception ex)
             {
                 return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
             }

             return Request.CreateResponse(HttpStatusCode.OK);
         }

         [HttpPost, HttpGet, APIAuthorize]
         public HttpResponseMessage PickShip_CheckPalletOrLocation(string PalletNo, string LocationCode)
         {
             DataTable objResult;

             try
             {
                 objResult = obj.PickShip_CheckPalletOrLocation(PalletNo, LocationCode);
             }
             catch (Exception ex)
             {
                 return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
             }

             return Request.CreateResponse(HttpStatusCode.OK, objResult);
         }

         [HttpPost, HttpGet, APIAuthorize]
         public HttpResponseMessage CaseMarkPickAndPack(string PalletNo, string UserName)
         {
             try
             {
                    obj.CaseMarkPickAndPack(PalletNo, UserName);
             }
             catch (Exception ex)
             {
                 return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
             }

             return Request.CreateResponse(HttpStatusCode.OK );
         }

         [HttpPost, HttpGet, APIAuthorize]
         public HttpResponseMessage PickingPalletEntry_SearchBy_ContainerNo(string ShipmentNo, string ContainerNo, string PackingDate)
         {
             DataSet objResult;

             try
             {
                 DateTime PackingDate_date = DateTime.ParseExact(PackingDate, "yyyy/mm/dd", System.Globalization.CultureInfo.InvariantCulture);
                 objResult = obj.PickingPalletEntry_SearchBy_ContainerNo(ShipmentNo, ContainerNo, PackingDate_date);
             }
             catch (Exception ex)
             {
                 return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
             }

             return Request.CreateResponse(HttpStatusCode.OK, objResult);
         }
        #endregion


        #region PickMaterial

         [HttpPost, HttpGet, APIAuthorize]
         public HttpResponseMessage CheckPickMatData(string PDSNo, string RunningNo)
         {
             DataTable objResult;

             try
             {
                 objResult = obj.CheckPickMatData(PDSNo, RunningNo);
             }
             catch (Exception ex)
             {
                 return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
             }

             return Request.CreateResponse(HttpStatusCode.OK, objResult);
         }

         public HttpResponseMessage PickMat_Save(string PDSNo, string RunningNo, string UserName)
         {


             try
             {
                 obj.PickMat_Save(PDSNo, RunningNo, UserName);
             }
             catch (Exception ex)
             {
                 return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
             }

             return Request.CreateResponse(HttpStatusCode.OK);
         }

        #endregion
    }
}