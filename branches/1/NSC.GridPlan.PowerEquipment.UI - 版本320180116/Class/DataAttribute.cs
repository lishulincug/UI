using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSC.GridPlan.PowerEquipment.UI.Class
{
    /// <summary>
    /// 属性方法类
    /// </summary>
    public class DataAttribute
    {
        static Dictionary<string, object> attribute = new Dictionary<string, object>();
        /// <summary>
        /// 设置属性
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public static void SetAttribute(string name, object value)
        {
            attribute.Add(name, value);
        }
        public static object GetAttribute(string name)
        {

            return attribute[name];
        }
    }
}
