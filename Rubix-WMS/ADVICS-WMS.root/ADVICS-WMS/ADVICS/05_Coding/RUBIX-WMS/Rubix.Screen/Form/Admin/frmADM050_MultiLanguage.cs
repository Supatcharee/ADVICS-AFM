using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Rubix.Framework;
using CSI.Business;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTreeList;
using DevExpress.XtraNavBar;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraBars;
using DevExpress.XtraTab;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraBars.Ribbon;

namespace Rubix.Screen.Form.Admin
{
    [ScreenPermissionAttribute(Permission.OpenScreen, Permission.Edit)]
    public partial class frmADM050_MultiLanguage : FormBase
    {
        #region Member
        private MultiLangBiz mb = null;
        #endregion

        #region Constructor
        public frmADM050_MultiLanguage()
        {
            InitializeComponent();
            base.GridControlSearchResult = new GridControl[] { grdResult };
            ControlUtil.HiddenControl(true, m_toolBarSave, m_toolBarCancel, m_toolBarRefresh, m_toolBarView, m_toolBarDelete, m_toolBarAdd);
        }
        #endregion
        
        #region Properties
        private MultiLangBiz BusinessClass
        {
            get
            {
                if (mb == null)
                {
                    mb = new MultiLangBiz();
                }
                return mb;
            }
        }
        #endregion

        #region Override Method
        public override bool OnCommandAdd()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                Dialog.dlgADM050_MultiLanguage ListScreenDialog = new Dialog.dlgADM050_MultiLanguage();
                System.Windows.Forms.Form frm = null;

