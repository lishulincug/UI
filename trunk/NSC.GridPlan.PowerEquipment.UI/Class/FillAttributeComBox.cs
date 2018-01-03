using DevExpress.XtraEditors.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSC.GridPlan.PowerEquipment.UI.Class
{
    public class FillAttributeComBox
    {
        /// <summary>
        /// 填充初始值
        /// </summary>
        /// <param name="mRepositoryItemComboBox"></param>
        public static void FillComBox(RepositoryItemComboBox mRepositoryItemComboBox)
        {
            string Type=mRepositoryItemComboBox.Name;
            object[] objectCollect = getFillValue(Type);
            if (objectCollect!=null)
                mRepositoryItemComboBox.Items.AddRange(objectCollect);
        }
        /// <summary>
        /// 获取相应初始值集合
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static object[] getFillValue(string type)
        {
            object[] objectCollect=null;
            switch (type)
            {
                case "电压等级(kV)":
                    objectCollect = new object[4];
                    objectCollect[0] = 500;
                    objectCollect[1] = 220;
                    objectCollect[2] = 110;
                    objectCollect[3] = 35;
                    break;
            }


            return objectCollect;
        }
    }
}
