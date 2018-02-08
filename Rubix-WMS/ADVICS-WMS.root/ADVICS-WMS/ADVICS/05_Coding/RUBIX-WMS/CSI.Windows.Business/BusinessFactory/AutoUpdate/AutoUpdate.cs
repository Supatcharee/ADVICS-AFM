using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Newtonsoft.Json;
using Rubix.Framework;
using System.Data;

namespace CSI.Business
{
    public class AutoUpdateBiz
    {
        public Boolean CheckProgramUpdate()
        {
            string SerialNo;
            string MainBoardNo;

            DataUtil.GetDataMD5FromRegistry(out SerialNo, out MainBoardNo);

            Hashtable hs = new Hashtable();
            hs.Add("Serial", SerialNo);
            hs.Add("CurrentVersion", AppConfig.ProgramVersion);

            try
            {
                string strResult = RubixWebAPI.ExecuteAutoUpdateObjectResult("AutoUpdate/CheckProgramUpdate", hs);
                return JsonConvert.DeserializeObject<Boolean>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet LoadUpdateData(string ProgramVersion)
        {
            string SerialNo;
            string MainBoardNo;

            DataUtil.GetDataMD5FromRegistry(out SerialNo, out MainBoardNo);
            
            Hashtable hs = new Hashtable();
            hs.Add("Serial", SerialNo);
            hs.Add("CurrentVersion", ProgramVersion);

            try
            {
                string strResult = RubixWebAPI.ExecuteAutoUpdateObjectResult("AutoUpdate/LoadUpdateData", hs);
                return JsonConvert.DeserializeObject<DataSet>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public int LoadForceAutoUpdate()
        //{
        //    string SerialNo;
        //    string MainBoardNo;

        //    DataUtil.GetDataMD5FromRegistry(out SerialNo, out MainBoardNo);

        //    try
        //    {
        //        string strResult = RubixWebAPI.ExecuteAutoUpdateObjectResult("AutoUpdate/LoadForceAutoUpdate", SerialNo);
        //        return JsonConvert.DeserializeObject<int>(strResult);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

    }
}
