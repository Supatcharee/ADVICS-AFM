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
    public class PackingInstructionController : ApiController
    {
        PackingInstruction obj = new PackingInstruction();

        struct PackingArragementstr
        {
            public int? OwnerID;
            public int? CustomerID;
            public int? WarehouseID;
            public string ShipmentNo;
            public string PackingNo;
            public string ShipmentNoTo;
            public string PackingNoTo;
            public string CustomerPO;
            public string PalletNo;
            public string PackingDateFrom;
            public string PackingDateTo;
            public DateTime? ShippingDate;
            public DateTime? PackingDate;
            public DateTime? PickingDate;
            public bool isCompletedPacking;
            public bool isActual;
            public string DetailXML;
            public int MoveAll;
            public string CurrentUser;
            public int? StatusID;
        }

        struct ConfirmPacking
        {
            public int? OwnerID;
            public int? CustomerID;
            public int? WarehouseID;
            public string ShipmentNo;
            public string PackingNo;
            public string CustomerPONo;
            public DateTime? PackingDateFrom;
            public DateTime? PackingDateTo;
            public bool Status;
        }

        struct PackingConfirmData
        {
            public string PackingNo;
            public decimal? TotalWeight;
            public decimal? TotalGrossWeight;
            public decimal? TotalM3;
            public string RMTagXML;
            public string CurrentUser;
            public string RemarkHeader;
            public string UserLogon;
            public string MachineIP;
        }

        //PKP010
        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage PackingArragementSearchAll()
        {
            DataTable ResultReturn;
            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            PackingArragementstr stc = JsonConvert.DeserializeObject<PackingArragementstr>(strParameterData);
            try
            {
                ResultReturn = obj.PackingArragementSearchAll(stc.OwnerID, stc.CustomerID, stc.WarehouseID, stc.ShipmentNo, stc.PackingNo, stc.CustomerPO, stc.PalletNo, stc.PackingDateFrom, stc.PackingDateTo, stc.isActual, stc.StatusID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }
            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }
        //KPK010
        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage PackingArragementRollBack(string PickingNo, string CreateUser)
        {
            try
            {
                obj.PackingArragementRollBack(PickingNo, CreateUser);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        //KPK010
        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage PackingArragementValidate_PickPallet(string PalletNo)
        {
            DataSet ResultReturn;
            try
            {
                ResultReturn = obj.PackingArragementValidate_PickPallet(PalletNo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }
            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }
        //KPK010
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
            return Request.CreateResponse(HttpStatusCode.OK);
        }             
        //KPK011
        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage PackingArragementSearchDetail(string ShipmentNo, string PackingNo)
        {
            DataSet ResultReturn;

            try
            {
                ResultReturn = obj.PackingArragementSearchDetail(ShipmentNo, PackingNo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }
            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }
        //KPK011
        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage PackingArragementSaveDetail()
        {
            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            PackingConfirmData stc = JsonConvert.DeserializeObject<PackingConfirmData>(strParameterData);
            try
            {
                obj.PackingArragementSaveDetail(stc.PackingNo, stc.RemarkHeader, stc.RMTagXML, stc.CurrentUser, stc.TotalWeight, stc.TotalGrossWeight, stc.TotalM3);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        //KPK012
        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage PackingManagementSearchAll()
        {
            DataTable ResultReturn;
            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            PackingArragementstr stc = JsonConvert.DeserializeObject<PackingArragementstr>(strParameterData);
            try
            {
                ResultReturn = obj.PackingManagementSearchAll(stc.OwnerID, stc.CustomerID, stc.WarehouseID, stc.ShippingDate, stc.PackingDate, stc.ShipmentNo, stc.PackingNo, stc.MoveAll, stc.ShipmentNoTo, stc.PackingNoTo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }
            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }
        //KPK012
        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage PackingManagementGetShipmentStatus(string ShipmentNo, string PackingNo)
        {
            int ResultReturn;
            try
            {
                ResultReturn = obj.PackingManagementGetShipmentStatus(ShipmentNo, PackingNo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }
            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        //KPK012
        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage PackingManagementSave()
        {
            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            PackingArragementstr stc = JsonConvert.DeserializeObject<PackingArragementstr>(strParameterData);
            try
            {
                obj.PackingManagementSave(stc.OwnerID, stc.WarehouseID, stc.CustomerID, stc.ShippingDate, stc.PackingDate, stc.PickingDate, stc.ShipmentNo, stc.PackingNo, stc.CurrentUser, stc.DetailXML);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        //KPK020
        [HttpPost, HttpGet, APIAuthorize]
        
        
        public HttpResponseMessage ConfirmPackingSearchAll()
        {
            DataTable ResultReturn;
            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            ConfirmPacking stc = JsonConvert.DeserializeObject<ConfirmPacking>(strParameterData);
            try
            {
                ResultReturn = PackingInstruction.ConfirmPackingSearchAll(stc.OwnerID, stc.CustomerID, stc.WarehouseID, stc.ShipmentNo, stc.PackingNo, stc.CustomerPONo, stc.PackingDateFrom, stc.PackingDateTo,stc.Status);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }
            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        public HttpResponseMessage ConfirmPackingForScannerSearchAll()
        {
            DataTable ResultReturn;
            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            ConfirmPacking stc = JsonConvert.DeserializeObject<ConfirmPacking>(strParameterData);
            try
            {
                ResultReturn = PackingInstruction.ConfirmPackingForScannerSearchAll(stc.OwnerID, stc.CustomerID, stc.WarehouseID, stc.ShipmentNo, stc.PackingNo, stc.CustomerPONo, stc.PackingDateFrom, stc.PackingDateTo, stc.Status);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }
            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        //KPK020
        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage ConfirmPackingConfirmData()
        {
            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            PackingConfirmData stc = JsonConvert.DeserializeObject<PackingConfirmData>(strParameterData);
            try
            {
                obj.ConfirmPackingConfirmData(stc.PackingNo, stc.RMTagXML, stc.CurrentUser);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        //KPK021
        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage ConfirmPackingSearchRMTagDetail(string PDSNo, string RunningNo, string ProductCode, string ShipmentNo, string PackingNo)
        {
            DataTable ResultReturn;

            try
            {
                ResultReturn = obj.ConfirmPackingSearchRMTagDetail(PDSNo, RunningNo, ProductCode, ShipmentNo, PackingNo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }
            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        //KPK022
        public HttpResponseMessage PackingAppearanceSearchPackingProduct(string PackingNo)
        {
            DataTable ResultReturn;

            try
            {
                ResultReturn = obj.PackingAppearanceSearchPackingProduct(PackingNo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }
            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }


    }
}