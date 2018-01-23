using DevExpress.XtraEditors.Controls;
using DevExpress.XtraVerticalGrid;
using DevExpress.XtraVerticalGrid.Rows;
using NSC.GridPlan.PowerEquipment.UI.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NSC.GridPlan.PowerEquipment.UI.Class
{
    public class FillVGrid
    {
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
        /// <summary>
        /// 填充属性表
        /// </summary>
        /// <param name="mStructTable">数据填充结构</param>
        /// <param name="mTitle">数据对象名</param>
        /// <param name="strFormName">窗体名称</param>
        public  void InitalGridData(List<StructTable> mStructTable,VGridControl vGridAttribute)
        {
            vGridAttribute.Rows.Clear();
            if (mStructTable == null || mStructTable.Count == 0)
                return;
            ////填充单个电力设备名称
            //this.toolStripTextBox1.Text = mTitle;
            ////修改窗体名称
            //this.Text = strFormName;
            //循环填充组
            for (int i = 0; i < mStructTable.Count; i++)
            {
                InitalRow(mStructTable[i], i, vGridAttribute);
            }
        }
        /// <summary>
        /// 填充每个组
        /// </summary>
        /// <param name="mStructTable"></param>
        /// <param name="iCount">当前组数</param>
        private void InitalRow(StructTable mStructTable, int iCount, VGridControl vGridAttribute)
        {
            mCategoryRow = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
            mCategoryRow.Properties.Caption = mStructTable.Group;
            vGridAttribute.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.mCategoryRow});
            mCategoryRow.Grid.Dock = DockStyle.Fill;
            if (mStructTable.Row == null || mStructTable.Row.Count == 0)
                return;
            //循环填充表格
            for (int i = 0; i < mStructTable.Row.Count; i++)
            {
                //添加行
                EditorRow row = FillRowData(mStructTable.Row[i]);
                this.mCategoryRow.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
                row});
            }
            mCategoryRow.Properties.ReadOnly = true;
            //设置是否展开控件
            mCategoryRow.Expanded = iCount == 0 ? true : false;
        }
        /// <summary>
        /// 填充行
        /// </summary>
        /// <param name="mRowTable"></param>
        private EditorRow FillRowData(RowTable mRowTable)
        {
            EditorRow row = new EditorRow();
            row.Name = mRowTable.RowName;
            row.Properties.Caption = mRowTable.RowName;
            row.Height = 20;
            row.Appearance.Options.UseForeColor = true;
            row.Properties.Value = mRowTable.RowValue;
            //判断是否添加特殊控件
            CheckUseComEdit(mRowTable.RowType, row);
            //判断，存在子行，循环添加
            if (mRowTable.IsHasChild)
            {
                for (int i = 0; i < mRowTable.RowChild.Count; i++)
                {
                    //添加子行
                    EditorRow childRow = FillRowChildData(mRowTable.RowChild[i]);
                    row.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
                childRow});

                }
                //存在子行，则只读
                row.Properties.ReadOnly = true;
            }
            return row;
        }
        /// <summary>
        /// 填充子行
        /// </summary>
        /// <param name="mRowChildTable"></param>
        /// <returns></returns>
        private EditorRow FillRowChildData(RowChildTable mRowChildTable)
        {
            EditorRow row = new EditorRow();
            row.Name = mRowChildTable.RowChildName;
            row.Properties.Caption = mRowChildTable.RowChildName;
            row.Height = 20;
            row.Appearance.Options.UseForeColor = true;
            row.Properties.Value = mRowChildTable.RowChildValue;
            //判断是否添加特殊控件
            CheckUseComEdit(mRowChildTable.RowChildType, row);
            return row;
        }
        /// <summary>
        /// 判断是否添加特殊控件
        /// </summary>
        /// <param name="type"></param>
        /// <param name="row"></param>
        private void CheckUseComEdit(ComEditType type, EditorRow row)
        {
            if (type == ComEditType.下拉选择)
            {
                mRepositoryItemComboBox = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
                mRepositoryItemComboBox.Name = row.Name;
                //初始化控件
                FillAttributeComBox.FillComBox(mRepositoryItemComboBox);
                mRepositoryItemComboBox.Click += new EventHandler(mRepositoryItemComboBox_Click);
                row.Properties.RowEdit = mRepositoryItemComboBox;
            }
            else if (type == ComEditType.数据集合)
            {
                mRepositoryItemButtonEdit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
                mRepositoryItemButtonEdit.Name = row.Name;
                mRepositoryItemButtonEdit.ButtonClick += new ButtonPressedEventHandler(mRepositoryItemButtonEdit_ButtonClick);
                row.Properties.RowEdit = mRepositoryItemButtonEdit;
            }
        }
        /// <summary>
        /// 下拉选择事件响应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mRepositoryItemComboBox_Click(object sender, EventArgs e)
        {
        }
        /// <summary>
        /// item集合事件响应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mRepositoryItemButtonEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
         
        }
    }
}
