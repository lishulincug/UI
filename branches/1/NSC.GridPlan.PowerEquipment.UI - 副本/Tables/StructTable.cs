using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSC.GridPlan.PowerEquipment.UI.Tables
{
    /// <summary>
    /// 属性对象结构类
    /// </summary>
    public class StructTable
    {
        private string mGroup;
        /// <summary>
        /// 组名
        /// </summary>
        public string Group
        {
            get { return mGroup; }
            set { mGroup = value; }
        }
        private List<RowTable> mRow;
        /// <summary>
        /// 行集合
        /// </summary>
        public List<RowTable> Row
        {
            get 
            {
                if (mRow == null)
                    mRow = new List<RowTable>();
                return mRow;
            }
            set { mRow = value; }
        }
    }
    /// <summary>
    /// 行
    /// </summary>
    public class RowTable
    {
        private string mRowName;
        /// <summary>
        /// 行名称
        /// </summary>
        public string RowName
        {
            get { return mRowName; }
            set { mRowName = value; }
        }
        private ComEditType mRowType;
        /// <summary>
        /// 行类型
        /// </summary>
        public ComEditType RowType
        {
            get { return mRowType; }
            set { mRowType = value; }
        }
        private bool isHasChild=false;
        /// <summary>
        /// 是否有子行
        /// </summary>
        public bool IsHasChild
        {
            get { return isHasChild; }
            set { isHasChild = value; }
        }
        private object mRowValue;
        /// <summary>
        /// 行Value
        /// </summary>
        public object RowValue
        {
            get { return mRowValue; }
            set { mRowValue = value; }
        }
        private List<RowChildTable> mRowChild;
        /// <summary>
        /// 子行集合
        /// </summary>
        public List<RowChildTable> RowChild
        {
            get
            {
                if (mRowChild == null)
                    mRowChild = new List<RowChildTable>();
                return mRowChild;
            }
            set { mRowChild = value; }
        }
    }
    public class RowChildTable
    {
        private string mRowChildName;
        /// <summary>
        /// 子行名称
        /// </summary>
        public string RowChildName
        {
            get { return mRowChildName; }
            set { mRowChildName = value; }
        }
        private ComEditType mRowChildType;
        /// <summary>
        /// 子行类型
        /// </summary>
        public ComEditType RowChildType
        {
            get { return mRowChildType; }
            set { mRowChildType = value; }
        }
        private object mRowChildValue;
        /// <summary>
        /// 子行Value
        /// </summary>
        public object RowChildValue
        {
            get { return mRowChildValue; }
            set { mRowChildValue = value; }
        }
    }
    public enum ComEditType
    {
        下拉选择=0,
        数据集合=1,
        无=2
    }
}
