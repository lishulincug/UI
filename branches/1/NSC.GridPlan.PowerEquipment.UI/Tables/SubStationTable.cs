using NSC.PMSHandler.DataContractObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace NSC.GridPlan.PowerEquipment.UI.Tables
{
    /// <summary>
    /// 构建变电站属性信息结构
    /// </summary>
    public class SubStationTable
    {
        #region 属性表构建
        public static Dictionary<string, string> GetFieldName(string m_SubType)
        {
            Dictionary<string, string> FieldName = new Dictionary<string, string>();
            FieldName.Add("基本信息", "名称,简称,变电站类型,,电压等级(kV),分区名供电公司,所属区域,调度关系,运维单位,建设进度,核准进度,投产年,供电区域,行政区域");
            if (m_SubType.Contains("交流"))
            {
                FieldName.Add("主变信息", "主变组数(终期),主变组数(已建),出线(已建),出线(规划),出线方向,开关(遮断能力),主变信息");
            }
            else
            {
                FieldName.Add("主变信息", "名称,回路号,起点名称,起点类型,终点名称,终点类型,线路类型,电压等级(kV),线路长度（km）");
            }
            FieldName.Add("母线信息", "母线信息");
            FieldName.Add("电容电抗", "线路长度(km),导线型号,导线截面");
            FieldName.Add("串补信息", "串补站,安装线路,安装地点,串补性质,串补度(固定),串补度(可控),串补容量(固定),额定电流,线路潮流PMax,线路潮流PMin,线路电抗Min,线路电抗Max");
            FieldName.Add("机组信息", "机组信息集合");
            return FieldName;
        }
        /// <summary>
        /// 变电站信息填充
        /// </summary>
        /// <param name="m_SubType">变电站信息结合</param>
        /// <returns></returns>
        public static Dictionary<string, object> GetValueInfo(SubStaObjects mSubSta)
        {
            Dictionary<string, object> FieldValue = new Dictionary<string, object>();
            //基本信息表
            FieldValue.Add("名称", mSubSta.BaseSub.SubName);
            FieldValue.Add("变电站类型", mSubSta.BaseSub.SubType);
            FieldValue.Add("分区名", mSubSta.BaseSub.Partition);
            FieldValue.Add("电压等级(kV)", mSubSta.BaseSub.SubVol);
            FieldValue.Add("供电公司", "");
            FieldValue.Add("所属区域", mSubSta.BaseSub.PartitionEx);
            FieldValue.Add("调度关系", "");
            FieldValue.Add("运维单位", "");
            FieldValue.Add("建设进度", "");
            FieldValue.Add("核准进度", "");
            FieldValue.Add("投产年", "");
            FieldValue.Add("简称", mSubSta.BaseSub.SimName);
            FieldValue.Add("供电区域", "");
            FieldValue.Add("行政区域", "");
            //交流变电站表
            FieldValue.Add("主变组数(终期)",mSubSta.ACSub.GSUPlanCount);
            FieldValue.Add("主变组数(已建)", mSubSta.ACSub.GSUNowCount);
            FieldValue.Add("出线(已建)", mSubSta.ACSub.HighOutLineNow);
            FieldValue.Add("出线(规划)", mSubSta.ACSub.HighOutLinePlan);
            FieldValue.Add("出线方向", "");
            FieldValue.Add("开关(遮断能力)", "");
            //交流变电站主变表
            FieldValue.Add("主变信息", mSubSta.SubGUSCollection);
            //变电站母线表、变电站母线负荷信息表、变电站电容电抗器表
            FieldValue.Add("母线信息", mSubSta.SubBusCollection);           
            //串补表
            FieldValue.Add("串补站", "");
            FieldValue.Add("安装线路", "");
            FieldValue.Add("安装地点", "");
            FieldValue.Add("串补性质", "");
            FieldValue.Add("串补度(固定)", "");
            FieldValue.Add("串补度(可控)", "");
            FieldValue.Add("串补容量(固定)", "");
            FieldValue.Add("串补容量(可控)", "");
            FieldValue.Add("额定电流", "");
            FieldValue.Add("线路潮流PMax", "");
            FieldValue.Add("线路潮流PMin", "");
            FieldValue.Add("线路电抗Min", "");
            FieldValue.Add("线路电抗Max", "");
            return FieldValue;
        }
        /// <summary>
        /// 构建是否添加ComEdit
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, ComEditType> GetFieldCom()
        {
            Dictionary<string, ComEditType> FieldLink = new Dictionary<string, ComEditType>();
            //基本信息表
            FieldLink.Add("名称", ComEditType.无);
            FieldLink.Add("变电站类型", ComEditType.下拉选择);
            FieldLink.Add("分区名", ComEditType.下拉选择);
            FieldLink.Add("电压等级(kV)", ComEditType.下拉选择);
            FieldLink.Add("供电公司", ComEditType.下拉选择);
            FieldLink.Add("所属区域", ComEditType.无);
            FieldLink.Add("调度关系", ComEditType.无);
            FieldLink.Add("运维单位", ComEditType.下拉选择);
            FieldLink.Add("建设进度", ComEditType.下拉选择);
            FieldLink.Add("核准进度", ComEditType.下拉选择);
            FieldLink.Add("投产年", ComEditType.下拉选择);
            FieldLink.Add("简称", ComEditType.无);
            FieldLink.Add("供电区域", ComEditType.下拉选择);
            FieldLink.Add("行政区域", ComEditType.下拉选择);
            //交流变电站表
            FieldLink.Add("主变组数(终期)", ComEditType.无);
            FieldLink.Add("主变组数(已建)", ComEditType.无);
            FieldLink.Add("出线(已建)", ComEditType.数据集合);
            FieldLink.Add("出线(规划)", ComEditType.数据集合);
            FieldLink.Add("出线方向", ComEditType.数据集合);
            FieldLink.Add("开关(遮断能力)", ComEditType.数据集合);
            //交流变电站主变表
            FieldLink.Add("主变信息", ComEditType.数据集合);
            //变电站母线表、变电站母线负荷信息表、变电站电容电抗器表
            FieldLink.Add("母线信息", ComEditType.数据集合);
            //串补表
            FieldLink.Add("串补站", ComEditType.无);
            FieldLink.Add("安装线路", ComEditType.无);
            FieldLink.Add("安装地点", ComEditType.无);
            FieldLink.Add("串补性质", ComEditType.无);
            FieldLink.Add("串补度(固定)", ComEditType.无);
            FieldLink.Add("串补度(可控)", ComEditType.无);
            FieldLink.Add("串补容量(固定)", ComEditType.无);
            FieldLink.Add("串补容量(可控)", ComEditType.无);
            FieldLink.Add("额定电流", ComEditType.无);
            FieldLink.Add("线路潮流PMax", ComEditType.无);
            FieldLink.Add("线路潮流PMin", ComEditType.无);
            FieldLink.Add("线路电抗Min", ComEditType.无);
            FieldLink.Add("线路电抗Max", ComEditType.无);

            return FieldLink;
        }
        /// <summary>
        /// 是否构建字段集合
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, bool> GetFieldItem()
        {
            Dictionary<string, bool> FieldItem = new Dictionary<string, bool>();
            //基本信息表
            FieldItem.Add("名称", false);
            FieldItem.Add("变电站类型", false);
            FieldItem.Add("分区名", false);
            FieldItem.Add("电压等级(kV)", false);
            FieldItem.Add("供电公司", false);
            FieldItem.Add("所属区域", false);
            FieldItem.Add("调度关系", false);
            FieldItem.Add("运维单位", false);
            FieldItem.Add("建设进度", false);
            FieldItem.Add("核准进度", false);
            FieldItem.Add("投产年", false);
            FieldItem.Add("简称", false);
            FieldItem.Add("供电区域", false);
            FieldItem.Add("行政区域", false);
            //交流变电站表
            FieldItem.Add("主变组数(终期)", false);
            FieldItem.Add("主变组数(已建)", false);
            FieldItem.Add("出线(已建)", true);
            FieldItem.Add("出线(规划)", true);
            FieldItem.Add("出线方向", true);
            FieldItem.Add("开关(遮断能力)", true);
            //交流变电站主变表
            FieldItem.Add("主变信息", true);
            //变电站母线表、变电站母线负荷信息表、变电站电容电抗器表
            FieldItem.Add("母线信息", true);
            //串补表
            FieldItem.Add("串补站", false);
            FieldItem.Add("安装线路", false);
            FieldItem.Add("安装地点", false);
            FieldItem.Add("串补性质", false);
            FieldItem.Add("串补度(固定)", false);
            FieldItem.Add("串补度(可控)", false);
            FieldItem.Add("串补容量(固定)", false);
            FieldItem.Add("串补容量(可控)", false);
            FieldItem.Add("额定电流", false);
            FieldItem.Add("线路潮流PMax", false);
            FieldItem.Add("线路潮流PMin", false);
            FieldItem.Add("线路电抗Min", false);
            FieldItem.Add("线路电抗Max", false);

            return FieldItem;
        }
        #endregion

        #region 变电站必填信息构建
        public static DataTable GetSubStaTable(string mTableName)
        {
            DataTable dtTable = new DataTable();
            switch (mTableName)
            {
                case "主变":
                    //dtTable.Rows.Add(new DataRow[] 
                    //    {
                    //    new DataRow( "date1", 10);
                    //    new datarow(new object[] { "date1", 10, 1 });
                    //    new datacolumn("主变容量(mwa)",typeof(double))
                    //    });
                    dtTable.Columns.AddRange(new DataColumn[]
                        {
                            new DataColumn("*主变号",typeof(int)),
                            new DataColumn("*主变容量(MWA)",typeof(double)),
                            new DataColumn("*额定电压(kV)",typeof(double)),
                            new DataColumn("*短路阻抗(%)",typeof(double)) ,
                             new DataColumn("主变数组(终期)",typeof(int)),
                            new DataColumn("主变数组(已建)",typeof(double)),
                            new DataColumn("出线(已建)",typeof(double)),
                            new DataColumn("出线(规划)",typeof(double)),
                            new DataColumn("出线(方向)",typeof(double)),
                            new DataColumn("开关(遮蔽能力)",typeof(double))    
                        });

                    break;
                case "母线":
                    dtTable.Columns.AddRange(new DataColumn[]
                        {
                            new DataColumn("*编号",typeof(string)),
                            new DataColumn("*变电站代码",typeof(string)),
                            new DataColumn("*关联主变号",typeof(string)),
                            new DataColumn("*母线名称",typeof(string)),
                            new DataColumn("*基准电压(kV)",typeof(double)),
                            new DataColumn("短路容量(MWA)",typeof(string)),
                            new DataColumn("电压上限",typeof(double)),
                            new DataColumn("电压下限",typeof(string))
                        });
                    break;
                case "电容电抗":
                    dtTable.Columns.AddRange(new DataColumn[]
                        {                            
                            new DataColumn("母线代码",typeof(string)),                         
                            new DataColumn("电容电抗器名称",typeof(string)),
                            new DataColumn("投入容量",typeof(string)),                         
                            new DataColumn("额定电压",typeof(string)),
                            new DataColumn("出力方式",typeof(string)),                         
                            new DataColumn("设备类型",typeof(string)),
                            new DataColumn("单组容量",typeof(string)),                         
                            new DataColumn("己建组数",typeof(string)),
                            new DataColumn("总容量",typeof(string)),
                            new DataColumn("型号",typeof(string)),                         
                            new DataColumn("备注",typeof(string))
                        });
                    break;
            }
            return dtTable;
        }
        #endregion
    }
}
