using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;
using DevExpress.XtraEditors;
using DevExpress.LookAndFeel;
using DevExpress.DXperience.Demos;
using DevExpress.XtraBars;
using DevExpress.XtraVerticalGrid;
using DevExpress.XtraExport;
using DevExpress.XtraPrinting;
using DevExpress.XtraBars.Ribbon;


namespace DevExpress.XtraVerticalGrid.Demos {
	public class TutorialControl : TutorialControlBase {
		private DevExpress.Utils.Frames.NotePanel fDescription = null;
		
		public TutorialControl() {}

        public VGridRibbonMenuManager VertGridRibbonMenuManager { get { return RibbonMenuManager as VGridRibbonMenuManager; } }
        protected override void AllowExport() {
            EnabledPrintExportActions(true, ExportFormats.PDF | ExportFormats.HTML | ExportFormats.MHT | ExportFormats.XLS |
                ExportFormats.RTF | ExportFormats.Text | ExportFormats.XLSX, false);
        }
        public override bool AllowPrintOptions { get { return ExportControl != null; } }
		protected virtual void OnOptionsChanged(object sender, EventArgs e) {}

		protected override void SetControlManager(Control ctrl, BarManager manager) {
			DevExpress.XtraVerticalGrid.VGridControlBase vGrid = ctrl as DevExpress.XtraVerticalGrid.VGridControlBase;
			if(vGrid != null) vGrid.MenuManager = manager;
		}

		public DevExpress.Utils.Frames.NotePanel Description {
			get { return fDescription; }
			set { fDescription = value; 
				OnSetDescription("");	
			}
		}

		protected virtual void OnSetDescription(string fDescription) {
			if(fDescription == string.Empty) return;
			Description.Text = string.Format(fDescription);
		}
		
		public virtual VGridControlBase ExportControl { get { return null; }}
		public virtual VGridControlBase ViewOptionsControl { get { return null; }}
		void HideCustomization(ControlCollection collection) {
			foreach(Control ctrl in collection) {
				HideCustomization(ctrl.Controls);
				if(ctrl is VGridControlBase)
					((VGridControlBase)ctrl).DestroyCustomization();
			}
		}
		protected override void DoHide() {
			HideCustomization(this.Controls);
		}

        protected virtual void InitNWindData() {
            string DBFileName = string.Empty;
            DBFileName = DevExpress.Utils.FilesHelper.FindingFileName(Application.StartupPath, "Data\\nwind.mdb");
            if(DBFileName != string.Empty) {
                InitMDBData("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + DBFileName);
            }
        }
        protected virtual void InitMDBData(string connectionString) {
        }
        #region Print and Export
        protected override void ExportToCore(String filename, string ext) {
            if(ExportControl == null) return;
            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            if(ext == "rtf") ExportControl.ExportToRtf(filename);
            if(ext == "pdf") ExportControl.ExportToPdf(filename);
            if(ext == "mht") ExportControl.ExportToMht(filename, new MhtExportOptions());
            if(ext == "html") ExportControl.ExportToHtml(filename);
            if(ext == "txt") ExportControl.ExportToText(filename);
            if(ext == "xls") ExportControl.ExportToXls(filename);
            if(ext == "xlsx") ExportControl.ExportToXlsx(filename);
            Cursor.Current = currentCursor;
        }
        protected override void ExportToPDF() {
            ExportTo("pdf", "PDF document (*.pdf)|*.pdf");
        }
        protected override void ExportToHTML() {
            ExportTo("html", "HTML document (*.html)|*.html");
        }
        protected override void ExportToMHT() {
            ExportTo("mht", "MHT document (*.mht)|*.mht");
        }
        protected override void ExportToXLS() {
            ExportTo("xls", "XLS document (*.xls)|*.xls");
        }
        protected override void ExportToXLSX() {
            ExportTo("xlsx", "XLSX document (*.xlsx)|*.xlsx");
        }
        protected override void ExportToRTF() {
            ExportTo("rtf", "RTF document (*.rtf)|*.rtf");
        }
        protected override void ExportToText() {
            ExportTo("txt", "Text document (*.txt)|*.txt");
        }
        protected override void PrintPreview() {
            if(this.ExportControl != null) {
                if(RibbonMenuManager.PrintOptions.ShowRibbonPreviewForm)
                    this.ExportControl.ShowRibbonPrintPreview();
                else this.ExportControl.ShowPrintPreview();
            }
        }
        #endregion

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // TutorialControl
            // 
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Appearance.Options.UseFont = true;
            this.Name = "TutorialControl";
            this.Load += new System.EventHandler(this.TutorialControl_Load);
            this.ResumeLayout(false);

        }

        private void TutorialControl_Load(object sender, EventArgs e)
        {

        }
	}
    public class VGridRibbonMenuManager : RibbonMenuManager {
        VGridControlBase currentVGrid = null;
        BarSubItem bsiViewOptions;
        public VGridRibbonMenuManager(RibbonMainForm form)
            : base(form) {
            CreateOptionsMenu(form.ReservGroup1, form.Ribbon);
        }
        void CreateOptionsMenu(RibbonPageGroup ribbonPageGroup, RibbonControl ribbonControl) {
            ribbonPageGroup.Text = "Options";
            bsiViewOptions = new BarSubItem();
            bsiViewOptions.Caption = "View\n Options";
            MainFormHelper.SetBarButtonImage(bsiViewOptions, "View");
            ribbonControl.Items.Add(bsiViewOptions);
            ribbonPageGroup.ItemLinks.Add(bsiViewOptions);
        }
        public void RefreshOptionsMenu(VGridControlBase vGrid) {
            currentVGrid = vGrid;
            ShowReservGroup1(vGrid != null);
            LookAndFeelMenu.ClearOptionItems(Manager);
            LookAndFeelMenu.AddOptionsMenu(bsiViewOptions, ViewOptions, new ItemClickEventHandler(miViewOptions_Click), Manager);
        }
        private object ViewOptions {
            get {
                if(currentVGrid == null) return null;
                return currentVGrid.OptionsView;
            }
        }
        void miViewOptions_Click(object sender, ItemClickEventArgs e) {
            OptionBarItem item = e.Item as OptionBarItem;
            if(currentVGrid != null && item != null) {
                DevExpress.Utils.SetOptions.SetOptionValueByString(item.Caption, ViewOptions, item.Checked);
                LookAndFeelMenu.InitOptionsMenu(bsiViewOptions, ViewOptions);
            }
        }
    }
}
