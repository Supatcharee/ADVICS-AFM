using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using Newtonsoft.Json;

namespace CSI.Business.Operation
{
    public class SalePurchaseOrder 
    {
        #region Member
        private BusinessCommon ims = null;
        #endregion

        #region Properties
        private BusinessCommon Database
        {
            get
            {
                if (ims == null)
                {
                    ims = new BusinessCommon();
                }
                return ims;
            }
        }
        #endregion

        #region Sale Order
        public DataTable SaleOrderDataLoading(int? OwnerID, int? WarehouseID, int? CustomerID, string ShippingPeriod, string CustomerPOIssuedDateFrom, string CustomerPOIssuedDateTo, string CustomerPONo, string SONo, int? IsAllStatus, int? IsPackingMaterial, int IsAfterMarket)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("OwnerID", OwnerID);
                hs.Add("CustomerID", CustomerID);
                hs.Add("WarehouseID", WarehouseID);
                hs.Add("ShippingPeriod", ShippingPeriod);
                hs.Add("CustomerPOIssuedDateFrom", CustomerPOIssuedDateFrom);
                hs.Add("CustomerPOIssuedDateTo", CustomerPOIssuedDateTo);
                hs.Add("CustomerPONo", string.IsNullOrEmpty(CustomerPONo) ? null : CustomerPONo);
                hs.Add("SONo", string.IsNullOrEmpty(SONo) ? null : SONo);
                hs.Add("IsAllStatus", IsAllStatus);
                hs.Add("IsPackingMaterial", IsPackingMaterial);
                hs.Add("IsAfterMarket", IsAfterMarket);

