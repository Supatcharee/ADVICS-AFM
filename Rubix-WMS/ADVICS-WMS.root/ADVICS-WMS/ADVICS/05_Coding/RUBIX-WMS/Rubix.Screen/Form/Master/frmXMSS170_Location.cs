using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Rubix.Framework;
using CSI.Business.Master;
using CSI.Business.DataObjects;
using CSI.Business.BusinessFactory.Report;
using DevExpress.XtraReports.UI;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;

namespace Rubix.Screen.Form.Master
{
     [ScreenPermissionAttribute(Permission.OpenScreen, Permission.Edit, Permission.Export)]
    public partial class frmXMSS170_Location : FormBase
    {
        #region Member
         private Location db;         
         private ReceivePlanListReport db2;
         private DataTable dtLocationInformation = null;
         /////////////////////////////////////////////
         private System.Windows.Forms.Control _FocusControl = new System.Windows.Forms.Control();
         private SimpleButton SelectButton;
         private Point ButtonMousePoint;
         private const float FONT_SIZE_BUTTON = 7;
         private const float FONT_SIZE_LABEL = 8;
         private int MarginX = 5;
         private int MarginY = 5;
         private const int NoPixelPerMM = 4;
         private List<LocationGraphic> _LocationSaveList = null;
         private bool IsLoadDetail = false;
         private int ButtonID = 0;
         /////////////////////////////////////////////
        #endregion

        #region Properties
         public Common.eScreenMode ScreenMode { get; set; }

         private Location BusinessClass
         {
             get
             {
                 if (db == null)
                 {
                     db = new Location();
                 }
                 return db;
             }
             set
             {
                 if (db == null)
                 {
                     db = new Location();
                 }
                 db = value;
             }
         }

         SimpleButton NewButton
         {
             get
             {
                 SimpleButton button = new SimpleButton();
                 button.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
                 button.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                 button.Appearance.ForeColor = Color.Black;
                 button.AllowDrop = true;

                 Font _Font = new Font(button.Appearance.Font.FontFamily, FONT_SIZE_BUTTON);
                 button.Appearance.Font = _Font;
                 button.MouseMove += Button_MouseMove;
                 button.MouseUp += Button_MouseUp;
                 button.Click += Button_Click;
                 button.KeyUp += Button_KeyUp;

                 return button;
             }
         }

         LabelControl NewLabel
         {
             get 
             {
                 LabelControl label = new LabelControl();
                 Font _Font = new System.Drawing.Font(label.Appearance.Font.FontFamily, FONT_SIZE_LABEL);
                 label.Appearance.Font = _Font;
                 label.AutoSizeMode = LabelAutoSizeMode.Default;

                 return label;
             }
         }

         private Point PointStart
         {
             get { return pnDrawing.AutoScrollPosition; }
         }

         public List<LocationGraphic> LocationSaveList
         {
             get
             {
                 if (_LocationSaveList == null)
                     _LocationSaveList = new List<LocationGraphic>();
                 return _LocationSaveList;
             }
             set
             {
                 _LocationSaveList = value;
             }
         }

         private ReceivePlanListReport BusinessClassReport
         {
             get
             {
                 if (db2 == null)
                 {
                     db2 = new ReceivePlanListReport();
                 }
                 return db2;
             }
         }

         private byte[] DeletePicture
         {
             get 
             {
                 System.IO.MemoryStream stream = new System.IO.MemoryStream();
                 picDelete.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                 return stream.ToArray();
             }
         }
        #endregion

        #region Constructor
        public frmXMSS170_Location()
        {
            InitializeComponent();
            base.GridExportExcel = gdvSearchResult;
           // base.GridControlSearchResult = new GridControl[] { grdSearchResult };
            base.SetExpandGroupControl(gcLocationDesignSearchCriteria);
            base.SetExpandGroupControl(gcLocationLabelSearchCriteria);
            ControlUtil.HiddenControl(true, m_toolBarAdd, m_toolBarView, m_toolBarSave, m_toolBarRefresh, m_toolBarCancel);   
         
        } 
        #endregion

        #region Override Method
        public override bool OnCommandEdit()
        {
            try
            {
                if (!warehouseControlLocationDesigner.ValidateControl())
                {
                    return false;
                }
                
                ShowWaitScreen();

                zoneControlLocationDesigner.WarehouseID = warehouseControlLocationDesigner.WarehouseID;
                zoneControlLocationDesigner.DataLoading();

                ScreenMode = Common.eScreenMode.Edit;
                LoadWarehouseAndDrawing(ScreenMode);

                ControlUtil.EnableControl(false, warehouseControlLocationDesigner, btnLocationDesignSearch, btnLocationDesignerClear);
                ControlUtil.HiddenControl(false, m_toolBarSave, m_toolBarCancel);
                ControlUtil.HiddenControl(true, m_toolBarEdit);
                ControlUtil.HiddenControl(true, gcLocationInitial);
                ControlUtil.EnableControl(true, btnCreateNewLocation);
                ControlUtil.HiddenControl(false, btnCreateNewLocation);    
                ControlUtil.HiddenControl(true, btnEditLocation, btnDeleteLocation, btnApplyChanging, btnCancelChageLocation);
                SetReadOnlyLocationSettingLayout(false);
                tabWarehouseUtilization.TabPages[1].PageVisible = false;

                return true;
            }
            catch (Exception ex)
            {
                CloseWaitScreen();
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
                return false;
            }
            finally
            {
                CloseWaitScreen();
            }
        }

        public override bool OnCommandSave()
        {
            try
            {
                if (dtLocationInformation.GetChanges() != null && dtLocationInformation.GetChanges().Rows.Count > 0)
                {
                    if (MessageDialog.ShowConfirmationMsg(this, Rubix.Screen.Common.GetMessage("I0268")) == DialogButton.Yes)
                    {
                        dtLocationInformation.RejectChanges();
                    }
                    else
                    {
                        return false;
                    }
                }

                if (SelectButton != null && SelectButton.Text == "Location Code")
                {
                    LocationGraphic item = SelectButton.Tag as LocationGraphic;
                    item.LabelDetail.Dispose();
                    SelectButton.Dispose();
                }


                ShowWaitScreen();
                timerFlashingButton.Enabled = false;
                if (GetLocationSaveList("UNCHANGE", "SAVE"))
                {
                    BusinessClass.SaveZoneData(LocationSaveList, AppConfig.UserLogin);
                    ControlUtil.HiddenControl(true, m_toolBarSave, m_toolBarCancel);
                    ControlUtil.HiddenControl(false, m_toolBarEdit);
                    ControlUtil.EnableControl(false, gcAllLocationInformation.Controls);
                    ControlUtil.EnableControl(true, warehouseControlLocationDesigner, btnLocationDesignSearch, btnLocationDesignerClear);
                    gdcDelete.Visible = false;
                    MessageDialog.ShowInformationMsg(Rubix.Screen.Common.GetMessage("I0003"));
                    ScreenMode = Common.eScreenMode.View;
                    LoadWarehouseAndDrawing();
                }
                else
                {
                    ControlUtil.HiddenControl(true, m_toolBarSave, m_toolBarCancel);
                    ControlUtil.HiddenControl(false, m_toolBarEdit);
                    ControlUtil.EnableControl(false, gcAllLocationInformation.Controls);
                    ControlUtil.EnableControl(true, warehouseControlLocationDesigner, btnLocationDesignSearch, btnLocationDesignerClear);
                    gdcDelete.Visible = false;
                    ScreenMode = Common.eScreenMode.View;
                }
                ControlUtil.HiddenControl(true, btnCreateNewLocation, btnEditLocation, btnDeleteLocation);
                SetReadOnlyLocationSettingLayout(true);
                timerFlashingButton.Enabled = true;
                tabWarehouseUtilization.TabPages[1].PageVisible = true;
                return true;
            }
            catch (Exception ex)
            {
                CloseWaitScreen();
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
                return false;
            }
            finally
            {
                CloseWaitScreen();
            }
        }

        public override bool OnCommandCancel()
        {
            try
            {
                ShowWaitScreen();

                tabWarehouseUtilization.TabPages[1].PageVisible = true;
                ControlUtil.EnableControl(true, warehouseControlLocationDesigner, btnLocationDesignSearch, btnLocationDesignerClear);
                ControlUtil.HiddenControl(true, m_toolBarSave, m_toolBarCancel);
                ControlUtil.HiddenControl(false, m_toolBarEdit);
                ControlUtil.EnableControl(false, gcAllLocationInformation.Controls);
                ControlUtil.HiddenControl(true,btnCreateNewLocation, btnEditLocation, btnDeleteLocation, btnApplyChanging, btnCancelChageLocation);
                gdcDelete.Visible = false;
                ScreenMode = Common.eScreenMode.View;
                LoadWarehouseAndDrawing();
                SetReadOnlyLocationSettingLayout(true);
                return true;
            }
            catch (Exception ex)
            {
                CloseWaitScreen();
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
                return false;
            }
            finally
            {
                CloseWaitScreen();
            }
        }
        #endregion

