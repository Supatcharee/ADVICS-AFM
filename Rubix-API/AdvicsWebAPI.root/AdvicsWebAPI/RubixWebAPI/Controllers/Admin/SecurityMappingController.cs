using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CSI.Business.Admin;
using System.Data.Objects;
using System.Data;
using CSI.Business.DataObjects;
using Newtonsoft.Json;

namespace RubixWebAPI.Controllers.Admin
{
    public class SecurityMappingController : ApiController
    {
        private SecurityMapping sm = new SecurityMapping();

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage IsAllowToPerformAuthen(string className, string userID, string permission, int AuthenLevel)
        {
            bool blnResult;
            try
            {
                blnResult = sm.IsAllowToPerformAuthen(className, userID, permission, AuthenLevel);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, blnResult);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LoadAllGroup()
        {
            DataTable objResult;

            try
            {
                objResult = sm.LoadAllGroup();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, objResult);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LoadAllScreen()
        {
            DataTable objResult;

            try
            {
                objResult = sm.LoadAllScreen();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, objResult);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LoadAllUser()
        {
            DataTable objResult;

            try
            {
                objResult = sm.LoadAllUser();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, objResult);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LoadGroupByUserID(string userID)
        {
            DataTable objResult;

            try
            {
                objResult = sm.LoadGroupByUserID(userID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, objResult);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LoadUserPermissionByUserID(string userID)
        {
            DataTable objResult;

            try
            {
                objResult = sm.LoadUserPermissionByUserID(userID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, objResult);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LoadGroupPermissionByGroupID(int groupID)
        {
            DataTable objResult;

            try
            {
                objResult = sm.LoadGroupPermissionByGroupID(groupID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, objResult);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LoadUserByGroupID(int groupID)
        {
            DataTable objResult;

            try
            {
                objResult = sm.LoadUserByGroupID(groupID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, objResult);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LoadGroupPermissionByScreenID(int screenID)
        {
            DataTable objResult;

            try
            {
                objResult = sm.LoadGroupPermissionByScreenID(screenID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, objResult);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LoadUserPermissionByScreenID(int screenID)
        {
            DataTable objResult;

            try
            {
                objResult = sm.LoadUserPermissionByScreenID(screenID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, objResult);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage SecurityMappingSaveChange()
        {
            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            List<tb_SecurityMatch> SecurityList = JsonConvert.DeserializeObject<List<tb_SecurityMatch>>(strParameterData);

            try
            {
                foreach (tb_SecurityMatch tsm in SecurityList)
                {
                    sm.SecurityMappingSaveChange(tsm.SCREENID, tsm.PERMISSION, tsm.USERID, tsm.GROUPID, tsm.CREATEUSER);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LoadMainMenu(string UserID, string ScreenPermission, int AuthenLevel)
        {
            DataTable objResult;

            try
            {
                objResult = sm.LoadMainMenu(UserID, ScreenPermission, AuthenLevel);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, objResult);
        }
          
    }
}