                return Database.ExecuteDataSet("sp_ASO010_SaleOrder_SearchAll", hs).Tables[0];
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
                return Database.ExecuteDataSet("sp_ASO011_SaleOrder_SearchDetail", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaleOrderSaveData(string SONo, int? OwnerID, int? WarehouseID, int? CustomerID, string CustomerPOIssuedDate, string CustomerPONo, string Validity, string ShippingPeriod, string Remark, int isAfterMarket, string XMLDetail, string CurrentUser)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("OwnerID", OwnerID);
                hs.Add("CustomerID", CustomerID);
                hs.Add("WarehouseID", WarehouseID);
                hs.Add("CustomerPOIssuedDate", CustomerPOIssuedDate);
                hs.Add("CustomerPONo", CustomerPONo);
                hs.Add("SONo", string.IsNullOrEmpty(SONo) ? null : SONo);
                hs.Add("Validity", Validity);
                hs.Add("Remark", Remark);
                hs.Add("ShippingPeriod", ShippingPeriod);
                hs.Add("CurrentUser", CurrentUser);
                hs.Add("isAfterMarket", isAfterMarket);
                hs.Add("XMLDetail", XMLDetail);

                Database.ExecuteNonQuery("sp_ASO010_SaleOrder_Save", hs);
                
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
                Database.ExecuteNonQuery("sp_ASO010_SaleOrder_Delete", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool SaleOrderCheckValidCustomerPO(string CustomerPO, DateTime ShippingPeriod)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("CustomerPO", CustomerPO);
                hs.Add("ShippingPeriod", ShippingPeriod);
                return Convert.ToInt16(Database.ExecuteScalar("sp_ASO011_SaleOrder_CheckValidCustomerPO", hs)) == 1;
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
                Hashtable hs = new Hashtable();
                hs.Add("OwnerID", OwnerID);
                hs.Add("CustomerID", CustomerID);
                hs.Add("ProductID", ProductID);
                hs.Add("ShippingPeriod", ShippingPeriod);
                return Convert.ToInt16(Database.ExecuteScalar("sp_ASO011_SaleOrder_CheckShippingCalendar", hs)) == 1;
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
                Hashtable hs = new Hashtable();
                hs.Add("OwnerID", OwnerID);
                hs.Add("ShippingPeriod", ShippingPeriod);
                return Convert.ToInt16(Database.ExecuteScalar("sp_ASO011_SaleOrder_CheckCompanyCalendar", hs)) == 2;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //A020
        public void SaleOrderConfirm(string XMLSONo, string CurrentUser)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("XMLSONo", XMLSONo);
                hs.Add("CurrentUser", CurrentUser);
                Database.ExecuteNonQuery("sp_ASO020_SaleOrder_Confirm", hs);
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
                Hashtable hs = new Hashtable();
                hs.Add("OwnerID", OwnerID);
                hs.Add("CustomerID", CustomerID);
                hs.Add("WarehouseID", WarehouseID);
                hs.Add("ShippingPeriod", ShippingPeriod);
                hs.Add("CustomerPOIssuedDateFrom", CustomerPOIssuedDateFrom);
                hs.Add("CustomerPOIssuedDateTo", CustomerPOIssuedDateTo);
                hs.Add("CustomerPONo", string.IsNullOrEmpty(CustomerPONo) ? null : CustomerPONo);
                hs.Add("SONo", string.IsNullOrEmpty(SONo) ? null : SONo);
                hs.Add("IsAllStatus", IsAllStatus);
                return Database.ExecuteDataSet("sp_ASO030_CheckingSaleOrder_SearchAll", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable CheckingSaleOrderByContainer(string SONo)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("SONo", SONo);
                return Database.ExecuteDataSet("sp_ASO031_SaleOrderByContainer_DataLoading", hs).Tables[0];
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
                Hashtable hs = new Hashtable();
                hs.Add("OwnerID", OwnerID);
                hs.Add("WarehouseID", WarehouseID);
                hs.Add("SupplierID", SupplierID);
                hs.Add("CustomerID", CustomerID);                
                hs.Add("POIssuedDateFrom", POIssuedDateFrom);
                hs.Add("POIssuedDateTo", POIssuedDateTo);
                hs.Add("SONo", string.IsNullOrEmpty(SONo) ? null : SONo );
                hs.Add("PONo", string.IsNullOrEmpty(PONo) ? null : PONo);
                hs.Add("CustomerPONo", string.IsNullOrEmpty(CustomerPONo) ? null : CustomerPONo);
                hs.Add("IsAllStatus", IsAllStatus);
                hs.Add("isAfterMarket", isAfterMarket);

                return Database.ExecuteDataSet("sp_ASO040_PurchaseOrder_SearchAll", hs);
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
                return Database.ExecuteDataSet("sp_ASO041_PurchaseOrder_SearchDetail", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable PurchaseOrderLoadProductBySONo(string XMLSONo, int? SupplierID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("XMLSONo", XMLSONo);
                hs.Add("SupplierID", SupplierID);
                return Database.ExecuteDataSet("sp_ASO042_PurchaseOrder_LoadProductBySONo", hs).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void PurchaseOrderSaveManualData(string PONo, int? OwnerID, int? WarehouseID, int? SupplierID, int? CustomerID, string IssuedDate, string ArrivalDate, string CollectDate, string POInvoiceNo, string Remark, string XMLDetail, string CurrentUser)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("PONo", PONo);
                hs.Add("OwnerID", OwnerID);
                hs.Add("CustomerID", CustomerID);
                hs.Add("WarehouseID", WarehouseID);
                hs.Add("SupplierID", SupplierID);
                hs.Add("IssuedDate", IssuedDate);
                hs.Add("ArrivalDate", ArrivalDate);
                hs.Add("CollectDate", CollectDate);
                hs.Add("POInvoiceNo", POInvoiceNo);
                hs.Add("Remark", Remark);
                hs.Add("CurrentUser", CurrentUser);
                hs.Add("XMLDetail", XMLDetail);
                
                Database.ExecuteNonQuery("sp_ASO040_PurchaseOrder_SaveManual", hs);
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
                Database.ExecuteNonQuery("sp_ASO040_PurchaseOrder_Delete", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void PurchaseOrderRollBackData(string PONo)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("PONo", PONo);
                Database.ExecuteNonQuery("sp_ASO060_RollbackAftMktPlan", hs);
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
                Hashtable hs = new Hashtable();
                hs.Add("OwnerID", OwnerID);
                hs.Add("CustomerID", CustomerID);
                hs.Add("WarehouseID", WarehouseID);
                hs.Add("ShippingPeriod", ShippingPeriod);
                hs.Add("CustomerPOIssuedDateFrom", CustomerPOIssuedDateFrom);
                hs.Add("CustomerPOIssuedDateTo", CustomerPOIssuedDateTo);
                hs.Add("CustomerPONo", string.IsNullOrEmpty(CustomerPONo) ? null : CustomerPONo);
                hs.Add("SONo", string.IsNullOrEmpty(SONo) ? null : SONo);

                return Database.ExecuteDataSet("[sp_ASO042_PurchaseOrder_SearchSONo]", hs).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //A041
        public void PurchaseOrderEditPOInvoice(string PONo, string POInvoiceNo, string CurrentUser)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("PONo", PONo);
                hs.Add("POInvoiceNo", POInvoiceNo);
                hs.Add("CurrentUser", CurrentUser);
                Database.ExecuteNonQuery("sp_ASO041_PurchaseOrder_EditPOInvoice", hs);
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
                Hashtable hs = new Hashtable();
                hs.Add("OwnerID", OwnerID);
                hs.Add("WarehouseID", WarehouseID);
                hs.Add("SupplierID", SupplierID);
                hs.Add("CustomerID", CustomerID);
                hs.Add("POIssuedDateFrom", POIssuedDateFrom);
                hs.Add("POIssuedDateTo", POIssuedDateTo);
                hs.Add("SONo", string.IsNullOrEmpty(SONo) ? null : SONo);
                hs.Add("PONo", string.IsNullOrEmpty(PONo) ? null : PONo);
                hs.Add("CustomerPONo", string.IsNullOrEmpty(CustomerPONo) ? null : CustomerPONo);

                return Database.ExecuteDataSet("sp_ASO040_PurchaseOrder_SearchConfirm", hs).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void PurchaseOrderConfirm(string XMLPONo, string CurrentUser)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("XMLPONo", XMLPONo);
                hs.Add("CurrentUser", CurrentUser);
                Database.ExecuteNonQuery("sp_ASO050_PurchaseOrder_Confirm", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void PurchaseOrderSavePSDInvNo(string XMLSave)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("xmlResult", XMLSave);
                Database.ExecuteNonQuery("sp_ASO040_PurchaseOrder_SavePSDInvNo", hs);
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
                Hashtable hs = new Hashtable();
                hs.Add("XMLSONo", XMLSONo);
                return Database.ExecuteDataSet("sp_ASO021_SaleOrder_PreConfirm_Search", hs);
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
                Hashtable hs = new Hashtable();
                hs.Add("XMLSONo", XMLSONo);
                return Database.ExecuteDataSet("sp_ASO021_SaleOrder_PreConfirm_BySONo_Search", hs);
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
                Hashtable hs = new Hashtable();
                hs.Add("XMLSave", XMLSave);
                Database.ExecuteNonQuery("sp_ASO021_SaleOrder_PreConfirm_Save", hs);
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
                //Database.ExecuteNonQuery("sp_NPM010");
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
                Hashtable hs = new Hashtable();
                hs.Add("XMLSONo", XMLSONo);
                return Database.ExecuteDataSet("sp_NPM012_PurchaseOrder_Adjust_PackingMaterial", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Packing_Material_Summary_Save(string XMLSONo, string XMLAdjust, int CalculateMethod, string CurrentUser)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("XMLSONo", XMLSONo);
                hs.Add("XMLAdjust", XMLAdjust);
                hs.Add("ISIncludeSaftyStock", CalculateMethod);
                hs.Add("CurrentUser", CurrentUser);
                return Database.ExecuteDataSet("sp_NPM012_PurchaseOrder_Save_PackingMaterial", hs);
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
                Hashtable hs = new Hashtable();
                hs.Add("XMLSONo", XMLSONo);
                Database.ExecuteDataSet("sp_NPM012_PurchaseOrder_PackingMaterial_Delete", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void PurchaseOrderPackingMaterialPreConfirmSave(string XMLSave, string CurrentUser)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("XMLSave", XMLSave);
                hs.Add("CurrentUser", CurrentUser);
                Database.ExecuteNonQuery("sp_NPM012_PurchaseOrder_PackingMaterial_PreConfirm_Save", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
