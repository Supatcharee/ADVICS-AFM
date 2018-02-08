namespace StartUp.MainFrame
{
    partial class MainMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.barManager1 = new DevExpress.XtraBars.BarManager();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager();
            this.dcpMenu = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.trlMenuList = new DevExpress.XtraTreeList.TreeList();
            this.tlcMenuName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tlcScreenID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tclClassName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.imgMenuList = new System.Windows.Forms.ImageList();
            this.nbcMenu = new DevExpress.XtraNavBar.NavBarControl();
            this.rgbiSkins = new DevExpress.XtraBars.RibbonGalleryBarItem();
            this.ribbonGalleryBarItem1 = new DevExpress.XtraBars.RibbonGalleryBarItem();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.bsUserLogin = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem2 = new DevExpress.XtraBars.BarStaticItem();
            this.bsScreenName = new DevExpress.XtraBars.BarStaticItem();
            this.bsLastestDailyPost = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.bsDatabase = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem3 = new DevExpress.XtraBars.BarStaticItem();
            this.bsProgramVersion = new DevExpress.XtraBars.BarStaticItem();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.barButtonGroup1 = new DevExpress.XtraBars.BarButtonGroup();
            this.docMgr = new DevExpress.XtraBars.Docking2010.DocumentManager();
            this.tabbedView1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelControl6 = new DevExpress.XtraEditors.PanelControl();
            this.btnSkin = new DevExpress.XtraEditors.SimpleButton();
            this.btnLogout = new DevExpress.XtraEditors.SimpleButton();
            this.btnChangePassword = new DevExpress.XtraEditors.SimpleButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnThaiLang = new DevExpress.XtraEditors.SimpleButton();
            this.btnEngLishLang = new DevExpress.XtraEditors.SimpleButton();
            this.btnJapanLang = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.splashScreenMgr = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::StartUp.MainFrame.WaitFormMainManager), true, true);
            this.imgGroupList = new System.Windows.Forms.ImageList();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dcpMenu.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trlMenuList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbcMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docMgr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar2,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.DockManager = this.dockManager1;
            this.barManager1.Form = this;
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 0;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.Text = "Tools";
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 1;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            this.bar3.Visible = false;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1008, 51);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 560);
            this.barDockControlBottom.Size = new System.Drawing.Size(1008, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 51);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 509);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1008, 51);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 509);
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.MenuManager = this.barManager1;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dcpMenu});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
            this.dockManager1.StartDocking += new DevExpress.XtraBars.Docking.DockPanelCancelEventHandler(this.dockManager1_StartDocking);
            // 
            // dcpMenu
            // 
            this.dcpMenu.Controls.Add(this.dockPanel1_Container);
            this.dcpMenu.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dcpMenu.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dcpMenu.ID = new System.Guid("cb717c92-ff83-47f8-a766-aaf920c9abb2");
            this.dcpMenu.Location = new System.Drawing.Point(0, 98);
            this.dcpMenu.Name = "dcpMenu";
            this.dcpMenu.Options.AllowDockBottom = false;
            this.dcpMenu.Options.AllowDockFill = false;
            this.dcpMenu.Options.AllowDockRight = false;
            this.dcpMenu.Options.AllowDockTop = false;
            this.dcpMenu.Options.AllowFloating = false;
            this.dcpMenu.Options.FloatOnDblClick = false;
            this.dcpMenu.Options.ShowCloseButton = false;
            this.dcpMenu.Options.ShowMaximizeButton = false;
            this.dcpMenu.OriginalSize = new System.Drawing.Size(200, 200);
            this.dcpMenu.Size = new System.Drawing.Size(200, 435);
            this.dcpMenu.Text = "Menu";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.trlMenuList);
            this.dockPanel1_Container.Controls.Add(this.nbcMenu);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(192, 408);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // trlMenuList
            // 
            this.trlMenuList.ActiveFilterEnabled = false;
            this.trlMenuList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trlMenuList.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.tlcMenuName,
            this.tlcScreenID,
            this.tclClassName});
            this.trlMenuList.KeyFieldName = "SCREENID";
            this.trlMenuList.Location = new System.Drawing.Point(0, 0);
            this.trlMenuList.Name = "trlMenuList";
            this.trlMenuList.OptionsBehavior.AutoChangeParent = false;
            this.trlMenuList.OptionsBehavior.AutoNodeHeight = false;
            this.trlMenuList.OptionsBehavior.AutoSelectAllInEditor = false;
            this.trlMenuList.OptionsBehavior.CloseEditorOnLostFocus = false;
            this.trlMenuList.OptionsBehavior.Editable = false;
            this.trlMenuList.OptionsBehavior.KeepSelectedOnClick = false;
            this.trlMenuList.OptionsBehavior.PopulateServiceColumns = true;
            this.trlMenuList.OptionsBehavior.ResizeNodes = false;
            this.trlMenuList.OptionsBehavior.SmartMouseHover = false;
            this.trlMenuList.OptionsFilter.AllowFilterEditor = false;
            this.trlMenuList.OptionsMenu.EnableFooterMenu = false;
            this.trlMenuList.OptionsPrint.PrintHorzLines = false;
            this.trlMenuList.OptionsPrint.PrintVertLines = false;
            this.trlMenuList.OptionsPrint.UsePrintStyles = true;
            this.trlMenuList.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.trlMenuList.OptionsView.ShowFocusedFrame = false;
            this.trlMenuList.OptionsView.ShowHorzLines = false;
            this.trlMenuList.OptionsView.ShowIndicator = false;
            this.trlMenuList.OptionsView.ShowVertLines = false;
            this.trlMenuList.Size = new System.Drawing.Size(192, 131);
            this.trlMenuList.StateImageList = this.imgMenuList;
            this.trlMenuList.TabIndex = 1;
            this.trlMenuList.GetStateImage += new DevExpress.XtraTreeList.GetStateImageEventHandler(this.trlMenuList_GetStateImage);
            this.trlMenuList.PopupMenuShowing += new DevExpress.XtraTreeList.PopupMenuShowingEventHandler(this.trlMenuList_PopupMenuShowing);
            this.trlMenuList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trlMenu_MouseDown);
            // 
            // tlcMenuName
            // 
            this.tlcMenuName.AppearanceCell.BackColor = System.Drawing.Color.Transparent;
            this.tlcMenuName.AppearanceCell.BackColor2 = System.Drawing.Color.Transparent;
            this.tlcMenuName.AppearanceCell.BorderColor = System.Drawing.Color.Transparent;
            this.tlcMenuName.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlcMenuName.AppearanceCell.Options.UseBackColor = true;
            this.tlcMenuName.AppearanceCell.Options.UseBorderColor = true;
            this.tlcMenuName.AppearanceCell.Options.UseFont = true;
            this.tlcMenuName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.tlcMenuName.AppearanceHeader.Options.UseFont = true;
            this.tlcMenuName.Caption = "Menu";
            this.tlcMenuName.FieldName = "DisplayName";
            this.tlcMenuName.MinWidth = 52;
            this.tlcMenuName.Name = "tlcMenuName";
            this.tlcMenuName.OptionsColumn.AllowEdit = false;
            this.tlcMenuName.OptionsColumn.AllowFocus = false;
            this.tlcMenuName.OptionsColumn.AllowMove = false;
            this.tlcMenuName.OptionsColumn.AllowMoveToCustomizationForm = false;
            this.tlcMenuName.OptionsColumn.AllowSort = false;
            this.tlcMenuName.OptionsFilter.AllowAutoFilter = false;
            this.tlcMenuName.OptionsFilter.AllowFilter = false;
            this.tlcMenuName.Visible = true;
            this.tlcMenuName.VisibleIndex = 0;
            // 
            // tlcScreenID
            // 
            this.tlcScreenID.Caption = "Screen ID";
            this.tlcScreenID.FieldName = "ScreenID";
            this.tlcScreenID.Name = "tlcScreenID";
            // 
            // tclClassName
            // 
            this.tclClassName.Caption = "Class Name";
            this.tclClassName.FieldName = "ClassName";
            this.tclClassName.Name = "tclClassName";
            // 
            // imgMenuList
            // 
            this.imgMenuList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgMenuList.ImageStream")));
            this.imgMenuList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgMenuList.Images.SetKeyName(0, "m_Customer.png");
            this.imgMenuList.Images.SetKeyName(1, "m_Final.png");
            this.imgMenuList.Images.SetKeyName(2, "m_Item.png");
            this.imgMenuList.Images.SetKeyName(3, "m_ItemClassification.png");
            this.imgMenuList.Images.SetKeyName(4, "m_ItemCondition.png");
            this.imgMenuList.Images.SetKeyName(5, "m_ItemGroup.png");
            this.imgMenuList.Images.SetKeyName(6, "m_Location.png");
            this.imgMenuList.Images.SetKeyName(7, "m_Owner.png");
            this.imgMenuList.Images.SetKeyName(8, "m_Packaging.png");
            this.imgMenuList.Images.SetKeyName(9, "m_Port.png");
            this.imgMenuList.Images.SetKeyName(10, "m_Shipping.png");
            this.imgMenuList.Images.SetKeyName(11, "m_Supplier.png");
            this.imgMenuList.Images.SetKeyName(12, "m_TransportationType.png");
            this.imgMenuList.Images.SetKeyName(13, "m_TransportationUnstaffing.png");
            this.imgMenuList.Images.SetKeyName(14, "m_Truck.png");
            this.imgMenuList.Images.SetKeyName(15, "m_Type.png");
            this.imgMenuList.Images.SetKeyName(16, "m_Warehouse.png");
            this.imgMenuList.Images.SetKeyName(17, "m_Zone.png");
            this.imgMenuList.Images.SetKeyName(18, "O_AdjustmentStock.png");
            this.imgMenuList.Images.SetKeyName(19, "O_ChangeLocation.png");
            this.imgMenuList.Images.SetKeyName(20, "O_ConfirmPicking.png");
            this.imgMenuList.Images.SetKeyName(21, "O_ConfirmReceiving.png");
            this.imgMenuList.Images.SetKeyName(22, "O_ConfirmReturnShipping.png");
            this.imgMenuList.Images.SetKeyName(23, "O_ConfirmShipping.png");
            this.imgMenuList.Images.SetKeyName(24, "O_ConfirmTransit.png");
            this.imgMenuList.Images.SetKeyName(25, "O_ConfirmUnplanPicking.png");
            this.imgMenuList.Images.SetKeyName(26, "O_ConfirmUnplanReceiving.png");
            this.imgMenuList.Images.SetKeyName(27, "O_DeliveryOrder.png");
            this.imgMenuList.Images.SetKeyName(28, "O_History.png");
            this.imgMenuList.Images.SetKeyName(29, "O_InventoryInquiry.png");
            this.imgMenuList.Images.SetKeyName(30, "O_OrderCancel.png");
            this.imgMenuList.Images.SetKeyName(31, "O_OrderManagement.png");
            this.imgMenuList.Images.SetKeyName(32, "O_OrderRefresh.png");
            this.imgMenuList.Images.SetKeyName(33, "O_OverallHistoryView.png");
            this.imgMenuList.Images.SetKeyName(34, "O_Picking.png");
            this.imgMenuList.Images.SetKeyName(35, "O_PickingArrangement.png");
            this.imgMenuList.Images.SetKeyName(36, "O_Receiving&ShippingHistory.png");
            this.imgMenuList.Images.SetKeyName(37, "O_Receiving.png");
            this.imgMenuList.Images.SetKeyName(38, "O_ReceivingInstruction.png");
            this.imgMenuList.Images.SetKeyName(39, "O_ReceivingPlan.png");
            this.imgMenuList.Images.SetKeyName(40, "O_ReceivingPlanList.png");
            this.imgMenuList.Images.SetKeyName(41, "O_ReceivingPlanPreparation.png");
            this.imgMenuList.Images.SetKeyName(42, "O_ReceivingProgress.png");
            this.imgMenuList.Images.SetKeyName(43, "O_Shipping.png");
            this.imgMenuList.Images.SetKeyName(44, "O_ShippingPlan.png");
            this.imgMenuList.Images.SetKeyName(45, "O_ShippingPlanPreparation.png");
            this.imgMenuList.Images.SetKeyName(46, "O_ShippingProgress.png");
            this.imgMenuList.Images.SetKeyName(47, "O_SpaceUtilization.png");
            this.imgMenuList.Images.SetKeyName(48, "O_StockControlProcess.png");
            this.imgMenuList.Images.SetKeyName(49, "O_StockPreview.png");
            this.imgMenuList.Images.SetKeyName(50, "O_StockTaking.png");
            this.imgMenuList.Images.SetKeyName(51, "O_TransferPlanPreparation.png");
            this.imgMenuList.Images.SetKeyName(52, "O_TransitService.png");
            this.imgMenuList.Images.SetKeyName(53, "O_Transportation.png");
            this.imgMenuList.Images.SetKeyName(54, "O_WorkProgress.png");
            this.imgMenuList.Images.SetKeyName(55, "O_TransportationInquiry.png");
            this.imgMenuList.Images.SetKeyName(56, "R_ChargeReport.png");
            this.imgMenuList.Images.SetKeyName(57, "R_EstimatePrice.png");
            this.imgMenuList.Images.SetKeyName(58, "R_InventoryCheckList.png");
            this.imgMenuList.Images.SetKeyName(59, "R_InventoryUsage.png");
            this.imgMenuList.Images.SetKeyName(60, "R_Movement.png");
            this.imgMenuList.Images.SetKeyName(61, "R_OrderBalance.png");
            this.imgMenuList.Images.SetKeyName(62, "R_PutAway.png");
            this.imgMenuList.Images.SetKeyName(63, "R_Receiving.png");
            this.imgMenuList.Images.SetKeyName(64, "R_ReceivingPlanList.png");
            this.imgMenuList.Images.SetKeyName(65, "R_ShippingDelivery.png");
            this.imgMenuList.Images.SetKeyName(66, "R_SlowMovement.png");
            this.imgMenuList.Images.SetKeyName(67, "R_StockCard.png");
            this.imgMenuList.Images.SetKeyName(68, "A_ForceRunProcess.png");
            this.imgMenuList.Images.SetKeyName(69, "A_MultiLanguage.png");
            this.imgMenuList.Images.SetKeyName(70, "A_SecurityMapping.png");
            this.imgMenuList.Images.SetKeyName(71, "A_SystemConfig.png");
            this.imgMenuList.Images.SetKeyName(72, "A_UserGroup.png");
            this.imgMenuList.Images.SetKeyName(73, "A_UserMaintenance.png");
            this.imgMenuList.Images.SetKeyName(74, "A_UserWebMaintenance.png");
            this.imgMenuList.Images.SetKeyName(75, "A_PurgeManagement.png");
            this.imgMenuList.Images.SetKeyName(76, "m_Currency.png");
            this.imgMenuList.Images.SetKeyName(77, "m_CompanyCalendar.png");
            this.imgMenuList.Images.SetKeyName(78, "m_Pallet.png");
            this.imgMenuList.Images.SetKeyName(79, "m_PurchasePrice.png");
            this.imgMenuList.Images.SetKeyName(80, "m_SalePrice.png");
            this.imgMenuList.Images.SetKeyName(81, "O_SalesOrder.png");
            this.imgMenuList.Images.SetKeyName(82, "O_CheckingSaleOrder.png");
            this.imgMenuList.Images.SetKeyName(83, "O_ConfirmPacking.png");
            this.imgMenuList.Images.SetKeyName(84, "O_Packing.png");
            this.imgMenuList.Images.SetKeyName(85, "O_PackingArragement.png");
            this.imgMenuList.Images.SetKeyName(86, "O_PurchaseOrder.png");
            this.imgMenuList.Images.SetKeyName(87, "O_PurchaseOrderEntry.png");
            this.imgMenuList.Images.SetKeyName(88, "O_ExportDocument.png");
            this.imgMenuList.Images.SetKeyName(89, "m_TransportCalendar.png");
            this.imgMenuList.Images.SetKeyName(90, "O_ConfirmSaleOrder.png");
            this.imgMenuList.Images.SetKeyName(91, "O_ContainerManagement.png");
            this.imgMenuList.Images.SetKeyName(92, "m_Privilege.png");
            this.imgMenuList.Images.SetKeyName(93, "R_QRCode.png");
            this.imgMenuList.Images.SetKeyName(94, "O_ShippingPlanList.png");
            this.imgMenuList.Images.SetKeyName(95, "O_QCCheckingList.png");
            // 
            // nbcMenu
            // 
            this.nbcMenu.ActiveGroup = null;
            this.nbcMenu.AllowDrop = false;
            this.nbcMenu.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.nbcMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nbcMenu.DragDropFlags = DevExpress.XtraNavBar.NavBarDragDrop.None;
            this.nbcMenu.ExplorerBarShowGroupButtons = false;
            this.nbcMenu.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nbcMenu.Location = new System.Drawing.Point(0, 0);
            this.nbcMenu.Name = "nbcMenu";
            this.nbcMenu.OptionsNavPane.ExpandedWidth = 196;
            this.nbcMenu.OptionsNavPane.ShowExpandButton = false;
            this.nbcMenu.OptionsNavPane.ShowOverflowButton = false;
            this.nbcMenu.OptionsNavPane.ShowOverflowPanel = false;
            this.nbcMenu.OptionsNavPane.ShowSplitter = false;
            this.nbcMenu.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.nbcMenu.SelectLinkOnPress = false;
            this.nbcMenu.ShowGroupHint = false;
            this.nbcMenu.ShowLinkHint = false;
            this.nbcMenu.Size = new System.Drawing.Size(192, 408);
            this.nbcMenu.StoreDefaultPaintStyleName = true;
            this.nbcMenu.TabIndex = 0;
            this.nbcMenu.Text = "navBarControl1";
            this.nbcMenu.GroupExpanded += new DevExpress.XtraNavBar.NavBarGroupEventHandler(this.nbcMenu_GroupExpanded);
            // 
            // rgbiSkins
            // 
            this.rgbiSkins.Caption = "Skins";
            // 
            // rgbiSkins
            // 
            this.rgbiSkins.Gallery.AllowHoverImages = true;
            this.rgbiSkins.Gallery.Appearance.ItemCaptionAppearance.Normal.Options.UseFont = true;
            this.rgbiSkins.Gallery.Appearance.ItemCaptionAppearance.Normal.Options.UseTextOptions = true;
            this.rgbiSkins.Gallery.Appearance.ItemCaptionAppearance.Normal.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.rgbiSkins.Gallery.ColumnCount = 4;
            this.rgbiSkins.Gallery.FixedHoverImageSize = false;
            this.rgbiSkins.Gallery.ImageSize = new System.Drawing.Size(32, 17);
            this.rgbiSkins.Gallery.ItemImageLocation = DevExpress.Utils.Locations.Top;
            this.rgbiSkins.Gallery.RowCount = 4;
            this.rgbiSkins.Id = 60;
            this.rgbiSkins.Name = "rgbiSkins";
            // 
            // ribbonGalleryBarItem1
            // 
            this.ribbonGalleryBarItem1.Caption = "Skins";
            // 
            // ribbonGalleryBarItem1
            // 
            this.ribbonGalleryBarItem1.Gallery.AllowHoverImages = true;
            this.ribbonGalleryBarItem1.Gallery.Appearance.ItemCaptionAppearance.Normal.Options.UseFont = true;
            this.ribbonGalleryBarItem1.Gallery.Appearance.ItemCaptionAppearance.Normal.Options.UseTextOptions = true;
            this.ribbonGalleryBarItem1.Gallery.Appearance.ItemCaptionAppearance.Normal.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ribbonGalleryBarItem1.Gallery.ColumnCount = 4;
            this.ribbonGalleryBarItem1.Gallery.FixedHoverImageSize = false;
            this.ribbonGalleryBarItem1.Gallery.ImageSize = new System.Drawing.Size(32, 17);
            this.ribbonGalleryBarItem1.Gallery.ItemImageLocation = DevExpress.Utils.Locations.Top;
            this.ribbonGalleryBarItem1.Gallery.RowCount = 4;
            this.ribbonGalleryBarItem1.Id = 60;
            this.ribbonGalleryBarItem1.Name = "ribbonGalleryBarItem1";
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.ItemLinks.Add(this.bsUserLogin);
            this.ribbonStatusBar1.ItemLinks.Add(this.barStaticItem2);
            this.ribbonStatusBar1.ItemLinks.Add(this.bsScreenName);
            this.ribbonStatusBar1.ItemLinks.Add(this.bsLastestDailyPost);
            this.ribbonStatusBar1.ItemLinks.Add(this.barStaticItem1);
            this.ribbonStatusBar1.ItemLinks.Add(this.bsDatabase);
            this.ribbonStatusBar1.ItemLinks.Add(this.barStaticItem3);
            this.ribbonStatusBar1.ItemLinks.Add(this.bsProgramVersion);
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 533);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(1008, 27);
            // 
            // bsUserLogin
            // 
            this.bsUserLogin.Caption = "Admin";
            this.bsUserLogin.Glyph = ((System.Drawing.Image)(resources.GetObject("bsUserLogin.Glyph")));
            this.bsUserLogin.Id = 1;
            this.bsUserLogin.Name = "bsUserLogin";
            this.bsUserLogin.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barStaticItem2
            // 
            this.barStaticItem2.Caption = "|";
            this.barStaticItem2.Id = 10;
            this.barStaticItem2.Name = "barStaticItem2";
            this.barStaticItem2.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // bsScreenName
            // 
            this.bsScreenName.Caption = "MAS010: User Maintenance";
            this.bsScreenName.Glyph = ((System.Drawing.Image)(resources.GetObject("bsScreenName.Glyph")));
            this.bsScreenName.Id = 7;
            this.bsScreenName.Name = "bsScreenName";
            this.bsScreenName.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // bsLastestDailyPost
            // 
            this.bsLastestDailyPost.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.bsLastestDailyPost.Caption = "Latest daily post on : {0}";
            this.bsLastestDailyPost.Glyph = ((System.Drawing.Image)(resources.GetObject("bsLastestDailyPost.Glyph")));
            this.bsLastestDailyPost.Id = 15;
            this.bsLastestDailyPost.Name = "bsLastestDailyPost";
            this.bsLastestDailyPost.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barStaticItem1.Caption = "|";
            this.barStaticItem1.Id = 17;
            this.barStaticItem1.Name = "barStaticItem1";
            this.barStaticItem1.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // bsDatabase
            // 
            this.bsDatabase.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.bsDatabase.Caption = "Server/IMS";
            this.bsDatabase.Glyph = ((System.Drawing.Image)(resources.GetObject("bsDatabase.Glyph")));
            this.bsDatabase.Id = 12;
            this.bsDatabase.Name = "bsDatabase";
            this.bsDatabase.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barStaticItem3
            // 
            this.barStaticItem3.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barStaticItem3.Caption = "|";
            this.barStaticItem3.Id = 13;
            this.barStaticItem3.Name = "barStaticItem3";
            this.barStaticItem3.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // bsProgramVersion
            // 
            this.bsProgramVersion.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.bsProgramVersion.Caption = "Version: 1.0.0.0";
            this.bsProgramVersion.Glyph = ((System.Drawing.Image)(resources.GetObject("bsProgramVersion.Glyph")));
            this.bsProgramVersion.Id = 11;
            this.bsProgramVersion.Name = "bsProgramVersion";
            this.bsProgramVersion.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // ribbonControl1
            // 
            // 
            // 
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.ExpandCollapseItem.Name = "";
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.bsUserLogin,
            this.bsScreenName,
            this.barStaticItem2,
            this.bsProgramVersion,
            this.bsDatabase,
            this.barStaticItem3,
            this.barEditItem1,
            this.bsLastestDailyPost,
            this.barButtonGroup1,
            this.barStaticItem1});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 51);
            this.ribbonControl1.MaxItemId = 18;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1});
            this.ribbonControl1.Size = new System.Drawing.Size(1008, 47);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            this.ribbonControl1.Visible = false;
            // 
            // barEditItem1
            // 
            this.barEditItem1.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barEditItem1.Caption = "barEditItem1";
            this.barEditItem1.Edit = this.repositoryItemTextEdit1;
            this.barEditItem1.Id = 14;
            this.barEditItem1.Name = "barEditItem1";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // barButtonGroup1
            // 
            this.barButtonGroup1.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barButtonGroup1.Caption = "barButtonGroup1";
            this.barButtonGroup1.Id = 16;
            this.barButtonGroup1.Name = "barButtonGroup1";
            // 
            // docMgr
            // 
            this.docMgr.MdiParent = this;
            this.docMgr.MenuManager = this.barManager1;
            this.docMgr.View = this.tabbedView1;
            this.docMgr.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.tabbedView1});
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.ContentImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.panelControl1.Controls.Add(this.panelControl3);
            this.panelControl1.Controls.Add(this.panel3);
            this.panelControl1.Controls.Add(this.panel1);
            this.panelControl1.Controls.Add(this.panel2);
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.LookAndFeel.SkinName = "Liquid Sky";
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1009, 51);
            this.panelControl1.TabIndex = 10;
            // 
            // panelControl3
            // 
            this.panelControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl3.Location = new System.Drawing.Point(690, -1);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(3, 58);
            this.panelControl3.TabIndex = 93;
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel3.BackgroundImage")));
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Location = new System.Drawing.Point(5, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(141, 39);
            this.panel3.TabIndex = 99;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.panelControl6);
            this.panel1.Controls.Add(this.btnSkin);
            this.panel1.Controls.Add(this.btnLogout);
            this.panel1.Controls.Add(this.btnChangePassword);
            this.panel1.Location = new System.Drawing.Point(838, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(171, 48);
            this.panel1.TabIndex = 0;
            // 
            // panelControl6
            // 
            this.panelControl6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl6.Location = new System.Drawing.Point(15, -5);
            this.panelControl6.Name = "panelControl6";
            this.panelControl6.Size = new System.Drawing.Size(3, 58);
            this.panelControl6.TabIndex = 92;
            // 
            // btnSkin
            // 
            this.btnSkin.AllowFocus = false;
            this.btnSkin.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnSkin.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.btnSkin.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.btnSkin.Appearance.ForeColor = System.Drawing.Color.Transparent;
            this.btnSkin.Appearance.Options.UseBackColor = true;
            this.btnSkin.Appearance.Options.UseBorderColor = true;
            this.btnSkin.Appearance.Options.UseForeColor = true;
            this.btnSkin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSkin.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnSkin.Image = ((System.Drawing.Image)(resources.GetObject("btnSkin.Image")));
            this.btnSkin.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnSkin.Location = new System.Drawing.Point(27, 6);
            this.btnSkin.Name = "btnSkin";
            this.btnSkin.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnSkin.Size = new System.Drawing.Size(34, 34);
            this.btnSkin.TabIndex = 2;
            this.btnSkin.TabStop = false;
            this.btnSkin.ToolTip = "Theme Selection";
            this.btnSkin.Click += new System.EventHandler(this.btnSkin_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.AllowFocus = false;
            this.btnLogout.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnLogout.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.btnLogout.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.btnLogout.Appearance.ForeColor = System.Drawing.Color.Transparent;
            this.btnLogout.Appearance.Options.UseBackColor = true;
            this.btnLogout.Appearance.Options.UseBorderColor = true;
            this.btnLogout.Appearance.Options.UseForeColor = true;
            this.btnLogout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnLogout.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnLogout.Image = ((System.Drawing.Image)(resources.GetObject("btnLogout.Image")));
            this.btnLogout.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnLogout.Location = new System.Drawing.Point(120, 6);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnLogout.Size = new System.Drawing.Size(34, 34);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.TabStop = false;
            this.btnLogout.ToolTip = "Logout";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.AllowFocus = false;
            this.btnChangePassword.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnChangePassword.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.btnChangePassword.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.btnChangePassword.Appearance.ForeColor = System.Drawing.Color.Transparent;
            this.btnChangePassword.Appearance.Options.UseBackColor = true;
            this.btnChangePassword.Appearance.Options.UseBorderColor = true;
            this.btnChangePassword.Appearance.Options.UseForeColor = true;
            this.btnChangePassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnChangePassword.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnChangePassword.Image = ((System.Drawing.Image)(resources.GetObject("btnChangePassword.Image")));
            this.btnChangePassword.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnChangePassword.Location = new System.Drawing.Point(74, 6);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnChangePassword.Size = new System.Drawing.Size(34, 34);
            this.btnChangePassword.TabIndex = 0;
            this.btnChangePassword.TabStop = false;
            this.btnChangePassword.ToolTip = "Change Password";
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.btnThaiLang);
            this.panel2.Controls.Add(this.btnEngLishLang);
            this.panel2.Controls.Add(this.btnJapanLang);
            this.panel2.Location = new System.Drawing.Point(698, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(324, 48);
            this.panel2.TabIndex = 1;
            // 
            // btnThaiLang
            // 
            this.btnThaiLang.AllowFocus = false;
            this.btnThaiLang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThaiLang.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnThaiLang.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.btnThaiLang.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.btnThaiLang.Appearance.ForeColor = System.Drawing.Color.Transparent;
            this.btnThaiLang.Appearance.Options.UseBackColor = true;
            this.btnThaiLang.Appearance.Options.UseBorderColor = true;
            this.btnThaiLang.Appearance.Options.UseForeColor = true;
            this.btnThaiLang.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnThaiLang.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnThaiLang.Image = global::StartUp.Properties.Resources.Thai_Flag;
            this.btnThaiLang.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnThaiLang.Location = new System.Drawing.Point(11, 6);
            this.btnThaiLang.Name = "btnThaiLang";
            this.btnThaiLang.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnThaiLang.Size = new System.Drawing.Size(34, 34);
            this.btnThaiLang.TabIndex = 3;
            this.btnThaiLang.TabStop = false;
            this.btnThaiLang.ToolTip = "Thai";
            this.btnThaiLang.Click += new System.EventHandler(this.btnThaiLang_Click);
            // 
            // btnEngLishLang
            // 
            this.btnEngLishLang.AllowFocus = false;
            this.btnEngLishLang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEngLishLang.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnEngLishLang.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.btnEngLishLang.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.btnEngLishLang.Appearance.ForeColor = System.Drawing.Color.Transparent;
            this.btnEngLishLang.Appearance.Options.UseBackColor = true;
            this.btnEngLishLang.Appearance.Options.UseBorderColor = true;
            this.btnEngLishLang.Appearance.Options.UseForeColor = true;
            this.btnEngLishLang.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnEngLishLang.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnEngLishLang.Image = global::StartUp.Properties.Resources.english_flag;
            this.btnEngLishLang.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnEngLishLang.Location = new System.Drawing.Point(100, 6);
            this.btnEngLishLang.Name = "btnEngLishLang";
            this.btnEngLishLang.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnEngLishLang.Size = new System.Drawing.Size(34, 34);
            this.btnEngLishLang.TabIndex = 5;
            this.btnEngLishLang.TabStop = false;
            this.btnEngLishLang.ToolTip = "English";
            this.btnEngLishLang.Click += new System.EventHandler(this.btnEngLishLang_Click);
            // 
            // btnJapanLang
            // 
            this.btnJapanLang.AllowFocus = false;
            this.btnJapanLang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnJapanLang.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnJapanLang.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.btnJapanLang.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.btnJapanLang.Appearance.ForeColor = System.Drawing.Color.Transparent;
            this.btnJapanLang.Appearance.Options.UseBackColor = true;
            this.btnJapanLang.Appearance.Options.UseBorderColor = true;
            this.btnJapanLang.Appearance.Options.UseForeColor = true;
            this.btnJapanLang.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnJapanLang.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnJapanLang.Image = global::StartUp.Properties.Resources.flag_japanese;
            this.btnJapanLang.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnJapanLang.Location = new System.Drawing.Point(56, 6);
            this.btnJapanLang.Name = "btnJapanLang";
            this.btnJapanLang.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnJapanLang.Size = new System.Drawing.Size(34, 34);
            this.btnJapanLang.TabIndex = 4;
            this.btnJapanLang.TabStop = false;
            this.btnJapanLang.ToolTip = "Japanese";
            this.btnJapanLang.Click += new System.EventHandler(this.btnJapanLang_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl2.Location = new System.Drawing.Point(-120, 49);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1249, 3);
            this.panelControl2.TabIndex = 91;
            // 
            // imgGroupList
            // 
            this.imgGroupList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgGroupList.ImageStream")));
            this.imgGroupList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgGroupList.Images.SetKeyName(0, "Admin.png");
            this.imgGroupList.Images.SetKeyName(1, "Master.png");
            this.imgGroupList.Images.SetKeyName(2, "Operation.png");
            this.imgGroupList.Images.SetKeyName(3, "Report.png");
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 583);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.dcpMenu);
            this.Controls.Add(this.ribbonControl1);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.LookAndFeel.SkinName = "Xmas 2008 Blue";
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Warehouse Management System (WMS)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainMenu_FormClosed);
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.MdiChildActivate += new System.EventHandler(this.MainMenu_MdiChildActivate);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dcpMenu.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trlMenuList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbcMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docMgr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.RibbonGalleryBarItem rgbiSkins;
        private DevExpress.XtraBars.RibbonGalleryBarItem ribbonGalleryBarItem1;
        private System.Windows.Forms.ImageList imgMenuList;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dcpMenu;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraNavBar.NavBarControl nbcMenu;
        private DevExpress.XtraTreeList.TreeList trlMenuList;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcMenuName;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarStaticItem bsUserLogin;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarStaticItem bsScreenName;
        private DevExpress.XtraBars.BarStaticItem barStaticItem2;
        private DevExpress.XtraBars.BarStaticItem bsProgramVersion;
        private DevExpress.XtraBars.BarStaticItem bsDatabase;
        private DevExpress.XtraBars.BarStaticItem barStaticItem3;
        private DevExpress.XtraBars.Docking2010.DocumentManager docMgr;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnSkin;
        private DevExpress.XtraEditors.SimpleButton btnLogout;
        private DevExpress.XtraEditors.SimpleButton btnChangePassword;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.SimpleButton btnThaiLang;
        private DevExpress.XtraEditors.SimpleButton btnEngLishLang;
        private DevExpress.XtraEditors.SimpleButton btnJapanLang;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl6;
        private System.Windows.Forms.Panel panel3;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraBars.BarStaticItem bsLastestDailyPost;
        private DevExpress.XtraBars.BarButtonGroup barButtonGroup1;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private System.Windows.Forms.ImageList imgGroupList;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcScreenID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tclClassName;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenMgr;

    }
}

