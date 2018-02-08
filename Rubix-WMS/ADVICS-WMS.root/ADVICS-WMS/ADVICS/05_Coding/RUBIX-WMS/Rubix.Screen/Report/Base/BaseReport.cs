using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.ComponentModel;
using System.Drawing;
using CSI.Business.BusinessFactory.Master;
using System.IO;
using System.Windows.Forms;
using Rubix.Framework;

namespace Rubix.Screen.Report.Base
{
    public class BaseReport : DevExpress.XtraReports.UI.XtraReport
    {
        #region Member
        private SystemConfig db = null;
        protected DevExpress.XtraReports.Parameters.Parameter WMSAddress1 = new DevExpress.XtraReports.Parameters.Parameter();
        protected DevExpress.XtraReports.Parameters.Parameter WMSAddress2 = new DevExpress.XtraReports.Parameters.Parameter();
        protected DevExpress.XtraReports.Parameters.Parameter WMSAddress3 = new DevExpress.XtraReports.Parameters.Parameter();
        protected DevExpress.XtraReports.Parameters.Parameter WMSAddress4 = new DevExpress.XtraReports.Parameters.Parameter();
        protected DevExpress.XtraReports.Parameters.Parameter WMSAddress5 = new DevExpress.XtraReports.Parameters.Parameter();
        protected DevExpress.XtraReports.Parameters.Parameter WMSAddress6 = new DevExpress.XtraReports.Parameters.Parameter();
        protected DevExpress.XtraReports.Parameters.Parameter WMSAddress7 = new DevExpress.XtraReports.Parameters.Parameter();
        protected DevExpress.XtraReports.Parameters.Parameter WMSAddress8 = new DevExpress.XtraReports.Parameters.Parameter();
        protected DevExpress.XtraReports.Parameters.Parameter WMSAddress9 = new DevExpress.XtraReports.Parameters.Parameter();
        protected DevExpress.XtraReports.Parameters.Parameter WMSAddress10 = new DevExpress.XtraReports.Parameters.Parameter();
        protected DevExpress.XtraReports.Parameters.Parameter ISO = new DevExpress.XtraReports.Parameters.Parameter();
        protected DevExpress.XtraReports.Parameters.Parameter MadeIn = new DevExpress.XtraReports.Parameters.Parameter();
        protected DevExpress.XtraReports.Parameters.Parameter TaxRegistration = new DevExpress.XtraReports.Parameters.Parameter();
        private DevExpress.XtraReports.UI.TopMarginBand topMarginBand1;
        private DevExpress.XtraReports.UI.DetailBand detailBand1;
        private DevExpress.XtraReports.UI.BottomMarginBand bottomMarginBand1;
        #endregion

