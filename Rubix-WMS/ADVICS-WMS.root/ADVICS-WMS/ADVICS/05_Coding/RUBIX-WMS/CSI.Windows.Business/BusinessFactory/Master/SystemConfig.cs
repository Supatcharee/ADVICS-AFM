using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using System.Collections;
using Newtonsoft.Json;

namespace CSI.Business.BusinessFactory.Master
{
    public class SystemConfig
    {
        #region Member
        private sp_XMSS280_SystemConfig_Search_Result ta_Result = null;
        #endregion

        #region Properties
        public sp_XMSS280_SystemConfig_Search_Result ResultData
        {
            get
            {
                if (ta_Result == null)
                {
                    ta_Result = new sp_XMSS280_SystemConfig_Search_Result();
                }
                return ta_Result;
            }
            set { ta_Result = value; }

        }
        public Object SelectData
        {
            set { ta_Result = (sp_XMSS280_SystemConfig_Search_Result)value; }
        }
        public int ConfigID
        {
            get { return ResultData.ConfigID; }
            set { ResultData.ConfigID = value; }
        }
        public String ConfigItem
        {
            get { return ResultData.ConfigItem; }
            set { ResultData.ConfigItem = value; }
        }
        public String ConfigValue
        {
            get { return ResultData.ConfigValue; }
            set { ResultData.ConfigValue = value; }
        }
        public String Description
        {
            get { return ResultData.Description; }
            set { ResultData.Description = value; }
        }
        #endregion

        public List<sp_XMSS280_SystemConfig_Search_Result> DataLoading(string ConfigItem)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ConfigItem", ConfigItem);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("SystemConfig/DataLoading", hs);
                return JsonConvert.DeserializeObject<List<sp_XMSS280_SystemConfig_Search_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean CheckExistConfigID(String ConfigItem)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ConfigItem", ConfigItem);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("SystemConfig/CheckExistConfigID", hs);
                return JsonConvert.DeserializeObject<Boolean>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveSystemConfigData()
        {
            try
            {
                RubixWebAPI.ExecuteObjectResult("SystemConfig/SaveSystemConfigData", JsonConvert.SerializeObject(ResultData));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteSystemConfigData()
        {
            Hashtable hs = new Hashtable();
            hs.Add("ConfigID", ConfigID);

            try
            {
                RubixWebAPI.ExecuteObjectResult("SystemConfig/DeleteSystemConfigData", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
