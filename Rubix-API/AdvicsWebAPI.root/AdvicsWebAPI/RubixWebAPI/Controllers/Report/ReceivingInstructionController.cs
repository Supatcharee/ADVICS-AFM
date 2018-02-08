using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using CSI.Business.BusinessFactory.Report;
using System.Data.Objects;
using CSI.Business.DataObjects;
using System.Net.Http;
using System.Net;
using System.Data;
using Newtonsoft.Json;

namespace RubixWebAPI.Controllers.Report
{
    public class ReceivingInstructionController : ApiController
    {
        ReceivingInstruction obj = new ReceivingInstruction();

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetReceivingInstruction(string receivingNo, int installment)
        {
            List<sp_RPT018_ReceivingInstruction_GetData_Result> ResultReturn;
            try
            {
                ResultReturn = obj.GetReceivingInstruction(receivingNo, installment);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage  GetReceivingLabel(string palletNo,int? locationID,int? productID,string lotNo,int? productConditonID,int? flag)
        {
            List<sp_RPT019_ReceivingLabel_GetData_Result> ResultReturn;
            try
            {
                ResultReturn = obj.GetReceivingLabel(palletNo, locationID, productID, lotNo, productConditonID, flag);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);

        }

    }
}