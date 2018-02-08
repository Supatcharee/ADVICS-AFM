using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;

namespace CSI.Business
{
    public class AutoUpdate
    {
        #region Member
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
        #endregion

        public DataSet LoadUpdateData(string Serial, string CurrentVersion)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("SERIAL", Serial);
                hs.Add("CURRENT_VERSION", CurrentVersion);

                return Database.ExecuteDataSet("SP_AUTO_UPDATE_GETUPDATE", hs);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DataSet LoadMobileUpdateData(string CurrentVersion)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("CURRENT_VERSION", CurrentVersion);

                return Database.ExecuteDataSet("SP_AUTO_UPDATE_MOBILE_GETUPDATE", hs);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool CheckProgramUpdate(string Serial, string CurrentVersion)
        {
            try
            {
                DataSet ds = LoadUpdateData(Serial, CurrentVersion);

                return (ds.Tables[0].Rows.Count > 0 || ds.Tables[1].Rows.Count > 0);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public bool CheckMobileUpdate(string CurrentVersion)
        {
            try
            {
                DataSet ds = LoadMobileUpdateData(CurrentVersion);

                return (ds.Tables[0].Rows.Count > 0 || ds.Tables[1].Rows.Count > 0);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
