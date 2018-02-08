using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using Newtonsoft.Json;
using Rubix.Framework;

namespace CSI.Business.Operation
{
    public class SalePurchaseOrder
    {
        #region Member
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
        #endregion

        #region Properties

        #endregion

        #region Sale Order
        public DataTable SaleOrderDataLoading(int? OwnerID, int? WarehouseID, int? CustomerID, string ShippingPeriod, string CustomerPOIssuedDateFrom, string CustomerPOIssuedDateTo, string CustomerPONo, string SONo, int? IsAllStatus, int? IsPackingMaterial, int IsAfterMarket)
        {
            try
            {
                SaleOrderstr str = new SaleOrderstr();
                str.OwnerID = OwnerID;
                str.WarehouseID = WarehouseID;
                str.CustomerID = CustomerID;
                str.ShippingPeriod = ShippingPeriod;
                str.CustomerPOIssueDateFrom = CustomerPOIssuedDateFrom;
                str.CustomerPOIssueDateTo = CustomerPOIssuedDateTo;
                str.CustomerPONo = CustomerPONo;
                str.SONo = SONo;
                str.IsAllStatus = IsAllStatus;
                str.IsPackingMaterial = IsPackingMaterial;
                str.isAfterMarket = IsAfterMarket;
                
                string strResult = RubixWebAPI.ExecuteObjectResult("SalePurchaseOrder/SaleOrderDataLoading", JsonConvert.SerializeObject(str));
                return JsonConvert.DeserializeObject<DataTable>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet SaleOrderDataLoadingDetail(string SONo)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("SONo", SONo);
                string strResult = RubixWebAPI.ExecuteObjectResult("SalePurchaseOrder/SaleOrderDataLoadingDetail", hs);
                return JsonConvert.DeserializeObject<DataSet>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaleOrderDeleteData(string SONo)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("SONo", SONo);
                string strResult = RubixWebAPI.ExecuteObjectResult("SalePurchaseOrder/SaleOrderDeleteData", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaleOrderSaveData(string SONo, int? OwnerID, int? WarehouseID, int? CustomerID, string ShippingPeriod, string CustomerPOIssuedDate, string CustomerPONo, string Validity, string Remark,int isAfterMarket, string XMLDetail)
        {
            try
            {
                SaleOrderstr str = new SaleOrderstr();
                str.SONo = SONo;
                str.OwnerID = OwnerID;
                str.WarehouseID = WarehouseID;
                str.CustomerID = CustomerID;
                str.ShippingPeriod = ShippingPeriod;
                str.CustomerPOIssueDate = CustomerPOIssuedDate;
                str.CustomerPONo = CustomerPONo;
                str.Validity = Validity;
                str.Remark = Remark;
                str.isAfterMarket = isAfterMarket;
                str.XMLDetail = XMLDetail;
                str.CurrentUser = AppConfig.UserLogin;
                RubixWebAPI.ExecuteObjectResult("SalePurchaseOrder/SaleOrderSaveData", JsonConvert.SerializeObject(str));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void SaleOrderSaveDataAfterMarket(string SONo, int? OwnerID, int? WarehouseID, int? CustomerID, string ShippingPeriod, string CustomerPOIssuedDate, string CustomerPONo, string Validity, string Remark, int isAfterMarket, string XMLDetail)
        {
            try
            {
                SaleOrderstr str = new SaleOrderstr();
                str.SONo = SONo;
                str.OwnerID = OwnerID;
                str.WarehouseID = WarehouseID;
                str.CustomerID = CustomerID;
                str.ShippingPeriod = ShippingPeriod;
                str.CustomerPOIssueDate = CustomerPOIssuedDate;
                str.CustomerPONo = CustomerPONo;
                str.Validity = Validity;
                str.Remark = Remark;
                str.isAfterMarket = isAfterMarket;
                str.XMLDetail = XMLDetail;
                str.CurrentUser = AppConfig.UserLogin;
                RubixWebAPI.ExecuteObjectResult("SalePurchaseOrder/SaleOrderSaveData", JsonConvert.SerializeObject(str));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





        public bool SaleOrderCheckValidCustomerPO(string CustomerPO, DateTime ShippingDate)
        {
            try
            {
                ShippingPeriodstr stc = new ShippingPeriodstr();
                stc.CustomerPO = CustomerPO;
                stc.ShippingDate = ShippingDate;
                string strResult = RubixWebAPI.ExecuteObjectResult("SalePurchaseOrder/SaleOrderCheckValidCustomerPO", JsonConvert.SerializeObject(stc));
                return JsonConvert.DeserializeObject<bool>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool SaleOrderCheckShippingCalendar(int? OwnerID, int? CustomerID, int? ProductID, string ShippingPeriod)
        {
            try
            {
                SaleOrderstr str = new SaleOrderstr();
                str.OwnerID = OwnerID;
                str.CustomerID = CustomerID;
                str.ShippingPeriod = ShippingPeriod;
                str.ProductID = ProductID;

                string strResult = RubixWebAPI.ExecuteObjectResult("SalePurchaseOrder/SaleOrderCheckShippingCalendar", JsonConvert.SerializeObject(str));
                return JsonConvert.DeserializeObject<bool>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool SaleOrderCheckCompanyCalendar(int? OwnerID, string ShippingPeriod)
        {
            try
            {
                SaleOrderstr str = new SaleOrderstr();
                str.OwnerID = OwnerID;
                str.ShippingPeriod = ShippingPeriod;

                string strResult = RubixWebAPI.ExecuteObjectResult("SalePurchaseOrder/SaleOrderCheckCompanyCalendar", JsonConvert.SerializeObject(str));
                return JsonConvert.DeserializeObject<bool>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //A020
        public void SaleOrderConfirm(string XMLSONo)
        {
            try
            {
                SaleOrderstr str = new SaleOrderstr();
                str.XMLDetail = XMLSONo;
                str.CurrentUser = AppConfig.UserLogin;

                string strResult = RubixWebAPI.ExecuteObjectResult("SalePurchaseOrder/SaleOrderConfirm", JsonConvert.SerializeObject(str));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //A030
        public DataSet CheckingSaleDataLoading(int? OwnerID, int? WarehouseID, int? CustomerID, string ShippingPeriod, string CustomerPOIssuedDateFrom, string CustomerPOIssuedDateTo, string CustomerPONo, string SONo, int? IsAllStatus)
        {
            try
            {
                SaleOrderstr str = new SaleOrderstr();
                str.OwnerID = OwnerID;
                str.WarehouseID = WarehouseID;
                str.CustomerID = CustomerID;
                str.ShippingPeriod = ShippingPeriod;
                str.CustomerPOIssueDateFrom = CustomerPOIssuedDateFrom;
                str.CustomerPOIssueDateTo = CustomerPOIssuedDateTo;
                str.CustomerPONo = CustomerPONo;
                str.SONo = SONo;
                str.IsAllStatus = IsAllStatus;

                string strResult = RubixWebAPI.ExecuteObjectResult("SalePurchaseOrder/CheckingSaleDataLoading", JsonConvert.SerializeObject(str));
                return JsonConvert.DeserializeObject<DataSet>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //A031
        public DataTable CheckingSaleOrderByContainer(string SONo)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("SONo", SONo);

                string strResult = RubixWebAPI.ExecuteObjectResult("SalePurchaseOrder/CheckingSaleOrderByContainer", hs);
                return JsonConvert.DeserializeObject<DataTable>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Purchase Order
        public DataSet PurchaseOrderDataLoading(int? OwnerID, int? WarehouseID, int? SupplierID, int? CustomerID, string POIssuedDateFrom, string POIssuedDateTo, string SONo, string PONo, string CustomerPONo, int? IsAllStatus, int isAfterMarket)
        {
            try
            {
                PurchaseOrderstr str = new PurchaseOrderstr();
                str.OwnerID = OwnerID;
                str.WarehouseID = WarehouseID;
                str.SupplierID = SupplierID;
                str.CustomerID = CustomerID;
                str.POIssuedDateFrom = POIssuedDateFrom;
                str.POIssuedDateTo = POIssuedDateTo;
                str.SONo = SONo;
                str.PONo = PONo;
                str.CustomerPONo = CustomerPONo;
                str.IsAllStatus = IsAllStatus;
                str.isAfterMarket = isAfterMarket;

                string strResult = RubixWebAPI.ExecuteObjectResult("SalePurchaseOrder/PurchaseOrderDataLoading", JsonConvert.SerializeObject(str));
                return JsonConvert.DeserializeObject<DataSet>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public DataSet PurchaseOrderDataLoadingDetail(string PONo)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("PONo", PONo);
                string strResult = RubixWebAPI.ExecuteObjectResult("SalePurchaseOrder/PurchaseOrderDataLoadingDetail", hs);
                return JsonConvert.DeserializeObject<DataSet>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void PurchaseOrderDeleteData(string PONo)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("PONo", PONo);
                string strResult = RubixWebAPI.ExecuteObjectResult("SalePurchaseOrder/PurchaseOrderDeleteData", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void PurchaseOrderSaveManualData(string PONo, int? OwnerID, int? WarehouseID, int? SupplierID, int? CustomerID, string IssuedDate, string ArrivalDate, string CollectDate, string POInvoiceNo, string Remark, string XMLDetail)
        {
            try
            {
                PurchaseOrderstr str = new PurchaseOrderstr();
                str.PONo = PONo;
                str.OwnerID = OwnerID;
                str.WarehouseID = WarehouseID;
                str.SupplierID = SupplierID;
                str.CustomerID = CustomerID;
                str.POIssuedDate = IssuedDate;
                str.ArrivalDate = ArrivalDate;
                str.CollectDate = CollectDate;
                str.POInvoiceNo = POInvoiceNo;
                str.Remark = Remark;
                str.XMLDetail = XMLDetail;
                str.CurrentUser = AppConfig.UserLogin;
                RubixWebAPI.ExecuteObjectResult("SalePurchaseOrder/PurchaseOrderSaveManualData", JsonConvert.SerializeObject(str));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //A041
        public void PurchaseOrderEditPOInvoice(string PONo, string POInvoiceNo)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("PONo", PONo);
                hs.Add("POInvoiceNo", POInvoiceNo);
                hs.Add("CurrentUser", AppConfig.UserLogin);
                RubixWebAPI.ExecuteObjectResult("SalePurchaseOrder/PurchaseOrderEditPOInvoice", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //A042
        public DataTable PurchaseOrderLoadProductBySONo(string XMLSONo, int? SupplierID)
        {
            try
            {
                PurchaseOrderstr str = new PurchaseOrderstr();
                str.XMLDetail = XMLSONo;
                str.SupplierID = SupplierID;

                string strResult = RubixWebAPI.ExecuteObjectResult("SalePurchaseOrder/PurchaseOrderLoadProductBySONo", JsonConvert.SerializeObject(str));
                return JsonConvert.DeserializeObject<DataTable>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable PurchaseOrderLoadSONo(int? OwnerID, int? WarehouseID, int? CustomerID, string ShippingPeriod, string CustomerPOIssuedDateFrom, string CustomerPOIssuedDateTo, string CustomerPONo, string SONo)
        {
            try
            {
                SaleOrderstr str = new SaleOrderstr();
                str.OwnerID = OwnerID;
                str.WarehouseID = WarehouseID;
                str.CustomerID = CustomerID;
                str.ShippingPeriod = ShippingPeriod;
                str.CustomerPOIssueDateFrom = CustomerPOIssuedDateFrom;
                str.CustomerPOIssueDateTo = CustomerPOIssuedDateTo;
                str.CustomerPONo = CustomerPONo;
                str.SONo = SONo;

                string strResult = RubixWebAPI.ExecuteObjectResult("SalePurchaseOrder/PurchaseOrderLoadSONo", JsonConvert.SerializeObject(str));
                return JsonConvert.DeserializeObject<DataTable>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
 
        //A050
        public DataTable PurchaseOrderDataLoadingConfirm(int? OwnerID, int? WarehouseID, int? SupplierID, int? CustomerID, string POIssuedDateFrom, string POIssuedDateTo, string SONo, string PONo, string CustomerPONo)
        {
            try
            {
                PurchaseOrderstr str = new PurchaseOrderstr();
                str.OwnerID = OwnerID;
                str.WarehouseID = WarehouseID;
                str.SupplierID = SupplierID;
                str.CustomerID = CustomerID;
                str.POIssuedDateFrom = POIssuedDateFrom;
                str.POIssuedDateTo = POIssuedDateTo;
                str.SONo = SONo;
                str.PONo = PONo;
                str.CustomerPONo = CustomerPONo;

                string strResult = RubixWebAPI.ExecuteObjectResult("SalePurchaseOrder/PurchaseOrderDataLoadingConfirm", JsonConvert.SerializeObject(str));
                return JsonConvert.DeserializeObject<DataTable>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        

        public void PurchaseOrderConfirm(string XMLPONo)
        {
            try
            {
                SaleOrderstr str = new SaleOrderstr();
                str.XMLDetail = XMLPONo;
                str.CurrentUser = AppConfig.UserLogin;

                string strResult = RubixWebAPI.ExecuteObjectResult("SalePurchaseOrder/PurchaseOrderConfirm", JsonConvert.SerializeObject(str));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void PurchaseOrderSavePSDInvNo(string XMLdataSave)
        {
            try
            {
                PurchaseOrderPDS str = new PurchaseOrderPDS();
                str.XMLSave = XMLdataSave;
                string strResult = RubixWebAPI.ExecuteObjectResult("SalePurchaseOrder/PurchaseOrderSavePSDInvNo", JsonConvert.SerializeObject(str));
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public DataSet SaleOrder_PreConfirm_Search(string XMLSONo)
        {
            try
            {
                string result = RubixWebAPI.ExecuteObjectResult("SalePurchaseOrder/SaleOrder_PreConfirm_Search", JsonConvert.SerializeObject(XMLSONo));

                return JsonConvert.DeserializeObject<DataSet>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet SaleOrder_PreConfirm_BySONo_Search(string XMLSONo)
        {
            try
            {
                string result = RubixWebAPI.ExecuteObjectResult("SalePurchaseOrder/SaleOrder_PreConfirm_BySONo_Search", JsonConvert.SerializeObject(XMLSONo));

                return JsonConvert.DeserializeObject<DataSet>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaleOrderPreconfirmSave(string XMLSave)
        {
            try
            {
                RubixWebAPI.ExecuteObjectResult("SalePurchaseOrder/SaleOrderPreconfirmSave", JsonConvert.SerializeObject(XMLSave));
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        #endregion

        #region Packing Material
        public void PackingMaterialCheckPreconfirm()
        {
            try
            {
                RubixWebAPI.ExecuteObjectResult("SalePurchaseOrder/PackingMaterialCheckPreconfirm", JsonConvert.SerializeObject(""));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Packing_Material_Summary_Search(string XMLSONo)
        {
            try
            {
                string result = RubixWebAPI.ExecuteObjectResult("SalePurchaseOrder/Packing_Material_Summary_Search", JsonConvert.SerializeObject(XMLSONo));

                return JsonConvert.DeserializeObject<DataSet>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Packing_Material_Summary_Save(string XMLSONo, string XMLAdjust, int CalculateMethod)
        {
            try
            {
                Packing_Material_save str = new Packing_Material_save();
                str.XMLSONo = XMLSONo;
                str.XMLAdjust = XMLAdjust;
                str.CalculateMethod = CalculateMethod;
                str.CurrentUser = AppConfig.UserLogin;
                string result = RubixWebAPI.ExecuteObjectResult("SalePurchaseOrder/Packing_Material_Summary_Save", JsonConvert.SerializeObject(str));

                return JsonConvert.DeserializeObject<DataSet>(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void PurchaseOrder_PackingMaterial_Cancel(string XMLSONo)
        {
            try
            {
                string result = RubixWebAPI.ExecuteObjectResult("SalePurchaseOrder/PurchaseOrder_PackingMaterial_Cancel", JsonConvert.SerializeObject(XMLSONo));
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public void PurchaseOrderPackingMaterialPreConfirmSave(string XMLSave)
        {
            try
            {
                Packing_Material_save str = new Packing_Material_save();
                str.XMLSONo = XMLSave;
                str.CurrentUser = AppConfig.UserLogin;
                RubixWebAPI.ExecuteObjectResult("SalePurchaseOrder/PurchaseOrderPackingMaterialPreConfirmSave", JsonConvert.SerializeObject(str));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}
