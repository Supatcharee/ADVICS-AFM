using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;

namespace CSI.Business.Report
{
    public class RawMaterialTagReport : BusinessFactory.Report.Base.BaseReport
    {
        public DataSet GetDataReport(string PONo)
        {
            try
            {
                Hashtable hash = new Hashtable();
                hash.Add("PONo", PONo);

                DataSet ds = Database.ExecuteDataSet("sp_RPT032_RMTag_GetData", hash);

                if (ds.Tables.Count == 3)
                {
                    ds.DataSetName = "dsRPT032_RMTagReport";
                    ds.Tables[0].TableName = "dtbHeader";
                    ds.Tables[1].TableName = "dtbPalletBoxDetail";
                    ds.Tables[2].TableName = "dtbBoxDetail_ServicePart";
                }

                return ds;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
