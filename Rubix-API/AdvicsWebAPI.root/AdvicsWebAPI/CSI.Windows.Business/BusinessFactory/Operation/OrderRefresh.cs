using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using System.Transactions;
using Rubix.Framework;
using System.Collections;

namespace CSI.Business.Operation
{
    public class OrderRefresh
    {
        #region Member
        private ObjectResult<sp_ROMS010_OrderRefresh_SearchAll_Receiving_Result> lt_Result_rcv = null; // Receiving
        private sp_ROMS010_OrderRefresh_SearchAll_Receiving_Result ta_Result_rcv = null; // Receiving
        private ObjectResult<sp_ROMS010_OrderRefresh_SearchAll_Shipping_Result> lt_Result_shp = null; // Shipping
        private sp_ROMS010_OrderRefresh_SearchAll_Shipping_Result ta_Result_shp = null; // Shipping
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

        #region Receiving
        private sp_ROMS010_OrderRefresh_SearchAll_Receiving_Result ResultDataRcv
        {
            get
            {
                if (ta_Result_rcv == null)
                {
                    ta_Result_rcv = new sp_ROMS010_OrderRefresh_SearchAll_Receiving_Result();
                }
                return ta_Result_rcv;
            }
            set { ta_Result_rcv = value; }
        }
        private ObjectResult<sp_ROMS010_OrderRefresh_SearchAll_Receiving_Result> ResultListRcv
        {
            get { return lt_Result_rcv; }
            set { lt_Result_rcv = value; }
        }
        public Object SelectDataRcv
        {
            set { ta_Result_rcv = (sp_ROMS010_OrderRefresh_SearchAll_Receiving_Result)value; }
        }
        public bool? SelectRcv
        {
            get { return ResultDataRcv.Select; }
            set { ResultDataRcv.Select = value; }
        }
        public string ReceivingNo
        {
            get { return ResultDataRcv.ReceivingNo; }
            set { ResultDataRcv.ReceivingNo = value; }
        }
        public DateTime? EntryRcv
        {
            get { return ResultDataRcv.Entry; }
            set { ResultDataRcv.Entry = value; }
        }
        public DateTime? TransitInstruction
        {
            get { return ResultDataRcv.TransitInstruction; }
            set { ResultDataRcv.TransitInstruction = value; }
        }
        public DateTime? ReceivingDate
        {
            get { return ResultDataRcv.ReceivingDate; }
            set { ResultDataRcv.ReceivingDate = value; }
        }
        public DateTime? TransitDate
        {
            get { return ResultDataRcv.TransitDate; }
            set { ResultDataRcv.TransitDate = value; }
        }
        public int? DistributionCenterIDRcv
        {
            get { return ResultDataRcv.DistributionCenterID; }
            set { ResultDataRcv.DistributionCenterID = value; }
        }
        public int? SupplierID
        {
            get { return ResultDataRcv.SupplierID; }
            set { ResultDataRcv.SupplierID = value; }
        }
        public string RemarkRcv
        {
            get { return ResultDataRcv.Remark; }
            set { ResultDataRcv.Remark = value; }
        }
        public int Installment
        {
            get { return ResultDataRcv.Installment; }
            set { ResultDataRcv.Installment = value; }
        }
        public string DistributionCenterCodeRcv
        {
            get { return ResultDataRcv.DistributionCenterCode; }
            set { ResultDataRcv.DistributionCenterCode = value; }
        }
        public string SupplierCode
        {
            get { return ResultDataRcv.SupplierCode; }
            set { ResultDataRcv.SupplierCode = value; }
        }
        public string SupplierName
        {
            get { return ResultDataRcv.SupplierCode; }
            set { ResultDataRcv.SupplierCode = value; }
        }
        #endregion

