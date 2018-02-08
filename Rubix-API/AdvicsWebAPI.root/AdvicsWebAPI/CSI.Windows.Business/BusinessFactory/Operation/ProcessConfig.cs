using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using System.Data;
using CSI.Business.Common;
using System.Globalization;
using Rubix.Framework;
using System.Transactions;
using System.Collections;
namespace CSI.Business.Operation
{
    public class ProcessConfig
    {
        #region Member
        private BusinessCommon ims = null;
        #endregion

        #region Properties
        private BusinessCommon Database
        {
            get
            {
                if (ims == null)
                {
                    ims = new BusinessCommon();
                }
                return ims;
            }
        }
        private tbs_SystemConfig DailyProcessConfig
        {
            get;
            set;
        }
        private tbs_SystemConfig MonthlyProcessConfig
        {
            get;
            set;
        }
        public string HourFromDailyProcessConfig
        {
            get;
            set;
        }
        public string MinuteFromDailyProcessConfig
        {
            get;
            set;
        }
        public string AMPMFromDailyProcessConfig
        {
            get;
            set;
        }
        public string MonthFromMonthlyProcessConfig
        {
            get;
            set;
        }
        public string YearFromMonthlyProcessConfig
        {
            get;
            set;
        }
        public string HourFromMonthlyProcessConfig
        {
            get;
            set;
        }
        public string MinuteFromMonthlyProcessConfig
        {
            get;
            set;
        }
        public string AMPMFromMonthlyProcessConfig
        {
            get;
            set;
        }
        #endregion
        
