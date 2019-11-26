namespace uWAVE_VLBL_Ino
{
    partial class SettingsEditor
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
            this.cancelBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.inPortNameCbx = new System.Windows.Forms.ComboBox();
            this.inPortBaudrateCbx = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.isUseOutPortChb = new System.Windows.Forms.CheckBox();
            this.outPortBaudrateCbx = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.outPortNameCbx = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.measurementsFIFOSizeEdit = new System.Windows.Forms.NumericUpDown();
            this.baseSizeEdit = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.targetLocationFIFOSizeEdit = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.radialErrorThresholdEdit = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.simplexSizeEdit = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.salinityEdit = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.measurementsFIFOSizeEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseSizeEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.targetLocationFIFOSizeEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radialErrorThresholdEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simplexSizeEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salinityEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Font = new System.Drawing.Font("Segoe UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cancelBtn.Location = new System.Drawing.Point(470, 528);
            this.cancelBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(123, 40);
            this.cancelBtn.TabIndex = 0;
            this.cancelBtn.Text = "CANCEL";
            this.cancelBtn.UseVisualStyleBackColor = true;
            // 
            // okBtn
            // 
            this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okBtn.Enabled = false;
            this.okBtn.Font = new System.Drawing.Font("Segoe UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.okBtn.Location = new System.Drawing.Point(316, 528);
            this.okBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(123, 40);
            this.okBtn.TabIndex = 1;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "In port name";
            // 
            // inPortNameCbx
            // 
            this.inPortNameCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.inPortNameCbx.FormattingEnabled = true;
            this.inPortNameCbx.Location = new System.Drawing.Point(12, 50);
            this.inPortNameCbx.Name = "inPortNameCbx";
            this.inPortNameCbx.Size = new System.Drawing.Size(246, 31);
            this.inPortNameCbx.TabIndex = 3;
            this.inPortNameCbx.SelectedIndexChanged += new System.EventHandler(this.inPortNameCbx_SelectedIndexChanged);
            // 
            // inPortBaudrateCbx
            // 
            this.inPortBaudrateCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.inPortBaudrateCbx.FormattingEnabled = true;
            this.inPortBaudrateCbx.Location = new System.Drawing.Point(347, 50);
            this.inPortBaudrateCbx.Name = "inPortBaudrateCbx";
            this.inPortBaudrateCbx.Size = new System.Drawing.Size(246, 31);
            this.inPortBaudrateCbx.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(347, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "In port baudrate";
            // 
            // isUseOutPortChb
            // 
            this.isUseOutPortChb.AutoSize = true;
            this.isUseOutPortChb.Location = new System.Drawing.Point(12, 106);
            this.isUseOutPortChb.Name = "isUseOutPortChb";
            this.isUseOutPortChb.Size = new System.Drawing.Size(128, 27);
            this.isUseOutPortChb.TabIndex = 6;
            this.isUseOutPortChb.Text = "Use out port";
            this.isUseOutPortChb.UseVisualStyleBackColor = true;
            this.isUseOutPortChb.CheckedChanged += new System.EventHandler(this.isUseOutPortChb_CheckedChanged);
            // 
            // outPortBaudrateCbx
            // 
            this.outPortBaudrateCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.outPortBaudrateCbx.Enabled = false;
            this.outPortBaudrateCbx.FormattingEnabled = true;
            this.outPortBaudrateCbx.Location = new System.Drawing.Point(347, 168);
            this.outPortBaudrateCbx.Name = "outPortBaudrateCbx";
            this.outPortBaudrateCbx.Size = new System.Drawing.Size(246, 31);
            this.outPortBaudrateCbx.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Location = new System.Drawing.Point(347, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 23);
            this.label3.TabIndex = 9;
            this.label3.Text = "Out port baudrate";
            // 
            // outPortNameCbx
            // 
            this.outPortNameCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.outPortNameCbx.Enabled = false;
            this.outPortNameCbx.FormattingEnabled = true;
            this.outPortNameCbx.Location = new System.Drawing.Point(12, 168);
            this.outPortNameCbx.Name = "outPortNameCbx";
            this.outPortNameCbx.Size = new System.Drawing.Size(246, 31);
            this.outPortNameCbx.TabIndex = 8;
            this.outPortNameCbx.SelectedIndexChanged += new System.EventHandler(this.outPortNameCbx_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Enabled = false;
            this.label4.Location = new System.Drawing.Point(12, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 23);
            this.label4.TabIndex = 7;
            this.label4.Text = "Out port name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 224);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(194, 23);
            this.label5.TabIndex = 11;
            this.label5.Text = "Measurements FIFO size";
            // 
            // measurementsFIFOSizeEdit
            // 
            this.measurementsFIFOSizeEdit.Location = new System.Drawing.Point(12, 250);
            this.measurementsFIFOSizeEdit.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.measurementsFIFOSizeEdit.Minimum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.measurementsFIFOSizeEdit.Name = "measurementsFIFOSizeEdit";
            this.measurementsFIFOSizeEdit.Size = new System.Drawing.Size(128, 30);
            this.measurementsFIFOSizeEdit.TabIndex = 12;
            this.measurementsFIFOSizeEdit.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            // 
            // baseSizeEdit
            // 
            this.baseSizeEdit.Location = new System.Drawing.Point(12, 332);
            this.baseSizeEdit.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.baseSizeEdit.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.baseSizeEdit.Name = "baseSizeEdit";
            this.baseSizeEdit.Size = new System.Drawing.Size(128, 30);
            this.baseSizeEdit.TabIndex = 14;
            this.baseSizeEdit.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 306);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 23);
            this.label6.TabIndex = 13;
            this.label6.Text = "Base size";
            // 
            // targetLocationFIFOSizeEdit
            // 
            this.targetLocationFIFOSizeEdit.Location = new System.Drawing.Point(12, 416);
            this.targetLocationFIFOSizeEdit.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.targetLocationFIFOSizeEdit.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.targetLocationFIFOSizeEdit.Name = "targetLocationFIFOSizeEdit";
            this.targetLocationFIFOSizeEdit.Size = new System.Drawing.Size(128, 30);
            this.targetLocationFIFOSizeEdit.TabIndex = 16;
            this.targetLocationFIFOSizeEdit.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 390);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(195, 23);
            this.label7.TabIndex = 15;
            this.label7.Text = "Target location FIFO size";
            // 
            // radialErrorThresholdEdit
            // 
            this.radialErrorThresholdEdit.Location = new System.Drawing.Point(347, 250);
            this.radialErrorThresholdEdit.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.radialErrorThresholdEdit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.radialErrorThresholdEdit.Name = "radialErrorThresholdEdit";
            this.radialErrorThresholdEdit.Size = new System.Drawing.Size(128, 30);
            this.radialErrorThresholdEdit.TabIndex = 18;
            this.radialErrorThresholdEdit.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(347, 224);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(199, 23);
            this.label8.TabIndex = 17;
            this.label8.Text = "Radial error threshold, m";
            // 
            // simplexSizeEdit
            // 
            this.simplexSizeEdit.Location = new System.Drawing.Point(347, 332);
            this.simplexSizeEdit.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.simplexSizeEdit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.simplexSizeEdit.Name = "simplexSizeEdit";
            this.simplexSizeEdit.Size = new System.Drawing.Size(128, 30);
            this.simplexSizeEdit.TabIndex = 20;
            this.simplexSizeEdit.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(347, 306);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(126, 23);
            this.label9.TabIndex = 19;
            this.label9.Text = "Simplex size, m";
            // 
            // salinityEdit
            // 
            this.salinityEdit.Location = new System.Drawing.Point(347, 416);
            this.salinityEdit.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.salinityEdit.Name = "salinityEdit";
            this.salinityEdit.Size = new System.Drawing.Size(128, 30);
            this.salinityEdit.TabIndex = 22;
            this.salinityEdit.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(347, 390);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(104, 23);
            this.label10.TabIndex = 21;
            this.label10.Text = "Salinity, PSU";
            // 
            // SettingsEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 581);
            this.Controls.Add(this.salinityEdit);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.simplexSizeEdit);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.radialErrorThresholdEdit);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.targetLocationFIFOSizeEdit);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.baseSizeEdit);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.measurementsFIFOSizeEdit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.outPortBaudrateCbx);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.outPortNameCbx);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.isUseOutPortChb);
            this.Controls.Add(this.inPortBaudrateCbx);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.inPortNameCbx);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.cancelBtn);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SettingsEditor";
            this.Text = "SettingsEditor";
            ((System.ComponentModel.ISupportInitialize)(this.measurementsFIFOSizeEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseSizeEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.targetLocationFIFOSizeEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radialErrorThresholdEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simplexSizeEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salinityEdit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox inPortNameCbx;
        private System.Windows.Forms.ComboBox inPortBaudrateCbx;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox isUseOutPortChb;
        private System.Windows.Forms.ComboBox outPortBaudrateCbx;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox outPortNameCbx;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown measurementsFIFOSizeEdit;
        private System.Windows.Forms.NumericUpDown baseSizeEdit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown targetLocationFIFOSizeEdit;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown radialErrorThresholdEdit;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown simplexSizeEdit;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown salinityEdit;
        private System.Windows.Forms.Label label10;
    }
}