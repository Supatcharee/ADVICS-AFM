using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using System.Collections;

namespace CSI.Business.BusinessFactory.Master
{
    public class SystemConfig
    {
        #region Member
        private sp_XMSS280_SystemConfig_Search_Result ta_Result = null;
        private BusinessCommon ims = null;
        #endregion

        #region Properties
        private BusinessCommon Database
        {
            get
            {
                if (ims == null)
                {
                    ims = new BusinessCommon();
                }
                return ims;
            }
        }
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

        public ObjectResult<sp_XMSS280_SystemConfig_Search_Result> DataLoading(string ConfigItem)
        {
            try
            {
                return Database.MasterEntity.sp_XMSS280_SystemConfig_Search(configItem: (ConfigItem == String.Empty ? null : ConfigItem));
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public Boolean CheckExistConfigID(String ConfigItem)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ConfigItem", ConfigItem);
                return (Database.ExecuteDataSet("sp_XMSS280_SystemConfig_CheckExist", hs).Tables[0].Rows.Count > 0);
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
                Hashtable hs = new Hashtable();
                hs.Add("ConfigID", ConfigID);
                hs.Add("ConfigItem", ConfigItem);
                hs.Add("ConfigValue", ConfigValue);
                hs.Add("Description", Description);

                Database.ExecuteNonQuery("sp_XMSS280_SystemConfig_Save",hs);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void DeleteSystemConfigData()
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ConfigID", ConfigID);
                Database.ExecuteNonQuery("sp_XMSS280_SystemConfig_Delete",hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
