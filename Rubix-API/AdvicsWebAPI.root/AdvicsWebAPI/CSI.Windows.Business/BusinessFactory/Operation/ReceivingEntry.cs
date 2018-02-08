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
using System.IO;

namespace CSI.Business.Operation
{
    public class ReceivingEntry : BaseReceiving
    {
        #region Member
        private BusinessCommon ims = null;
        private DataRow ta_Result; 
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

        public DataRow ResultData
        {
            get { return ta_Result; }
            set { ta_Result = value; }
        }
        public DataRow SelectData
        {
            set { ta_Result = value; }
        }
        public string ReceivingNo
        {
            get { return ResultData["ReceivingNo"].ToString(); }
            set { ResultData["ReceivingNo"] = value; }
        }
        public int OwnerID
        {
            get { return Convert.ToInt32(ResultData["OwnerID"]); }
            set { ResultData["OwnerID"] = value; }
        }
        public int WarehouseID
        {
            get { return Convert.ToInt32(ResultData["WarehouseID"]); }
            set { ResultData["WarehouseID"] = value; }
        }
        public int SupplierID
        {
            get { return Convert.ToInt32(ResultData["SupplierID"]); }
            set { ResultData["SupplierID"] = value; }
        }
        public DateTime ArrivalDate
        {
            get { return Convert.ToDateTime(ResultData["ArrivalDate"]); }
            set { ResultData["ArrivalDate"] = value; }
        }
        public string Remark
        {
            get { return ResultData["Remark"].ToString(); }
            set { ResultData["Remark"] = value; }
        }
        public bool CancelSlipFlag
        {
            get { return Convert.ToBoolean(ResultData["CancelSlipFlag"]); }
            set { ResultData["CancelSlipFlag"] = value; }
        }
        public int Installment
        {
            get { return Convert.ToInt32(ResultData["Installment"]); }
            set { ResultData["Installment"] = value; }
        }
        public int? PalletQty
        {
            get { return DataUtil.Convert<int>(ResultData["NumberOfPallet"]); }
            set { ResultData["NumberOfPallet"] = value; }
        }
        public DateTime? CreateDate
        {
            get { return DataUtil.Convert<DateTime>(ResultData["CreateDate"]); }
            set { ResultData["CreateDate"] = value; }
        }
        public string CreateUser
        {
            get { return ResultData["CreateUser"].ToString(); }
            set { ResultData["CreateUser"] = value; }
        }
        public DateTime? UpdateDate
        {
            get { return DataUtil.Convert<DateTime>(ResultData["UpdateDate"]); }
            set { ResultData["UpdateDate"] = value; }
        }
        public string UpdateUser
        {
            get { return ResultData["UpdateUser"].ToString(); }
            set { ResultData["UpdateUser"] = value; }
        }
        #endregion\
        
        public DataTable DataLoading(int? OwnerID, string ReceivingNo, int? ProductID, int? SupplierID, DateTime? ArrivalDateFrom, DateTime? ArrivalDateTo, int StatusFilter, int? WarehouseID, string InvoiceNo)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("OwnerID", OwnerID);
                hs.Add("ReceivingNo", ReceivingNo == string.Empty ? null : ReceivingNo);
                hs.Add("ProductID", ProductID);
                hs.Add("SupplierID", SupplierID);
                hs.Add("ArrivalDateFrom", ArrivalDateFrom);
                hs.Add("ArrivalDateTo", ArrivalDateTo);
                hs.Add("StatusFilter", StatusFilter);
                hs.Add("WarehouseID", WarehouseID);
                hs.Add("InvoiceNo", InvoiceNo);
                hs.Add("Installment", null);

                return Database.ExecuteDataSet("sp_BRES010_ReceivingEntry_SearchAll", hs).Tables[0];
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public DataTable GetReceivingInstructionHeader(string ReceivingNo, int Installment)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("OwnerID", null);
                hs.Add("ReceivingNo", ReceivingNo);
                hs.Add("ProductID", null);
                hs.Add("SupplierID", null);
                hs.Add("ArrivalDateFrom", null);
                hs.Add("ArrivalDateTo", null);
                hs.Add("StatusFilter", null);
                hs.Add("WarehouseID", null);
                hs.Add("InvoiceNo", null);
                hs.Add("Installment", Installment);

                return Database.ExecuteDataSet("sp_BRES010_ReceivingEntry_SearchAll", hs).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetReceivingInstructionDetail(string ReceivingNo, int Installment, int OwnerID, out string StatusName)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ReceivingNo", ReceivingNo);
                hs.Add("Installment", Installment);
                hs.Add("OwnerID", OwnerID);
                Hashtable hsOut = new Hashtable();
                hsOut.Add("Status",string.Empty);

