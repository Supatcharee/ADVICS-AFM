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
    public class OrderCancel
    {
        #region Member
        private ObjectResult<sp_ROMS020_OrderCancel_SearchAll_Receiving_Result> lt_Result_rcv = null; // Receiving
        private sp_ROMS020_OrderCancel_SearchAll_Receiving_Result ta_Result_rcv = null; // Receiving
        private ObjectResult<sp_ROMS020_OrderCancel_SearchAll_Shipping_Result> lt_Result_shp = null; // Shipping
        private sp_ROMS020_OrderCancel_SearchAll_Shipping_Result ta_Result_shp = null; // Shipping
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
        private sp_ROMS020_OrderCancel_SearchAll_Receiving_Result ResultDataRcv
        {
            get
            {
                if (ta_Result_rcv == null)
                {
                    ta_Result_rcv = new sp_ROMS020_OrderCancel_SearchAll_Receiving_Result();
                }
                return ta_Result_rcv;
            }
            set { ta_Result_rcv = value; }
        }
        private ObjectResult<sp_ROMS020_OrderCancel_SearchAll_Receiving_Result> ResultListRcv
        {
            get { return lt_Result_rcv; }
            set { lt_Result_rcv = value; }
        }
        #endregion

        #region Shipping
        private sp_ROMS020_OrderCancel_SearchAll_Shipping_Result ResultDataShp
        {
            get
            {
                if (ta_Result_shp == null)
                {
                    ta_Result_shp = new sp_ROMS020_OrderCancel_SearchAll_Shipping_Result();
                }
                return ta_Result_shp;
            }
            set { ta_Result_shp = value; }
        }
        private ObjectResult<sp_ROMS020_OrderCancel_SearchAll_Shipping_Result> ResultListShp
        {
            get { return lt_Result_shp; }
            set { lt_Result_shp = value; }
        }
        #endregion
        #endregion
        
        #region Receiving
        public List<sp_ROMS020_OrderCancel_SearchAll_Receiving_Result> DataLoadReceiving(int? OwnerID, int? WarehouseID, string ReceivingNo)
        {
            try
            {
                return Database.OrderEntity.sp_ROMS020_OrderCancel_SearchAll_Receiving(ownerID: OwnerID
                                                                                       ,warehouseID: WarehouseID
                                                                                       ,receivingNo: ReceivingNo == string.Empty ? null : ReceivingNo).ToList();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public string SaveDataReceiving(List<sp_ROMS020_OrderCancel_SearchAll_Receiving_Result> data)
        {
            try
            {
                string resultmsg = string.Empty;
                
                    foreach (sp_ROMS020_OrderCancel_SearchAll_Receiving_Result item in data)
                    {
                        Hashtable hs = new Hashtable();
                        Hashtable hsOut = new Hashtable();
                        string iReceivingNo = item.ReceivingNo;
                        int iLineNo = item.LineNo;

                        hs.Add("ReceivingNo", iReceivingNo);
                        hs.Add("LineNo", iLineNo);
                        hsOut.Add("MsgID", "");

                        Database.ExecuteNonQuery("sp_ROMS020_OrderCancel_SaveReceiving", hs, ref hsOut);
                        resultmsg = hsOut["MsgID"].ToString();

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

        #region Shipping
        public List<sp_ROMS020_OrderCancel_SearchAll_Shipping_Result> DataLoadShipping(int? OwnerID, int? WarehouseID, string ShipmentNo, string PickingNo, int? CustomerID)
        {
            try
            {
                return Database.OrderEntity.sp_ROMS020_OrderCancel_SearchAll_Shipping(ownerID: OwnerID
                                                                                      ,warehouseID: WarehouseID
                                                                                      ,shipmentNo: ShipmentNo
                                                                                      ,customerID: CustomerID).ToList();

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public string SaveDataShipping(List<sp_ROMS020_OrderCancel_SearchAll_Shipping_Result> data)
        {
            try
            {
                string resultmsg = string.Empty;

                foreach (sp_ROMS020_OrderCancel_SearchAll_Shipping_Result item in data)
                {
                    Hashtable hs = new Hashtable();
                    Hashtable hsOut = new Hashtable();
                    string iShipmentNo = item.ShipmentNo;
                    string iPickingNo = item.PickingNo;
                    int iLineNo = item.LineNo;

                    hs.Add("ShipmentNo", iShipmentNo);
                    hs.Add("PickingNo ", iPickingNo);
                    hs.Add("LineNo", iLineNo);

                    hsOut.Add("MsgID", "");

                    Database.ExecuteNonQuery("sp_ROMS020_OrderCancel_SaveShipping", hs, ref hsOut);
                    resultmsg = hsOut["MsgID"].ToString();

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
