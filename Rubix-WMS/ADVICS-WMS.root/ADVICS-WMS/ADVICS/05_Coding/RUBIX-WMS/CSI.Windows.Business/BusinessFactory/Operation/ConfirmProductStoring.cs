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
using System.Collections;
using Newtonsoft.Json;
using System.IO;

namespace CSI.Business.Operation
{
    public class ConfirmProductStoring : BaseReceiving
    {
        #region Member
        struct SaveChangesStruct
        {
            public tbt_TransitInstructionItems transit;
            public EntityState entityState;
        }
        #endregion

        public List<sp_DSRS010_ConfirmProductStoring_SearchAll_Result> DataLoading(int? OwnerID, int? WarehouseID, string ReceivingNo, int? LineNo, int? SupplierID, bool ShowConfirm, int? isAfterMarket, DateTime? TransitDateFrom, DateTime? TransitDateTo, int? isPackingMaterial, int? isPart)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("ReceivingNo", ReceivingNo);
            hs.Add("LineNo", LineNo);
            hs.Add("SupplierID", SupplierID);
            hs.Add("ShowConfirm", ShowConfirm);
            hs.Add("isAfterMarket", isAfterMarket);
            hs.Add("TransitDateFrom", TransitDateFrom);
            hs.Add("TransitDateTo", TransitDateTo);
            hs.Add("isPackingMaterial", isPackingMaterial);
            hs.Add("isPart", isPart);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ConfirmProductStoring/DataLoading", hs);
                return JsonConvert.DeserializeObject<List<sp_DSRS010_ConfirmProductStoring_SearchAll_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            } 
        }

        public tbt_TransitInstructionItems GetTransItem(string ReceivingNo, int Installment, int OwnerID, int LineNo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ReceivingNo", ReceivingNo);
            hs.Add("Installment", Installment);
            hs.Add("OwnerID", OwnerID);
            hs.Add("LineNo", LineNo);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ConfirmProductStoring/GetTransItem", hs);
                return JsonConvert.DeserializeObject<tbt_TransitInstructionItems>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            } 
        }

        public List<sp_DSRS010_ConfirmProductStoring_LoadTransitConfirm_Result> LoadTransitConfirm(int OwnerID, string ReceivingNo, int Installment, int LineNo, int rcvSeq)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("ReceivingNo", ReceivingNo);
            hs.Add("Installment", Installment);
            hs.Add("LineNo", LineNo);
            hs.Add("rcvSeq", rcvSeq);
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ConfirmProductStoring/LoadTransitConfirm", hs);
                return JsonConvert.DeserializeObject<List<sp_DSRS010_ConfirmProductStoring_LoadTransitConfirm_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<sp_DSRS010_ConfirmProductStoring_LoadSuggest_Result> LoadSuggestion(string ReceivingNo, int LineNo, int receiveSeq)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ReceivingNo", ReceivingNo);
            hs.Add("LineNo", LineNo);
            hs.Add("receiveSeq", receiveSeq);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ConfirmProductStoring/LoadSuggestion", hs);
                return JsonConvert.DeserializeObject<List<sp_DSRS010_ConfirmProductStoring_LoadSuggest_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public sp_DSRS010_ConfirmProductStoring_LoadStockByLocation_Result LoadDefaultTransitConfirm(int LocationID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("LocationID", LocationID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ConfirmProductStoring/LoadDefaultTransitConfirm", hs);
                return JsonConvert.DeserializeObject<sp_DSRS010_ConfirmProductStoring_LoadStockByLocation_Result>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetConfirmTransitStatusID()
        {
            return 7;
        }

        public void UploadFile(string ReceivingNo, List<string> fileList)
        {
            try
            {
                Hashtable hsUploadFile = new Hashtable();
                string fileName;
                foreach (string filePath in fileList)
                {
                    fileName = String.Format("{0}_{1}{2}", System.IO.Path.GetFileNameWithoutExtension(filePath), DateTime.Now.ToString("yyyyMMddHHmmss"), System.IO.Path.GetExtension(filePath));
                    hsUploadFile.Clear();
                    hsUploadFile.Add("FileName", fileName);
                    hsUploadFile.Add("ReceivingNo", ReceivingNo);

                    using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                    {
                        byte[] bytes = new byte[fileStream.Length];
                        fileStream.Read(bytes, 0, bytes.Length);

                        RubixWebAPI.UploadFile("ConfirmProductStoring/UploadFile", hsUploadFile, bytes);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Confirm(List<sp_DSRS010_ConfirmProductStoring_SearchAll_Result> list)
        {
            Hashtable hs = new Hashtable();
            hs.Add("UserLogin", AppConfig.UserLogin);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ConfirmProductStoring/Confirm", hs, JsonConvert.SerializeObject(list));
                return JsonConvert.DeserializeObject<int>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CheckWorkMethod(int? OwnerID, int? WarehouseID, out string messageId)
        {
            messageId = string.Empty;

            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ConfirmProductStoring/CheckWorkMethod", hs);
                int? result = JsonConvert.DeserializeObject<int?>(strResult);

                if (result == null || Convert.ToInt32(result.Value) == 0)
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

        public void Confirm(int OwnerID, string ReceivingNo, int Installment, int LineNo, int transitSeq, int WarehouseID, string PalletNo, int ProductID, int ProductConditionID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("ReceivingNo", ReceivingNo);
            hs.Add("Installment", Installment);
            hs.Add("LineNo", LineNo);
            hs.Add("transitSeq", transitSeq);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("PalletNo", PalletNo);
            hs.Add("ProductID", ProductID);
            hs.Add("ProductConditionID", ProductConditionID);
            hs.Add("UpdateUser", AppConfig.UserLogin);


            try
            {
                RubixWebAPI.ExecuteObjectResult("ConfirmProductStoring/Confirm", hs);
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
                RubixWebAPI.ExecuteObjectResult("ConfirmProductStoring/ClearData", JsonConvert.SerializeObject(list));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<sp_common_LoadByLocationType_Result> LoadAllLocation(int? OwnerID, int? WarehouseID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ConfirmProductStoring/LoadAllLocation", hs);
                return JsonConvert.DeserializeObject<List<sp_common_LoadByLocationType_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LoadAllFileName(string ReceivingNo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ReceivingNo", ReceivingNo);
            try
            {
                return RubixWebAPI.ExecuteDataTable("ConfirmProductStoring/LoadAllFileName", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public byte[] LoadCOAImage(int COA_ID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("COA_ID", COA_ID);
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ConfirmProductStoring/LoadCOAImage", hs);
                return JsonConvert.DeserializeObject<byte[]>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LoadLocationType()
        {
            try
            {
                return RubixWebAPI.ExecuteDataTable("Location/LoadLocationType");
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
                return RubixWebAPI.ExecuteDataTable("ConfirmProductStoring/ReprintReceivingLabelDataLoading", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
