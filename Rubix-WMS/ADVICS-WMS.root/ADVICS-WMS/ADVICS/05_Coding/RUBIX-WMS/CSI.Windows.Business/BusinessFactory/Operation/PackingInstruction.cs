using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using System.Transactions;
using Rubix.Framework;
using System.Collections;
using Newtonsoft.Json;
using System.Data;

namespace CSI.Business.Operation
{
    public class PackingInstruction
    {
        struct PackingArragementstr
        {
            public int? OwnerID;
            public int? CustomerID;
            public int? WarehouseID;
            public string ShipmentNo;
            public string PackingNo;
            public string ShipmentNoTo;
            public string PackingNoTo;
            public string CustomerPO;
            public string PalletNo;
            public string PackingDateFrom;
            public string PackingDateTo;
            public DateTime? ShippingDate;
            public DateTime? PackingDate;
            public DateTime? PickingDate;
            public bool isCompletedPacking;
            public bool isActual;
            public string DetailXML;
            public int MoveAll;
            public string CurrentUser;
            public int? StatusID;
        }

        struct ConfirmPacking
        {
            public int? OwnerID;
            public int? CustomerID;
            public int? WarehouseID;
            public string ShipmentNo;
            public string PackingNo;
            public string CustomerPONo;
            public DateTime? PackingDateFrom;
            public DateTime? PackingDateTo;
            public bool Status;
        }

        struct PackingConfirmData
        {
            public string PackingNo;
            public decimal? TotalWeight;
            public decimal? TotalGrossWeight;
            public decimal? TotalM3;
            public string RemarkHeader;
            public string RMTagXML;
            public string CurrentUser;
            public string UserLogon;
            public string MachineIP;
        }

