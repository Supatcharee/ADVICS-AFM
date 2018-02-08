using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Data.Objects;
using CSI.Business.DataObjects;
using System.Net.Http;
using System.Net;
using CSI.Business.BusinessFactory.Common;
using Newtonsoft.Json;

namespace RubixWebAPI.Controllers.Common
{
    public class IdleValidatorController : ApiController
    {
        public struct IdleValidatorStruct
        {
            public string Table;
            public string Column;
            public string Key;

        }

        IdleValidator id = new IdleValidator();

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LastUpdateDate()
        {
            string ResultReturn;
            try
            {
                string strParameterData = Request.Content.ReadAsStringAsync().Result;
                IdleValidatorStruct stc = JsonConvert.DeserializeObject<IdleValidatorStruct>(strParameterData);
                                
                ResultReturn = id.ReturnValue(stc.Table, stc.Column, stc.Key);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }
    }
}