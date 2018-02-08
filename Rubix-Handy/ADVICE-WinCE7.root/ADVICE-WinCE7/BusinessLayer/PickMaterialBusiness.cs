using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using Newtonsoft.Json;

namespace BusinessLayer
{
    public class PickMaterialBusiness
    {
        public bool CheckPickMat_QRCode(string PDSNo, string RunningNo)
        {
            try
            {
                bool retflag = false;
                Hashtable hs = new Hashtable();
                hs.Add("PDSNo", PDSNo);
                hs.Add("RunningNo", RunningNo);
                string strResult = AdvicsWebAPI.ExecuteObjectResult("HandyTerminal/CheckPickMatData", hs);
                DataTable dt = JsonConvert.DeserializeObject<DataTable>(strResult);
                if (dt.Rows.Count > 0)
                {
                    retflag = true;
                }
                else
                {
                    retflag = false;
                }
                return retflag;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void PickMat_Save(string PDSNo, string RunningNo,string UserName)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("PDSNo", PDSNo);
                hs.Add("RunningNo", RunningNo);
                hs.Add("UserName", UserName);
                string strResult = AdvicsWebAPI.ExecuteObjectResult("HandyTerminal/PickMat_Save", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