        #region Shipping
        private sp_ROMS010_OrderRefresh_SearchAll_Shipping_Result ResultDataShp
        {
            get
            {
                if (ta_Result_shp == null)
                {
                    ta_Result_shp = new sp_ROMS010_OrderRefresh_SearchAll_Shipping_Result();
                }
                return ta_Result_shp;
            }
            set { ta_Result_shp = value; }
        }
        private ObjectResult<sp_ROMS010_OrderRefresh_SearchAll_Shipping_Result> ResultListShp
        {
            get { return lt_Result_shp; }
            set { lt_Result_shp = value; }
        }
        public Object SelectDataShp
        {
            set { ta_Result_shp = (sp_ROMS010_OrderRefresh_SearchAll_Shipping_Result)value; }
        }
        public bool? SelectShp
        {
            get { return ResultDataShp.Select; }
            set { ResultDataShp.Select = value; }
        }
        public string ShipmentNo
        {
            get { return ResultDataShp.ShipmentNo; }
            set { ResultDataShp.ShipmentNo = value; }
        }
        public DateTime? EntryShp
        {
            get { return ResultDataShp.Entry; }
            set { ResultDataShp.Entry = value; }
        }
        public DateTime? StockControl
        {
            get { return ResultDataShp.StockControl; }
            set { ResultDataShp.StockControl = value; }
        }
        public DateTime? PickingInstruction
        {
            get { return ResultDataShp.PickingInstruction; }
            set { ResultDataShp.PickingInstruction = value; }
        }
        public DateTime? Picking
        {
            get { return ResultDataShp.Picking; }
            set { ResultDataShp.Picking = value; }
        }
        public DateTime? Shipping
        {
            get { return ResultDataShp.Shipping; }
            set { ResultDataShp.Shipping = value; }
        }
        public DateTime? Transporation
        {
            get { return ResultDataShp.Transporation; }
            set { ResultDataShp.Transporation = value; }
        }
        public int? DistributionCenterIDShp
        {
            get { return ResultDataShp.DistributionCenterID; }
            set { ResultDataShp.DistributionCenterID = value; }
        }
        public DateTime? DeliveryDate
        {
            get { return ResultDataShp.DeliveryDate; }
            set { ResultDataShp.DeliveryDate = value; }
        }
        public int? FinalDestinationID
        {
            get { return ResultDataShp.FinalDestinationID; }
            set { ResultDataShp.FinalDestinationID = value; }
        }
        public string DistributionCenterCodeShp
        {
            get { return ResultDataShp.DistributionCenterCode; }
            set { ResultDataShp.DistributionCenterCode = value; }
        }
        public string FinalDestinationCode
        {
            get { return ResultDataShp.FinalDestinationCode; }
            set { ResultDataShp.FinalDestinationCode = value; }
        }
        public string PortCode
        {
            get { return ResultDataShp.PortCode; }
            set { ResultDataShp.PortCode = value; }
        }
        public string PortName
        {
            get { return ResultDataShp.PortName; }
            set { ResultDataShp.PortName = value; }
        }
        public string RemarkShp
        {
            get { return ResultDataShp.Remark; }
            set { ResultDataShp.Remark = value; }
        }
        #endregion

        #endregion
        
        #region Receiving
        public List<sp_ROMS010_OrderRefresh_SearchAll_Receiving_Result> DataLoadReceiving(int? OwnerID, int? WarehouseID, string ReceivingNo)
        {
            try
            {
                return Database.OrderEntity.sp_ROMS010_OrderRefresh_SearchAll_Receiving(ownerID: OwnerID
                                                                                        ,warehouseID: WarehouseID
                                                                                        , receivingNo: ReceivingNo == string.Empty ? null : ReceivingNo).ToList();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        public void SaveDataReceiving(List<sp_ROMS010_OrderRefresh_SearchAll_Receiving_Result> data)
        {
            try
            {
                foreach (sp_ROMS010_OrderRefresh_SearchAll_Receiving_Result item in data)
                {
                    int? OwnerID = item.OwnerID;
                    string iReceivingNo = item.ReceivingNo;

                    Hashtable hs = new Hashtable();
                    hs.Add("OwnerID", OwnerID);
                    hs.Add("ReceivingNo", iReceivingNo);
                    Database.ExecuteNonQuery("sp_ROMS010_OrderRefresh_SaveReceiving", hs);
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Shipping
        public List<sp_ROMS010_OrderRefresh_SearchAll_Shipping_Result> DataLoadShipping(int? OwnerID, int? WarehouseID, string ShipmentNo, string PickingNo,int? CustomerID)
        {
            try
            {

                return Database.OrderEntity.sp_ROMS010_OrderRefresh_SearchAll_Shipping(ownerID: OwnerID
                                                                                       ,warehouseID: WarehouseID
                                                                                       ,shipmentNo: ShipmentNo == string.Empty ? null : ShipmentNo
                                                                                       ,pickingNo: PickingNo == string.Empty ? null : PickingNo
                                                                                       ,customerID: CustomerID).ToList();

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        public String SaveDataShipping(List<sp_ROMS010_OrderRefresh_SearchAll_Shipping_Result> data)
        {
            try
            {
                string resultmsg = string.Empty;

                foreach (sp_ROMS010_OrderRefresh_SearchAll_Shipping_Result item in data)
                {
                    ObjectParameter result = new ObjectParameter("ErrorMsg", typeof(string));
                    string iShippingNo = item.ShipmentNo;
                    string PickingNo = item.PickingNo;
                    Hashtable hs = new Hashtable();
                    Hashtable hsOut = new Hashtable();

                    hs.Add("ShipmentNo", iShippingNo);
                    hs.Add("PickingNo", PickingNo);
                    hsOut.Add("ErrorMsg", "");

                    Database.ExecuteNonQuery("sp_ROMS010_OrderRefresh_SaveShipping", hs, ref hsOut);
                    resultmsg = hsOut["ErrorMsg"].ToString();

                    if (!string.IsNullOrEmpty(resultmsg))
                    {
                        return resultmsg;
                    }
                }

                return resultmsg;
            }
            catch
            {
                throw;
            }
        }
        #endregion

    }
}
