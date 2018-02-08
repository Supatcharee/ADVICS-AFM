using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;

namespace CSI.Business
{
    public class Authentication
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

        public DataTable SaveToken(string Serial, string ComputerName, string UserLogin, string TOKEN)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("SERIAL", Serial);
                hs.Add("COMPUTER_NAME", ComputerName);
                hs.Add("USER_LOGIN", UserLogin);
                hs.Add("TOKEN", TOKEN);
                return Database.ExecuteDataSet("SP_AUTH_SAVE_TOKEN", hs).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public Boolean CheckExistToken(string Token)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("TOKEN", Token);
                return Database.ExecuteDataSet("SP_AUTH_CHECK_EXIST_TOKEN", hs).Tables[0].Rows.Count == 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean CheckNoOfConnection(string Serial)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("Serial", Serial);
                return Database.ExecuteDataSet("SP_AUTH_CHECK_NO_OF_CONNECTION", hs).Tables[0].Rows.Count >= 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LoadDatabaseConfig(string Token)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("TOKEN", Token);
                return Database.ExecuteDataSet("SP_AUTH_LOAD_DATABASE_CONFIG", hs).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       public DataTable LoadDatabaseConfigByCompanyCode(string CompanyCode, string Serial)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("COMPANY_CODE", CompanyCode);
                hs.Add("Serial", Serial);
                return Database.ExecuteDataSet("SP_LOAD_DATABASE_CONFIG", hs).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

         public bool CheckActivateSerial(string Serial)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("SERIAL", Serial);
                return Database.ExecuteDataSet("SP_AUTH_CHECK_ACTIVATE_SERIAL", hs).Tables[0].Rows.Count > 0;
            }
            catch (Exception ex)
            {
                throw;
            }
        }   

        public bool RegisterMachine(string Serial, string MainboardSerial)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("Serial", Serial);
                hs.Add("MainboardSerial", MainboardSerial);
                return Database.ExecuteDataSet("SP_REGISTER", hs).Tables[0].Rows.Count > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
