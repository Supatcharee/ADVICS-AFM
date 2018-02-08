using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using Advics.Framework;
using System.Collections;
using System.Data;

namespace BusinessLayer
{
    public class ReceivingBusiness
    {
        struct ReceivingConfirm
        {
            public string ReceivingNo;
            public int Installment;
            public int ProductID;
            public decimal ReceiveQty;
            public int? LocationID;
            public int? IsCompleteFlag;
            public string UserName;
        }

        public DataTable ReceivingEntry_SearchBy_ReceivingDate(string ReceivingDate, string UserLogin)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ReceivingDate", ReceivingDate);
                hs.Add("UserLogin", UserLogin);
                string strResult = AdvicsWebAPI.ExecuteObjectResult("HandyTerminal/ReceivingEntry_SearchBy_ReceivingDate", hs);
                return JsonConvert.DeserializeObject<DataTable>(strResult);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DataSet ReceivingEntry_SearchBy_ReceivingNo(string ReceivingNo, int Installment)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ReceivingNo", ReceivingNo);
                hs.Add("Installment", Installment);
                string strResult = AdvicsWebAPI.ExecuteObjectResult("HandyTerminal/ReceivingEntry_SearchBy_ReceivingNo", hs);
                return JsonConvert.DeserializeObject<DataSet>(strResult);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void ReceivingConfirmDetail_Save(string ReceivingNo, int Installment, int ProductID, decimal ReceiveQty, int? LocationID)
        {
            try
            {
                ReceivingConfirm stc = new ReceivingConfirm();
                stc.ReceivingNo = ReceivingNo;
                stc.Installment = Installment;
                stc.ProductID = ProductID;
                stc.ReceiveQty = ReceiveQty;
                stc.LocationID = LocationID;
                stc.UserName = AppConfig.UserLogin;
                string strResult = AdvicsWebAPI.ExecuteObjectResult("HandyTerminal/ReceivingConfirmDetail_Save", JsonConvert.SerializeObject(stc));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void ReceivingConfirmDetail_RMTagSave(string ReceivingNo, int? IsCompleteFlag, DataTable dtRMTag)
        {
            try
            {
                DataSet ds = new DataSet("DataSet");
                dtRMTag.TableName = "DataTable";
                ds.Tables.Add(dtRMTag);
                Hashtable hs = new Hashtable();
                hs.Add("ReceivingNo", ReceivingNo);
                hs.Add("IsCompleteFlag", IsCompleteFlag);
                string strResult = AdvicsWebAPI.ExecuteObjectResult("HandyTerminal/ReceivingConfirmDetail_RMTagSave", hs, JsonConvert.SerializeObject(ds.GetXml()));
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
