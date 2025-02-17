namespace DAWRPC
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RPCMenuVersion = new System.Windows.Forms.ToolStripMenuItem();
            this.discordUsername = new System.Windows.Forms.ToolStripMenuItem();
            this.openWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideProjectNameContextMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.hideSystemUsageContextMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.setUpdateIntervalContextMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.RAMUsage = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.CPUUsage = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ProjectOpening = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DAWName = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.oFFHideProjectNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oFFHideSystemUsageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setUpdateIntervalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 2500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "DAWRPC";
            this.notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RPCMenuVersion,
            this.discordUsername,
            this.openWindowToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(271, 114);
            // 
            // RPCMenuVersion
            // 
            this.RPCMenuVersion.Enabled = false;
            this.RPCMenuVersion.Name = "RPCMenuVersion";
            this.RPCMenuVersion.Size = new System.Drawing.Size(270, 22);
            this.RPCMenuVersion.Text = "DAW Discord Rich Presence";
            // 
            // discordUsername
            // 
            this.discordUsername.Enabled = false;
            this.discordUsername.Name = "discordUsername";
            this.discordUsername.Size = new System.Drawing.Size(270, 22);
            this.discordUsername.Text = "Open a DAW to begin displaying RPC";
            // 
            // openWindowToolStripMenuItem
            // 
            this.openWindowToolStripMenuItem.Name = "openWindowToolStripMenuItem";
            this.openWindowToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
            this.openWindowToolStripMenuItem.Text = "Open Window";
            this.openWindowToolStripMenuItem.Click += new System.EventHandler(this.openWindowToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hideProjectNameContextMenu,
            this.hideSystemUsageContextMenu,
            this.setUpdateIntervalContextMenu});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // hideProjectNameContextMenu
            // 
            this.hideProjectNameContextMenu.Name = "hideProjectNameContextMenu";
            this.hideProjectNameContextMenu.Size = new System.Drawing.Size(207, 22);
            this.hideProjectNameContextMenu.Text = "[OFF] Hide Project Name";
            this.hideProjectNameContextMenu.Click += new System.EventHandler(this.hideProjectNameContextMenu_Click);
            // 
            // hideSystemUsageContextMenu
            // 
            this.hideSystemUsageContextMenu.Name = "hideSystemUsageContextMenu";
            this.hideSystemUsageContextMenu.Size = new System.Drawing.Size(207, 22);
            this.hideSystemUsageContextMenu.Text = "[OFF] Hide System Usage";
            this.hideSystemUsageContextMenu.Click += new System.EventHandler(this.hideSystemUsageContextMenu_Click);
            // 
            // setUpdateIntervalContextMenu
            // 
            this.setUpdateIntervalContextMenu.Name = "setUpdateIntervalContextMenu";
            this.setUpdateIntervalContextMenu.Size = new System.Drawing.Size(207, 22);
            this.setUpdateIntervalContextMenu.Text = "Set Update Interval";
            this.setUpdateIntervalContextMenu.Click += new System.EventHandler(this.setUpdateIntervalContextMenu_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.menuStrip1, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(735, 347);
            this.tableLayoutPanel3.TabIndex = 12;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox4, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 33);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(729, 311);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.RAMUsage);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(374, 165);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(10);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(345, 136);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "RAM Usage";
            // 
            // RAMUsage
            // 
            this.RAMUsage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RAMUsage.Font = new System.Drawing.Font("Consolas", 20F);
            this.RAMUsage.Location = new System.Drawing.Point(3, 18);
            this.RAMUsage.Name = "RAMUsage";
            this.RAMUsage.Size = new System.Drawing.Size(339, 115);
            this.RAMUsage.TabIndex = 8;
            this.RAMUsage.Text = "Undefined";
            this.RAMUsage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.CPUUsage);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(10, 165);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(10);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(344, 136);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "CPU Usage";
            // 
            // CPUUsage
            // 
            this.CPUUsage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CPUUsage.Font = new System.Drawing.Font("Consolas", 20F);
            this.CPUUsage.Location = new System.Drawing.Point(3, 18);
            this.CPUUsage.Name = "CPUUsage";
            this.CPUUsage.Size = new System.Drawing.Size(338, 115);
            this.CPUUsage.TabIndex = 7;
            this.CPUUsage.Text = "Undefined";
            this.CPUUsage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ProjectOpening);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(374, 10);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(345, 135);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Opening Project";
            // 
            // ProjectOpening
            // 
            this.ProjectOpening.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProjectOpening.Font = new System.Drawing.Font("Tahoma", 12F);
            this.ProjectOpening.Location = new System.Drawing.Point(3, 18);
            this.ProjectOpening.Name = "ProjectOpening";
            this.ProjectOpening.Size = new System.Drawing.Size(339, 114);
            this.ProjectOpening.TabIndex = 3;
            this.ProjectOpening.Text = "None";
            this.ProjectOpening.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DAWName);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(344, 135);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Current Digital Audio Workstation";
            // 
            // DAWName
            // 
            this.DAWName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DAWName.Font = new System.Drawing.Font("Tahoma", 12F);
            this.DAWName.Location = new System.Drawing.Point(3, 18);
            this.DAWName.Name = "DAWName";
            this.DAWName.Size = new System.Drawing.Size(338, 114);
            this.DAWName.TabIndex = 1;
            this.DAWName.Text = "None";
            this.DAWName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oFFHideProjectNameToolStripMenuItem,
            this.oFFHideSystemUsageToolStripMenuItem,
            this.setUpdateIntervalToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(735, 30);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // oFFHideProjectNameToolStripMenuItem
            // 
            this.oFFHideProjectNameToolStripMenuItem.Name = "oFFHideProjectNameToolStripMenuItem";
            this.oFFHideProjectNameToolStripMenuItem.Size = new System.Drawing.Size(151, 26);
            this.oFFHideProjectNameToolStripMenuItem.Text = "[OFF] Hide Project Name";
            this.oFFHideProjectNameToolStripMenuItem.Click += new System.EventHandler(this.oFFHideProjectNameToolStripMenuItem_Click);
            // 
            // oFFHideSystemUsageToolStripMenuItem
            // 
            this.oFFHideSystemUsageToolStripMenuItem.Name = "oFFHideSystemUsageToolStripMenuItem";
            this.oFFHideSystemUsageToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.oFFHideSystemUsageToolStripMenuItem.Text = "[OFF] Hide System Usage";
            this.oFFHideSystemUsageToolStripMenuItem.Click += new System.EventHandler(this.oFFHideSystemUsageToolStripMenuItem_Click);
            // 
            // setUpdateIntervalToolStripMenuItem
            // 
            this.setUpdateIntervalToolStripMenuItem.Name = "setUpdateIntervalToolStripMenuItem";
            this.setUpdateIntervalToolStripMenuItem.Size = new System.Drawing.Size(118, 26);
            this.setUpdateIntervalToolStripMenuItem.Text = "Set Update Interval";
            this.setUpdateIntervalToolStripMenuItem.Click += new System.EventHandler(this.setUpdateIntervalToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(735, 347);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.ForeColor = System.Drawing.Color.Black;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "DAW Discord Rich Presence";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem discordUsername;
        private System.Windows.Forms.ToolStripMenuItem RPCMenuVersion;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label RAMUsage;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label CPUUsage;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label ProjectOpening;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label DAWName;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem oFFHideProjectNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oFFHideSystemUsageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setUpdateIntervalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hideProjectNameContextMenu;
        private System.Windows.Forms.ToolStripMenuItem hideSystemUsageContextMenu;
        private System.Windows.Forms.ToolStripMenuItem setUpdateIntervalContextMenu;
    }
}

