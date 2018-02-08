using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using CSI.Business.BusinessFactory.Operation;
using System.Data.Objects;
using CSI.Business.DataObjects;
using System.Net.Http;
using System.Net;
using System.Data;
using Newtonsoft.Json;

namespace RubixWebAPI.Controllers.Operation
{
    public class SqlServerAgentController : ApiController
    {
        SqlServerAgent obj = new SqlServerAgent();

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage CreateJobSchedule(string scheduleName,
                                                    string jobName,
                                                    string stepName,
                                                    string operatorName,
                                                    string email,
                                                    int minute,
                                                    bool isEnabled,
                                                    bool isRun,
                                                    string commandName)
        {

            try
            {
               obj.CreateJobSchedule(scheduleName, jobName, stepName, operatorName, email, minute, isEnabled, isRun, commandName);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}