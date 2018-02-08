using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using CSI.Business;
using System.Net.Http;
using System.Data;
using System.Net;
using Newtonsoft.Json;

namespace RubixWebAPI.Controllers.Admin
{
    public class MultiLangController : ApiController
    {
        private MultiLangBiz ml = new MultiLangBiz();
        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LoadMultilang(string CurrentLanguage, string FormName)
        {
            DataSet ds;
            try
            {
                ds = ml.LoadMultilang(CurrentLanguage, FormName);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }
            return Request.CreateResponse(HttpStatusCode.OK, ds);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LoadAlllanguage()
        {
            DataTable dt;
            try
            {
                dt = ml.LoadAlllanguage();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }
            return Request.CreateResponse(HttpStatusCode.OK, dt);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LoadAllFormName()
        {
            DataTable dt;
            try
            {
                dt = ml.LoadAllFormName();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }
            return Request.CreateResponse(HttpStatusCode.OK, dt);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage AddNewMultiLang(string FORM_ID, string CTRL_ID, string CTRL_TYPE, string ORIGIN, string FORM_NAME, string LANG_WORD, string CREATED_BY)
        {
            try
            {
                ml.AddNewMultiLang(FORM_ID, CTRL_ID, CTRL_TYPE, ORIGIN, FORM_NAME, LANG_WORD, CREATED_BY);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage UpdateMultiLang()
        {
            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            DataTable dt = JsonConvert.DeserializeObject<DataTable>(strParameterData);
            try
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ml.UpdateMultiLang(dr["MAP_ID"].ToString(), dr["LANG_ID"].ToString(), dr["LANG_WORD"].ToString(), dr["UPDATED_BY"].ToString());
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage SearchMultiLang(string FORM_ID, string CTRL_TYPE, string LANG)
        {
            DataTable dt;
            try
            {
                dt = ml.SearchMultiLang(FORM_ID, CTRL_TYPE, LANG);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }
            return Request.CreateResponse(HttpStatusCode.OK, dt);
        }
    }
}