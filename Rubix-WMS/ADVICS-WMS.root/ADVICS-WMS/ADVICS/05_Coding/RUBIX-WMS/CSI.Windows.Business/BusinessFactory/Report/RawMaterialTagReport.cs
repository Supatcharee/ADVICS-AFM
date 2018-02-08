using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace CSI.Business.Report
{
    public class RawMaterialTagReport
    {
        public DataSet GetDataReport(string PONo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("PONo", PONo);


            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("RawMaterialTagReport/GetDataReport", hs);
                return JsonConvert.DeserializeObject<DataSet>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