        #region Event Handler
        private void frmXMSS170_LocationGraphic_Load(object sender, EventArgs e)
        {
            try
            {
                InitialScreen();
                LoadLocationType();
                ClearLocationLabel();
                SetReadOnlyLocationSettingLayout(true);
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void tabWarehouseUtilization_Click(object sender, EventArgs e)
        {
            if (((DevExpress.XtraTab.XtraTabControl)(sender)).SelectedTabPage == xtpLocationDesigner)
            {
                ControlUtil.HiddenControl(true, m_toolBarExport);
                ControlUtil.HiddenControl(false, m_toolBarEdit);
                ControlUtil.HiddenControl(true, m_toolBarPaintStyls, m_toolBarThemeStyls);
            }
            else
            {
                ControlUtil.HiddenControl(false, m_toolBarExport);
                ControlUtil.HiddenControl(true, m_toolBarEdit);
                ControlUtil.HiddenControl(false, m_toolBarPaintStyls, m_toolBarThemeStyls);
            }
        }

        private void btnLocationDesignSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (warehouseControlLocationDesigner.ValidateControl())
                {
                    zoneControlLocationDesigner.WarehouseID = warehouseControlLocationDesigner.WarehouseID;
                    zoneControlLocationDesigner.DataLoading();
                }
                else
                {
                    return;
                }

                ShowWaitScreen();
                ScreenMode = Common.eScreenMode.View;
                LoadWarehouseAndDrawing();
            }
            catch (Exception ex)
            {
                CloseWaitScreen();
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
            finally
            {
                CloseWaitScreen();
            }
        }

        private void btnLocationDesignerClear_Click(object sender, EventArgs e)
        {
            try
            {
                ShowWaitScreen();
                ClearWareHousePanel();
                warehouseControlLocationDesigner.ClearData();
                warehouseControlLocationDesigner.OwnerID = null;
                warehouseControlLocationDesigner.DataLoading();
                ControlUtil.EnableControl(false, gcAllLocationInformation.Controls);
                ControlUtil.ClearControlData(gcAllLocationInformation.Controls);
            }
            catch (Exception ex)
            {
                CloseWaitScreen();
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
            finally
            {
                CloseWaitScreen();
            }
        }

        private void btnCreateNewLocation_Click(object sender, EventArgs e)
        {
            try
            {
                //เปลี่ยนสี่ตัวอักษรปุ่ม กับ babel เดิมกลับก่อน
                ClearSelectionButton();

                ControlUtil.ClearControlData(gcAllLocationInformation.Controls);
                ControlUtil.EnableControl(true, gcAllLocationInformation.Controls);
                ControlUtil.HiddenControl(true, btnEditLocation, btnDeleteLocation, btnCreateNewLocation);
                ControlUtil.HiddenControl(false, btnApplyChanging, btnCancelChageLocation);
                gdcDelete.Visible = true;
                timerFlashingButton.Enabled = false;
                SelectButton = null;
                _FocusControl = null;
                dtLocationInformation.Rows.Clear();
                gdvLocation.OptionsBehavior.Editable = true;
                if (cboRackType.Text == "On Floor")
                {
                    cboAddBy.Text = "Location";
                    ControlUtil.EnableControl(false, cboAddBy);
                }
                else
                {
                    cboAddBy.Text = string.Empty;
                    ControlUtil.EnableControl(true, cboAddBy);
                }

                //////////////////////////////////////////////////////////////////////////////////
                txtWidth.EditValue = 20;
                txtHeight.EditValue = 10;
                cboLabelPosition.EditValue = "Right";
                LocationGraphic item = new LocationGraphic();
                item.LocationName = "Location Name";
                item.LocationCode = "Location Code";
                //item.ZoneID = (int)zoneControlLocationDesigner.ZoneID;
                //item.ZoneColor = zoneControlLocationDesigner.ZoneColor;
                //item.LocationTypeID = Convert.ToInt32(cboLocationType.EditValue);
                //item.Type = cboRackType.Text;
                item.CaptionPosition = cboLabelPosition.EditValue.ToString().Substring(0, 1);
                item.LayoutSizeWidthX = Convert.ToInt32(txtWidth.EditValue);
                item.LayoutSizeHeightY = Convert.ToInt32(txtHeight.EditValue);
                item.CaptionOffset = BusinessClass.GetCaptionOffSet(item.CaptionPosition);
                item.DataState = "INSERT";
                item.LocationInformation = dtLocationInformation.Copy();

                CreateWarehouseLayout(item);
                ///////////////////////////////////////////////////////////////////////////////////
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }  
        }

        private void btnEditLocation_Click(object sender, EventArgs e)
        {
            try
            {
                ControlUtil.EnableControl(true, gcAllLocationInformation.Controls);
                ControlUtil.HiddenControl(true, btnEditLocation, btnDeleteLocation, btnCreateNewLocation);
                ControlUtil.HiddenControl(false, btnApplyChanging, btnCancelChageLocation);
                ControlUtil.EnableControl(false, zoneControlLocationDesigner, cboLocationType, cboRackType);
                gdcDelete.Visible = true;
                gdvLocation.OptionsBehavior.Editable = true;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }  
        }

        private void btnDeleteLocation_Click(object sender, EventArgs e)
        {
            if (SelectButton == null) return;
            try
            {
                LocationGraphic item = SelectButton.Tag as LocationGraphic;

                if (MessageDialog.ShowConfirmationMsg(this, String.Format(Rubix.Screen.Common.GetMessage("I0002"), item.LocationName)) == DialogButton.Yes)
                {
                    this.ShowWaitScreen();
                    if (BusinessClass.CheckReferenceByLayout(item.LocationInformation) != 0)
                    {
                        this.CloseWaitScreen();
                        MessageDialog.ShowBusinessErrorMsg(this, String.Format(Rubix.Screen.Common.GetMessage("I0082"), "Location"));
                    }
                    else
                    {
                        timerFlashingButton.Enabled = false;
                        ControlUtil.ClearControlData(gcAllLocationInformation.Controls);

                        if (item.DataState == "INSERT")
                        {
                            item.LabelDetail.Dispose();
                            SelectButton.Dispose();
                        }
                        else
                        {
                            item.LabelDetail.Visible = false;
                            SelectButton.Visible = false;
                        }
                        item.DataState = "DELETE";
                        SelectButton.Tag = item;
                        AdjustPanelDrawing();
                        ClearSelectionButton();
                    }
                }
            }
            catch (Exception ex)
            {
                this.CloseWaitScreen();
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
            finally
            {
                this.CloseWaitScreen();
            }
        }

        private void btnCancelChageLocation_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.ClearErrors();
                ControlUtil.EnableControl(false, gcAllLocationInformation.Controls);
                ControlUtil.HiddenControl(true, btnApplyChanging, btnCancelChageLocation);
                ControlUtil.HiddenControl(false, btnCreateNewLocation);
                ControlUtil.EnableControl(true, btnCreateNewLocation);
                ControlUtil.HiddenControl(SelectButton == null, btnEditLocation, btnDeleteLocation);
                ControlUtil.EnableControl(SelectButton != null, btnEditLocation, btnDeleteLocation);
                gdcDelete.Visible = false;
                gdvLocation.OptionsBehavior.Editable = false;
                dtLocationInformation.RejectChanges();

                if (SelectButton != null)
                {
                    LocationGraphic property = SelectButton.Tag as LocationGraphic;
                    if (property.LocationCode == "Location Code")
                    {
                        property.LabelDetail.Dispose();
                        SelectButton.Dispose();
                        SelectButton = null;                        
                    }
                }

                LoadButtonDetail();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void btnApplyChanging_Click(object sender, EventArgs e)
        {
            this.ShowWaitScreen();

            if (!ValidateOKLocationLayout() || ValidateExistingLocationCode())
            {
                CloseWaitScreen();
                return;
            }
            
            try
            {
                timerFlashingButton.Enabled = false;
                dtLocationInformation.AcceptChanges();                             

                if (SelectButton != null)
                {                 
                    LocationGraphic property = SelectButton.Tag as LocationGraphic;                   

                    int Widht = 0, Height = 0;
                    Int32.TryParse(txtWidth.Text, out Widht);
                    Int32.TryParse(txtHeight.Text, out Height);
                    SelectButton.Size = new Size(Widht * NoPixelPerMM, Height * NoPixelPerMM);

                    string strLocationCode = dtLocationInformation.Rows[0]["LocationCode"].ToString();         

                    if (cboRackType.Text == "On Floor")
                    {
                        property.LocationCode = strLocationCode;        
                    }
                    else
                    {
                        if (dtLocationInformation.Select(string.Format("LocationCode LIKE '%{0}%'", strLocationCode.Substring(0, 6))).Length == dtLocationInformation.Rows.Count)
                        {
                            property.LocationCode = dtLocationInformation.Rows[0]["LocationCode"].ToString().Substring(0, 6);
                        }
                        else if (dtLocationInformation.Select(string.Format("LocationCode LIKE '%{0}%'", strLocationCode.Substring(0, 5))).Length == dtLocationInformation.Rows.Count)
                        {
                            property.LocationCode = dtLocationInformation.Rows[0]["LocationCode"].ToString().Substring(0, 5);
                        }
                        else
                        {
                            property.LocationCode = dtLocationInformation.Rows[0]["LocationCode"].ToString().Substring(0, 4);
                        }
                    }

                    property.LocationName = dtLocationInformation.Rows[0]["LocationName"].ToString();
                    property.ZoneID = (int)zoneControlLocationDesigner.ZoneID;
                    property.ZoneColor = zoneControlLocationDesigner.ZoneColor;
                    property.LocationTypeID = Convert.ToInt32(cboLocationType.EditValue);
                    property.Type = cboRackType.Text;

                    property.CaptionPosition = cboLabelPosition.EditValue.ToString().Substring(0, 1);
                    property.LayoutSizeWidthX = Convert.ToInt32(txtWidth.EditValue);
                    property.LayoutSizeHeightY = Convert.ToInt32(txtHeight.EditValue);
                    property.CaptionOffset = BusinessClass.GetCaptionOffSet(property.CaptionPosition);
                    property.DataState = property.DataState == "UNCHANGE" ? "CHANGE" : property.DataState;
                    property.LocationInformation = dtLocationInformation.Copy();

                    SelectButton.Appearance.BackColor = ColorTranslator.FromHtml(string.Format("#{0}", zoneControlLocationDesigner.ZoneColor));
                    SelectButton.Tag = property;
                    SelectButton.Text = property.LocationCode;

                    SetLabel(SelectButton);
                    AdjustPanelDrawing();
                }

                ControlUtil.HiddenControl(true, btnApplyChanging, btnCancelChageLocation);                
                ControlUtil.EnableControl(false, gcAllLocationInformation.Controls);
                ControlUtil.HiddenControl(false, btnCreateNewLocation, btnEditLocation, btnDeleteLocation);
                ControlUtil.EnableControl(true, btnCreateNewLocation, btnEditLocation, btnDeleteLocation);
                gdvLocation.OptionsBehavior.Editable = false;
                timerFlashingButton.Enabled = true;
            }
            catch (Exception ex)
            {
                this.CloseWaitScreen();
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
            finally
            {
                this.CloseWaitScreen();
            }
        }

        #region Location Information
        private void cboRackType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {   
                SetEditTableColor();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

         private void btnInitialLocation_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateFirstData())
                {
                    ControlUtil.ClearControlData(gcLocationInitial.Controls);
                    //ControlUtil.EnableControl(true, cboAddBy, btnInitialCancel);
                    gcLocationInitial.Visible = true;
                    ControlUtil.EnableControl(false,btnApplyChanging, btnCancelChageLocation);

                    if (cboRackType.Text == "On Floor")
                    {
                        cboAddBy.EditValue = "Location";                        
                        ControlUtil.EnableControl(true, gcLocationInitial.Controls);
                        ControlUtil.EnableControl(false, cboAddBy);
                    }
                    else
                    {
                        cboAddBy.EditValue = null;
                        ControlUtil.EnableControl(false, gcLocationInitial.Controls);
                        ControlUtil.EnableControl(true, cboAddBy);
                    }
                    ControlUtil.EnableControl(true, btnInitialCancel);
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void btnNewRow_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateFirstData())
                {
                    if (cboRackType.Text == "On Floor" && gdvLocation.RowCount == 1)
                    {
                        return;
                    }

                    DataRow dr = dtLocationInformation.NewRow();
                    dr["LocationID"] = -1;
                    dr["Delete"] = DeletePicture;
                    if (cboRackType.Text == "On Rack")
                    {
                        dr["Stack"] = 1;
                        dr["NoOfPallet"] = 1;
                        dr["EachStack"] = 1;
                        dr["MaxUnit"] = 1;
                    }

                    dtLocationInformation.Rows.Add(dr);
                    //dtLocationInformation.AcceptChanges();
                    grdLocation.DataSource = dtLocationInformation;
                    ControlUtil.EnableControl(false, zoneControlLocationDesigner, cboLocationType, cboRackType);
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void gdvLocation_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                string strRackNo = string.Empty;
                string strLevel = string.Empty;

                if (e.Column == gdcItemConditionCode)
                {
                    if (Util.IsNullOrEmpty(e.Value))
                    {
                        gdvLocation.SetRowCellValue(e.RowHandle, gdcItemConditionName, "");
                        return;
                    }
                    sp_common_LoadProductCondition_Result pc = (repItemCondition.DataSource as List<sp_common_LoadProductCondition_Result>).Where(c => c.ProductConditionID == Convert.ToInt32(e.Value)).FirstOrDefault();
                    if (pc != null)
                    {
                        gdvLocation.SetRowCellValue(e.RowHandle, gdcItemConditionName, pc.ProductConditionName);
                    }
                    else
                    {
                        gdvLocation.SetRowCellValue(e.RowHandle, gdcItemConditionName, "");
                    }
                }
                else if (e.Column == gdcRackNo || e.Column == gdcLevel)
                {
                    strRackNo = gdvLocation.GetRowCellValue(e.RowHandle, gdcRackNo).ToString();
                    strLevel= gdvLocation.GetRowCellValue(e.RowHandle, gdcLevel).ToString();
                    if (cboRackType.Text == "On Rack")
                    {
                        gdvLocation.SetRowCellValue(e.RowHandle, gdcLocationCode, string.Format("{0}-{1}-{2}", zoneControlLocationDesigner.ZoneCode, strRackNo, strLevel));
                    }
                    else
                    {
                        gdvLocation.SetRowCellValue(e.RowHandle, gdcLocationCode, string.Format("{0}-{1}", zoneControlLocationDesigner.ZoneCode, strRackNo));
                    }
                }
                else if (e.Column == gdcStack || e.Column == gdcEachStack)
                {
                    int? iStack = DataUtil.Convert<int>(gdvLocation.GetRowCellValue(e.RowHandle, gdcStack));
                    int? iEachStack = DataUtil.Convert<int>(gdvLocation.GetRowCellValue(e.RowHandle, gdcEachStack));
                    iStack = (iStack == null || iStack <= 0 ? 1 : iStack);
                    iEachStack = (iEachStack == null || iEachStack <= 0 ? 1 : iEachStack);
                    gdvLocation.SetRowCellValue(e.RowHandle, gdcMaxUnit, iStack * iEachStack);
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void gdvLocation_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (cboRackType.Text == "On Rack")
            {
                if (gdvLocation.FocusedColumn == gdcStack ||
                    gdvLocation.FocusedColumn == gdcEachStack ||
                    gdvLocation.FocusedColumn == gdcMaxUnit ||
                    gdvLocation.FocusedColumn == gdcNoOfPallet)
                {
                    e.Cancel = true;
                }
            }
            else
            {
                if (gdvLocation.FocusedColumn == gdcLevel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void gdvLocation_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            bool isValid = true;
            ColumnView view = sender as ColumnView;
            view.ClearColumnErrors();
            string strRackNo = view.GetRowCellValue(e.RowHandle, gdcRackNo).ToString().Trim();

            e.ErrorText = Rubix.Screen.Common.GetMessage("I0353");

            if (view.GetRowCellValue(e.RowHandle, gdcLocationName).ToString().Trim() == String.Empty)
            {
                isValid = false;
                view.SetColumnError(gdcLocationName, Rubix.Screen.Common.GetMessage("I0068"));
            }

            if (strRackNo == String.Empty)
            {
                isValid = false;
                view.SetColumnError(gdcRackNo, Rubix.Screen.Common.GetMessage("I0217", "Rack No."));
            }

            if (!ValidateRackNoFormat(strRackNo))
            {
                isValid = false;
                view.SetColumnError(gdcRackNo, Rubix.Screen.Common.GetMessage("I0098"));
            }

            if (view.GetRowCellValue(e.RowHandle, gdcMaxCapacity).ToString().Trim() == String.Empty)
            {
                isValid = false;
                view.SetColumnError(gdcMaxCapacity, Rubix.Screen.Common.GetMessage("I0289"));
            }

            if (view.GetRowCellValue(e.RowHandle, gdcStack).ToString().Trim() == String.Empty || 
                view.GetRowCellValue(e.RowHandle, gdcStack).ToString().Trim() == "0")
            {
                isValid = false;
                view.SetColumnError(gdcStack, Rubix.Screen.Common.GetMessage("I0349"));
            }


            if (view.GetRowCellValue(e.RowHandle, gdcEachStack).ToString().Trim() == String.Empty ||
                view.GetRowCellValue(e.RowHandle, gdcEachStack).ToString().Trim() == "0")
            {
                isValid = false;
                view.SetColumnError(gdcEachStack, Rubix.Screen.Common.GetMessage("I0349"));
            }

            string strCurrentLocationCode = view.GetRowCellValue(e.RowHandle, gdcLocationCode).ToString();
            string strOLdLocationCode = view.GetRowCellValue(e.RowHandle, gdcOldLocationCode).ToString();
            int? iLocationID = DataUtil.Convert<int>(view.GetRowCellValue(e.RowHandle, gdcLocationID));

            if (strOLdLocationCode != string.Empty && strOLdLocationCode != strCurrentLocationCode && iLocationID != null)
            {
                if (BusinessClass.CheckReferenceByLocation(iLocationID) != 0)
                {
                    isValid = false;
                    view.SetColumnError(gdcLocationCode, Rubix.Screen.Common.GetMessage("I0352", strOLdLocationCode, strCurrentLocationCode));
                }
            }

            DataTable dt = grdLocation.DataSource as DataTable;

            if (dt != null && ( strRackNo == string.Empty || dt.Rows.Count > 1 && dt.Select(string.Format("RackNo LIKE '{0}%'", strRackNo.Substring(0, 1))).Length == 0))
            {
                isValid = false;
                view.SetColumnError(gdcRackNo, Rubix.Screen.Common.GetMessage("I0098"));
            }

            DataRow[] dr = dt.Select(string.Format("LocationCode = '{0}' AND OldLocationCode <> '{1}' ", strCurrentLocationCode, strOLdLocationCode));

            if (dr.Length >= 1)
            {
                isValid = false;
                view.SetColumnError(gdcLocationCode, Rubix.Screen.Common.GetMessage("I0069", strCurrentLocationCode));
            }
            else if (strOLdLocationCode != strCurrentLocationCode)
            {
                if (!CheckExistLocation(strCurrentLocationCode, zoneControlLocationDesigner.ZoneID))
                {
                    isValid = false;
                    view.SetColumnError(gdcLocationCode, Rubix.Screen.Common.GetMessage("I0069", strCurrentLocationCode));
                }
            }

            e.Valid = isValid;
        }

        private void repDelete_Click(object sender, EventArgs e)
        {
            try
            {
                ShowWaitScreen();
                DataRow dr = gdvLocation.GetFocusedDataRow();
                int? iLocationID = DataUtil.Convert<int>(dr["LocationID"]);
                if (dr["OldLocationCode"].ToString() != string.Empty && iLocationID != null)
                {
                    if (BusinessClass.CheckReferenceByLocation(iLocationID) != 0)
                    {
                        CloseWaitScreen();
                        MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0082", dr["LocationCode"].ToString()));
                        return;
                    }
                }
                gdvLocation.DeleteSelectedRows();
            }
            catch (Exception ex)
            {
                CloseWaitScreen();
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
            finally
            {
                CloseWaitScreen();
            }
        }
         
        private void zoneControlLocationDesigner_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (zoneControlLocationDesigner.ZoneID != null)
                {
                    SelectButton.Appearance.BackColor = ColorTranslator.FromHtml(string.Format("#{0}", zoneControlLocationDesigner.ZoneColor));   
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }
        #endregion

        #region Location Graphic
        private void timerFlashingButton_Tick(object sender, EventArgs e)
        {
            if (SelectButton != null)
            {
                LocationGraphic item = SelectButton.Tag as LocationGraphic;
                LabelControl label = item.LabelDetail;
                if (label != null)
                {
                    label.Appearance.ForeColor = Color.Red;
                }

                if (SelectButton.Appearance.ForeColor == Color.Black)
                {
                    SelectButton.Appearance.ForeColor = Color.White;
                }
                else
                {
                    SelectButton.Appearance.ForeColor = Color.Black;
                }
            }
            else
            {
                timerFlashingButton.Enabled = false;
            }
        }

        private void Button_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                //ไม่ให้ move ถ้าไม่ได้อยู่ใน mode edit
                if (ScreenMode != Common.eScreenMode.Edit)
                {
                    return;
                }

                SimpleButton button = (sender as SimpleButton);
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    Point RealPoint = pnDrawing.PointToClient(new Point(Cursor.Position.X - ButtonMousePoint.X, Cursor.Position.Y - ButtonMousePoint.Y));

                    LocationGraphic item = button.Tag as LocationGraphic;
                    LabelControl label = item.LabelDetail;
                    pnDrawing.Controls.SetChildIndex(button, 0);
                    pnDrawing.Controls.SetChildIndex(label, 1);

                    button.Location = RealPoint;
                    SetLabel(button);

                    SetButtonPointXToTextbox(button.Location.X - pnDrawing.AutoScrollPosition.X < 0 ? MarginX : button.Location.X - pnDrawing.AutoScrollPosition.X);
                    SetButtonPointXToTextbox(button.Location.Y - pnDrawing.AutoScrollPosition.Y < 0 ? MarginY : button.Location.Y - pnDrawing.AutoScrollPosition.Y);

                    item.DataState = item.DataState == "UNCHANGE" ? "CHANGE" : item.DataState;
                    button.Tag = item;
                }
                else ButtonMousePoint = e.Location;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void Button_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                //ไม่ให้ move ถ้าไม่ได้อยู่ใน mode edit
                if (ScreenMode != Common.eScreenMode.Edit)
                {
                    return;
                }

                AdjustPanelDrawing();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            try
            {   
                if (dtLocationInformation.GetChanges() != null && dtLocationInformation.GetChanges().Rows.Count > 0)
                {
                    if (MessageDialog.ShowConfirmationMsg(this, Rubix.Screen.Common.GetMessage("I0268")) == DialogButton.Yes)
                    {
                        dtLocationInformation.RejectChanges();
                    }
                    else
                    {
                        return;
                    }
                }

                if (SelectButton != null && SelectButton.Text == "Location Code")
                {
                    return;
                }

                ShowWaitScreen();
                errorProvider.ClearErrors();
                _FocusControl = (sender as System.Windows.Forms.Control);
                if (_FocusControl.GetType() == typeof(SimpleButton))
                {
                    //เปลี่ยนสี่ตัวอักษรปุ่ม กับ babel เดิมกลับก่อน
                    ClearSelectionButton();

                    SimpleButton button = (sender as SimpleButton);
                    SelectButton = button;
                    timerFlashingButton.Enabled = true;

                    if (this.ScreenMode == Common.eScreenMode.Edit)
                    {
                        ControlUtil.HiddenControl(false, btnCreateNewLocation, btnEditLocation, btnDeleteLocation);
                        ControlUtil.EnableControl(true, btnCreateNewLocation, btnEditLocation, btnDeleteLocation);
                        ControlUtil.EnableControl(false, btnApplyChanging, btnCancelChageLocation);
                        gdcDelete.Visible = false;
                        gdvLocation.OptionsBehavior.Editable = false;
                    }

                    LoadButtonDetail();

                    //if (this.ScreenMode == Common.eScreenMode.Edit)
                    //{
                    //    pnDrawing.Controls.SetChildIndex(button, 0);
                    //    pnDrawing.Controls.SetChildIndex((_FocusControl.Tag as LocationGraphic).LabelDetail, 1);
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
            finally
            {
                CloseWaitScreen();
            }
        }

        private void Button_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                SelectButton.Focus();
                Point RealPoint = new Point(-100, -100);
                SimpleButton button = SelectButton;
                if (e.Modifiers == Keys.Shift)
                {
                    if (e.KeyCode == Keys.Left)
                    {
                        txtWidth.EditValue = Convert.ToInt32(txtWidth.EditValue) - 1;
                    }
                    else if (e.KeyCode == Keys.Right)
                    {
                        txtWidth.EditValue = Convert.ToInt32(txtWidth.EditValue) + 1;
                    }
                    else if (e.KeyCode == Keys.Up)
                    {
                        txtHeight.EditValue = Convert.ToInt32(txtHeight.EditValue) - 1;
                    }
                    else if (e.KeyCode == Keys.Down)
                    {
                        txtHeight.EditValue = Convert.ToInt32(txtHeight.EditValue) + 1;
                    }
                }
                else
                {
                    if (e.KeyCode == Keys.Left)
                    {
                        RealPoint = new Point(button.Location.X - NoPixelPerMM, button.Location.Y);
                    }
                    else if (e.KeyCode == Keys.Right)
                    {
                        RealPoint = new Point(button.Location.X + NoPixelPerMM, button.Location.Y);
                    }
                    else if (e.KeyCode == Keys.Up)
                    {
                        RealPoint = new Point(button.Location.X, button.Location.Y - NoPixelPerMM);
                    }
                    else if (e.KeyCode == Keys.Down)
                    {
                        RealPoint = new Point(button.Location.X, button.Location.Y + NoPixelPerMM);
                    }

                    //===================================================
                    if (RealPoint.X != -100)
                    {

                        LocationGraphic item = button.Tag as LocationGraphic;
                        LabelControl label = item.LabelDetail;
                        pnDrawing.Controls.SetChildIndex(button, 0);
                        pnDrawing.Controls.SetChildIndex(label, 1);

                        button.Location = RealPoint;
                        SetLabel(button);

                        SetButtonPointXToTextbox(button.Location.X - pnDrawing.AutoScrollPosition.X < 0 ? MarginX : button.Location.X - pnDrawing.AutoScrollPosition.X);
                        SetButtonPointXToTextbox(button.Location.Y - pnDrawing.AutoScrollPosition.Y < 0 ? MarginY : button.Location.Y - pnDrawing.AutoScrollPosition.Y);

                        item.DataState = item.DataState == "UNCHANGE" ? "CHANGE" : item.DataState;
                        button.Tag = item;

                        AdjustPanelDrawing();
                    }
                }
                //===================================================
            }
            catch (Exception ex)
            {
                 MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }

        private void txtWidth_EditValueChanged(object sender, EventArgs e)
        {
            LocationLayoutChange();
        }

        private void txtHeight_EditValueChanged(object sender, EventArgs e)
        {
            LocationLayoutChange();
        }

        private void cboLabelPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            LocationLayoutChange();
        }
         
        private void btnPositionOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (SelectButton != null && !IsLoadDetail)
                {
                    int X = 0, Y = 0;

                    Int32.TryParse(txtPositionX.Text, out X);
                    Int32.TryParse(txtPositionY.Text, out Y);

                    if (X < 0)
                    {
                        X = SelectButton.Location.X;
                    }

                    if (Y <= 0)
                    {
                        Y = SelectButton.Location.Y;
                    }

                    SelectButton.Location = new Point(X * NoPixelPerMM, Y * NoPixelPerMM);
                    AdjustPanelDrawing();
                    SetLabel(SelectButton);
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }
        #endregion

        #region Location Initial Data
        private void cboAddBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboAddBy.Text != string.Empty)
                {
                    ControlUtil.EnableControl(true, gcLocationInitial.Controls);
                    if (cboAddBy.Text == "Location")
                    {
                        if (cboRackType.Text == "On Floor")
                        {
                            txtIntitialStack.Text = "";
                            txtIntitialEachStack.Text = "";
                            ControlUtil.EnableControl(true, txtIntitialStack, txtIntitialEachStack);
                        }
                        else
                        {
                            txtIntitialStack.Text = "1";
                            txtIntitialEachStack.Text = "1";
                            ControlUtil.EnableControl(false, txtIntitialStack, txtIntitialEachStack);
                        }
                    }
                    else if (cboAddBy.Text == "Rack")
                    {
                        txtIntitialStack.Text = "";
                        txtIntitialEachStack.Text = "1";
                        ControlUtil.EnableControl(false, txtIntitialEachStack);
                        ControlUtil.EnableControl(true, txtIntitialStack);
                    }
                    else
                    {
                        txtIntitialStack.Text = "";
                        txtIntitialEachStack.Text = "";
                        ControlUtil.EnableControl(true, txtIntitialStack, txtIntitialEachStack);
                    }

                    if (cboRackType.Text == "On Rack")
                    {
                        txtIntitialNoOfPallete.Text = "1";
                        ControlUtil.EnableControl(false, txtIntitialNoOfPallete);
                    }
                    else
                    {
                        ControlUtil.EnableControl(true, txtIntitialNoOfPallete);
                    }
                }
                else
                {
                    ControlUtil.EnableControl(false, gcLocationInitial.Controls);
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void txtIntitialRackNo_EditValueChanged(object sender, EventArgs e)
        {
            setInitialLocationCode();
        }

        private void txtIntitialStack_EditValueChanged(object sender, EventArgs e)
        {
            setInitialLocationCode();
            if (txtIntitialStack.Text != string.Empty && txtIntitialEachStack.Text != string.Empty)
            {
                txtIntitialMaxUnit.Text = (Convert.ToInt32(txtIntitialStack.Text) * Convert.ToInt32(txtIntitialEachStack.Text)).ToString();
            }
        }

        private void txtIntitialEachStack_EditValueChanged(object sender, EventArgs e)
        {
            setInitialLocationCode();
            if (txtIntitialStack.Text != string.Empty && txtIntitialEachStack.Text != string.Empty)
            {
                txtIntitialMaxUnit.Text = (Convert.ToInt32(txtIntitialStack.Text) * Convert.ToInt32(txtIntitialEachStack.Text)).ToString();
            }
        }
         
        private void btnInitialOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateLocationInitialData())
                {
                    dtLocationInformation.Rows.Clear();
                    ShowWaitScreen();
                    if (cboRackType.Text == "On Floor")
                    {
                        if (!CheckExistLocation(txtIntitialLocationCodeFrom.Text, zoneControlLocationDesigner.ZoneID))
                        {
                            MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0069", txtIntitialLocationCodeFrom.Text));
                            return;
                        }                        
                        DataRow dr = dtLocationInformation.NewRow();
                        dr["LocationCode"] = txtIntitialLocationCodeFrom.Text;
                        dr["OldLocationCode"] = dr["LocationCode"];
                        dr["LocationName"] = txtIntitialLocationName.Text;
                        dr["RackNo"] = txtIntitialRackNo.Text;
                        dr["Level"] = DBNull.Value;
                        if (itemConditionControl.ProductConditionID != null)
                        {
                            dr["ProductConditionID"] = itemConditionControl.ProductConditionID;
                        }                        
                        dr["ProductConditionCode"] = "";
                        dr["ProductConditionName"] = "";
                        dr["MaxM3"] = (txtIntitialMaxM3.EditValue == null ? DBNull.Value : txtIntitialMaxM3.EditValue);
                        dr["MaxM2"] = (txtIntitialMaxM2.EditValue == null ? DBNull.Value : txtIntitialMaxM2.EditValue);
                        dr["MaxCapacity"] = txtIntitialMaxCapacity.EditValue;
                        dr["NoOfPallet"] = (txtIntitialNoOfPallete.EditValue == null ? DBNull.Value : txtIntitialNoOfPallete.EditValue);
                        dr["Stack"] = txtIntitialStack.EditValue;
                        dr["EachStack"] = txtIntitialEachStack.EditValue;
                        dr["MaxUnit"] = txtIntitialMaxUnit.EditValue;
                        dr["Remark"] = memoRemark.Text;
                        dr["Delete"] = DeletePicture;
                        dtLocationInformation.Rows.Add(dr);
                    }
                    else
                    {
                        string strLocationCode = string.Empty;
                        string strRackNoPrefix = txtIntitialRackNo.Text.Substring(0, 1);
                        int iRackNo = Convert.ToInt32(txtIntitialRackNo.Text.Substring(1, 2));
                        int iStack = Convert.ToInt32(txtIntitialStack.Text);
                        int iEachStack = Convert.ToInt32(txtIntitialEachStack.Text);

                        for (int i = 1; i <= iStack; i++)
                        {
                            for (int j = iRackNo; j < iRackNo + iEachStack; j++)
                            {
                                strLocationCode = string.Format("{0}-{1}{2}-{3}", zoneControlLocationDesigner.ZoneCode, strRackNoPrefix, j.ToString().PadLeft(2, '0'), i.ToString().PadLeft(2, '0'));

                                if (!CheckExistLocation(strLocationCode, zoneControlLocationDesigner.ZoneID))
                                {
                                    CloseWaitScreen();
                                    MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0069", strLocationCode));
                                    return;
                                }

                                DataRow dr = dtLocationInformation.NewRow();
                                dr["LocationCode"] = string.Format("{0}-{1}{2}-{3}", zoneControlLocationDesigner.ZoneCode, strRackNoPrefix, j.ToString().PadLeft(2, '0'), i.ToString().PadLeft(2, '0'));
                                dr["OldLocationCode"] = dr["LocationCode"];
                                dr["LocationName"] = txtIntitialLocationName.Text;
                                dr["RackNo"] = string.Format("{0}{1}", strRackNoPrefix, j.ToString().PadLeft(2, '0'));
                                dr["Level"] = i.ToString().PadLeft(2, '0');
                                if (itemConditionControl.ProductConditionID != null)
                                {
                                    dr["ProductConditionID"] = itemConditionControl.ProductConditionID;
                                }
                                dr["ProductConditionCode"] = "";
                                dr["ProductConditionName"] = "";
                                dr["MaxM3"] = (txtIntitialMaxM3.EditValue == null ? DBNull.Value : txtIntitialMaxM3.EditValue);
                                dr["MaxM2"] = (txtIntitialMaxM2.EditValue == null ? DBNull.Value : txtIntitialMaxM2.EditValue);
                                dr["MaxCapacity"] = txtIntitialMaxCapacity.EditValue;
                                dr["NoOfPallet"] = 1;
                                dr["Stack"] = 1;
                                dr["EachStack"] = 1;
                                dr["MaxUnit"] = 1;
                                dr["Remark"] = memoRemark.Text;
                                dr["Delete"] = DeletePicture;
                                dtLocationInformation.Rows.Add(dr);
                            }
                        }
                    }
                    gcLocationInitial.Visible = false;
                    grdLocation.DataSource = dtLocationInformation;
                    ControlUtil.EnableControl(true, btnApplyChanging, btnCancelChageLocation);
                }
            }
            catch (Exception ex)
            {
                CloseWaitScreen();
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
            finally
            {
                CloseWaitScreen();
            }
        }

        private void btnInitialCancel_Click(object sender, EventArgs e)
        {
            ControlUtil.ClearControlData(gcLocationInitial.Controls);
            ControlUtil.HiddenControl(true, gcLocationInitial);
            if (gdvLocation.RowCount > 0)
            {
                ControlUtil.EnableControl(false, zoneControlLocationDesigner, cboLocationType, cboRackType);
            }
            else
            {
                ControlUtil.EnableControl(true, zoneControlLocationDesigner, cboLocationType, cboRackType);
            }
            ControlUtil.EnableControl(true, btnApplyChanging, btnCancelChageLocation);
        }
        #endregion

        #region Location Detail View
        private void btnLocatinLabelSearch_Click(object sender, EventArgs e)
        {
            try
            {
                ShowWaitScreen();
                grdSearchResult.DataSource = BusinessClass.SearchLocationLabel(warehouseControlLocationLabel.WarehouseID, zoneControlLocationLabel.ZoneID, txtRackNoLocationLabel.Text.Trim(), txtLocationCodeLocationLabel.Text.Trim(), txtLocationNameLocationLabel.Text.Trim());
                if (gdvSearchResult.RowCount <= 0)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0014"));
                }
                base.GridViewOnChangeLanguage(grdSearchResult);
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
            finally
            {
                CloseWaitScreen();
            }
        }

        private void btnLocationLabelClear_Click(object sender, EventArgs e)
        {
            try
            {
                ClearLocationLabel();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            SetSelectColumn(true);
        }

        private void btnUnselectAll_Click(object sender, EventArgs e)
        {
            SetSelectColumn(false);
        }

        private void btnPrintSmallLabel_Click(object sender, EventArgs e)
        {
            try
            {
                if (true == gdvSearchResult.IsEmpty)
                {
                    return;
                }
                ShowWaitScreen();
                List<sp_XMSS170_Location_SearchAll_Result> selectedList = GenerateReportSource();
                if (selectedList.Count != 0)
                {
                    XtraReport rpt = null;

                    Rubix.Screen.Report.rptRPT030_QRLocationSmallLabel report = new Rubix.Screen.Report.rptRPT030_QRLocationSmallLabel(BusinessClassReport.GetReportDefaultParams("RPT033"));

                    report.HasISO = false;
                    report.DataSource = selectedList;
                    rpt = report;
                    if (rpt != null)
                    {
                        ReportUtil.ShowPreview(rpt);
                    }
                    else
                    {
                        CloseWaitScreen();
                        MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0170"));
                    }
                }
                else
                {
                    CloseWaitScreen();
                    MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0011"));
                }
            }
            catch (Exception ex)
            {
                CloseWaitScreen();
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
            finally
            {
                CloseWaitScreen();
            }
        }

        private void btnPrintLargeLabel_Click(object sender, EventArgs e)
        {
            try
            {
                if (true == gdvSearchResult.IsEmpty)
                {
                    return;
                }
                ShowWaitScreen();
                List<sp_XMSS170_Location_SearchAll_Result> selectedList = GenerateReportSource();
                if (selectedList.Count != 0)
                {
                    XtraReport rpt = null;
                    Rubix.Screen.Report.rptRPT030_QRLocatinoLargeLabel report = new Rubix.Screen.Report.rptRPT030_QRLocatinoLargeLabel(BusinessClassReport.GetReportDefaultParams("RPT033"));

                    report.HasISO = false;
                    report.DataSource = selectedList;
                    rpt = report;
                    if (rpt != null)
                    {
                        ReportUtil.ShowPreview(rpt);
                    }
                    else
                    {
                        CloseWaitScreen();
                        MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0170"));
                    }
                }
                else
                {
                    CloseWaitScreen();
                    MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0011"));
                }
            }
            catch (Exception ex)
            {
                CloseWaitScreen();
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
            finally
            {
                CloseWaitScreen();
            }
        }

        private void warehouseControlLocationLabel_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                zoneControlLocationLabel.OwnerID = null;
                zoneControlLocationLabel.WarehouseID = warehouseControlLocationLabel.WarehouseID;
                zoneControlLocationLabel.DataLoading();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        } 
        #endregion
        #endregion
         
        #region Location Graphic
        private void CreateWarehouseLayout(LocationGraphic tag)
        {     
            Point point = new Point(20, 30);
            Size size = new Size(tag.LayoutSizeWidthX * NoPixelPerMM, tag.LayoutSizeHeightY * NoPixelPerMM);

            LabelControl label = NewLabel;
            SimpleButton button = NewButton;            
                        
            button.Location = point;            
            button.Text = tag.LocationCode;
            button.Size = size;
            button.Appearance.BackColor = ColorTranslator.FromHtml("#FFFFFF");

            ButtonID++;
            tag.ButtonID = ButtonID;
            tag.LabelDetail = label;
            button.Tag = tag;

            pnDrawing.Controls.Add(button);
            pnDrawing.Controls.Add(label);

            SetLabel(button);

            pnDrawing.Controls.SetChildIndex(button, 0);
            pnDrawing.Controls.SetChildIndex(label, 1);

            SetButtonPointXToTextbox(point.X);
            SetButtonPointYToTextbox(point.Y);

            //เปลี่ยนสี่ตัวอักษรปุ่ม กับ babel เดิมกลับก่อน
            ClearSelectionButton();

            //เก็บปุ่มใหม่ไว้
            SelectButton = button;
            _FocusControl = button;

            timerFlashingButton.Enabled = true;
        }

        protected void SetLabel(SimpleButton button)
        {
            LocationGraphic item = button.Tag as LocationGraphic;
            LabelControl label = item.LabelDetail;
            Point CaptionLocation;
            label.Text = item.LocationName;
            label.Size = label.CalcBestSize();

            if (item.CaptionPosition == "T")
            {
                CaptionLocation = new Point(button.Location.X + ((button.Size.Width - label.Size.Width) / 2)
                                            , button.Location.Y - label.Size.Height - item.CaptionOffset);
            }
            else if (item.CaptionPosition == "B")
            {
                CaptionLocation = new Point(button.Location.X + ((button.Size.Width - label.Size.Width) / 2)
                                            , button.Location.Y + button.Size.Height + item.CaptionOffset);
            }
            else if (item.CaptionPosition == "R")
            {
                CaptionLocation = new Point(button.Location.X + button.Size.Width + item.CaptionOffset
                                            , button.Location.Y + ((button.Size.Height - label.Size.Height) / 2));
            }
            else
            {
                CaptionLocation = new Point(button.Location.X - label.Size.Width - item.CaptionOffset
                                            , button.Location.Y + ((button.Size.Height - label.Size.Height) / 2));
            }

            label.Location = CaptionLocation;
        }

        protected void AdjustPanelDrawing()
        {
            SimpleButton button;
            LabelControl label;
            foreach (System.Windows.Forms.Control control in pnDrawing.Controls)
            {
                if (control.GetType() == typeof(SimpleButton))
                {
                    button = control as SimpleButton;
                    LocationGraphic tag = button.Tag as LocationGraphic;
                    label = tag.LabelDetail;

                    if (label.Location.X < PointStart.X
                        || button.Location.X < PointStart.X)
                    {
                        if (label.Location.X < button.Location.X)
                        {
                            button.Location = new Point(button.Location.X + PointStart.X - label.Location.X + MarginX, button.Location.Y);
                            label.Location = new Point(PointStart.X + MarginX, label.Location.Y);
                        }
                        else
                        {
                            label.Location = new Point(label.Location.X + PointStart.X - button.Location.X + MarginX, label.Location.Y);
                            button.Location = new Point(PointStart.X + MarginX, button.Location.Y);
                        }
                    }

                    if (label.Location.Y < PointStart.Y
                        || button.Location.Y < PointStart.Y)
                    {
                        if (label.Location.Y < button.Location.Y)
                        {
                            button.Location = new Point(button.Location.X, button.Location.Y + PointStart.Y - label.Location.Y + MarginY);
                            label.Location = new Point(label.Location.X, PointStart.Y + MarginY);
                        }
                        else
                        {
                            label.Location = new Point(label.Location.X, label.Location.Y + PointStart.Y - button.Location.Y + MarginY);
                            button.Location = new Point(button.Location.X, PointStart.Y + MarginY);
                        }
                    }

                    if (SelectButton != null && button == SelectButton)
                    {
                        SetButtonPointXToTextbox(button.Location.X - pnDrawing.AutoScrollPosition.X);
                        SetButtonPointYToTextbox(button.Location.Y - pnDrawing.AutoScrollPosition.Y);
                    }
                }
            }

            if (SelectButton != null)
            {
                label = (SelectButton.Tag as LocationGraphic).LabelDetail;
                int minX = label.Location.X - PointStart.X < SelectButton.Location.X - PointStart.X ? label.Location.X - PointStart.X : SelectButton.Location.X - PointStart.X;
                int minY = label.Location.Y - PointStart.Y < SelectButton.Location.Y - PointStart.Y ? label.Location.Y - PointStart.Y : SelectButton.Location.Y - PointStart.Y;
                int maxX = label.Location.X + label.Size.Width - PointStart.X > SelectButton.Location.X + SelectButton.Size.Width - PointStart.X ? label.Location.X + label.Size.Width - PointStart.X : SelectButton.Location.X + SelectButton.Size.Width - PointStart.X;
                int maxY = label.Location.Y + label.Size.Height - PointStart.Y > SelectButton.Location.Y + SelectButton.Size.Height - PointStart.Y ? label.Location.Y + label.Size.Height - PointStart.Y : SelectButton.Location.Y + SelectButton.Size.Height - PointStart.Y;
                if (minX < 0 || minY < 0)
                {
                    pnDrawing.AutoScrollPosition = new Point(minX, minY);
                }
                if (maxX > pnDrawing.Size.Width || maxY > pnDrawing.Size.Height)
                {
                    pnDrawing.AutoScrollPosition = new Point(maxX, maxY);
                }
            }
        }

        private void ClearSelectionButton(bool ClearSelectButton = true)
        {
            if (ClearSelectButton)
            {
                if (SelectButton != null)
                {
                    timerFlashingButton.Enabled = false;
                    ResetButtonLabelColor();
                    SelectButton = null;
                }
            }
        }

        private void LoadButtonDetail()
        {
            if (SelectButton != null)
            {
                IsLoadDetail = true;
                LocationGraphic Tag = SelectButton.Tag as LocationGraphic;
                zoneControlLocationDesigner.ZoneID = Tag.ZoneID;
                cboLocationType.EditValue = Tag.LocationTypeID;
                cboRackType.EditValue = Tag.Type;
                
                dtLocationInformation = Tag.LocationInformation.Copy();
                grdLocation.DataSource = dtLocationInformation;

                cboLabelPosition.EditValue = BusinessClass.GetFullPositionBinding(Tag.CaptionPosition);
                txtWidth.EditValue = Tag.LayoutSizeWidthX;
                txtHeight.EditValue = Tag.LayoutSizeHeightY;
                SetButtonPointXToTextbox(_FocusControl.Location.X - pnDrawing.AutoScrollPosition.X);
                SetButtonPointYToTextbox(_FocusControl.Location.Y - pnDrawing.AutoScrollPosition.Y);
                IsLoadDetail = false;
            }
            else
            {
                ControlUtil.ClearControlData(gcAllLocationInformation.Controls);
                grdLocation.DataSource = null;
                dtLocationInformation.Rows.Clear();
            }
        }

        private void ResetButtonLabelColor()
        {
            if (SelectButton != null)
            {
                //เปลี่ยนสี่ตัวอักษรปุ่มเดิมกลับก่อน
                SelectButton.Appearance.ForeColor = Color.Black;
                LocationGraphic item = SelectButton.Tag as LocationGraphic;
                LabelControl labelSelect = item.LabelDetail;
                if (labelSelect != null)
                {
                    labelSelect.Appearance.ForeColor = Color.Black;
                }
            }
        }

        private void SetButtonPointXToTextbox(int PointX)
        {
            txtPositionX.EditValue = Math.Ceiling(Convert.ToDecimal(PointX / NoPixelPerMM));
        }

        private void SetButtonPointYToTextbox(int PointY)
        {
            txtPositionY.EditValue = Math.Ceiling(Convert.ToDecimal(PointY / NoPixelPerMM));
        }

        protected bool GetLocationSaveList(string RemoveDataState = "UNCHANGE", string GetDataMode = "CHECK" )
        {
            bool bIsData = false;
            LocationSaveList.Clear();
            foreach (System.Windows.Forms.Control control in pnDrawing.Controls)
            {
                if (control.GetType() == typeof(SimpleButton))
                {
                    SimpleButton button = control as SimpleButton;
                    LocationGraphic Tag = ((control as SimpleButton).Tag as LocationGraphic);
                    if (Tag.DataState == RemoveDataState) continue;
                    Tag.LayoutLocationX = Convert.ToInt32(button.Location.X - pnDrawing.AutoScrollPosition.X);
                    Tag.LayoutLocationY = Convert.ToInt32(button.Location.Y - pnDrawing.AutoScrollPosition.Y);
                    if (GetDataMode != "CHECK")
                    {
                        Tag.LabelDetail = null;
                    }
                    LocationSaveList.Add(Tag);
                    bIsData = true;
                }
            }
            return bIsData;
        }

        private void ClearWareHousePanel()
        {
            SelectButton = null;
            _FocusControl = null;
            timerFlashingButton.Enabled = false;
            ControlUtil.ClearControlData(gcAllLocationInformation.Controls);
            pnDrawing.SuspendLayout();
            int controlCnt = pnDrawing.Controls.Count;
            for (int i = 0; i < controlCnt; i++)
            {
                System.Windows.Forms.Control ctrl = pnDrawing.Controls[0];
                pnDrawing.Controls.RemoveAt(0);
                ctrl.Dispose();
                ctrl = null;
            }
            pnDrawing.ResumeLayout();
            GC.Collect();
        }

        private void LoadWarehouseAndDrawing(Common.eScreenMode mScreenMode = Common.eScreenMode.View)
        {
            ClearWareHousePanel();

            try
            {
                pnDrawing.SuspendLayout();

                List<LocationGraphic> list = BusinessClass.SearchLocationDesigner(Convert.ToInt32(warehouseControlLocationDesigner.WarehouseID), DeletePicture);
                if ((list == null || list.Count <= 0) && mScreenMode != Common.eScreenMode.Edit)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0014"));
                    return;
                }

                foreach (LocationGraphic item in list)
                {
                    if (item.LayoutLocationX == null
                        || item.LayoutLocationY == null
                        || item.LayoutSizeWidthX == null
                        || item.LayoutSizeHeightY == null
                        || item.CaptionOffset == null
                        || item.CaptionPosition == null) continue;

                    SimpleButton button = new SimpleButton();
                    Point PointLocation = new Point(item.LayoutLocationX, item.LayoutLocationY);
                    button.Location = PointLocation;
                    button.AllowDrop = true;
                    button.Text = item.LocationCode;
                    button.Size = new Size(item.LayoutSizeWidthX * NoPixelPerMM, item.LayoutSizeHeightY * NoPixelPerMM);
                    button.Tag = item;
                    button.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
                    button.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                    button.Appearance.ForeColor = Color.Black;
                    button.Appearance.BackColor = ColorTranslator.FromHtml(string.Format("#{0}", item.ZoneColor));   

                    Font _Font = new System.Drawing.Font(button.Appearance.Font.FontFamily, FONT_SIZE_BUTTON);
                    button.Appearance.Font = _Font;
                    button.Click += Button_Click;

                    if (this.ScreenMode == Common.eScreenMode.Edit)
                    {
                        button.MouseMove += Button_MouseMove;
                        button.MouseUp += Button_MouseUp;
                        button.KeyUp += Button_KeyUp;
                    }

                    LabelControl label = new LabelControl();
                    label.AllowDrop = true;

                    _Font = new System.Drawing.Font(label.Appearance.Font.FontFamily, FONT_SIZE_LABEL);
                    label.Appearance.Font = _Font;
                    label.Appearance.BackColor = Color.Transparent;
                    label.Appearance.ForeColor = Color.Black;

                    label.AutoSizeMode = LabelAutoSizeMode.Default;

                    item.LabelDetail = label;
                    SetLabel(button);
                    pnDrawing.Controls.Add(button);
                    pnDrawing.Controls.Add(label);
                }
                AdjustPanelDrawing();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                pnDrawing.ResumeLayout();
            }
        }

        private void LocationLayoutChange()
        {
            try
            {
                if (SelectButton != null && !IsLoadDetail)
                {
                    LocationGraphic property = SelectButton.Tag as LocationGraphic;

                    int Widht = 0, Height = 0;
                    Int32.TryParse(txtWidth.Text, out Widht);
                    Int32.TryParse(txtHeight.Text, out Height);
                    if (Widht <= 0)
                    {
                        Widht = SelectButton.Size.Width / NoPixelPerMM;
                    }

                    if (Height <= 0)
                    {
                        Height = SelectButton.Size.Height / NoPixelPerMM;
                    }

                    if (cboLabelPosition.EditValue == null)
                    {
                        cboLabelPosition.EditValue = BusinessClass.GetFullPositionBinding(property.CaptionPosition);
                    }

                    SelectButton.Size = new Size(Widht * NoPixelPerMM, Height * NoPixelPerMM);
                    property.CaptionPosition = cboLabelPosition.EditValue.ToString().Substring(0, 1);
                    property.LayoutSizeWidthX = Convert.ToInt32(txtWidth.EditValue);
                    property.LayoutSizeHeightY = Convert.ToInt32(txtHeight.EditValue);
                    property.CaptionOffset = BusinessClass.GetCaptionOffSet(property.CaptionPosition);
                    property.DataState = property.DataState == "UNCHANGE" ? "CHANGE" : property.DataState;
                    property.LocationInformation = dtLocationInformation.Copy();

                    SelectButton.Tag = property;
                    SelectButton.Text = property.LocationCode;

                    SetLabel(SelectButton);
                    AdjustPanelDrawing();
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }
         
        private void SetReadOnlyLocationSettingLayout(bool IsReadOnly)
        {
            cboLabelPosition.Properties.ReadOnly = IsReadOnly;
            txtWidth.Properties.ReadOnly = IsReadOnly;
            txtHeight.Properties.ReadOnly = IsReadOnly;
            txtPositionX.Properties.ReadOnly = IsReadOnly;
            txtPositionY.Properties.ReadOnly = IsReadOnly;
            btnPositionOK.Enabled = !IsReadOnly;
        }
        #endregion

        #region Generic Function
        private void InitialScreen()
        {
            //Disable all right control
            ControlUtil.EnableControl(false, gcAllLocationInformation.Controls);
            ControlUtil.HiddenControl(true, m_toolBarExport);
            ControlUtil.HiddenControl(true, m_toolBarPaintStyls, m_toolBarThemeStyls);

            warehouseControlLocationDesigner.OwnerID = null;
            warehouseControlLocationDesigner.DataLoading();
            zoneControlLocationDesigner.WarehouseID = Common.GetDefaultWarehouseID();
            zoneControlLocationDesigner.DataLoading();
               
            dtLocationInformation = InitialLocationInformationGrid();
            grdLocation.DataSource = dtLocationInformation;

            warehouseControlLocationDesigner.ErrorText = Common.GetMessage("I0045");
            warehouseControlLocationDesigner.RequireField = true;

            CSI.Business.Common.ProductCondition cm = new CSI.Business.Common.ProductCondition();
            repItemCondition.DataSource = cm.DataLoading();
            repItemCondition.DisplayMember = "ProductConditionCode";
            repItemCondition.ValueMember = "ProductConditionID";

            gcLocationInitial.Visible = false;
            ControlUtil.HiddenControl(true, btnCreateNewLocation, btnEditLocation, btnDeleteLocation, btnApplyChanging, btnCancelChageLocation);
            gdcDelete.Visible = false;
            gdvLocation.OptionsBehavior.Editable = false;
        }
         
         private void LoadLocationType()
        {
            cboLocationType.Properties.DataSource = BusinessClass.LoadLocationType();
            cboLocationType.Properties.DisplayMember = "LocationTypeName";
            cboLocationType.Properties.ValueMember = "LocationTypeID";
            cboLocationType.EditValue = null;
        }

        private DataTable InitialLocationInformationGrid()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("LocationID", typeof(int));
            dt.Columns.Add("LocationCode", typeof(string));
            dt.Columns.Add("OldLocationCode", typeof(string));
            dt.Columns.Add("LocationName", typeof(string));
            dt.Columns.Add("RackNo", typeof(string));
            dt.Columns.Add("Level", typeof(string));
            dt.Columns.Add("ProductConditionID", typeof(int));
            dt.Columns.Add("ProductConditionCode", typeof(string));
            dt.Columns.Add("ProductConditionName", typeof(string));
            dt.Columns.Add("MaxM3", typeof(decimal));
            dt.Columns.Add("MaxM2", typeof(decimal));
            dt.Columns.Add("MaxCapacity", typeof(decimal));
            dt.Columns.Add("NoOfPallet", typeof(int));
            dt.Columns.Add("Stack", typeof(int));
            dt.Columns.Add("EachStack", typeof(int));
            dt.Columns.Add("MaxUnit", typeof(int));
            dt.Columns.Add("Remark", typeof(string));
            dt.Columns.Add("Delete", typeof(byte[]));
            return dt;
        }

        private void setInitialLocationCode()
        {
            string strStartLocationCode = string.Empty;
            string strEndLocationCode = string.Empty;
            string strRackNoPrefix = string.Empty;
            int iRackNo = 0;
            int iEachStack = 0;
            string strEndRackNo = string.Empty;

            if (txtIntitialRackNo.Text.Trim() != string.Empty && txtIntitialStack.Text != string.Empty && txtIntitialEachStack.Text != string.Empty && ValidateRackNoFormat(txtIntitialRackNo.Text.Trim()))
            {
                if (cboAddBy.Text == "Location")
                {
                    strStartLocationCode = string.Format("{0}-{1}", zoneControlLocationDesigner.ZoneCode, txtIntitialRackNo.Text);
                    strEndLocationCode = strStartLocationCode;
                    strEndRackNo = txtIntitialRackNo.Text;
                }
                else
                {
                    if (txtIntitialRackNo.Text.Length == 3)
                    {
                        strRackNoPrefix = txtIntitialRackNo.Text.Substring(0, 1);
                        iRackNo = Convert.ToInt32(txtIntitialRackNo.Text.Substring(1, 2));
                        iEachStack = Convert.ToInt32(txtIntitialEachStack.Text);
                        if (iRackNo + iEachStack > 99)
                        {
                            errorProvider.SetError(txtIntitialRackNo, Rubix.Screen.Common.GetMessage("I0098"));
                        }
                        else
                        {
                            strStartLocationCode = string.Format("{0}-{1}-01", zoneControlLocationDesigner.ZoneCode, txtIntitialRackNo.Text);
                            strEndLocationCode = string.Format("{0}-{1}{2}-{3}", zoneControlLocationDesigner.ZoneCode, strRackNoPrefix, (iRackNo + iEachStack - 1).ToString().PadLeft(2, '0'), txtIntitialStack.Text.PadLeft(2, '0'));
                            strEndRackNo = string.Format("{0}{1}", strRackNoPrefix, (iRackNo + iEachStack - 1).ToString().PadLeft(2, '0'));
                        }
                    }
                }
            }

            txtIntitialLocationCodeFrom.Text = strStartLocationCode;
            txtIntitialLocationCodeTo.Text = strEndLocationCode;
            txtIntitialRackNoTo.Text = strEndRackNo;
        }

        private bool ValidateFirstData()
        {
            Boolean errFlag = true;
            errorProvider.ClearErrors();

            zoneControlLocationDesigner.RequireField = true;
            zoneControlLocationDesigner.ErrorText = Rubix.Screen.Common.GetMessage("I0055");
            if (!zoneControlLocationDesigner.ValidateControl())
            {
                errFlag = false;
            }

            if (cboLocationType.EditValue == null)
            {
                errorProvider.SetError(cboLocationType, Common.GetMessage("I0297"));
                errFlag = false;
            }

            if (cboRackType.EditValue == null)
            {
                errorProvider.SetError(cboRackType, Rubix.Screen.Common.GetMessage("I0350"));
                errFlag = false;
            }
            return errFlag;
        }

        private bool ValidateLocationInitialData()
        {
            Boolean errFlag = true;
            errorProvider.ClearErrors();

            if (txtIntitialLocationName.Text.Trim() == String.Empty)
            {
                errorProvider.SetError(txtIntitialLocationName, Rubix.Screen.Common.GetMessage("I0068"));
                errFlag = false;
            }
            
            if (string.IsNullOrWhiteSpace(txtIntitialRackNo.Text) || string.IsNullOrWhiteSpace(txtIntitialRackNoTo.Text))
            {
                errorProvider.SetError(txtIntitialRackNo, Rubix.Screen.Common.GetMessage("I0217", "Rack No."));
                errFlag = false;
            }

            if (!ValidateRackNoFormat(txtIntitialRackNo.Text))
            {
                errorProvider.SetError(txtIntitialRackNo, Rubix.Screen.Common.GetMessage("I0098"));
                errFlag = false;
            }
            
            if (!string.IsNullOrWhiteSpace(txtIntitialMaxM2.Text))
            {
                if (!DataUtil.IsValidDecimal(txtIntitialMaxM2.Text, 18, 5))
                {
                    errorProvider.SetError(txtIntitialMaxM2, Common.GetMessage("I0295"));
                    errFlag = false;
                }
            }
            if (!string.IsNullOrWhiteSpace(txtIntitialMaxM3.Text))
            {
                if (!DataUtil.IsValidDecimal(txtIntitialMaxM3.Text, 18, 5))
                {
                    errorProvider.SetError(txtIntitialMaxM3, Common.GetMessage("I0296"));
                    errFlag = false;
                }
            }

            if (txtIntitialMaxCapacity.Text.Trim() == string.Empty)
            {
                errorProvider.SetError(txtIntitialMaxCapacity, Rubix.Screen.Common.GetMessage("I0289"));
                errFlag = false;
            }

            if (txtIntitialStack.Text.Trim() == string.Empty || txtIntitialStack.Text.Trim() == "0")
            {
                errorProvider.SetError(txtIntitialStack, Rubix.Screen.Common.GetMessage("I0349"));
                errFlag = false;
            }

            if (txtIntitialEachStack.Text.Trim() == string.Empty || txtIntitialEachStack.Text.Trim() == "0")
            {
                errorProvider.SetError(txtIntitialEachStack, Rubix.Screen.Common.GetMessage("I0349"));
                errFlag = false;
            }
            
            return errFlag;
        }

        private bool ValidateOKLocationLayout()
        {
            Boolean errFlag = true;
            errorProvider.ClearErrors();
             
            if (cboLabelPosition.EditValue == null)
            {
                errorProvider.SetError(cboLabelPosition, Rubix.Screen.Common.GetMessage("I0351"));
                errFlag = false;
            }

            if (txtWidth.Text.Trim() == string.Empty)
            {
                errorProvider.SetError(txtWidth, Rubix.Screen.Common.GetMessage("I0351"));
                errFlag = false;
            }

            if (txtHeight.Text.Trim() == string.Empty)
            {
                errorProvider.SetError(txtHeight, Rubix.Screen.Common.GetMessage("I0351"));
                errFlag = false;
            }

            if (gdvLocation.RowCount <= 0)
            {
                CloseWaitScreen();
                MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0193"));
                errFlag = false;
            }

            for (int i = 0; i < gdvLocation.RowCount; i ++ )
            {
                if (gdvLocation.GetRowCellValue(i, gdcLocationCode).ToString() == string.Empty)
                {
                    CloseWaitScreen();
                    MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0193"));
                    errFlag = false;
                    break;
                }
            }

            return errFlag;
        }

        private bool ValidateRackNoFormat(string RackNo)
        {
            string text = RackNo.Trim();
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^[A-Z]+[0-9]+$");
            bool match = regex.IsMatch(text);

            if (false == match)
            {                
                return false;
            }
            return true;
        }

        private bool ValidateExistingLocationCode()
        {
            bool errFlag = false;

            DataTable dt = grdLocation.DataSource as DataTable;
            foreach (DataRow dr in dt.Rows)
            {
                if (dr.RowState != DataRowState.Deleted)
                {
                    int? iLocationID = DataUtil.Convert<int>(dr["LocationID"]);
                    if (dr["OldLocationCode"].ToString() != dr["LocationCode"].ToString())
                    {
                        if (!CheckExistLocation(dr["LocationCode"].ToString(), zoneControlLocationDesigner.ZoneID))
                        {
                            CloseWaitScreen();
                            MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0069", dr["LocationCode"].ToString()));
                            return true;
                        }
                        else if (dr["OldLocationCode"].ToString() != string.Empty && iLocationID != null)
                        {
                            if (BusinessClass.CheckReferenceByLocation(iLocationID) != 0)
                            {
                                CloseWaitScreen();
                                MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0352", dr["OldLocationCode"].ToString(), dr["LocationCode"].ToString()));
                                return true;
                            }
                        }
                    }
                }
            }

            return errFlag;
        }

        private void ClearLocationLabel()
        {
            ControlUtil.ClearControlData(txtLocationCodeLocationLabel, txtLocationNameLocationLabel, txtRackNoLocationLabel);
            warehouseControlLocationLabel.ClearData();
            zoneControlLocationLabel.ClearData();
            grdSearchResult.DataSource = null;
            warehouseControlLocationLabel.OwnerID = null;
            warehouseControlLocationLabel.DataLoading();
            zoneControlLocationLabel.OwnerID = null;
            zoneControlLocationLabel.WarehouseID = null;
            zoneControlLocationLabel.DataLoading();
        }

        private void SetSelectColumn(bool select)
        {
            try
            {
                ShowWaitScreen();
                gdvSearchResult.ClearSorting();
                for (int rowIndex = 0; rowIndex < gdvSearchResult.RowCount; rowIndex++)
                {
                    gdvSearchResult.SetRowCellValue(rowIndex, gdvSearchResult.Columns[0], select);
                }
            }
            catch (Exception ex)
            {
                CloseWaitScreen();
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
            finally
            {
                CloseWaitScreen();
            }
        }

        private List<sp_XMSS170_Location_SearchAll_Result> GenerateReportSource()
        {
            gdvSearchResult.CloseEditor();
            gdvSearchResult.UpdateCurrentRow();

            List<sp_XMSS170_Location_SearchAll_Result> DataList = new List<sp_XMSS170_Location_SearchAll_Result>();
            DataTable dt = grdSearchResult.DataSource as DataTable;
            DataRow[] dr = dt.Select(" Select = 1");

            for (int i = 0; i < dr.Length; i++)
            {
                sp_XMSS170_Location_SearchAll_Result listDetail = new sp_XMSS170_Location_SearchAll_Result();
                listDetail.LocationID = Convert.ToInt32(dr[i]["LocationID"]);
                listDetail.LocationCode = dr[i]["LocationCode"].ToString();
                listDetail.LocationName = dr[i]["LocationName"].ToString();
                DataList.Add(listDetail);
            }
            return DataList;
        }

        private void SetEditTableColor()
        {
            if (ScreenMode == Common.eScreenMode.Edit)
            {
                gdcLocationCode.AppearanceCell.BackColor = Color.White;

                //สีเหลืองเสมอ
                gdcLocationName.AppearanceCell.BackColor = Color.Yellow;
                gdcRackNo.AppearanceCell.BackColor = Color.Yellow;
                gdcItemConditionCode.AppearanceCell.BackColor = Color.Yellow;
                gdcMaxM3.AppearanceCell.BackColor = Color.Yellow;
                gdcMaxM2.AppearanceCell.BackColor = Color.Yellow;
                gdcMaxCapacity.AppearanceCell.BackColor = Color.Yellow;
                gdcRemark.AppearanceCell.BackColor = Color.Yellow;

                if (cboRackType.Text == "On Floor")
                {
                    gdcLevel.AppearanceCell.BackColor = Color.White;
                    gdcStack.AppearanceCell.BackColor = Color.Yellow;
                    gdcEachStack.AppearanceCell.BackColor = Color.Yellow;
                    gdcNoOfPallet.AppearanceCell.BackColor = Color.Yellow;
                }
                else
                {
                    gdcLevel.AppearanceCell.BackColor = Color.Yellow;
                    gdcStack.AppearanceCell.BackColor = Color.White;
                    gdcEachStack.AppearanceCell.BackColor = Color.White;
                    gdcNoOfPallet.AppearanceCell.BackColor = Color.White;
                }

                gdcMaxUnit.AppearanceCell.BackColor = Color.White;
            }
            else
            {
                for (int i = 0; i < gdvLocation.Columns.Count; i++)
                {
                    gdvLocation.Columns[i].AppearanceCell.BackColor = Color.White;
                }
            }
        }

        private bool CheckExistLocation(string LocationCode, int? ZoneID)
        {
            LocationGraphic Tag = ((SelectButton as SimpleButton).Tag as LocationGraphic);
            DataRow[] dr;

            if (GetLocationSaveList("UNCHANGE", "CHECK"))
            {
                foreach (LocationGraphic lg in LocationSaveList)
                {
                    DataTable dt = lg.LocationInformation;
                    if (lg.ButtonID != Tag.ButtonID)
                    {
                        dr = dt.Select(string.Format(" LocationCode = '{0}'", LocationCode));

                        if (dr.Length >= 1)
                        {
                            return false;
                        }
                    }
                }
            }

            if (BusinessClass.CheckExistLocation(LocationCode, warehouseControlLocationDesigner.WarehouseID, ZoneID))
            {
                return false;
            }
            return true;
        }
        #endregion                             
    }
}