/*
 * 18 Jan 2013:
 * 1. expand excel export column size
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Design;
using DevExpress.XtraBars;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTreeList;
using DevExpress.XtraBars.Helpers;
using Rubix.Framework;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Localization;
using CSI.Business.Admin;
using System.Linq;
using CSI.Business.BusinessFactory.Common;
using CSI.Business.Common;
using Rubix.Screen.Form.Master.Dialog;
namespace Rubix.Screen
{
    public partial class FormBase : DevExpress.XtraEditors.XtraForm, IMultiLanguage
    {
        #region Member
        GridControl[] grdSearchResult = null;
        TreeList[] trlList = null;
        GridView gdvExport = null;
        bool _isNotSetScreenID = false;
        protected IdleValidator iv;
        private LastestDaily ld = null;
        bool canAdd, canEdit, canDelete, canExport, canConfirm, canImport, canPrint;
        #endregion

        #region Member Toolbar Control
        BarButtonItem[] _itemMenuAdd = null;
        BarButtonItem[] _itemMenuDelete = null;
        BarButtonItem[] _itemMenuEdit = null;
        BarButtonItem[] _itemMenuExport = null;
        BarButtonItem[] _itemMenuConfirm = null;
        BarButtonItem[] _itemMenuImport = null;
        BarButtonItem[] _itemMenuPrint = null;
        #endregion

        #region Contruction
        public FormBase()
        {
            InitializeComponent();
            InitGridTheme();            
            if (string.IsNullOrWhiteSpace(ScreenID))
            {
                if (this.GetType().Name.IndexOf("_") != -1 && this.GetType().Name.Length > 3) 
                    ScreenID = this.GetType().Name.Substring(3, this.GetType().Name.IndexOf("_") - 3);
            }
        }

        private void InitGridTheme()
        {
            string filePath;
            XAppearances gvScheme;
            try
            { 
                filePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.System) + "\\DevExpress.XtraGrid.Appearances.xml";
                gvScheme = new XAppearances(filePath);
            }
            catch (Exception)
            {                
                filePath = System.Environment.CurrentDirectory + "\\DevExpress.XtraGrid.Appearances.xml";
                gvScheme = new XAppearances(filePath);
            }
            
            foreach (String str in gvScheme.FormatNames)
            {
                repositoryItemComboBox1.Items.Add(str);
            }

            repositoryItemComboBox2.Items.Add("Default");
            repositoryItemComboBox2.Items.Add("Flat");
            repositoryItemComboBox2.Items.Add("WindowsXP");
            repositoryItemComboBox2.Items.Add("Style3D");
            repositoryItemComboBox2.Items.Add("UltraFlat");
            repositoryItemComboBox2.Items.Add("Office2003");
            repositoryItemComboBox2.Items.Add("MixedXP");
            repositoryItemComboBox2.Items.Add("Web");
            repositoryItemComboBox2.Items.Add("Skin");
          
        }
        #endregion

        #region Properties
        public GridControl[] GridControlSearchResult
        {
            get { return grdSearchResult; }
            set { grdSearchResult = value; }
        }

        public TreeList[] TreeListControl
        {
            get { return trlList; }
            set { trlList = value; }
        }

        public GridView GridExportExcel
        {
            get { return gdvExport; }
            set { gdvExport = value; }
        }
        
        public string ScreenID { get; set; }

        public bool IsNotSetScreenID { get { return _isNotSetScreenID; } }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsLock { get; set; }

        public Exception AUTError
        {
            get;
            set;
        }

        private LastestDaily LastestDailyBiz
        {
            get
            {
                if (ld == null)
                {
                    ld = new LastestDaily();
                }
                return ld;
            }
        }

        public bool CanAdd { get { return canAdd; } }
        public bool CanEdit { get { return canEdit; } }
        public bool CanDelete { get { return canDelete; } }
        public bool CanExport { get { return canExport; } }
        public bool CanConfirm { get { return canConfirm; } }
        public bool CanImport { get { return canImport; } }
        public bool CanPrint { get { return canPrint; } }
        #endregion

        #region Properties Toolbar Control
        public Bar m_toolBar { get { return bToolbar; } }
        public BarButtonItem m_toolBarView {get { return btnView; }}
        public BarButtonItem m_toolBarAdd { get { return btnAdd; } }
        public BarButtonItem m_toolBarEdit { get { return btnEdit; } }
        public BarButtonItem m_toolBarDelete { get { return btnDelete; } }
        public BarButtonItem m_toolBarSave { get { return btnSave; } }
        public BarButtonItem m_toolBarConfirm { get { return btnConfirm; } }
        public BarButtonItem m_toolBarCancel { get { return btnCancel; } }
        public BarButtonItem m_toolBarRefresh { get { return btnRefresh; } }
        public BarButtonItem m_toolBarPrint { get { return btnPrint; } }
        public BarButtonItem m_toolBarExport { get { return btnExport; } }
        public BarButtonItem m_toolBarBookStock { get { return btnBookStock; } }
        public BarButtonItem m_toolBarImport { get { return btnImport; } }

        public BarButtonItem q_toolBarView { get { return iView; } }
        public BarButtonItem q_toolBarAdd { get { return iAdd; } }
        public BarButtonItem q_toolBarEdit { get { return iEdit; } }
        public BarButtonItem q_toolBarDelete { get { return iDelete; } }
        public BarButtonItem q_toolBarExport { get { return iExport; } }
        public BarButtonItem q_toolBarCopy { get { return iCopy; } }

        public BarEditItem m_toolBarThemeStyls { get { return cboGridTheme; } }
        public BarEditItem m_toolBarPaintStyls { get { return cboPaintStyle; } }

        private BarButtonItem[] ItemMenuAdd { get { return _itemMenuAdd == null? new BarButtonItem[] { m_toolBarAdd, q_toolBarAdd }: _itemMenuAdd; } }
        private BarButtonItem[] ItemMenuDelete { get { return _itemMenuDelete == null ? new BarButtonItem[] { m_toolBarDelete, q_toolBarDelete } : _itemMenuDelete; } }
        private BarButtonItem[] ItemMenuEdit { get { return _itemMenuEdit == null ? new BarButtonItem[] { m_toolBarEdit, q_toolBarEdit } : _itemMenuEdit; } }
        private BarButtonItem[] ItemMenuExport { get { return _itemMenuExport == null ? new BarButtonItem[] { m_toolBarExport, q_toolBarExport } : _itemMenuExport; } }
        private BarButtonItem[] ItemMenuConfirm { get { return _itemMenuConfirm == null ? new BarButtonItem[] { m_toolBarConfirm } : _itemMenuConfirm; } }
        private BarButtonItem[] ItemMenuImport { get { return _itemMenuImport == null ? new BarButtonItem[] { m_toolBarImport } : _itemMenuImport; } }
        private BarButtonItem[] ItemMenuPrint { get { return _itemMenuPrint == null ? new BarButtonItem[] { m_toolBarPrint } : _itemMenuPrint; } }
        #endregion

        #region Virtual Method Must Implement by inherrited form.
        public virtual void OnCommandExit() { }
        public virtual bool OnCommandView() { return true; }
        public virtual bool OnCommandAdd() { return true; }
        public virtual bool OnCommandEdit() { return true; }
        public virtual bool OnCommandDelete() { return true; }
        public virtual bool OnCommandSave() { return true; }
        public virtual bool OnCommandConfirm() { return true; }
        public virtual bool OnCommandCancel() { return true; }
        public virtual bool OnCommandRefresh() { return true; }
        public virtual bool OnCommandPrint() { return true; }
        public virtual bool OnCommandBookStock() { return true; }
        public virtual bool OnCommandImport() { return true; }
        #endregion

        #region Event Handler Function
        private void FormBase_Load(object sender, EventArgs e)
        {
            try
            {
                if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
                    CheckPermission();

                if (!DesignMode)
                {
                    OnLanguageChange(this, new LanguageChangeEventArgs(new MultiLanguage()));

                    if (string.IsNullOrWhiteSpace(ScreenID))
                    {
                        _isNotSetScreenID = true;
                    }
                    else
                    {
                        _isNotSetScreenID = false;
                        CSI.Business.Admin.ScreenControl sc = new CSI.Business.Admin.ScreenControl();
                        string ipAddress = NetworkUtil.GetIPAdress();

                        IsLock = sc.LockScreen(this.ScreenID, AppConfig.UserLogin, ipAddress);
                    }
                    IntitialGridStyle();
                    ProtectEditGrid();
                    LastestDailyPost();
                    ControlUtil.HiddenControl(GridControlSearchResult == null, cboPaintStyle);
                    if (GridExportExcel != null)
                    {
                        GridExportExcel.MouseDown += new MouseEventHandler(gdvExport_MouseDown);
                    }
                }
            }
            catch (Exception ex)
            {
                AUTError = ex;
                ControlUtil.EnableControl(false, m_toolBarAdd, m_toolBarEdit, m_toolBarView, m_toolBarDelete, m_toolBarConfirm, m_toolBarExport, m_toolBarRefresh, m_toolBarAdd, m_toolBarCancel, m_toolBarBookStock, m_toolBarImport, m_toolBarPrint);
                //throw ex;
                //MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void FormBase_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(ScreenID))
                    return;
                CSI.Business.Admin.ScreenControl sc = new CSI.Business.Admin.ScreenControl();
                string ipAddress = NetworkUtil.GetIPAdress();
                sc.ClearScreen(this.ScreenID, AppConfig.UserLogin, ipAddress);
            }
            catch (Exception ex)
            {

            }
        }
        
        private void FormBase_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (sender is TextBox)
                {
                    this.SelectNextControl(this, true, true, false, true);
                }
            }
        }

        private void FormBase_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.ActiveControl != null && this.ActiveControl.TabStop)
                {
                    //System.Windows.Forms.Control ctrl = this.GetNextControl(this.ActiveControl, true);
                    this.SelectNextControl(this.ActiveControl, true, true, true, false);
                }
            }
        }

        private void btnView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                ClearErrorProvider();
                OnCommandView();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }            
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                ClearErrorProvider();
                OnCommandAdd();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }            
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                ClearErrorProvider();
                OnCommandEdit();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }            
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                ClearErrorProvider();
                OnCommandDelete();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }            
        }
        
        private void btnSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            //this.ShowWaitScreen();
            try
            {
                ClearErrorProvider();
                OnCommandSave();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
            finally
            {
                this.Cursor = Cursors.Default;
                //this.CloseWaitScreen();
            }            
        }
        
        private void btnCalcel_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            //this.ShowWaitScreen();
            try
            {
                ClearErrorProvider();
                OnCommandCancel();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
            finally
            {
                this.Cursor = Cursors.Default;
                //this.CloseWaitScreen();
            }            
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                ClearErrorProvider();
                OnCommandRefresh();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }            
        }

        private void btnExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExportDataToExcel();
        }

        private void btnBookStock_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            //this.ShowWaitScreen();
            try
            {
                ClearErrorProvider();
                OnCommandBookStock();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
            finally
            {
                this.Cursor = Cursors.Default;
                //this.CloseWaitScreen();
            }       
        }

        private void btnImport_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                ClearErrorProvider();
                OnCommandImport();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }   
        }

        private void gdvExport_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                pmQuickMenu.ShowPopup(ribbonControl1.Manager, MousePosition);
            }
        }

        private void cboGridTheme_EditValueChanged(object sender, EventArgs e)
        {
            AppConfig.GridThemeStyle = cboGridTheme.EditValue.ToString();
            ChangeThemeStyle();
        }

        private void cboPaintStyle_EditValueChanged(object sender, EventArgs e)
        {
            AppConfig.GridPaintStyle = cboPaintStyle.EditValue.ToString();
            ChangePaintStyle();
        }
        
        private void btnConfirm_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                ClearErrorProvider();
                OnCommandConfirm();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnPrint_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                ClearErrorProvider();
                OnCommandPrint();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        //===Quick Toolbar=====
        private void iCopy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gdvExport == null)
            {
                return;
            }

            if (gdvExport.RowCount > 0)
            {
                try
                {
                    if (!String.IsNullOrEmpty(gdvExport.GetFocusedValue().ToString()))
                    {
                        Clipboard.SetText(gdvExport.GetFocusedValue().ToString());
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        private void iView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                ClearErrorProvider();
                OnCommandView();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }            
        }

        private void iAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                ClearErrorProvider();
                OnCommandAdd();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }            
        }

        private void iEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                ClearErrorProvider();
                OnCommandEdit();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }            
        }

        private void iDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                ClearErrorProvider();
                OnCommandDelete();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }            
        }

        private void iExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExportDataToExcel();
        }

        int gpHeight;
        GroupControl gp;
        private void GroupControl_ExpandCollapse_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            gp = (sender as GroupControl);
            int HeightArea = gp.AppearanceCaption.FontHeight + gp.Margin.Top + gp.Margin.Bottom;
            if (gp.CaptionImage.Height + gp.Margin.Top + gp.Margin.Bottom > HeightArea)
                HeightArea = gp.CaptionImage.Height + gp.Margin.Top + gp.Margin.Bottom;

            Point pt = gp.PointToClient(System.Windows.Forms.Control.MousePosition);
            if (pt.Y <= HeightArea)
            {
                Image expand = Rubix.Screen.Properties.Resources.ExpandIcon;
                int _HeightCaption_Collapse = gp.AppearanceCaption.CalcDefaultTextSize().Height + gp.Margin.Top + gp.Margin.Bottom;
                if (expand.Height + gp.Margin.Top + gp.Margin.Bottom > _HeightCaption_Collapse)
                    _HeightCaption_Collapse = expand.Height + gp.Margin.Top + gp.Margin.Bottom;

                if (gp.Height == _HeightCaption_Collapse)
                {
                    //gp.Height = ((Size)gp.Tag).Height;
                    gpHeight = ((Size)gp.Tag).Height;
                    gp.CaptionImage = Rubix.Screen.Properties.Resources.CollapseIcon;
                }
                else
                {
                    //gp.Height = _HeightCaption_Collapse;
                    gpHeight = _HeightCaption_Collapse;
                    gp.CaptionImage = expand;
                }
                timer1.Enabled = true;
            }

            Cursor.Current = Cursors.Default;
        }
                
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (gp.Height == gpHeight)
            {
                timer1.Enabled = false;
                return;
            }
            else if (gp.Height > gpHeight)
            {
                if (gp.Height - 10 >= gpHeight)
                {
                    gp.Height = gp.Height - 10;
                }
                else
                {
                    gp.Height = gpHeight;
                }
            }
            else
            {
                if (gp.Height + 10 <= gpHeight)
                {
                    gp.Height = gp.Height + 10;
                }
                else
                {
                    gp.Height = gpHeight;
                }
            }
        }
        #endregion
                            
        #region Generic Function 
        private void ExportDataToExcel()
        {
            if (GridExportExcel != null && GridExportExcel.RowCount > 0)
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.AddExtension = true;
                saveFile.CheckPathExists = true;
                saveFile.DefaultExt = "xlsx";
                saveFile.Filter = "Excel Workbook (*.xlsx)|*.xlsx|Excel 97-2003 Workbook (*.xls)|*.xls";
                //saveFile.FileName = "";
                saveFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    bool flgAllowCellMerge = GridExportExcel.OptionsView.AllowCellMerge;
                    try
                    {
                        // 18 Jan 2013: expand excel column size
                        GridExportExcel.OptionsPrint.AutoWidth = false;
                        GridExportExcel.BestFitColumns();
                        GridExportExcel.OptionsPrint.PrintHeader = GridExportExcel.OptionsView.ShowColumnHeaders;

                        // end 18 Jan 2013: expand excel column size
                        GridExportExcel.OptionsView.AllowCellMerge = false;
                        if (saveFile.FilterIndex == 1)
                        {
                            GridExportExcel.ExportToXlsx(saveFile.FileName);
                        }
                        else if (saveFile.FilterIndex == 2)
                        {
                            GridExportExcel.ExportToXls(saveFile.FileName);
                        }
                        Type officeType = Type.GetTypeFromProgID("Excel.Application");
                        if (officeType == null)
                        {
                            MessageDialog.ShowBusinessErrorMsg(this, "Cannot open this file type! Please check if device is compatible or try copy the file to compatible device.");
                        }
                        else
                        {
                            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                            excel.Visible = true;
                            excel.Workbooks.Open(saveFile.FileName);
                        }
                        Rubix.Framework.ControlUtil.SetBestWidth(GridExportExcel);
                    }
                    catch (Exception ex)
                    {
                        MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
                    }
                    GridExportExcel.OptionsView.AllowCellMerge = flgAllowCellMerge;
                }
            }
            else
            {
                MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0333"));
            }
        }

        private void IntitialGridStyle()
        {           
            cboGridTheme.EditValue = AppConfig.GridThemeStyle;
            cboPaintStyle.EditValue = AppConfig.GridPaintStyle;
            ChangeThemeStyle();
            ChangePaintStyle();
        }

        private void ChangeThemeStyle()
        {
            if (GridControlSearchResult != null)
            {
                foreach (GridControl gdc in GridControlSearchResult)
                {
                    gdc.ForceInitialize();
                    string filePath;
                    DevExpress.XtraGrid.Design.XAppearances gvScheme;
                    try
                    {
                        filePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.System) + "\\DevExpress.XtraGrid.Appearances.xml";
                        gvScheme = new DevExpress.XtraGrid.Design.XAppearances(filePath);
                    }
                    catch (Exception)
                    {
                        filePath = System.Environment.CurrentDirectory + "\\DevExpress.XtraGrid.Appearances.xml";
                        gvScheme = new DevExpress.XtraGrid.Design.XAppearances(filePath);
                    }
                    foreach (GridView gdv in gdc.Views)
                    {
                        gvScheme.LoadScheme(cboGridTheme.EditValue.ToString(), gdv);
                    }
                }                
            }

            if (TreeListControl != null)
            {
                string filePath;
                DevExpress.XtraTreeList.Design.XAppearances gvScheme;
                try
                {
                    filePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.System) + "\\DevExpress.XtraTreeList.Appearances.xml";
                    gvScheme = new DevExpress.XtraTreeList.Design.XAppearances(filePath);
                }
                catch (Exception)
                {
                    filePath = System.Environment.CurrentDirectory + "\\DevExpress.XtraTreeList.Appearances.xml";
                    gvScheme = new DevExpress.XtraTreeList.Design.XAppearances(filePath);
                }
                if (TreeListControl != null)
                {
                    foreach (TreeList trl in TreeListControl)
                    {
                        gvScheme.LoadScheme(cboGridTheme.EditValue.ToString(), trl);
                    }
                }
            }            
        }

        private void ChangePaintStyle()
        {
            if (GridControlSearchResult != null)
            {
                foreach (GridControl gdc in GridControlSearchResult)
                {
                    for (int i = gdc.Views.Count - 1; i >= 0; i--)
                    {
                        gdc.Views[i].PaintStyleName = cboPaintStyle.EditValue.ToString();
                    }
                }
            }
        }

        private void ProtectEditGrid()
        {
            if (GridControlSearchResult != null)
            {
                foreach (GridControl gdc in GridControlSearchResult)
                {
                    foreach (GridView gdv in gdc.Views)
                    {
                        gdv.OptionsBehavior.Editable = false;
                        gdv.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gdv.Appearance.HeaderPanel.Font = new Font(gdv.Appearance.HeaderPanel.Font, FontStyle.Bold);
                        //if (gdv is BandedGridView)
                        //{
                        //    BandedGridView bgv = (BandedGridView)gdv;
                        //    bgv.Appearance.BandPanel.Font = new Font(gdv.Appearance.HeaderPanel.Font, FontStyle.Bold);
                        //    bgv.Appearance.BandPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        //}
                        //gdv.OptionsView.ColumnAutoWidth = false;
                        gdv.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gdv_PopupMenuShowing);
                    }
                }
            }
        }

        private DXMenuItem GetItemByStringId(DXPopupMenu menu, GridStringId id)
        {

            foreach (DXMenuItem item in menu.Items)

                if (item.Caption == GridLocalizer.Active.GetLocalizedString(id))

                    return item;

            return null;

        }

        private void gdv_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {

            //if (e.MenuType == GridMenuType.Column)
            //{
            //    DXMenuItem mi = GetItemByStringId(e.Menu, GridStringId.MenuColumnRemoveColumn);
            //    if (mi != null)
            //        mi.Visible = false;

            //    mi = GetItemByStringId(e.Menu, GridStringId.MenuColumnColumnCustomization);
            //    if (mi != null)
            //        mi.Enabled = false;

            //    mi = GetItemByStringId(e.Menu, GridStringId.MenuColumnShowColumn);
            //    if (mi != null)
            //        mi.Enabled = false;
            //}

        }

        protected void ShowWaitScreen()
        { 
            if (this.ActiveControl != null && !AppConfig.SplashScreenManager.IsSplashFormVisible)
            {
                if (AppConfig.SplashScreenType != 2)
                {
                    AppConfig.SplashScreenType = 2;
                    AppConfig.SplashScreenManager = splashScreenManager;
                }
                AppConfig.SplashScreenManager.ShowWaitForm();
                AppConfig.SplashScreenManager.SetWaitFormCaption(Common.GetMessage("A0002"));
                AppConfig.SplashScreenManager.SetWaitFormDescription(Common.GetMessage("A0003"));
            }
        }

        protected void CloseWaitScreen()
        {
            if (this.ActiveControl != null && AppConfig.SplashScreenManager.IsSplashFormVisible && AppConfig.SplashScreenType == 2)
            {                
                AppConfig.SplashScreenManager.CloseWaitForm();
                //AppConfig.SplashScreenManager.Dispose();
            }
        }

        protected void ClearErrorProvider()
        {
            this.errorProvider.ClearErrors();
        }

        private bool IsAllowToPerform(Type form, string userID, string permission)
        {
            CSI.Business.Admin.SecurityMapping sm = new CSI.Business.Admin.SecurityMapping();
            return sm.IsAllowToPerformAuthen(form.FullName, userID, permission);
        }

        private bool IsAllowToPerform(string FormFullName, string userID, string permission)
        {
            CSI.Business.Admin.SecurityMapping sm = new CSI.Business.Admin.SecurityMapping();
            return sm.IsAllowToPerformAuthen(FormFullName, userID, permission);
        }

        private void CheckPermission()
        {            
            SecurityMapping sm = new SecurityMapping();            
            string [] permission = sm.GetScreenPermission(this.GetType());

            try
            {
                if (permission.Count(c => c.Equals(Rubix.Framework.Permission.Add.ToString(), StringComparison.InvariantCultureIgnoreCase)) > 0)
                {
                    canAdd = this.IsAllowToPerform(this.GetType(), AppConfig.UserLogin, Rubix.Framework.Permission.Add);
                }
                else
                {
                    canAdd = false;
                }
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                if (permission.Count(c => c.Equals(Rubix.Framework.Permission.Edit.ToString(), StringComparison.InvariantCultureIgnoreCase)) > 0)
                {
                    canEdit = this.IsAllowToPerform(this.GetType(), AppConfig.UserLogin, Rubix.Framework.Permission.Edit);
                }
                else
                {
                    canEdit = false;
                }
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                if (permission.Count(c => c.Equals(Rubix.Framework.Permission.Delete.ToString(), StringComparison.InvariantCultureIgnoreCase)) > 0)
                {
                    canDelete = this.IsAllowToPerform(this.GetType(), AppConfig.UserLogin, Rubix.Framework.Permission.Delete);
                }
                else
                {
                    canDelete = false;
                }
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                if (permission.Count(c => c.Equals(Rubix.Framework.Permission.Export.ToString(), StringComparison.InvariantCultureIgnoreCase)) > 0)
                {
                    canExport = this.IsAllowToPerform(this.GetType(), AppConfig.UserLogin, Rubix.Framework.Permission.Export);
                }
                else
                {
                    canExport = false;
                }
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                if (permission.Count(c => c.Equals(Rubix.Framework.Permission.Confirm.ToString(), StringComparison.InvariantCultureIgnoreCase)) > 0)
                {
                    canConfirm = this.IsAllowToPerform(this.GetType(), AppConfig.UserLogin, Rubix.Framework.Permission.Confirm);
                }
                else
                {
                    canConfirm = false;
                }
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                if (permission.Count(c => c.Equals(Rubix.Framework.Permission.Import.ToString(), StringComparison.InvariantCultureIgnoreCase)) > 0)
                {
                    canImport = this.IsAllowToPerform(this.GetType(), AppConfig.UserLogin, Rubix.Framework.Permission.Import);
                }
                else
                {
                    canImport = false;
                }
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                if (permission.Count(c => c.Equals(Rubix.Framework.Permission.Print.ToString(), StringComparison.InvariantCultureIgnoreCase)) > 0)
                {
                    canPrint = this.IsAllowToPerform(this.GetType(), AppConfig.UserLogin, Rubix.Framework.Permission.Print);
                }
                else
                {
                    canPrint = false;
                }
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


                m_toolBarAdd.Enabled = canAdd;
                m_toolBarDelete.Enabled = canDelete;
                m_toolBarEdit.Enabled = canEdit;
                m_toolBarExport.Enabled = canExport;
                m_toolBarConfirm.Enabled = canConfirm;
                m_toolBarImport.Enabled = canImport;
                m_toolBarPrint.Enabled = canPrint;

                q_toolBarAdd.Enabled = canAdd;
                q_toolBarEdit.Enabled = canEdit;
                q_toolBarDelete.Enabled = canDelete;
                q_toolBarExport.Enabled = canExport;
                
                SetVisibleMenu(canAdd, Rubix.Framework.Permission.Add);
                SetVisibleMenu(canDelete, Rubix.Framework.Permission.Delete);
                SetVisibleMenu(canEdit, Rubix.Framework.Permission.Edit);
                SetVisibleMenu(canExport, Rubix.Framework.Permission.Export);
                SetVisibleMenu(canConfirm, Rubix.Framework.Permission.Confirm);
                SetVisibleMenu(canImport, Rubix.Framework.Permission.Import);
                SetVisibleMenu(canPrint, Rubix.Framework.Permission.Print);
                //////////////////////////////////////////////////////////////////
                //Check Add permission for adding Add button to user control.
                foreach (DataRow dr in Common.InitialDataTableUserControl().Rows)
                {
                    System.Windows.Forms.Control[] ct = this.Controls.Find(dr["UserControlName"].ToString(), true);
                    if (ct.Length > 0)
                    {
                        Common.SetEnableAddToUserControl(ct, this.IsAllowToPerform(dr["ScreenName"].ToString(), AppConfig.UserLogin, Rubix.Framework.Permission.Add));
                    }
                }
                /////////////////////////////////////////////////////////////////
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SetVisibleMenu(bool canVisible, string permission)
        {
            BarButtonItem[] barButtonItems = null;
            switch (permission)
            { 
                case Permission.Add:
                    barButtonItems = ItemMenuAdd;
                    break;
                case Permission.Edit:
                    barButtonItems = ItemMenuEdit;
                    break;
                case Permission.Delete:
                    barButtonItems = ItemMenuDelete;
                    break;
                case Permission.Export:
                    barButtonItems = ItemMenuExport;
                    break;
                case Permission.Confirm:
                    barButtonItems = ItemMenuConfirm;
                    break;
                case Permission.Import:
                    barButtonItems = ItemMenuImport;
                    break;
                case Permission.Print:
                    barButtonItems = ItemMenuPrint;
                    break;
            }

            if (barButtonItems == null)
            {
                return;
            }
            ControlUtil.HiddenControl(!canVisible, barButtonItems);
            foreach (BarButtonItem bar in barButtonItems)
            {
                bar.Tag = canVisible;
            }  
        }

        private void LastestDailyPost()
        {
            try
            {
                DataTable dt = LastestDailyBiz.LastestDailyPost();
                if (dt.Rows.Count > 0)
                {
                    AppConfig.LastestDailyPost.Caption = string.Format(AppConfig.LastestDailyPost.Caption, Convert.ToDateTime(dt.Rows[0]["MaxDateDailyPost"]).ToString("dd/MM/yyyy HH:mm"));
                }
                else
                {
                    AppConfig.LastestDailyPost.Caption = string.Format(AppConfig.LastestDailyPost.Caption, "-");
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void SetExpandGroupControl(GroupControl grpSearchCriteria)
        {
            if (grpSearchCriteria != null)
            {
                if (grpSearchCriteria.Dock != DockStyle.Fill)
                {
                    if (grpSearchCriteria.Tag == null)
                    {
                        grpSearchCriteria.Tag = grpSearchCriteria.Size;
                    }
                    grpSearchCriteria.CaptionImage = Rubix.Screen.Properties.Resources.CollapseIcon;
                    grpSearchCriteria.Click += GroupControl_ExpandCollapse_Click;
                }
            }
        }
        #endregion

        #region IMultiLanguage Members
        LanguageChangeEventArgs lang = new LanguageChangeEventArgs(new MultiLanguage());
        public virtual void OnLanguageChange(object sender, LanguageChangeEventArgs e)
        {
            if (!this.DesignMode)
            {
                this.Text = e.MultiLanguage.GetText(MultiLanguage.eType.Form, this.Name, "Text", this.Text);
                Util.ChangeLanguage(this.Name, ((System.Windows.Forms.Control)sender).Controls, e);
                Util.ChangeLanguage("FormBase", this.Controls, e);
                lang = e;

                pmQuickMenu.MenuCaption = e.MultiLanguage.GetMenuText("QuickMenu", "Quick Menu");
            }
        }
        protected void GridViewOnChangeLanguage(GridControl gridControl)
        {
            Util.ChangeLanguage(this.Name, gridControl, lang);
        }
        protected void GridViewChildOnChangeLanguage(GridControl gridControl, int RowHandle)
        {
            Util.ChangeLanguageGridChild(this.Name, gridControl, lang, RowHandle);
        }
        protected string GetLanguange(string ControlName, string CurrentDisplayText)
        {
            return lang.MultiLanguage.GetText(MultiLanguage.eType.Form, this.Name, ControlName, CurrentDisplayText);
        }
        #endregion                

        #region ILogoutable Members
        public virtual void OnLogout()
        {
            AppConfig.MainScreen.OnLogout();
        }
        #endregion                
    }
}