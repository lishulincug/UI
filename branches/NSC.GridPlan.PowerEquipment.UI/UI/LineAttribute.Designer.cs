﻿namespace NSC.GridPlan.PowerEquipment.UI
{
    partial class LineAttribute
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.cbxType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtStart = new DevExpress.XtraEditors.TextEdit();
            this.txtEnd = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtLength = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.cbxLineType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.cbxPartition = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.cbxVol = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnPreView = new DevExpress.XtraEditors.SimpleButton();
            this.btnField = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl17 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl18 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLength.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxLineType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxPartition.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxVol.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(287, 20);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "线路类型：";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(24, 69);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 14);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "线路起点：";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(24, 21);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(60, 14);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "线路名称：";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(95, 16);
            this.txtName.Name = "txtName";
            this.txtName.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.txtName.Properties.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.txtName.Properties.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.txtName.Properties.Appearance.Options.UseBackColor = true;
            this.txtName.Properties.Appearance.Options.UseBorderColor = true;
            this.txtName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtName.Size = new System.Drawing.Size(145, 24);
            this.txtName.TabIndex = 3;
            this.txtName.EditValueChanged += new System.EventHandler(this.txtName_EditValueChanged);
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(287, 69);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(60, 14);
            this.labelControl4.TabIndex = 4;
            this.labelControl4.Text = "线路终点：";
            // 
            // cbxType
            // 
            this.cbxType.Location = new System.Drawing.Point(362, 17);
            this.cbxType.Name = "cbxType";
            this.cbxType.Properties.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.cbxType.Properties.Appearance.Options.UseBorderColor = true;
            this.cbxType.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.cbxType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxType.Properties.Items.AddRange(new object[] {
            "交流线路",
            "直流线路"});
            this.cbxType.Size = new System.Drawing.Size(145, 24);
            this.cbxType.TabIndex = 5;
            this.cbxType.SelectedIndexChanged += new System.EventHandler(this.cbxType_SelectedIndexChanged);
            // 
            // txtStart
            // 
            this.txtStart.Location = new System.Drawing.Point(95, 65);
            this.txtStart.Name = "txtStart";
            this.txtStart.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.txtStart.Properties.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.txtStart.Properties.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.txtStart.Properties.Appearance.Options.UseBackColor = true;
            this.txtStart.Properties.Appearance.Options.UseBorderColor = true;
            this.txtStart.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtStart.Size = new System.Drawing.Size(145, 24);
            this.txtStart.TabIndex = 6;
            this.txtStart.EditValueChanged += new System.EventHandler(this.txtStart_EditValueChanged);
            this.txtStart.TextChanged += new System.EventHandler(this.txtStart_TextChanged);
            // 
            // txtEnd
            // 
            this.txtEnd.Location = new System.Drawing.Point(362, 65);
            this.txtEnd.Name = "txtEnd";
            this.txtEnd.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.txtEnd.Properties.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.txtEnd.Properties.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.txtEnd.Properties.Appearance.Options.UseBackColor = true;
            this.txtEnd.Properties.Appearance.Options.UseBorderColor = true;
            this.txtEnd.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtEnd.Size = new System.Drawing.Size(145, 24);
            this.txtEnd.TabIndex = 7;
            this.txtEnd.EditValueChanged += new System.EventHandler(this.txtEnd_EditValueChanged);
            this.txtEnd.TextChanged += new System.EventHandler(this.txtEnd_TextChanged);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(24, 114);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(60, 14);
            this.labelControl5.TabIndex = 9;
            this.labelControl5.Text = "电压等级：";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(287, 114);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(60, 14);
            this.labelControl6.TabIndex = 11;
            this.labelControl6.Text = "线路长度：";
            // 
            // txtLength
            // 
            this.txtLength.Location = new System.Drawing.Point(362, 110);
            this.txtLength.Name = "txtLength";
            this.txtLength.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.txtLength.Properties.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.txtLength.Properties.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.txtLength.Properties.Appearance.Options.UseBackColor = true;
            this.txtLength.Properties.Appearance.Options.UseBorderColor = true;
            this.txtLength.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtLength.Size = new System.Drawing.Size(145, 24);
            this.txtLength.TabIndex = 10;
            this.txtLength.EditValueChanged += new System.EventHandler(this.txtLength_EditValueChanged);
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(247, 116);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(24, 14);
            this.labelControl7.TabIndex = 12;
            this.labelControl7.Text = "(kV)";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(515, 114);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(26, 14);
            this.labelControl8.TabIndex = 13;
            this.labelControl8.Text = "(km)";
            // 
            // cbxLineType
            // 
            this.cbxLineType.AllowDrop = true;
            this.cbxLineType.Location = new System.Drawing.Point(95, 154);
            this.cbxLineType.Name = "cbxLineType";
            this.cbxLineType.Properties.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.cbxLineType.Properties.Appearance.Options.UseBorderColor = true;
            this.cbxLineType.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.cbxLineType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxLineType.Size = new System.Drawing.Size(145, 24);
            this.cbxLineType.TabIndex = 15;
            this.cbxLineType.SelectedIndexChanged += new System.EventHandler(this.cbxLineType_SelectedIndexChanged);
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(24, 158);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(60, 14);
            this.labelControl9.TabIndex = 14;
            this.labelControl9.Text = "导线型号：";
            // 
            // cbxPartition
            // 
            this.cbxPartition.Location = new System.Drawing.Point(362, 154);
            this.cbxPartition.Name = "cbxPartition";
            this.cbxPartition.Properties.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.cbxPartition.Properties.Appearance.Options.UseBorderColor = true;
            this.cbxPartition.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.cbxPartition.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxPartition.Properties.Items.AddRange(new object[] {
            "孝感",
            "武汉"});
            this.cbxPartition.Size = new System.Drawing.Size(145, 24);
            this.cbxPartition.TabIndex = 17;
            this.cbxPartition.SelectedIndexChanged += new System.EventHandler(this.cbxPartition_SelectedIndexChanged);
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(287, 158);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(60, 14);
            this.labelControl10.TabIndex = 16;
            this.labelControl10.Text = "区域名称：";
            // 
            // cbxVol
            // 
            this.cbxVol.Location = new System.Drawing.Point(95, 110);
            this.cbxVol.Name = "cbxVol";
            this.cbxVol.Properties.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.cbxVol.Properties.Appearance.Options.UseBorderColor = true;
            this.cbxVol.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.cbxVol.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxVol.Properties.Items.AddRange(new object[] {
            "500",
            "220",
            "110",
            "35"});
            this.cbxVol.Size = new System.Drawing.Size(145, 24);
            this.cbxVol.TabIndex = 23;
            this.cbxVol.SelectedIndexChanged += new System.EventHandler(this.cbxVol_SelectedIndexChanged);
            // 
            // btnPreView
            // 
            this.btnPreView.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnPreView.Appearance.Options.UseBorderColor = true;
            this.btnPreView.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnPreView.Location = new System.Drawing.Point(362, 200);
            this.btnPreView.Name = "btnPreView";
            this.btnPreView.Size = new System.Drawing.Size(145, 23);
            this.btnPreView.TabIndex = 24;
            this.btnPreView.Text = "线路信息预览";
            this.btnPreView.Click += new System.EventHandler(this.btnPreView_Click);
            // 
            // btnField
            // 
            this.btnField.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnField.Appearance.Options.UseBorderColor = true;
            this.btnField.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnField.Location = new System.Drawing.Point(95, 198);
            this.btnField.Name = "btnField";
            this.btnField.Size = new System.Drawing.Size(145, 23);
            this.btnField.TabIndex = 25;
            this.btnField.Text = "属性字段管理";
            this.btnField.Click += new System.EventHandler(this.btnField_Click);
            // 
            // labelControl11
            // 
            this.labelControl11.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl11.Location = new System.Drawing.Point(246, 21);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(7, 14);
            this.labelControl11.TabIndex = 26;
            this.labelControl11.Text = "*";
            // 
            // labelControl12
            // 
            this.labelControl12.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl12.Location = new System.Drawing.Point(246, 69);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(7, 14);
            this.labelControl12.TabIndex = 27;
            this.labelControl12.Text = "*";
            // 
            // labelControl13
            // 
            this.labelControl13.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl13.Location = new System.Drawing.Point(246, 164);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(7, 14);
            this.labelControl13.TabIndex = 28;
            this.labelControl13.Text = "*";
            // 
            // labelControl14
            // 
            this.labelControl14.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl14.Location = new System.Drawing.Point(513, 21);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(7, 14);
            this.labelControl14.TabIndex = 29;
            this.labelControl14.Text = "*";
            // 
            // labelControl15
            // 
            this.labelControl15.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl15.Location = new System.Drawing.Point(513, 69);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(7, 14);
            this.labelControl15.TabIndex = 30;
            this.labelControl15.Text = "*";
            // 
            // labelControl16
            // 
            this.labelControl16.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl16.Location = new System.Drawing.Point(513, 158);
            this.labelControl16.Name = "labelControl16";
            this.labelControl16.Size = new System.Drawing.Size(7, 14);
            this.labelControl16.TabIndex = 31;
            this.labelControl16.Text = "*";
            // 
            // labelControl17
            // 
            this.labelControl17.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl17.Location = new System.Drawing.Point(276, 118);
            this.labelControl17.Name = "labelControl17";
            this.labelControl17.Size = new System.Drawing.Size(7, 14);
            this.labelControl17.TabIndex = 32;
            this.labelControl17.Text = "*";
            // 
            // labelControl18
            // 
            this.labelControl18.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl18.Location = new System.Drawing.Point(546, 116);
            this.labelControl18.Name = "labelControl18";
            this.labelControl18.Size = new System.Drawing.Size(7, 14);
            this.labelControl18.TabIndex = 33;
            this.labelControl18.Text = "*";
            // 
            // LineAttribute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::NSC.GridPlan.PowerEquipment.UI.Properties.Resources.arcgis_background;
            this.ClientSize = new System.Drawing.Size(559, 235);
            this.Controls.Add(this.labelControl18);
            this.Controls.Add(this.labelControl17);
            this.Controls.Add(this.labelControl16);
            this.Controls.Add(this.labelControl15);
            this.Controls.Add(this.labelControl14);
            this.Controls.Add(this.labelControl13);
            this.Controls.Add(this.labelControl12);
            this.Controls.Add(this.labelControl11);
            this.Controls.Add(this.btnField);
            this.Controls.Add(this.btnPreView);
            this.Controls.Add(this.cbxVol);
            this.Controls.Add(this.cbxPartition);
            this.Controls.Add(this.labelControl10);
            this.Controls.Add(this.cbxLineType);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.txtLength);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.txtEnd);
            this.Controls.Add(this.txtStart);
            this.Controls.Add(this.cbxType);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "LineAttribute";
            this.Text = "线路属性信息";
            this.Load += new System.EventHandler(this.LineAttribute_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLength.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxLineType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxPartition.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxVol.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.ComboBoxEdit cbxType;
        private DevExpress.XtraEditors.TextEdit txtStart;
        private DevExpress.XtraEditors.TextEdit txtEnd;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txtLength;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.ComboBoxEdit cbxLineType;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.ComboBoxEdit cbxPartition;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.ComboBoxEdit cbxVol;
        private DevExpress.XtraEditors.SimpleButton btnPreView;
        private DevExpress.XtraEditors.SimpleButton btnField;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private DevExpress.XtraEditors.LabelControl labelControl16;
        private DevExpress.XtraEditors.LabelControl labelControl17;
        private DevExpress.XtraEditors.LabelControl labelControl18;
    }
}