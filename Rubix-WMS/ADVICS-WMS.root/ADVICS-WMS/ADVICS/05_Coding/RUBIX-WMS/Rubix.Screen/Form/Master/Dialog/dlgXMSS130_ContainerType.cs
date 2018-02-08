using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CSI.Business.Master;
using Rubix.Framework;
namespace Rubix.Screen.Form.Master.Dialog
{
    public partial class dlgXMSS130_ContainerType : DialogBase, Rubix.Framework.IClearable
    {
        #region Member
        String strTransportTypeID = String.Empty;
        String strTransportTypeCode = String.Empty;
        private TransportType db;
        private Common.eScreenMode eScrenMode;
        #endregion

        #region Properties
        public String TransportTypeID
        {
            get { return strTransportTypeID; }
            set { strTransportTypeID = value; }
        }
        public String TransportTypeCode
        {
            get { return strTransportTypeCode; }
            set { strTransportTypeCode = value; }
        }
        public TransportType BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new TransportType();
                }
                return db;
            }
            set
            {
                if (db == null)
                {
                    db = new TransportType();
                }
                db = value;
            }
        }
        public Common.eScreenMode ScreenMode
        {
            get { return eScrenMode; }
            set { eScrenMode = value; }
        }
        #endregion

        #region Constructor
        public dlgXMSS130_ContainerType()
        {
            InitializeComponent();
        }
        #endregion

        #region Event Handler Function
        private void dlgXMSS130_Container_Load(object sender, EventArgs e)
        {
            if (ScreenMode == Common.eScreenMode.View)
            {
                ControlUtil.HiddenControl(true, m_toolBarClear, m_toolBarSave);
                ControlUtil.EnableControl(false, Controls);
            }
            else
            {
                ControlUtil.HiddenControl(false, m_toolBarClear, m_toolBarSave);
            }
            if (ScreenMode == Common.eScreenMode.Add)
            {
                m_statusBarCreatedDate.Caption = DateTime.Now.ToString(Common.FullDatetimeFormat);
                m_statusBarCreatedUser.Caption = AppConfig.UserLogin;
                m_statusBarUpdatedDate.Caption = "-";
                m_statusBarUpdatedUser.Caption = "-";
                clearControl();
                if (BusinessClass.TransportTypeCode != null)
                {
                    BusinessClass = new TransportType();
                }
            }
            else
            {
                DataBinding();
            }
        }

        private void txtWidth_Leave(object sender, EventArgs e)
        {
            CalculateCapacity();
        }

        private void txtLength_Leave(object sender, EventArgs e)
        {
            CalculateCapacity();
        }

        private void txtHeight_Leave(object sender, EventArgs e)
        {
            CalculateCapacity();
        }

        private void txtAllDimension_TextChanged(object sender, EventArgs e)
        {
            TextEdit te = (TextEdit)sender;
            decimal val;
            if (Decimal.TryParse(te.Text, out val))
                te.EditValue = val;
        }


        private void txtWidth_EditValueChanged(object sender, EventArgs e)
        {
            CalculateCapacity();
        }

        private void txtLength_EditValueChanged(object sender, EventArgs e)
        {
            CalculateCapacity();
        }

        private void txtHeight_EditValueChanged(object sender, EventArgs e)
        {
            CalculateCapacity();
        }
        #endregion

        #region Override Method
        public override bool OnCommandSave()
        {
            try
            {
                if (MessageDialog.ShowConfirmationMsg(this,String.Format(Rubix.Screen.Common.GetMessage("I0047"),txtTransportName.Text.Trim())) == DialogButton.Yes)
                {
                    if (ValidateData())
                    {
                        if (BusinessClass.CheckExistTransportTypeCode(txtTransportCode.Text.Trim()) && BusinessClass.TransportTypeCode != txtTransportCode.Text.Trim())
                        {
                            MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0063"));
                            return false;
                        }
                        
                        SavaData();
                        DialogResult = DialogResult.OK;
                        return true;


                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
                return false;
            }
        }
        public override bool OnCommandClear()
        {
            ControlUtil.ClearControlData(this);
            return base.OnCommandClear();
        }
        private void clearControl()
        {
            ControlUtil.ClearControlData(txtTransportCode
                                        , txtTransportName
                                        , txtMaxM3
                                        , txtWeight
                                        , txtWidth
                                        ,txtLength
                                        ,txtHeight
                                        , memoRemark);
            
        }
        #endregion

        #region Generic Function
        private Boolean ValidateData()
        {
            Boolean errFlag = true;
            errorProvider.ClearErrors();
            ////Transport Type Code 
            if (txtTransportCode.Text.Trim() == String.Empty)
            {
                errorProvider.SetError(txtTransportCode, Rubix.Screen.Common.GetMessage("I0061"));
                errFlag = false;
            }

            ////Transport Type Name
            if (txtTransportName.Text.Trim() == String.Empty)
            {
                errorProvider.SetError(txtTransportName, Rubix.Screen.Common.GetMessage("I0062"));
                errFlag = false;
            }

            if (txtMaxPallet.EditValue == null || Convert.ToInt32(txtMaxPallet.EditValue) <= 0)
            {
                errorProvider.SetError(txtMaxPallet, Rubix.Screen.Common.GetMessage("I0358"));
                errFlag = false;
            }
            return errFlag;
        }

        private void DataBinding()
        {
            txtWidth.Text = BusinessClass.Width.ToString();
            txtLength.Text = BusinessClass.Length.ToString();
            txtHeight.Text = BusinessClass.Height.ToString();
            txtTransportCode.Text = BusinessClass.TransportTypeCode;
            txtTransportName.Text = BusinessClass.TransportTypeName;
            txtMaxM3.Text = BusinessClass.MaxM3.ToString();
            txtWeight.Text = BusinessClass.ContainerWeight.ToString();
            memoRemark.Text = BusinessClass.Remark;
            txtMaxPallet.EditValue = BusinessClass.MaxPallet;
            chkLGL.Checked = BusinessClass.LGL;
            CalculateCapacity();
            //Binding Statusbar
            m_statusBarCreatedDate.Caption = BusinessClass.CreateDate.ToString(Common.FullDatetimeFormat);
            m_statusBarCreatedUser.Caption = BusinessClass.CreateUser;
            if (BusinessClass.UpdateDate != null)
            {
                m_statusBarUpdatedDate.Caption = Convert.ToDateTime(BusinessClass.UpdateDate).ToString(Common.FullDatetimeFormat);
                m_statusBarUpdatedUser.Caption = BusinessClass.UpdateUser;
            }
            else if (BusinessClass.UpdateDate == null && ScreenMode == Common.eScreenMode.Edit)
            {
                m_statusBarUpdatedDate.Caption = DateTime.Now.ToString(Common.FullDatetimeFormat);
                m_statusBarUpdatedUser.Caption = AppConfig.UserLogin;
            }
        }

        private void SavaData()
        {
            BusinessClass.TransportTypeCode = txtTransportCode.Text.Trim();
            BusinessClass.TransportTypeName = txtTransportName.Text.Trim();
            if (txtMaxM3.Text.Trim() != string.Empty)
            {
                BusinessClass.MaxM3 = Convert.ToDecimal(txtMaxM3.Text);
            }
            else
            {
                BusinessClass.MaxM3 = null;
            }
            if (txtWeight.Text.Trim() != string.Empty)
            {
                BusinessClass.ContainerWeight = Convert.ToDecimal(txtWeight.Text);
            }
            else
            {
                BusinessClass.ContainerWeight = null;
            }
            BusinessClass.Remark = memoRemark.Text.Trim();
            BusinessClass.CreateUser = AppConfig.UserLogin;

            if (txtWidth.Text.Trim() != string.Empty)
            {
                BusinessClass.Width = DataUtil.Convert<decimal>(txtWidth.Text);
            }
            else
            {
                BusinessClass.Width = null;
            }
            if (txtLength.Text.Trim() != string.Empty)
            {
                BusinessClass.Length = Convert.ToDecimal(txtLength.Text);
            }
            else
            {
                BusinessClass.Length = null;
            }
            if (txtHeight.Text.Trim() != string.Empty)
            {
                BusinessClass.Height = Convert.ToDecimal(txtHeight.Text);
            }
            else
            {
                BusinessClass.Height = null;
            }

            BusinessClass.MaxPallet = Convert.ToInt32(txtMaxPallet.EditValue);
            BusinessClass.LGL = chkLGL.Checked;

            BusinessClass.SaveTransportTypeData();
        }

        public void ClearData()
        {
            errorProvider.ClearErrors();
            if (ScreenMode == Common.eScreenMode.Add)
            {
                clearControl();
            }
            else
            {
                DataBinding();
            }
        }

        private void CalculateCapacity()
        {
            decimal width;
            decimal length;
            decimal height;
            if (!Decimal.TryParse(txtWidth.Text, out width))
                width = 0;
            if (!Decimal.TryParse(txtLength.Text, out length))
                length = 0;
            if (!Decimal.TryParse(txtHeight.Text, out height))
                height = 0;
            if (string.IsNullOrWhiteSpace(txtWidth.Text)
                || string.IsNullOrWhiteSpace(txtLength.Text)
                || string.IsNullOrWhiteSpace(txtHeight.Text))
                txtMaxM3.EditValue = string.Empty;
            else
                txtMaxM3.EditValue = width * length * height;
        }

        #endregion        

    }
}