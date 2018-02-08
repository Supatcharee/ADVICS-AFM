using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CSI.Business.Master;
using CSI.Business;
using Rubix.Framework;
using System.Text.RegularExpressions;
using CSI.Business.BusinessFactory.Master;

namespace Rubix.Screen.Form.Master.Dialog
{
    public partial class dlgXMSS301_Pallet : DialogBase, Rubix.Framework.IClearable
    {
        #region Member
        private Pallet db;
        private Common.eScreenMode eScrenMode;
        //public DataRow dtr{get;set;}
        #endregion

        #region Enumeration
        enum ePallate
        {
            PalletID,
            PalletCode,
            PalletName,
            Length,
            Width,
            Height,
            M3,
            WeightLimit,
            Remark,
            CreateDate,
            CreateUser,
            UpdateDate,
            UpdateUser
        }
        #endregion

        #region Properties
        public Common.eScreenMode ScreenMode
        {
            get { return eScrenMode; }
            set { eScrenMode = value; }
        }
        
        public Pallet BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new Pallet();
                }
                return db;
            }
            set
            {
                if (db == null)
                {
                    db = new Pallet();
                }
                db = value;
            }
        }

        public DataRow SelectData { set; get; }
        #endregion

        #region Constructor

        public dlgXMSS301_Pallet()
        {
            InitializeComponent();

            
            ControlUtil.EnableControl(false, txtM3);
        }

        #endregion

        #region Event Handler
        private void dlgXMSS301_Pallet_Load(object sender, EventArgs e)
        {
            try
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
                    if (BusinessClass.PalletCode != null)
                    {
                        BusinessClass = new Pallet();
                    }
                }
                else
                {
                    DataBinding();
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
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
            //BusinessClass.PalletID = 0;
            //BusinessClass.SaveData();
            try
            {
                if (MessageDialog.ShowConfirmationMsg(this, String.Format(Rubix.Screen.Common.GetMessage("I0047"), txtPalletName.Text.Trim())) == DialogButton.Yes)
                {
                    if (ValidateData())
                    {
                        if (BusinessClass.CheckExistPalletCode(txtPalletCode.Text.Trim()) && (SelectData == null || SelectData[ePallate.PalletCode.ToString()].ToString() != txtPalletCode.Text.Trim()))
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
            ClearData();
            return base.OnCommandClear();
        }


        #endregion

        #region Generic Function
        private Boolean ValidateData()
        {
            Boolean errFlag = true;
            errorProvider.ClearErrors();
            ////Pallet Code
            if (string.IsNullOrEmpty(txtPalletCode.Text.Trim()))
            {
                errorProvider.SetError(txtPalletCode, Rubix.Screen.Common.GetMessage("I0360"));
                errFlag = false;
            }

            ////Pallet Name
            if (string.IsNullOrEmpty(txtPalletName.Text.Trim()))
            {
                errorProvider.SetError(txtPalletName, Rubix.Screen.Common.GetMessage("I0361"));
                errFlag = false;
            }

            if (string.IsNullOrEmpty(txtWeightLimit.Text.Trim()))
            {
                errorProvider.SetError(txtPalletName, Rubix.Screen.Common.GetMessage("I0406"));
                errFlag = false;
            }

            return errFlag;
        }

        private void SaveData()
        {
            BusinessClass.PalletCode = txtPalletCode.Text.Trim();
            BusinessClass.PalletName = txtPalletName.Text.Trim();
            BusinessClass.Width = Convert.ToDecimal(txtWidth.Text);
            BusinessClass.Height = Convert.ToDecimal(txtHeight.Text);
            BusinessClass.Length = Convert.ToDecimal(txtLength.Text);
            BusinessClass.M3 = Convert.ToDecimal(txtM3.Text);
            BusinessClass.WeightLimit = Convert.ToDecimal(txtWeightLimit.Text);
            BusinessClass.Remark = txtRemark.Text.Trim();
            BusinessClass.CurrentUser = AppConfig.UserLogin;
            BusinessClass.SaveData();
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

        private void DataBinding()
        {
            if (SelectData != null)
            {
                BusinessClass.PalletID = DataUtil.Convert<int>(SelectData[ePallate.PalletID.ToString()].ToString());
                txtPalletCode.Text = SelectData[ePallate.PalletCode.ToString()].ToString();
                txtPalletName.Text = SelectData[ePallate.PalletName.ToString()].ToString();
                txtLength.Text = SelectData[ePallate.Length.ToString()].ToString();
                txtWidth.Text = SelectData[ePallate.Width.ToString()].ToString();
                txtHeight.Text = SelectData[ePallate.Height.ToString()].ToString();
                txtM3.Text = SelectData[ePallate.M3.ToString()].ToString();
                txtWeightLimit.EditValue = SelectData[ePallate.WeightLimit.ToString()].ToString();
                txtRemark.Text = SelectData[ePallate.Remark.ToString()].ToString();

            }

            //Binding Statusbar
            m_statusBarCreatedDate.Caption = Convert.ToDateTime(SelectData[ePallate.CreateDate.ToString()]).ToString(Common.FullDatetimeFormat);
            m_statusBarCreatedUser.Caption = SelectData[ePallate.CreateUser.ToString()].ToString();
            if (SelectData[ePallate.UpdateDate.ToString()] != DBNull.Value)
            {
                m_statusBarUpdatedDate.Caption = Convert.ToDateTime(SelectData[ePallate.UpdateDate.ToString()]).ToString(Common.FullDatetimeFormat);
                m_statusBarUpdatedUser.Caption = SelectData[ePallate.UpdateUser.ToString()].ToString();
            }
            else if (SelectData[ePallate.UpdateDate.ToString()] == DBNull.Value && ScreenMode == Common.eScreenMode.Edit)
            {
                m_statusBarUpdatedDate.Caption = DateTime.Now.ToString(Common.FullDatetimeFormat);
                m_statusBarUpdatedUser.Caption = AppConfig.UserLogin;
            }
        }

        private void clearControl()
        {
            txtLength.Text = "0";
            txtWidth.Text = "0";
            txtHeight.Text = "0";

            this.CalVolume();

            ControlUtil.ClearControlData(txtPalletCode, txtPalletName, txtRemark);

        } 
        #endregion
        
    }
}
