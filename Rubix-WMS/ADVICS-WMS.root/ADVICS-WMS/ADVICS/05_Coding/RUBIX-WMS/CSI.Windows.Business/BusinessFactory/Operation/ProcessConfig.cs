using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using System.Data;
using CSI.Business.Common;
using System.Globalization;
using Rubix.Framework;
using System.Transactions;
using Newtonsoft.Json;
using System.Collections;
namespace CSI.Business.Operation
{
    public class ProcessConfig
    {
        #region Properties

        #endregion
                
        public void RunDailyProcess()
        {
            try
            {
                RubixWebAPI.ExecuteObjectResult("ProcessConfig/RunDailyProcess");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RunMonthlyProcess()
        {
            try
            {
                RubixWebAPI.ExecuteObjectResult("ProcessConfig/RunMonthlyProcess");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AutoCalPlanProcess()
        {
            try
            {
                RubixWebAPI.ExecuteObjectResult("ProcessConfig/AutoCalPlanProcess");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }  

    }
}
