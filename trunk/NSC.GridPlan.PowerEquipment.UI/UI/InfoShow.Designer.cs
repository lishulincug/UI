namespace NSC.GridPlan.PowerEquipment.UI
{
    partial class InfoShow
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
            this.DetialAtrribute = new DevExpress.XtraEditors.GroupControl();
            this.vGridDdtial = new DevExpress.XtraVerticalGrid.VGridControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.listNavigate = new DevExpress.XtraTreeList.TreeList();
            this.list = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DetialAtrribute)).BeginInit();
            this.DetialAtrribute.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vGridDdtial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listNavigate)).BeginInit();
            this.SuspendLayout();
            // 
            // DetialAtrribute
            // 
            this.DetialAtrribute.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.DetialAtrribute.Controls.Add(this.vGridDdtial);
            this.DetialAtrribute.Dock = System.Windows.Forms.DockStyle.Right;
            this.DetialAtrribute.Location = new System.Drawing.Point(171, 0);
            this.DetialAtrribute.Name = "DetialAtrribute";
            this.DetialAtrribute.Size = new System.Drawing.Size(329, 437);
            this.DetialAtrribute.TabIndex = 0;
            this.DetialAtrribute.Text = "groupControl1";
            // 
            // vGridDdtial
            // 
            this.vGridDdtial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vGridDdtial.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView;
            this.vGridDdtial.Location = new System.Drawing.Point(2, 22);
            this.vGridDdtial.Name = "vGridDdtial";
            this.vGridDdtial.OptionsView.AutoScaleBands = true;
            this.vGridDdtial.Size = new System.Drawing.Size(325, 413);
            this.vGridDdtial.TabIndex = 0;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.listNavigate);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(171, 437);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "成员";
            // 
            // listNavigate
            // 
            this.listNavigate.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.list});
            this.listNavigate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listNavigate.Location = new System.Drawing.Point(2, 22);
            this.listNavigate.Name = "listNavigate";
            this.listNavigate.Size = new System.Drawing.Size(167, 413);
            this.listNavigate.TabIndex = 0;
            this.listNavigate.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.listNavigate_FocusedNodeChanged);
            // 
            // list
            // 
            this.list.Caption = "成员列表";
            this.list.FieldName = "成员列表";
            this.list.Name = "list";
            this.list.Visible = true;
            this.list.VisibleIndex = 0;
            // 
            // InfoShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 437);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.DetialAtrribute);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "InfoShow";
            this.Text = "InfoShow";
            this.Load += new System.EventHandler(this.InfoShow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DetialAtrribute)).EndInit();
            this.DetialAtrribute.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vGridDdtial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listNavigate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl DetialAtrribute;
        private DevExpress.XtraVerticalGrid.VGridControl vGridDdtial;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraTreeList.TreeList listNavigate;
        private DevExpress.XtraTreeList.Columns.TreeListColumn list;
    }
}