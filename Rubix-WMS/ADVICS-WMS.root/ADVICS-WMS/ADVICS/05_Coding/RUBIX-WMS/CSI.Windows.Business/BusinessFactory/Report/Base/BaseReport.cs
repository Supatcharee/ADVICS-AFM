using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using System.Collections;
using Newtonsoft.Json;

namespace CSI.Business.BusinessFactory.Report.Base
{
    public class BaseReport
    {
        public List<ReportDefaultParam> GetReportDefaultParams(string reportID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("reportID", reportID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("BaseReport/GetReportDefaultParams", hs);
                return JsonConvert.DeserializeObject<List<ReportDefaultParam>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public String GetLabelHeader()
        {
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("BaseReport/GetLabelHeader");
                return JsonConvert.DeserializeObject<String>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
