using NSC.GridPlan.PowerEquipment.UI.Tables;
using NSC.GridPlan.PowerEquipment.UI.Class;
using NSC.PMSHandler.DataContractObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NSC.GridPlan.PowerEquipment.UI
{
    public partial class LineAttribute : Form
    {
        LineObjects mLine = new LineObjects();
        public LineAttribute()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 线路信息预览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPreView_Click(object sender, EventArgs e)
        {
            EquipmentInfoShow lineShow = EquipmentInfoShow.Instance();
            Dictionary<string, string> FieldName = LineTable.GetFieldName(mLine.BaseLine.LineType);
            Dictionary<string, object> FieldValue = LineTable.SetValueInfo(mLine);
            Dictionary<string, ComEditType> FieldLink = LineTable.GetFieldCom();         
            string[] groupName = new string[3];
            groupName[2] = "基本信息";
            if (mLine.BaseLine.LineType.Contains("交流"))
                groupName[1] = "交流线信息";
            else
                groupName[1] = "直流线信息";
            groupName[0] = "线路长度信息";
            //lineShow.FillContent(groupName, FieldName, FieldValue, "徐行变");
            //lineShow.InitalGridControl(groupName, FieldName, FieldValue, FieldLink, "徐行变", "线路属性");
            lineShow.megreGridControl(vGridControl2);
            lineShow.megreGridControl(vGridDdtial);
            lineShow.megreGridControl(vGridControl1);
            lineShow.megreGridControl(vGridControl3);
            //lineShow.megreGridControl(vGridControl4);
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            mLine.BaseLine.LineName = txtName.Text;
        }
        private void cbxVol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cbxVol.Text))
                try
                { mLine.BaseLine.LineVol = Convert.ToInt32(cbxVol.Text); }
                catch
                { MessageBox.Show("请输入数值！"); }            
        }

        private void cbxLineType_SelectedIndexChanged(object sender, EventArgs e)
        {
            mLine.LineLen.LineModel = cbxLineType.Text;
        }

        private void cbxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            mLine.BaseLine.LineType = cbxType.Text;
        }
        private void txtLength_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtLength.Text))
                try
                { mLine.LineLen.LineLength = Convert.ToDouble(txtLength.Text); }
                catch
                { MessageBox.Show("请输入数值！"); }
                                                              
        }

        private void cbxPartition_SelectedIndexChanged(object sender, EventArgs e)
        {
            //mLine.BaseLine.
            //mLine.BaseLine.PartitionEx = cbxPartition.Text;
        }

        private void txtStart_TextChanged(object sender, EventArgs e)
        {
            mLine.BaseLine.Origin = txtStart.Text;
        }

        private void txtEnd_TextChanged(object sender, EventArgs e)
        {
            mLine.BaseLine.Destination = txtEnd.Text;
        }

        private void txtName_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtStart_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtEnd_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnField_Click(object sender, EventArgs e)
        {
            //EquipmentInfoShow lineShow = EquipmentInfoShow.Instance();
            FieldsManagement FieldsManage =  FieldsManagement.Instance();
        }

        private void LineAttribute_Load(object sender, EventArgs e)
        {

        }
        private void LineTrans_KeyPress(object sender, KeyPressEventArgs e)
        {
            BaseFunction.KeyPress(sender, e);
        }
        private void Trans_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void textBus_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void textPcr_EditValueChanged(object sender, EventArgs e)
        {

        }      
    }
}
