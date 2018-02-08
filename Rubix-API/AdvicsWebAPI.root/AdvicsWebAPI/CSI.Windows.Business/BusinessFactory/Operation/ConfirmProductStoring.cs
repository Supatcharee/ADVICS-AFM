using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using CSI.Business.BusinessFactory.Operation.Base;
using System.Data;
using System.Transactions;
using Rubix.Framework;
using System.IO;
using System.Collections;

namespace CSI.Business.Operation
{
    public class ConfirmProductStoring : BaseReceiving
    {
        public List<sp_DSRS010_ConfirmProductStoring_SearchAll_Result> DataLoading(int? OwnerID, int? WarehouseID, string receivingNo, int? lineNo, int? supplierID, bool showConfirm, int? isAfterMarket, DateTime? TransitDateFrom, DateTime? TransitDateTo, int? isPackingMaterial, int? isPart)
        {
            try
            {
                int intShowConfirm = 0;
                if (showConfirm)
                    intShowConfirm = 1;
                return Database.TransitContext.sp_DSRS010_ConfirmProductStoring_SearchAll(ownerID: OwnerID, warehouseID: WarehouseID, receivingNo: receivingNo, lineNo: lineNo, supplierID: supplierID, showConfirm: intShowConfirm, isAfterMarket: isAfterMarket, transitDateFrom: TransitDateFrom, transitDateTo: TransitDateTo, isPackingMaterial: isPackingMaterial, isPart: isPart).ToList();

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public tbt_TransitInstructionItems GetTransItem(string receivingNo, int installment, int OwnerID, int lineNo)
        {
            try
            {
                ObjectQuery<tbt_TransitInstructionItems> query = (ObjectQuery<tbt_TransitInstructionItems>)Database.TransitContext.tbt_TransitInstructionItems.Where(c => c.ReceivingNo == receivingNo && c.Installment == installment && c.OwnerID == OwnerID && c.LineNo == lineNo);
                return query.Execute(MergeOption.OverwriteChanges).SingleOrDefault();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public List<sp_DSRS010_ConfirmProductStoring_LoadTransitConfirm_Result> LoadTransitConfirm(int OwnerID, string receivingNo, int installment, int lineNo, int rcvSeq)
        {
            try
            {
                return Database.TransitContext.sp_DSRS010_ConfirmProductStoring_LoadTransitConfirm(ownerID: OwnerID, receivingNo: receivingNo, installment: installment, lineNo: lineNo, receiveSeq: rcvSeq).ToList();

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public List<sp_DSRS010_ConfirmProductStoring_LoadSuggest_Result> LoadSuggestion(string receivingNo, int lineNo, int receiveSeq)
        {
            try
            {
                return Database.TransitContext.sp_DSRS010_ConfirmProductStoring_LoadSuggest(lineNo: lineNo, receiveSeq: receiveSeq, receivingNo: receivingNo).ToList();

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public sp_DSRS010_ConfirmProductStoring_LoadStockByLocation_Result LoadDefaultTransitConfirm(int locationID)
        {
            try
            {
                return Database.TransitContext.sp_DSRS010_ConfirmProductStoring_LoadStockByLocation(locationID: locationID).FirstOrDefault();

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public int GetConfirmTransitStatusID()
        {
            try
            {
                return 7;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        
        public bool SaveChanges(tbt_TransitInstructionItems transit, EntityState es)
        {
            try
            {
                if (es == EntityState.Added)
                {
                    Database.TransitContext.tbt_TransitInstructionItems.AddObject(transit);
                }
                else if (es == EntityState.Deleted)
                    Database.TransitContext.tbt_TransitInstructionItems.DeleteObject(transit);

                int result = (Context.SaveChanges());
                Hashtable hs = new Hashtable();
                hs.Add("OwnerID", transit.OwnerID);
                hs.Add("ReceivingNo", transit.ReceivingNo);
                hs.Add("Installment", transit.Installment);
                Database.ExecuteNonQuery("sp_BRES011_ReceivingEntry_Detail_UpdatePallet", hs);
                return result >= 1;
            }
            catch
            {
                throw;
            }
        }

        public int SaveChanges()
        {
            try
            {
                return Context.SaveChanges();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public int Confirm(List<sp_DSRS010_ConfirmProductStoring_SearchAll_Result> list, string UserLogin)
        {
            try
            {
                int result = 0;
                if (list == null)
                {
                    return result;
                }
                const string XML_FORMAT = "<Tab>{0}</Tab>";
                const string REC_FORMAT = "<Rec>{0}</Rec>";
                const string RCV_NO_FORMAT = "<RcvNo>{0}</RcvNo>";
                const string CUS_ID_FORMAT = "<CusID>{0}</CusID>";
                const string INSTALLMENT_FORMAT = "<INS>{0}</INS>";
                const string LINE_NO_FORMAT = "<LINE>{0}</LINE>";
                const string RCV_SEQ_FORMAT = "<RcvSeq>{0}</RcvSeq>";
                const string TRANS_QTY_FORMAT = "<Qty>{0}</Qty>";
                const string LOC_ID_FORMAT = "<LocID>{0}</LocID>";
                const string FLAG_FORMAT = "<FullFlag>{0}</FullFlag>";
                const string PRODUCT_ID_FORMAT = "<ProID>{0}</ProID>";
                const string PRODUCT_CONDITION_ID_FORMAT = "<ProConID>{0}</ProConID>";
                const string WarehouseID_FORMAT = "<WarehouseID>{0}</WarehouseID>";
                const string PALLET_FORMAT = "<PalletNo>{0}</PalletNo>";
                const string LOT_FORMAT = "<LotNo>{0}</LotNo>";

                StringBuilder records = new StringBuilder();
                foreach (sp_DSRS010_ConfirmProductStoring_SearchAll_Result data in list)
                {
                    if (data.Select.HasValue && data.Select.Value && data.TransitSeq == 0)
                    {
                        records.Append(string.Format(REC_FORMAT,
                                string.Format(RCV_NO_FORMAT, data.ReceivingNo)
                                + string.Format(CUS_ID_FORMAT, data.OwnerID)
                                + string.Format(INSTALLMENT_FORMAT, data.Installment)
                                + string.Format(LINE_NO_FORMAT, data.LineNo)
                                + string.Format(RCV_SEQ_FORMAT, data.ReceiveSeq)
                                + string.Format(TRANS_QTY_FORMAT, data.TransitQty)
                                + string.Format(LOC_ID_FORMAT, data.LocationID)
                                + string.Format(PRODUCT_ID_FORMAT, data.ProductID)
                                + string.Format(PRODUCT_CONDITION_ID_FORMAT, data.ProductConditionID)
                                + string.Format(WarehouseID_FORMAT, data.WarehouseID)
                                + string.Format(PALLET_FORMAT, data.PalletNo)
                                + string.Format(LOT_FORMAT, data.LotNo)
                                + string.Format(FLAG_FORMAT, (data.FullFlag.HasValue && data.FullFlag.Value ? 1 : 0))
                            )
                        );
                    }
                }
                Hashtable hs = new Hashtable();
                hs.Add("XMLData", string.Format(XML_FORMAT, records.ToString()));
                hs.Add("UserID", UserLogin);
                hs.Add("ByWindow", 1);
                Database.ExecuteNonQuery("sp_DSRS010_ConfirmProductStoring_Confirm", hs);
                return 1;
            }
            catch (Exception ex)
            {                
                throw ex;
            }
            
        }

        public int? CheckWorkMethod(int? OwnerID, int? WarehouseID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                Hashtable hsOut = new Hashtable();

                hs.Add("OwnerID", OwnerID);
                hs.Add("WarehouseID", WarehouseID);
                hsOut.Add("result", "");//result เป็น in out

                Database.ExecuteNonQuery("sp_DSRS010_ConfirmProductStoring_CheckWorkMethod", hs, ref hsOut);

                return (int?)(hsOut["result"]);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
           
        }

        public void Confirm(int OwnerID, string ReceivingNo, int Installment, int LineNo, int transitSeq, int WarehouseID, string PalletNo, int ProductID, int ProductConditionID, string UpdateUser)
        {
            try
            {
                tbt_TransitConfirmed tc = Database.TransitContext.tbt_TransitConfirmed.Where(c => c.OwnerID == OwnerID && c.ReceivingNo == ReceivingNo && c.Installment == Installment && c.LineNo == LineNo && c.TransitSeq == transitSeq).FirstOrDefault();
                if (tc != null)
                {
                    if (tc.ConfirmFlag)
                        return;
                    tc.ConfirmFlag = true;
                    tc.StockActualQty = tc.TransitQty;
                    tc.LastUpdate = DateTime.Now;
                }
                tbt_ReceivingStatus rs = Database.ReceivingContext.tbt_ReceivingStatus.FirstOrDefault(c => c.OwnerID == OwnerID && c.ReceivingNo == ReceivingNo && c.Installment == Installment && c.LineNo == LineNo);
                rs.StatusID = GetConfirmTransitStatusID();
                rs.TransitDate = rs.ReceivingDate;
                rs = Database.ReceivingContext.tbt_ReceivingStatus.FirstOrDefault(c => c.OwnerID == OwnerID && c.ReceivingNo == ReceivingNo && c.Installment == Installment && c.LineNo != LineNo && c.StatusID != 60); //60 = Complete Transit
                if (rs == null)
                {
                    tbt_ReceivingInstructionHeader rh = Database.ReceivingContext.tbt_ReceivingInstructionHeader.FirstOrDefault(c => c.OwnerID == OwnerID && c.ReceivingNo == ReceivingNo && c.Installment == Installment);
                    rh.SlipCompleteDate = DateTime.Now;
                    rh.UpdateUser = UpdateUser;
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public void ClearData(List<sp_DSRS010_ConfirmProductStoring_SearchAll_Result> list)
        {
            try
            {
                if (list == null)
                    return;
                foreach (sp_DSRS010_ConfirmProductStoring_SearchAll_Result data in list)
                {
                    if (data.LocationID.HasValue)
                        this.ClearData(data.OwnerID, data.ReceivingNo, data.Installment, data.LineNo);
                }
                this.SaveChanges();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public void ClearData(int OwnerID, string ReceivingNo, int Installment, int LineNo)
        {
            try
            {
                foreach (tbt_TransitConfirmed tc in Database.TransitContext.tbt_TransitConfirmed.Where(c => c.OwnerID == OwnerID && c.ReceivingNo == ReceivingNo && c.Installment == Installment && c.LineNo == LineNo && !c.ConfirmFlag))
                {
                    Database.TransitContext.tbt_TransitConfirmed.DeleteObject(tc);
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public ObjectResult<sp_common_LoadByLocationType_Result> LoadAllLocation(int? OwnerID, int? WarehouseID)
        {
            try
            {
                return Database.CommonContext.sp_common_LoadByLocationType(ownerID: OwnerID, warehouseID: WarehouseID);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable ReprintReceivingLabelDataLoading(int? OwnerID, int? WarehouseID, string ArrivalDateFrom, string ArrivalDateTo)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("OwnerID", OwnerID);
                hs.Add("WarehouseID", WarehouseID);
                hs.Add("ArrivalDateFrom", ArrivalDateFrom);
                hs.Add("ArrivalDateTo", ArrivalDateTo);
                return Database.ExecuteDataSet("sp_DSRS012_ReprintReceivingLabel_Search", hs).Tables[0];
            }
            catch (Exception ex)
            {                
                throw ex;
            }
           
        }
        
    }
}
