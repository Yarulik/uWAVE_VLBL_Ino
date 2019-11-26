namespace uWAVE_VLBL_Ino
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainToolStrip = new System.Windows.Forms.ToolStrip();
            this.connectionBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.settingsBtn = new System.Windows.Forms.ToolStripButton();
            this.infoBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.logBtn = new System.Windows.Forms.ToolStripDropDownButton();
            this.logViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logClearAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tracksBtn = new System.Windows.Forms.ToolStripDropDownButton();
            this.tracksSaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tracksClearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.isAutoSnapshotBtn = new System.Windows.Forms.ToolStripButton();
            this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.geoPlotCartesian = new UCNLUI.Controls.GeoPlotCartesian();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.logAnalyzeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainToolStrip
            // 
            this.mainToolStrip.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectionBtn,
            this.toolStripSeparator1,
            this.settingsBtn,
            this.infoBtn,
            this.toolStripSeparator2,
            this.logBtn,
            this.tracksBtn,
            this.toolStripSeparator3,
            this.isAutoSnapshotBtn});
            this.mainToolStrip.Location = new System.Drawing.Point(0, 0);
            this.mainToolStrip.Name = "mainToolStrip";
            this.mainToolStrip.Size = new System.Drawing.Size(781, 30);
            this.mainToolStrip.TabIndex = 0;
            this.mainToolStrip.Text = "toolStrip1";
            // 
            // connectionBtn
            // 
            this.connectionBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.connectionBtn.Font = new System.Drawing.Font("Segoe UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.connectionBtn.Image = ((System.Drawing.Image)(resources.GetObject("connectionBtn.Image")));
            this.connectionBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.connectionBtn.Name = "connectionBtn";
            this.connectionBtn.Size = new System.Drawing.Size(94, 27);
            this.connectionBtn.Text = "CONNECT";
            this.connectionBtn.Click += new System.EventHandler(this.connectionBtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 30);
            // 
            // settingsBtn
            // 
            this.settingsBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.settingsBtn.Font = new System.Drawing.Font("Segoe UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.settingsBtn.Image = ((System.Drawing.Image)(resources.GetObject("settingsBtn.Image")));
            this.settingsBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.settingsBtn.Name = "settingsBtn";
            this.settingsBtn.Size = new System.Drawing.Size(93, 27);
            this.settingsBtn.Text = "SETTINGS";
            this.settingsBtn.Click += new System.EventHandler(this.settingsBtn_Click);
            // 
            // infoBtn
            // 
            this.infoBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.infoBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.infoBtn.Font = new System.Drawing.Font("Segoe UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.infoBtn.Image = ((System.Drawing.Image)(resources.GetObject("infoBtn.Image")));
            this.infoBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.infoBtn.Name = "infoBtn";
            this.infoBtn.Size = new System.Drawing.Size(54, 27);
            this.infoBtn.Text = "INFO";
            this.infoBtn.Click += new System.EventHandler(this.infoBtn_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 30);
            // 
            // logBtn
            // 
            this.logBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.logBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logViewToolStripMenuItem,
            this.logClearAllToolStripMenuItem,
            this.toolStripSeparator4,
            this.logAnalyzeToolStripMenuItem});
            this.logBtn.Font = new System.Drawing.Font("Segoe UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.logBtn.Image = ((System.Drawing.Image)(resources.GetObject("logBtn.Image")));
            this.logBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.logBtn.Name = "logBtn";
            this.logBtn.Size = new System.Drawing.Size(57, 27);
            this.logBtn.Text = "LOG";
            // 
            // logViewToolStripMenuItem
            // 
            this.logViewToolStripMenuItem.Name = "logViewToolStripMenuItem";
            this.logViewToolStripMenuItem.Size = new System.Drawing.Size(169, 28);
            this.logViewToolStripMenuItem.Text = "VIEW";
            this.logViewToolStripMenuItem.Click += new System.EventHandler(this.logViewToolStripMenuItem_Click);
            // 
            // logClearAllToolStripMenuItem
            // 
            this.logClearAllToolStripMenuItem.Name = "logClearAllToolStripMenuItem";
            this.logClearAllToolStripMenuItem.Size = new System.Drawing.Size(169, 28);
            this.logClearAllToolStripMenuItem.Text = "CLEAR ALL";
            this.logClearAllToolStripMenuItem.Click += new System.EventHandler(this.logClearAllToolStripMenuItem_Click);
            // 
            // tracksBtn
            // 
            this.tracksBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tracksBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tracksSaveToolStripMenuItem,
            this.tracksClearToolStripMenuItem});
            this.tracksBtn.Font = new System.Drawing.Font("Segoe UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tracksBtn.Image = ((System.Drawing.Image)(resources.GetObject("tracksBtn.Image")));
            this.tracksBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tracksBtn.Name = "tracksBtn";
            this.tracksBtn.Size = new System.Drawing.Size(88, 27);
            this.tracksBtn.Text = "TRACKS";
            // 
            // tracksSaveToolStripMenuItem
            // 
            this.tracksSaveToolStripMenuItem.Name = "tracksSaveToolStripMenuItem";
            this.tracksSaveToolStripMenuItem.Size = new System.Drawing.Size(167, 28);
            this.tracksSaveToolStripMenuItem.Text = "SAVE";
            this.tracksSaveToolStripMenuItem.Click += new System.EventHandler(this.tracksSaveToolStripMenuItem_Click);
            // 
            // tracksClearToolStripMenuItem
            // 
            this.tracksClearToolStripMenuItem.Name = "tracksClearToolStripMenuItem";
            this.tracksClearToolStripMenuItem.Size = new System.Drawing.Size(167, 28);
            this.tracksClearToolStripMenuItem.Text = "CLEAR ALL";
            this.tracksClearToolStripMenuItem.Click += new System.EventHandler(this.tracksClearToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 30);
            // 
            // isAutoSnapshotBtn
            // 
            this.isAutoSnapshotBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.isAutoSnapshotBtn.Font = new System.Drawing.Font("Segoe UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.isAutoSnapshotBtn.Image = ((System.Drawing.Image)(resources.GetObject("isAutoSnapshotBtn.Image")));
            this.isAutoSnapshotBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.isAutoSnapshotBtn.Name = "isAutoSnapshotBtn";
            this.isAutoSnapshotBtn.Size = new System.Drawing.Size(155, 27);
            this.isAutoSnapshotBtn.Text = "AUTO SNAPSHOT";
            this.isAutoSnapshotBtn.Click += new System.EventHandler(this.isAutoSnapshotBtn_Click);
            // 
            // mainStatusStrip
            // 
            this.mainStatusStrip.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mainStatusStrip.Location = new System.Drawing.Point(0, 483);
            this.mainStatusStrip.Name = "mainStatusStrip";
            this.mainStatusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.mainStatusStrip.Size = new System.Drawing.Size(781, 22);
            this.mainStatusStrip.TabIndex = 1;
            this.mainStatusStrip.Text = "statusStrip1";
            // 
            // geoPlotCartesian
            // 
            this.geoPlotCartesian.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.geoPlotCartesian.BackColor = System.Drawing.Color.Wheat;
            this.geoPlotCartesian.LeftUpperCornerText = "";
            this.geoPlotCartesian.Location = new System.Drawing.Point(12, 34);
            this.geoPlotCartesian.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.geoPlotCartesian.Name = "geoPlotCartesian";
            this.geoPlotCartesian.Size = new System.Drawing.Size(757, 445);
            this.geoPlotCartesian.TabIndex = 2;
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(166, 6);
            // 
            // logAnalyzeToolStripMenuItem
            // 
            this.logAnalyzeToolStripMenuItem.Name = "logAnalyzeToolStripMenuItem";
            this.logAnalyzeToolStripMenuItem.Size = new System.Drawing.Size(169, 28);
            this.logAnalyzeToolStripMenuItem.Text = "ANALYZE...";
            this.logAnalyzeToolStripMenuItem.Click += new System.EventHandler(this.logAnalyzeToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 505);
            this.Controls.Add(this.geoPlotCartesian);
            this.Controls.Add(this.mainStatusStrip);
            this.Controls.Add(this.mainToolStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "uWAVE VLBL Ino";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.mainToolStrip.ResumeLayout(false);
            this.mainToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip mainToolStrip;
        private System.Windows.Forms.StatusStrip mainStatusStrip;
        private System.Windows.Forms.ToolStripButton connectionBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton settingsBtn;
        private System.Windows.Forms.ToolStripButton infoBtn;
        private UCNLUI.Controls.GeoPlotCartesian geoPlotCartesian;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripDropDownButton logBtn;
        private System.Windows.Forms.ToolStripMenuItem logViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logClearAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton tracksBtn;
        private System.Windows.Forms.ToolStripMenuItem tracksSaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton isAutoSnapshotBtn;
        private System.Windows.Forms.ToolStripMenuItem tracksClearToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem logAnalyzeToolStripMenuItem;
    }
}

