using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using CSI.Business.BusinessFactory.Operation.Base;
using System.Transactions;
using Rubix.Framework;
using System.Collections;


namespace CSI.Business.Operation
{
    public class ProductReceiveEntry : BaseReceiving
    {
        #region Member

        #endregion

        #region Properties

        #endregion

        public List<sp_CRCS050_ProductReceiveEntry_SearchAll_Result> DataLoading(int? OwnerID
            , int? WarehouseID
            , int? SupplierID
            , string ReceivingNo
            , int? LineNo
            , int ReceivingCompleted
            , DateTime? ReceivingDateFrom
            , DateTime? ReceivingDateTo
            , string PDSNo
            , string PONo
            , string CustomerPONo
            , DateTime? CustomerPOIssueDateFrom
            , DateTime? CustomerPOIssueDateTo
            , int isAfterMarket
            , int isPackingMaterial
            , int isPart
            )
        {
            try
            {
                return Database.ReceivingContext.sp_CRCS050_ProductReceiveEntry_SearchAll(OwnerID
                    , WarehouseID
                    , SupplierID
                    , string.IsNullOrWhiteSpace(ReceivingNo) ? null : ReceivingNo
                    , LineNo
                    , ReceivingCompleted
                    , ReceivingDateFrom
                    , ReceivingDateTo
                    , string.IsNullOrEmpty(PDSNo) ? null : PDSNo
                    , string.IsNullOrEmpty(PONo) ? null : PONo
                    , string.IsNullOrEmpty(CustomerPONo) ? null : CustomerPONo
                    , CustomerPOIssueDateFrom
                    , CustomerPOIssueDateTo
                    , isAfterMarket
                    , isPackingMaterial
                    , isPart).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ObjectResult<sp_RPT001_ReceivingReport_GetData_Result> GetReceivingReport(string receivingNo)
        {
            try
            {
                return Database.ReportContext.sp_RPT001_ReceivingReport_GetData(receivingNo);

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public bool IsCompleteReceive(decimal qty, decimal? receiveQty)
        {
            try
            {
                if (receiveQty.HasValue)
                    return qty <= receiveQty;
                else
                    return false;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public bool CanSaveReceiveQty(decimal qty, decimal? receiveQty)
        {
            try
            {
                ObjectParameter allow = new ObjectParameter("Result", typeof(bool));
                if (receiveQty.HasValue)
                {
                    Hashtable hs = new Hashtable();
                    Hashtable hsOut = new Hashtable();
                    hs.Add("Qty", qty);
                    hs.Add("ReceiveQty", receiveQty.Value);
                    hsOut.Add("Result", "");

                    Database.ExecuteNonQuery("sp_CRCS050_ProductReceiveEntry_CanSaveQty", hs, ref hsOut);
                    return Convert.ToInt16(hsOut["Result"])==1;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public bool IsAllLineOfReceiving(int OwnerID, string ReceivingNo, int Installment, int selectCnt)
        {
            try
            {
                return (Database.ReceivingContext.tbt_ReceivingInstructionDetail.Count(c => c.OwnerID == OwnerID && c.ReceivingNo == ReceivingNo && c.Installment == Installment) == selectCnt);

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public bool IsReadyToConfirm(sp_CRCS050_ProductReceiveEntry_SearchAll_Result data)
        {
            try
            {
                tbt_ReceivingInstructionDetail detail = Database.ReceivingContext.tbt_ReceivingInstructionDetail.FirstOrDefault(c => c.OwnerID == data.OwnerID && c.ReceivingNo == data.ReceivingNo && c.Installment == data.Installment && (c.ReceiveQty == null || c.ReceiveQty <= 0));
                if (detail == null)
                {
                    tbt_ReceivingStatus status = Database.ReceivingContext.tbt_ReceivingStatus.FirstOrDefault(c => c.OwnerID == data.OwnerID && c.ReceivingNo == data.ReceivingNo && c.Installment == data.Installment && c.StatusID >= 6);
                    return (status == null);
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public int? CheckWorkMethod(int? OwnerID, int? DCID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                Hashtable hsOut = new Hashtable();
                hs.Add("OwnerID", OwnerID);
                hs.Add("WarehouseID", DCID);
                hsOut.Add("result", "");
                Database.ExecuteNonQuery("sp_DSRS010_ConfirmProductStoring_CheckWorkMethod", hs, ref hsOut);

                return Convert.ToInt32(hsOut["result"]);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public List<sp_CRCS051_ConfirmReceivingDetail_Get_Result> GetDetail(string receivingNo, int Installment, out DateTime rcvDate, out int? palletQty)
        {
            try
            {
                ObjectParameter receivingDate = new ObjectParameter("ReceivingDate", typeof(DateTime));
                ObjectParameter noOfPallet = new ObjectParameter("NoOfPallet", typeof(int?));
                List<sp_CRCS051_ConfirmReceivingDetail_Get_Result> result = Database.ReceivingContext.sp_CRCS051_ConfirmReceivingDetail_Get(receivingNo: receivingNo, installment: Installment, receivingDate: receivingDate, noOfPallet: noOfPallet).ToList();
                rcvDate = (DateTime)receivingDate.Value;
                if (noOfPallet.Value is DBNull)
                    palletQty = null;
                else
                    palletQty = (int)noOfPallet.Value;
                return result;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public void SaveDetail(string receivingNo, DateTime? receivingDate, int? noOfPallet, bool isConfirmCompletely, string xml, string UserLogin, int Installment)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ReceivingNo", receivingNo);
                hs.Add("ReceivingDate", receivingDate);
                hs.Add("NoOfPallet", noOfPallet);
                hs.Add("UserID", UserLogin);
                hs.Add("XMLData", xml);
                hs.Add("IsCompleteFlag", (isConfirmCompletely ? 1 : 0));
                hs.Add("Installment", Installment);

                Database.ExecuteNonQuery("sp_CRCS050_ProductReceiveEntry_Save_Detail", hs);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        
        public DateTime? UnplanReceivingEntry_GetExpiryDate(int ProductID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ProductID", ProductID);

                object objResult = Database.ExecuteScalar("sp_CRCS031_UnplanReceivingEntry_GetExpiryDate", hs);
                if (objResult != null)
                {
                    return Convert.ToDateTime(objResult);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
