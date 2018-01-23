using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraVerticalGrid.Rows;
using DevExpress.XtraVerticalGrid.ViewInfo;
using DevExpress.XtraVerticalGrid;
 
namespace NSC.GridPlan.PowerEquipment.UI.UI
{
    public partial class Multi_select : Form
    {
        public Multi_select()
        {
            InitializeComponent();
            DevExpress.XtraVerticalGrid.Design.XViews.ConfigureDemoView(vGridControl1);
            //cbMultiselectMode.Properties.Items.AddEnum<DevExpress.XtraVerticalGrid.MultiSelectMode>();
        }

        private void cbMultiselectMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            //vGridControl1.OptionsSelectionAndFocus.MultiSelectMode = GetEnum<MultiSelectMode>(sender);
        }
        Random rnd = new Random();
        private void sbSelectSomeElements_Click(object sender, EventArgs e)
        {
            vGridControl1.ClearSelection();
            int iterationCount = -1;
            switch (vGridControl1.OptionsSelectionAndFocus.MultiSelectMode)
            {
                //case multiselectmode.recordselect:
                //    iterationcount = rnd.next(1, vgridcontrol1.recordcount);
                //    break;
                //case multiselectmode.rowselect:
                //    iterationcount = rnd.next(1, vgridcontrol1.viewinfo.rowsviewinfo.count);
                //    break;
                //case multiselectmode.cellselect:
                //    iterationcount = rnd.next(1, vgridcontrol1.viewinfo.rowsviewinfo.count * vgridcontrol1.recordcount);
                //    break;
            }
            for (int i = 0; i < iterationCount; i++)
            {
                int record = rnd.Next(0, vGridControl1.RecordCount);
                int rowIndex = rnd.Next(0, vGridControl1.ViewInfo.RowsViewInfo.Count);
                BaseRow row = vGridControl1.ViewInfo.RowsViewInfo.Cast<BaseRowViewInfo>().ToArray()[rowIndex].Row;
                int cell = rnd.Next(0, row.RowPropertiesCount);
                switch (vGridControl1.OptionsSelectionAndFocus.MultiSelectMode)
                {
                    //case MultiSelectMode.RecordSelect: vGridControl1.SelectRecord(record); break;
                    //case MultiSelectMode.RowSelect: vGridControl1.SelectRow(row); break;
                    //case MultiSelectMode.CellSelect: vGridControl1.SelectCell(record, row, cell); break;
                }
            }
        }
        bool GetBoolValue(object sender)
        {
            return ((CheckEdit)sender).Checked;
        }
        T GetEnum<T>(object sender)
        {
            return (T)((ImageComboBoxEdit)sender).EditValue;
        }
        private void cheMultiselect_CheckedChanged(object sender, EventArgs e)
        {
            bool value = GetBoolValue(sender);
            vGridControl1.OptionsSelectionAndFocus.MultiSelect = value;
            cbMultiselectMode.Enabled = value;
        }

        private void vGridControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