        public void LoadDailyProcessConfig()
        {
            try
            {
                DailyProcessConfig = CSI.Business.Common.SystemConfig.LoadConfig("DailyProcess");
                GetDailyProcessConfigData();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public void LoadMonthlyProcessConfig()
        {
            try
            {
                MonthlyProcessConfig = CSI.Business.Common.SystemConfig.LoadConfig("MonthlyProcess");
                GetMonthlyProcessConfigData();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        private void GetDailyProcessConfigData()
        {
            try
            {
                if (DailyProcessConfig == null)
                {
                    HourFromDailyProcessConfig = null;
                    MinuteFromDailyProcessConfig = null;
                    AMPMFromDailyProcessConfig = null;
                }
                else
                {
                    // format : HH:mm
                    string[] data = DailyProcessConfig.ConfigValue.Split(new string[] { ":" }, StringSplitOptions.None);
                    int hour = Convert.ToInt32(data[0]);
                    HourFromDailyProcessConfig = GetHourForAMPMFormat(hour);
                    MinuteFromDailyProcessConfig = data[1];
                    AMPMFromDailyProcessConfig = GetAMPM(hour);
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        private void GetMonthlyProcessConfigData()
        {
            try
            {
                if (MonthlyProcessConfig == null)
                {
                    MonthFromMonthlyProcessConfig = null;
                    YearFromMonthlyProcessConfig = null;
                    HourFromMonthlyProcessConfig = null;
                    MinuteFromMonthlyProcessConfig = null;
                    AMPMFromMonthlyProcessConfig = null;
                }
                else
                {
                    //// format : MM/YYYY HH:mm
                    //string[] data = MonthlyProcessConfig.ConfigValue.Split(new string[] { "/", " ", ":" }, StringSplitOptions.None);
                    //MonthFromMonthlyProcessConfig = GetAbbrMonthName(data[0]);
                    //YearFromMonthlyProcessConfig = data[1];
                    //int hour = Convert.ToInt32(data[2]);
                    //HourFromMonthlyProcessConfig = GetHourForAMPMFormat(hour);
                    //MinuteFromMonthlyProcessConfig = data[3];
                    //AMPMFromMonthlyProcessConfig = GetAMPM(hour);

                    // format : HH:mm
                    string[] data = MonthlyProcessConfig.ConfigValue.Split(new string[] { ":" }, StringSplitOptions.None);
                    int hour = Convert.ToInt32(data[0]);
                    HourFromMonthlyProcessConfig = GetHourForAMPMFormat(hour);
                    MinuteFromMonthlyProcessConfig = data[1];
                    AMPMFromMonthlyProcessConfig = GetAMPM(hour);
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public bool WriteDailyProcessConfig(string hour, string minute, string ampm, bool runAgain, bool needForceRun)
        {

            try
            {
                bool success = false;

                DateTime currentDate = CSI.Business.Database.GetSystemDate();
                DateTime? setTime = ConvertToDateTime(currentDate.Day,
                    currentDate.Month,
                    currentDate.Year,
                    Convert.ToInt32(GetHourFor24HourFormat(hour, ampm)),
                    Convert.ToInt32(minute));

                UpdateDailyProcessSetting(setTime, runAgain, needForceRun);

                return success;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public bool WriteMonthlyProcessConfig(string hour, string minute, string ampm, bool runAgain, bool needForceRun)
        {
            try
            {

                bool success = false;

                DateTime currentDate = CSI.Business.Database.GetEndDateOfCurrentMonth();
                DateTime? setTime = ConvertToDateTime(currentDate.Day,
                    currentDate.Month,
                    currentDate.Year,
                    Convert.ToInt32(GetHourFor24HourFormat(hour, ampm)),
                    Convert.ToInt32(minute));

                UpdateMonthlyProcessSetting(setTime, runAgain, needForceRun);
                return success;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        private string GetHourForAMPMFormat(int hour)
        {
            try
            {

                if (hour == 0)
                {
                    return "12";
                }
                else if (hour > 12)
                {
                    return (hour % 12).ToString().PadLeft(2, '0');
                }
                else
                {
                    return hour.ToString().PadLeft(2, '0');
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        private string GetHourFor24HourFormat(string hour, string ampm)
        {
            try
            {
                int HH = Convert.ToInt32(hour);
                if (HH == 12 && ampm == "AM")
                {
                    return "00";
                }
                else if (HH == 12 && ampm == "PM")
                {
                    return "12";
                }
                else if (ampm == "PM")
                {
                    return (HH + 12).ToString();
                }
                else
                {
                    return hour.ToString().PadLeft(2, '0'); ;
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        private string GetAMPM(int hourFor24HourFormat) 
        {
            try
            {
                return hourFor24HourFormat > 11 ? "PM" : "AM";
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        private void UpdateDailyProcessSetting(DateTime? dt, bool runAgain, bool needForceRun)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ScheduledJobId", LoadJobIDDailyProcessConfig());
                hs.Add("NewDateTime", dt);
                hs.Add("RunAgainFlag", runAgain);
                hs.Add("NeedForceRunFlag", needForceRun);
                Database.ExecuteNonQuery("sp_XCMP010_UpdateScheduledJob", hs);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        private void UpdateMonthlyProcessSetting(DateTime? dt, bool runAgain, bool needForceRun)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ScheduledJobId", LoadJobIDMonthlyProcessConfig());
                hs.Add("NewDateTime", dt);
                hs.Add("RunAgainFlag", runAgain);
                hs.Add("NeedForceRunFlag", needForceRun);

                Database.ExecuteNonQuery("sp_XCMP010_UpdateScheduledJob", hs);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        private int? LoadJobIDDailyProcessConfig()
        {
            try
            {
                tbs_SystemConfig jobIdProcess = CSI.Business.Common.SystemConfig.LoadConfig("JobIDDailyProcess");
                return DataUtil.Convert<int>(jobIdProcess.ConfigValue);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        private int? LoadJobIDMonthlyProcessConfig()
        {
            try
            {
                tbs_SystemConfig jobIdProcess = CSI.Business.Common.SystemConfig.LoadConfig("JobIDMonthlyProcess");
                return DataUtil.Convert<int>(jobIdProcess.ConfigValue);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        private DateTime? ConvertToDateTime(int day, int month, int year, int hour, int minute)
        {
            try
            {

                DateTime dt = new DateTime(year, month, day, hour, minute, 0);
                return new DateTime?(dt);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public void RunDailyProcess()
        {
            try
            {
                Database.ExecuteNonQuery("sp_XCMP010_DailyJob");
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public void RunMonthlyProcess()
        {
            try
            {
                Database.ExecuteNonQuery("sp_XCMP010_MonthlyJob");
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public void AutoCalPlanProcess()
        {
            try
            {
                Database.ExecuteNonQuery("sp_ASO000_JobForGenerateActualPlan");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ScheduleRunDailyProcess()
        {
            try
            {
                Database.ExecuteNonQuery("SP_JOB_SCHEDULE_DAILY_PROCESS");
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public void ScheduleRunMonthlyProcess()
        {
            try
            {
                Database.ExecuteNonQuery("SP_JOB_SCHEDULE_MONTHLY_PROCESS");
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        private bool CheckDailyProcessAlreadyRun()
        {
            try
            {

                bool alreadyRun = false;

                DateTime currentDate = CSI.Business.Database.GetSystemDate();
                DateTime? OldSetTime = ConvertToDateTime(currentDate.Day,
                    currentDate.Month,
                    currentDate.Year,
                    Convert.ToInt32(GetHourFor24HourFormat(this.HourFromDailyProcessConfig, this.AMPMFromDailyProcessConfig)),
                    Convert.ToInt32(this.MinuteFromDailyProcessConfig));

                if (currentDate.CompareTo(OldSetTime) > 0)
                {
                    alreadyRun = true;
                }

                return alreadyRun;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private bool CheckMonthlyProcessAlreadyRun()
        {
            try
            {
                bool alreadyRun = false;

                DateTime currentDate = CSI.Business.Database.GetEndDateOfCurrentMonth();
                DateTime? OldSetTime = ConvertToDateTime(currentDate.Day,
                    currentDate.Month,
                    currentDate.Year,
                    Convert.ToInt32(GetHourFor24HourFormat(this.HourFromMonthlyProcessConfig, this.AMPMFromMonthlyProcessConfig)),
                    Convert.ToInt32(this.MinuteFromMonthlyProcessConfig));

                if (currentDate.CompareTo(OldSetTime) > 0)
                {
                    alreadyRun = true;
                }

                return alreadyRun;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        /// <summary>
        /// Daily process has been run today, but new time is set on next time.
        /// </summary>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <param name="ampm"></param>
        /// <returns></returns>
        public bool NeedRunDailyProcessAgain(string hour, string minute, string ampm)
        {
            try
            {
                bool needRun = false;

                DateTime currentDate = CSI.Business.Database.GetSystemDate();
                DateTime? SetTime = ConvertToDateTime(currentDate.Day,
                    currentDate.Month,
                    currentDate.Year,
                    Convert.ToInt32(GetHourFor24HourFormat(hour, ampm)),
                    Convert.ToInt32(minute));

                if (true == CheckDailyProcessAlreadyRun() &&
                    SetTime.Value.CompareTo(currentDate) > 0)
                {
                    needRun = true;
                }

                return needRun;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        /// <summary>
        /// Monthly process has been run today, but new time is set on next time.
        /// </summary>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <param name="ampm"></param>
        /// <returns></returns>
        public bool NeedRunMonthlyProcessAgain(string hour, string minute, string ampm)
        {
            try
            {
                bool needRun = false;

                DateTime currentDate = CSI.Business.Database.GetEndDateOfCurrentMonth();
                DateTime? SetTime = ConvertToDateTime(currentDate.Day,
                    currentDate.Month,
                    currentDate.Year,
                    Convert.ToInt32(GetHourFor24HourFormat(hour, ampm)),
                    Convert.ToInt32(minute));

                if (true == CheckMonthlyProcessAlreadyRun() &&
                    SetTime.Value.CompareTo(currentDate) > 0)
                {
                    needRun = true;
                }

                return needRun;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        /// <summary>
        /// Daily process has not been run today, but new time is passed.
        /// </summary>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <param name="ampm"></param>
        /// <returns></returns>
        public bool NeedForceRunDailyProcess(string hour, string minute, string ampm)
        {
            try
            {

                bool needRun = false;

                DateTime currentDate = CSI.Business.Database.GetSystemDate();
                DateTime? SetTime = ConvertToDateTime(currentDate.Day,
                    currentDate.Month,
                    currentDate.Year,
                    Convert.ToInt32(GetHourFor24HourFormat(hour, ampm)),
                    Convert.ToInt32(minute));

                if (false == CheckDailyProcessAlreadyRun() &&
                    currentDate.CompareTo(SetTime) > 0)
                {
                    needRun = true;
                }

                return needRun;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        } 
    }
}
