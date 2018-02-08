using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Rubix.Framework;
using DevExpress.XtraEditors;

namespace Rubix.Control
{
    public partial class VirtualLane : DevExpress.XtraEditors.XtraUserControl
    {
        #region Member
        private List<VirtualRack> rackList = null;
        private int paddingLeft = 5;
        private int paddingTop = -20;
        private int maxLevel;
        private int maxRack;
        private int blockSize;
        private int minRack;
        #endregion

        #region Properties
        [DefaultValue("#,##0.000")]
        public string QtyFormat { get; set; }
        [DefaultValue("#,##0.00")]
        public string PercentFormat { get; set; }
        [DefaultValue(true)]
        public bool HasLevel{get;set;}
        public List<VirtualRack> Datasource
        {
            get
            {
                return rackList;
            }
            set
            {
                rackList = value;
                CreateVirtualLand();
            }
        }
        SimpleButton NewButton
        {
            get
            {
                SimpleButton button = new SimpleButton();
                button.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
                button.AllowDrop = false;
                button.TabStop = false;
                button.AllowFocus = false;
                return button;
            }
        }
        #endregion

        #region Constructor
        public VirtualLane()
        {
            InitializeComponent();
        }
        #endregion

        #region Event Handler
        private void VirtualLane_Load(object sender, EventArgs e)
        {

        } 
        #endregion

