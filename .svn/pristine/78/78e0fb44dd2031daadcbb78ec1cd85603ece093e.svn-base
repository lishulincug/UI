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
    public partial class FieldsManagement : Form
    {
        DataTable dtFields =null ;//全局变量
        bool isEdit = false;//标识是否保存

        public static FieldsManagement theSingleton = null;
        /// <summary>
        /// 单例
        /// </summary>
        /// <returns></returns>
        public static FieldsManagement Instance()
        {
            if (theSingleton == null || theSingleton.IsDisposed)
            {
                theSingleton = new FieldsManagement();
                theSingleton.Show();
            }
            return theSingleton;
        }
        public FieldsManagement()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 添加字段
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolAdd_Click(object sender, EventArgs e)
        {
            gvFields.AddNewRow();
        }
        /// <summary>
        /// 删除字段
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolDelete_Click(object sender, EventArgs e)
        {
            if (gvFields.GetSelectedRows().Length == 0)
                MessageBox.Show("请选择删除字段");
            else
            {
                for(int i=0;i<gvFields.GetSelectedRows().Length;i++)
                {
                    gvFields.DeleteRow(gvFields.GetSelectedRows()[i]);
                }
            }
        }
        /// <summary>
        /// 编辑字段
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolEdit_Click(object sender, EventArgs e)
        {
            if (!isEdit)
            {
                gvFields.OptionsBehavior.Editable = true;
                isEdit = true;
            }
            else
            {
                gvFields.OptionsBehavior.Editable = false;
                isEdit = false;
            }           
        }
        /// <summary>
        /// 保存字段
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolSave_Click(object sender, EventArgs e)
        {
            //保存到配置文件
        }

        private void FieldsManagement_Load(object sender, EventArgs e)
        {
            dtFields = new DataTable();
            FieldsTable.GetFieldsTable(dtFields);
            //从配置文件中读取字段对应关系

            //end
            gcFields.DataSource = dtFields;
            gvFields.PopulateColumns();
            gvFields.BestFitColumns();

        }

    }
}
