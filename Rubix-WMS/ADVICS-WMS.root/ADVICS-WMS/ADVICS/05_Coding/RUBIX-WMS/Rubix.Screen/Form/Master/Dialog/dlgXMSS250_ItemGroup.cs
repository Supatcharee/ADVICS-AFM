using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using CSI.Business.Master;
using Rubix.Framework;
using CSI.Business.DataObjects;
using System.Data.Objects;
using DevExpress.XtraGrid.Views.Grid;

namespace Rubix.Screen.Form.Master.Dialog
{
    public partial class dlgXMSS250_ItemGroup : DialogBase, Rubix.Framework.IClearable
    {  
        #region Member
        private ProductGroup db;
        private Common.eScreenMode eScrenMode;
        private DataRow dtForEdit = null;
        private int rowNoForEdit;
        private int rowCount = 0;
        #endregion

         #region Enum
        public enum eColSubItem
        {
            RowNo,
            ProductCategoryID,
            ProductCategoryCode,
            ProductCategoryName
        }
        #endregion

        #region Properties
        public ProductGroup BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new ProductGroup();
                }
                return db;
            }
            set
            {
                if (db == null)
                {
                    db = new ProductGroup();
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
        public dlgXMSS250_ItemGroup()
        {
            InitializeComponent();
            base.GridViewControl = new GridControl[] { grdItemCategory };
        }
        #endregion

        #region Event Handler Function
        private void dlgXMSS250_ItemGroup_Load(object sender, EventArgs e)
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
                    gdvItemCategory.Columns.Clear();
                    grdItemCategory.DataSource = null;
                    clearControl();
                    if (BusinessClass.ProductGroupCode != null)
                    {
                        BusinessClass = new ProductGroup();
                    }
                }
                else
                {
                    DataBinding();
                }
                DataBindingSubItems();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message);
            }
            finally
            {
                base.GridViewOnChangeLanguage(grdItemCategory);
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkGrid())
                {
                    DataTable dt = grdItemCategory.DataSource as DataTable;
                    DataRow dr = dt.NewRow();
                    dr["RowNo"] = rowCount + 1;
                    dr["ProductCategoryCode"] = txtCategoryCode.Text;
                    dr["ProductCategoryName"] = txtCategoryName.Text;
                    dt.Rows.Add(dr);
                    dt.AcceptChanges();

                    txtCategoryCode.Text = string.Empty;
                    txtCategoryName.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gdvItemCategory.RowCount > 0)
            {
                if (MessageDialog.ShowConfirmationMsg(this,Common.GetMessage("I0016")) == DialogButton.Yes)
                {
                    DataRow dr = gdvItemCategory.GetFocusedDataRow();
                    if (BusinessClass.CheckReferenceCategory(DataUtil.Convert<int>(dr["ProductCategoryID"])) == 1)
                    {
                        MessageDialog.ShowBusinessErrorMsg(this, string.Format(Common.GetMessage("I0082"), "Product Category"));
                        return;
                    }
                    else
                    {

                        if (DataUtil.Convert<int>(dr["ProductCategoryID"]) != null)
                        {
                            BusinessClass.ProductCategoryID = Convert.ToInt32(dr["ProductCategoryID"]);
                            BusinessClass.DeleteProductCategoryData();
                        }
                        int rows = gdvItemCategory.GetFocusedDataSourceRowIndex();
                        gdvItemCategory.DeleteRow(rows);
                    } 
                }
            }
        }
        
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (gdvItemCategory.RowCount > 0)
                {
                    DataRow dr = gdvItemCategory.GetFocusedDataRow();

                    if (dr != null)
                    {
                        dtForEdit = dr;
                        rowNoForEdit = Convert.ToInt32(dr["RowNo"]);
                        txtCategoryCode.Text = dr["ProductCategoryCode"].ToString();
                        txtCategoryName.Text = dr["ProductCategoryName"].ToString();
                        EditMode(true);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateEditData())
                {
                    SetDetail(dtForEdit);
                    ControlUtil.SetBestWidth(gdvItemCategory);
                    ControlUtil.ClearControlData(txtCategoryCode, txtCategoryName);

                    EditMode(false);
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }
        #endregion

        #region Override Method
        public override bool OnCommandSave()
        {
            try
            {
                if (MessageDialog.ShowConfirmationMsg(this,String.Format(Rubix.Screen.Common.GetMessage("I0047"),txtGoodsName.Text.Trim())) == DialogButton.Yes)
                {
                    if (ValidateData())
                    {
                        if (BusinessClass.CheckExistProductGroupCode(txtGoodsCode.Text.Trim()) && BusinessClass.ProductGroupCode != txtGoodsCode.Text.Trim())
                        {
                            MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0081"));
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
            //ControlUtil.ClearControlData(this);
            ClearData();
            return base.OnCommandClear();
        }
        #endregion

        #region Generic Function
        private void DataBinding()
        {
            txtGoodsCode.Text = BusinessClass.ProductGroupCode;
            txtGoodsName.Text = BusinessClass.ProductGroupName;

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

        private void SaveData()
        {
            DataTable dt_save = ForSubItem();

            DataSet ds = new DataSet("SubItemSet");

            dt_save.TableName = "SubItemTable";

            ds.Tables.Add(dt_save);

            BusinessClass.ProductGroupCode = txtGoodsCode.Text.Trim();
            BusinessClass.ProductGroupName = txtGoodsName.Text.Trim();
            BusinessClass.CreateUser = AppConfig.UserLogin;
            string xmlresult = ds.GetXml();
            BusinessClass.SaveProductGroupData(xmlresult);
        }

        private DataTable ForSubItem()
        {
            //post editor before save
            gdvItemCategory.PostEditor();

            DataTable dt_tempData = (DataTable)grdItemCategory.DataSource;

            // -- For Save Data -- \\
            DataTable dt_SaveData = new DataTable();

            dt_SaveData.Columns.Add("SubItemID");
            dt_SaveData.Columns.Add("SubItemCode");
            dt_SaveData.Columns.Add("SubItemName");

            for (int i = 0; i < dt_tempData.Rows.Count; i++)
            {
                //for (int j = 1; j < dt_tempData.Columns.Count; j++)
                //{
                if (dt_tempData.Rows[i].RowState != DataRowState.Deleted)
                {
                    DataRow dr = dt_SaveData.NewRow();
                    dr["SubItemID"] = dt_tempData.Rows[i]["ProductCategoryID"].ToString();
                    dr["SubItemCode"] = dt_tempData.Rows[i]["ProductCategoryCode"].ToString();
                    dr["SubItemName"] = dt_tempData.Rows[i]["ProductCategoryName"].ToString();
                    dt_SaveData.Rows.Add(dr);
                }
                //}
            }

            return dt_SaveData;
        }

        private void clearControl()
        {
            ControlUtil.ClearControlData(txtGoodsCode, txtGoodsName);

        }

        private Boolean ValidateData()
        {
            Boolean errFlag = true;
            ////Unit Code
            if ( txtGoodsCode.Text.Trim() == String.Empty)
            {
                errorProvider.SetError(txtGoodsCode, Rubix.Screen.Common.GetMessage("I0080"));
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(txtGoodsCode, String.Empty);
            }
            return errFlag;
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
            DataBindingSubItems();
        }

        private void DataBindingSubItems()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("RowNo", typeof(int));
            dt.Columns.Add("ProductCategoryID", typeof(int));
            dt.Columns.Add("ProductCategoryCode", typeof(string));
            dt.Columns.Add("ProductCategoryName", typeof(string));

            if (BusinessClass.ProductGroupID == 0)
            {
                grdItemCategory.DataSource = dt;
                gdvItemCategory.Columns[(int)eColSubItem.RowNo].Visible = false;
                gdvItemCategory.Columns[(int)eColSubItem.ProductCategoryID].Visible = false;

                //ห้ามลบ เพราะจะกระทบกัน Multilang
                gdvItemCategory.Columns[(int)eColSubItem.ProductCategoryCode].Name = "gdcItemCategoryCode";
                gdvItemCategory.Columns[(int)eColSubItem.ProductCategoryName].Name = "gdcItemCategoryName";

            }
            else
            {
                DataTable dts = BusinessClass.DataLoadingSubItem();
                if (dts.Rows.Count > 0)
                {
                    grdItemCategory.DataSource = dts;
                    rowCount = dts.Rows.Count;
                }
                else
                {
                    grdItemCategory.DataSource = dt;
                    gdvItemCategory.Columns[(int)eColSubItem.RowNo].Visible = false;
                    gdvItemCategory.Columns[(int)eColSubItem.ProductCategoryID].Visible = false;
                }
            }           
        }

        private bool checkGrid()
        {
            if (txtCategoryCode.Text == string.Empty)
            {
                MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0207"));
                return false;
            }

            if (gdvItemCategory.RowCount != 0)
            {
                DataTable dt = (DataTable)grdItemCategory.DataSource;
                dt.AcceptChanges();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i][1].ToString().Trim() == txtCategoryCode.Text.Trim())
                        {
                            MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0259"));
                            return false;
                        }
                    }
                }
                //DataRow[] dr = ((DataTable)grdCustomer.DataSource).Select(String.Format("ProductCategoryCode = {0}", txtCategoryCode.Text));
                //if (dr.Length > 0)
                //{
                //   return false;
                //}
            }
            return true;

        }

        private void EditMode(bool On)
        {
            ControlUtil.HiddenControl(!On, btnOK);
            ControlUtil.HiddenControl(On, btnAddItem, btnDelete, btnUpdate);
            //grdSubItem.Enabled = !On;
        }

        private bool ValidateEditData()
        {
            bool isValid = true;

            if (string.IsNullOrEmpty(txtCategoryCode.Text))
            {
                MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0207"));
                return false;
            }

            DataTable dt = (DataTable)grdItemCategory.DataSource;

            DataRow[] drExisted = dt.Select(string.Format("RowNo <> {0} AND ProductCategoryCode = '{1}'", rowNoForEdit, txtCategoryCode.Text));

            if (drExisted.Length > 0)
            {
                MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0259"));
                return false;
            }

            return isValid;

        }

        private void SetDetail(DataRow dr)
        {
            //dr["ProductCategoryID"] = itemPriceControl.ProductID;
            dr["ProductCategoryCode"] = txtCategoryCode.Text;
            dr["ProductCategoryName"] = txtCategoryName.Text;
        }
        #endregion

    }
}