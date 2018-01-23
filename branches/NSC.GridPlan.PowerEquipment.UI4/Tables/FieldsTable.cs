using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace NSC.GridPlan.PowerEquipment.UI.Tables
{
    public class FieldsTable
    {
        public static void GetFieldsTable(DataTable dtFields)
        {
            dtFields.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("字段名",typeof(string)),
                new DataColumn("对应值",typeof(object)),
            });
        }


    }
}
