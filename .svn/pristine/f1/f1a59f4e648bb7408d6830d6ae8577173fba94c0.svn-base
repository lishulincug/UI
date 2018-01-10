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
using DevExpress.XtraTreeList.Nodes;

namespace NSC.GridPlan.PowerEquipment.UI
{
    public partial class InfoShow : Form
    {
        public static InfoShow theSingleton = null;
        private string infoName = null;//当前集合名称
        private object infoValue = null;//当前集合值
        string path = Application.StartupPath + @"\DataStructModel.xml";//模型路径
        string SubPath = Application.StartupPath + @"\DataSubStructModel.xml";//子模型路径
        Dictionary<string, string> KeyWord = new Dictionary<string, string>();
        DataTable dtGrid = null;
        /// <summary>
        /// 单例
        /// </summary>
        /// <returns></returns>
        public static InfoShow Instance(string name, object value)
        {
            if (theSingleton == null || theSingleton.IsDisposed)
            {
                theSingleton = new InfoShow(name, value);
                theSingleton.Show();
            }
            return theSingleton;
        }
        public InfoShow(string name, object value)
        {
            InitializeComponent();
            infoName = name;
            infoValue = value;
            //窗体名称
            this.Text = infoName;
            this.DetialAtrribute.Text = infoName;
        }

        private void InfoShow_Load(object sender, EventArgs e)
        {
            dtGrid = new DataTable();
            SetNavigate(dtGrid);
            switch (infoName)
            {
                case "主变信息":
                    InitGSUControl();
                    break;
                case "母线信息":
                    InitSubControl();
                    break;
                case "升压变信息":
                    InitSBGSUControl();
                    break;
            }
        }
        /// <summary>
        /// 初始化主变属性字段
        /// </summary>
        private void InitGSUControl()
        {
            List<SubGSUObjects> mSubGUS = infoValue as List<SubGSUObjects>;
            if (mSubGUS != null || mSubGUS.Count != 0)
            {
                dtGrid.Rows.Add("", "主变列表");
                //填充数量列表
                for (int i = 0; i < mSubGUS.Count; i++)
                {
                    DataRow drGrid = dtGrid.NewRow();
                    drGrid[0] = i;
                    drGrid[1] = "主变" + mSubGUS[i].GSU.GSUCode;
                    dtGrid.Rows.Add(drGrid);
                }
                listNavigate.DataSource = dtGrid;
                List<StructTable> mStructTableCollect = AnalysisDataStruct.AnalysisData(path, "SubStationTrans");
                FillVGrid vGrid = new FillVGrid();
                vGrid.InitalGridData(mStructTableCollect, vGridDdtial);
            }
        }
        private void InitSBGSUControl()
        {
            List<SubGSUObjects> mSubGUS = infoValue as List<SubGSUObjects>;
            if (mSubGUS != null || mSubGUS.Count != 0)
            {
                dtGrid.Rows.Add("", "升压变列表");
                //填充数量列表
                for (int i = 0; i < mSubGUS.Count; i++)
                {
                    DataRow drGrid = dtGrid.NewRow();
                    drGrid[0] = i;
                    drGrid[1] = "升压变" + mSubGUS[i].GSU.GSUCode;
                    dtGrid.Rows.Add(drGrid);
                }
                listNavigate.DataSource = dtGrid;
                List<StructTable> mStructTableCollect = AnalysisDataStruct.AnalysisData(path, "SubStationTrans");
                FillVGrid vGrid = new FillVGrid();
                vGrid.InitalGridData(mStructTableCollect, vGridDdtial);
            }
        }
        private void InitSubControl()
        {
            List<SubBusObjects> mSubBus = infoValue as List<SubBusObjects>;
            //SubBusObjects mSubBus = new SubBusObjects();
            if (mSubBus != null || mSubBus.Count != 0)
            {
                dtGrid.Rows.Add("", "母线列表");
                //填充数量列表
                for (int i = 0; i < mSubBus.Count; i++)
                {
                    DataRow drGrid = dtGrid.NewRow();
                    drGrid[0] = i;
                    drGrid[1] = "母线" + mSubBus[i].SubBus.BusCode;// GSU.GSUCode;
                    dtGrid.Rows.Add(drGrid);
                }
                listNavigate.DataSource = dtGrid;
                List<StructTable> mStructTableCollect = AnalysisDataStruct.AnalysisData(path, "SubStationBus");
                FillVGrid vGrid = new FillVGrid();
                vGrid.InitalGridData(mStructTableCollect, vGridDdtial);
            }
        }
        private void SetNavigate(DataTable dtGrid)
        {
            dtGrid.Columns.AddRange(new DataColumn[]
                {
                    new DataColumn(" "),
                    new DataColumn("成员列表",typeof(string)),
                });

        }
        /// <summary>
        /// 获取节点名称
        /// </summary>
        /// <param name="node"></param>
        /// <param name="columnId"></param>
        /// <returns></returns>
        //private string fullnamebynode(treelistnode node, int columnid)
        //{
        //    string ret = node.getvalue(columnid).tostring();
        //    while (node.parentnode != null)
        //    {
        //        node = node.parentnode;
        //        ret = node.getvalue(columnid).tostring() + "\\" + ret;
        //    }
        //    return ret;
        //}
        private void listNavigate_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            //dtGrid = new DataTable();
            //SetNavigate(dtGrid);
            //listNavigate.DataSource = dtGrid;
            //string NodeName = this.listNavigate.FocusedNode.GetDisplayText("NAME");
            //FullNameByNode(listNavigate.FocusedNode, e.Node.Id);
            //string NodeName = listNavigate.FocusedNode.GetDisplayText(0).ToString;
            //KeyWord.Add("SubSubStationBus",1);
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

        private void vGridDdtial_Click(object sender, EventArgs e)
        {

        }
    }
}
