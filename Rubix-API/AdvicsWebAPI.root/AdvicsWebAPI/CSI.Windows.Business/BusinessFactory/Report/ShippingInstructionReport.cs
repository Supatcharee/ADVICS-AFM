using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CSI.Business.Report
{
    public class ShippingInstructionReport : BusinessFactory.Report.Base.BaseReport
    {
        public DataSet GetCoverData_Report(string ShipmentNo, int Installment, string ContainerNo)
        {
            try
            {
                Hashtable hash = new Hashtable();
                hash.Add("ShipmentNo", ShipmentNo);
                hash.Add("Installment", Installment);
                hash.Add("ContainerNo", ContainerNo);

                DataSet ds = Database.ExecuteDataSet("sp_RPT040_ShippingInstructionCover_GetData", hash);

                if (ds.Tables.Count == 1)
                {
                    ds.DataSetName = "dsRPT040_ShippingInstructionCoverReport";
                    ds.Tables[0].TableName = "dtbHeader";
                }

                return ds;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataSet GetListData_Report(string ShipmentNo, int Installment, string ContainerNo)
        {
            try
            {
                Hashtable hash = new Hashtable();
                hash.Add("ShipmentNo", ShipmentNo);
                hash.Add("Installment", Installment);
                hash.Add("ContainerNo", ContainerNo);

                DataSet ds = Database.ExecuteDataSet("sp_RPT041_ShippingInstructionList_GetData", hash);

                if (ds.Tables.Count == 1)
                {
                    ds.DataSetName = "dsRPT041_ShippingInstructionListReport";
                    ds.Tables[0].TableName = "dtbData";
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
