using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using CSI.Business.Admin;

namespace CSI.Business.HandyTerminal
{
    public class HandyTerminal
    {
        #region Member
        private BusinessCommon db = null;
        #endregion

        #region Properties
        private BusinessCommon Database
        {
            get
            {
                if (db == null)
                {
                    db = new BusinessCommon();
                }
                return db;
            }
        }
        #endregion

        #region Login
        public DataTable UserLogin(string UserName)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("UserName", UserName);
                return Database.ExecuteDataSet("sp_ZLOG010_Login", hs).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 
        #endregion

        #region Permission
        public DataTable LoadMainMenu(string UserID, string Permission)
        {           
            try
            {
                
               Hashtable hs = new Hashtable();
               hs.Add("UserID", UserID);
               hs.Add("Permission", Permission);
                return Database.ExecuteDataSet("sp_ZHND000_LoadMainMenu", hs).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Receiving
        public DataTable ReceivingEntry_SearchBy_ReceivingDate(string ReceivingDate, string UserLogin)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ReceivingDate", ReceivingDate);
                hs.Add("UserLogin", UserLogin);
                return Database.ExecuteDataSet("sp_ZHRC010_ReceivingEntry_SearchBy_ReceivingDate", hs).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet ReceivingEntry_SearchBy_ReceivingNo(string ReceivingNo, int Installment)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ReceivingNo", ReceivingNo);
                hs.Add("Installment", Installment);
                return Database.ExecuteDataSet("sp_ZHRC010_ReceivingEntry_SearchBy_ReceivingNo", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ReceivingConfirmDetail_Save(string ReceivingNo, int Installment, int ProductID, decimal ReceiveQty, int? LocationID, string UserName)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ReceivingNo", ReceivingNo);
                hs.Add("Installment", Installment);
                hs.Add("ProductID", ProductID);
                hs.Add("ReceiveQty", ReceiveQty);
                hs.Add("LocationID", LocationID == 0 ? null : LocationID);
                hs.Add("UserName", UserName);
                Database.ExecuteNonQuery("sp_ZHRC030_ReceivingConfirmDetail_Save", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ReceivingConfirmDetail_RMTagSave(string ReceivingNo, int? IsCompleteFlag, string xmlRMTag)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ReceivingNo", ReceivingNo);
                hs.Add("IsCompleteFlag", IsCompleteFlag);
                hs.Add("xmlRMTag", xmlRMTag);
                Database.ExecuteNonQuery("sp_ZHRC030_ReceivingConfirmDetail_RMTagSave", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Transit
        public DataSet TransitEntry_Search(string PDSNo, string RunningNo)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("PDSNo", PDSNo);
                hs.Add("RunningNo", RunningNo);
                return Database.ExecuteDataSet("sp_ZHTS010_TransitEntry_Search", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void TransitConfirmationDetail_Save(string PDSNo, string RunningNo, string LocationCode, string UserName)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("PDSNo", PDSNo);
                hs.Add("RunningNo", RunningNo);
                hs.Add("LocationCode", LocationCode);
                hs.Add("UserName", UserName);
                Database.ExecuteNonQuery("sp_ZHTS020_TransitConfirmationDetail_RMTagSave", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Picking
        public DataTable PickingEntry_SearchBy_PickingDate(string PickingDate, string UserLogin)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("PickingDate", PickingDate);
                hs.Add("UserLogin", UserLogin);
                return Database.ExecuteDataSet("sp_ZHPK010_PickingEntry_SearchBy_PickingDate", hs).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet PickingEntry_SearchBy_PickingNo(string PickingNo, int Installment)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("PickingNo", PickingNo);
                hs.Add("Installment", Installment);
                return Database.ExecuteDataSet("sp_ZHPK010_PickingEntry_SearchBy_PickingNo", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
                
        public void PickingConfirmationDetail_Save(string PickingNo,int Installment,int ProductID, decimal PickQty, string xmlRMTag ,string UserName)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("PickingNo", PickingNo);            
                hs.Add("Installment", Installment);              
                hs.Add("ProductID", ProductID);               
                hs.Add("PickQty", PickQty);
                hs.Add("xmlRMTag", xmlRMTag);
                hs.Add("UserName", UserName);
                Database.ExecuteNonQuery("sp_ZHPK030_PickingConfirmationDetail_Save", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void PickingPackingMaterial_Save(string xmlRMTag, string UserID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("xmlRMTag", xmlRMTag);
                hs.Add("UserID", UserID);
                Database.ExecuteNonQuery("sp_ZHPK040_PickingPackingMaterial_Save", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Tracking

        public DataSet Tracking_Search(string ILabel)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("QRString", ILabel);

                return Database.ExecuteDataSet("sp_ZHTS050_GetInformationByQR_Search", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion

        #region TransitAfterPack

        public void TransitPack_SaveUpdate(string PalletNo, string LocationCode, int Flag, string UserName)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("PalletNo", PalletNo);
                hs.Add("LocationCode", LocationCode);
                hs.Add("Flag", Flag);
                hs.Add("UserName", UserName);

                Database.ExecuteNonQuery("sp_ZHTP010_CaseMarkPickAndPack", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable TransitPack_CheckPalletOrLocation(string PalletNo, string LocationCode)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("PalletNo", PalletNo);
                hs.Add("LocationCode", LocationCode);
                return Database.ExecuteDataSet("sp_ZHTP010_CheckPalletOrLocationPickAndPack", hs).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetDetailByPallet(string PalletNo)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("PalletNo", PalletNo);
                return Database.ExecuteDataSet("sp_ZHTP020_GetDetailByPallet", hs);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        
        #endregion

        #region PickForShip

        public void PickShip_Update(string PalletNo, string LocationCode, int Flag, string UserName)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("PalletNo", PalletNo);
                hs.Add("LocationCode", LocationCode);
                hs.Add("Flag", Flag);
                hs.Add("UserName", UserName);

                Database.ExecuteNonQuery("sp_ZHTP010_CaseMarkPickAndPack", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable PickShip_CheckPalletOrLocation(string PalletNo, string LocationCode)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("PalletNo", PalletNo);
                hs.Add("LocationCode", LocationCode);
                return Database.ExecuteDataSet("sp_ZHTP010_CheckPalletOrLocationPickAndPack", hs).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CaseMarkPickAndPack(string PalletNo, string UserName)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("PalletNo", PalletNo);
                hs.Add("UserName", UserName);
                Database.ExecuteDataSet("sp_ZHPS020_CaseMarkPickAndPack ", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet PickingPalletEntry_SearchBy_ContainerNo(string ShipmentNo, string ContainerNo, DateTime PackingDate)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ShipmentNo", ShipmentNo);
                hs.Add("ContainerNo", ContainerNo);
                hs.Add("PackingDate", PackingDate);
                return Database.ExecuteDataSet("sp_ZHPS010_PickingPalletEntry_SearchBy_ContainerNo", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion

        #region PickMaterial

        public DataTable CheckPickMatData(string PDSNo, string RunningNo)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("PDSNo", PDSNo);
                hs.Add("RunningNo", RunningNo);
                return Database.ExecuteDataSet("sp_ZHPM010_CheckPickMaterial", hs).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void PickMat_Save(string PDSNo, string RunningNo, string UserName)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("PDSNo", PDSNo);
                hs.Add("RunningNo", RunningNo);
                hs.Add("UserName", UserName);

                Database.ExecuteNonQuery("sp_ZHPM010_ConfirmPickMaterial", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
