/*
 * 23 Jan 2013:
 * 1. add new function "GetSpecificStatusId"
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using System.Transactions;
using Rubix.Framework;
using System.Collections;
using System.Data;

namespace CSI.Business.Operation
{
    public class PackingInstruction
    {
        #region Member

        #endregion

        #region Properties

        #endregion

        //KPK010
        public DataTable PackingArragementSearchAll(int? OwnerID, int? CustomerID, int? WarehouseID, string ShipmentNo, string PackingNo, string CustomerPO, string PalletNo, string PackingDateFrom, string PackingDateTo, bool isActual, int? StatusID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("OwnerID", OwnerID);
                hs.Add("CustomerID", CustomerID);
                hs.Add("WarehouseID", WarehouseID);
                hs.Add("ShipmentNo", ShipmentNo == string.Empty ? null : ShipmentNo);
                hs.Add("PackingNo", PackingNo == string.Empty ? null : PackingNo);
                hs.Add("CustomerPO", CustomerPO == string.Empty ? null : CustomerPO);
                hs.Add("PalletNo", PalletNo == string.Empty ? null : PalletNo);
                hs.Add("PackingDateFrom", PackingDateFrom);
                hs.Add("PackingDateTo", PackingDateTo);
                hs.Add("isActual", isActual);
                hs.Add("Status", StatusID);

                return Database.ExecuteDataSet("sp_KPK010_PackingArragement_SearchAll", hs).Tables[0];
            }
            catch (Exception ex)
            {                
                throw ex;
            }	
        }
        //KPK010
        public DataSet PackingArragementRollBack(string PickingNo, string CreateUser)
        {

            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("PickingNo", PickingNo);
                hs.Add("CreateUser", CreateUser);

                return Database.ExecuteDataSet("sp_KPK010_PackingArragement_Rollback_Transaction", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        //KPK010
        public DataSet PackingArragementValidate_PickPallet(string PalletNo)
        {

            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("PalletNo", PalletNo);

                return Database.ExecuteDataSet("sp_KPK010_PackingArragement_Validate_PickPallet", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        //KPK010
        public void CaseMarkPickAndPack(string PalletNo, string UserName)
        {

            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("PalletNo", PalletNo);
                hs.Add("LocationCode", "");
                hs.Add("Flag", 1);
                hs.Add("UserName", UserName);

                Database.ExecuteNonQuery("sp_ZHTP010_CaseMarkPickAndPack", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        //KPK011
        public DataSet PackingArragementSearchDetail(string ShipmentNo, string PackingNo)
        {

            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ShipmentNo", ShipmentNo);
                hs.Add("PackingNo", PackingNo);

                return Database.ExecuteDataSet("sp_KPK011_PackingArragement_SearchDetail", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        //KPK011
        public DataSet PackingArragementSaveDetail(string PackingNo, string RemarkHeader, string DetailXML,
            string CurrentUser, decimal? TotalWeight, decimal? TotalGrossWeight, decimal? TotalM3)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("PackingNo", PackingNo);
                hs.Add("TotalWeight", TotalWeight);
                hs.Add("TotalGrossWeight", TotalGrossWeight);
                hs.Add("TotalM3", TotalM3);
                hs.Add("RemarkHeader", RemarkHeader);
                //hs.Add("DetailXML", DetailXML);
                hs.Add("CurrentUser", CurrentUser);

                return Database.ExecuteDataSet("sp_KPK011_PackingArragement_SaveDetail", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //KPK012
        public DataTable PackingManagementSearchAll(int? OwnerID, int? CustomerID, int? WarehouseID, DateTime? ShippingDate, DateTime? PackingDate, string ShipmentNo, string PackingNo, int MoveAllStatus, string ShipmentNoTo, string PackingNoTo)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("OwnerID", OwnerID);
                hs.Add("CustomerID", CustomerID);
                hs.Add("WarehouseID", WarehouseID);
                hs.Add("ShippingDate", ShippingDate);
                hs.Add("PackingDate", PackingDate);
                hs.Add("ShipmentNo", ShipmentNo == string.Empty ? null : ShipmentNo);
                hs.Add("PackingNo", PackingNo == string.Empty ? null : PackingNo);
                hs.Add("MoveAllStatus", MoveAllStatus);
                hs.Add("ShipmentNoTo", ShipmentNoTo == string.Empty ? null : ShipmentNoTo);
                hs.Add("PackingNoTo", PackingNoTo == string.Empty ? null : PackingNoTo);
                return Database.ExecuteDataSet("sp_KPK012_PackingManagement_SearchAll", hs).Tables[0];
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
                hs.Add("ShipmentNo", ShipmentNo == string.Empty ? null : ShipmentNo);
                hs.Add("PackingNo", PackingNo == string.Empty ? null : PackingNo);

                return Convert.ToInt32(Database.ExecuteScalar("sp_KPK012_PackingManagement_GetShipmentStatus", hs));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //KPK012
        public void PackingManagementSave(int? OwnerID, int? WarehouseID, int? CustomerID, DateTime? ShippingDate, DateTime? PackingDate, DateTime? PickingDate, string ShipmentNo, string PackingNo, string CurrentUser, string DetailXML)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("OwnerID", OwnerID);
                hs.Add("WarehouseID", WarehouseID);
                hs.Add("CustomerID", CustomerID);
                hs.Add("ShippingDate", ShippingDate);
                hs.Add("PackingDate", PackingDate);
                hs.Add("PickingDate", PickingDate);
                hs.Add("ShipmentNo", ShipmentNo);
                hs.Add("PackingNo", PackingNo == string.Empty ? null : PackingNo);
                hs.Add("CurrentUser", CurrentUser);
                hs.Add("DetailXML", DetailXML);
                Database.ExecuteNonQuery("sp_KPK012_PackingManagement_Save", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //KPK020
        public static DataTable ConfirmPackingSearchAll(int? OwnerID,  int? CustomerID, int? WarehouseID, string ShipmentNo, string PackingNo, 
                                                    string CustomerPONo, DateTime? PackingDateFrom, DateTime? PackingDateTo, bool Status)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("OwnerID", OwnerID);
                hs.Add("CustomerID", CustomerID);
                hs.Add("WarehouseID", WarehouseID);
                hs.Add("ShipmentNo", ShipmentNo == string.Empty ? null : ShipmentNo);
                hs.Add("PackingNo", PackingNo == string.Empty ? null : PackingNo);
                hs.Add("CustomerPONo", CustomerPONo == string.Empty ? null : CustomerPONo);
                if (PackingDateFrom != null)
                {
                    hs.Add("PackingDateFrom", PackingDateFrom);
                }
                else
                {
                    hs.Add("PackingDateFrom", DBNull.Value);
                }
                if (PackingDateTo != null)
                {
                    hs.Add("PackingDateTo", PackingDateTo);
                }
                else
                {
                    hs.Add("PackingDateTo", DBNull.Value);
                }
                hs.Add("Status", Status);

                return Database.ExecuteDataSet("sp_KPK020_ConfirmPacking_SearchAll", hs).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //KPK020
        public static DataTable ConfirmPackingForScannerSearchAll(int? OwnerID, int? CustomerID, int? WarehouseID, string ShipmentNo, string PackingNo,
                                                    string CustomerPONo, DateTime? PackingDateFrom, DateTime? PackingDateTo, bool Status)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("OwnerID", OwnerID);
                hs.Add("CustomerID", CustomerID);
                hs.Add("WarehouseID", WarehouseID);
                hs.Add("ShipmentNo", ShipmentNo == string.Empty ? null : ShipmentNo);
                hs.Add("PackingNo", PackingNo == string.Empty ? null : PackingNo);
                hs.Add("CustomerPONo", CustomerPONo == string.Empty ? null : CustomerPONo);
                if (PackingDateFrom != null)
                {
                    hs.Add("PackingDateFrom", PackingDateFrom);
                }
                else
                {
                    hs.Add("PackingDateFrom", DBNull.Value);
                }
                if (PackingDateTo != null)
                {
                    hs.Add("PackingDateTo", PackingDateTo);
                }
                else
                {
                    hs.Add("PackingDateTo", DBNull.Value);
                }
                hs.Add("Status", Status);

                return Database.ExecuteDataSet("sp_KPK020_ConfirmPacking_ForBarcode_SearchAll", hs).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //KPK020       
        public void ConfirmPackingConfirmData(string PackingNo, string RMTagXML, string CurrentUser)
        {
            Hashtable hs = new Hashtable();
            hs.Add("PackingNo", PackingNo);
            if (!string.IsNullOrEmpty(RMTagXML))
            {
                hs.Add("RMTagXML", RMTagXML);
            }
            else
            {
                hs.Add("RMTagXML", DBNull.Value);
            }
            
            hs.Add("CurrentUser", CurrentUser);
            //hs.Add("UserLogon", UserLogon);
            //hs.Add("MachineIP", MachineIP);


            try
            {
                Database.ExecuteNonQuery("sp_KPK020_ConfirmPacking_Confirm", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        //KPK021
        public DataTable ConfirmPackingSearchRMTagDetail(string PDSNo, string RunningNo, string ProductCode, string ShipmentNo, string PackingNo)
        {

            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("PDSNo", PDSNo);
                hs.Add("RunningNo", RunningNo);
                hs.Add("ProductCode", ProductCode);
                hs.Add("ShipmentNo", ShipmentNo);
                hs.Add("PackingNo", PackingNo);

                return Database.ExecuteDataSet("sp_KPK021_ConfirmPacking_SearchRMTagDetail", hs).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //KPK022
        public DataTable PackingAppearanceSearchPackingProduct(string PackingNo)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("PackingNo", PackingNo);

                return Database.ExecuteDataSet("sp_KPK022_PackingAppearance_SearchPackingProduct", hs).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
