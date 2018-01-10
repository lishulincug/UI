using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NSC.GridPlan.PowerEquipment.UI.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void SubStationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //开启新的窗口
            SubStationAttribute SubStationfm = new SubStationAttribute();
            SubStationfm.ShowDialog();
        }

        private void StationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StationAttribute Stationfm = new StationAttribute();
            Stationfm.ShowDialog();
        }

        private void LineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LineAttribute Linefm = new LineAttribute();
            Linefm.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
