using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CSI.Business.Admin;
using System.Data.Objects;
using CSI.Business.DataObjects;
using Newtonsoft.Json;

namespace RubixWebAPI.Controllers.Admin
{
    public class ScreenControlController : ApiController
    {
        private ScreenControl sc = new ScreenControl();
        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage ClearScreen()
        {
            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            tb_ScreensControl ResultData = JsonConvert.DeserializeObject<tb_ScreensControl>(strParameterData);

            try
            {
                sc.ClearScreen(ResultData.ScreenID, ResultData.UserID, ResultData.IPaddress);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
        
        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LockScreen()
        {
            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            tb_ScreensControl ResultData = JsonConvert.DeserializeObject<tb_ScreensControl>(strParameterData);
            
            bool tc;

            try
            {
                tc = sc.LockScreen(ResultData.ScreenID, ResultData.UserID, ResultData.IPaddress);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, tc);
        }
    }
}
