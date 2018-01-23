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
        string DBFileName = Application.StartupPath + "\\湖北省2012年地理接线图.mdb";
        const string
            NewRow = "New",
            TableGrid = "[GV_LINE]",
            TableLookUp = "GV_STATION_GENERATORSET";
        public LineAttribute()
        {
            InitializeComponent();
            InitNWindData();
        }
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
                    this.mEditorRow.Height = 19;                   
                    this.mEditorRow.Appearance.Options.UseForeColor = true;
                    if (Ds.Tables[tableName].Rows.Count > 0)
                    {
                        if (!(Ds.Tables[tableName].Rows[0][Ds.Tables[tableName].Columns[i].ColumnName] is System.DBNull) & ds.Tables[TableMETADATA_FIELD].Rows[0] != null)
                        {
                            this.mEditorRow.Properties.Caption = ds.Tables[TableMETADATA_FIELD].Rows[0]["ALIAS"].ToString();

                            //this.mEditorRow.Properties.Value = FieldValue.ContainsKey(strName[i]) ? FieldValue[strName[i]] : string.Empty;
                            //判断是否存在下拉选择项、事件注册
                            //if (FieldLink.ContainsKey(strName[i]) && (FieldLink[strName[i]] == ComEditType.下拉选择))
                            //{
                            //    mRepositoryItemComboBox = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
                            //    mRepositoryItemComboBox.Name = strName[i];
                            //初始化控件
                            //    FillAttributeComBox.FillComBox(mRepositoryItemComboBox);
                            //mRepositoryItemComboBox.Click += new EventHandler(mRepositoryItemComboBox_Click);
                            //    this.mEditorRow.Properties.RowEdit = mRepositoryItemComboBox;
                            //}
                            //判断是否存在数据集合项、事件注册
                            //if (FieldLink.ContainsKey(strName[i]) && (FieldLink[strName[i]] == ComEditType.数据集合))
                            //{
                            //    mRepositoryItemButtonEdit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
                            //    mRepositoryItemButtonEdit.Name = strName[i];
                            //mRepositoryItemButtonEdit.ButtonClick += new ButtonPressedEventHandler(mRepositoryItemButtonEdit_ButtonClick);
                            //    this.mEditorRow.Properties.RowEdit = mRepositoryItemButtonEdit;
                            //}
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
            //RecalcWidth(vGridControlx);
            vGridControlx.SaveLayoutToXml(Application.StartupPath + @"\Model\GV_LINE\" + vGridControlx.Tag.ToString() + ".xml");
        }
       
        protected void InitNWindData()
        {
            DataSet ds = new DataSet();
            if (DBFileName != string.Empty)
            {
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("SELECT TOP 1 * FROM " + TableGrid, "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + DBFileName);
                DataBaseOp.SetWaitDialogCaption("Loading Order Details...");
                oleDbDataAdapter.Fill(ds, TableGrid);
                //oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("SELECT * FROM " + TableLookUp, "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + DBFileName);
                //DataBaseOp.SetWaitDialogCaption("Loading Products...");
                //oleDbDataAdapter.Fill(ds, TableLookUp);
                //ds.Tables.AddRange();
                InitalGridControlByMdb(vGridControl2, ds, TableGrid);
                vGridControl2.DataSource = ds.Tables[TableGrid];
                //vGridControl4.Rows.Add
                //repositoryItemLookUpEdit1.DataSource = ds.Tables[TableLookUp];
                vGridControl2.BestFit();
            }
        }
        /// <summary>
        /// 线路信息预览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPreView_Click(object sender, EventArgs e)
        {
            EquipmentInfoShow lineShow = EquipmentInfoShow.Instance();
            //Dictionary<string, string> FieldName = LineTable.GetFieldName(mLine.BaseLine.LineType);
            //Dictionary<string, object> FieldValue = LineTable.SetValueInfo(mLine);
            //Dictionary<string, ComEditType> FieldLink = LineTable.GetFieldCom();         
            //string[] groupName = new string[3];
            //groupName[2] = "基本信息";
            //if (mLine.BaseLine.LineType.Contains("交流"))
            //    groupName[1] = "交流线信息";
            //else
            //    groupName[1] = "直流线信息";
            //groupName[0] = "线路长度信息";
            //lineShow.FillContent(groupName, FieldName, FieldValue, "徐行变");
            //lineShow.InitalGridControl(groupName, FieldName, FieldValue, FieldLink, "徐行变", "线路属性");
            lineShow.megreGridControl(vGridControl2,1);
            lineShow.megreGridControl(vGridDdtial,2);
            lineShow.megreGridControl(vGridControl1,3);
            lineShow.megreGridControl(vGridControl3,3);
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
            int mTransNum = 1;// BaseFunction.GetCode(Trans.Text);//获取主变台数                   
            if (DBFileName != string.Empty)
            {
                string TableGV_LINE_XX = "[GV_LINE_XX]";
                DataSet ds = new DataSet();
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("SELECT TOP " + mTransNum.ToString() + " * FROM " + TableGV_LINE_XX, "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + DBFileName);
                DataBaseOp.SetWaitDialogCaption("Loading Order Details...");
                oleDbDataAdapter.Fill(ds, TableGV_LINE_XX);
                //oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("SELECT TOP 2 * FROM " + TableLookUp, "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + DBFileName);
                //DataBaseOp.SetWaitDialogCaption("Loading Products...");
                //oleDbDataAdapter.Fill(ds, TableLookUp);
                //ds.Tables.AddRange();
                //InitalGridControlByMdb(vGridDdtial, ds, TableGV_LINE_XX);
                vGridDdtial.DataSource = ds.Tables[TableGV_LINE_XX];
                vGridDdtial.BestFit();
            }         
        }

        private void textBus_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void textPcr_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void toolStripTextBoxPT_Click(object sender, EventArgs e)
        {
            int mTransNum = BaseFunction.GetCode(toolStripTextBoxPT.Text);//获取主变台数                   
            if (DBFileName != string.Empty)
            {
                string TableGV_LINE_XX = "[GV_LINE_XX]";
                DataSet ds = new DataSet();
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("SELECT TOP " + mTransNum.ToString() + " * FROM " + TableGV_LINE_XX, "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + DBFileName);
                DataBaseOp.SetWaitDialogCaption("Loading Order Details...");
                oleDbDataAdapter.Fill(ds, TableGV_LINE_XX);
                //oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("SELECT TOP 2 * FROM " + TableLookUp, "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + DBFileName);
                //DataBaseOp.SetWaitDialogCaption("Loading Products...");
                //oleDbDataAdapter.Fill(ds, TableLookUp);
                //ds.Tables.AddRange();
                //InitalGridControlByMdb(vGridDdtial, ds, TableGV_LINE_XX);
                vGridDdtial.DataSource = ds.Tables[TableGV_LINE_XX];
                vGridDdtial.BestFit();
            }
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage5)//进行tabpage位置判断  
            {
                EquipmentInfoShow lineShow = EquipmentInfoShow.Instance();
                lineShow.megreGridControl(vGridControl2, 1);
                lineShow.megreGridControl(vGridDdtial, 2);
            }
        }     
    }
}
