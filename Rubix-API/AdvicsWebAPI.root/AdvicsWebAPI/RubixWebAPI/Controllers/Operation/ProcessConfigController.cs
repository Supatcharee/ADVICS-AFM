using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using CSI.Business.Operation;
using System.Data.Objects;
using CSI.Business.DataObjects;
using System.Net.Http;
using System.Net;
using System.Data;
using Newtonsoft.Json;

namespace RubixWebAPI.Controllers.Operation
{
    public class ProcessConfigController : ApiController
    {
        ProcessConfig obj = new ProcessConfig();
        
        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage WriteDailyProcessConfig(string hour, string minute, string ampm, bool runAgain, bool needForceRun)
        {
            bool ResultReturn;
            try
            {
                ResultReturn = obj.WriteDailyProcessConfig(hour, minute, ampm, runAgain, needForceRun);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage WriteMonthlyProcessConfig(string hour, string minute, string ampm, bool runAgain, bool needForceRun)
        {
            bool ResultReturn;
            try
            {
                ResultReturn = obj.WriteMonthlyProcessConfig(hour, minute, ampm, runAgain, needForceRun);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }
        
        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage RunDailyProcess()
        {
            try
            {
                obj.RunDailyProcess();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage RunMonthlyProcess()
        {
            try
            {
                obj.RunMonthlyProcess();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage AutoCalPlanProcess()
        {
            try
            {
                obj.AutoCalPlanProcess();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }


        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage ScheduleRunDailyProcess()
        {
            try
            {
                obj.ScheduleRunDailyProcess();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage ScheduleRunMonthlyProcess()
        {
            try
            {
                obj.ScheduleRunMonthlyProcess();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage NeedRunDailyProcessAgain(string hour, string minute, string ampm, string HourFromDailyProcessConfig, string AMPMFromDailyProcessConfig, string MinuteFromDailyProcessConfig)
        {
            obj.HourFromDailyProcessConfig = HourFromDailyProcessConfig;
            obj.AMPMFromDailyProcessConfig = AMPMFromDailyProcessConfig;
            obj.MinuteFromDailyProcessConfig = MinuteFromDailyProcessConfig;

            bool ResultReturn;
            try
            {
                ResultReturn = obj.NeedRunDailyProcessAgain(hour,minute,ampm);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage NeedRunMonthlyProcessAgain(string hour, string minute, string ampm, string HourFromMonthlyProcessConfig, string AMPMFromMonthlyProcessConfig, string MinuteFromMonthlyProcessConfig)
        {
            obj.HourFromMonthlyProcessConfig = HourFromMonthlyProcessConfig;
            obj.AMPMFromMonthlyProcessConfig = AMPMFromMonthlyProcessConfig;
            obj.MinuteFromMonthlyProcessConfig = MinuteFromMonthlyProcessConfig;

            bool ResultReturn;
            try
            {
                ResultReturn = obj.NeedRunMonthlyProcessAgain(hour, minute, ampm);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage NeedForceRunDailyProcess(string hour, string minute, string ampm, string HourFromDailyProcessConfig, string AMPMFromDailyProcessConfig, string MinuteFromDailyProcessConfig)
        {
            obj.HourFromDailyProcessConfig = HourFromDailyProcessConfig;
            obj.AMPMFromDailyProcessConfig = AMPMFromDailyProcessConfig;
            obj.MinuteFromDailyProcessConfig = MinuteFromDailyProcessConfig;

            bool ResultReturn;
            try
            {
                ResultReturn = obj.NeedForceRunDailyProcess(hour, minute, ampm);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        } 
    }
}