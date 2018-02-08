using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CSI.Business.Admin;
using CSI.Business.DataObjects;
using System.Data.Objects;
using Newtonsoft.Json;

namespace RubixWebAPI.Controllers
{
    public class UserGroupController : ApiController
    {
        private UserGroup ug = new UserGroup();

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LoadGroup()
        {
            ObjectResult objResult;

            try
            {
                objResult = ug.LoadGroup();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, objResult);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LoadUserByGroup(decimal GroupID)
        {
            ObjectResult objResult;

            try
            {
                objResult = ug.LoadUserByGroup(GroupID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, objResult);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage SaveChange(decimal? GroupID, string GroupName, string Description, string CreateBy)
        {
            string strListUser = Request.Content.ReadAsStringAsync().Result;
            List<sp_ADM020_LoadUserByGroup_Result> lstUser;
            lstUser = JsonConvert.DeserializeObject<List<sp_ADM020_LoadUserByGroup_Result>>(strListUser);

            try
            {
                ug.SaveChange(GroupID, GroupName, Description, CreateBy, lstUser);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DeleteGroup(int GroupID)
        {
            try
            {
                ug.DeleteGroup(GroupID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
        
        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetUserGroup(decimal GroupID)
        {
            tb_UserGroups tbResult;

            try
            {

                tbResult = ug.GetUserGroup(GroupID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, tbResult);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetUserInfo(string UserID)
        {
            sp_ADM020_LoadUserByGroup_Result tbResult;

            try
            {

                tbResult = ug.GetUserInfo(UserID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, tbResult);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage IsDuplicatedGroupName(decimal? GroupID, string GroupName)
        {
            bool blnResult;

            try
            {
                blnResult = ug.IsDuplicatedGroupName(GroupID, GroupName);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, blnResult);
        }



    }
}
