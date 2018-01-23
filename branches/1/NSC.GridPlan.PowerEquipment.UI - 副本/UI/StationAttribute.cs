using DevExpress.XtraEditors.Repository;
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
    public partial class StationAttribute : Form
    {
        SubStaObjects mSubSta = new SubStaObjects();
        string DBFileName = Application.StartupPath + "\\湖北省2012年地理接线图.mdb";
        const string
            NewRow = "New",
            TableGrid = "[GV_STATION]",
            TableLookUp = "GV_STATION_GENERATORSET";
  
        /// <summary>
        /// 分组控件
        /// </summary>
        /// 
        private DevExpress.XtraVerticalGrid.Rows.CategoryRow nCategoryRow;
        private DevExpress.XtraVerticalGrid.Rows.CategoryRow mCategoryRow;
        /// <summary>
        /// 行控件
        /// </summary>
        private DevExpress.XtraVerticalGrid.Rows.EditorRow mEditorRow;
        /// <summary>
        /// 选择控件
        /// </summary>
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox mRepositoryItemComboBox;
        /// <summary>
        /// Item控件
        /// </summary>
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit mRepositoryItemButtonEdit;
        public static EquipmentInfoShow theSingleton = null;
        public StationAttribute()
        {
            InitializeComponent();
        }

        /// <summary>
        /// VGridControl 行宽自动调整
        /// </summary>
        private void RecalcWidth(DevExpress.XtraVerticalGrid.VGridControl vGridControlx)
        {
            int recordWidth = (vGridControlx.Width - vGridControlx.RowHeaderWidth) / vGridControlx.Rows.Count;
            if (recordWidth > vGridControlx.RecordMinWidth)
            {
                vGridControlx.RecordWidth = recordWidth;
                vGridControlx.ScrollVisibility = DevExpress.XtraVerticalGrid.ScrollVisibility.Vertical;
            }
            else
            {
                vGridControlx.ScrollVisibility = DevExpress.XtraVerticalGrid.ScrollVisibility.Auto;
            }
        }
        /// <summary>
        /// mdb转表格生成
        /// </summary>
        /// <param name="strGroupName"></param>
        /// <param name="FieldName"></param>
        /// <param name="FieldValue"></param>
        /// <param name="FieldLink"></param>
        /// <param name="iCount"></param>
        private void InitalGridControlByMdb(DevExpress.XtraVerticalGrid.VGridControl vGridControlx, DataSet Ds, string tableName)
        {
            //string[] strGroup = FieldName[strGroupName].Split(',');

            if (DBFileName != string.Empty)
            {
                string TableMETADATA_FIELD = "[METADATA_FIELD]";
                DataSet dsInt = new DataSet();
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("SELECT   * FROM " + TableMETADATA_FIELD, "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + DBFileName);
                DataBaseOp.SetWaitDialogCaption("Loading Order Details...");
                oleDbDataAdapter.Fill(dsInt, TableMETADATA_FIELD);
            }
            IList<string> strGroupName1 = new List<string>();
            strGroupName1.Add("必填");
            strGroupName1.Add("选填");
            if (Ds.Tables[tableName] != null)
            {
                vGridControlx.Rows.Clear();
                nCategoryRow = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
                nCategoryRow.Properties.Caption = strGroupName1[0];
                vGridControlx.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
                nCategoryRow});
                nCategoryRow.Grid.Dock = DockStyle.Fill;

                mCategoryRow = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
                mCategoryRow.Properties.Caption = strGroupName1[1];
                vGridControlx.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
                mCategoryRow});
                mCategoryRow.Grid.Dock = DockStyle.Fill;
                
                //}
                //判断是否存在重复组
                //if (!FieldName.ContainsKey(strGroupName1[k]))
                //    return;
                //string[] strName = FieldName[strGroupName1[k]].Split(',');
                //if (strName == null || strName.Length == 0)
                //    return;
                //循环填充表格
                for (int i = 0; i < Ds.Tables[tableName].Columns.Count; i++)
                {
                    string TableMETADATA_FIELD = "[METADATA_FIELD]";
                    DataSet ds = new DataSet();
                    System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("SELECT   ALIAS  FROM " + TableMETADATA_FIELD + "WHERE FIELDNAME =" + "'" + Ds.Tables[tableName].Columns[i].ColumnName + "'" + " AND " + "TABLENAME =" + "'" + tableName.Replace("[", "").Replace("]", "") + "'", "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + DBFileName);
                    DataBaseOp.SetWaitDialogCaption("Loading Order Details...");
                    oleDbDataAdapter.Fill(ds, TableMETADATA_FIELD);

                    //设置row属性
                    this.mEditorRow = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
                    this.mEditorRow.Name = Ds.Tables[tableName].Columns[i].ColumnName;
                    this.mEditorRow.Properties.FieldName = Ds.Tables[tableName].Columns[i].ColumnName;
                    this.mEditorRow.Properties.UnboundType = DevExpress.Data.UnboundColumnType.Object; //Ds.Tables[tableName].Columns[i].DataType; //
                    this.mEditorRow.Height = 20;
                    this.mEditorRow.Appearance.Options.UseForeColor = true;
                    if (Ds.Tables[tableName].Rows.Count > 0)
                    {
                        if (!(Ds.Tables[tableName].Rows[0][Ds.Tables[tableName].Columns[i].ColumnName] is System.DBNull) & ds.Tables[TableMETADATA_FIELD].Rows[0] != null)
                        {
                            this.mEditorRow.Properties.Caption = ds.Tables[TableMETADATA_FIELD].Rows[0]["ALIAS"].ToString();

                            this.nCategoryRow.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] { this.mEditorRow });
                        }
                        else if (Ds.Tables[tableName].Rows[0][Ds.Tables[tableName].Columns[i].ColumnName] is System.DBNull & ds.Tables[TableMETADATA_FIELD].Rows[0] != null)
                        {
                            this.mEditorRow.Properties.Caption = ds.Tables[TableMETADATA_FIELD].Rows[0]["ALIAS"].ToString();
                            this.mCategoryRow.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] { this.mEditorRow });
                        }
                        else
                        {
                            this.mEditorRow.Properties.Caption = Ds.Tables[tableName].Columns[i].ColumnName;
                            this.mCategoryRow.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] { this.mEditorRow });
                        }
                    }
                    else
                    {
                        this.mEditorRow.Properties.Caption = ds.Tables[TableMETADATA_FIELD].Rows[0]["ALIAS"].ToString();
                        this.mCategoryRow.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] { this.mEditorRow });
                    }
                }
            }
            // vGridControlx 行宽自动调整
            RecalcWidth(vGridControlx);
        }
        #region 界面事件
        /// <summary>
        /// 升压变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBoost_Click(object sender, EventArgs e)
        {
            SetBoostView();
            BindBoostData();
        }
        /// <summary>
        /// 母线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBus_Click(object sender, EventArgs e)
        {
            SetBusView();
            BindBusData();
        }
        /// <summary>
        /// 机组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUnit_Click(object sender, EventArgs e)
        {
            SetUnitView();
            BindUnitData();
        }
        /// <summary>
        /// 电源信息预览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPreView_Click(object sender, EventArgs e)
        {
            EquipmentInfoShow lineShow = EquipmentInfoShow.Instance();
            Dictionary<string, string> FieldName = StationTable.GetFieldName("交流");
            Dictionary<string, object> FieldValue = StationTable.GetValueInfo(mSubSta);
            //Dictionary<string, bool> FieldLink = StationTable.GetFieldLink();
            Dictionary<string, ComEditType> FieldLink = StationTable.GetFieldCom();
            Dictionary<string, bool> FieldItem = StationTable.GetFieldItem();
            string[] groupName = new string[4];
            groupName[3] = "基本信息";
            groupName[2] = "升压变信息";
            groupName[1] = "母线信息";
            groupName[0] = "机组信息";
            lineShow.InitalGridControl(groupName, FieldName, FieldValue, FieldLink, txtName.Text, "电源属性");
            
            //string path = Application.StartupPath + @"\DataStruct.xml";
            //List<StructTable> mStructTableCollect = AnalysisDataStruct.AnalysisData(path, "SubStation");
            //AttributeShow dataShow = AttributeShow.Instance();
            //dataShow.InitalGridData(mStructTableCollect, txtName.Text, "电源属性");
        }
        /// <summary>
        /// 升压变添加行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvBoost_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gvBoost.SetRowCellValue(e.RowHandle, gvBoost.Columns[0], gvBoost.RowCount);
            gvBoost.UpdateCurrentRow();
        }
        /// <summary>
        /// 升压变数量变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvBoost_RowCountChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 母线添加行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvBus_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gvBus.SetRowCellValue(e.RowHandle, gvBus.Columns[0], gvBus.RowCount);
            gvBus.UpdateCurrentRow();
        }
        /// <summary>
        /// 母线数量变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvBus_RowCountChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 母线数量改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBusNum_TextChanged(object sender, EventArgs e)
        {
            //注：初始化默认母线为3条
            int mNum = BaseFunction.GetCode(txtBusNum.Text);//获取母线数量          
            //电源母线表修改
            BaseFunction.GridViewChanged(gvBus, mNum);  
        }
        /// <summary>
        /// 限制输入数值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBusNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            BaseFunction.KeyPress(sender, e); 
        }
        /// <summary>
        /// 限制输入数值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBoostNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            BaseFunction.KeyPress(sender, e); 
        }
        /// <summary>
        /// 升压变改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBoostNum_TextChanged(object sender, EventArgs e)
        {
            //注：初始化默认升压变为3台
            int mNum = BaseFunction.GetCode(txtBoostNum.Text);//获取升压变台数          
            //升压变表修改
            BaseFunction.GridViewChanged(gvBoost, mNum);  
        }
        
        /// <summary>
        /// 添加机组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvUnit_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gvUnit.SetRowCellValue(e.RowHandle, gvUnit.Columns[0], gvUnit.RowCount);
            gvUnit.UpdateCurrentRow();
        }
        /// <summary>
        /// 机组数量改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvUnit_RowCountChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 机组数量变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUnitNum_TextChanged(object sender, EventArgs e)
        {
            //注：初始化默认机组为3台
            int mNum = BaseFunction.GetCode(txtUnitNum.Text);//获取机组台数        
            SubStaObjects mSubSta = new SubStaObjects();//变电站信息全局变量
            //机组表修改
            BaseFunction.GridViewChanged(gvUnit, mNum, mSubSta);  

        }
        /// <summary>
        /// 限定输入数值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUnitNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            BaseFunction.KeyPress(sender, e); 
        }
        #endregion
        #region 私有方法
        protected void InitNWindData()
        {
            if (DBFileName != string.Empty)
            {
                //InitMDBData("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + DBFileName);
                string TableGV_STATION = "[GV_STATION]";
                DataSet ds = new DataSet();
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("SELECT TOP 1 * FROM " + TableGV_STATION, "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + DBFileName);
                DataBaseOp.SetWaitDialogCaption("Loading Order Details...");
                oleDbDataAdapter.Fill(ds, TableGV_STATION);
                InitalGridControlByMdb(vGridControlStationBase, ds, TableGV_STATION);
                vGridControlStationBase.DataSource = ds.Tables[TableGV_STATION];
                vGridControlStationBase.BestFit();
            }
        }             
        /// <summary>
        /// 升压变视图
        /// </summary>
        private void SetBoostView()
        {
            if (this.Controls.Contains(this.panelBus))
                this.Controls.Remove(this.panelBus);
            if (this.Controls.Contains(this.panelUnit))
                this.Controls.Remove(this.panelUnit);
            this.Controls.Add(this.panelBoost);
            this.panelBoost.Dock = DockStyle.Bottom;
            this.panelBoost.BringToFront();
            this.panelBoost.Visible = true;
        }
        /// <summary>
        /// 母线视图
        /// </summary>
        private void SetBusView()
        {
            if (this.Controls.Contains(this.panelUnit))
                this.Controls.Remove(this.panelUnit);
            if (this.Controls.Contains(this.panelBoost))
                this.Controls.Remove(this.panelBoost);
            this.Controls.Add(panelBus);
            this.panelBus.Dock = DockStyle.Bottom;
            this.panelBus.BringToFront();
            this.panelBus.Visible = true;
        }
        /// <summary>
        /// 机组视图
        /// </summary>
        private void SetUnitView()
        {
            if (this.Controls.Contains(this.panelBoost))
                this.Controls.Remove(this.panelBoost);
            if (this.Controls.Contains(this.panelBus))
                this.Controls.Remove(this.panelBus);
            this.Controls.Add(panelUnit);
            this.panelUnit.Dock = DockStyle.Bottom;
            this.panelUnit.BringToFront();
            this.panelUnit.Visible = true;
        }
        /// <summary>
        /// 绑定升压变数据
        /// </summary>
        private void BindBoostData()
        {
            //获取表结构
            DataTable dtBoost = StationTable.GetStaTable("升压变");
            RepositoryItemComboBox repositoryWinding = new RepositoryItemComboBox();
            //绑定表结构
            this.gcBoost.DataSource = dtBoost;
            this.gcBoost.MainView = gvBoost;
            gvBoost.PopulateColumns();
            gvBoost.Columns["绕组数"].ColumnEdit = repositoryWinding;
            //绑定数据
            int mNum = BaseFunction.GetCode(this.txtBoostNum.Text);//获取台数; 
            mSubSta.SubGUSCollection.Clear();
            for (int i = 0; i < mNum; i++)
            {
                gvBoost.AddNewRow();
                //赋值
                SubGSUObjects mSubGUS = new SubGSUObjects();
                mSubGUS.GSU.GSUCode = (i + 1).ToString();
                mSubSta.SubGUSCollection.Add(mSubGUS);
            }
            //自适应
            gvBoost.BestFitColumns();
            this.gvBoost.Tag = "升压变";
        }
        /// <summary>
        /// 绑定母线数据
        /// </summary>
        private void BindBusData()
        {
            DataTable dtBus = StationTable.GetStaTable("母线");
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
                mSubBus.SubBus.BusCode = (i + 1).ToString();
                mSubSta.SubBusCollection.Add(mSubBus);
            }
            gvBus.BestFitColumns();
            this.gvBus.Tag = "电源母线";
        }
        /// <summary>
        /// 绑定机组数据
        /// </summary>
        private void BindUnitData()
        {
            DataTable dtUnit = StationTable.GetStaTable("机组");
            RepositoryItemComboBox repositoryUnitType = new RepositoryItemComboBox();
            RepositoryItemComboBox repositoryRelationTrans = new RepositoryItemComboBox();
            RepositoryItemComboBox repositoryModelLc = new RepositoryItemComboBox();
            RepositoryItemComboBox repositoryModelWd = new RepositoryItemComboBox();
            RepositoryItemComboBox repositoryModelTs= new RepositoryItemComboBox();
            this.gcUnit.DataSource = dtUnit;
            gvUnit.PopulateColumns();
            gvUnit.Columns["机组类型"].ColumnEdit = repositoryUnitType;
            gvUnit.Columns["关联主变号"].ColumnEdit = repositoryRelationTrans;
            gvUnit.Columns["励磁模型"].ColumnEdit = repositoryModelLc;
            gvUnit.Columns["电力系统稳定器"].ColumnEdit = repositoryModelWd;
            gvUnit.Columns["调速器模型"].ColumnEdit = repositoryModelTs;
            //绑定数据
            int mUnitNum = BaseFunction.GetCode(txtUnitNum.Text);//获取主变号; 
            mSubSta.SubBusCollection.Clear();
            for (int i = 0; i < mUnitNum; i++)
            {
                gvUnit.AddNewRow();
                SubBusObjects mSubBus = new SubBusObjects();
                mSubBus.SubBus.BusCode = (i + 1).ToString();
                mSubSta.SubBusCollection.Add(mSubBus);
            }
            gvUnit.BestFitColumns();
            this.gvUnit.Tag = "电源机组";
        }
        #endregion

        private void txtName_EditValueChanged(object sender, EventArgs e)
        {
            mSubSta.BaseSub.SubName = txtName.Text; 
        }

        private void cbxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            mSubSta.BaseSub.SubType = cbxType.Text;
        }

        private void cbxVol_SelectedIndexChanged(object sender, EventArgs e)
        {          
            if (!string.IsNullOrEmpty(cbxVol.Text))
                try
                { mSubSta.BaseSub.SubVol = Convert.ToInt32(cbxVol.Text); }
                catch
                { MessageBox.Show("请输入数值！"); }
        }

        private void cbxPartition_SelectedIndexChanged(object sender, EventArgs e)
        {
            mSubSta.BaseSub.Partition = cbxPartition.Text;
        }

        private void cbxRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            mSubSta.BaseSub.PartitionEx = cbxRegion.Text;
        }

        private void txtSimple_EditValueChanged(object sender, EventArgs e)
        {
            mSubSta.BaseSub.SimName = txtSimple.Text;
        }

        private void vGridControl4_Click(object sender, EventArgs e)
        {

        }

        private void StationAttribute_Load(object sender, EventArgs e)
        {
            // TODO:  这行代码将数据加载到表“湖北省2012年地理接线图DataSet.GV_STATION”中。您可以根据需要移动或删除它。
            //this.gV_STATIONTableAdapter.Fill(this.湖北省2012年地理接线图DataSet.GV_STATION);

        }

        private void vGridControl1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void vGridControl4_Click_1(object sender, EventArgs e)
        {

        }
        private void stationTrans_KeyPress(object sender, KeyPressEventArgs e)
        {
            BaseFunction.KeyPress(sender, e);
        }
        private void Trans_EditValueChanged(object sender, EventArgs e)
        {
            //注：初始化默认主变为3台
            int mTransNum = BaseFunction.GetCode(Trans.Text);//获取主变台数                   
            if (DBFileName != string.Empty)
            {
                //InitMDBData("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + DBFileName);
            }
            string TableGV_AC_SUBSTATION_PT = "[GV_AC_SUBSTATION_PT]";
            DataSet ds = new DataSet();
            System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("SELECT TOP " + mTransNum.ToString() + " * FROM " + TableGV_AC_SUBSTATION_PT, "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + DBFileName);
            DataBaseOp.SetWaitDialogCaption("Loading Order Details...");
            oleDbDataAdapter.Fill(ds, TableGV_AC_SUBSTATION_PT);
            //oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("SELECT TOP 2 * FROM " + TableLookUp, "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + DBFileName);
            //DataBaseOp.SetWaitDialogCaption("Loading Products...");
            //oleDbDataAdapter.Fill(ds, TableLookUp);
            //ds.Tables.AddRange();
            InitalGridControlByMdb(vGridDdtialStationPT, ds, TableGV_AC_SUBSTATION_PT);
            vGridDdtialStationPT.DataSource = ds.Tables[TableGV_AC_SUBSTATION_PT];
            vGridDdtialStationPT.BestFit();
        }

        private void textBus_EditValueChanged(object sender, EventArgs e)
        {
            int mtextBus = BaseFunction.GetCode(textBus.Text);//获取主变台数   
            if (DBFileName != string.Empty)
            {
                //InitMDBData("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + DBFileName);
                string TableGV_STATION_BUSBAR = "[GV_STATION_BUSBAR]";
                DataSet ds = new DataSet();
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("SELECT TOP " + mtextBus.ToString() + " * FROM " + TableGV_STATION_BUSBAR, "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + DBFileName);
                DataBaseOp.SetWaitDialogCaption("Loading Order Details...");
                oleDbDataAdapter.Fill(ds, TableGV_STATION_BUSBAR);
                InitalGridControlByMdb(vGridControlStationBus, ds, TableGV_STATION_BUSBAR);
                vGridControlStationBus.DataSource = ds.Tables[TableGV_STATION_BUSBAR];
                vGridControlStationBus.BestFit();
            }

        }

        private void textPcr_EditValueChanged(object sender, EventArgs e)
        {
            int mtextPcr = BaseFunction.GetCode(textPcr.Text);//获取主变台数   
            if (DBFileName != string.Empty)
            {
                //InitMDBData("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + DBFileName);
                string TableGV_STATION_PCR = "[GV_STATION_PCR]";
                DataSet ds = new DataSet();
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("SELECT TOP " + mtextPcr.ToString() + " * FROM " + TableGV_STATION_PCR, "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + DBFileName);
                DataBaseOp.SetWaitDialogCaption("Loading Order Details...");
                oleDbDataAdapter.Fill(ds, TableGV_STATION_PCR);
                InitalGridControlByMdb(vGridControlStationPcr, ds, TableGV_STATION_PCR);
                vGridControlStationPcr.DataSource = ds.Tables[TableGV_STATION_PCR];
                vGridControlStationPcr.BestFit();
            }
        }

        private void GENERATORSETEdit_EditValueChanged(object sender, EventArgs e)
        {
            int mGENERATORSETEdit = BaseFunction.GetCode(GENERATORSETEdit.Text);//获取主变台数   
            if (DBFileName != string.Empty)
            {
                //InitMDBData("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + DBFileName);
                string TableGV_STATION_GENERATORSET = "[GV_STATION_GENERATORSET]";
                DataSet ds = new DataSet();
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("SELECT TOP " + mGENERATORSETEdit.ToString() + " * FROM " + TableGV_STATION_GENERATORSET, "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + DBFileName);
                DataBaseOp.SetWaitDialogCaption("Loading Order Details...");
                oleDbDataAdapter.Fill(ds, TableGV_STATION_GENERATORSET);
                InitalGridControlByMdb(vGridControlStationGENERATORSET, ds, TableGV_STATION_GENERATORSET);
                vGridControlStationGENERATORSET.DataSource = ds.Tables[TableGV_STATION_GENERATORSET];
                vGridControlStationGENERATORSET.BestFit();
            }
        }
    }
}
