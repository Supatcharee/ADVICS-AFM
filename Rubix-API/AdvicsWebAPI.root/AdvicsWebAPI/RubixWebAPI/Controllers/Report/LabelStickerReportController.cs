using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using CSI.Business.Report;
using System.Data.Objects;
using CSI.Business.DataObjects;
using System.Net.Http;
using System.Net;
using System.Data;
using Newtonsoft.Json;

namespace RubixWebAPI.Controllers.Report
{
    public class LabelStickerReportController : ApiController
    {
        LabelStickerReport obj = new LabelStickerReport();

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetDataReport(string PackingNo)
        {
            List<sp_RPT045_LabelSticker_GetData_Result> ResultReturn;
            try
            {
                ResultReturn = obj.GetDataReport(PackingNo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }
            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetDataByRMTagReport(string PackingNo, string RMTagStart, string RMTagEnd, int? ProductID)
        {
            List<sp_RPT045_LabelSticker_GetData_Result> ResultReturn;
            try
            {
                ResultReturn = obj.GetDataByRMTagReport(PackingNo, RMTagStart, RMTagEnd, ProductID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }
            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetUserStickerLaberReport()
        {
            List<sp_RPT046_UserStickerLaber_GetData_Result> ResultReturn;
            try
            {
                ResultReturn = obj.GetUserStickerLaberReport();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }
            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }       

    }
}