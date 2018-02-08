using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using Newtonsoft.Json;
using System.Collections;
using System.Data;

namespace CSI.Business.BusinessFactory.Master
{
    public class Pallet
    {
        #region Member
        struct stcPalletDetail
        {
            public int?     PalletID;
            public string   PalletCode;
            public string   PalletName;
            public decimal? Length;
            public decimal? Width;
            public decimal? Height;
            public decimal? M3;
            public decimal? WeightLimit;
            public string   Remark;
            public string   CurrentUser;
        }
        #endregion

        #region Properties
        
        public int?     PalletID      { get; set; }
        public string   PalletName    { get; set; }
        public string   PalletCode    { get; set; }
        public decimal  Length        { get; set; }
        public decimal  Width         { get; set; }
        public decimal  Height        { get; set; }
        public decimal? M3            { get; set; }
        public string   Remark        { get; set; }
        public string   CurrentUser   { get; set; }
        public decimal? WeightLimit   { get; set; }

        #endregion

        public DataTable DataLoading(string PalletCode, string PalletName)
        {
            Hashtable hs = new Hashtable();
            hs.Add("PalletCode", PalletCode);
            hs.Add("PalletName", PalletName);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Pallet/DataLoading", hs);
                return JsonConvert.DeserializeObject<DataTable>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Boolean CheckExistPalletCode(String PalletCode)
        {

            Hashtable hs = new Hashtable();
            hs.Add("PalletCode", PalletCode);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Pallet/CheckExistPalletCode", hs);
                return JsonConvert.DeserializeObject<Boolean>(strResult);
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
                stcPalletDetail stc;
                stc.PalletID    = this.PalletID;
                stc.PalletCode  = this.PalletCode;
                stc.PalletName  = this.PalletName;
                stc.Length      = this.Length;
                stc.Width       = this.Width;
                stc.Height      = this.Height;
                stc.M3          = this.M3;
                stc.WeightLimit = this.WeightLimit;
                stc.Remark      = this.Remark;
                stc.CurrentUser = this.CurrentUser;

                RubixWebAPI.ExecuteObjectResult("Pallet/SaveData", JsonConvert.SerializeObject(stc));
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

                RubixWebAPI.ExecuteObjectResult("Pallet/DeleteData", JsonConvert.SerializeObject(this.PalletID));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int? CheckReference(int PalletID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("PalletID", PalletID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Pallet/CheckReference", hs);
                return JsonConvert.DeserializeObject<int>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
