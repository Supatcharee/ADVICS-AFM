using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraTreeList;
using DevExpress.XtraEditors;
using DevExpress.XtraNavBar;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using DevExpress.XtraBars;
using DevExpress.Utils;
using DevExpress.XtraTab;
using DevExpress.XtraGrid.Views.BandedGrid;
using System.Drawing;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraLayout;
using DevExpress.Utils.Win;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraGrid.Localization;
using DevExpress.XtraEditors.Controls;

namespace Rubix.Framework
{
    public class Util
    {
        #region constant value
        // Multi-Language Screen
        private static string mc_strTextType_Screen = "Screen";
        private static string mc_strTextType_Menu = "Menu";
        private static string mc_strTextType_Global = "Global";

        //DB Multi Langugage
        public const string strLang_English = "en-US";
        public const string strLang_Japanese = "ja-JP";
        public const string strLang_Thai = "th-TH";

        //CurrentLang
        private static string mc_strCurrentLang = string.Empty;

        #endregion

        #region Multi-Language
 
        private static MultiLanguage m_multiLang = new MultiLanguage();
                
        //GetFormText
        /// <summary>
        /// Get Form Text from xml
        /// </summary>
        /// <param name="strFormName">Form Name</param>
        /// <param name="strItemName">Item Name</param>
        /// <returns></returns>
        public static string GetFormText(string strFormName, string strItemName)
        {
            //return m_multiLang.GetText(MultiLanguage.eType.Form, strFormName, strItemName, "NO MSG ID");
            return m_multiLang.GetFormText(strFormName, strItemName, "NO MSG ID");
        }
        /// <summary>
        /// Get Form Text from xml
        /// </summary>
        /// <param name="strFormName">Form Name</param>
        /// <param name="strItemName">Item Name</param>
        /// <param name="strDefaultText">Default Text if not find</param>
        /// <returns></returns>
        public static string GetFormText(string strFormName, string strItemName, string strDefaultText)
        {
            //return m_multiLang.GetText(MultiLanguage.eType.Form, strFormName, strItemName, strDefaultText);
            return m_multiLang.GetFormText(strFormName, strItemName, strDefaultText);
        }

        //GetMenuText
        /// <summary>
        /// Get Menu Text from xml
        /// </summary>
        /// <param name="strItemName">Item Name</param>
        /// <returns></returns>
        public static string GetMenuText(string strItemName)
        {
            //return m_multiLang.GetText(MultiLanguage.eType.Menu, string.Empty, strItemName, "NO MSG ID");
            return m_multiLang.GetMenuText(strItemName, "NO MSG ID");
        }
        /// <summary>
        /// Get Menu Text from xml
        /// </summary>
        /// <param name="strItemName">Item Name</param>
        /// <param name="strDefaultText">Default Text if not find</param>
        /// <returns></returns>
        public static string GetMenuText(string strItemName, string strDefaultText)
        {
            //return m_multiLang.GetText(MultiLanguage.eType.Menu, string.Empty, strItemName, strDefaultText);
            return m_multiLang.GetMenuText(strItemName, strDefaultText);
        }

        //GetGlobalText
        /// <summary>
        /// Get global text from xml
        /// </summary>
        /// <param name="strItemName">Item Name</param>
        /// <returns></returns>
        public static string GetGlobalText(string strMsgNo)
        {
            //return m_multiLang.GetText(MultiLanguage.eType.Global, string.Empty, strMsgNo, "NO MSG ID");
            return m_multiLang.GetGlobalText(strMsgNo, "NO MSG ID");
        }

        /// <summary>
        /// Get global text from xml
        /// </summary>
        /// <param name="strItemName">Item Name</param>
        /// <param name="strDefaultText">Default Text if not find</param>
        /// <returns></returns>
        public static string GetGlobalText(string strMsgNo, string strDefaultText)
        {
            //return m_multiLang.GetText(MultiLanguage.eType.Global, string.Empty, strMsgNo, strDefaultText);
            return m_multiLang.GetGlobalText(strMsgNo, strDefaultText);
        }

        public static string GetGlobalText(string strMsgNo, string strDefaultText, params string[] strParams)
        {
            //return m_multiLang.GetText(MultiLanguage.eType.Global, string.Empty, strMsgNo, strDefaultText);
            return m_multiLang.GetGlobalText(strMsgNo, strDefaultText, strParams);
        }
        
        public static string GetLangDES()
        {
            if (strCurrentLang.Equals("ja-JP"))
            {
                return "DES_JP";
            }
            else if (strCurrentLang.Equals("zh-CN"))
            {
                return "DES_CHN";
            }
            else
            {
                return "DES_ENG";
            }
        }

        public static string GetLangDESC()
        {
            if (strCurrentLang.Equals("ja-JP"))
            {
                return "DESC_JP";
            }
            else if (strCurrentLang.Equals("zh-CN"))
            {
                return "DESC_CHN";
            }
            else
            {
                return "DESC_ENG";
            }
        }

        #endregion

        #region Properties
        public static string strTextType_Screen
        {
            get { return Util.mc_strTextType_Screen; }
            set { Util.mc_strTextType_Screen = value; }
        }
        public static string strTextType_Menu
        {
            get { return Util.mc_strTextType_Menu; }
            set { Util.mc_strTextType_Menu = value; }
        }
        public static string strTextType_Global
        {
            get { return Util.mc_strTextType_Global; }
            set { Util.mc_strTextType_Global = value; }
        }

