using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NSC.GridPlan.PowerEquipment.UI.Class;

namespace NSC.GridPlan.PowerEquipment.UI.UI
{
    public partial class Substation : Form
    {
        string DBFileName = Application.StartupPath + "\\湖北省2012年地理接线图.mdb";
        const string
            NewRow = "New",
            TableGrid = "[GV_SUBSTATION]",
            TableLookUp = "GV_SUBSTATION_BUSBAR";       
        public Substation()
        {
            InitializeComponent();
            InitializeTable();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void InitializeTable()
        {
            DataSet ds = new DataSet();
            if (DBFileName != string.Empty)
            {
                string TableGV_AC_SUBSTATION_PT = "[GV_AC_SUBSTATION_PT]";
                string TableGV_SUBSTATION_BUSBAR = "[GV_SUBSTATION_BUSBAR]";
                string TableGV_SUBSTATION_PCR = "[GV_SUBSTATION_PCR]";
                IList<string> strGrouptableName = new List<string>();

                strGrouptableName.Add(TableGV_AC_SUBSTATION_PT);
                strGrouptableName.Add(TableGV_SUBSTATION_BUSBAR);
                strGrouptableName.Add(TableGV_SUBSTATION_PCR);
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("SELECT TOP 3 * FROM " + TableGrid, "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + DBFileName);
                DataBaseOp.SetWaitDialogCaption("Loading Order Details...");
                oleDbDataAdapter.Fill(ds, TableGrid);

                for (int i = 0; i < strGrouptableName.Count; i++)
                {
                    oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("SELECT TOP 2 * FROM " + strGrouptableName[i], "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + DBFileName);
                    DataBaseOp.SetWaitDialogCaption("Loading Products...");
                    oleDbDataAdapter.Fill(ds, strGrouptableName[i]);
                    //gridControl1.DataSource = ds.Tables[strGrouptableName[i]];
                }
                //ds.Tables.AddRange();
                //AllInitalGridControlByMdb(vGridControl2, ds, TableGrid,1);
                //InitalGridControlByMdb(vGridControl2, ds, TableGV_AC_SUBSTATION_PT, 1);
                //InitalGridControlByMdb(vGridControl2, ds, TableGV_SUBSTATION_BUSBAR, 1);
                //InitalGridControlByMdb(vGridControl2, ds, TableGV_SUBSTATION_PCR, 1);
                gridControl1.DataSource = ds.Tables[TableGrid];
                //vGridControl4.Rows.Add
                //repositoryItemLookUpEdit1.DataSource = ds.Tables[TableLookUp];
                gridControl1.Show();
            }   
        }
    }
}