        //KPK010
        public DataTable PackingArragementSearchAll(int? OwnerID, int? CustomerID, int? WarehouseID, string ShipmentNo, string PackingNo,
                                                    string CustomerPO, string PalletNo, string PackingDateFrom, string PackingDateTo, bool isActual, int? StatusID)
        {
            PackingArragementstr stc = new PackingArragementstr();
            stc.OwnerID = OwnerID;
            stc.CustomerID = CustomerID;
            stc.WarehouseID = WarehouseID;
            stc.ShipmentNo = ShipmentNo;
            stc.PackingNo = PackingNo;
            stc.CustomerPO = CustomerPO;
            stc.PalletNo = PalletNo;
            stc.PackingDateFrom = PackingDateFrom;
            stc.PackingDateTo = PackingDateTo;
            stc.isActual = isActual;
            stc.StatusID = StatusID;

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("PackingInstruction/PackingArragementSearchAll", JsonConvert.SerializeObject(stc));
                return JsonConvert.DeserializeObject<DataTable>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //KPK010
        public DataSet PackingArragementRollBack(string PickingNo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("PickingNo", PickingNo);
            hs.Add("CreateUser", AppConfig.UserLogin);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("PackingInstruction/PackingArragementRollBack", hs);
                return JsonConvert.DeserializeObject<DataSet>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //KPK010
        public DataSet PackingArragementValidate_PickPallet(string PalletNo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("PalletNo", PalletNo);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("PackingInstruction/PackingArragementValidate_PickPallet", hs);
                return JsonConvert.DeserializeObject<DataSet>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //KPK010
        public void CaseMarkPickAndPack(string PalletNo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("PalletNo", PalletNo);
            hs.Add("UserName", AppConfig.UserLogin);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("PackingInstruction/CaseMarkPickAndPack", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //KPK011
        public DataSet PackingArragementSearchDetail(string ShipmentNo, string PackingNo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ShipmentNo", ShipmentNo);
            hs.Add("PackingNo", PackingNo);
            
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("PackingInstruction/PackingArragementSearchDetail", hs);
                return JsonConvert.DeserializeObject<DataSet>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //KPK011
        public void PackingArragementSaveDetail(string PackingNo, string RemarkHeader,
            decimal? TotalWeight, decimal? TotalGrossWeight, decimal? TotalM3, DataTable dtDetail)
        {
            PackingConfirmData stc = new PackingConfirmData();
            DataSet ds = new DataSet("PackingDataSet");
            ds.Tables.Add(dtDetail);
            dtDetail.TableName = "PackingDataTable";
            stc.PackingNo = PackingNo;
            stc.TotalWeight = TotalWeight;
            stc.TotalGrossWeight = TotalGrossWeight;
            stc.TotalM3 = TotalM3;
            stc.CurrentUser = AppConfig.UserLogin;
            stc.RMTagXML = ds.GetXml();
            stc.RemarkHeader = RemarkHeader;

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("PackingInstruction/PackingArragementSaveDetail", JsonConvert.SerializeObject(stc));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ds.Tables.Clear();
                ds.Clear();
                ds = null;
            }
        }
        //KPK012
        public DataTable PackingManagementSearchAll(int? OwnerID, int? CustomerID, int? WarehouseID, DateTime? ShippingDate, DateTime? PackingDate, string ShipmentNo, string PackingNo, int MoveAll, string ShipmentNoTo, string PackingNoTo)
        {
            PackingArragementstr stc = new PackingArragementstr();
            stc.OwnerID = OwnerID;
            stc.CustomerID = CustomerID;
            stc.WarehouseID = WarehouseID;
            stc.ShippingDate = ShippingDate;
            stc.PackingDate = PackingDate;
            stc.ShipmentNo = ShipmentNo;
            stc.PackingNo = PackingNo;
            stc.MoveAll = MoveAll;
            stc.ShipmentNoTo = ShipmentNoTo;
            stc.PackingNoTo = PackingNoTo;

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("PackingInstruction/PackingManagementSearchAll", JsonConvert.SerializeObject(stc));
                return JsonConvert.DeserializeObject<DataTable>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //KPK012
        public int PackingManagementGetShipmentStatus(string ShipmentNo, string PackingNo)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ShipmentNo", ShipmentNo);
                hs.Add("PackingNo", PackingNo);

                string strResult = RubixWebAPI.ExecuteObjectResult("PackingInstruction/PackingManagementGetShipmentStatus", hs);
                return JsonConvert.DeserializeObject<int>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //KPK012
        public void PackingManagementSave(int? OwnerID, int? WarehouseID, int? CustomerID, DateTime? ShippingDate, DateTime? PackingDate, DateTime? PickingDate, string ShipmentNo, string PackingNo, DataTable dtDetail)
        {
            try
            {
                DataSet ds = new DataSet("PackingDataSet");
                dtDetail.TableName = "PackingDataTable";
                ds.Tables.Add(dtDetail);

                PackingArragementstr stc = new PackingArragementstr();
                stc.OwnerID = OwnerID;
                stc.CustomerID = CustomerID;
                stc.WarehouseID = WarehouseID;
                stc.ShippingDate = ShippingDate;
                stc.PackingDate = PackingDate;
                stc.PickingDate = PickingDate;
                stc.ShipmentNo = ShipmentNo;
                stc.PackingNo = PackingNo;
                stc.CurrentUser = AppConfig.UserLogin;
                stc.DetailXML = ds.GetXml();

                string strResult = RubixWebAPI.ExecuteObjectResult("PackingInstruction/PackingManagementSave", JsonConvert.SerializeObject(stc));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //For PKP012
        public List<int?> GetSpecificStatusIdForPackingManagement(string Status)
        {
            List<int?> ListStatus = new List<int?>();

            if (Status == "Start")
            {
                ListStatus.AddRange(new int?[] { Common.Status.NewShippingEntry });
                ListStatus.AddRange(new int?[] { Common.Status.CompletePicking });
                ListStatus.AddRange(new int?[] { Common.Status.PackingInnstructionIssued });
            }
            else if (Status == "AllPack")
            {
                ListStatus.AddRange(new int?[] { Common.Status.CompletePacking });
            }
            else if (Status == "65")
            {
                ListStatus.AddRange(new int?[] { Common.Status.NewShippingEntry });
            }
            else if (Status == "85")
            {
                ListStatus.AddRange(new int?[] { Common.Status.CompletePicking });
                ListStatus.AddRange(new int?[] { Common.Status.PackingInnstructionIssued });
            }
            else if (Status == "100")
            {
                ListStatus.AddRange(new int?[] { Common.Status.PackingInnstructionIssued });
            }
            else
            {
                ListStatus.AddRange(new int?[] { -1 });
            }

            return ListStatus;
        }

        //For KPK020m --Unconfirm
        public List<int?> GetSpecificStatusIdForPackingUnconfirmed()
        {
            List<int?> ListStatus = new List<int?>();
            ListStatus.AddRange(new int?[] { Common.Status.CompletePicking });
            ListStatus.AddRange(new int?[] { Common.Status.PackingInnstructionIssued });
            ListStatus.AddRange(new int?[] { Common.Status.InCompletePacking });
            return ListStatus;
        }
        //For KPK020m --Confirmed
        public List<int?> GetSpecificStatusIdForPackingConfirmed()
        {
            List<int?> ListStatus = new List<int?>();
            ListStatus.AddRange(new int?[] { Common.Status.CompletePacking });
            return ListStatus;
        }
        //KPK020
        public DataTable ConfirmPackingSearchAll(int? OwnerID, int? CustomerID, int? WarehouseID, string ShipmentNo, string PackingNo,
                                                string CustomerPONo, DateTime? PackingDateFrom, DateTime? PackingDateTo, bool Status)
        {
            ConfirmPacking stc = new ConfirmPacking();
            stc.OwnerID = OwnerID;
            stc.CustomerID = CustomerID;
            stc.WarehouseID = WarehouseID;
            stc.ShipmentNo = ShipmentNo;
            stc.PackingNo = PackingNo;
            stc.CustomerPONo = CustomerPONo;
            stc.PackingDateFrom = PackingDateFrom;
            stc.PackingDateTo = PackingDateTo;
            stc.Status = Status;

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("PackingInstruction/ConfirmPackingSearchAll", JsonConvert.SerializeObject(stc));
                return JsonConvert.DeserializeObject<DataTable>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ConfirmPackingForScannerSearchAll(int? OwnerID, int? CustomerID, int? WarehouseID, string ShipmentNo, string PackingNo,
                                                string CustomerPONo, DateTime? PackingDateFrom, DateTime? PackingDateTo, bool Status)
        {
            ConfirmPacking stc = new ConfirmPacking();
            stc.OwnerID = OwnerID;
            stc.CustomerID = CustomerID;
            stc.WarehouseID = WarehouseID;
            stc.ShipmentNo = ShipmentNo;
            stc.PackingNo = PackingNo;
            stc.CustomerPONo = CustomerPONo;
            stc.PackingDateFrom = PackingDateFrom;
            stc.PackingDateTo = PackingDateTo;
            stc.Status = Status;

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("PackingInstruction/ConfirmPackingForScannerSearchAll", JsonConvert.SerializeObject(stc));
                return JsonConvert.DeserializeObject<DataTable>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //KPK020
        public void ConfirmPackingConfirmData(string PackingNo, string RMTagXML)
        {
            //-------------------------------------------------------------------------
            ControlUtil.LMethod = "ConfirmPackingConfirmData(string PackingNo, string RMTagXML)";
            ControlUtil.LStart = "START";
            ControlUtil.LStartCurrentDateDate = DateTime.Now.ToString("dd/MM/yy HH:mm:ss tt");

            //----------------------------------------------------------------------------
            PackingConfirmData confirmData = new PackingConfirmData();
            confirmData.PackingNo = PackingNo;
            confirmData.RMTagXML = RMTagXML;
            confirmData.CurrentUser = AppConfig.UserLogin;
            //confirmData.UserLogon = UserLogon;
            //confirmData.MachineIP = MachineIP;

            try
            {
                //---------------------------------------------------------
                ControlUtil.LParameter = "string PackingNo = "+PackingNo;
                ControlUtil.LogFileStart(ControlUtil.LMethod, ControlUtil.LStart, ControlUtil.LStartCurrentDateDate, ControlUtil.LParameter);
                //---------------------------------------------------------
                RubixWebAPI.ExecuteObjectResult("PackingInstruction/ConfirmPackingConfirmData", JsonConvert.SerializeObject(confirmData));
                //---------------------------------------------------------
                ControlUtil.LEnd = "END";
                ControlUtil.LEndCurrentDate = DateTime.Now.ToString("dd/MM/yy HH:mm:ss tt");
                ControlUtil.LogFileEnd(ControlUtil.LMethod, ControlUtil.LEnd, ControlUtil.LEndCurrentDate);
                //---------------------------------------------------------
                //return JsonConvert.DeserializeObject<DataSet>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        //KPK021
        public DataTable ConfirmPackingSearchRMTagDetail(string PDSNo, string RunningNo, string ProductCode, string ShipmentNo, string PackingNo)
        {
            //-------------------------------------------------------------------------
            ControlUtil.LMethod = "ConfirmPackingSearchRMTagDetail(string PDSNo, string RunningNo, string ProductCode, string ShipmentNo, string PackingNo)";
            ControlUtil.LStart = "START";
            ControlUtil.LStartCurrentDateDate = DateTime.Now.ToString("dd/MM/yy HH:mm:ss tt");

            //----------------------------------------------------------------------------
            Hashtable hs = new Hashtable();
            hs.Add("PDSNo", PDSNo);
            hs.Add("RunningNo", RunningNo);
            hs.Add("ProductCode", ProductCode);
            hs.Add("ShipmentNo", ShipmentNo);
            hs.Add("PackingNo", PackingNo);


            try
            {
                //---------------------------------------------------------
                ControlUtil.LParameter = String.Format("string PDSNo = {0}; string RunningNo = {1}; string ProductCode = {2}; string ShipmentNo = {3}; string PackingNo = {4}", PDSNo, RunningNo, ProductCode, ShipmentNo, PackingNo);
                ControlUtil.LogFileStart(ControlUtil.LMethod, ControlUtil.LStart, ControlUtil.LStartCurrentDateDate, ControlUtil.LParameter);
                //---------------------------------------------------------
                string strResult = RubixWebAPI.ExecuteObjectResult("PackingInstruction/ConfirmPackingSearchRMTagDetail", hs);
                //---------------------------------------------------------
                ControlUtil.LEnd = "END";
                ControlUtil.LEndCurrentDate = DateTime.Now.ToString("dd/MM/yy HH:mm:ss tt");
                ControlUtil.LogFileEnd(ControlUtil.LMethod, ControlUtil.LEnd, ControlUtil.LEndCurrentDate);
                //---------------------------------------------------------
                return JsonConvert.DeserializeObject<DataTable>(strResult);
            }
            catch (Exception ex)
            {
                //-------------------------------------------------------------------------------------------------------
                ControlUtil.LMethod = "Exception --> dlgKPK021_ConfirmPacking_ScanDetail/txtQRCode_KeyPress(object sender, KeyPressEventArgs e)";
                ControlUtil.LStart = "Start Exception";
                ControlUtil.LStartCurrentDateDate = DateTime.Now.ToString("dd/MM/yy HH:mm:ss tt");
                ControlUtil.LParameter = String.Format("Exception Message is {0}; StackTrace is {1}", ex.Message, ex.StackTrace);
                ControlUtil.LogFileStart(ControlUtil.LMethod, ControlUtil.LStart, ControlUtil.LStartCurrentDateDate, ControlUtil.LParameter);
                ControlUtil.LEnd = "End Exception";
                ControlUtil.LEndCurrentDate = DateTime.Now.ToString("dd/MM/yy HH:mm:ss tt");
                ControlUtil.LogFileEnd(ControlUtil.LMethod, ControlUtil.LEnd, ControlUtil.LEndCurrentDate);
                //-----------------------------------------------------------------------------------------------------
                
                throw ex;
            }
        }

        //KPK022
        public DataTable PackingAppearanceSearchPackingProduct(string PackingNo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("PackingNo", PackingNo);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("PackingInstruction/PackingAppearanceSearchPackingProduct", hs);
                return JsonConvert.DeserializeObject<DataTable>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
