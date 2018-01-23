using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using NSC.PMSHandler.DataContractObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NSC.GridPlan.PowerEquipment.UI.Class
{
    /// <summary>
    /// 基础功能类
    /// </summary>
    public class BaseFunction
    {
        /// <summary>
        /// 限定TextEdit只能输入数值 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x20) e.KeyChar = (char)0;  //禁止空格   
            if (e.KeyChar == 0x2e) e.KeyChar = (char)0;  //禁止小数点   
            if ((e.KeyChar == 0x2D) && (((TextEdit)sender).Text.Length == 0)) return;
            //处理负数  
            if (e.KeyChar > 0x20)
            {
                try
                {
                    int max = int.Parse(((TextEdit)sender).Text + e.KeyChar.ToString());
                    if (max < -128 || max > 127)
                        //输入数值范围控制           
                        e.KeyChar = (char)0;
                }
                catch
                {
                    e.KeyChar = (char)0;  //处理非法字符串         
                }
            }
        }
        /// <summary>
        /// 获取TextEdit值(可转换文本值)
        /// </summary>
        /// <returns></returns>
        public static int GetCode(string Value)
        {
            //判断是否为空
            int mNum = 0;//记录值
            if (string.IsNullOrEmpty(Value))
                mNum = 0;
            else
                mNum = Convert.ToInt32(Value);
            return mNum;
        }
        /// <summary>
        /// 改变表格行数
        /// </summary>
        /// <param name="view">当前GridView</param>
        /// <param name="count">需要的行数</param>
        public static void GridViewChanged(GridView view,int count)
        {
            if (view.RowCount > count)//移除多余行
            {
                for (int i = view.RowCount; i >= count; i--)
                {
                    view.DeleteRow(i);
                }
            }
            else//添加行
            {
                for (int j = view.RowCount; j < count; j++)
                {
                    view.AddNewRow();
                }
            }
        }
        /// <summary>
        /// 改变表格行数
        /// </summary>
        /// <param name="view">当前GridView</param>
        /// <param name="count">需要的行数</param>
        /// <param name="Value">对应数据</param>
        public static void GridViewChanged(GridView view,int count,object Value)
        {
            SubStaObjects mSubSta = Value as SubStaObjects;
            if (view.RowCount > count & count >=0)//移除多余行
            {
                for (int i = view.RowCount; i >= count; i--)
                {

                    if (view.Tag.ToString() == "变电站主变" & mSubSta.SubGUSCollection.Count == view.RowCount & i>=1)
                    {
                        mSubSta.SubGUSCollection.RemoveAt(i-1);
                    }
                    else if (view.Tag.ToString() == "变电站母线" & mSubSta.SubGUSCollection.Count == view.RowCount)
                    {
                        Console.WriteLine("{0}", i);
                        mSubSta.SubBusCollection.RemoveAt(i-1);
                    }
                    view.DeleteRow(i);
                }
            }
            else//添加行
            {
                for (int j = view.RowCount; j < count; j++)
                {
                    view.AddNewRow();
                    if (view.Tag.ToString() == "变电站主变" & count>1)
                    {
                        SubGSUObjects mSubGUS = new SubGSUObjects();
                        mSubGUS.GSU.GSUCode = view.GetRowCellValue(j, view.Columns[0]).ToString();
                        mSubSta.SubGUSCollection.Add(mSubGUS);
                    }
                    else if (view.Tag.ToString() == "变电站母线" & count > 1)
                    {
                        SubBusObjects mSubBus = new SubBusObjects();
                        mSubBus.SubBus.BusCode = view.GetRowCellValue(j, view.Columns[0]).ToString();
                        mSubSta.SubBusCollection.Add(mSubBus);
                    }
                }
            }
        }
    }
}
