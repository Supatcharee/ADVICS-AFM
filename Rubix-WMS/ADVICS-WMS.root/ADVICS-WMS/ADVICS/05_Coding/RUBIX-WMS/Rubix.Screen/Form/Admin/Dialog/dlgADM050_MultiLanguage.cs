using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Rubix.Framework;
using System.IO;
using System.Reflection;

namespace Rubix.Screen.Form.Admin.Dialog
{
    public partial class dlgADM050_MultiLanguage : DevExpress.XtraEditors.XtraForm, IMultiLanguage
    {
        #region Member
        private MultiLanguage m_CurrentLanguage = new MultiLanguage();
        private Assembly m_asmCurrentAssembly;
        private MultiLanguageData LangData = new MultiLanguageData();
        #endregion

        #region Properties
        public MultiLanguage CurrentLanguage { get { return m_CurrentLanguage; } set { m_CurrentLanguage = value; } }

        public Assembly CurrentAssembly { get { return m_asmCurrentAssembly; } set { m_asmCurrentAssembly = value; } }
        #endregion

        #region Constructor
        public dlgADM050_MultiLanguage()
        {
            InitializeComponent();
        } 
        #endregion
        
        #region Event Handler
        private void dlgADM050_MultiLanguage_Load(object sender, EventArgs e)
        {
            try
            {
                txtFileName.Text = Application.StartupPath + "\\" + "Rubix.Screen.dll";
                if (CurrentLanguage != null)
                {
                    OnLanguageChange(sender, new LanguageChangeEventArgs(CurrentLanguage));
                }
            }
            catch
            {
                txtFileName.Text = string.Empty;
            }
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (File.Exists(txtFileName.Text))
                {
                    LoadClass(txtFileName.Text, txtFilter.Text);
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            if (CurrentLanguage != null)
            {
                OnLanguageChange(sender, new LanguageChangeEventArgs(CurrentLanguage));
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "Assembly |*.exe;*.dll|All files (*.*)|*.*";
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    txtFileName.Text = dlg.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
            this.Cursor = Cursors.Default;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (File.Exists(txtFileName.Text))
                {
                    LoadClass(txtFileName.Text, txtFilter.Text);
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lv in lstvScreen.Items)
            {
                lv.Checked = true;
            }
        }

        private void btnUnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lv in lstvScreen.Items)
            {
                lv.Checked = false;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        } 

        private void lstvScreen_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            SortOrder order = lstvScreen.Sorting;
            switch (order)
            {
                case SortOrder.None:
                case SortOrder.Ascending:
                    lstvScreen.Sorting = SortOrder.Descending;
                    break;
                case SortOrder.Descending:
                    lstvScreen.Sorting = SortOrder.Ascending;
                    break;
            }
        }

        private void lstvScreen_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                string strSelectForm = e.Item.Text;
                lstvControl.Items.Clear();
                Type[] InnerType = CurrentAssembly.GetTypes();
                foreach (Type t in InnerType)
                {
                    if (t.FullName == strSelectForm)
                    {
                        FieldInfo[] fInfos = t.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
                        foreach (FieldInfo Field in fInfos)
                        {
                            if (Field.FieldType.IsSubclassOf(typeof(System.Windows.Forms.Control)))
                            {
                                ListViewItem li = CreateEmptyListViewItem(lstvControl);
                                li.SubItems[clhControlType.Index].Text = Field.FieldType.Name;
                                li.SubItems[clhControlName.Index].Text = Field.Name;
                                lstvControl.Items.Add(li);
                            }
                        }
                    }
                }
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (File.Exists(txtFileName.Text))
                {
                    LoadClass(txtFileName.Text, txtFilter.Text);
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        #endregion

        #region Generic Function
        public void OnLanguageChange(object sender, LanguageChangeEventArgs e)
        {
            this.Text = e.MultiLanguage.GetText(MultiLanguage.eType.Form, this.Name, "Text", this.Text);
            Util.ChangeLanguage(this.Name, this.Controls, e);            
        }

        private void LoadClass(string strFileName, string strFilter)
        {
            Assembly asm = Assembly.LoadFile(strFileName);
            CurrentAssembly = asm;
            Module[] modules = asm.GetModules();

            lstvScreen.Items.Clear();
            foreach (Module mod in modules)
            {
                try
                {
                    Type[] types = mod.GetTypes();
                    foreach (Type t in types)
                    {
                        if (t == null)
                        {
                            continue;
                        }
                        if (t.IsSubclassOf(typeof(System.Windows.Forms.Form)) || t.IsSubclassOf(typeof(DevExpress.XtraReports.UI.XtraReport)))
                        {
                            if (t.FullName.ToUpper().IndexOf(strFilter.ToUpper()) >= 0)
                            {
                                lstvScreen.Items.Add(t.FullName);
                            }
                        }
                    }
                }
                catch (ReflectionTypeLoadException rtlex)
                {
                    foreach (Type t in rtlex.Types)
                    {
                        if (t == null)
                        {
                            continue;
                        }
                        if (t.IsSubclassOf(typeof(System.Windows.Forms.Form)))
                        {
                            if (t.FullName.IndexOf(strFilter) >= 0)
                            {
                                lstvScreen.Items.Add(t.FullName);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }
        }

        private ListViewItem CreateEmptyListViewItem(ListView listView)
        {
            ListViewItem lv = new ListViewItem();
            for (int i = 1; i < listView.Columns.Count; ++i)
            {
                lv.SubItems.Add(string.Empty);
            }
            return lv;
        }

        public MultiLanguageData GetOutputData()
        {
            LangData = new MultiLanguageData();

            foreach (ListViewItem li in lstvScreen.CheckedItems)
            {
                Type[] InnerType = CurrentAssembly.GetTypes();
                foreach (Type t in InnerType)
                {
                    if (t.FullName == li.SubItems[clhScreenName.Index].Text)
                    {
                        MultiLanguageData.FormData dataForm = new MultiLanguageData.FormData();
                        dataForm.FormName = t.Name;
                        FieldInfo[] fInfos = t.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
                        foreach (FieldInfo Field in fInfos)
                        {
                            if (Field.FieldType.IsSubclassOf(typeof(System.Windows.Forms.Control)))
                            {
                                MultiLanguageData.FormData.ControlData dataControl = new MultiLanguageData.FormData.ControlData();
                                dataControl.ControlName = Field.Name;
                                dataControl.ControlText = "?";
                                dataForm.ArrFormControls.Add(dataControl);
                                //if (Field.FieldType == typeof(FpSpread))
                                //{
                                //    dataControl = new MultiLanguageData.FormData.ControlData();
                                //    dataControl.ControlName = Field.Name + ".Sheet_0.Column_0";
                                //    dataControl.ControlText = "?";
                                //    dataForm.ArrFormControls.Add(dataControl);
                                //    dataControl = new MultiLanguageData.FormData.ControlData();
                                //    dataControl.ControlName = Field.Name + ".Sheet_0.SheetName";
                                //    dataControl.ControlText = "?";
                                //    dataForm.ArrFormControls.Add(dataControl);
                                //}
                            }
                        }
                        LangData.ArrForms.Add(dataForm);
                    }
                }
            }
            return LangData;
        }
        #endregion

    }
}