                DataTable dt = Database.ExecuteDataSet("sp_BRES011_ReceivingEntry_Detail_Search", hs, ref hsOut).Tables[0];
                StatusName = hsOut["Status"].ToString();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetReceivingTransDetail(string ReceivingNo, int Installment)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ReceivingNo", ReceivingNo);
                hs.Add("Installment", Installment);

                return Database.ExecuteDataSet("sp_BRES011_ReceivingEntry_Trans_Detail_Search", hs).Tables[0];

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable GetReceivingOtherDetail(string ReceivingNo, int Installment)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ReceivingNo", ReceivingNo);
                hs.Add("Installment", Installment);

                return Database.ExecuteDataSet("sp_BRES011_ReceivingEntry_Other_Detail_Search", hs).Tables[0];

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable GetTransportCharge(int? OwnerID, int? WarehouseID, int TransportTypeID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("OwnerID", OwnerID);
                hs.Add("WarehouseID", WarehouseID);
                hs.Add("TransportTypeID", TransportTypeID);
                return Database.ExecuteDataSet("sp_BRES011_ReceivingEntry_TransportCharge_Search", hs).Tables[0];
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
        
        public DataTable LoadProductInfo(int ProductID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ProductID", ProductID);
                return Database.ExecuteDataSet("sp_BRES011_ReceivingEntry_LoadProductInfo", hs).Tables[0];
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public DataTable LoadUnit(int? ProductID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ProductID", ProductID);
                return Database.ExecuteDataSet("sp_BRES011_ReceivingEntry_LoadUnit", hs).Tables[0];
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public bool CanDelete(string ReceivingNo, int Installment, int OwnerID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                Hashtable hsOut = new Hashtable();
                hs.Add("OwnerID", OwnerID);
                hs.Add("ReceivingNo", ReceivingNo);
                hs.Add("Installment", Installment);
                hsOut.Add("CanDelete", "");
                Database.ExecuteNonQuery("sp_BRES011_ReceivingEntry_Header_CanDelete", hs, ref hsOut);

                return Convert.ToInt32(hsOut["CanDelete"]) == 1;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public bool CanDeleteDetail(string ReceivingNo, int Installment, int OwnerID, int LineNo)
        {
            try
            {
                Hashtable hs = new Hashtable();
                Hashtable hsOut = new Hashtable();
                hs.Add("OwnerID", OwnerID);
                hs.Add("ReceivingNo", ReceivingNo);
                hs.Add("Installment", Installment);
                hs.Add("LineNo", LineNo);
                hsOut.Add("CanDelete", "");
                Database.ExecuteNonQuery("sp_BRES011_ReceivingEntry_Detail_CanDelete", hs, ref hsOut);

                return Convert.ToInt32(hsOut["CanDelete"]) == 1;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public bool CanUpdateDetail(string ReceivingNo, int Installment, int OwnerID, int LineNo)
        {
            try
            {
                Hashtable hs = new Hashtable();
                Hashtable hsOut = new Hashtable();
                hs.Add("OwnerID", OwnerID);
                hs.Add("ReceivingNo", ReceivingNo);
                hs.Add("Installment", Installment);
                hs.Add("LineNo", LineNo);
                hsOut.Add("CanUpdate", "");
                Database.ExecuteNonQuery("sp_BRES011_ReceivingEntry_Detail_CanUpdate", hs, ref hsOut);

                return Convert.ToInt32(hsOut["CanUpdate"]) == 1;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public bool CanAddDetail(string ReceivingNo, int Installment, int OwnerID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                Hashtable hsOut = new Hashtable();
                hs.Add("OwnerID", OwnerID);
                hs.Add("ReceivingNo", ReceivingNo);
                hs.Add("Installment", Installment);
                hsOut.Add("CanAdd", "");
                Database.ExecuteNonQuery("sp_BRES011_ReceivingEntry_Detail_CanAdd", hs, ref hsOut);

                return Convert.ToInt32(hsOut["CanAdd"]) == 1;
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public bool CanUpdate(string ReceivingNo, int Installment, int OwnerID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                Hashtable hsOut = new Hashtable();
                hs.Add("OwnerID", OwnerID);
                hs.Add("ReceivingNo", ReceivingNo);
                hs.Add("Installment", Installment);
                hsOut.Add("CanUpdate", "");
                Database.ExecuteNonQuery("sp_BRES011_ReceivingEntry_Header_CanUpdate", hs, ref hsOut);

                return Convert.ToInt32(hsOut["CanUpdate"]) == 1;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public string SaveChanges(DataTable ReceivingInstructionHeader
                                  , string ReceivingInstructionDetail
                                  , string ReceivingTransportation
                                  , string ReceivingOtherCharge)
        {
            try
            {
                this.SelectData = ReceivingInstructionHeader.Rows[0];
                
                Hashtable hs = new Hashtable();
                hs.Add("OwnerID", this.OwnerID);
                hs.Add("ReceivingNo", string.IsNullOrEmpty(this.ReceivingNo) ? null : this.ReceivingNo);
                hs.Add("Installment", this.Installment);
                hs.Add("WarehouseID", this.WarehouseID);
                hs.Add("SupplierID", this.SupplierID);
                hs.Add("ArrivalDate", this.ArrivalDate);
                hs.Add("Remark", this.Remark);
                hs.Add("CancelSlipFlag", this.CancelSlipFlag);
                hs.Add("CreateUser", this.CreateUser);
                hs.Add("UpdateUser", this.UpdateUser);
                hs.Add("xmlDetail", ReceivingInstructionDetail);
                hs.Add("XMLTrasport", ReceivingTransportation);
                hs.Add("XMLOther", ReceivingOtherCharge);
                ReceivingNo = Database.ExecuteScalar("sp_BRES011_ReceivingEntry_Save", hs).ToString();

                return string.Format("{0}|{1}", ReceivingNo, 1);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void Delete(string ReceivingNo, int Installment)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ReceivingNo", ReceivingNo);
                hs.Add("Installment", Installment);
                Database.ExecuteNonQuery("sp_BRES011_ReceivingEntry_Delete", hs);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
                
        public DataTable GetUnitOfMeasure(int UnitID, int ProductID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("SelectUnitID", UnitID);
                hs.Add("ProductID", ProductID);
                return Database.ExecuteDataSet("sp_BRES011_ReceivingEntry_Detail_Unit_Search", hs).Tables[0];

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public bool CanShowQtyLevel1()
        {
            try
            {
                string canShow = Common.SystemConfig.GetShowQtyLevel1();
                return canShow == "1";
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        
        public int GetMaxLineNo(string receivingNo)
        {
            try
            {
                Hashtable hs = new Hashtable();
                Hashtable hsOut = new Hashtable();
                hs.Add("SlipNo", receivingNo);
                hsOut.Add("LineNo", "");
                Database.ExecuteNonQuery("sp_BRES010_ReceivingEntry_GetMaxLineNo", hs, ref hsOut);

                return Convert.ToInt32(hsOut["LineNo"]);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        
        public DataTable LoadCOAList(string ReceivingNo)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ReceivingNo", ReceivingNo);
                return Database.ExecuteDataSet("sp_BRES011_ReceivingEntry_COA_LOAD", hs).Tables[0];
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public void AddNewCOA(string ReceivingNo, string COA_FileName, byte[] byte_COA)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ReceivingNo", ReceivingNo);
                hs.Add("COA_FileName", COA_FileName);
                hs.Add("ImageFile", byte_COA);
                Database.ExecuteNonQuery("sp_BRES010_ReceivingEntry_COA_Save", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public byte[] LoadCOAImage(int COA_ID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("COA_ID", COA_ID);

               return  (byte[])Database.ExecuteDataSet("sp_BRES011_ReceivingEntry_COA_LOAD_IMAGE", hs).Tables[0].Rows[0]["ImageFile"];
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
                return Database.ReceivingEntity.sp_CRCS030_UnplanReceivingEntry_SearchAll(OwnerID, ReceivingNo, ProductID, ArrivalDateFrom, ArrivalDateTo, SupplierID, WarehouseID, InvoiceNo).ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable LoadPONo(int OwnerID, int WarehouseID, int SupplierID, string POIssueDateFrom, string POIssueDateTo)
        {

            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("OwnerID", OwnerID);
                hs.Add("WarehouseID", WarehouseID);
                hs.Add("SupplierID", SupplierID);
                hs.Add("POIssuedDateFrom", POIssueDateFrom);
                hs.Add("POIssuedDateTo", POIssueDateTo);


                return Database.ExecuteDataSet("sp_BRES011_ReceivingEntry_SearchPONo", hs).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataTable LoadDetailPDSNo(string PDSNo)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("PDSNo", PDSNo);


                return Database.ExecuteDataSet("sp_BRES011_ReceivingEntry_SearchDetailByPDSNo", hs).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
