﻿using DevExpress.XtraEditors.Controls;
using NSC.GridPlan.PowerEquipment.UI.Class;
using NSC.GridPlan.PowerEquipment.UI.Tables;
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
    public partial class EquipmentInfoShow : Form
    {
        private DevExpress.XtraVerticalGrid.Rows.BaseRow mBaseRow;
        /// <summary>
        /// 分组控件
        /// </summary>
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
        /// 单例
        /// </summary>
        /// <returns></returns>
        public static EquipmentInfoShow Instance()
        {
            if (theSingleton == null || theSingleton.IsDisposed)
            {
                theSingleton = new EquipmentInfoShow();
                theSingleton.Show();
            }
            return theSingleton;
        }
        public EquipmentInfoShow()
        {
            InitializeComponent();
            // This line of code is generated by Data Source Configuration Wizard
            // Uncomment next line to set the total number of data records stored within your source       
            // This line of code is generated by Data Source Configuration Wizard
            // Fill a ExcelDataSource
            //excelDataSource1.Fill();
        }
       /// <summary>
       /// 内容填充（没有特殊控件）
       /// </summary>
       /// <param name="groupName"></param>
       /// <param name="FieldName"></param>
       /// <param name="FieldValue"></param>
       /// <param name="TypeName"></param>
        public void FillContent(string[] groupName, Dictionary<string, string> FieldName,Dictionary<string, string> FieldValue,string TypeName)
        {
            this.vGridControl1.Rows.Clear();
            if (groupName == null || groupName.Length == 0)
                return;

            this.toolStripTextBox1.Text = TypeName;
            for (int i = groupName.Length - 1; i >= 0; i--)
            {
                InitalGrid(groupName[i], FieldName, FieldValue);
            }
        
        }
        /// <summary>
        /// 普通填充
        /// </summary>
        /// <param name="groupName"></param>
        /// <param name="FieldName"></param>
        /// <param name="FieldValue"></param>
         private void InitalGrid(string groupName, Dictionary<string, string> FieldName, Dictionary<string, string> FieldValue)
         {
             mCategoryRow = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
             mCategoryRow.Properties.Caption = groupName;
             this.vGridControl1.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.mCategoryRow});
             mCategoryRow.Grid.Dock = DockStyle.Fill;
             //判断是否存在重名
             if (!FieldName.ContainsKey(groupName))
                 return;
             string[] strName = FieldName[groupName].Split(',');
             if (strName == null || strName.Length == 0)
                 return;
             //循环填充表格
             for (int i = 0; i < strName.Length; i++)
             {
                 this.mEditorRow = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
                 this.mEditorRow.Name = strName[i];
                 this.mEditorRow.Properties.Caption = strName[i];
                 this.mEditorRow.Height = 20;
                 this.mEditorRow.Appearance.Options.UseForeColor = true;
                 this.mEditorRow.Properties.Value = FieldValue.ContainsKey(strName[i]) ? FieldValue[strName[i]] : string.Empty;
                 this.mCategoryRow.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
                this.mEditorRow});

             }
             this.vGridControl1.BestFit();
         }
        /// <summary>
        /// 填充，有特殊控件（Combox控件）
        /// </summary>
        /// <param name="groupName"></param>
        /// <param name="FieldName"></param>
        /// <param name="FieldValue"></param>
        /// <param name="FieldLink"></param>
        /// <param name="strTitle"></param>
         /// <param name="strFormName"></param>
         public void InitalGridControl(string[] groupName, Dictionary<string, string> FieldName, Dictionary<string, object> FieldValue, Dictionary<string, ComEditType> FieldLink, string strTitle, string strFormName)
         {
             this.vGridControl1.Rows.Clear();
             if (groupName == null || groupName.Length == 0)
                 return;
             //填充单个电力设备名称
             this.toolStripTextBox1.Text = strTitle;
             //修改窗体名称
             this.Text = strFormName;
             //循环填充组
             for (int i = groupName.Length - 1; i >= 0; i--)
             {
                 InitalGridControl(groupName[i], FieldName, FieldValue, FieldLink, i == groupName.Length - 1 ? 0 : 1);
             }
             //自适应
             this.vGridControl1.BestFit();            
         }
        /// <summary>
         /// VGridControl 行宽自动调整
        /// </summary>
         private void RecalcWidth()
         {
             int recordWidth = (vGridControl1.Width - vGridControl1.RowHeaderWidth) / vGridControl1.Rows.Count;
             if (recordWidth > vGridControl1.RecordMinWidth)
             {
                 vGridControl1.RecordWidth = recordWidth;
                 vGridControl1.ScrollVisibility = DevExpress.XtraVerticalGrid.ScrollVisibility.Vertical;
             }
             else
             {
                 vGridControl1.ScrollVisibility = DevExpress.XtraVerticalGrid.ScrollVisibility.Auto;
             }
         }
        /// <summary>
        /// 填充单个组表格
        /// </summary>
        /// <param name="strGroupName"></param>
        /// <param name="FieldName"></param>
        /// <param name="FieldValue"></param>
        /// <param name="FieldLink"></param>
        /// <param name="iCount"></param>
         private void InitalGridControl(string strGroupName, Dictionary<string, string> FieldName, Dictionary<string, object> FieldValue, Dictionary<string, ComEditType> FieldLink, int iCount)
         {
             mCategoryRow = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
             mCategoryRow.Properties.Caption = strGroupName;
             this.vGridControl1.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.mCategoryRow});
             mCategoryRow.Grid.Dock = DockStyle.Fill;
             RecalcWidth();
             //判断是否存在重复组
             if (!FieldName.ContainsKey(strGroupName))
                 return;
             string[] strName = FieldName[strGroupName].Split(',');
             if (strName == null || strName.Length == 0)
                 return;
             //循环填充表格
             for (int i = 0; i < strName.Length; i++)
             {
                 this.mEditorRow = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
                 this.mEditorRow.Name = strName[i];
                 this.mEditorRow.Properties.Caption = strName[i];
                 this.mEditorRow.Height = 20;
                 this.mEditorRow.Appearance.Options.UseForeColor = true;
                 this.mEditorRow.Properties.Value = FieldValue.ContainsKey(strName[i]) ? FieldValue[strName[i]] : string.Empty;
                 //判断是否存在下拉选择项、事件注册
                 if (FieldLink.ContainsKey(strName[i]) && (FieldLink[strName[i]]==ComEditType.下拉选择))
                 {
                     mRepositoryItemComboBox = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
                     mRepositoryItemComboBox.Name = strName[i];
                     //初始化控件
                     FillAttributeComBox.FillComBox(mRepositoryItemComboBox);
                     mRepositoryItemComboBox.Click += new EventHandler(mRepositoryItemComboBox_Click);
                     this.mEditorRow.Properties.RowEdit = mRepositoryItemComboBox;
                 }
                 //判断是否存在数据集合项、事件注册
                 if (FieldLink.ContainsKey(strName[i]) && (FieldLink[strName[i]] == ComEditType.数据集合))
                 {
                     mRepositoryItemButtonEdit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
                     mRepositoryItemButtonEdit.Name = strName[i];
                     mRepositoryItemButtonEdit.ButtonClick += new ButtonPressedEventHandler(mRepositoryItemButtonEdit_ButtonClick);
                     this.mEditorRow.Properties.RowEdit = mRepositoryItemButtonEdit;
                 }
                 this.mCategoryRow.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
                this.mEditorRow});
             }
             mCategoryRow.Expanded = iCount == 0 ? true : false;
         }
         public void megreGridControl(DevExpress.XtraVerticalGrid.VGridControl vGridControlm)
         {
             for (int j = 0; j < vGridControlm.Rows.Count; j++)
             {
                 mCategoryRow = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
                 mCategoryRow.Properties.Caption = vGridControlm.Rows[j].Properties.Caption;
                 this.vGridControl1.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.mCategoryRow});
                 mCategoryRow.Grid.Dock = DockStyle.Fill;
                 RecalcWidth();

                 for (int i = 0; i < vGridControlm.Rows[j].ChildRows.Count; i++)
                {
                 this.mEditorRow = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
                 this.mEditorRow.Name = vGridControlm.Rows[j].ChildRows[i].Name;
                 this.mEditorRow.Properties.Caption = vGridControlm.Rows[j].ChildRows[i].Properties.Caption;
                 //this.mEditorRow.Height = vGridControlm.Rows[j].ChildRows[i].Height;
                 //this.mEditorRow.Appearance.Options.UseForeColor = true;
                 this.mEditorRow.Properties.Value = vGridControlm.Rows[j].ChildRows[i].Properties.Value;//FieldValue.ContainsKey(strName[i]) ? FieldValue[strName[i]] : string.Empty;
                 //判断是否存在下拉选择项、事件注册
                 this.mCategoryRow.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
                this.mEditorRow});
                }
                 //this.vGridControl1.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] { vGridControlm.Rows[j] });
                 //this.mBaseRow = vGridControlm.Rows[j];
                 //this.vGridControl1.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
                //this.mBaseRow});
                 //this.vGridControl1.Rows.Add(vGridControlm.Rows[j]);
             }
             this.vGridControl1.BestFit();
             this.vGridControl1.OptionsView.FixRowHeaderPanelWidth = true;
             this.vGridControl1.OptionsView.AutoScaleBands = true;
             //this.vGridControl1.OptionsBehavior.Editable = false;
         }
        /// <summary>
        /// 下拉选择事件响应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
         private void mRepositoryItemComboBox_Click(object sender, EventArgs e)
         {
             //获取当前下拉选择项名称
             string name = this.vGridControl1.FocusedRow.Name;

         }
         /// <summary>
         /// item集合事件响应
         /// </summary>
         /// <param name="sender"></param>
         /// <param name="e"></param>
         private void mRepositoryItemButtonEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
         {
             //获取当前选中行名称
             string name = this.vGridControl1.FocusedRow.Name;
             //获取值
             object value = this.vGridControl1.GetRowByName(name).Properties.Value;
             //窗体显示
             InfoShow.Instance(name,value);
         }
         /// <summary>
         /// 保存入库
         /// </summary>
         /// <param name="sender"></param>
         /// <param name="e"></param>
         private void toolDB_Click(object sender, EventArgs e)
         {
             DataTable dtData = this.vGridControl1.DataSource as DataTable;
             DataBaseOp.DataOperator(dtData);
         }

         private void EquipmentInfoShow_Load(object sender, EventArgs e)
         {
             
         }

         private void toolStripTextBox1_Click(object sender, EventArgs e)
         {

         }

         // This event is generated by Data Source Configuration Wizard
         //void unboundSource1_ValueNeeded(object sender, DevExpress.Data.UnboundSourceValueNeededEventArgs e)
         //{

             // Handle this event to obtain data from your data source
             // e.Value = something /* TODO: Assign the real data here.*/
         //}

         // This event is generated by Data Source Configuration Wizard
         //void unboundSource1_ValuePushed(object sender, DevExpress.Data.UnboundSourceValuePushedEventArgs e)
         //{

             // Handle this event to save modified data back to your data source
             // something = e.Value; /* TODO: Propagate the value into the storage.*/
         //} 
    }
}
