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
    public class PackingInstructionReportController : ApiController
    {
        private PackingInstructionReport obj = new PackingInstructionReport();

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetDataReport(string packingNo)
        {
            List<sp_RPT035_PackingInstruction_GetData_Result> ResultReturn;
            try
            {
                ResultReturn = obj.GetDataReport(packingNo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }
            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetMaterialDataReport(string packingNo)
        {
            List<sp_RPT035_PackingInstruction_Material_GetData_Result> ResultReturn;
            try
            {
                ResultReturn = obj.GetMaterialDataReport(packingNo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }
            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }
                
        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetCaseMarkReport(string PalletNo)
        {
            List<sp_RPT037_CaseMark_GetData_Result> ResultReturn;
            //string strParameterData = Request.Content.ReadAsStringAsync().Result;
            //sp_RPT037_CaseMark_GetData_Result stc = JsonConvert.DeserializeObject<sp_RPT037_CaseMark_GetData_Result>(strParameterData);
            try
            {
                ResultReturn = obj.GetCaseMarkReport(PalletNo);
                
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }
            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }
    }
}