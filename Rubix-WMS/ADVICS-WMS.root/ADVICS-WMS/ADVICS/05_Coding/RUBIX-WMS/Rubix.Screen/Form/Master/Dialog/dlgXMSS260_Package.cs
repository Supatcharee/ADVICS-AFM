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
using System.Text.RegularExpressions;
namespace Rubix.Screen.Form.Master.Dialog
{
    public partial class dlgXMSS260_Package : DialogBase, Rubix.Framework.IClearable
    {
        #region Member
        private Package db;
        private Common.eScreenMode eScrenMode;
        #endregion

        #region Properties
        public Package BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new Package();
                }
                return db;
            }
            set
            {
                if (db == null)
                {
                    db = new Package();
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
        public dlgXMSS260_Package()
        {
            InitializeComponent();
            //txtLength.Text = "0";
            //txtWidth.Text  = "0";
            //txtHeight.Text = "0";

            this.CalVolume();

            ControlUtil.EnableControl(false, txtM3);
            
        }
        #endregion

        #region Event Handler Function
        private void dlgXMSS220_UnitType_Load(object sender, EventArgs e)
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
                if (BusinessClass.PackageCode != null)
                {
                    BusinessClass = new Package();
                }
            }
            else
            {
                DataBinding();
            }
        }

        private void txtLength_EditValueChanged(object sender, EventArgs e)
        {
            this.CalVolume();
        }

        private void txtWidth_EditValueChanged(object sender, EventArgs e)
        {
            this.CalVolume();
        }

        private void txtHeight_EditValueChanged(object sender, EventArgs e)
        {
            this.CalVolume();
        }

        #endregion

        #region Override Method
        public override bool OnCommandSave()
        {
            try
            {
                if (MessageDialog.ShowConfirmationMsg(this,String.Format(Rubix.Screen.Common.GetMessage("I0047"),txtPackageName.Text.Trim())) == DialogButton.Yes)
                {
                    if (ValidateData())
                    {
                        if (BusinessClass.CheckExistUnitCode(txtPackageCode.Text.Trim()) && BusinessClass.PackageCode != txtPackageCode.Text.Trim())
                        {
                            MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0070"));
                            return false;
                        }
                        
                        SaveData();
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
        #endregion

        #region Generic Function
        private Boolean ValidateData()
        {
            Boolean errFlag = true;
            ////Unit Code
            if (txtPackageCode.Text.Trim() == String.Empty)
            {
                errorProvider.SetError(txtPackageCode, Rubix.Screen.Common.GetMessage("I0250"));
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(txtPackageCode, String.Empty);
            }

            ////Unit Name
            if (txtPackageName.Text.Trim() == String.Empty)
            {
                errorProvider.SetError(txtPackageName, Rubix.Screen.Common.GetMessage("I0251"));
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(txtPackageName, String.Empty);
            }

            ////Unit Width Length Height 
            if (txtLength.Text.Trim() == String.Empty || txtWidth.Text.Trim() == String.Empty || txtHeight.Text.Trim() == String.Empty)
            {
                errorProvider.SetError(txtWidth, Rubix.Screen.Common.GetMessage("I0398"));
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(txtLength, String.Empty);
            }

            ////Unit Width
            //if (txtWidth.Text.Trim() == String.Empty)
            //{
            //    errorProvider.SetError(txtWidth, Rubix.Screen.Common.GetMessage(""));
            //    errFlag = false;
            //}
            //else
            //{
            //    errorProvider.SetError(txtWidth, String.Empty);
            //}

            //////Unit Height
            //if (txtHeight.Text.Trim() == String.Empty)
            //{
            //    errorProvider.SetError(txtHeight, Rubix.Screen.Common.GetMessage(""));
            //    errFlag = false;
            //}
            //else
            //{
            //    errorProvider.SetError(txtHeight, String.Empty);
            //}

            //////Unit M3
            //if (txtM3.Text.Trim() == String.Empty)
            //{
            //    errorProvider.SetError(txtM3, Rubix.Screen.Common.GetMessage(""));
            //    errFlag = false;
            //}
            //else
            //{
            //    errorProvider.SetError(txtM3, String.Empty);
            //}

            return errFlag;
        }

        private void DataBinding()
        {
            txtPackageCode.Text = BusinessClass.PackageCode;
            txtPackageName.Text = BusinessClass.PackageName;
            memoRemark.Text = BusinessClass.Remark;
            txtPackageWeight.EditValue = BusinessClass.Weight;
            txtWidth.EditValue = BusinessClass.Width;
            txtLength.EditValue = BusinessClass.Length;
            txtHeight.EditValue = BusinessClass.Height;

            //Binding Statusbar
            m_statusBarCreatedDate.Caption = Convert.ToDateTime(BusinessClass.CreateDate).ToString(Common.FullDatetimeFormat);
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

        private void SaveData()
        {
            BusinessClass.PackageCode = txtPackageCode.Text.Trim();
            BusinessClass.PackageName = txtPackageName.Text.Trim();
            BusinessClass.Weight = Convert.ToDecimal(txtPackageWeight.Text);
            BusinessClass.Width = Convert.ToDecimal(txtWidth.Text);
            BusinessClass.Height = Convert.ToDecimal(txtHeight.Text);
            BusinessClass.Length = Convert.ToDecimal(txtLength.Text);
            BusinessClass.M3 = Convert.ToDecimal(txtM3.Text);
            BusinessClass.Remark = memoRemark.Text.Trim();
            BusinessClass.CreateUser = AppConfig.UserLogin;
            BusinessClass.SaveUnitData();
            
        }

        private void clearControl() 
        {
            ControlUtil.ClearControlData(txtPackageCode, txtPackageName, memoRemark);
        }

        public void ClearData()
        {
            errorProvider.ClearErrors();
            ControlUtil.ClearControlData(this.Controls);
            if (ScreenMode == Common.eScreenMode.Add)
            {
                clearControl();
            }
            else
            {
                DataBinding();
            }
        }

        private void CalVolume()
        {
            try
            {

                decimal length = Convert.ToDecimal(txtLength.Text);
                decimal width = Convert.ToDecimal(txtWidth.Text);
                decimal height = Convert.ToDecimal(txtHeight.Text);

                if (length >= 0 && width >= 0 && height >= 0)
                {
                    txtM3.EditValue = (length * width * height) / 1000000000;
                }
                else
                {
                    txtM3.EditValue = 0.0000;
                }

            }
            catch (Exception e)
            {
                txtM3.EditValue = "0.000";
            }
        }
        #endregion

        private void txtWidth_KeyPress(object sender, KeyPressEventArgs e)
        {
            //int isNumber = 0;
            //bool isMatch = Regex.IsMatch(txtWidth.Text, @"^[0-9]([.][0-9]{1,3})?$");
            //if (isMatch)
            //{
            //    e.Handled = true;
            //}
            //if (!int.TryParse(e.KeyChar.ToString(), out isNumber))
            //{
            //    e.Handled = true;
            //}
            
        }
    }
}