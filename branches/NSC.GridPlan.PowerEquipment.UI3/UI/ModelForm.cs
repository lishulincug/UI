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
    public partial class ModelForm : Form
    {
        public ModelForm()
        {
            InitializeComponent();
        }

        private void ModelForm_Load(object sender, EventArgs e)
        {

            
        }

        //private void InitData()
        //{
        //    RecordOrder[] records = new RecordOrder[10];
        //    records[0] = new RecordOrder("ProductName", "Mishi Kobe Niku", "Teatime Chocolate Biscuits", "Ipoh Coffee");
        //    records[1] = new RecordOrder("Category", 6, 3, 1);
        //    records[2] = new RecordOrder("Supplier", "Tokyo Traders", "Specialty Biscuits, Ltd.", "Leka Trading");
        //    records[3] = new RecordOrder("QuantityPerUnit", "18 - 500 g pkgs.", "10 boxes x 12 pieces", "16 - 500 g tins");
        //    records[4] = new RecordOrder("UnitPrice", 97.00, 9.20, 46.00);
        //    records[5] = new RecordOrder("UnitsInStock", 29, 25, 17);
        //    records[6] = new RecordOrder(Properties.Resources.Discontinued, false, true, true);
        //    records[7] = new RecordOrder(Properties.Resources.LastOrder, new DateTime(2001, 12, 14), new DateTime(2003, 7, 20), new DateTime(2002, 1, 7));
        //    records[8] = new RecordOrder(Properties.Resources.Picture, Properties.Resources.product1, Properties.Resources.product2, Properties.Resources.product3);
        //    records[9] = new RecordOrder(Properties.Resources.Relevance, 70, 90, 50);

        //    gridControl1.DataSource = records;
        //}

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
