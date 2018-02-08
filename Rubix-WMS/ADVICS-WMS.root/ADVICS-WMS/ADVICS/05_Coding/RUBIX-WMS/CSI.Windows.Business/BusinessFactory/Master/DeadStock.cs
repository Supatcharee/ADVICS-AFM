using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using Newtonsoft.Json;
using System.Collections;
using System.Data;
using Rubix.Framework;
namespace CSI.Business.Master
{
    public class DeadStock
    {
        #region Member
        private DataRow ta_Result = null;
        private BusinessCommon ims = null;
        #endregion

        #region Properties
        private DataRow ResultData
        {
            get
            {              
                return ta_Result;
            }
            set { ta_Result = value; }
        }
        public DataRow SelectData
        {
            set { ta_Result = value; }
        }
        public String CodeName
        {
            get { return ResultData["CodeName"].ToString(); }
            set { ResultData["CodeName"] = value; }
        }
        public String CodeDescription
        {
            get { return ResultData["CodeDescription"].ToString(); }
            set { ResultData["CodeDescription"] = value; }
        }
        public int? EmptyStockDay
        {
            get { return DataUtil.Convert<int>(ResultData["EmptyStockDay"]); }
            set { ResultData["EmptyStockDay"] = value; }
        }
        public int? ExpReceiveCompleteDay
        {
            get { return DataUtil.Convert<int>(ResultData["ExpReceiveCompleteDay"]); }
            set { ResultData["ExpReceiveCompleteDay"] = value; }
        }
        public int? ExpReceiveIncompleteDay
        {
            get { return DataUtil.Convert<int>(ResultData["ExpReceiveIncompleteDay"]); }
            set { ResultData["ExpReceiveIncompleteDay"] = value; }
        }
        public int? ExpShippingCompleteDay
        {
            get { return DataUtil.Convert<int>(ResultData["ExpShippingCompleteDay"]); }
            set { ResultData["ExpShippingCompleteDay"] = value; }

        }
        public int? ExpShippingIncompleteDay
        {
            get { return DataUtil.Convert<int>(ResultData["ExpShippingIncompleteDay"]); }
            set { ResultData["ExpShippingIncompleteDay"] = value; }

        }
        public int? ExpHistoryDay
        {
            get { return DataUtil.Convert<int>(ResultData["ExpHistoryDay"]); }
            set { ResultData["ExpHistoryDay"] = value; }
            
        }
        public int? ExpBillingDataDay
        {
            get { return DataUtil.Convert<int>(ResultData["ExpBillingDataDay"]); }
            set { ResultData["ExpBillingDataDay"] = value; }

        }
        public int? ExpBillingCostDay
        {
            get { return DataUtil.Convert<int>(ResultData["ExpBillingCostDay"]); }
            set { ResultData["ExpBillingCostDay"] = value; }

        }
        public int? ExpSerialDataDay
        {
            get { return DataUtil.Convert<int>(ResultData["ExpSerialDataDay"]); }
            set { ResultData["ExpSerialDataDay"] = value; }

        }
        public int? ExpStockTaking
        {
            get { return DataUtil.Convert<int>(ResultData["ExpStockTaking"]); }
            set { ResultData["ExpStockTaking"] = value; }

        }
        
        public String CreateUser
        {
            get { return ResultData["CreateUser"].ToString(); }
            set { ResultData["CreateUser"] = value; }
        }
        public String UpdateUser
        {
            get { return ResultData["UpdateUser"].ToString(); }
            set { ResultData["UpdateUser"] = value; }

        }
        public String ServerName
        {
            get { return ResultData["ServerName"].ToString(); }
            set { ResultData["ServerName"] = value; }

        }
        public String UserName
        {
            get { return ResultData["Login"].ToString(); }
            set { ResultData["Login"] = value; }

        }
        public String Password
        {
            get { return ResultData["Password"].ToString(); }
            set { ResultData["Password"] = value; }

        }
        public String DatabaseName
        {
            get { return ResultData["DatabaseName"].ToString(); }
            set { ResultData["DatabaseName"] = value; }

        }
        #endregion

        public DataTable GetData()
        {
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("DeadStock/GetData");
                return JsonConvert.DeserializeObject<DataTable>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void SaveDeadStockData()
        {            
            try
            {
                RubixWebAPI.ExecuteObjectResult("DeadStock/SaveDeadStockData", JsonConvert.SerializeObject(ResultData.Table));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