        #region Generic Function
        private void CreateVirtualLand()
        {
            try
            {
                if (rackList == null || rackList.Count <= 0)
                {
                    return;
                }
                pnDrawing.SuspendLayout();
                if (HasLevel) //For Rack
                {
                    maxRack = rackList.Max(c => c.X);
                    maxLevel = rackList.Max(c => c.Level);
                    minRack = maxRack;
                    blockSize = rackList[0].BlockSize;
                    foreach (VirtualRack vl in rackList)
                    {
                        if (vl.X < minRack)
                        {
                            minRack = vl.X;
                        }

                        ///////แกน X แนวนอน
                        //x * vl.BlockSize หาว่ากล่องจะอยู่ตำแหน่งไหน
                        //+ paddingLeft เว้นขอบซ้าย
                        //- (x - 1) ให้ขอบของกล่องซ้อนทับกัน
                        ////////////////////////////////////////////
                        ///////แกน Y แนวตั้ง
                        //y * vl.BlockSize หาจุดล่างสุดที่ต้องวาดกล่องก่อน แล้วย้อนขึ้น
                        //+ paddingTop เว้นขอบบน
                        //+ (maxLevel - y) ให้กล่องแต่ละแถวซ้อนกัน
                        ////////////////////////////////////////////
                        int x = vl.X - minRack + 1; //ถ้า min ไม่เท่ากับ 1
                        int y = maxLevel - vl.Y + 1; //หาตำแหน่งที่กล่องอยู่ 1 คือตัวล่างสุด

                        CreateButton((x * vl.BlockSize) + paddingLeft - (x - 1),
                                        (y * vl.BlockSize) + paddingTop + (maxLevel - y),
                                        vl.GetColor(),
                                        vl.BlockSize,
                                        vl.LocationCode,
                                        vl.UsageCapacity,
                                        vl.MaxCapacity,
                                        vl.UsageUnit,
                                        vl.MaxUnit);   
                    }
                }
                else //For Floor
                {
                    maxLevel = rackList.Max(c => c.Level);
                    maxRack = (rackList.Max(c => c.MaxUnit).HasValue ? (int)rackList.Max(c => c.MaxUnit).Value : 0) / maxLevel;
                    minRack = 1;
                    VirtualRack vl = rackList[0];
                    decimal? usage = vl.UsageUnit;
                    blockSize = vl.BlockSize;
                    for (int y = maxLevel; y >= 1; y--)
                    {
                        for (int x = 1; x <= maxRack; x++)
                        {
                            ///////แกน X แนวนอน
                            //x * vl.BlockSize หาว่ากล่องจะอยู่ตำแหน่งไหน
                            //+ paddingLeft เว้นขอบซ้าย
                            //- (x - 1) ให้ขอบของกล่องซ้อนทับกัน
                            ////////////////////////////////////////////
                            ///////แกน Y แนวตั้ง
                            //y * vl.BlockSize หาจุดล่างสุดที่ต้องวาดกล่องก่อน แล้วย้อนขึ้น
                            //+ paddingTop เว้นขอบบน
                            //+ (maxLevel - y) ให้กล่องแต่ละแถวซ้อนกัน
                            ////////////////////////////////////////////
                            CreateButton((x * vl.BlockSize) + paddingLeft - (x - 1), 
                                         (y * vl.BlockSize) + paddingTop + (maxLevel - y),
                                         vl.GetColor(),
                                         vl.BlockSize,
                                         vl.LocationCode,
                                         vl.UsageCapacity,
                                         vl.MaxCapacity,
                                         vl.UsageUnit,
                                         vl.MaxUnit);                            

                            if (vl.UsageUnit.HasValue && vl.UsageUnit.Value > 0)
                            {
                                vl.UsageUnit -= 1;
                            }
                        }
                    }
                    //เอา UsageUnit เดิมกลับมา
                    vl.UsageUnit = usage;                    
                }

                //วาดขอบล่างสุด
                for (int x = 1; x <= (maxRack - minRack + 1); x++)
                {
                    Point point = new Point((x * blockSize) + paddingLeft - (x - 1), (maxLevel * blockSize) - 1);
                    Size size = new Size(blockSize, blockSize);
                    SimpleButton button = NewButton;
                    button.Location = point;
                    button.Size = size;
                    button.Appearance.BackColor = Color.LightGray;
                    if (HasLevel)
                    {
                        button.Text = (minRack + x - 1).ToString();
                    }
                    pnDrawing.Controls.Add(button);
                }
                //วาดขอบซ้ายมือสุด
                for (int y = maxLevel; y >= 1; y--)
                {
                    Point point = new Point(paddingLeft + 1, (y * blockSize) + paddingTop + (maxLevel - y));
                    Size size = new Size(blockSize, blockSize);
                    SimpleButton button = NewButton;
                    button.Location = point;
                    button.Size = size;
                    button.Appearance.BackColor = Color.LightGray;
                    if (HasLevel)
                    {
                        button.Text = (maxLevel - y + 1).ToString();
                    }
                    pnDrawing.Controls.Add(button);
                }
                pnDrawing.ResumeLayout();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void CreateButton(int X, int Y, Color color, int iBlockSize, string LocationCode, decimal? UsageCapacity, decimal? MaxCapacity, decimal? UsageUnit, decimal? MaxUnit)
        {
            Point point = new Point(X,Y);
            Size size = new Size(iBlockSize, iBlockSize);

            SimpleButton button = NewButton;

            button.Location = point;
            button.Size = size;
            button.Appearance.BackColor = color;

            DevExpress.Utils.SuperToolTip superToolTip = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem ttTitleItemHeader = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem ttItemContent = new DevExpress.Utils.ToolTipItem();
            ttTitleItemHeader.Text = String.Format("Location Code: {0}", LocationCode);
            ttItemContent.LeftIndent = 6;
            ttItemContent.Text = string.Format("Usage Capacity: {0:" + QtyFormat + "} / {1:" + QtyFormat + "} ({2:" + PercentFormat + "}%)\r\nUsage Unit: {3:" + QtyFormat + "} / {4:" + QtyFormat + "} ({5:" + PercentFormat + "}%)"
                                                , UsageCapacity
                                                , MaxCapacity
                                                , (UsageCapacity / MaxCapacity) * 100
                                                , UsageUnit
                                                , MaxUnit
                                                , (UsageUnit / MaxUnit) * 100);
            superToolTip.Items.Add(ttTitleItemHeader);
            superToolTip.Items.Add(ttItemContent);
            button.SuperTip = superToolTip;

            pnDrawing.Controls.Add(button);
        }
        #endregion
        
    }
}
