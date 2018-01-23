namespace NSC.GridPlan.PowerEquipment.UI.UI
{
    partial class SubstationNew
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SubstationNew));
            this.commonBar1 = new DevExpress.XtraSpreadsheet.UI.CommonBar();
            this.spreadsheetControl1 = new DevExpress.XtraSpreadsheet.SpreadsheetControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.tableStyleOptionsBar1 = new DevExpress.XtraSpreadsheet.UI.TableStyleOptionsBar();
            this.toolDB = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // commonBar1
            // 
            this.commonBar1.Control = this.spreadsheetControl1;
            this.commonBar1.DockCol = 0;
            this.commonBar1.DockRow = 0;
            this.commonBar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            // 
            // spreadsheetControl1
            // 
            this.spreadsheetControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spreadsheetControl1.Location = new System.Drawing.Point(0, 25);
            this.spreadsheetControl1.Name = "spreadsheetControl1";
            this.spreadsheetControl1.Size = new System.Drawing.Size(725, 314);
            this.spreadsheetControl1.TabIndex = 5;
            this.spreadsheetControl1.Text = "spreadsheetControl1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolDB,
            this.toolStripLabel1,
            this.toolStripTextBox1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(725, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(96, 22);
            this.toolStripLabel1.Text = "toolStripLabel1";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 25);
            // 
            // tableStyleOptionsBar1
            // 
            this.tableStyleOptionsBar1.Control = this.spreadsheetControl1;
            this.tableStyleOptionsBar1.DockCol = 1;
            this.tableStyleOptionsBar1.DockRow = 0;
            this.tableStyleOptionsBar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            // 
            // toolDB
            // 
            this.toolDB.Image = ((System.Drawing.Image)(resources.GetObject("toolDB.Image")));
            this.toolDB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDB.Name = "toolDB";
            this.toolDB.Size = new System.Drawing.Size(52, 22);
            this.toolDB.Text = "入库";
            this.toolDB.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.toolDB.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // SubstationNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 339);
            this.Controls.Add(this.spreadsheetControl1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "SubstationNew";
            this.Text = "SubstationNew";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraSpreadsheet.UI.CommonBar commonBar1;
        private DevExpress.XtraSpreadsheet.SpreadsheetControl spreadsheetControl1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolDB;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private DevExpress.XtraSpreadsheet.UI.TableStyleOptionsBar tableStyleOptionsBar1;
    }
}