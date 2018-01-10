using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using NSC.GridPlan.PowerEquipment.UI.Class;
using NSC.GridPlan.PowerEquipment.UI.Tables;
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
    public partial class SubStationAttribute : Form
    {
        SubStaObjects mSubSta = new SubStaObjects();//变电站信息全局变量
        string path = Application.StartupPath + @"\DataStructModel.xml";//模型路径
        string SubPath = Application.StartupPath + @"\DataSubStructModel.xml";//子模型路径
        public SubStationAttribute()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 主变点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTrans_Click(object sender, EventArgs e)
        {
            SetTransView();
            BindTransData();
        }
        /// <summary>
        /// 母线点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBus_Click(object sender, EventArgs e)
        {
            SetBusView();
            BindBusData();
        }
        /// <summary>
        /// 主变状态
        /// </summary>
        private void SetTransView()
        {
            if (cbxType.Text.Contains("直流"))
            {
                if (this.Controls.Contains(this.panelBus))
                    this.Controls.Remove(this.panelBus);
                if (this.Controls.Contains(this.panelTrans))
                    this.Controls.Remove(this.panelTrans);
                if (!this.Controls.Contains(this.panelDCSub))
                    this.Controls.Add(panelDCSub);
                this.panelDCSub.Dock = DockStyle.Bottom;
                this.panelDCSub.BringToFront();
                this.panelDCSub.Visible = true;
                this.panelTrans.Visible = false;
            }
            else
            {
                if (this.Controls.Contains(this.panelBus))
                    this.Controls.Remove(this.panelBus);
                if (this.Controls.Contains(this.panelDCSub))
                    this.Controls.Remove(this.panelDCSub);
                if(!this.Controls.Contains(this.panelTrans))
                    this.Controls.Add(this.panelTrans);
                this.panelTrans.Dock = DockStyle.Bottom;
                this.panelTrans.BringToFront();
                this.panelTrans.Visible = true;
                this.panelBus.Visible = false;
            }
        }
        /// <summary>
        /// 绑定主变数据
        /// </summary>
        private void BindTransData()
        {
            //获取表结构
            DataTable dtTrans = SubStationTable.GetSubStaTable("主变"); 
            //绑定表结构
            this.gcTrans.DataSource = dtTrans;
            this.gcTrans.MainView = gvTrans;
            gvTrans.PopulateColumns();                      
            //绑定数据
            int mTransNum = BaseFunction.GetCode(txtTransCode.Text);//获取台数; 
            mSubSta.SubGUSCollection.Clear();
            for (int i = 0; i < mTransNum; i++)
            {
                gvTrans.AddNewRow();
                //赋值
                SubGSUObjects mSubGUS = new SubGSUObjects();
                mSubGUS.GSU.GSUCode =(i+1).ToString();
                mSubSta.SubGUSCollection.Add(mSubGUS);
            }
            //自适应
            gvTrans.BestFitColumns();
            this.gvTrans.Tag = "变电站主变";
           
        }
        /// <summary>
        /// 绑定母线、电容电抗数据
        /// </summary>
        private void BindBusData()
        {
            DataTable dtBus = SubStationTable.GetSubStaTable("母线");
            RepositoryItemComboBox repositoryWorkWay = new RepositoryItemComboBox();
            RepositoryItemComboBox repositoryCapacitive = new RepositoryItemComboBox();
            this.gcBus.DataSource = dtBus;
            gvBus.PopulateColumns();
            gvBus.Columns["运行方式"].ColumnEdit = repositoryWorkWay;
            gvBus.Columns["并联电容电抗"].ColumnEdit = repositoryCapacitive;
            //绑定数据
            int mBusNum = BaseFunction.GetCode(txtBusNum.Text);//获取主变号;     
            mSubSta.SubBusCollection.Clear();
            for (int i = 0; i < mBusNum; i++)
            {
                gvBus.AddNewRow();
                SubBusObjects mSubBus = new SubBusObjects();
                mSubBus.SubBus.BusCode = (i+1).ToString();
                mSubSta.SubBusCollection.Add(mSubBus);
                //mSubSta.SubBusCollection[0].SubBus.
            }
            gvBus.BestFitColumns();
            this.gvBus.Tag = "变电站母线";
        }
        /// <summary>
        /// 母线状态
        /// </summary>
        private void SetBusView()
        {
            if (this.Controls.Contains(this.panelDCSub))
                this.Controls.Remove(this.panelDCSub);
            if (this.Controls.Contains(this.panelTrans))
                this.Controls.Remove(this.panelTrans);
            this.Controls.Add(panelBus);
            this.panelBus.Dock = DockStyle.Bottom;
            this.panelBus.BringToFront();
            this.panelBus.Visible = true;
            this.panelTrans.Visible = false;
        }
        /// <summary>
        /// 初始化加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SubStationAttribute_Load(object sender, EventArgs e)
        {
            //变电站类型初始化
            //cbxType.Properties.Items.Add("交流变电站");
            //cbxType.Properties.Items.Add("直流换流站");
            cbxType.SelectedItem = cbxType.Properties.Items[0];
            cbxType.Text = cbxType.Properties.Items[0].ToString();
            //主变初始化
            //SetTransView();
           // BindTransData();
        }
        /// <summary>
        /// 变电站类型改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SetTransView();
            mSubSta.BaseSub.SubType = cbxType.Text;
        }
        /// <summary>
        /// 变电站属性汇总预览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPreview_Click(object sender, EventArgs e)
        {
            EquipmentInfoShow lineShow = EquipmentInfoShow.Instance();
            Dictionary<string, string> FieldName = SubStationTable.GetFieldName("交流");
            Dictionary<string, object> FieldValue = SubStationTable.GetValueInfo(mSubSta);
            Dictionary<string, ComEditType> FieldLink = SubStationTable.GetFieldCom();
            Dictionary<string, bool> FieldItem = SubStationTable.GetFieldItem();
            string[] groupName = new string[4];
            groupName[3] = "基本信息";
            groupName[2] = "主变信息";
            groupName[1] = "母线信息";
            groupName[0] = "串补信息";
            lineShow.InitalGridControl(groupName, FieldName, FieldValue, FieldLink, txtName.Text, "变电站属性");
        }

        private void gvTrans_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gvTrans.SetRowCellValue(e.RowHandle, gvTrans.Columns[0], gvTrans.RowCount);
            gvTrans.UpdateCurrentRow();
            gcTrans.RefreshDataSource();
          
        }
        /// <summary>
        /// 母线数量变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBusNum_TextChanged(object sender, EventArgs e)
        {
            //注：初始化默认母线为2条
            int mBusNum = BaseFunction.GetCode(txtBusNum.Text);//获取母线数量          
            //母线表修改
            BaseFunction.GridViewChanged(gvBus, mBusNum,mSubSta);
        }
        /// <summary>
        /// 添加或删除母线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvBus_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            gvBus.SetRowCellValue(e.RowHandle, gvBus.Columns[0], gvBus.RowCount);
            gvBus.UpdateCurrentRow();
            gcBus.RefreshDataSource();   
        }
        /// <summary>
        /// 主变数量限定只能输入数值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTransCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            BaseFunction.KeyPress(sender,e); 
        }
        /// <summary>
        /// 主变数量变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTransCode_TextChanged(object sender, EventArgs e)
        {
            //注：初始化默认主变为3台
            int mTransNum = BaseFunction.GetCode(txtTransCode.Text);//获取主变台数          
            //主变表修改
            BaseFunction.GridViewChanged(gvTrans, mTransNum,mSubSta);  
          
        }
        /// <summary>
        /// 限定母线输入为数值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBusNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            BaseFunction.KeyPress(sender, e); 
        }
        /// <summary>
        /// 变电站名称改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            mSubSta.BaseSub.SubName = txtName.Text;               
        }
        /// <summary>
        /// 主变数量变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvTrans_RowCountChanged(object sender, EventArgs e)
        {
            //if (mSubSta.SubGUSCollection.Count > gvTrans.RowCount)//移除多余行
            //{
            //    for (int i = mSubSta.SubGUSCollection.Count; i >= gvTrans.RowCount; i--)
            //    {
            //        SubGSUObjects mSubGUS = new SubGSUObjects();
            //        mSubGUS.GSU.GSUCode = gvTrans.GetRowCellValue(i, gvTrans.Columns[0]).ToString();
            //        mSubSta.SubGUSCollection.Remove(mSubGUS);
            //    }
            //}
            //else//添加行
            //{
            //    for (int j = mSubSta.SubGUSCollection.Count; j < gvTrans.RowCount; j++)
            //    {
            //        SubGSUObjects mSubGUS = new SubGSUObjects();
            //        mSubGUS.GSU.GSUCode = gvTrans.GetRowCellValue(j, gvTrans.Columns[0]).ToString();
            //        mSubSta.SubGUSCollection.Add(mSubGUS);
            //    }
            //}
        }
        /// <summary>
        /// 母线数量变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvBus_RowCountChanged(object sender, EventArgs e)
        {
            //if (mSubSta.SubBusCollection.Count > gvBus.RowCount)//移除多余行
            //{
            //    for (int i = mSubSta.SubBusCollection.Count; i >= gvBus.RowCount; i--)
            //    {
            //        SubBusObjects mSubBus = new SubBusObjects();
            //        mSubBus.SubBus.BusCode = gvBus.GetRowCellValue(i, gvBus.Columns[0]).ToString();
            //        mSubSta.SubBusCollection.Remove(mSubBus);
            //    }
            //}
            //else//添加行
            //{
            //    for (int j = mSubSta.SubBusCollection.Count; j < gvBus.RowCount; j++)
            //    {
            //        SubBusObjects mSubBus = new SubBusObjects();
            //        mSubBus.SubBus.BusCode = gvBus.GetRowCellValue(j, gvBus.Columns[0]).ToString();
            //        mSubSta.SubBusCollection.Add(mSubBus);
            //    }
            //}
        }

        private void cbxVol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxVol.Text != "")
            {
                try
                { mSubSta.BaseSub.SubVol = Convert.ToInt16(cbxVol.Text); }
                catch
                { MessageBox.Show("电压等级请输入数值！"); }
            }
        }       

        private void txtSimple_SelectedIndexChanged(object sender, EventArgs e)
        {
            mSubSta.BaseSub.SimName = txtSimple.Text;
        }
       

        private void txtName_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtSimple_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void cbxPartition_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            mSubSta.BaseSub.Partition = cbxPartition.Text;           
        }

        private void cbxRegion_SelectedIndexChanged(object sender, EventArgs e)
        {          
            mSubSta.BaseSub.PartitionEx = cbxRegion.Text;               
        }

        private void gridLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void listNavigate_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {

        }

        private void vGridDdtial_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void toolDB_Click(object sender, EventArgs e)
        {
            //DataTable dtData = this.vGridControl.DataSource as DataTable;
            //DataBaseOp.DataOperator(dtData);
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            //注：初始化默认主变为3台
            int mTransNum = BaseFunction.GetCode(txtTransCode.Text);//获取主变台数          
            //主变表修改
            //BaseFunction.GridViewChanged(gvTrans, mTransNum, mSubSta);
            List<StructTable> mStructTableCollect = AnalysisDataStruct.AnalysisData(path, "SubStationTrans");
            FillVGrid vGrid = new FillVGrid();
            vGrid.InitalGridData(mStructTableCollect, vGridDdtial);
        }

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {
            //注：初始化默认母线为2条
            int mBusNum = BaseFunction.GetCode(txtBusNum.Text);//获取母线数量          
            //母线表修改
            BaseFunction.GridViewChanged(gvBus, mBusNum, mSubSta);
        }

        private void listNavigate_FocusedNodeChanged_1(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (this.listNavigate.FocusedNode.GetDisplayText(0).ToString().Contains("母线") & this.listNavigate.FocusedNode.Level==1)
            {
                List<StructTable> SubStructTableCollect = AnalysisDataStruct.AnalysisData(SubPath, "SubSubStationBus");
                FillVGrid vGrid = new FillVGrid();
                vGrid.InitalGridData(SubStructTableCollect, vGridDdtial);
            }
            else if (this.listNavigate.FocusedNode.GetDisplayText(0).ToString().Contains("主变") & this.listNavigate.FocusedNode.Level==1)
            {
                List<StructTable> SubStructTableCollect = AnalysisDataStruct.AnalysisData(SubPath, "SubSubStationTrans");
                FillVGrid vGrid = new FillVGrid();
                vGrid.InitalGridData(SubStructTableCollect, vGridDdtial);
            }
            else if (this.listNavigate.FocusedNode.GetDisplayText(0).ToString().Contains("机组") & this.listNavigate.FocusedNode.Level==1)
            {
                List<StructTable> SubStructTableCollect = AnalysisDataStruct.AnalysisData(SubPath, "SubSubStationJizu");
                FillVGrid vGrid = new FillVGrid();
                vGrid.InitalGridData(SubStructTableCollect, vGridDdtial);
            }
            else if (this.listNavigate.FocusedNode.GetDisplayText(0).ToString().Contains("机组") & this.listNavigate.FocusedNode.Level == 0)
            {
                List<StructTable> SubStructTableCollect = AnalysisDataStruct.AnalysisData(path, "SubSubStationJizu");
                FillVGrid vGrid = new FillVGrid();
                vGrid.InitalGridData(SubStructTableCollect, vGridDdtial);
            }
            else if (this.listNavigate.FocusedNode.GetDisplayText(0).ToString().Contains("主变") & this.listNavigate.FocusedNode.Level == 0)
            {
                List<StructTable> SubStructTableCollect = AnalysisDataStruct.AnalysisData(path, "SubStationTrans");
                FillVGrid vGrid = new FillVGrid();
                vGrid.InitalGridData(SubStructTableCollect, vGridDdtial);
            }
            else if (this.listNavigate.FocusedNode.GetDisplayText(0).ToString().Contains("母线") & this.listNavigate.FocusedNode.Level == 0)
            {
                List<StructTable> SubStructTableCollect = AnalysisDataStruct.AnalysisData(path, "SubStationBus");
                FillVGrid vGrid = new FillVGrid();
                vGrid.InitalGridData(SubStructTableCollect, vGridDdtial);
            }
        }

        private void vGridDdtial_Click_1(object sender, EventArgs e)
        {

        }
    }              
}