                if (ListScreenDialog.ShowDialog() == DialogResult.OK)
                {
                    ShowWaitScreen();
                    Type[] InnerType = ListScreenDialog.CurrentAssembly.GetTypes();

                    foreach (Type t in InnerType)
                    {
                        foreach (MultiLanguageData.FormData Data in ListScreenDialog.GetOutputData().ArrForms)
                        {
                            if (t.Name.Equals(Data.FormName))
                            {
                                if (t.Namespace.ToUpper() == "RUBIX.SCREEN.REPORT")
                                {
                                    try
                                    {
                                        DevExpress.XtraReports.UI.XtraReport xrep = (DevExpress.XtraReports.UI.XtraReport)Activator.CreateInstance(t);
                                        xrep.Visible = false;
                                        xrep.ShowPreview();
                                        GetReportControl(xrep);
                                        xrep.ClosePreview();
                                        xrep.Dispose();
                                    }
                                    catch (Exception ex)
                                    {                                        
                                        throw ex;
                                    }
                                }
                                else
                                {
                                    frm = null;
                                    try
                                    {
                                        frm = (System.Windows.Forms.Form)Activator.CreateInstance(t);
                                        if (frm is Rubix.Screen.DialogBase)
                                        {
                                            ((Rubix.Screen.DialogBase)frm).Visible = false;
                                            ((Rubix.Screen.DialogBase)frm).Show();
                                        }
                                        if (frm is Rubix.Screen.FormBase)
                                        {
                                            ((Rubix.Screen.FormBase)frm).Visible = false;
                                            ((Rubix.Screen.FormBase)frm).Show();
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        throw new Exception("Cannot create instance of class " + frm.Name + ". Please create default constructor first.");
                                    }

                                    //Add new data to database
                                    try
                                    {
                                        BusinessClass.AddNewMultiLang(frm.Name, "Text", "Form Title", frm.Text, frm.Name, string.Empty, AppConfig.UserLogin);
                                    }
                                    catch (Exception ex)
                                    {
                                        if (frm != null)
                                        {
                                            frm.Dispose();
                                        }
                                        throw ex;
                                    }
                                    //-----------------------------------------------

                                    try
                                    {
                                        GetControls(frm.Controls, frm.Name);
                                    }
                                    catch (Exception ex)
                                    {
                                        throw ex;
                                    }
                                    finally
                                    {
                                        if (frm != null)
                                        {
                                            frm.Dispose();
                                        }
                                    }
                                }
                            }
                        }
                    }

                    MessageDialog.ShowInformationMsg("Save already.");
                    BindingScreenName();
                    LoadData();
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
                return false;
            }
            finally
            {
                CloseWaitScreen();
                this.Cursor = Cursors.Default;
            }
        }
        public override bool OnCommandEdit()
        {
            try
            {
                ShowWaitScreen();
                gdvResult.OptionsBehavior.Editable = true;
                grcLANG_WORD.OptionsColumn.AllowEdit = true;
                ControlUtil.HiddenControl(false, m_toolBarSave, m_toolBarCancel);
                ControlUtil.HiddenControl(true, m_toolBarAdd, m_toolBarEdit);
                LoadData();
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
                ShowWaitScreen();
                gdvResult.CloseEditor();
                if (!gdvResult.UpdateCurrentRow())
                {
                    return false;
                }

                if (grdResult.DataSource == null)
                {
                    return false;
                }

                ControlUtil.HiddenControl(true, m_toolBarSave, m_toolBarCancel);
                ControlUtil.HiddenControl(false, m_toolBarAdd, m_toolBarEdit);

                DataRow[] dr = ((DataTable)grdResult.DataSource).Select("", "", DataViewRowState.ModifiedCurrent);
                DataTable dt = new DataTable();
                dt.Columns.Add("MAP_ID", typeof(string));
                dt.Columns.Add("LANG_ID", typeof(string));
                dt.Columns.Add("LANG_WORD", typeof(string));
                dt.Columns.Add("UPDATED_BY", typeof(string));

                for (int i = 0; i < dr.Length; i++)
                {
                    DataRow drr = dt.NewRow();
                    drr["MAP_ID"] = dr[i]["MAP_ID"].ToString();
                    drr["LANG_ID"] = cboLang.EditValue.ToString();
                    drr["LANG_WORD"] = dr[i]["LANG_WORD"].ToString();
                    drr["UPDATED_BY"] = AppConfig.UserLogin;
                    dt.Rows.Add(drr);
                }

                dt.AcceptChanges();
                BusinessClass.UpdateMultiLang(dt);
                grcLANG_WORD.OptionsColumn.AllowEdit = false;
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
                ControlUtil.HiddenControl(true, m_toolBarSave, m_toolBarCancel);
                ControlUtil.HiddenControl(false, m_toolBarAdd, m_toolBarEdit);
                grcLANG_WORD.OptionsColumn.AllowEdit = false;
                LoadData();
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
        private void frmADM050_MultiLanguage_Load(object sender, EventArgs e)
        {
            LoadCombobox();
            BindingScreenName();
            grcLANG_WORD.OptionsColumn.AllowEdit = false;
        }

        private void cboLang_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                ShowWaitScreen();
                LoadData();
                CloseWaitScreen();
            }
            catch (Exception ex)
            {
                CloseWaitScreen();
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void cboType_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                ShowWaitScreen();
                if (cboType.EditValue.ToString().Equals("Menu") || (cboType.EditValue.ToString().Equals("Global")))
                {
                    ControlUtil.EnableControl(false, cboScreen);
                    cboScreen.EditValue = null;
                }
                else
                {
                    ControlUtil.EnableControl(true, cboScreen);
                    if (cboScreen.Properties.DataSource != null && ((DataTable)cboScreen.Properties.DataSource).Rows.Count > 0)
                    {
                        cboScreen.EditValue = ((DataTable)cboScreen.Properties.DataSource).Rows[0]["FORM_ID"];
                    }
                    else
                    {
                        cboScreen.EditValue = null;
                    }
                }
                LoadData();
                CloseWaitScreen();
            }
            catch (Exception ex)
            {
                CloseWaitScreen();
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void cboScreen_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                ShowWaitScreen();
                LoadData();
                CloseWaitScreen();
            }
            catch (Exception ex)
            {
                CloseWaitScreen();
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void frmADM050_MultiLanguage_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                string strKey = e.Control.ToString() + e.Shift.ToString() + e.KeyCode.ToString();

                if (strKey.ToUpper().Contains("TRUETRUEA"))
                {
                    m_toolBarAdd.Visibility = BarItemVisibility.Always;
                    m_toolBarAdd.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                CloseWaitScreen();
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        #endregion
        
        #region Generic Funtion
        private void LoadCombobox()
        {
            try
            {
                DataTable dt = BusinessClass.LoadAlllanguage();
                cboLang.Properties.DataSource = dt;
                cboLang.Properties.DisplayMember = "Description";
                cboLang.Properties.ValueMember = "Lang_ID";
                cboLang.EditValue = dt.Rows[0]["Lang_ID"].ToString();
            }
            catch (Exception ex)
            { }
            
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Text", typeof(string));
                dt.Columns.Add("Value", typeof(string));
                DataRow dr = dt.NewRow();
                dr["Text"] = "Screen";
                dr["Value"] = "Screen";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Text"] = "Message Box";
                dr["Value"] = "Menu";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Text"] = "Alert";
                dr["Value"] = "Global";
                dt.Rows.Add(dr);
                dt.AcceptChanges();

                cboType.Properties.DataSource = dt;
                cboType.Properties.DisplayMember = "Text";
                cboType.Properties.ValueMember = "Value";

                cboType.EditValue = dt.Rows[0]["Value"].ToString();
            }
            catch (Exception ex)
            { }
        }

        private void BindingScreenName()
        {
            try
            {
                DataTable dtLanCtrl = BusinessClass.LoadAllFormName();

                cboScreen.Properties.DataSource = null;
                if (dtLanCtrl.Rows.Count > 0)
                {
                    cboScreen.Properties.DataSource = dtLanCtrl;
                    cboScreen.Properties.DisplayMember = "ORIGIN";
                    cboScreen.Properties.ValueMember = "FORM_ID";

                    cboScreen.EditValue = dtLanCtrl.Rows[0]["FORM_ID"].ToString();
                }
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        private void GetControls(System.Windows.Forms.Control.ControlCollection ctrls, string FormName, string Optional = "")
        {
            string CTRL_ID = string.Empty;
            string CTRL_TYPE = string.Empty;
            string ORIGIN = string.Empty;
            
            foreach (System.Windows.Forms.Control c in ctrls)
            {
                if (!c.GetType().IsSubclassOf(typeof(System.Windows.Forms.TextBox)) & !c.Name.Equals(string.Empty))
                { 
                   if (c.GetType() == typeof(GridControl))
                    {
                        GridControl gc = (GridControl)c;
                        for (int sht = 0; sht < gc.Views.Count; sht++)
                        {
                            if (gc.Views[sht] is BandedGridView)
                            {
                                BandedGridView bgv = ((BandedGridView)gc.Views[sht]);
                                for (int col = 0; col < bgv.Bands.Count; col++)
                                {
                                    if (bgv.Columns[col].Visible)
                                    {
                                        CTRL_ID = gc.Name + "." + bgv.Name + "." + bgv.Bands[col].Name;
                                        CTRL_TYPE = bgv.Bands[col].GetType().Name;
                                        ORIGIN = bgv.Bands[col].Caption;
                                        //Add new data to database
                                        if (ORIGIN != string.Empty)
                                        {
                                            BusinessClass.AddNewMultiLang(FormName, CTRL_ID, CTRL_TYPE, ORIGIN, FormName, string.Empty, AppConfig.UserLogin);
                                        }
                                        //-----------------------------------------------
                                        if (bgv.Bands[col].HasChildren)
                                        {
                                            GetBandChild(bgv.Bands[col].Children, FormName, CTRL_ID);
                                        }
                                        else if (bgv.Bands[col].Columns.Count > 0 && bgv.OptionsView.ShowColumnHeaders)
                                        {
                                            for (int i = 0; i < bgv.Bands[col].Columns.Count; i++)
                                            {
                                                if (bgv.Bands[col].Columns[i].Visible)
                                                {
                                                    CTRL_ID = gc.Name + "." + bgv.Name + "." + bgv.Bands[col].Name + "." + bgv.Bands[col].Columns[i].Name;
                                                    ORIGIN = bgv.Bands[col].Columns[i].Caption;
                                                    CTRL_TYPE = bgv.Bands[col].Columns[i].GetType().Name;
                                                    if (ORIGIN != string.Empty)
                                                    {
                                                        BusinessClass.AddNewMultiLang(FormName, CTRL_ID, CTRL_TYPE, ORIGIN, FormName, string.Empty, AppConfig.UserLogin);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }

                                if (bgv.OptionsView.ShowColumnHeaders)
                                {
                                    for (int col = 0; col < bgv.Columns.Count; col++)
                                    {
                                        if (bgv.Columns[col].Visible)
                                        {
                                            CTRL_ID = gc.Name + "." + bgv.Name + "." + bgv.Columns[col].Name;
                                            CTRL_TYPE = bgv.Columns[col].GetType().Name;
                                            ORIGIN = Util.IsNullOrEmpty(bgv.Columns[col].Caption) ? bgv.Columns[col].Name.Replace("col", "") : bgv.Columns[col].Caption;
                                            //Add new data to database
                                            if (bgv.Columns[col].Visible)
                                            {
                                                BusinessClass.AddNewMultiLang(FormName, CTRL_ID, CTRL_TYPE, ORIGIN, FormName, string.Empty, AppConfig.UserLogin);
                                            }
                                            //-----------------------------------------------
                                        }
                                    }
                                }
                            }
                            else if (gc.Views[sht] is GridView)
                            {
                                GridView grv = ((GridView)gc.Views[sht]);

                                if (grv.OptionsView.ShowColumnHeaders)
                                {
                                    for (int col = 0; col < grv.Columns.Count; col++)
                                    {
                                        if (grv.Columns[col].Visible)
                                        {
                                            CTRL_ID = gc.Name + "." + grv.Name + "." + grv.Columns[col].Name;
                                            CTRL_TYPE = grv.Columns[col].GetType().Name;
                                            ORIGIN = Util.IsNullOrEmpty(grv.Columns[col].Caption) ? grv.Columns[col].Name.Replace("col", "") : grv.Columns[col].Caption;
                                            //Add new data to database
                                            if (grv.Columns[col].Visible)
                                            {
                                                BusinessClass.AddNewMultiLang(FormName, CTRL_ID, CTRL_TYPE, ORIGIN, FormName, string.Empty, AppConfig.UserLogin);
                                            }
                                            //-----------------------------------------------
                                        }
                                    }

                                    grv.ExpandMasterRow(0, 0);
                                    if (grv.GetDetailView(0, 0) != null)
                                    {
                                        GridView grv1 = ((GridView)(grv.GetDetailView(0, 0)));

                                        CTRL_ID = gc.Name + "." + grv.Name + ".DetailView.Relation";
                                        CTRL_TYPE = grv.GetRelationName(0, 0).GetType().Name;
                                        ORIGIN = grv.GetRelationName(0, 0);
                                        //Add new data to database
                                        BusinessClass.AddNewMultiLang(FormName, CTRL_ID, CTRL_TYPE, ORIGIN, FormName, string.Empty, AppConfig.UserLogin);
                                        //-----------------------------------------------

                                        for (int col = 0; col < grv1.Columns.Count; col++)
                                        {
                                            CTRL_ID = gc.Name + "." + grv.Name + ".DetailView." + grv1.Columns[col].Name;
                                            CTRL_TYPE = grv1.Columns[col].GetType().Name;
                                            ORIGIN = Util.IsNullOrEmpty(grv1.Columns[col].GetTextCaption()) ? grv1.Columns[col].Name.Replace("col", "") : grv1.Columns[col].GetTextCaption();
                                            //Add new data to database
                                            BusinessClass.AddNewMultiLang(FormName, CTRL_ID, CTRL_TYPE, ORIGIN, FormName, string.Empty, AppConfig.UserLogin);
                                            //-----------------------------------------------
                                        }
                                    }
                                    grv.CollapseMasterRow(0);
                                }
                            }
                        }

                       if(gc.RepositoryItems.Count > 0)
                       {
                           foreach(RepositoryItem rep in gc.RepositoryItems)
                           {
                                if (rep.GetType() == typeof(RepositoryItemLookUpEdit))
                                {
                                    RepositoryItemLookUpEdit re = (RepositoryItemLookUpEdit)rep;
                                    for (int i = 0; i < re.Columns.Count; i++)
                                    {
                                        CTRL_ID = "RepositoryItem." + re.Name + "." + re.Columns[i].FieldName;
                                        CTRL_TYPE = re.Columns[i].GetType().Name;
                                        ORIGIN = re.Columns[i].Caption;
                                        //Add new data to database
                                        BusinessClass.AddNewMultiLang(FormName, CTRL_ID, CTRL_TYPE, ORIGIN, FormName, string.Empty, AppConfig.UserLogin);
                                        //-----------------------------------------------
                                    }    
                                }
                                else if (rep.GetType() == typeof(RepositoryItemSearchLookUpEdit))
                                {
                                    RepositoryItemSearchLookUpEdit re = (RepositoryItemSearchLookUpEdit)rep;
                                    GridView grv = re.View;

                                    if (grv.OptionsView.ShowColumnHeaders)
                                    {
                                        for (int col = 0; col < grv.Columns.Count; col++)
                                        {
                                            if (grv.Columns[col].Visible)
                                            {
                                                CTRL_ID = re.Name +"."+grv.Name + "." + grv.Columns[col].Name;
                                                CTRL_TYPE = grv.Columns[col].GetType().Name;
                                                ORIGIN = Util.IsNullOrEmpty(grv.Columns[col].Caption) ? grv.Columns[col].Name.Replace("col", "") : grv.Columns[col].Caption;
                                                //Add new data to database
                                                if (grv.Columns[col].Visible)
                                                {
                                                    BusinessClass.AddNewMultiLang(FormName, CTRL_ID, CTRL_TYPE, ORIGIN, FormName, string.Empty, AppConfig.UserLogin);
                                                }
                                                //-----------------------------------------------
                                            }
                                        }
                                    }
                                }
                           }
                       }
                    }
                   else if (c.GetType() == typeof(SearchLookUpEdit))
                   {
                       SearchLookUpEdit sle = (SearchLookUpEdit)c;
                       GridView grv = sle.Properties.View;
                       for (int col = 0; col < grv.Columns.Count; col++)
                       {
                           if (grv.Columns[col].Visible)
                           {
                               CTRL_ID = sle.Name + "." + grv.Name + "." + grv.Columns[col].Name;
                               CTRL_TYPE = grv.Columns[col].GetType().Name;
                               ORIGIN = Util.IsNullOrEmpty(grv.Columns[col].Caption) ? grv.Columns[col].Name.Replace("col", "") : grv.Columns[col].Caption;
                               //Add new data to database
                               BusinessClass.AddNewMultiLang(FormName, CTRL_ID, CTRL_TYPE, ORIGIN, FormName, string.Empty, AppConfig.UserLogin);
                               //-----------------------------------------------
                           }
                       }  
                   }
                   else if (c.GetType() == typeof(TreeList))
                   {
                       TreeList tl = (TreeList)c;
                       for(int i = 0 ; i < tl.Columns.Count ; i++)
                       {
                           CTRL_ID = tl.Columns[i].Name;
                           CTRL_TYPE = tl.Columns[i].GetType().Name;
                           ORIGIN = tl.Columns[i].Caption;
                           //Add new data to database
                           BusinessClass.AddNewMultiLang(FormName, CTRL_ID, CTRL_TYPE, ORIGIN, FormName, string.Empty, AppConfig.UserLogin);
                           //-----------------------------------------------
                       }
                       if (FormName == "MainFrameDevEx")
                       {
                           for (int i = 0; i < tl.Nodes.Count; i++)
                           {
                               CTRL_ID = tl.Name + "." + tl.Nodes[i].Id.ToString().PadLeft(2, '0');
                               CTRL_TYPE = tl.Nodes[i].GetType().Name;
                               ORIGIN = tl.Nodes[i].GetDisplayText(0);
                               //Add new data to database
                               BusinessClass.AddNewMultiLang(FormName, CTRL_ID, CTRL_TYPE, ORIGIN, FormName, string.Empty, AppConfig.UserLogin);
                               //-----------------------------------------------
                               if (tl.Nodes[i].HasChildren)
                               {
                                   GetTreeChild(tl.Nodes[i], FormName, CTRL_ID);
                               }
                           }
                       }
                   }
                   else if (c.GetType() == typeof(NavBarControl))
                   {
                       NavBarControl nc = (NavBarControl)c;
                       foreach (NavBarGroup ng in nc.Groups)
                       {
                           CTRL_ID = nc.Name + "." + ng.Name;
                           CTRL_TYPE = ng.GetType().Name;
                           ORIGIN = ng.Caption;
                           //Add new data to database
                           BusinessClass.AddNewMultiLang(FormName, CTRL_ID, CTRL_TYPE, ORIGIN, FormName, string.Empty, AppConfig.UserLogin);
                           //-----------------------------------------------
                       }
                   }
                   else if (c.GetType() == typeof(SimpleButton))
                   {
                       SimpleButton btn = (SimpleButton)c;
                       if (btn.ToolTip.Trim() != string.Empty)
                       {
                           CTRL_ID = btn.Name + "." + "ToolTip";
                           CTRL_TYPE = btn.GetType().Name;
                           ORIGIN = btn.ToolTip.Trim();
                           //Add new data to database
                           BusinessClass.AddNewMultiLang(FormName, CTRL_ID, CTRL_TYPE, ORIGIN, FormName, string.Empty, AppConfig.UserLogin);
                           //-----------------------------------------------
                       }
                       if (btn.Text.Trim() != string.Empty)
                       {
                           CTRL_ID = btn.Name + "." + "Text";
                           CTRL_TYPE = btn.GetType().Name;
                           ORIGIN = btn.Text.Trim();
                           //Add new data to database
                           BusinessClass.AddNewMultiLang(FormName, CTRL_ID, CTRL_TYPE, ORIGIN, FormName, string.Empty, AppConfig.UserLogin);
                           //-----------------------------------------------
                       }
                   }
                   else if (c.GetType().FullName.Contains("Rubix.Control"))
                   {
                       GetControls(c.Controls, FormName, c.Name);
                   }
                   else if (c.GetType() == typeof(TabControl))
                   {
                       TabControl tc = (TabControl)c;
                       for (int tp = 0; tp < tc.TabPages.Count; tp++)
                       {
                           CTRL_ID = tc.TabPages[tp].Name;
                           CTRL_TYPE = tc.TabPages[tp].GetType().Name;
                           ORIGIN = tc.TabPages[tp].Text;
                           //Add new data to database
                           BusinessClass.AddNewMultiLang(FormName, CTRL_ID, CTRL_TYPE, ORIGIN, FormName, string.Empty, AppConfig.UserLogin);
                           //-----------------------------------------------
                           GetControls(tc.TabPages[tp].Controls, FormName);
                       }
                   }
                   else if (c.GetType() == typeof(XtraTabControl))
                   {
                       XtraTabControl tc = (XtraTabControl)c;
                       foreach (XtraTabPage tp in tc.TabPages)
                       {
                           CTRL_ID = tp.Name;
                           CTRL_TYPE = tp.GetType().Name;
                           ORIGIN = tp.Text;
                           //Add new data to database
                           BusinessClass.AddNewMultiLang(FormName, CTRL_ID, CTRL_TYPE, ORIGIN, FormName, string.Empty, AppConfig.UserLogin);
                           //-----------------------------------------------
                           if (tp.HasChildren)
                           {
                               GetControls(tp.Controls, FormName);
                           }
                       }
                   }
                   else if (c.GetType() == typeof(ListView))
                   {
                       ListView lv = (ListView)c;
                       for (int i = 0; i < lv.Columns.Count; i++)
                       {
                           CTRL_ID = lv.Name + ".Column[" + i.ToString() + "]";
                           CTRL_TYPE = lv.GetType().Name;
                           ORIGIN = lv.Columns[i].Text;
                           //Add new data to database
                           BusinessClass.AddNewMultiLang(FormName, CTRL_ID, CTRL_TYPE, ORIGIN, FormName, string.Empty, AppConfig.UserLogin);
                           //-----------------------------------------------
                       }
                   }
                   else if (c.GetType() == typeof(LookUpEdit))
                   {
                       LookUpEdit lv = (LookUpEdit)c;
                       
                       for (int i = 0; i < lv.Properties.Columns.Count; i++)
                       {
                           CTRL_ID = lv.Name + ".Column[" + i.ToString() + "]";
                           CTRL_TYPE = lv.GetType().Name;
                           ORIGIN = lv.Properties.Columns[i].Caption;
                           //Add new data to database
                           BusinessClass.AddNewMultiLang(FormName, CTRL_ID, CTRL_TYPE, ORIGIN, FormName, string.Empty, AppConfig.UserLogin);
                           //-----------------------------------------------
                       }
                   }

                   else if (c.GetType() == typeof(RibbonControl) && FormName == "FormBase")
                   {
                        RibbonControl rc = (RibbonControl)c;
                        for (int i = 0; i < rc.Items.Count; i++)
                        {
                            if (rc.Items[i].GetType() == typeof(BarButtonItem))
                            {
                                CTRL_ID = rc.Items[i].Name;
                                CTRL_TYPE = rc.Items[i].GetType().Name;
                                ORIGIN = rc.Items[i].Caption;
                                //Add new data to database
                                BusinessClass.AddNewMultiLang(FormName, CTRL_ID, CTRL_TYPE, ORIGIN, FormName, string.Empty, AppConfig.UserLogin);
                                //-----------------------------------------------
                            }
                        }
                   }
                   else
                   {
                       string strType = c.GetType().Name;
                       if (!(strType.Equals("AFDComboBox")
                            || strType.Equals("ComboBox")
                            || strType.Equals("CurrencyTextBox")
                            || strType.Equals("DateTextBox")
                            || strType.Equals("DateTextBoxWithCalendar")
                            || strType.Equals("FpSpread")
                            || strType.Equals("ListView")
                            || strType.Equals("PictureBox")
                            || strType.Equals("ProgressBar")
                            || strType.Equals("RichTextBox")
                            || strType.Equals("Splitter")
                            || strType.Equals("TabControl")
                            || strType.Equals("TextBox")
                            || strType.Equals("ToolBar")
                            || strType.Equals("RibbonControl")
                            || strType.Equals("RibbonStatusBar")
                            || c is TextEdit
                            || c is UserControl
                            || c is MemoEdit
                            || c is DateEdit
                            || c is System.Windows.Forms.MaskedTextBox))
                       {
                           //---------------------------                
                           CTRL_ID = (Optional != string.Empty ? Optional + "." : "") + c.Name;
                           CTRL_TYPE = c.GetType().Name;
                           ORIGIN = c.Text;
                           //Add new data to database
                           if (ORIGIN.Trim() != string.Empty && c.Visible)
                           {
                               BusinessClass.AddNewMultiLang(FormName, CTRL_ID, CTRL_TYPE, ORIGIN, FormName, string.Empty, AppConfig.UserLogin);
                           }
                           //-----------------------------------------------

                           if (c.HasChildren)
                           {
                               GetControls(c.Controls, FormName);
                           }
                       }
                   }
                }
                else if (c.GetType() == typeof(BarDockControl) && (FormName == "FormBase" || FormName == "DialogBase"))
                {
                    BarDockControl bdc = (BarDockControl)c;

                    if (bdc.Dock == DockStyle.Bottom)
                    {
                        for (int i = 0; i < ((DevExpress.XtraBars.Controls.CustomControl)(bdc)).Manager.Bars.Count; i++)
                        {
                            for (int j = 0; j < ((DevExpress.XtraBars.Controls.CustomControl)(bdc)).Manager.Bars[i].ItemLinks.Count; j++)
                            {
                                CTRL_ID = ((DevExpress.XtraBars.Controls.CustomControl)(bdc)).Manager.Bars[i].ItemLinks[j].Item.Name;
                                CTRL_TYPE = ((DevExpress.XtraBars.Controls.CustomControl)(bdc)).Manager.Bars[i].ItemLinks[j].Item.GetType().Name;
                                ORIGIN = ((DevExpress.XtraBars.Controls.CustomControl)(bdc)).Manager.Bars[i].ItemLinks[j].Item.Caption;
                                if (ORIGIN.Trim() != string.Empty && ORIGIN.Trim() != "-")
                                {
                                    BusinessClass.AddNewMultiLang(FormName, CTRL_ID, CTRL_TYPE, ORIGIN, FormName, string.Empty, AppConfig.UserLogin);
                                }

                                if (!Util.IsNullOrEmpty(((DevExpress.XtraBars.Controls.CustomControl)(bdc)).Manager.Bars[i].ItemLinks[j].Item.SuperTip))
                                {
                                    CTRL_ID = ((DevExpress.XtraBars.Controls.CustomControl)(bdc)).Manager.Bars[i].ItemLinks[j].Item.Name + ".SuperTip";
                                    CTRL_TYPE = ((DevExpress.XtraBars.Controls.CustomControl)(bdc)).Manager.Bars[i].ItemLinks[j].Item.GetType().Name;
                                    ORIGIN = ((DevExpress.XtraBars.Controls.CustomControl)(bdc)).Manager.Bars[i].ItemLinks[j].Item.SuperTip.ToString();
                                    BusinessClass.AddNewMultiLang(FormName, CTRL_ID, CTRL_TYPE, ORIGIN, FormName, string.Empty, AppConfig.UserLogin);
                                }
                            }
                        }
                    }                       
                }
            }
        }
        
        private void GetTreeChild(TreeListNode tl, string FormName, string BaseControlName)
        {
            string CTRL_ID = string.Empty;
            string CTRL_TYPE = string.Empty;
            string ORIGIN = string.Empty;

            for (int i = 0; i < tl.Nodes.Count; i++)
            {
                CTRL_ID = BaseControlName + "." + tl.Nodes[i].Id.ToString().PadLeft(2,'0');
                CTRL_TYPE = tl.Nodes[i].GetType().Name;
                ORIGIN = tl.Nodes[i].GetDisplayText(0);
                //Add new data to database
                BusinessClass.AddNewMultiLang(FormName, CTRL_ID, CTRL_TYPE, ORIGIN, FormName, string.Empty, AppConfig.UserLogin);
                //-----------------------------------------------
                if (tl.Nodes[i].HasChildren)
                {
                    GetTreeChild(tl.Nodes[i], FormName, CTRL_ID);
                }
            } 
        }

        private void GetBandChild(GridBandCollection gb, string FormName, string BaseControlName)
        {
            string CTRL_ID = string.Empty;
            string CTRL_TYPE = string.Empty;
            string ORIGIN = string.Empty;

            for (int col = 0; col < gb.Count; col++)
            {
                if (gb[col].Visible)
                {
                    CTRL_ID = BaseControlName + "." + gb[col].Name;
                    CTRL_TYPE = gb[col].GetType().Name;
                    ORIGIN = gb[col].Caption;
                    //Add new data to database
                    BusinessClass.AddNewMultiLang(FormName, CTRL_ID, CTRL_TYPE, ORIGIN, FormName, string.Empty, AppConfig.UserLogin);
                    //-----------------------------------------------
                    if (gb[col].HasChildren)
                    {
                        GetBandChild(gb[col].Children, FormName, CTRL_ID);
                    }
                }
            }
        }

        private void LoadData()
        {
            try
            {
                if (cboType.EditValue != null)
                {
                    string strType = string.Empty;
                    string strFormName = string.Empty;
                    if (cboScreen.Enabled && cboScreen.EditValue != null)
                    {
                        strFormName = cboScreen.EditValue.ToString();
                    }
                    else
                    {
                        strFormName = "%";
                    }
                    strType = cboType.EditValue.ToString();
                    grdResult.DataSource = BusinessClass.SearchMultiLang(strFormName, strType, cboLang.EditValue.ToString());
                    ((DataTable)grdResult.DataSource).AcceptChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GetReportControl(DevExpress.XtraReports.UI.XtraReport ReportScreen)
        {
            string CTRL_ID = string.Empty;
            string CTRL_TYPE = string.Empty;
            string ORIGIN = string.Empty;
            string strReportName = ((DevExpress.XtraReports.UI.XtraReportBase)(ReportScreen)).ToString().Replace("Rubix.Screen.Report.", "");

            BusinessClass.AddNewMultiLang(strReportName, "Text", "Form Title", strReportName, strReportName, string.Empty, AppConfig.UserLogin);

            for (int i = 0; i < ReportScreen.Bands.Count; i++)
            {
                for(int j = 0; j < ReportScreen.Bands[i].Controls.Count; j++) 
                {
                    string strControlType = (ReportScreen.Bands[i].Controls[j]).ControlType;
                    if (strControlType == "XRLabel")
                    {
                        DevExpress.XtraReports.UI.XRLabel xlbl = (DevExpress.XtraReports.UI.XRLabel)ReportScreen.Bands[i].Controls[j];
                        //if (!xlbl.Text.Contains("xrLabel") && xlbl.Text.Trim() != string.Empty)
                        //{
                            if (xlbl.DataBindings.Count > 0)
                            {
                                if (xlbl.Text != string.Format("[Parameters.{0}]", xlbl.DataBindings[0].DataMember) &&
                                    xlbl.DataBindings[0].FormatString.Trim() != string.Empty &&
                                    xlbl.Text != string.Format("[{0}]", xlbl.DataBindings[0].DataMember))
                                {
                                    CTRL_ID = xlbl.Name;
                                    CTRL_TYPE = "XRLabel";
                                    ORIGIN = xlbl.DataBindings[0].FormatString;
                                    BusinessClass.AddNewMultiLang(strReportName, CTRL_ID, CTRL_TYPE, ORIGIN, strReportName, string.Empty, AppConfig.UserLogin);
                                }
                            }
                            else if (!xlbl.Text.Contains("xrLabel") && xlbl.Text.Trim() != string.Empty && xlbl.DataBindings.Count <= 0)
                            {
                                CTRL_ID = xlbl.Name;
                                CTRL_TYPE = "XRLabel";
                                ORIGIN = xlbl.Text;
                                BusinessClass.AddNewMultiLang(strReportName, CTRL_ID, CTRL_TYPE, ORIGIN, strReportName, string.Empty, AppConfig.UserLogin);
                            }
                        //}
                    }
                    else if (strControlType == "XRCheckBox")
                    {
                        DevExpress.XtraReports.UI.XRCheckBox xchk = (DevExpress.XtraReports.UI.XRCheckBox)ReportScreen.Bands[i].Controls[j];
                        if (xchk.Text.Trim() != string.Empty)
                        {
                            CTRL_ID = xchk.Name;
                            CTRL_TYPE = "XRCheckBox";
                            ORIGIN = xchk.Text;
                            BusinessClass.AddNewMultiLang(strReportName, CTRL_ID, CTRL_TYPE, ORIGIN, strReportName, string.Empty, AppConfig.UserLogin);
                        }
                    }
                    else if (strControlType == "XRTableCell")
                    {
                        DevExpress.XtraReports.UI.XRTableCell xtbc = (DevExpress.XtraReports.UI.XRTableCell)ReportScreen.Bands[i].Controls[j];
                        if (xtbc.Text.Trim() != string.Empty)
                        {
                            CTRL_ID = xtbc.Name;
                            CTRL_TYPE = "XRTableCell";
                            ORIGIN = xtbc.Text;
                            BusinessClass.AddNewMultiLang(strReportName, CTRL_ID, CTRL_TYPE, ORIGIN, strReportName, string.Empty, AppConfig.UserLogin);
                        }
                    }
                    else if (strControlType == "XRPageInfo")
                    {
                        DevExpress.XtraReports.UI.XRPageInfo xpgi = (DevExpress.XtraReports.UI.XRPageInfo)ReportScreen.Bands[i].Controls[j];
                        if (xpgi.Format.Trim() != string.Empty)
                        {
                            CTRL_ID = xpgi.Name;
                            CTRL_TYPE = "XRPageInfo";
                            ORIGIN = xpgi.Format;
                            BusinessClass.AddNewMultiLang(strReportName, CTRL_ID, CTRL_TYPE, ORIGIN, strReportName, string.Empty, AppConfig.UserLogin);
                        }
                    }
                    else if (strControlType == "XRTable")
                    {
                        DevExpress.XtraReports.UI.XRTable xtbl = (DevExpress.XtraReports.UI.XRTable)ReportScreen.Bands[i].Controls[j];
                        foreach (DevExpress.XtraReports.UI.XRTableRow xtr in xtbl)
                        {
                            foreach (DevExpress.XtraReports.UI.XRTableCell xtc in xtr)
                            {
                                if (xtc.Text.Trim() != string.Empty)
                                {
                                    if (xtc.DataBindings.Count > 0)
                                    {
                                        if (xtc.DataBindings[0].FormatString.Trim() != string.Empty)
                                        {
                                            CTRL_ID = xtc.Name;
                                            CTRL_TYPE = "XRTableCell";
                                            ORIGIN = xtc.DataBindings[0].FormatString;
                                            BusinessClass.AddNewMultiLang(strReportName, CTRL_ID, CTRL_TYPE, ORIGIN, strReportName, string.Empty, AppConfig.UserLogin);
                                        }
                                    }
                                    else
                                    {
                                        CTRL_ID = xtc.Name;
                                        CTRL_TYPE = "XRTableCell";
                                        ORIGIN = xtc.Text;
                                        BusinessClass.AddNewMultiLang(strReportName, CTRL_ID, CTRL_TYPE, ORIGIN, strReportName, string.Empty, AppConfig.UserLogin);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion                
    }
}