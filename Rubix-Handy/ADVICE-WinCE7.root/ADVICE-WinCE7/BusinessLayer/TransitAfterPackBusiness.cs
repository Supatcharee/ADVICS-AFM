using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using Newtonsoft.Json;

namespace BusinessLayer
{
    public class TransitAfterPackBusiness
    {

        struct Transitstc
        {
            public string PDSNo;
            public string RunningNo;
            public string LocationCode;
            public string UserName;
        }

        public bool TransitPack_CheckPalletOrLocation(string PalletNo, string LocationCode)
        {
            try
            {
                bool retflag = false;
                Hashtable hs = new Hashtable();
                hs.Add("PalletNo", PalletNo);
                hs.Add("LocationCode", LocationCode);
                string strResult = AdvicsWebAPI.ExecuteObjectResult("HandyTerminal/TransitPack_CheckPalletOrLocation", hs);
                DataTable dt = JsonConvert.DeserializeObject<DataTable>(strResult);
                if (dt.Rows.Count > 0)
                {
                    retflag = true;
                }
                else {
                    retflag = false;
                }
                return retflag;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public void TransitPack_SaveUpdate(string PalletNo, string LocationCode, int Flag, string UserName)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("PalletNo", PalletNo);
                hs.Add("LocationCode", LocationCode);
                hs.Add("Flag", Flag);
                hs.Add("UserName", UserName);
                string strResult = AdvicsWebAPI.ExecuteObjectResult("HandyTerminal/TransitPack_SaveUpdate", hs);
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
                string strResult = AdvicsWebAPI.ExecuteObjectResult("HandyTerminal/GetDetailByPallet", hs);
                DataSet ds = JsonConvert.DeserializeObject<DataSet>(strResult);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
