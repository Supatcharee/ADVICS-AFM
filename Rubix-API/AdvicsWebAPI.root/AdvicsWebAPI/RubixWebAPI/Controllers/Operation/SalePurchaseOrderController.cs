using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Data.Objects;
using CSI.Business.DataObjects;
using System.Net.Http;
using System.Net;
using System.Data;
using Newtonsoft.Json;
using CSI.Business.Operation;

namespace RubixWebAPI.Controllers.Operation
{
    public class SalePurchaseOrderController : ApiController
    {
        SalePurchaseOrder obj = new SalePurchaseOrder();
        
        struct SaleOrderstr 
        {
            public string SONo;
            public int? OwnerID;
            public int? CustomerID; 
            public int? WarehouseID;
            public string CustomerPONo;
            public string CustomerPOIssueDate;
            public string CustomerPOIssueDateFrom;
            public string CustomerPOIssueDateTo;
            public string ShippingPeriod;
            public int? ProductID;
            public string Validity;
            public string Remark;
            public string XMLDetail;
            public string CurrentUser;
            public int isAfterMarket;
            public int? IsAllStatus;
            public int? IsPackingMaterial;
        }

        struct PurchaseOrderPDS
        {
            public string XMLSave;
        }

        struct Packing_Material_save
        {
            public string XMLSONo;
            public string XMLAdjust;
            public int CalculateMethod;
            public string CurrentUser;
        }

        struct PurchaseOrderstr
        {
            public int? OwnerID;
            public int? WarehouseID;
            public int? SupplierID;
            public int? CustomerID;
            public string POIssuedDate;
            public string POIssuedDateFrom;
            public string POIssuedDateTo;
            public string ArrivalDate;
            public string CollectDate;
            public string POInvoiceNo;
            public string Remark;
            public string SONo; 
            public string PONo; 
            public string CustomerPONo;
            public string CurrentUser;
            public int? IsAllStatus;
            public string XMLDetail;
            public int isAfterMarket;
        }

        struct ShippingPeriodstr
        {
            public string CustomerPO;
            public DateTime ShippingDate;
        }