        #region Properties
        public SystemConfig BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new SystemConfig();
                }
                return db;
            }
            set
            {
                if (db == null)
                {
                    db = new SystemConfig();
                }
                db = value;
            }
        }

        private bool _hasISO = true;
        [DefaultValue(true)]
        public bool HasISO
        {
            get { return _hasISO; }
            set { _hasISO = value; }
        }
        #endregion

        #region Constructor
        public BaseReport()
        {
            GenerateDefaultParameters();

            this.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.BaseReport_BeforePrint);
        }

        public BaseReport(List<ReportDefaultParam> rptParams)
        {
            GenerateDefaultParameters();
            foreach (ReportDefaultParam param in rptParams)
            {
                if (this.Parameters[param.Name] != null)
                {
                    this.Parameters[param.Name].Value = param.Value;
                }
            }

            this.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.BaseReport_BeforePrint);
        } 

        private void InitializeComponent()
        {
            this.topMarginBand1 = new DevExpress.XtraReports.UI.TopMarginBand();
            this.detailBand1 = new DevExpress.XtraReports.UI.DetailBand();
            this.bottomMarginBand1 = new DevExpress.XtraReports.UI.BottomMarginBand();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // topMarginBand1
            // 
            this.topMarginBand1.Name = "topMarginBand1";
            // 
            // detailBand1
            // 
            this.detailBand1.Name = "detailBand1";
            // 
            // bottomMarginBand1
            // 
            this.bottomMarginBand1.Name = "bottomMarginBand1";
            // 
            // BaseReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.topMarginBand1,
            this.detailBand1,
            this.bottomMarginBand1});
            this.Version = "11.2";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        #region Event Handler
        private void BaseReport_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //if (HasISO && LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            //{
            //    throw new Exception("Error!!!!!!!!");
            //}
            this.ShowPrintMarginsWarning = false;
            this.ShowPreviewMarginLines = false;
            OnLanguageChange(this, new LanguageChangeEventArgs(new MultiLanguage()));
        } 
        #endregion

        #region Generic Function
        /// <summary>
        /// เพิ่ม Parameter เข้าใน Report
        /// </summary>
        private void GenerateDefaultParameters()
        {
            WMSAddress1.Name = "WMSAddress1";
            this.Parameters.Add(WMSAddress1);
            WMSAddress2.Name = "WMSAddress2";
            this.Parameters.Add(WMSAddress2);
            WMSAddress3.Name = "WMSAddress3";
            this.Parameters.Add(WMSAddress3);
            WMSAddress4.Name = "WMSAddress4";
            this.Parameters.Add(WMSAddress4);
            WMSAddress5.Name = "WMSAddress5";
            this.Parameters.Add(WMSAddress5);
            WMSAddress6.Name = "WMSAddress6";
            this.Parameters.Add(WMSAddress6);
            WMSAddress7.Name = "WMSAddress7";
            this.Parameters.Add(WMSAddress7);
            WMSAddress8.Name = "WMSAddress8";
            this.Parameters.Add(WMSAddress8);
            WMSAddress9.Name = "WMSAddress9";
            this.Parameters.Add(WMSAddress9);
            WMSAddress10.Name = "WMSAddress10";
            this.Parameters.Add(WMSAddress10);
            //END Add
            ISO.Name = "ISO";
            this.Parameters.Add(ISO);

            // Made In
            MadeIn.Name = "MadeIn";
            this.Parameters.Add(MadeIn);

            // Tax Registration
            TaxRegistration.Name = "TaxRegistration";
            this.Parameters.Add(TaxRegistration);

            this.RequestParameters = false;
        }

        public void SetImageLogoReport(DevExpress.XtraReports.UI.XRPictureBox xrPictureBoxLogo)
        {
            BusinessClass.ResultData = BusinessClass.DataLoading("WMSLogo").First();
            string strWMSLogoName = BusinessClass.ConfigValue;
            string strRealPath = string.Empty;
            if (strWMSLogoName.Contains(":\\"))
            {
                if (File.Exists(strWMSLogoName))
                {
                    strRealPath = strWMSLogoName;
                }
            }
            else
            {
                strRealPath = Path.Combine(Application.StartupPath, strWMSLogoName); ;
            }

            if (strRealPath != string.Empty)
            {
                Image img = Image.FromFile(strRealPath);
                xrPictureBoxLogo.Image = img;
            }
        }

        public void SetFrontHeaderReport(DevExpress.XtraReports.UI.XRLabel xrLabelHeader)
        {
        } 
        #endregion

        #region IMultiLanguage Members
        LanguageChangeEventArgs lang = new LanguageChangeEventArgs(new MultiLanguage());
        public virtual void OnLanguageChange(object sender, LanguageChangeEventArgs e)
        {
            if (!this.DesignMode)
            {
                //this.Text = e.MultiLanguage.GetText(MultiLanguage.eType.Form, this.Name, "Text", this.Text);
                Util.ChangeLanguageReport((DevExpress.XtraReports.UI.XtraReport)(sender), e);
                lang = e;
            }
        }
        #endregion                
    }
}
