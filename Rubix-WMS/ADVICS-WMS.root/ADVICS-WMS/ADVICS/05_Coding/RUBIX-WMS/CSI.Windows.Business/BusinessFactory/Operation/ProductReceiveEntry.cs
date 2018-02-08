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
using Newtonsoft.Json;


namespace CSI.Business.Operation
{
    public class ProductReceiveEntry : BaseReceiving
    {
        #region Member
        struct GetDetailReturnStruct
        {
            public List<sp_CRCS051_ConfirmReceivingDetail_Get_Result> list;
            public DateTime rcvDate;
            public int? palletQty;
        }

        struct DataLoadingstr
        {
            public int? OwnerID;
            public int? WarehouseID;
            public int? SupplierID;
            public string ReceivingNo;
            public int? LineNo;
            public int ReceivingCompleted;
            public DateTime? ReceivingDateFrom;
            public DateTime? ReceivingDateTo;
            public string PDSNo;
            public string PONo;
            public string CustomerPONo;
            public DateTime? CustomerPOIssueDateFrom;
            public DateTime? CustomerPOIssueDateTo;
            public int isAfterMarket;
            public int isPackingMaterial;
            public int isPart;
        }
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
                                                                , int isPart )
        {
            try
            {
                DataLoadingstr stc = new DataLoadingstr();
                stc.OwnerID = OwnerID;
                stc.WarehouseID = WarehouseID;
                stc.SupplierID = SupplierID;
                stc.ReceivingNo = ReceivingNo;
                stc.LineNo = LineNo;
                stc.ReceivingCompleted = ReceivingCompleted;
                stc.ReceivingDateFrom = ReceivingDateFrom;
                stc.ReceivingDateTo = ReceivingDateTo;
                stc.PDSNo = PDSNo;
                stc.PONo = PONo;
                stc.CustomerPONo = CustomerPONo;
                stc.CustomerPOIssueDateFrom = CustomerPOIssueDateFrom;
                stc.CustomerPOIssueDateTo = CustomerPOIssueDateTo;
                stc.isAfterMarket = isAfterMarket;
                stc.isPackingMaterial = isPackingMaterial;
                stc.isPart = isPart;

                string strResult = RubixWebAPI.ExecuteObjectResult("ProductReceiveEntry/DataLoading", JsonConvert.SerializeObject(stc));
                return JsonConvert.DeserializeObject<List<sp_CRCS050_ProductReceiveEntry_SearchAll_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<sp_RPT001_ReceivingReport_GetData_Result> GetReceivingReport(string receivingNo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("receivingNo", receivingNo);
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ProductReceiveEntry/GetReceivingReport", hs);
                return JsonConvert.DeserializeObject<List<sp_RPT001_ReceivingReport_GetData_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IsCompleteReceive(decimal? qty, decimal? receiveQty)
        {
            if (receiveQty.HasValue)
                return qty <= receiveQty;
            else
                return false;
        }

        public bool CanSaveReceiveQty(decimal? qty, decimal? receiveQty)
        {
            Hashtable hs = new Hashtable();
            hs.Add("qty", qty);
            hs.Add("receiveQty", receiveQty);
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ProductReceiveEntry/CanSaveReceiveQty", hs);
                return JsonConvert.DeserializeObject<bool>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IsAllLineOfReceiving(int customerID, string receivingNo, int installment, int selectCnt)
        {
            Hashtable hs = new Hashtable();
            hs.Add("customerID", customerID);
            hs.Add("receivingNo", receivingNo);
            hs.Add("installment", installment);
            hs.Add("selectCnt", selectCnt);
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ProductReceiveEntry/IsAllLineOfReceiving", hs);
                return JsonConvert.DeserializeObject<bool>(strResult);
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
                string strResult = RubixWebAPI.ExecuteObjectResult("ProductReceiveEntry/IsReadyToConfirm",JsonConvert.SerializeObject(data));
                return JsonConvert.DeserializeObject<bool>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CheckWorkMethod(int? OwnerID, int? WarehouseID, out string messageId)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);
            messageId = string.Empty;
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ProductReceiveEntry/CheckWorkMethod", hs);
                int? result = JsonConvert.DeserializeObject<int?>(strResult);
                if (result == null || result == 0)
                {
                    messageId = "I0132";
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Confirm(List<sp_CRCS050_ProductReceiveEntry_SearchAll_Result> list, Dictionary<string, ConfirmDetail> confirmDetail)
        {

            string pvRcv = string.Empty;
            string revKey = string.Empty;
            int pvInstallment = -1;
            foreach (sp_CRCS050_ProductReceiveEntry_SearchAll_Result data in list)
            {
                if (data.ReceivingNo.Equals(pvRcv, StringComparison.InvariantCultureIgnoreCase) && data.Installment == pvInstallment)
                    continue;
                else
                {
                    pvInstallment = data.Installment;
                    pvRcv = data.ReceivingNo;
                }
                revKey = string.Format("{0}|{1}", pvRcv, pvInstallment);

                #region "GenXML"
                string XML_TEMPLATE = "<Tab xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">{0}</Tab>";
                string REC_TEMPLATE = "<Rec>{0}</Rec>";
                string LINE_NO_TEMPLATE = "<LineNo><![CDATA[{0}]]></LineNo>";
                string RECEIVE_QTY_TEMPLATE = "<ReceiveQty><![CDATA[{0}]]></ReceiveQty>";
                string LOT_NO_TEMPLATE = "<LotNo><![CDATA[{0}]]></LotNo>";
                string CONDITION_TEMPLATE = "<Condition><![CDATA[{0}]]></Condition>";
                string EXPIRED_DATE_TEMPLATE = "<ExpDate><![CDATA[{0}]]></ExpDate>";
                string RECEIVE_QTY_NULL_TEMPLATE = "<ReceiveQty xsi:nil=\"true\" />";
                string LOT_NO_NULL_TEMPLATE = "<LotNo xsi:nil=\"true\" />";
                string CONDITION_NULL_TEMPLATE = "<Condition xsi:nil=\"true\" />";
                string EXPIRED_DATE_NULL_TEMPLATE = "<ExpDate xsi:nil=\"true\" />";
                //string NEW_LINE_TEMPLATE = "<NewLine>{0}</NewLine>";

                StringBuilder record = new StringBuilder();
                foreach (sp_CRCS051_ConfirmReceivingDetail_Get_Result rec in confirmDetail[revKey].Data)
                {
                    if (rec.ReceiveQty.HasValue || !string.IsNullOrWhiteSpace(rec.ActualLotNo))
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append(string.Format(LINE_NO_TEMPLATE, rec.LineNo));

                        if (rec.ReceiveQty.HasValue)
                            sb.Append(string.Format(RECEIVE_QTY_TEMPLATE, rec.ReceiveQty)); //Receive Qty จะเป็น Level 2
                        else
                            sb.Append(RECEIVE_QTY_NULL_TEMPLATE);

                        if (string.IsNullOrWhiteSpace(rec.ActualLotNo))
                            sb.Append(LOT_NO_NULL_TEMPLATE);
                        else
                            sb.Append(string.Format(LOT_NO_TEMPLATE, rec.ActualLotNo));

                        if (rec.ReceiveQty.HasValue)
                            sb.Append(string.Format(CONDITION_TEMPLATE, rec.ActualProductConditionID));
                        else
                            sb.Append(CONDITION_NULL_TEMPLATE);

                        if (rec.ExpiredDate.HasValue)
                            sb.Append(string.Format(EXPIRED_DATE_TEMPLATE, string.Format("{0}-{1}-{2}", rec.ExpiredDate.Value.Year, rec.ExpiredDate.Value.Month, rec.ExpiredDate.Value.Day)));
                        else
                            sb.Append(EXPIRED_DATE_NULL_TEMPLATE);

                        record.AppendLine(string.Format(REC_TEMPLATE, sb.ToString()));
                    }

                    confirmDetail[revKey].Installment = pvInstallment;
                }
                SaveDetail(confirmDetail[revKey].ReceivingNo, confirmDetail[revKey].ReceivingDate, data.NoOfPallet, confirmDetail[revKey].IsConfirmCompletely
                , string.Format(XML_TEMPLATE, record.ToString()), confirmDetail[revKey].Installment);
                #endregion
            }
        }

        public void ConfirmUnplanReceivingEntry(tbt_ReceivingInstructionHeader rcv)
        {
            tbt_ReceivingInstructionHeader header = DataUtil.Clone(rcv);

            string XML_TEMPLATE = "<Tab xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">{0}</Tab>";
            string REC_TEMPLATE = "<Rec>{0}</Rec>";
            string LINE_NO_TEMPLATE = "<LineNo><![CDATA[{0}]]></LineNo>";
            string RECEIVE_QTY_TEMPLATE = "<ReceiveQty><![CDATA[{0}]]></ReceiveQty>";
            string LOT_NO_TEMPLATE = "<LotNo><![CDATA[{0}]]></LotNo>";
            string CONDITION_TEMPLATE = "<Condition><![CDATA[{0}]]></Condition>";
            string EXPIRED_DATE_TEMPLATE = "<ExpDate><![CDATA[{0}]]></ExpDate>";
            //string RECEIVE_QTY_NULL_TEMPLATE = "<ReceiveQty xsi:nil=\"true\" />";
            //string LOT_NO_NULL_TEMPLATE = "<LotNo xsi:nil=\"true\" />";
            //string CONDITION_NULL_TEMPLATE = "<Condition xsi:nil=\"true\" />";
            string EXPIRED_DATE_NULL_TEMPLATE = "<ExpDate xsi:nil=\"true\" />";
            //string NEW_LINE_TEMPLATE = "<NewLine>{0}</NewLine>";

            StringBuilder record = new StringBuilder();
            foreach (tbt_ReceivingInstructionDetail rec in header.tbt_ReceivingInstructionDetail.ToList())
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(string.Format(LINE_NO_TEMPLATE, rec.LineNo));

                sb.Append(string.Format(RECEIVE_QTY_TEMPLATE, rec.Qty));
                sb.Append(string.Format(LOT_NO_TEMPLATE, rec.LotNo));
                sb.Append(string.Format(CONDITION_TEMPLATE, rec.ProductConditionID));

                if (rec.ExpiredDate.HasValue)
                {
                    sb.Append(string.Format(EXPIRED_DATE_TEMPLATE, string.Format("{0}-{1}-{2}", rec.ExpiredDate.Value.Year, rec.ExpiredDate.Value.Month, rec.ExpiredDate.Value.Day)));
                }
                else
                {
                    sb.Append(EXPIRED_DATE_NULL_TEMPLATE);
                }

                record.AppendLine(string.Format(REC_TEMPLATE, sb.ToString()));
            }
            SaveDetail(rcv.ReceivingNo, DateTime.Now, rcv.PalletQty, true, string.Format(XML_TEMPLATE, record.ToString()), rcv.Installment);
        }

        public List<sp_CRCS051_ConfirmReceivingDetail_Get_Result> GetDetail(string receivingNo, out DateTime rcvDate, out int? palletQty, int installment)
        {
            Hashtable hs = new Hashtable();
            hs.Add("receivingNo", receivingNo);
            hs.Add("installment", installment);
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ProductReceiveEntry/GetDetail", hs);
                GetDetailReturnStruct result = JsonConvert.DeserializeObject<GetDetailReturnStruct>(strResult);
                rcvDate = result.rcvDate;
                palletQty = result.palletQty;
                return result.list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveDetail(string receivingNo, DateTime? receivingDate, int? noOfPallet, bool isConfirmCompletely, string xml, int installment)
        {
            Hashtable hs = new Hashtable();
            hs.Add("receivingNo", receivingNo);
            hs.Add("receivingDate", receivingDate);
            hs.Add("noOfPallet", noOfPallet);
            hs.Add("isConfirmCompletely", isConfirmCompletely);
            hs.Add("UserLogin", AppConfig.UserLogin);
            hs.Add("Installment", installment);

            try
            {
                RubixWebAPI.ExecuteObjectResult("ProductReceiveEntry/SaveDetail", hs, JsonConvert.SerializeObject(xml));
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

                string strResult = RubixWebAPI.ExecuteObjectResult("ProductReceiveEntry/UnplanReceivingEntry_GetExpiryDate", hs);
                return JsonConvert.DeserializeObject<DateTime?>(strResult);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }        
    }
}
