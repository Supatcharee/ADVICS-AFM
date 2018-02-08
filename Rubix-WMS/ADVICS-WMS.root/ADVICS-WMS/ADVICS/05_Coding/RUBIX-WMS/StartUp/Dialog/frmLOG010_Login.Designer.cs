namespace StartUp.Dialog
{
    partial class frmLOG010_Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLOG010_Login));
            this.timer1 = new System.Windows.Forms.Timer();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.checkEdit2 = new DevExpress.XtraEditors.CheckEdit();
            this.errorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider();
            this.splashScreenManager = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::StartUp.MainFrame.WaitFormMainManager), true, true);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.cboDomainServerName = new DevExpress.XtraEditors.LookUpEdit();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtUsername = new DevExpress.XtraEditors.TextEdit();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.btnLogin = new DevExpress.XtraEditors.SimpleButton();
            this.pnlTheme = new System.Windows.Forms.Panel();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.pnlExit = new System.Windows.Forms.Panel();
            this.pnlOption = new System.Windows.Forms.Panel();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.lblTime = new DevExpress.XtraEditors.LabelControl();
            this.pnlDefaultOption = new DevExpress.XtraEditors.GroupControl();
            this.txtDisplayPeriod = new DevExpress.XtraEditors.TextEdit();
            this.lblDisplayPeriodMonth = new DevExpress.XtraEditors.LabelControl();
            this.chkDefaultPassword = new DevExpress.XtraEditors.CheckEdit();
            this.chkDefaultUser = new DevExpress.XtraEditors.CheckEdit();
            this.pnlSerial = new System.Windows.Forms.Panel();
            this.lblSerial = new DevExpress.XtraEditors.LabelControl();
            this.lblSystemName = new DevExpress.XtraEditors.LabelControl();
            this.lblProgramVersion = new DevExpress.XtraEditors.LabelControl();
            this.lblDomainName = new DevExpress.XtraEditors.LabelControl();
            this.lblAvailbleUpdate = new DevExpress.XtraEditors.LabelControl();
            this.panal2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gpcWebAPIURL = new DevExpress.XtraEditors.GroupControl();
            this.btnWebAPIURLOK = new DevExpress.XtraEditors.SimpleButton();
            this.txtWebAPIURL = new DevExpress.XtraEditors.TextEdit();
            this.lblWebAPIUTL = new DevExpress.XtraEditors.LabelControl();
            this.timerScreenEffice = new System.Windows.Forms.Timer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDomainServerName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDefaultOption)).BeginInit();
            this.pnlDefaultOption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDisplayPeriod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDefaultPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDefaultUser.Properties)).BeginInit();
            this.panal2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gpcWebAPIURL)).BeginInit();
            this.gpcWebAPIURL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtWebAPIURL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // checkEdit1
            // 
            this.checkEdit1.EditValue = true;
            this.checkEdit1.Location = new System.Drawing.Point(109, 26);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "Remember User name";
            this.checkEdit1.Size = new System.Drawing.Size(147, 19);
            this.checkEdit1.TabIndex = 2;
            // 
            // checkEdit2
            // 
            this.checkEdit2.Location = new System.Drawing.Point(109, 51);
            this.checkEdit2.Name = "checkEdit2";
            this.checkEdit2.Properties.Caption = "Remember Password";
            this.checkEdit2.Size = new System.Drawing.Size(147, 19);
            this.checkEdit2.TabIndex = 3;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // cboDomainServerName
            // 
            this.cboDomainServerName.Location = new System.Drawing.Point(377, 204);
            this.cboDomainServerName.Name = "cboDomainServerName";
            this.cboDomainServerName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDomainServerName.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboDomainServerName.Properties.Appearance.Options.UseFont = true;
            this.cboDomainServerName.Properties.Appearance.Options.UseForeColor = true;
            this.cboDomainServerName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDomainServerName.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DomainName", 100, "Domain Name")});
            this.cboDomainServerName.Properties.NullText = "";
            this.cboDomainServerName.Size = new System.Drawing.Size(175, 20);
            this.cboDomainServerName.TabIndex = 2;
            this.cboDomainServerName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Location = new System.Drawing.Point(15, 11);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(330, 173);
            this.panel2.TabIndex = 24;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.labelControl1.Location = new System.Drawing.Point(278, 147);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(88, 16);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "User ID";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(255, 174);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(111, 20);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "Password";
            // 
            // txtUsername
            // 
            this.txtUsername.EditValue = "";
            this.txtUsername.Location = new System.Drawing.Point(377, 145);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtUsername.Properties.Appearance.Options.UseFont = true;
            this.txtUsername.Properties.Appearance.Options.UseForeColor = true;
            this.txtUsername.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtUsername.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUsername.Size = new System.Drawing.Size(175, 20);
            this.txtUsername.TabIndex = 0;
            this.txtUsername.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // txtPassword
            // 
            this.txtPassword.EditValue = "";
            this.txtPassword.Location = new System.Drawing.Point(377, 174);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPassword.Properties.Appearance.Options.UseFont = true;
            this.txtPassword.Properties.Appearance.Options.UseForeColor = true;
            this.txtPassword.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtPassword.Properties.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(175, 20);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // btnLogin
            // 
            this.btnLogin.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnLogin.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.btnLogin.Appearance.BorderColor = System.Drawing.Color.Silver;
            this.btnLogin.Appearance.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.btnLogin.Appearance.Options.UseBackColor = true;
            this.btnLogin.Appearance.Options.UseBorderColor = true;
            this.btnLogin.Appearance.Options.UseFont = true;
            this.btnLogin.Appearance.Options.UseForeColor = true;
            this.btnLogin.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.Image = ((System.Drawing.Image)(resources.GetObject("btnLogin.Image")));
            this.btnLogin.Location = new System.Drawing.Point(469, 238);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(83, 24);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Login";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // pnlTheme
            // 
            this.pnlTheme.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlTheme.BackgroundImage")));
            this.pnlTheme.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlTheme.Location = new System.Drawing.Point(348, 405);
            this.pnlTheme.Name = "pnlTheme";
            this.pnlTheme.Size = new System.Drawing.Size(50, 45);
            this.pnlTheme.TabIndex = 13;
            this.pnlTheme.Visible = false;
            this.pnlTheme.Click += new System.EventHandler(this.pnlTheme_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.Silver;
            this.labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.Location = new System.Drawing.Point(334, 459);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(77, 15);
            this.labelControl3.TabIndex = 14;
            this.labelControl3.Text = "Theme";
            this.labelControl3.Visible = false;
            // 
            // pnlExit
            // 
            this.pnlExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlExit.BackgroundImage")));
            this.pnlExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlExit.Location = new System.Drawing.Point(540, 405);
            this.pnlExit.Name = "pnlExit";
            this.pnlExit.Size = new System.Drawing.Size(48, 48);
            this.pnlExit.TabIndex = 15;
            this.pnlExit.Click += new System.EventHandler(this.pnlExit_Click);
            // 
            // pnlOption
            // 
            this.pnlOption.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlOption.BackgroundImage")));
            this.pnlOption.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlOption.Location = new System.Drawing.Point(445, 405);
            this.pnlOption.Name = "pnlOption";
            this.pnlOption.Size = new System.Drawing.Size(50, 48);
            this.pnlOption.TabIndex = 15;
            this.pnlOption.Click += new System.EventHandler(this.pnlOption_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.ForeColor = System.Drawing.Color.Silver;
            this.labelControl4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl4.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.labelControl4.Location = new System.Drawing.Point(524, 459);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(78, 15);
            this.labelControl4.TabIndex = 16;
            this.labelControl4.Text = "Exit";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.ForeColor = System.Drawing.Color.Silver;
            this.labelControl5.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl5.Location = new System.Drawing.Point(425, 459);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(89, 15);
            this.labelControl5.TabIndex = 16;
            this.labelControl5.Text = "Option";
            // 
            // lblTime
            // 
            this.lblTime.Appearance.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Appearance.ForeColor = System.Drawing.Color.Silver;
            this.lblTime.Location = new System.Drawing.Point(13, 459);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(52, 15);
            this.lblTime.TabIndex = 17;
            this.lblTime.Text = "12:00:00";
            // 
            // pnlDefaultOption
            // 
            this.pnlDefaultOption.Controls.Add(this.txtDisplayPeriod);
            this.pnlDefaultOption.Controls.Add(this.lblDisplayPeriodMonth);
            this.pnlDefaultOption.Controls.Add(this.chkDefaultPassword);
            this.pnlDefaultOption.Controls.Add(this.chkDefaultUser);
            this.pnlDefaultOption.Location = new System.Drawing.Point(377, 282);
            this.pnlDefaultOption.Name = "pnlDefaultOption";
            this.pnlDefaultOption.Size = new System.Drawing.Size(239, 108);
            this.pnlDefaultOption.TabIndex = 18;
            this.pnlDefaultOption.Text = "Default Option";
            this.pnlDefaultOption.Visible = false;
            // 
            // txtDisplayPeriod
            // 
            this.txtDisplayPeriod.EditValue = "2";
            this.txtDisplayPeriod.Location = new System.Drawing.Point(137, 80);
            this.txtDisplayPeriod.Name = "txtDisplayPeriod";
            this.txtDisplayPeriod.Properties.DisplayFormat.FormatString = "##";
            this.txtDisplayPeriod.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtDisplayPeriod.Properties.EditFormat.FormatString = "##";
            this.txtDisplayPeriod.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtDisplayPeriod.Properties.Mask.EditMask = "n0";
            this.txtDisplayPeriod.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtDisplayPeriod.Properties.MaxLength = 2;
            this.txtDisplayPeriod.Size = new System.Drawing.Size(27, 20);
            this.txtDisplayPeriod.TabIndex = 5;
            // 
            // lblDisplayPeriodMonth
            // 
            this.lblDisplayPeriodMonth.Location = new System.Drawing.Point(30, 84);
            this.lblDisplayPeriodMonth.Name = "lblDisplayPeriodMonth";
            this.lblDisplayPeriodMonth.Size = new System.Drawing.Size(100, 13);
            this.lblDisplayPeriodMonth.TabIndex = 4;
            this.lblDisplayPeriodMonth.Text = "Display Period Month";
            // 
            // chkDefaultPassword
            // 
            this.chkDefaultPassword.Location = new System.Drawing.Point(28, 56);
            this.chkDefaultPassword.Name = "chkDefaultPassword";
            this.chkDefaultPassword.Properties.Caption = "Remember Password";
            this.chkDefaultPassword.Size = new System.Drawing.Size(147, 19);
            this.chkDefaultPassword.TabIndex = 3;
            this.chkDefaultPassword.CheckedChanged += new System.EventHandler(this.chkDefaultPassword_CheckedChanged);
            // 
            // chkDefaultUser
            // 
            this.chkDefaultUser.Location = new System.Drawing.Point(28, 31);
            this.chkDefaultUser.Name = "chkDefaultUser";
            this.chkDefaultUser.Properties.Caption = "Remember User ID";
            this.chkDefaultUser.Size = new System.Drawing.Size(147, 19);
            this.chkDefaultUser.TabIndex = 2;
            this.chkDefaultUser.CheckedChanged += new System.EventHandler(this.chkDefaultUser_CheckedChanged);
            // 
            // pnlSerial
            // 
            this.pnlSerial.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlSerial.BackgroundImage")));
            this.pnlSerial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnlSerial.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlSerial.Location = new System.Drawing.Point(248, 405);
            this.pnlSerial.Name = "pnlSerial";
            this.pnlSerial.Size = new System.Drawing.Size(50, 45);
            this.pnlSerial.TabIndex = 14;
            this.pnlSerial.Visible = false;
            this.pnlSerial.Click += new System.EventHandler(this.pnlSerial_Click);
            // 
            // lblSerial
            // 
            this.lblSerial.Appearance.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerial.Appearance.ForeColor = System.Drawing.Color.Silver;
            this.lblSerial.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblSerial.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblSerial.Location = new System.Drawing.Point(234, 459);
            this.lblSerial.Name = "lblSerial";
            this.lblSerial.Size = new System.Drawing.Size(77, 15);
            this.lblSerial.TabIndex = 25;
            this.lblSerial.Text = "Serial";
            this.lblSerial.Visible = false;
            // 
            // lblSystemName
            // 
            this.lblSystemName.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSystemName.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblSystemName.Location = new System.Drawing.Point(53, 15);
            this.lblSystemName.Name = "lblSystemName";
            this.lblSystemName.Size = new System.Drawing.Size(389, 18);
            this.lblSystemName.TabIndex = 26;
            this.lblSystemName.Text = "Welcome to Warehouse Management System (WMS)";
            // 
            // lblProgramVersion
            // 
            this.lblProgramVersion.Appearance.ForeColor = System.Drawing.Color.DarkGray;
            this.lblProgramVersion.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblProgramVersion.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblProgramVersion.Location = new System.Drawing.Point(523, 15);
            this.lblProgramVersion.Name = "lblProgramVersion";
            this.lblProgramVersion.Size = new System.Drawing.Size(94, 13);
            this.lblProgramVersion.TabIndex = 27;
            this.lblProgramVersion.Text = "Version : X.Y";
            // 
            // lblDomainName
            // 
            this.lblDomainName.Appearance.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDomainName.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.lblDomainName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblDomainName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblDomainName.Location = new System.Drawing.Point(255, 204);
            this.lblDomainName.Name = "lblDomainName";
            this.lblDomainName.Size = new System.Drawing.Size(111, 20);
            this.lblDomainName.TabIndex = 28;
            this.lblDomainName.Text = "Domain Name";
            // 
            // lblAvailbleUpdate
            // 
            this.lblAvailbleUpdate.Appearance.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvailbleUpdate.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.lblAvailbleUpdate.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lblAvailbleUpdate.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblAvailbleUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblAvailbleUpdate.Location = new System.Drawing.Point(15, 370);
            this.lblAvailbleUpdate.Name = "lblAvailbleUpdate";
            this.lblAvailbleUpdate.Size = new System.Drawing.Size(247, 20);
            this.lblAvailbleUpdate.TabIndex = 26;
            this.lblAvailbleUpdate.Text = "New updates are available";
            this.lblAvailbleUpdate.Visible = false;
            this.lblAvailbleUpdate.Click += new System.EventHandler(this.lblAvailbleUpdate_Click);
            // 
            // panal2
            // 
            this.panal2.BackColor = System.Drawing.Color.Transparent;
            this.panal2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panal2.BackgroundImage")));
            this.panal2.Controls.Add(this.pictureBox1);
            this.panal2.Controls.Add(this.panel1);
            this.panal2.Controls.Add(this.gpcWebAPIURL);
            this.panal2.Controls.Add(this.lblAvailbleUpdate);
            this.panal2.Controls.Add(this.lblDomainName);
            this.panal2.Controls.Add(this.lblProgramVersion);
            this.panal2.Controls.Add(this.lblSystemName);
            this.panal2.Controls.Add(this.lblSerial);
            this.panal2.Controls.Add(this.pnlSerial);
            this.panal2.Controls.Add(this.pnlDefaultOption);
            this.panal2.Controls.Add(this.lblTime);
            this.panal2.Controls.Add(this.labelControl5);
            this.panal2.Controls.Add(this.labelControl4);
            this.panal2.Controls.Add(this.pnlOption);
            this.panal2.Controls.Add(this.pnlExit);
            this.panal2.Controls.Add(this.labelControl3);
            this.panal2.Controls.Add(this.pnlTheme);
            this.panal2.Controls.Add(this.btnLogin);
            this.panal2.Controls.Add(this.txtPassword);
            this.panal2.Controls.Add(this.txtUsername);
            this.panal2.Controls.Add(this.labelControl2);
            this.panal2.Controls.Add(this.labelControl1);
            this.panal2.Controls.Add(this.panel2);
            this.panal2.Controls.Add(this.cboDomainServerName);
            this.panal2.Location = new System.Drawing.Point(-5, -3);
            this.panal2.Name = "panal2";
            this.panal2.Size = new System.Drawing.Size(837, 513);
            this.panal2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(503, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(116, 45);
            this.panel1.TabIndex = 25;
            // 
            // gpcWebAPIURL
            // 
            this.gpcWebAPIURL.Controls.Add(this.btnWebAPIURLOK);
            this.gpcWebAPIURL.Controls.Add(this.txtWebAPIURL);
            this.gpcWebAPIURL.Controls.Add(this.lblWebAPIUTL);
            this.gpcWebAPIURL.Location = new System.Drawing.Point(13, 303);
            this.gpcWebAPIURL.Name = "gpcWebAPIURL";
            this.gpcWebAPIURL.Size = new System.Drawing.Size(603, 85);
            this.gpcWebAPIURL.TabIndex = 31;
            this.gpcWebAPIURL.Text = "Web API URL Configuration";
            this.gpcWebAPIURL.Visible = false;
            // 
            // btnWebAPIURLOK
            // 
            this.btnWebAPIURLOK.Image = ((System.Drawing.Image)(resources.GetObject("btnWebAPIURLOK.Image")));
            this.btnWebAPIURLOK.Location = new System.Drawing.Point(523, 55);
            this.btnWebAPIURLOK.Name = "btnWebAPIURLOK";
            this.btnWebAPIURLOK.Size = new System.Drawing.Size(75, 23);
            this.btnWebAPIURLOK.TabIndex = 31;
            this.btnWebAPIURLOK.Text = "OK";
            this.btnWebAPIURLOK.Click += new System.EventHandler(this.btnWebAPIURLOK_Click);
            // 
            // txtWebAPIURL
            // 
            this.txtWebAPIURL.EditValue = "";
            this.txtWebAPIURL.Location = new System.Drawing.Point(103, 29);
            this.txtWebAPIURL.Name = "txtWebAPIURL";
            this.txtWebAPIURL.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWebAPIURL.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtWebAPIURL.Properties.Appearance.Options.UseFont = true;
            this.txtWebAPIURL.Properties.Appearance.Options.UseForeColor = true;
            this.txtWebAPIURL.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtWebAPIURL.Size = new System.Drawing.Size(496, 20);
            this.txtWebAPIURL.TabIndex = 29;
            // 
            // lblWebAPIUTL
            // 
            this.lblWebAPIUTL.Appearance.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWebAPIUTL.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.lblWebAPIUTL.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblWebAPIUTL.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblWebAPIUTL.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.lblWebAPIUTL.Location = new System.Drawing.Point(4, 31);
            this.lblWebAPIUTL.Name = "lblWebAPIUTL";
            this.lblWebAPIUTL.Size = new System.Drawing.Size(88, 16);
            this.lblWebAPIUTL.TabIndex = 30;
            this.lblWebAPIUTL.Text = "Web API URL";
            // 
            // timerScreenEffice
            // 
            this.timerScreenEffice.Enabled = true;
            this.timerScreenEffice.Interval = 15;
            this.timerScreenEffice.Tick += new System.EventHandler(this.timerScreenEffice_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(710, 315);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            // 
            // frmLOG010_Login
            // 
            this.AcceptButton = this.btnLogin;
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(90)))));
            this.Appearance.ForeColor = System.Drawing.Color.Black;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseForeColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 510);
            this.Controls.Add(this.panal2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLOG010_Login";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LOG010 : Login";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(90)))));
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmLOG010_Login_FormClosed);
            this.Load += new System.EventHandler(this.frmLOG010_Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDomainServerName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDefaultOption)).EndInit();
            this.pnlDefaultOption.ResumeLayout(false);
            this.pnlDefaultOption.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDisplayPeriod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDefaultPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDefaultUser.Properties)).EndInit();
            this.panal2.ResumeLayout(false);
            this.panal2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gpcWebAPIURL)).EndInit();
            this.gpcWebAPIURL.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtWebAPIURL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
        private DevExpress.XtraEditors.CheckEdit checkEdit2;
        protected DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider errorProvider;
        private DevExpress.XtraEditors.SimpleButton btnLogin;
        private System.Windows.Forms.Panel panal2;
        private DevExpress.XtraEditors.LabelControl lblAvailbleUpdate;
        private DevExpress.XtraEditors.LabelControl lblDomainName;
        private DevExpress.XtraEditors.LabelControl lblProgramVersion;
        private DevExpress.XtraEditors.LabelControl lblSystemName;
        private DevExpress.XtraEditors.LabelControl lblSerial;
        private System.Windows.Forms.Panel pnlSerial;
        private DevExpress.XtraEditors.GroupControl pnlDefaultOption;
        private DevExpress.XtraEditors.TextEdit txtDisplayPeriod;
        private DevExpress.XtraEditors.LabelControl lblDisplayPeriodMonth;
        private DevExpress.XtraEditors.CheckEdit chkDefaultPassword;
        private DevExpress.XtraEditors.CheckEdit chkDefaultUser;
        private DevExpress.XtraEditors.LabelControl lblTime;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.Panel pnlOption;
        private System.Windows.Forms.Panel pnlExit;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.Panel pnlTheme;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.TextEdit txtUsername;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.LookUpEdit cboDomainServerName;
        public System.ComponentModel.BackgroundWorker backgroundWorker1;
        private DevExpress.XtraEditors.TextEdit txtWebAPIURL;
        private DevExpress.XtraEditors.LabelControl lblWebAPIUTL;
        private DevExpress.XtraEditors.GroupControl gpcWebAPIURL;
        private DevExpress.XtraEditors.SimpleButton btnWebAPIURLOK;
        private System.Windows.Forms.Timer timerScreenEffice;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager;
        private System.Windows.Forms.PictureBox pictureBox1;

    }
}