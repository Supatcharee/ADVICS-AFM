/*
 * 17 Jan 2013:
 * 1. add method for check whether can show qty level1
 * 28 Jan 2013:
 * 1. modify DeleteTransport and DeleteOther function to validate receiving no before delete
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using CSI.Business;
using System.Data;
using System.Collections;
using CSI.Business.BusinessFactory.Operation.Base;
using System.Transactions;
using Rubix.Framework;
using Newtonsoft.Json;
using System.IO;

namespace CSI.Business.Operation
{
    public class ReceivingEntry : BaseReceiving
    {
        #region Member
        private DataTable ta_Result = null;   
        
        struct GetReceivingInstructionDetailStruct
        {
            public DataTable Detail;
            public string StatusName;
        }

        struct SaveChangesStruct
        {
            public DataTable ReceivingInstructionHeader;
            public string XMLReceivingInstructionDetail;
            public string XMLReceivingTransportation;
            public string XMLReceivingOtherCharge;
        }
        #endregion

        #region Properties
        public DataTable ResultData
        {
            get
            {
                if (ta_Result == null || ta_Result.Rows.Count <= 0)
                {
                    ta_Result = new DataTable();
                    ta_Result.Columns.Clear();
                    ta_Result.Columns.Add("ReceivingNo", typeof(string));
                    ta_Result.Columns.Add("OwnerID", typeof(int));
                    ta_Result.Columns.Add("WarehouseID", typeof(int));
                    ta_Result.Columns.Add("SupplierID", typeof(int));
                    ta_Result.Columns.Add("ArrivalDate", typeof(DateTime));
                    ta_Result.Columns.Add("Remark", typeof(string));
                    ta_Result.Columns.Add("CancelSlipFlag", typeof(bool));
                    ta_Result.Columns.Add("Installment", typeof(int));
                    ta_Result.Columns.Add("PalletQty", typeof(int));
                    ta_Result.Columns.Add("CreateDate", typeof(DateTime));
                    ta_Result.Columns.Add("CreateUser", typeof(string));
                    ta_Result.Columns.Add("UpdateDate", typeof(DateTime));
                    ta_Result.Columns.Add("UpdateUser", typeof(string));
                    DataRow dr = ta_Result.NewRow();
                    ta_Result.Rows.Add(dr);
                }
                return ta_Result;}
            set 
            {
                ta_Result = value;
            }
        }
        public DataRow SelectData
        {
            get { return ResultData.Rows[0]; }
        }        
        public string ReceivingNo
        {
            get { return SelectData["ReceivingNo"].ToString(); }
            set { SelectData["ReceivingNo"] = value; }
        }
        public int OwnerID
        {
            get { return Convert.ToInt32(SelectData["OwnerID"]); }
            set { SelectData["OwnerID"] = value; }
        }
        public int WarehouseID
        {
            get { return Convert.ToInt32(SelectData["WarehouseID"]); }
            set { SelectData["WarehouseID"] = value; }
        }
        public int SupplierID
        {
            get { return Convert.ToInt32(SelectData["SupplierID"]); }
            set { SelectData["SupplierID"] = value; }
        }
        public DateTime ArrivalDate
        {
            get { return Convert.ToDateTime(SelectData["ArrivalDate"]); }
            set { SelectData["ArrivalDate"] = value; }
        }
        public string Remark
        {
            get { return SelectData["Remark"].ToString(); }
            set { SelectData["Remark"] = value; }
        }
        public bool CancelSlipFlag
        {
            get { return Convert.ToBoolean(SelectData["CancelSlipFlag"]); }
            set { SelectData["CancelSlipFlag"] = value; }
        }
        public int Installment
        {
            get { return Convert.ToInt32(SelectData["Installment"]); }
            set { SelectData["Installment"] = value; }
        }
        public int? PalletQty
        {
            get { return DataUtil.Convert<int>(SelectData["PalletQty"]); }
            set { SelectData["PalletQty"] = value; }
        }
        public DateTime? CreateDate
        {
            get { return DataUtil.Convert<DateTime>(SelectData["CreateDate"]); }
            set { SelectData["CreateDate"] = value; }
        }
        public string CreateUser
        {
            get { return SelectData["CreateUser"].ToString(); }
            set { SelectData["CreateUser"] = value; }
        }
        public DateTime? UpdateDate
        {
            get { return DataUtil.Convert<DateTime>(SelectData["UpdateDate"]); }
            set { SelectData["UpdateDate"] = value; }
        }
        public string UpdateUser
        {
            get { return SelectData["UpdateUser"].ToString(); }
            set { SelectData["UpdateUser"] = value; }
        }
        #endregion

        public DataTable DataLoading(int? OwnerID, string ReceivingNo, int? ProductID, int? SupplierID, DateTime? From, DateTime? To, int StatusFilter, int? WarehouseID, string InvoiceNo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("ReceivingNo", ReceivingNo);
            hs.Add("ProductID", ProductID);
            hs.Add("SupplierID", SupplierID);
            hs.Add("From", From);
            hs.Add("To", To);
            hs.Add("StatusFilter", StatusFilter);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("InvoiceNo", InvoiceNo);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ReceivingEntry/DataLoading", hs);
                return JsonConvert.DeserializeObject<DataTable>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetReceivingInstructionHeader(string ReceivingNo, int Installment)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ReceivingNo", ReceivingNo);
            hs.Add("Installment", Installment);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ReceivingEntry/GetReceivingInstructionHeader", hs);
                return JsonConvert.DeserializeObject<DataTable>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
                
        public DataTable GetReceivingInstructionDetail(string ReceivingNo, int Installment, int OwnerID, out string StatusName)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ReceivingNo", ReceivingNo);
            hs.Add("Installment", Installment);
            hs.Add("OwnerID", OwnerID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ReceivingEntry/GetReceivingInstructionDetail", hs);
                GetReceivingInstructionDetailStruct stc = JsonConvert.DeserializeObject<GetReceivingInstructionDetailStruct>(strResult);
                StatusName = stc.StatusName;
                return stc.Detail;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetReceivingTransDetail(string ReceivingNo, int Installment)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ReceivingNo", ReceivingNo);
            hs.Add("Installment", Installment);
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ReceivingEntry/GetReceivingTransDetail", hs);
                return JsonConvert.DeserializeObject<DataTable>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetReceivingOtherDetail(string ReceivingNo, int Installment)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ReceivingNo", ReceivingNo);
            hs.Add("Installment", Installment);
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ReceivingEntry/GetReceivingOtherDetail", hs);
                return JsonConvert.DeserializeObject<DataTable>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetTransportCharge(int? OwnerID, int? WarehouseID, int TransportTypeID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("TransportTypeID", TransportTypeID);
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ReceivingEntry/GetTransportCharge", hs);
                return JsonConvert.DeserializeObject<DataTable>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public DataTable LoadProductInfo(int ProductID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ProductID", ProductID);
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ReceivingEntry/LoadProductInfo", hs);
                return JsonConvert.DeserializeObject<DataTable>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LoadUnit(int? ProductID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ProductID", ProductID);
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ReceivingEntry/LoadUnit", hs);
                return JsonConvert.DeserializeObject<DataTable>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CanDelete(string ReceivingNo, int Installment, int OwnerID)
        {
            Hashtable hs = new Hashtable();            
            hs.Add("ReceivingNo", ReceivingNo);
            hs.Add("Installment", Installment);
            hs.Add("OwnerID", OwnerID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ReceivingEntry/CanDelete", hs);
                return JsonConvert.DeserializeObject<bool>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CanDeleteDetail(string ReceivingNo, int Installment, int OwnerID, int LineNo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ReceivingNo", ReceivingNo);
            hs.Add("Installment", Installment);
            hs.Add("OwnerID", OwnerID);
            hs.Add("LineNo", LineNo);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ReceivingEntry/CanDeleteDetail", hs);
                return JsonConvert.DeserializeObject<bool>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CanUpdateDetail(string ReceivingNo, int Installment, int OwnerID, int LineNo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ReceivingNo", ReceivingNo);
            hs.Add("Installment", Installment);
            hs.Add("OwnerID", OwnerID);
            hs.Add("LineNo", LineNo);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ReceivingEntry/CanUpdateDetail", hs);
                return JsonConvert.DeserializeObject<bool>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CanAddDetail(string ReceivingNo, int Installment, int OwnerID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ReceivingNo", ReceivingNo);
            hs.Add("Installment", Installment);
            hs.Add("OwnerID", OwnerID);
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ReceivingEntry/CanAddDetail", hs);
                return JsonConvert.DeserializeObject<bool>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CanUpdate(string ReceivingNo, int Installment, int OwnerID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ReceivingNo", ReceivingNo);
            hs.Add("Installment", Installment);
            hs.Add("OwnerID", OwnerID);
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ReceivingEntry/CanUpdate", hs);
                return JsonConvert.DeserializeObject<bool>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool SaveChanges(DataTable InstructionDetail, 
                                DataTable TransCharge,
                                DataTable OtherCharge, 
                                List<string> fileList)
        {

            SaveChangesStruct stc = new SaveChangesStruct();

            DataSet dsInstructionDetail = new DataSet("DataSet");
            DataSet dsTransCharge = new DataSet("DataSet");
            DataSet dsOtherCharge = new DataSet("DataSet");

            InstructionDetail.TableName = "DataTable";
            TransCharge.TableName = "DataTable";
            OtherCharge.TableName = "DataTable";

            dsInstructionDetail.Tables.Add(InstructionDetail);
            dsTransCharge.Tables.Add(TransCharge);
            dsOtherCharge.Tables.Add(OtherCharge);

            stc.ReceivingInstructionHeader = ResultData;
            stc.XMLReceivingInstructionDetail = dsInstructionDetail.GetXml();
            stc.XMLReceivingTransportation = dsTransCharge.GetXml();
            stc.XMLReceivingOtherCharge = dsOtherCharge.GetXml();

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ReceivingEntry/SaveChanges", JsonConvert.SerializeObject(stc));
                string[] arrResult = JsonConvert.DeserializeObject<string>(strResult).Split('|');
                //0 ==> Receiving No
                //1 ==> Result Return

                this.ReceivingNo = arrResult[0];

                Hashtable hsUploadFile = new Hashtable();
                string fileName;
                foreach (string filePath in fileList)
                {
                    fileName = String.Format("{0}_{1}{2}", System.IO.Path.GetFileNameWithoutExtension(filePath), DateTime.Now.ToString("yyyyMMddHHmmss"), System.IO.Path.GetExtension(filePath));
                    hsUploadFile.Clear();
                    hsUploadFile.Add("FileName", fileName);
                    hsUploadFile.Add("ReceivingNo", arrResult[0]);

                    using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                    {
                        byte[] bytes = new byte[fileStream.Length];
                        fileStream.Read(bytes, 0, bytes.Length);

                        RubixWebAPI.UploadFile("ReceivingEntry/UploadReceivingFile", hsUploadFile, bytes);
                    }
                }

                return Convert.ToInt32(arrResult[1]) >= 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dsInstructionDetail.Tables.Clear();
                dsTransCharge.Tables.Clear();
                dsOtherCharge.Tables.Clear();

                dsInstructionDetail = null;
                dsTransCharge = null;
                dsOtherCharge = null;
            }
        }

        public bool Delete(string ReceivingNo, int Installment)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ReceivingNo", ReceivingNo);
            hs.Add("Installment", Installment);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ReceivingEntry/Delete", hs);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GenReceivingNo(int OwnerID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ReceivingEntry/GenReceivingNo", hs);
                return JsonConvert.DeserializeObject<string>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetUnitOfMeasure(int UnitID, int ProductID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("UnitID", UnitID);
            hs.Add("ProductID", ProductID);
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ReceivingEntry/GetUnitOfMeasure", hs);
                return JsonConvert.DeserializeObject<DataTable>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CanShowQtyLevel1()
        {
            string canShow = Common.SystemConfig.GetShowQtyLevel1();
            return canShow == "1";
        }
        
        public int GetMaxLineNo(string ReceivingNo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ReceivingNo", ReceivingNo);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ReceivingEntry/GetMaxLineNo", hs);
                return JsonConvert.DeserializeObject<int>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public List<sp_CRCS030_UnplanReceivingEntry_SearchAll_Result> UnplanReceivingEntryDataLoading(int? OwnerID, string ReceivingNo, int? ProductID, DateTime? ArrivalDateFrom, DateTime? ArrivalDateTo, int? SupplierID, int? WarehouseID, string InvoiceNo)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("OwnerID", OwnerID);
                hs.Add("ReceivingNo", ReceivingNo);
                hs.Add("ProductID", ProductID);
                hs.Add("ArrivalDateFrom", ArrivalDateFrom);
                hs.Add("ArrivalDateTo", ArrivalDateTo);
                hs.Add("SupplierID", SupplierID);
                hs.Add("WarehouseID", WarehouseID);
                hs.Add("InvoiceNo", InvoiceNo);

                string strResult = RubixWebAPI.ExecuteObjectResult("ReceivingEntry/UnplanReceivingEntryDataLoading", hs);
                return JsonConvert.DeserializeObject<List<sp_CRCS030_UnplanReceivingEntry_SearchAll_Result>>(strResult);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable LoadPONo(int OwnerID, int WarehouseID, int SupplierID, string POIssueDateFrom, string POIssueDateTo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("SupplierID", SupplierID);
            hs.Add("POIssueDateFrom", POIssueDateFrom);
            hs.Add("POIssueDateTo", POIssueDateTo);


            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ReceivingEntry/LoadPONo", hs);
                return JsonConvert.DeserializeObject<DataTable>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable LoadDetailPDSNo(string PDSNo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("PDSNo", PDSNo);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ReceivingEntry/LoadDetailPDSNo", hs);
                return JsonConvert.DeserializeObject<DataTable>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
