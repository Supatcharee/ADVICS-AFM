using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using CSI.Business.BusinessFactory.Operation.Base;
using System.Data.Objects;
using CSI.Business.DataObjects;
using System.Net.Http;
using System.Net;
using System.Data;
using Newtonsoft.Json;

namespace RubixWebAPI.Controllers.Operation.Base
{
    public class BaseReceivingController : ApiController
    {
        BaseReceiving obj = new BaseReceiving();

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetPalletList(string receivingNo)
        {
            List<sp_CRCS020_StoringInstruction_Pallet_Search_Result> ResultReturn;

            try
            {
                ResultReturn = obj.GetPalletList(receivingNo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }
    }
}