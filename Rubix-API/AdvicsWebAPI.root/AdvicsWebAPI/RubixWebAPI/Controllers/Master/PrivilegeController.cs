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
    public class PrivilegeController : ApiController
    {
        Privilege obj = new Privilege();


        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DataLoading(string PrivilegeCode, string PrivilegeName)
        {
            DataTable ResultReturn;

            try
            {
                ResultReturn = obj.DataLoading(PrivilegeCode, PrivilegeName);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage CheckExist(int? PrivilegeID, String PrivilegeCode)
        {
            bool ResultReturn;

            try
            {
                ResultReturn = obj.CheckExist(PrivilegeID, PrivilegeCode);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage SaveData(String CurrentUser)
        {
            string PrivilegeXML = Request.Content.ReadAsStringAsync().Result;
            //string strParameterData = Request.Content.ReadAsStringAsync().Result;
            //stcPrivilegeDetail stc = JsonConvert.DeserializeObject<stcPrivilegeDetail>(strParameterData);
            //obj.PrivilegeID = stc.PrivilegeID;
            //obj.PrivilegeCode = stc.PrivilegeCode;
            //obj.PrivilegeName = stc.PrivilegeName;
            //obj.Remark = stc.Remark;
            //obj.CurrentUser = stc.CurrentUser;

            try
            {
                obj.SaveData(PrivilegeXML, CurrentUser);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DeleteData(int PrivilegeID)
        {
            try
            {
                obj.DeleteData(PrivilegeID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage CheckReference(int PrivilegeID)
        {
            int? ResultReturn;

            try
            {
                ResultReturn = obj.CheckReference(PrivilegeID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

    }
}
