using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Rubix.Framework;
using CSI.Business.Operation;
using DevExpress.XtraGrid;
using CSI.Business.DataObjects;

namespace Rubix.Screen.Form.Operation.E_Stocktaking.Dialog
{
    public partial class dlgESTS060_SpaceUtilization : DialogBase
    {
        #region Member
        private WarehouseUtilization db;
        #endregion

        #region Properties
        public CSI.Business.Master.LocationGraphic LocationInformationDetail { get; set; }
        #endregion
        
        #region Construntor
        public dlgESTS060_SpaceUtilization()
        {
            InitializeComponent();
            base.GridViewControl = new GridControl[] { grdSearchResult };
            ControlUtil.HiddenControl(true, m_toolBarSave, m_toolBarClear, m_toolBarSaveACopy, m_toolBarPrint);
            base.HideStatusBar();
        } 
        #endregion

        #region Event Handler
        private void dlgESTS060_SpaceUtilization_Load(object sender, EventArgs e)
        {
            grdSearchResult.DataSource = LocationInformationDetail.LocationInformation;

            //convert to display 
            int x, y;
            List<VirtualRack> rackList = new List<VirtualRack>();
            int blockSize = 20;

            lblLocation.Text = string.Format(lblLocation.Text, LocationInformationDetail.LocationCode, LocationInformationDetail.LocationName);
            lblZone.Text = string.Format(lblZone.Text, LocationInformationDetail.ZoneCode, LocationInformationDetail.ZoneName);
            lblType.Text = string.Format(lblType.Text, LocationInformationDetail.Type);
            
            foreach (DataRow dr in LocationInformationDetail.LocationInformation.Rows)
            {
                virtualLane1.HasLevel = (dr["Type"].ToString() == "On Floor" ? false : true);
                if (virtualLane1.HasLevel)
                {
                    if (dr["LocationCode"].ToString().Length > 5)
                    {
                        string[] xAndY = dr["LocationCode"].ToString().Substring(dr["LocationCode"].ToString().Length - 5, 5).Split('-');
                        if (xAndY.Length == 2)
                        {
                            if (Int32.TryParse(xAndY[0], out x) && Int32.TryParse(xAndY[1], out y))
                            {
                                rackList.Add(new VirtualRack(x, y, blockSize, Convert.ToInt32(dr["LocationID"]), dr["LocationCode"].ToString()
                                    , Convert.ToDecimal(dr["FullCapacity"])
                                    , Convert.ToDecimal(dr["UsageCapacity"])
                                    , Convert.ToDecimal(dr["FullUnit"])
                                    , Convert.ToDecimal(dr["UsageUnit"])
                                    , Convert.ToInt32(dr["FullCapacityFlag"]) == 1
                                    , Convert.ToInt32(dr["MaxLevel"])
                                    , Common.QtyFormat
                                    , Common.PercentFormat));
                            }
                        }
                    }
                }
                else
                    rackList.Add(new VirtualRack(1, 1, blockSize, Convert.ToInt32(dr["LocationID"]), dr["LocationCode"].ToString()
                                    , Convert.ToDecimal(dr["FullCapacity"])
                                    , Convert.ToDecimal(dr["UsageCapacity"])
                                    , Convert.ToDecimal(dr["FullUnit"])
                                    , Convert.ToDecimal(dr["UsageUnit"])
                                    , Convert.ToInt32(dr["FullCapacityFlag"]) == 1
                                    , Convert.ToInt32(dr["MaxLevel"])
                                    , Common.QtyFormat
                                    , Common.PercentFormat));
            }
            virtualLane1.Datasource = rackList;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (gdvSearchResult.RowCount > 0)
                {
                    SaveFileDialog saveFile = new SaveFileDialog();
                    saveFile.AddExtension = true;
                    saveFile.CheckPathExists = true;
                    saveFile.DefaultExt = "xlsx";
                    saveFile.Filter = "Excel Workbook (*.xlsx)|*.xlsx|Excel 97-2003 Workbook (*.xls)|*.xls";
                    saveFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                    if (saveFile.ShowDialog() == DialogResult.OK)
                    {
                        gdvSearchResult.OptionsPrint.AutoWidth = false;
                        gdvSearchResult.BestFitColumns();
                        gdvSearchResult.OptionsPrint.PrintHeader = gdvSearchResult.OptionsView.ShowColumnHeaders;

                        if (saveFile.FilterIndex == 1)
                        {
                            gdvSearchResult.ExportToXlsx(saveFile.FileName);
                        }
                        else if (saveFile.FilterIndex == 2)
                        {
                            gdvSearchResult.ExportToXls(saveFile.FileName);
                        }
                        Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                        excel.Visible = true;
                        excel.Workbooks.Open(saveFile.FileName);
                    }
                }
                else
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0333"));
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }
        #endregion
    }
}
