using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using Advics.Framework;
using System.Collections;
using System.Data;

namespace BusinessLayer
{
    public class PickingBusiness
    {
        struct Pickingstc
        {
            public string PickingNo;
            public string ShipmentNo;
            public int Installment;
            public int LineNo;
            public int LocationID;
            public int ProductID;
            public int ProductConditionID;
            public string PalletNo;
            public string LotNo;
            public int WarehouseID;
            public int PickingLineSeq;
            public decimal PickQty;
            public int UnitOfOrderQty;
            public string xmlRMTag;
            public string UserName;
        }

        struct PickingPackingMaterial
        {
            public string xmlRMTag;
            public string UserID;
        }

        public DataTable PickingEntry_SearchBy_PickingDate(string PickingDate, string UserLogin)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("PickingDate", PickingDate);
                hs.Add("UserLogin", UserLogin);
                string strResult = AdvicsWebAPI.ExecuteObjectResult("HandyTerminal/PickingEntry_SearchBy_PickingDate", hs);
                return JsonConvert.DeserializeObject<DataTable>(strResult);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DataSet PickingEntry_SearchBy_PickingNo(string PickingNo, int Installment)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("PickingNo", PickingNo);
                hs.Add("Installment", Installment);
                string strResult = AdvicsWebAPI.ExecuteObjectResult("HandyTerminal/PickingEntry_SearchBy_PickingNo", hs);
                return JsonConvert.DeserializeObject<DataSet>(strResult);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void PickingConfirmationDetail_Save(string PickingNo, int Installment, int ProductID, decimal PickQty, DataTable dtRMTag, string UserName)
        {
            DataSet ds = new DataSet("DataSet");
            try
            {
                dtRMTag.TableName = "DataTable";
                ds.Tables.Add(dtRMTag.Copy());
                Pickingstc stc = new Pickingstc();
                stc.PickingNo = PickingNo;
                stc.Installment = Installment;
                stc.ProductID = ProductID;
                stc.PickQty = PickQty;
                stc.xmlRMTag = ds.GetXml();
                stc.UserName = UserName;
                string strResult = AdvicsWebAPI.ExecuteObjectResult("HandyTerminal/PickingConfirmationDetail_Save", JsonConvert.SerializeObject(stc));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ds.Tables.Clear();
                ds.Clear();
            }
        }

        public void PickingPackingMaterial_Save(string xmlRMTag, string UserID)
        {
            try
            {
                PickingPackingMaterial stc = new PickingPackingMaterial();
                stc.xmlRMTag = xmlRMTag;
                stc.UserID = UserID;
                string strResult = AdvicsWebAPI.ExecuteObjectResult("HandyTerminal/PickingPackingMaterial_Save", JsonConvert.SerializeObject(stc));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
