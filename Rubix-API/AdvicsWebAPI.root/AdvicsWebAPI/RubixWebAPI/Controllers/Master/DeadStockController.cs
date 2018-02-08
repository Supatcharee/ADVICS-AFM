using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using CSI.Business.Master;
using System.Data.Objects;
using CSI.Business.DataObjects;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using System.Data;

namespace RubixWebAPI.Controllers.Master
{
    public class DeadStockController : ApiController
    {
        DeadStock ds = new DeadStock();

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetData()
        {
            DataTable ResultReturn;

            try
            {
                ResultReturn = ds.GetData();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);

        }
    
        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage SaveDeadStockData()
        {    
            try
            {
                string strParameterData = Request.Content.ReadAsStringAsync().Result;
                DataTable ResultData = JsonConvert.DeserializeObject<DataTable>(strParameterData);

                ds.SelectData = ResultData.Rows[0];

                ds.SaveDeadStockData();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}