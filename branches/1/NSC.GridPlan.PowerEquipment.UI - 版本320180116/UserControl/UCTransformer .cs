using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NSC.GridPlan.PowerEquipment.UI.Tables;
using NSC.PMSHandler.DataContractObjects;

namespace NSC.GridPlan.PowerEquipment.UI.UserControl
{
    public partial class UCTransformer : DevExpress.XtraEditors.XtraUserControl
    {
        public UCTransformer()
        {
            InitializeComponent();
        }

        private void UCTransformer_Load(object sender, EventArgs e)
        {
            //获取表结构
            DataTable dtTrans = SubStationTable.GetSubStaTable("主变");
            //绑定表结构
            //this.gcTrans.DataSource = dtTrans;
            //this.gcTrans.MainView = gvTrans;
            //gvTrans.PopulateColumns();      
        }
    }
}
