namespace NSC.GridPlan.PowerEquipment.UI.UI
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Sub1StationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.line1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Sub1StationToolStripMenuItem,
            this.StationToolStripMenuItem,
            this.LineToolStripMenuItem,
            this.SubToolStripMenuItem,
            this.line1ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(346, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Sub1StationToolStripMenuItem
            // 
            this.Sub1StationToolStripMenuItem.CheckOnClick = true;
            this.Sub1StationToolStripMenuItem.DoubleClickEnabled = true;
            this.Sub1StationToolStripMenuItem.Name = "Sub1StationToolStripMenuItem";
            this.Sub1StationToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
            this.Sub1StationToolStripMenuItem.Text = "变电站";
            this.Sub1StationToolStripMenuItem.Click += new System.EventHandler(this.Sub1StationToolStripMenuItem_Click);
            // 
            // StationToolStripMenuItem
            // 
            this.StationToolStripMenuItem.Name = "StationToolStripMenuItem";
            this.StationToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.StationToolStripMenuItem.Text = "电源";
            this.StationToolStripMenuItem.Click += new System.EventHandler(this.StationToolStripMenuItem_Click);
            // 
            // LineToolStripMenuItem
            // 
            this.LineToolStripMenuItem.Name = "LineToolStripMenuItem";
            this.LineToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.LineToolStripMenuItem.Text = "线路";
            this.LineToolStripMenuItem.Click += new System.EventHandler(this.LineToolStripMenuItem_Click);
            // 
            // SubToolStripMenuItem
            // 
            this.SubToolStripMenuItem.Name = "SubToolStripMenuItem";
            this.SubToolStripMenuItem.Size = new System.Drawing.Size(63, 21);
            this.SubToolStripMenuItem.Text = "变电站1";
            this.SubToolStripMenuItem.Click += new System.EventHandler(this.SubToolStripMenuItem_Click);
            // 
            // line1ToolStripMenuItem
            // 
            this.line1ToolStripMenuItem.Name = "line1ToolStripMenuItem";
            this.line1ToolStripMenuItem.Size = new System.Drawing.Size(51, 21);
            this.line1ToolStripMenuItem.Text = "线路1";
            this.line1ToolStripMenuItem.Click += new System.EventHandler(this.line1ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 225);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "主菜单";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Sub1StationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem StationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SubToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem line1ToolStripMenuItem;
    }
}