        public static string strCurrentLang
        {
            get { return Util.mc_strCurrentLang; }
            set { Util.mc_strCurrentLang = value; }
        }
        private static bool m_bLiteMode = false;
        public static bool LiteMode
        {
            get { return m_bLiteMode; }
            set { m_bLiteMode = value; }
        }        
        #endregion
        
        #region CommonFunction
        public static bool IsNull(object data)
        {
            if (data == null || data == DBNull.Value)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string IsNull(DataRow dr, int col, string value)
        {
            if (dr.IsNull(col) || dr.HasErrors)
                return value;
            else
                return dr[col].ToString();

        }

        public static object IsNull(object data, object value)
        {
            if (IsNull(data))
                return value;
            else
                return data;
        }

        public static bool IsNullOrEmpty(object obj)
        {
            if (IsNull(obj) || obj.ToString().Trim().Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static DateTime FirstDayOfMonth(DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, 1);
        }
        #endregion

        #region Multi Language
        public static void ChangeLanguage(string ParentName ,Control.ControlCollection ctrls, LanguageChangeEventArgs e, string Optional = "")
        {
            foreach (Control selectControl in ctrls)
            {
                ChangeLanguage(ParentName, selectControl, e, Optional);
            }
        }

        public static void ChangeLanguage(string ParentName, Control selectControl, LanguageChangeEventArgs e, string Optional = "")
        {
            string CTRL_ID = string.Empty;
            string ORIGIN = string.Empty;

            if (selectControl.GetType() == typeof(TreeList))
            {
                TreeList tl = (TreeList)selectControl;
                for (int i = 0; i < tl.Columns.Count; i++)
                {
                    CTRL_ID = tl.Columns[i].Name;
                    ORIGIN = tl.Columns[i].Caption;
                    tl.Columns[i].Caption = e.MultiLanguage.GetText(MultiLanguage.eType.Form, ParentName, CTRL_ID, ORIGIN);
                }
                if (ParentName == "MainFrameDevEx")
                {
                    for (int i = 0; i < tl.Nodes.Count; i++)
                    {
                        CTRL_ID = tl.Name + "." + tl.Nodes[i].Id.ToString().PadLeft(2, '0');
                        ORIGIN = tl.Nodes[i].GetDisplayText(0);
                        tl.Nodes[i].SetValue(0, e.MultiLanguage.GetText(MultiLanguage.eType.Form, ParentName, CTRL_ID, ORIGIN));

                        if (tl.Nodes[i].HasChildren)
                        {
                            GetTreeChild(ParentName, tl.Nodes[i], CTRL_ID, e);
                        }
                    }
                }
            }
            if (selectControl.GetType() == typeof(GridControl))
            {
                GridControl gc = (GridControl)selectControl;
                for (int sht = 0; sht < gc.Views.Count; sht++)
                {
                    if (gc.Views[sht] is BandedGridView)
                    {
                        BandedGridView bgv = ((BandedGridView)gc.Views[sht]);

                        for (int col = 0; col < bgv.Bands.Count; col++)
                        {
                            //if (bgv.Columns[col].Visible)
                            {
                                CTRL_ID = gc.Name + "." + bgv.Name + "." + bgv.Bands[col].Name;
                                ORIGIN = bgv.Bands[col].Caption;
                                bgv.Bands[col].Caption = e.MultiLanguage.GetText(MultiLanguage.eType.Form, ParentName, CTRL_ID, ORIGIN);
                                bgv.Bands[col].AppearanceHeader.Font = new Font(((GridView)gc.Views[sht]).Appearance.HeaderPanel.Font, FontStyle.Bold);
                                bgv.Bands[col].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;

                                if (bgv.Bands[col].HasChildren)
                                {
                                    GetBandChild(ParentName, ((GridView)gc.Views[sht]), bgv.Bands[col].Children, CTRL_ID, e);
                                }
                                else if (bgv.Bands[col].Columns.Count > 0 && bgv.OptionsView.ShowColumnHeaders)
                                {
                                    for (int i = 0; i < bgv.Bands[col].Columns.Count; i++)
                                    {
                                        //if (bgv.Bands[col].Columns[i].Visible)
                                        {
                                            CTRL_ID = gc.Name + "." + bgv.Name + "." + bgv.Bands[col].Name + "." + bgv.Bands[col].Columns[i].Name;
                                            ORIGIN = bgv.Bands[col].Columns[i].Caption;
                                            bgv.Bands[col].Columns[i].Caption = e.MultiLanguage.GetText(MultiLanguage.eType.Form, ParentName, CTRL_ID, ORIGIN);
                                            bgv.Bands[col].Columns[i].AppearanceHeader.Font = new Font(((GridView)gc.Views[sht]).Appearance.HeaderPanel.Font, FontStyle.Bold);
                                            bgv.Bands[col].Columns[i].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
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
                                    ORIGIN = Util.IsNullOrEmpty(bgv.Columns[col].Caption) ? bgv.Columns[col].Name.Replace("col", "") : bgv.Columns[col].Caption;
                                    bgv.Columns[col].Caption = e.MultiLanguage.GetText(MultiLanguage.eType.Form, ParentName, CTRL_ID, ORIGIN);
                                }
                            }
                        }
                    }
                    else if (gc.Views[sht] is GridView)
                    {
                        GridView grv = ((GridView)gc.Views[sht]);

                        //if (grv.OptionsView.ShowGroupPanel)
                        //{
                        //    grv.GroupPanelText = e.MultiLanguage.GetGlobalText("A0001");
                        //}

                        if (grv.OptionsView.ShowColumnHeaders)
                        {
                            for (int col = 0; col < grv.Columns.Count; col++)
                            {
                                CTRL_ID = gc.Name + "." + grv.Name + "." + grv.Columns[col].Name;
                                ORIGIN = Util.IsNullOrEmpty(grv.Columns[col].Caption) ? grv.Columns[col].Name.Replace("col", "") : grv.Columns[col].Caption;
                                grv.Columns[col].Caption = e.MultiLanguage.GetText(MultiLanguage.eType.Form, ParentName, CTRL_ID, ORIGIN);
                                grv.Columns[col].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                                grv.Columns[col].AppearanceHeader.Font = new Font(grv.Appearance.HeaderPanel.Font, FontStyle.Bold);

                                if (!grv.OptionsView.ColumnAutoWidth)
                                {
                                    try
                                    {
                                        grv.Columns[col].Width = grv.Columns[col].GetBestWidth();
                                    }
                                    catch (Exception)
                                    {
                                    }
                                }
                            }
                        }
                    }
                }
                if (gc.RepositoryItems.Count > 0)
                {
                    foreach (RepositoryItem rep in gc.RepositoryItems)
                    {
                        if (rep.GetType() == typeof(RepositoryItemLookUpEdit))
                        {
                            RepositoryItemLookUpEdit re = (RepositoryItemLookUpEdit)rep;
                            for (int i = 0; i < re.Columns.Count; i++)
                            {
                                CTRL_ID = "RepositoryItem." + re.Name + "." + re.Columns[i].FieldName;
                                ORIGIN = re.Columns[i].Caption;
                                re.Columns[i].Caption = e.MultiLanguage.GetText(MultiLanguage.eType.Form, ParentName, CTRL_ID, ORIGIN);
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
                                        CTRL_ID = re.Name + "." + grv.Name + "." + grv.Columns[col].Name;
                                        ORIGIN = Util.IsNullOrEmpty(grv.Columns[col].Caption) ? grv.Columns[col].Name.Replace("col", "") : grv.Columns[col].Caption;

                                        if (grv.Columns[col].Visible)
                                        {
                                            grv.Columns[col].Caption = e.MultiLanguage.GetText(MultiLanguage.eType.Form, ParentName, CTRL_ID, ORIGIN);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else if (selectControl.GetType() == typeof(NavBarControl))
            {
                NavBarControl nc = (NavBarControl)selectControl;
                foreach (NavBarGroup ng in nc.Groups)
                {
                    CTRL_ID = nc.Name + "." + ng.Name;
                    ORIGIN = ng.Caption;
                    ng.Caption = e.MultiLanguage.GetText(MultiLanguage.eType.Form, ParentName, CTRL_ID, ORIGIN);
                }
            }
            else if (selectControl.GetType() == typeof(BarDockControl))
            {
                BarDockControl bdc = (BarDockControl)selectControl;

                if (bdc.Dock == DockStyle.Bottom && (ParentName == "FormBase" || ParentName == "DialogBase"))
                {
                    for (int i = 0; i < ((DevExpress.XtraBars.Controls.CustomControl)(bdc)).Manager.Bars.Count; i++)
                    {
                        for (int j = 0; j < ((DevExpress.XtraBars.Controls.CustomControl)(bdc)).Manager.Bars[i].LinksPersistInfo.Count; j++)
                        {
                            CTRL_ID = ((DevExpress.XtraBars.Controls.CustomControl)(bdc)).Manager.Bars[i].LinksPersistInfo[j].Item.Name;
                            ORIGIN = ((DevExpress.XtraBars.Controls.CustomControl)(bdc)).Manager.Bars[i].LinksPersistInfo[j].Item.Caption;
                            if (ORIGIN.Trim() != string.Empty && ORIGIN.Trim() != "-")
                            {
                                ((DevExpress.XtraBars.Controls.CustomControl)(bdc)).Manager.Bars[i].LinksPersistInfo[j].Item.Caption = e.MultiLanguage.GetText(MultiLanguage.eType.Form, ParentName, CTRL_ID, ORIGIN);
                            }

                            if (!Util.IsNullOrEmpty(((DevExpress.XtraBars.Controls.CustomControl)(bdc)).Manager.Bars[i].LinksPersistInfo[j].Item.SuperTip))
                            {
                                ToolTipTitleItem toolTipTitleItem = new ToolTipTitleItem();
                                SuperToolTip superToolTip = new SuperToolTip();

                                CTRL_ID = ((DevExpress.XtraBars.Controls.CustomControl)(bdc)).Manager.Bars[i].LinksPersistInfo[j].Item.Name + ".SuperTip";
                                ORIGIN = ((DevExpress.XtraBars.Controls.CustomControl)(bdc)).Manager.Bars[i].LinksPersistInfo[j].Item.SuperTip.ToString();

                                toolTipTitleItem.Text = e.MultiLanguage.GetText(MultiLanguage.eType.Form, ParentName, CTRL_ID, ORIGIN);
                                superToolTip.Items.Add(toolTipTitleItem);

                                ((DevExpress.XtraBars.Controls.CustomControl)(bdc)).Manager.Bars[i].LinksPersistInfo[j].Item.SuperTip = superToolTip;
                            }
                        }
                    }
                }
            }
            else if (selectControl.GetType() == typeof(SimpleButton))
            {
                SimpleButton btn = (SimpleButton)selectControl;
                if (btn.ToolTip.Trim() != string.Empty)
                {
                    CTRL_ID = btn.Name + "." + "ToolTip";
                    ORIGIN = btn.ToolTip.Trim();
                    btn.ToolTip = e.MultiLanguage.GetText(MultiLanguage.eType.Form, ParentName, CTRL_ID, ORIGIN);
                }
                if (btn.Text.Trim() != string.Empty)
                {
                    CTRL_ID = btn.Name + "." + "Text";
                    ORIGIN = btn.Text.Trim();
                    btn.Text = e.MultiLanguage.GetText(MultiLanguage.eType.Form, ParentName, CTRL_ID, ORIGIN);
                }
            }
            else if (selectControl.GetType() == typeof(SearchLookUpEdit))
            {
                SearchLookUpEdit sle = (SearchLookUpEdit)selectControl;

                sle.Popup += SearchLookUpEdit_Popup;

                GridView grv = sle.Properties.View;
                for (int col = 0; col < grv.Columns.Count; col++)
                {
                    CTRL_ID = sle.Name + "." + grv.Name + "." + grv.Columns[col].Name;
                    ORIGIN = Util.IsNullOrEmpty(grv.Columns[col].Caption) ? grv.Columns[col].Name.Replace("col", "") : grv.Columns[col].Caption;
                    grv.Columns[col].Caption = e.MultiLanguage.GetText(MultiLanguage.eType.Form, ParentName, CTRL_ID, ORIGIN);
                    grv.Columns[col].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    grv.Columns[col].AppearanceHeader.Font = new Font(grv.Appearance.HeaderPanel.Font, FontStyle.Bold);

                    if (!grv.OptionsView.ColumnAutoWidth)
                    {
                        try
                        {
                            grv.Columns[col].Width = grv.Columns[col].GetBestWidth();
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
            }
            else if (selectControl.GetType() == typeof(ListView))
            {
                ListView lv = (ListView)selectControl;
                for (int i = 0; i < lv.Columns.Count; i++)
                {
                    CTRL_ID = lv.Name + ".Column[" + i.ToString() + "]";
                    ORIGIN = lv.Columns[i].Text;
                    lv.Columns[i].Text = e.MultiLanguage.GetText(MultiLanguage.eType.Form, ParentName, CTRL_ID, ORIGIN);
                }
            }
            else if (selectControl.GetType() == typeof(XtraTabControl))
            {
                XtraTabControl tc = (XtraTabControl)selectControl;
                foreach (XtraTabPage tp in tc.TabPages)
                {
                    CTRL_ID = tp.Name;
                    ORIGIN = tp.Text;
                    tp.Text = e.MultiLanguage.GetText(MultiLanguage.eType.Form, ParentName, CTRL_ID, ORIGIN);
                    if (tp.HasChildren)
                    {
                        ChangeLanguage(ParentName, tp.Controls, e);
                    }
                }
            }
            else if (selectControl.GetType() == typeof(LookUpEdit))
            {
                LookUpEdit lv = (LookUpEdit)selectControl;

                for (int i = 0; i < lv.Properties.Columns.Count; i++)
                {
                    CTRL_ID = lv.Name + ".Column[" + i.ToString() + "]";
                    ORIGIN = lv.Properties.Columns[i].Caption;
                    lv.Properties.Columns[i].Caption = e.MultiLanguage.GetText(MultiLanguage.eType.Form, ParentName, CTRL_ID, ORIGIN);
                }
            }

            else if (selectControl.GetType().FullName.Contains("Rubix.Control"))
            {
                ChangeLanguage(ParentName, selectControl.Controls, e, selectControl.Name);
            }
            else if (selectControl.GetType() == typeof(RibbonControl) && ParentName == "FormBase")
            {
                RibbonControl rc = (RibbonControl)selectControl;
                for (int i = 0; i < rc.Items.Count; i++)
                {
                    if (rc.Items[i].GetType() == typeof(BarButtonItem))
                    {
                        CTRL_ID = rc.Items[i].Name;
                        ORIGIN = rc.Items[i].GetType().Name;
                        rc.Items[i].Caption = e.MultiLanguage.GetText(MultiLanguage.eType.Form, ParentName, CTRL_ID, ORIGIN);
                    }
                }
            }
            else
            {
                string strType = selectControl.GetType().Name;
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
                     || selectControl is TextEdit
                     || selectControl is UserControl
                     || selectControl is MemoEdit
                     || selectControl is DateEdit
                     || selectControl is System.Windows.Forms.MaskedTextBox))
                {
                    CTRL_ID = (Optional != string.Empty ? Optional + "." : "") + selectControl.Name;
                    ORIGIN = selectControl.Text;
                    if (ORIGIN.Trim() != string.Empty)
                    {
                        selectControl.Text = e.MultiLanguage.GetText(MultiLanguage.eType.Form, ParentName, CTRL_ID, ORIGIN);
                    }
                }
                
                if (selectControl.HasChildren)
                {
                    ChangeLanguage(ParentName, selectControl.Controls, e);
                }
            }
        }

        public static void ChangeLanguageGridChild(string ParentName, GridControl gridControl, LanguageChangeEventArgs e, int RowHandle)
        {
            string CTRL_ID = string.Empty;
            string ORIGIN = string.Empty;

            GridView grv = ((GridView)(((GridView)gridControl.Views[0]).GetDetailView(RowHandle, 0)));
            
            if (grv != null)
            {
                for (int col = 0; col < grv.Columns.Count; col++)
                {
                    CTRL_ID = gridControl.Name + "." + grv.Name + ".DetailView." + grv.Columns[col].Name;
                    ORIGIN = Util.IsNullOrEmpty(grv.Columns[col].GetTextCaption()) ? grv.Columns[col].Name.Replace("col", "") : grv.Columns[col].GetTextCaption();
                    grv.Columns[col].Caption = e.MultiLanguage.GetText(MultiLanguage.eType.Form, ParentName, CTRL_ID, ORIGIN);
                    grv.Columns[col].Width = grv.Columns[col].GetBestWidth();
                }
            }
        }

        public static string ChangeLanguageGridChildRelation(string ParentName, GridControl gridControl, LanguageChangeEventArgs e, int RowHandle)
        {
            string CTRL_ID = string.Empty;
            string ORIGIN = string.Empty;

            GridView grv = (GridView)gridControl.Views[0];
            if (grv != null)
            {
                CTRL_ID = gridControl.Name + "." + grv.Name + ".DetailView.Relation";
                ORIGIN = "User List";
                return e.MultiLanguage.GetText(MultiLanguage.eType.Form, ParentName, CTRL_ID, ORIGIN);
            }
            else
            {
                return "User List";
            }
        }

        public static void ChangeLanguageReport(DevExpress.XtraReports.UI.XtraReport ReportScreen, LanguageChangeEventArgs e)
        {
            string CTRL_ID = string.Empty;
            string ORIGIN = string.Empty;
            string strReportName = ((DevExpress.XtraReports.UI.XtraReportBase)(ReportScreen)).ToString().Replace("Rubix.Screen.Report.", "");

            for (int i = 0; i < ReportScreen.Bands.Count; i++)
            {
                for (int j = 0; j < ReportScreen.Bands[i].Controls.Count; j++)
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
                                ORIGIN = xlbl.DataBindings[0].FormatString;
                                xlbl.DataBindings[0].FormatString = e.MultiLanguage.GetText(MultiLanguage.eType.Form, strReportName, CTRL_ID, ORIGIN);
                            }
                        }
                        else if (!xlbl.Text.Contains("xrLabel") && xlbl.Text.Trim() != string.Empty && xlbl.DataBindings.Count <= 0)
                        {
                            CTRL_ID = xlbl.Name;
                            ORIGIN = xlbl.Text;
                            xlbl.Text = e.MultiLanguage.GetText(MultiLanguage.eType.Form, strReportName, CTRL_ID, ORIGIN);
                        }
                        //}
                    }
                    else if (strControlType == "XRCheckBox")
                    {
                        DevExpress.XtraReports.UI.XRCheckBox xchk = (DevExpress.XtraReports.UI.XRCheckBox)ReportScreen.Bands[i].Controls[j];
                        if (xchk.Text.Trim() != string.Empty)
                        {
                            CTRL_ID = xchk.Name;
                            ORIGIN = xchk.Text;
                            xchk.Text = e.MultiLanguage.GetText(MultiLanguage.eType.Form, strReportName, CTRL_ID, ORIGIN);
                        }
                    }
                    else if (strControlType == "XRTableCell")
                    {
                        DevExpress.XtraReports.UI.XRTableCell xtbc = (DevExpress.XtraReports.UI.XRTableCell)ReportScreen.Bands[i].Controls[j];
                        if (xtbc.Text.Trim() != string.Empty)
                        {
                            CTRL_ID = xtbc.Name;
                            ORIGIN = xtbc.Text;
                            xtbc.Text = e.MultiLanguage.GetText(MultiLanguage.eType.Form, strReportName, CTRL_ID, ORIGIN);
                        }
                    }
                    else if (strControlType == "XRPageInfo")
                    {
                        DevExpress.XtraReports.UI.XRPageInfo xpgi = (DevExpress.XtraReports.UI.XRPageInfo)ReportScreen.Bands[i].Controls[j];
                        if (xpgi.Format.Trim() != string.Empty)
                        {
                            CTRL_ID = xpgi.Name;
                            ORIGIN = xpgi.Format;
                            xpgi.Format = e.MultiLanguage.GetText(MultiLanguage.eType.Form, strReportName, CTRL_ID, ORIGIN);
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
                                            ORIGIN = xtc.DataBindings[0].FormatString;
                                            xtc.DataBindings[0].FormatString = e.MultiLanguage.GetText(MultiLanguage.eType.Form, strReportName, CTRL_ID, ORIGIN);
                                        }
                                    }
                                    else
                                    {
                                        CTRL_ID = xtc.Name;
                                        ORIGIN = xtc.Text;
                                        xtc.Text = e.MultiLanguage.GetText(MultiLanguage.eType.Form, strReportName, CTRL_ID, ORIGIN);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private static void GetTreeChild(string ParentName, TreeListNode tl, string BaseControlName, LanguageChangeEventArgs e)
        {
            string CTRL_ID = string.Empty;
            string ORIGIN = string.Empty;

            for (int i = 0; i < tl.Nodes.Count; i++)
            {
                CTRL_ID = BaseControlName + "." + tl.Nodes[i].Id.ToString().PadLeft(2, '0');
                ORIGIN = tl.Nodes[i].GetDisplayText(0);
                tl.Nodes[i].SetValue(0, e.MultiLanguage.GetText(MultiLanguage.eType.Form, ParentName, CTRL_ID, ORIGIN));

                if (tl.Nodes[i].HasChildren)
                {
                    GetTreeChild(ParentName, tl.Nodes[i], CTRL_ID, e);
                }
            }
        }

        private static void GetBandChild(string ParentName,GridView gdv, GridBandCollection gb, string BaseControlName, LanguageChangeEventArgs e)
        {
            string CTRL_ID = string.Empty;
            string ORIGIN = string.Empty;

            for (int col = 0; col < gb.Count; col++)
            {
                if (gb[col].Visible)
                {
                    CTRL_ID = BaseControlName + "." + gb[col].Name;
                    ORIGIN = gb[col].Caption;
                    gb[col].Caption = e.MultiLanguage.GetText(MultiLanguage.eType.Form, ParentName, CTRL_ID, ORIGIN);
                    gb[col].AppearanceHeader.Font = new Font(gdv.Appearance.HeaderPanel.Font, FontStyle.Bold);
                    gb[col].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;

                    if (gb[col].HasChildren)
                    {
                        GetBandChild(ParentName, gdv, gb[col].Children, CTRL_ID, e);
                    }
                }
            }
        }

        private static void SearchLookUpEdit_Popup(object sender, EventArgs e)
        {
            IPopupControl popupControl = sender as IPopupControl;
            LayoutControl layoutControl = popupControl.PopupWindow.Controls[2].Controls[0] as LayoutControl;
            SimpleButton clearButton = ((LayoutControlItem)layoutControl.Items.FindByName("lciClear")).Control as SimpleButton;
            SimpleButton findButton = ((LayoutControlItem)layoutControl.Items.FindByName("lciButtonFind")).Control as SimpleButton;
            SimpleButton addButton = ((LayoutControlItem)layoutControl.Items.FindByName("lciAddNew")).Control as SimpleButton;

            if (clearButton != null)
            {
                clearButton.Text = GetMenuText("Clear", "Clear");
                clearButton.Image = Properties.Resources.Clear;
            }

            if (findButton != null)
            {
                findButton.Text = GetMenuText("Find", "Find");
                findButton.Image = Properties.Resources.Find;
            }

            if (addButton != null)
            {
                addButton.Text = GetMenuText("AddNew", "Add New");
                addButton.Image = Properties.Resources.AddNew;
            }
            
        }
        #endregion

    }

    public class GridLocalizerLanguage : GridLocalizer
    {
        public override string GetLocalizedString(GridStringId id)
        {
            string ret = "";
            switch (id)
            {
                // ...  
                case GridStringId.GridGroupPanelText: return Util.GetGlobalText("A0001");
                case GridStringId.MenuColumnSortAscending: return Util.GetMenuText("SortAscending", "Sort Ascending");
                case GridStringId.MenuColumnSortDescending: return Util.GetMenuText("SortDescending", "Sort Descending");
                case GridStringId.MenuColumnClearSorting: return Util.GetMenuText("ClearSorting", "Clear Sorting");
                case GridStringId.MenuColumnGroup: return Util.GetMenuText("GroupByThisColumn", "Group By This Column");
                case GridStringId.MenuGroupPanelHide: return Util.GetMenuText("HideGroupByBox", "Hide Group By Box");
                case GridStringId.MenuGroupPanelShow: return Util.GetMenuText("ShowGroupByBox", "Show Group By Box");
                case GridStringId.MenuColumnRemoveColumn: return Util.GetMenuText("RemoveThisColumn", "Remove This Column");
                case GridStringId.MenuColumnColumnCustomization: return Util.GetMenuText("ColumnChooser", "Column Chooser");
                case GridStringId.MenuColumnBandCustomization: return Util.GetMenuText("MenuColumnBandCustomization", "Column/Band Chooser");
                case GridStringId.MenuColumnBestFit: return Util.GetMenuText("BestFit", "Best Fit");
                case GridStringId.MenuColumnBestFitAllColumns: return Util.GetMenuText("BestFitAll", "Best Fit (all columns)");
                case GridStringId.MenuColumnFilterEditor: return Util.GetMenuText("FilterEditor", "Filter Editor...");
                case GridStringId.MenuColumnFindFilterShow: return Util.GetMenuText("ShowFindPanel", "Show Find Panel");
                case GridStringId.MenuColumnFindFilterHide: return Util.GetMenuText("HideFindPanel", "Hide Find Panel");
                case GridStringId.MenuColumnAutoFilterRowShow: return Util.GetMenuText("ShowAutoFilterRow", "Show Auto Filter Row");
                case GridStringId.MenuColumnAutoFilterRowHide: return Util.GetMenuText("HideAutoFilterRow", "Hide Auto Filter Row");

                case GridStringId.MenuGroupPanelFullExpand: return Util.GetMenuText("FullExpand", "Full Expand");
                case GridStringId.MenuGroupPanelFullCollapse: return Util.GetMenuText("FullCollaps", "Full Collaps");
                case GridStringId.MenuColumnUnGroup: return Util.GetMenuText("UnGroup", "UnGroup");
                case GridStringId.MenuGroupPanelClearGrouping: return Util.GetMenuText("ClearGrouping", "Clear Grouping");
                case GridStringId.MenuColumnFilter: return Util.GetMenuText("ColumnFilter", "Column Filter");
                case GridStringId.MenuColumnClearFilter: return Util.GetMenuText("ClearFilter", "Clear Filter");

                case GridStringId.FindControlFindButton: return Util.GetMenuText("Find", "Find");
                case GridStringId.FindControlClearButton: return Util.GetMenuText("Clear", "Clear");

                //Column band chooser
                case GridStringId.CustomizationCaption: return Util.GetMenuText("CustomizationCaption", "Customization");
                case GridStringId.CustomizationColumns: return Util.GetMenuText("CustomizationColumns", "Columns");
                case GridStringId.CustomizationBands: return Util.GetMenuText("CustomizationBands", "Bands");
                case GridStringId.CustomizationFormColumnHint: return Util.GetMenuText("CustomizationFormColumnHint", "Drag and drop columns here to customize layout");
                case GridStringId.CustomizationFormBandHint: return Util.GetMenuText("CustomizationFormBandHint", "Drag and drop bands here to customize layout");

                //Filter Editor button
                case GridStringId.FilterBuilderOkButton: return Util.GetMenuText("OK", "OK");
                case GridStringId.FilterBuilderCancelButton: return Util.GetMenuText("Cancel", "Cancel");
                case GridStringId.FilterBuilderApplyButton: return Util.GetMenuText("Apply", "Apply");
                case GridStringId.FilterBuilderCaption: return Util.GetMenuText("FilterEditor", "Filter Editor");

                //Footer Summary
                case GridStringId.MenuFooterAddSummaryItem: return Util.GetMenuText("AddNewSummary", "Add New Summary");
                case GridStringId.MenuFooterAverage: return Util.GetMenuText("Average", "Average");
                case GridStringId.MenuFooterCount: return Util.GetMenuText("Count", "Count");
                case GridStringId.MenuFooterMax: return Util.GetMenuText("Max", "Max");
                case GridStringId.MenuFooterMin: return Util.GetMenuText("Min", "Min");
                case GridStringId.MenuFooterSum: return Util.GetMenuText("Sum", "Sum");
                case GridStringId.MenuFooterNone: return Util.GetMenuText("None", "None");

                ///Filter Grid
                case GridStringId.PopupFilterCustom: return Util.GetMenuText("PopupFilterCustom", "(Custom)");
                case GridStringId.PopupFilterNonBlanks: return Util.GetMenuText("PopupFilterNonBlanks", "(Non blanks)");
                case GridStringId.PopupFilterBlanks: return Util.GetMenuText("PopupFilterBlanks", "(Blanks)");
                case GridStringId.PopupFilterAll: return Util.GetMenuText("PopupFilterAll", "(All)");
                ///Custom Filter (Custom)
                case GridStringId.FilterPanelCustomizeButton: return Util.GetMenuText("FilterPanelCustomizeButton", "Edit Filter");
                case GridStringId.CustomFilterDialogOkButton: return Util.GetMenuText("CustomFilterDialogOkButton", "&OK");
                case GridStringId.CustomFilterDialogEmptyValue: return Util.GetMenuText("CustomFilterDialogEmptyValue", "(Enter a value)");
                case GridStringId.CustomFilterDialogFormCaption: return Util.GetMenuText("CustomFilterDialogFormCaption", "Custom AutoFilter");
                case GridStringId.CustomFilterDialogCaption: return Util.GetMenuText("CustomFilterDialogCaption", "Show rows Where:");
                case GridStringId.CustomFilterDialogRadioOr: return Util.GetMenuText("CustomFilterDialogRadioOr", "O&r");
                case GridStringId.CustomFilterDialogRadioAnd: return Util.GetMenuText("CustomFilterDialogRadioAnd", "&And");
                case GridStringId.CustomFilterDialogCancelButton: return Util.GetMenuText("CustomFilterDialogCancelButton", "&Cancel");
                case GridStringId.CustomFilterDialogEmptyOperator: return Util.GetMenuText("CustomFilterDialogEmptyOperator", "(Select an operator)");
                case GridStringId.CustomFilterDialogHint: return Util.GetMenuText("CustomFilterDialogHint", "Use _ to represent any single character#Use % to represent any series of characters");

                //// ...  
                default:
                    ret = base.GetLocalizedString(id);
                    break;
            }
            return ret;
        }
    }

    public class EditorsLocalizerLanguage : Localizer
    {
        public override string GetLocalizedString(StringId id)
        {
            switch (id)
            {
                // ... 
                case StringId.TextEditMenuCopy: return Util.GetMenuText("Copy", "Copy");
                case StringId.TextEditMenuCut: return Util.GetMenuText("Cut", "Cut");
                case StringId.TextEditMenuDelete: return Util.GetMenuText("Delete", "Delete");
                case StringId.TextEditMenuPaste: return Util.GetMenuText("Paste", "Paste");
                case StringId.TextEditMenuSelectAll: return Util.GetMenuText("SelectAll", "Select All");
                case StringId.TextEditMenuUndo: return Util.GetMenuText("Undo", "Undo");

                case StringId.XtraMessageBoxAbortButtonText: return Util.GetMenuText("Abort", "Abort");
                case StringId.XtraMessageBoxCancelButtonText: return Util.GetMenuText("Cancel", "Cancel");
                case StringId.XtraMessageBoxIgnoreButtonText: return Util.GetMenuText("Ignore", "Ignore");
                case StringId.XtraMessageBoxNoButtonText: return Util.GetMenuText("No", "No");
                case StringId.XtraMessageBoxOkButtonText: return Util.GetMenuText("OK", "OK");
                case StringId.XtraMessageBoxRetryButtonText: return Util.GetMenuText("Retry", "Retry");
                case StringId.XtraMessageBoxYesButtonText: return Util.GetMenuText("Yes", "Yes");

                case StringId.FilterMenuClearAll: return Util.GetMenuText("ClearAll", "Clear All");
                case StringId.FilterMenuConditionAdd: return Util.GetMenuText("AddCondition", "Add Condition");
                case StringId.FilterMenuGroupAdd: return Util.GetMenuText("AddGroup", "Add Group");
                case StringId.FilterMenuRowRemove: return Util.GetMenuText("RemoveGroup", "Remove Group");
                case StringId.FilterGroupAnd: return Util.GetMenuText("And", "And");
                case StringId.FilterGroupNotAnd: return Util.GetMenuText("NotAnd", "Not And");
                case StringId.FilterGroupNotOr: return Util.GetMenuText("NotOr", "Not Or");
                case StringId.FilterGroupOr: return Util.GetMenuText("Or", "Or");

                case StringId.FilterToolTipKeysAdd: return Util.GetMenuText("ToolTipKeysAdd", "(Use the Insert or Add key)");
                case StringId.FilterToolTipNodeAdd: return Util.GetMenuText("ToolTipNodeAdd", "Adds a new condition to this group");
                case StringId.FilterToolTipKeysRemove: return Util.GetMenuText("ToolTipKeysRemove", "(Use the Delete or Subtract key)");
                case StringId.FilterToolTipNodeRemove: return Util.GetMenuText("ToolTipNodeRemove", "Removes this condition");
                case StringId.FilterEmptyEnter: return Util.GetMenuText("EnterAValue", "enter a value");

                case StringId.FilterClauseAnyOf: return Util.GetMenuText("IsAnyOf", "Is any of");
                case StringId.FilterClauseBeginsWith: return Util.GetMenuText("BeginsWith", "Begins with");
                case StringId.FilterClauseBetween: return Util.GetMenuText("IsBetween", "Is between");
                case StringId.FilterClauseBetweenAnd: return Util.GetMenuText("And", "And");
                case StringId.FilterClauseContains: return Util.GetMenuText("Contains", "Contains");
                case StringId.FilterClauseDoesNotContain: return Util.GetMenuText("DoesNotContain", "Does not contain");
                case StringId.FilterClauseDoesNotEqual: return Util.GetMenuText("DoesNotEqual", "Does not equal");
                case StringId.FilterClauseEndsWith: return Util.GetMenuText("EndsWith", "Ends with");
                case StringId.FilterClauseEquals: return Util.GetMenuText("Equals", "Equals");
                case StringId.FilterClauseGreater: return Util.GetMenuText("IsGreaterThan", "Is greater than");
                case StringId.FilterClauseGreaterOrEqual: return Util.GetMenuText("IsGreaterThanOrEqualTo", "Is greater than or equal to");
                case StringId.FilterClauseIsNull: return Util.GetMenuText("IsNull", "Is null");
                case StringId.FilterClauseIsNotNull: return Util.GetMenuText("IsNotNull", "Is not null");
                case StringId.FilterClauseIsNotNullOrEmpty: return Util.GetMenuText("IsNotBlank", "Is not blank");
                case StringId.FilterClauseIsNullOrEmpty: return Util.GetMenuText("IsBlank", "Is blank");
                case StringId.FilterClauseLess: return Util.GetMenuText("IsLessThan", "Is less than");
                case StringId.FilterClauseLessOrEqual: return Util.GetMenuText("IsLessThanOrEqualTo", "Is less than or equal to");
                case StringId.FilterClauseLike: return Util.GetMenuText("IsLike", "Is like");
                case StringId.FilterClauseNoneOf: return Util.GetMenuText("IsNoneOf", "Is none of");
                case StringId.FilterClauseNotBetween: return Util.GetMenuText("IsNotBetween", "Is not between");
                case StringId.FilterClauseNotLike: return Util.GetMenuText("IsNotLike", "Is not like");

                //Filter Editor Date and time operators
                case StringId.FilterDateTimeOperatorMenuCaption: return Util.GetMenuText("DateTimeOperator", "Date and time operators");
                case StringId.FilterCriteriaToStringFunctionIsOutlookIntervalBeyondThisYear: return Util.GetMenuText("IsBeyondThisYear", "Is beyond this year");
                case StringId.FilterCriteriaToStringFunctionIsOutlookIntervalLaterThisYear: return Util.GetMenuText("IsLaterThisYear", "Is later this year");
                case StringId.FilterCriteriaToStringFunctionIsOutlookIntervalEarlierThisYear: return Util.GetMenuText("IsEarlierThisYear", "Is earlier this year");
                case StringId.FilterCriteriaToStringFunctionIsOutlookIntervalPriorThisYear: return Util.GetMenuText("IsPriorThisYear", "Is prior this year");
                case StringId.FilterCriteriaToStringFunctionIsOutlookIntervalLaterThisMonth: return Util.GetMenuText("IsLaterThisMonth", "Is later this month");
                case StringId.FilterCriteriaToStringFunctionIsOutlookIntervalEarlierThisMonth: return Util.GetMenuText("IsEarlierThisMonth", "Is earlier this month");
                case StringId.FilterCriteriaToStringFunctionIsOutlookIntervalNextWeek: return Util.GetMenuText("IsNextWeek", "Is next week");
                case StringId.FilterCriteriaToStringFunctionIsOutlookIntervalLaterThisWeek: return Util.GetMenuText("IsLaterThisWeek", "Is later this week");
                case StringId.FilterCriteriaToStringFunctionIsOutlookIntervalLastWeek: return Util.GetMenuText("IsLastWeek", "Is last week");
                case StringId.FilterCriteriaToStringFunctionIsOutlookIntervalEarlierThisWeek: return Util.GetMenuText("IsEarlierThisWeek", "Is earlier this week");
                case StringId.FilterCriteriaToStringFunctionIsOutlookIntervalToday: return Util.GetMenuText("IsToday", "Is today");
                case StringId.FilterCriteriaToStringFunctionIsOutlookIntervalTomorrow: return Util.GetMenuText("IsTomorrow", "Is tomorrow");
                case StringId.FilterCriteriaToStringFunctionIsOutlookIntervalYesterday: return Util.GetMenuText("IsYesterday", "Is yesterday");

                default:
                    return base.GetLocalizedString(id);
                    break;
                //... 
            }
            return "";
        }
    }
}
