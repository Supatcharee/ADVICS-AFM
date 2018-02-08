using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.BusinessFactory.Report.Base;
using CSI.Business.DataObjects;
using Newtonsoft.Json;
using System.Collections;
using Rubix.Framework;

namespace CSI.Business.Report
{
    public class LabelStickerReport : BaseReport
    {
        public List<sp_RPT045_LabelSticker_GetData_Result> GetDataReport(string PackingNo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("PackingNo", PackingNo);  

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("LabelStickerReport/GetDataReport", hs);
                return JsonConvert.DeserializeObject<List<sp_RPT045_LabelSticker_GetData_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<sp_RPT045_LabelSticker_GetData_Result> GetDataByRMTagReport(string PackingNo, string RMTagStart, string RMTagEnd, int ProductID)
        {
            //-------------------------------------------------------------------------
            ControlUtil.LMethod = "GetDataByRMTagReport(string PackingNo, string RMTagStart, string RMTagEnd, int ProductID)";
            ControlUtil.LStart = "START";
            ControlUtil.LStartCurrentDateDate = DateTime.Now.ToString("dd/MM/yy HH:mm:ss tt");
           
            //----------------------------------------------------------------------------
            Hashtable hs = new Hashtable();
            hs.Add("PackingNo", PackingNo);
            hs.Add("RMTagStart", string.Format("OUT-{0}", RMTagStart));
            hs.Add("RMTagEnd", string.Format("OUT-{0}", RMTagEnd));
            hs.Add("ProductID", ProductID);

            try
            {
                //---------------------------------------------------------
                ControlUtil.LParameter = String.Format("PackingNo = {0}; RMTagStart= {1}; RMTagEnd = {2}; ProductID = {3};API/LabelStickerReport/GetDataByRMTagReport", PackingNo, RMTagStart, RMTagEnd, ProductID);
                ControlUtil.LogFileStart(ControlUtil.LMethod, ControlUtil.LStart, ControlUtil.LStartCurrentDateDate, ControlUtil.LParameter);
                //---------------------------------------------------------

                string strResult = RubixWebAPI.ExecuteObjectResult("LabelStickerReport/GetDataByRMTagReport", hs);
                //---------------------------------------------------------
                ControlUtil.LEnd = "END";
                ControlUtil.LEndCurrentDate = DateTime.Now.ToString("dd/MM/yy HH:mm:ss tt");
                ControlUtil.LogFileEnd(ControlUtil.LMethod, ControlUtil.LEnd, ControlUtil.LEndCurrentDate);
                //---------------------------------------------------------
                return JsonConvert.DeserializeObject<List<sp_RPT045_LabelSticker_GetData_Result>>(strResult);

                
            }
            catch (Exception ex)
            {
                //-------------------------------------------------------------------------------------------------------
                ControlUtil.LMethod = "Exception --> GetDataByRMTagReport(string PackingNo, string RMTagStart, string RMTagEnd, int ProductID)";
                ControlUtil.LStart = "Start Exception";
                ControlUtil.LStartCurrentDateDate = DateTime.Now.ToString("dd/MM/yy HH:mm:ss tt");
                ControlUtil.LParameter = String.Format("Exception Message is {0}; StackTrace is {1}", ex.Message, ex.StackTrace);
                ControlUtil.LogFileStart(ControlUtil.LMethod, ControlUtil.LStart, ControlUtil.LStartCurrentDateDate, ControlUtil.LParameter);
                ControlUtil.LEnd = "End Exception";
                ControlUtil.LEndCurrentDate = DateTime.Now.ToString("dd/MM/yy HH:mm:ss tt");
                ControlUtil.LogFileEnd(ControlUtil.LMethod, ControlUtil.LEnd, ControlUtil.LEndCurrentDate);
                //-----------------------------------------------------------------------------------------------------

                throw ex;
            }
        }

        public List<sp_RPT046_UserStickerLaber_GetData_Result> GetUserStickerLaberReport()
        {
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("LabelStickerReport/GetUserStickerLaberReport");
                return JsonConvert.DeserializeObject<List<sp_RPT046_UserStickerLaber_GetData_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }       
    }
}
