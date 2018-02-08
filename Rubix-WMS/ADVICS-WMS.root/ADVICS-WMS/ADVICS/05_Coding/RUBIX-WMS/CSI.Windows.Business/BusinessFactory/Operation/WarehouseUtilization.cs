/*
 * 17 Jan 2013:
 * 1. add method for check whether can show qty level1
 * 28 Jan 2013:
 * 1. modify DeleteTransport and DeleteOther function to validate receiving no before delete
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using CSI.Business;
using System.Data;
using System.Collections;
using CSI.Business.BusinessFactory.Operation.Base;
using System.Transactions;
using Rubix.Framework;
using Newtonsoft.Json;

namespace CSI.Business.Operation
{
    public class WarehouseUtilization
    {        
        public DataSet SpaceUtilization_Load(int WarehouseID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("WarehouseID", WarehouseID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("WarehouseUtilization/SpaceUtilization_Load", hs);
                return JsonConvert.DeserializeObject<DataSet>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