        #region Sale Order
        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage SaleOrderDataLoading()
        {
            DataTable ResultReturn;

            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            SaleOrderstr stc = JsonConvert.DeserializeObject<SaleOrderstr>(strParameterData);
            try
            {
                ResultReturn = obj.SaleOrderDataLoading(stc.OwnerID, stc.WarehouseID, stc.CustomerID, stc.ShippingPeriod, stc.CustomerPOIssueDateFrom, stc.CustomerPOIssueDateTo, stc.CustomerPONo, stc.SONo, stc.IsAllStatus, stc.IsPackingMaterial, stc.isAfterMarket);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage SaleOrderDataLoadingDetail(string SONo)
        {
            DataSet ResultReturn;
            try
            {
                ResultReturn = obj.SaleOrderDataLoadingDetail(SONo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage SaleOrderSaveData()
        {
            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            SaleOrderstr stc = JsonConvert.DeserializeObject<SaleOrderstr>(strParameterData);
            try
            {
                obj.SaleOrderSaveData(stc.SONo, stc.OwnerID, stc.WarehouseID, stc.CustomerID, stc.CustomerPOIssueDate, stc.CustomerPONo, stc.Validity, stc.ShippingPeriod, stc.Remark, stc.isAfterMarket, stc.XMLDetail, stc.CurrentUser);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage SaleOrderDeleteData(string SONo)
        {
            try
            {
                obj.SaleOrderDeleteData(SONo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage SaleOrderCheckValidCustomerPO()
        {
            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            //ต้อง convert จาก string ไป string เพื่อตัด ความสำคัญตอนส่งมา ออก
            ShippingPeriodstr stc = JsonConvert.DeserializeObject<ShippingPeriodstr>(strParameterData);
            bool ResultReturn;
            try
            {
                ResultReturn = obj.SaleOrderCheckValidCustomerPO(stc.CustomerPO, stc.ShippingDate);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage SaleOrderCheckShippingCalendar()
        {
            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            SaleOrderstr stc = JsonConvert.DeserializeObject<SaleOrderstr>(strParameterData);
            bool ResultReturn;
            try
            {
                ResultReturn = obj.SaleOrderCheckShippingCalendar(stc.OwnerID, stc.CustomerID, stc.ProductID, stc.ShippingPeriod);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }
        
        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage SaleOrderCheckCompanyCalendar()
        {
            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            SaleOrderstr stc = JsonConvert.DeserializeObject<SaleOrderstr>(strParameterData);
            bool ResultReturn;
            try
            {
                ResultReturn = obj.SaleOrderCheckCompanyCalendar(stc.OwnerID, stc.ShippingPeriod);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage SaleOrderConfirm()
        {
            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            SaleOrderstr stc = JsonConvert.DeserializeObject<SaleOrderstr>(strParameterData);
            try
            {
                obj.SaleOrderConfirm(stc.XMLDetail, stc.CurrentUser);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage CheckingSaleDataLoading()
        {
            DataSet ResultReturn;

            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            SaleOrderstr stc = JsonConvert.DeserializeObject<SaleOrderstr>(strParameterData);
            try
            {
                ResultReturn = obj.CheckingSaleDataLoading(stc.OwnerID, stc.WarehouseID, stc.CustomerID, stc.ShippingPeriod, stc.CustomerPOIssueDateFrom, stc.CustomerPOIssueDateTo, stc.CustomerPONo, stc.SONo, stc.IsAllStatus);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage CheckingSaleOrderByContainer(string SONo)
        {
            DataTable ResultReturn;
            try
            {
                ResultReturn = obj.CheckingSaleOrderByContainer(SONo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }
        #endregion

        #region Purchase Order
        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage PurchaseOrderDataLoading()
        {
            DataSet ResultReturn;

            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            PurchaseOrderstr stc = JsonConvert.DeserializeObject<PurchaseOrderstr>(strParameterData);
            try
            {
                ResultReturn = obj.PurchaseOrderDataLoading(stc.OwnerID, stc.WarehouseID, stc.SupplierID, stc.CustomerID, stc.POIssuedDateFrom, stc.POIssuedDateTo, stc.SONo, stc.PONo, stc.CustomerPONo, stc.IsAllStatus, stc.isAfterMarket);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage PurchaseOrderDataLoadingDetail(string PONo)
        {
            DataSet ResultReturn;
            try
            {
                ResultReturn = obj.PurchaseOrderDataLoadingDetail(PONo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }
        
        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage PurchaseOrderLoadProductBySONo()
        {
            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            PurchaseOrderstr stc = JsonConvert.DeserializeObject<PurchaseOrderstr>(strParameterData);
            DataTable ResultReturn;
            try
            {
                ResultReturn = obj.PurchaseOrderLoadProductBySONo(stc.XMLDetail, stc.SupplierID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }
        
        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage PurchaseOrderSaveManualData()
        {
            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            PurchaseOrderstr stc = JsonConvert.DeserializeObject<PurchaseOrderstr>(strParameterData);
            try
            {
                obj.PurchaseOrderSaveManualData(stc.PONo, stc.OwnerID, stc.WarehouseID, stc.SupplierID, stc.CustomerID, stc.POIssuedDate, stc.ArrivalDate, stc.CollectDate, stc.POInvoiceNo, stc.Remark, stc.XMLDetail, stc.CurrentUser);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage PurchaseOrderDeleteData(string PONo)
        {
            try
            {
                obj.PurchaseOrderDeleteData(PONo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage PurchaseOrderDataLoadingConfirm()
        {
            DataTable ResultReturn;

            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            PurchaseOrderstr stc = JsonConvert.DeserializeObject<PurchaseOrderstr>(strParameterData);
            try
            {
                ResultReturn = obj.PurchaseOrderDataLoadingConfirm(stc.OwnerID, stc.WarehouseID, stc.SupplierID, stc.CustomerID, stc.POIssuedDateFrom, stc.POIssuedDateTo, stc.SONo, stc.PONo, stc.CustomerPONo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage PurchaseOrderConfirm()
        {
            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            SaleOrderstr stc = JsonConvert.DeserializeObject<SaleOrderstr>(strParameterData);
            try
            {
                obj.PurchaseOrderConfirm(stc.XMLDetail, stc.CurrentUser);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage PurchaseOrderSavePSDInvNo()
        {
            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            PurchaseOrderPDS stc = JsonConvert.DeserializeObject<PurchaseOrderPDS>(strParameterData);
            try
            {
                obj.PurchaseOrderSavePSDInvNo(stc.XMLSave);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage PurchaseOrderLoadSONo()
        {
            DataTable ResultReturn;

            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            SaleOrderstr stc = JsonConvert.DeserializeObject<SaleOrderstr>(strParameterData);
            try
            {
                ResultReturn = obj.PurchaseOrderLoadSONo(stc.OwnerID, stc.WarehouseID, stc.CustomerID, stc.ShippingPeriod, stc.CustomerPOIssueDateFrom, stc.CustomerPOIssueDateTo, stc.CustomerPONo, stc.SONo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage PurchaseOrderEditPOInvoice(string PONo, string POInvoiceNo, string CurrentUser)
        {
            try
            {
                obj.PurchaseOrderEditPOInvoice(PONo, POInvoiceNo, CurrentUser);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage SaleOrder_PreConfirm_Search()
        {
            DataSet ResultReturn;
            try
            {
                string strParameterData = Request.Content.ReadAsStringAsync().Result;
                string stc = JsonConvert.DeserializeObject<string>(strParameterData);
                ResultReturn = obj.SaleOrder_PreConfirm_Search(stc);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        public HttpResponseMessage SaleOrder_PreConfirm_BySONo_Search()
        {
            DataSet ResultReturn;
            try
            {
                string strParameterData = Request.Content.ReadAsStringAsync().Result;
                string stc = JsonConvert.DeserializeObject<string>(strParameterData);
                ResultReturn = obj.SaleOrder_PreConfirm_BySONo_Search(stc);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }
        
        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage SaleOrderPreconfirmSave()
        {
            try
            {
                string strParameterData = Request.Content.ReadAsStringAsync().Result;
                string stc = JsonConvert.DeserializeObject<string>(strParameterData);
                obj.SaleOrderPreconfirmSave(stc);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }




        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage PurchaseOrderRollBackData(string PONo)
        {
            try
            {
                obj.PurchaseOrderRollBackData(PONo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        #endregion

        #region Packing Material

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage PackingMaterialCheckPreconfirm()
        {
            try
            {
                string strParameterData = Request.Content.ReadAsStringAsync().Result;
                string stc = JsonConvert.DeserializeObject<string>(strParameterData);
                obj.PackingMaterialCheckPreconfirm();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage Packing_Material_Summary_Search()
        {
            DataSet ResultReturn;
            try
            {
                string strParameterData = Request.Content.ReadAsStringAsync().Result;
                string stc = JsonConvert.DeserializeObject<string>(strParameterData);
                ResultReturn = obj.Packing_Material_Summary_Search(stc);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage Packing_Material_Summary_Save()
        {
            DataSet ResultReturn;
            try
            {
                string strParameterData = Request.Content.ReadAsStringAsync().Result;
                Packing_Material_save stc = JsonConvert.DeserializeObject<Packing_Material_save>(strParameterData);
                ResultReturn = obj.Packing_Material_Summary_Save(stc.XMLSONo, stc.XMLAdjust, stc.CalculateMethod, stc.CurrentUser);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage PurchaseOrder_PackingMaterial_Cancel()
        {
            try
            {
                string strParameterData = Request.Content.ReadAsStringAsync().Result;
                string stc = JsonConvert.DeserializeObject<string>(strParameterData);
                obj.PurchaseOrder_PackingMaterial_Cancel(stc);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage PurchaseOrderPackingMaterialPreConfirmSave()
        {
            try
            {
                string strParameterData = Request.Content.ReadAsStringAsync().Result;
                Packing_Material_save stc = JsonConvert.DeserializeObject<Packing_Material_save>(strParameterData);
                obj.PurchaseOrderPackingMaterialPreConfirmSave(stc.XMLSONo,stc.CurrentUser);
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
