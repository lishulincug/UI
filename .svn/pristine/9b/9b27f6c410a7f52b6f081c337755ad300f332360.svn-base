using DevExpress.XtraVerticalGrid.Rows;
using NSC.GridPlan.PowerEquipment.UI.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace NSC.GridPlan.PowerEquipment.UI.Class
{
    public class AnalysisDataStruct
    {
        /// <summary>
        /// 数据结构解析
        /// </summary>
        /// <param name="dataPath"></param>
        /// <returns></returns>
        public static List<StructTable> AnalysisData(string dataPath,string type)
        {
            List<StructTable> mStructTableCollect = new List<StructTable>();           
            XmlDocument xml = new XmlDocument();
            xml.Load(dataPath);
            //根据解析数据类型获取子节点，
            XmlNodeList root = xml.SelectSingleNode("module").SelectNodes(type);
            //类型节点下只存在一个子节点（变电站或线路或电源）
            XmlElement rootChild = (XmlElement)root[0];
            if (! rootChild.IsEmpty)
            {
                foreach (XmlElement group in rootChild)
                {
                    //单个组
                    StructTable mStructTable = new StructTable();
                    mStructTable.Group = group.GetAttribute("caption");
                    //遍历行
                    if (rootChild.ChildNodes.Count >= 1)
                    {
                        foreach (XmlElement rowCollection in group.ChildNodes)
                        {
                            //实例化，赋值
                            RowTable mRowTable = new RowTable();
                            mRowTable.RowName = rowCollection.GetAttribute("caption");
                            mRowTable.RowValue = rowCollection.InnerText;
                            mRowTable.IsHasChild = rowCollection.GetAttribute("isHasChild").Equals("false") ? false : true;
                            mRowTable.RowType = GetType(rowCollection.GetAttribute("Type"));
                            if (mRowTable.IsHasChild)
                            {
                                foreach (XmlElement childCollection in rowCollection.ChildNodes)
                                {
                                    //赋值
                                    RowChildTable mRowChildTable = new RowChildTable();
                                    mRowChildTable.RowChildName = childCollection.GetAttribute("caption");
                                    mRowChildTable.RowChildValue = childCollection.InnerText;
                                    mRowChildTable.RowChildType = GetType(childCollection.GetAttribute("Type"));
                                    mRowTable.RowChild.Add(mRowChildTable);
                                }
                            }
                            mStructTable.Row.Add(mRowTable);
                        }
                    }
                    mStructTableCollect.Add(mStructTable);
                }
            }
            
            return mStructTableCollect;
        }
        /// <summary>
        /// 获取类型
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static ComEditType GetType(string value)
        {
            ComEditType type=new ComEditType();
            if (value.Equals("0"))
                type= ComEditType.下拉选择;
            else if (value.Equals("1"))
                type = ComEditType.数据集合;
            else if (value.Equals("2"))
                type = ComEditType.无;
            return type;
        }

    }
}
