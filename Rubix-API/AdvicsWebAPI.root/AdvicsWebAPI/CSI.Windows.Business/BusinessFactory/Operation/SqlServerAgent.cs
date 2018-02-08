using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Smo.Agent;
using Microsoft.SqlServer.Management.Common;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace CSI.Business.BusinessFactory.Operation
{
    public class SqlServerAgent
    {
        public void CreateJobSchedule(string scheduleName,string jobName,string stepName,string operatorName,string email,int minute,bool isEnabled,bool isRun,string commandName)
        {
            try
            {

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionJob"].ConnectionString);
                ServerConnection conn = new ServerConnection(con);
                Server server = new Server(conn);

                // Get instance of SQL Agent SMO object 
                JobServer jobServer = server.JobServer;
                Job job = null;
                JobStep step = null;
                JobSchedule schedule = null;
                if (jobServer.Jobs.Contains(jobName))
                {
                    jobServer.Jobs[jobName].Drop();
                }

                // Create a schedule 



                //if (jobServer.SharedSchedules.Contains(scheduleName))
                //{
                //    jobServer.SharedSchedules[scheduleName].Drop();
                //}
                schedule = new JobSchedule(jobServer, scheduleName);

                schedule.FrequencyTypes = FrequencyTypes.Daily;
                schedule.FrequencySubDayTypes = FrequencySubDayTypes.Minute;
                schedule.FrequencySubDayInterval = minute;

                schedule.ActiveStartDate = DateTime.Today;
                schedule.ActiveStartTimeOfDay = new TimeSpan(0, 0, 0);
                schedule.FrequencyInterval = 1;
                schedule.Create();

                // Create Job 



                //job = server.JobServer.Jobs[jobName];
                job = new Job(jobServer, jobName);
                job.Create();
                job.AddSharedSchedule(schedule.ID);
                //job.ApplyToTargetServer(server.Name);

                // Create JobStep 
                SqlConnectionStringBuilder DBBuilder = new SqlConnectionStringBuilder();
                DBBuilder.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnectionJob"].ConnectionString;

                step = new JobStep(job, stepName);
                step.DatabaseName = DBBuilder.InitialCatalog; //"WMS";
                step.Command = "EXEC " + commandName; //"EXEC sp_test"; 
                step.SubSystem = AgentSubSystem.TransactSql;
                step.Create();

                //if(jobServer.Operators.Contains(operatorName))
                //{
                //    jobServer.Operators[operatorName].Drop();
                //}
                //Operator o = new Operator(jobServer, operatorName);
                //o.EmailAddress = email;
                //o.AddNotification("Error", NotifyMethods.NotifyEmail);

                //o.Enabled = true;
                //o.Create();

                //Alert a = new Alert(jobServer, "Test Alert");
                //a.Severity = 20;    // Fatal error in current process
                //a.Create();

                //a.AddNotification(operatorName, NotifyMethods.NotifyEmail);


                job.OperatorToEmail = operatorName;
                job.IsEnabled = isEnabled;


                job.ApplyToTargetServer("(local)");
                con.Close();
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_common_enabledjob ", con);
                cmd.CommandType = CommandType.StoredProcedure;

                if (isEnabled)
                {

                    cmd.Parameters.AddWithValue("@job_name", jobName);
                    cmd.Parameters.AddWithValue("@job_enabled_flag", 1);

                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    cmd.ExecuteNonQuery();
                    con.Close();
                    if (isRun)
                    {
                        job.Start();
                    }
                }
                else
                {
                    cmd.Parameters.AddWithValue("@job_name", jobName);
                    cmd.Parameters.AddWithValue("@job_enabled_flag", 0);

                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }

            
        }
    }
}
