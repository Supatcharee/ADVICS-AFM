using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Data.Objects;
using CSI.Business.DataObjects;
using System.Net.Http;
using System.Net;
using System.Data;
using Newtonsoft.Json;
using CSI.Business.BusinessFactory.Master;

namespace RubixWebAPI.Controllers.Master
{
    public class SystemConfigController : ApiController
    {
        SystemConfig obj = new SystemConfig();

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DataLoading(string ConfigItem)
        {
            ObjectResult<sp_XMSS280_SystemConfig_Search_Result> ResultReturn;

            try
            {
                ResultReturn = obj.DataLoading(ConfigItem);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage CheckExistConfigID(String ConfigItem)
        {
            Boolean ResultReturn;

            try
            {
                ResultReturn = obj.CheckExistConfigID(ConfigItem);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage SaveSystemConfigData()
        {
            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            sp_XMSS280_SystemConfig_Search_Result ResultData = JsonConvert.DeserializeObject<sp_XMSS280_SystemConfig_Search_Result>(strParameterData);

            obj.ResultData = ResultData;

            try
            {
                obj.SaveSystemConfigData();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DeleteSystemConfigData(int ConfigID)
        {

            obj.ConfigID = ConfigID;

            try
            {
                obj.DeleteSystemConfigData();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}