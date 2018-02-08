using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using Advics.Framework;
using System.Collections;
using System.Data;

namespace BusinessLayer
{
    public class TransitBusiness
    {
        struct Transitstc
        {
            public string PDSNo;
            public string RunningNo;
            public string LocationCode;
            public string UserName;
        }

        public DataSet TransitEntry_Search(string PDSNo, string RunningNo)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("PDSNo", PDSNo);
                hs.Add("RunningNo", RunningNo);
                string strResult = AdvicsWebAPI.ExecuteObjectResult("HandyTerminal/TransitEntry_Search", hs);
                return JsonConvert.DeserializeObject<DataSet>(strResult);
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
                Transitstc stc = new Transitstc();
                stc.PDSNo = PDSNo;
                stc.RunningNo = RunningNo;
                stc.LocationCode = LocationCode;
                stc.UserName = UserName;
                string strResult = AdvicsWebAPI.ExecuteObjectResult("HandyTerminal/TransitConfirmationDetail_Save", JsonConvert.SerializeObject(stc));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
