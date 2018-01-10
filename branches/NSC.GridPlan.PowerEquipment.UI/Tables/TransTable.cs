using NSC.PMSHandler.DataContractObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSC.GridPlan.PowerEquipment.UI.Tables
{
    public class TransTable
    {
        /// <summary>
        /// 获取字段名
        /// </summary>
        /// <param name="m_SubType"></param>
        /// <returns></returns>
        public static Dictionary<string, string> GetFieldName(string m_SubType)
        {
            Dictionary<string, string> FieldName = new Dictionary<string, string>();
           
            if (m_SubType.Contains("交流"))
            {
                FieldName.Add("基本信息", "主变号,绕组数,变压器型号,主变容量(MWA),主抽头及调压范围,抽头位置,短路阻抗,短路损耗,空载损耗(kW),空载电流百分值,中性点接地电抗,负载率(%)");
                FieldName.Add("其他信息", "调压方式,连接方式,冷却方式,绝缘材料,制造厂家,建成日期,分区名,容载率,自耦变压器");
            }
            else
            {
                FieldName.Add("主变信息", "名称,回路号,起点名称,起点类型,终点名称,终点类型,线路类型,电压等级(kV),线路长度（km）");
            }
                    
            return FieldName;
        }
        /// <summary>
        /// 获取字段名
        /// </summary>
        /// <param name="m_SubType"></param>
        /// <returns></returns>
        public static Dictionary<string, string> GetSubFieldName(string m_SubType)
        {
            Dictionary<string, string> FieldName = new Dictionary<string, string>();

            if (m_SubType.Contains("交流"))
            {
                FieldName.Add("基本信息", "主变号,绕组数,变压器型号,主变容量(MWA),主抽头及调压范围,抽头位置,短路阻抗,短路损耗,空载损耗(kW),空载电流百分值,中性点接地电抗,负载率(%)");
                FieldName.Add("其他信息", "调压方式,连接方式,冷却方式,绝缘材料,制造厂家,建成日期,分区名,容载率,自耦变压器");
            }
            else
            {
                FieldName.Add("主变信息", "名称,回路号,起点名称,起点类型,终点名称,终点类型,线路类型,电压等级(kV),线路长度（km）");
            }


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
            FieldValue.Add("名称", "");
            FieldValue.Add("变电站类型", "");
            FieldValue.Add("分区名", "");
            FieldValue.Add("电压等级(kV)", "");
            FieldValue.Add("供电公司", "");
            FieldValue.Add("所属区域", "");
            FieldValue.Add("调度关系", "");
            FieldValue.Add("运维单位", "");
            FieldValue.Add("建设进度", "");
            FieldValue.Add("核准进度", "");
            FieldValue.Add("投产年", "");
            FieldValue.Add("简称", "");
            FieldValue.Add("供电区域", "");
            FieldValue.Add("行政区域", "");
            //交流变电站表
            FieldValue.Add("主变组数(终期)", "");
            FieldValue.Add("主变组数(已建)", "");
            FieldValue.Add("出线(已建)", "");
            FieldValue.Add("出线(规划)", "");
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
        public static Dictionary<string, bool> GetFieldLink()
        {
            Dictionary<string, bool> FieldLink = new Dictionary<string, bool>();
            //基本信息表
            FieldLink.Add("名称", false);
            FieldLink.Add("变电站类型", true);
            FieldLink.Add("分区名", true);
            FieldLink.Add("电压等级(kV)", true);
            FieldLink.Add("供电公司", true);
            FieldLink.Add("所属区域", true);
            FieldLink.Add("调度关系", false);
            FieldLink.Add("运维单位", true);
            FieldLink.Add("建设进度", true);
            FieldLink.Add("核准进度", true);
            FieldLink.Add("投产年", true);
            FieldLink.Add("简称", false);
            FieldLink.Add("供电区域", true);
            FieldLink.Add("行政区域", true);
            //交流变电站表
            FieldLink.Add("主变组数(终期)", false);
            FieldLink.Add("主变组数(已建)", false);
            FieldLink.Add("出线(已建)", false);
            FieldLink.Add("出线(规划)", false);
            FieldLink.Add("出线方向", false);
            FieldLink.Add("开关(遮断能力)", false);
            //交流变电站主变表
            FieldLink.Add("主变信息", false);
            //变电站母线表、变电站母线负荷信息表、变电站电容电抗器表
            FieldLink.Add("母线信息", false);
            //串补表
            FieldLink.Add("串补站", false);
            FieldLink.Add("安装线路", false);
            FieldLink.Add("安装地点", true);
            FieldLink.Add("串补性质", false);
            FieldLink.Add("串补度(固定)", false);
            FieldLink.Add("串补度(可控)", false);
            FieldLink.Add("串补容量(固定)", false);
            FieldLink.Add("串补容量(可控)", false);
            FieldLink.Add("额定电流", false);
            FieldLink.Add("线路潮流PMax", false);
            FieldLink.Add("线路潮流PMin", false);
            FieldLink.Add("线路电抗Min", false);
            FieldLink.Add("线路电抗Max", false);

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
    }
}
