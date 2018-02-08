using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CSI.Business.Report
{
    public class DomesticInvoiceReport : BusinessFactory.Report.Base.BaseReport
    {
        public DataSet GetDataReport(string ShipmentNo, int Installment, string ContainerNo)
        {
            try
            {
                Hashtable hash = new Hashtable();
                hash.Add("ShipmentNo", ShipmentNo);
                hash.Add("ContainerNo", ContainerNo);
                hash.Add("Installment", Installment);

                DataSet ds = Database.ExecuteDataSet("sp_RPT039_DomesticInvoice_GetData", hash);

                if (ds.Tables.Count == 3)
                {
                    ds.DataSetName = "dsRPT039_DomesticInvoiceReport";
                    ds.Tables[0].TableName = "dtbHeader";
                    ds.Tables[1].TableName = "dtbDetail";
                    ds.Tables[2].TableName = "dtbFooter";
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
