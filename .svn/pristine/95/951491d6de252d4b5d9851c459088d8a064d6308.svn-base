using NSC.PMSHandler.DataContractObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSC.GridPlan.PowerEquipment.UI.Tables
{
    public class LineTable
    {
        /// <summary>
        /// 获取字段名
        /// </summary>
        /// <param name="m_LineType">线路类型</param>
        /// <returns></returns>
        public static Dictionary<string, string> GetFieldName(string m_LineType)
        {
            Dictionary<string, string> FieldName = new Dictionary<string, string>();
            FieldName.Add("基本信息", "名称,回路号,起点名称,起点类型,终点名称,终点类型,线路类型,电压等级(kV),供电公司,供电区域,行政区域,建设进度,运维单位,排列方式,建成日期,充电功率,所属区域,运行状态");
            if (m_LineType.Contains("交流"))
            {
                FieldName.Add("交流线信息", "起点母线,终点母线,额定电流(A),正序电阻,正序电抗,正序电纳,零序电阻,零序电抗,零序电纳,是否对称,起点正序电导,终点正序电导,起点正序电纳,终点正序电纳,起点高抗,起点高抗值,终点高抗,终点高抗值");                              
            }
            else
            {             
                FieldName.Add("直流线信息", "名称,回路号,起点名称,起点类型,终点名称,终点类型,线路类型,电压等级(kV),线路长度（km）");
            }
            FieldName.Add("线路长度信息", "线路长度(km),导线型号,导线截面");
            return FieldName;
        }

        /// <summary>
        /// 线路信息填充
        /// </summary>
        /// <param name="m_LineType">线路信息结合</param>
        /// <returns></returns>
        public static Dictionary<string, object> SetValueInfo(LineObjects mLine)
        {
            Dictionary<string, object> FieldValue = new Dictionary<string, object>();
            //基本信息表
            FieldValue.Add("名称", mLine.BaseLine.LineName);
            FieldValue.Add("回路号", mLine.BaseLine.LoopID);
            FieldValue.Add("起点名称", mLine.BaseLine.Origin);
            FieldValue.Add("起点类型", mLine.BaseLine.OriginType);
            FieldValue.Add("终点名称", mLine.BaseLine.Destination);
            FieldValue.Add("终点类型", mLine.BaseLine.DestinationType);
            FieldValue.Add("线路类型", mLine.BaseLine.LineType);
            FieldValue.Add("电压等级(kV)", mLine.BaseLine.LineVol);
            FieldValue.Add("供电公司", "");
            FieldValue.Add("供电区域", "");
            FieldValue.Add("行政区域", "");
            FieldValue.Add("建设进度", "");
            FieldValue.Add("运维单位", "");
            FieldValue.Add("排列方式", "");
            FieldValue.Add("建成日期", "");
            FieldValue.Add("充电功率", "");
            FieldValue.Add("所属区域", "");
            FieldValue.Add("运行状态", "");
            //交流线路表
            
            FieldValue.Add("起点母线", mLine.ACLine.StartingBus);
            FieldValue.Add("终点母线", mLine.ACLine.EndingBus);
            FieldValue.Add("额定电流(A)", "");
            FieldValue.Add("正序电阻", "");
            FieldValue.Add("正序电抗", "");
            FieldValue.Add("正序电纳", "");
            FieldValue.Add("零序电阻", "");
            FieldValue.Add("零序电抗", "");
            FieldValue.Add("零序电纳", "");
            FieldValue.Add("是否对称", "");
            FieldValue.Add("起点正序电导", "");
            FieldValue.Add("终点正序电导", "");
            FieldValue.Add("起点正序电纳", "");
            FieldValue.Add("终点正序电纳", "");
            FieldValue.Add("起点高抗", "");
            FieldValue.Add("起点高抗值", "");
            FieldValue.Add("终点高抗", "");
            FieldValue.Add("终点高抗值", "");
            //线路分段长度
            FieldValue.Add("线路长度(km)", mLine.LineLen.LineLength);
            FieldValue.Add("导线型号", mLine.LineLen.LineModel);
            FieldValue.Add("导线截面", "");
            return FieldValue;
        }
        /// <summary>
        /// 设置控件
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, ComEditType> GetFieldCom()
        {
            Dictionary<string, ComEditType> FieldLink = new Dictionary<string, ComEditType>();
            //基本信息表
            FieldLink.Add("名称", ComEditType.无);
            FieldLink.Add("回路号", ComEditType.下拉选择);
            FieldLink.Add("起点名称", ComEditType.无);
            FieldLink.Add("起点类型", ComEditType.下拉选择);
            FieldLink.Add("终点名称", ComEditType.无);
            FieldLink.Add("终点类型", ComEditType.下拉选择);
            FieldLink.Add("线路类型", ComEditType.下拉选择);
            FieldLink.Add("电压等级(kV)", ComEditType.下拉选择);
            FieldLink.Add("供电公司", ComEditType.下拉选择);
            FieldLink.Add("供电区域", ComEditType.下拉选择);
            FieldLink.Add("行政区域", ComEditType.下拉选择);
            FieldLink.Add("建设进度", ComEditType.下拉选择);
            FieldLink.Add("运维单位", ComEditType.无);
            FieldLink.Add("排列方式", ComEditType.下拉选择);
            FieldLink.Add("建成日期", ComEditType.无);
            FieldLink.Add("充电功率", ComEditType.无);
            FieldLink.Add("所属区域", ComEditType.下拉选择);
            FieldLink.Add("运行状态", ComEditType.下拉选择);
            //交流线路表

            FieldLink.Add("起点母线", ComEditType.下拉选择);
            FieldLink.Add("终点母线", ComEditType.下拉选择);
            FieldLink.Add("额定电流(A)", ComEditType.无);
            FieldLink.Add("正序电阻", ComEditType.无);
            FieldLink.Add("正序电抗", ComEditType.无);
            FieldLink.Add("正序电纳", ComEditType.无);
            FieldLink.Add("零序电阻", ComEditType.无);
            FieldLink.Add("零序电抗", ComEditType.无);
            FieldLink.Add("零序电纳", ComEditType.无);
            FieldLink.Add("是否对称", ComEditType.下拉选择);
            FieldLink.Add("起点正序电导", ComEditType.无);
            FieldLink.Add("终点正序电导", ComEditType.无);
            FieldLink.Add("起点正序电纳", ComEditType.无);
            FieldLink.Add("终点正序电纳", ComEditType.无);
            FieldLink.Add("起点高抗", ComEditType.无);
            FieldLink.Add("起点高抗值", ComEditType.无);
            FieldLink.Add("终点高抗", ComEditType.无);
            FieldLink.Add("终点高抗值", ComEditType.无);
            //线路分段长度
            FieldLink.Add("线路长度(km)", ComEditType.无);
            FieldLink.Add("导线型号", ComEditType.下拉选择);
            FieldLink.Add("导线截面", ComEditType.无);

            return FieldLink;
        }
        /// <summary>
        /// 构建下拉选择项
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, bool> GetFieldLink()
        {
            Dictionary<string, bool> FieldLink = new Dictionary<string, bool>();
            //基本信息表
            FieldLink.Add("名称", false);
            FieldLink.Add("回路号", true);
            FieldLink.Add("起点名称", false);
            FieldLink.Add("起点类型", true);
            FieldLink.Add("终点名称", false);
            FieldLink.Add("终点类型", true);
            FieldLink.Add("线路类型", true);
            FieldLink.Add("电压等级(kV)", true);
            FieldLink.Add("供电公司", true);
            FieldLink.Add("供电区域", true);
            FieldLink.Add("行政区域", true);
            FieldLink.Add("建设进度", true);
            FieldLink.Add("运维单位", false);
            FieldLink.Add("排列方式", true);
            FieldLink.Add("建成日期", false);
            FieldLink.Add("充电功率", false);
            FieldLink.Add("所属区域", true);
            FieldLink.Add("运行状态", true);
            //交流线路表

            FieldLink.Add("起点母线", true);
            FieldLink.Add("终点母线", true);
            FieldLink.Add("额定电流(A)", false);
            FieldLink.Add("正序电阻", false);
            FieldLink.Add("正序电抗", false);
            FieldLink.Add("正序电纳", false);
            FieldLink.Add("零序电阻", false);
            FieldLink.Add("零序电抗", false);
            FieldLink.Add("零序电纳", false);
            FieldLink.Add("是否对称", true);
            FieldLink.Add("起点正序电导", false);
            FieldLink.Add("终点正序电导", false);
            FieldLink.Add("起点正序电纳", false);
            FieldLink.Add("终点正序电纳", false);
            FieldLink.Add("起点高抗", false);
            FieldLink.Add("起点高抗值", false);
            FieldLink.Add("终点高抗", false);
            FieldLink.Add("终点高抗值", false);
            //线路分段长度
            FieldLink.Add("线路长度(km)", false);
            FieldLink.Add("导线型号", true);
            FieldLink.Add("导线截面", false);

            return FieldLink;
        }
        /// <summary>
        /// 构建数据集合项
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, bool> GetFieldItems()
        {
            Dictionary<string, bool> FieldLink = new Dictionary<string, bool>();
            //基本信息表
            FieldLink.Add("名称", false);
            FieldLink.Add("回路号", false);
            FieldLink.Add("起点名称", false);
            FieldLink.Add("起点类型", false);
            FieldLink.Add("终点名称", false);
            FieldLink.Add("终点类型", false);
            FieldLink.Add("线路类型", false);
            FieldLink.Add("电压等级(kV)", false);
            FieldLink.Add("供电公司", false);
            FieldLink.Add("供电区域", false);
            FieldLink.Add("行政区域", false);
            FieldLink.Add("建设进度", false);
            FieldLink.Add("运维单位", false);
            FieldLink.Add("排列方式", false);
            FieldLink.Add("建成日期", false);
            FieldLink.Add("充电功率", false);
            FieldLink.Add("所属区域", false);
            FieldLink.Add("运行状态", false);
            //交流线路表

            FieldLink.Add("起点母线", false);
            FieldLink.Add("终点母线", false);
            FieldLink.Add("额定电流(A)", false);
            FieldLink.Add("正序电阻", false);
            FieldLink.Add("正序电抗", false);
            FieldLink.Add("正序电纳", false);
            FieldLink.Add("零序电阻", false);
            FieldLink.Add("零序电抗", false);
            FieldLink.Add("零序电纳", false);
            FieldLink.Add("是否对称", false);
            FieldLink.Add("起点正序电导", false);
            FieldLink.Add("终点正序电导", false);
            FieldLink.Add("起点正序电纳", false);
            FieldLink.Add("终点正序电纳", false);
            FieldLink.Add("起点高抗", false);
            FieldLink.Add("起点高抗值", false);
            FieldLink.Add("终点高抗", false);
            FieldLink.Add("终点高抗值", false);
            //线路分段长度
            FieldLink.Add("线路长度(km)", false);
            FieldLink.Add("导线型号", false);
            FieldLink.Add("导线截面", false);

            return FieldLink;
        }
    }
}
