using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Advics.Framework
{
    public class AppConfig
    {
        #region Member
        private static List<Form> _formList = new List<Form>(); 
        private const string strCaption = "การแจ้งเตือน";
        #endregion

        public static string AdvicsWebApiUrl { get; set; }
        public static string ProgramVersion { get; set; }

        public static string UserLogin { get; set; }

        public static Form MainMenu { get; set; }

        public static bool IsOpenReceivingModule { get; set; }
        public static bool IsOpenTransitModule { get; set; }
        public static bool IsOpenPickingModule { get; set; }
        public static bool IsOpenTrackingModule { get; set; }
        public static bool IsOpenTransitAfterPackModule { get; set; }
        public static bool IsOpenPickForShipModule { get; set; }
        public static bool IsOpenPickMaterialModule { get; set; }
        public static bool IsOpenPickPackingMaterialModule { get; set; }


        
        public static DialogResult dialogResult { get; set; }

        public static string Caption { get { return strCaption; } }

        public static List<Form> FormList
        {
            get
            {
                return _formList;
            }
            set
            {
                _formList = value;
            }
        }

        #region Handy Terminal Command
        public static string ReceivingCommand 
        {
            get { return "CMD-M001"; }        
        }
        public static string TransitCommand
        {
            get { return "CMD-M002"; }
        }
        public static string PickingCommand
        {
            get { return "CMD-M003"; }
        }
        public static string LogoutCommand
        {
            get { return "CMD-M004"; }
        }
        public static string HomeCommand
        {
            get { return "CMD-F001"; }
        }
        public static string BackCommand
        {
            get { return "CMD-F002"; }
        }
        public static string OKCommand
        {
            get { return "CMD-F003"; }
        }
        public static string ConfirmCommand
        {
            get { return "CMD-F003"; }
        }
        public static string ClearCommand
        {
            get { return "CMD-F004"; }
        }
        #endregion
    }
}
