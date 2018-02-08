using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using System.Collections;
using System.Data;

namespace CSI.Business.BusinessFactory.Master
{
    public class Pallet
    {
        #region Member
        private BusinessCommon ims = null; 
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

        public int? PalletID { get; set; }
        public string PalletName { get; set; }
        public string PalletCode { get; set; }
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public decimal? M3 { get; set; }
        public decimal? WeightLimit { get; set; }
        public string Remark { get; set; }
        public string CurrentUser { get; set; }

        #endregion

        #region Generic Function
        public DataTable DataLoading(String PalletCode, String PalletName)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("PalletCode", PalletCode);
                hs.Add("PalletName", PalletName);
                DataTable tb = Database.ExecuteDataSet("sp_XMSS300_Pallet_Search", hs).Tables[0];
                return tb;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Boolean CheckExistPalletCode(String PalletCode)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("PalletCode", PalletCode);
                return (Database.ExecuteDataSet("sp_XMSS301_Pallet_CheckExist", hs).Tables[0].Rows.Count > 0);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void SaveData()
        {
            try
            {

                Hashtable hs = new Hashtable();
                hs.Add("PalletID", PalletID);
                hs.Add("PalletCode", PalletCode);
                hs.Add("PalletName", PalletName);
                hs.Add("Length", Length);
                hs.Add("Width", Width);
                hs.Add("Height", Height);
                hs.Add("M3", M3);
                hs.Add("WeightLimit", WeightLimit);
                hs.Add("Remark", Remark);
                hs.Add("CurrentUser", CurrentUser);

                Database.ExecuteNonQuery("sp_XMSS301_Pallet_Save", hs);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteData()
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("PalletID", PalletID);
                Database.ExecuteNonQuery("sp_XMSS301_Pallet_Delete", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int? CheckReference()
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("PalletID", PalletID);
                return Convert.ToInt32(Database.ExecuteScalar("sp_XMSS301_Pallet_CheckReference", hs));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

    }
}
