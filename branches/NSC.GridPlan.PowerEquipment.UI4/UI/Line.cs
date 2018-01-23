using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NSC.GridPlan.PowerEquipment.UI.Class;
using NSC.PMSHandler.DataContractObjects;
using DevExpress.Spreadsheet;
using DevExpress.Spreadsheet.Export;
   

namespace NSC.GridPlan.PowerEquipment.UI.UI
{
    public partial class Line : Form
    {
        string DBFileName = Application.StartupPath + "\\湖北省2012年地理接线图.mdb";
        string excelName = Application.StartupPath + "\\Model\\GV_LINE\\GV_LINE.xlsx";
        const string
            NewRow = "New",
            TableGrid = "[GV_LINE]",
            TableLookUp = "GV_STATION_GENERATORSET";
        public Line()
        {
            InitializeComponent();
            InitializeTable();
        }

        private void InitializeTable()
        {
            spreadsheetControl1.BeginUpdate();
            //if (excelName != string.Empty)
            //{
            //    this.spreadsheetControl1.LoadDocument(excelName, DocumentFormat.OpenXml);
            //    IWorkbook workbook = spreadsheetControl1.Document;
            //    workbook.LoadDocument(excelName);
                
            //}
            DataSet ds = new DataSet();
            if (DBFileName != string.Empty)
            {
                
                System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("SELECT TOP 1 * FROM " + TableGrid, "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + DBFileName);
                DataBaseOp.SetWaitDialogCaption("Loading Order Details...");
                oleDbDataAdapter.Fill(ds, TableGrid);
                oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("SELECT * FROM " + "[GV_LINE_XX]", "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + DBFileName);
                DataBaseOp.SetWaitDialogCaption("Loading Products...");
                oleDbDataAdapter.Fill(ds, "[GV_LINE_XX]");
                
                InitalspreadsheetControlByMdb(spreadsheetControl1, ds, TableGrid);
                //vGridControl2.DataSource = ds.Tables[TableGrid];
                //vGridControl4.Rows.Add
                //repositoryItemLookUpEdit1.DataSource = ds.Tables[TableLookUp];
                //vGridControl2.BestFit();

            }
            spreadsheetControl1.EndUpdate();
        }

        private void spreadsheetControl1_Click(object sender, EventArgs e)
        {

        }
        private void CellBeginEdit(object sender, DevExpress.XtraSpreadsheet.SpreadsheetCellCancelEventArgs e)
        {
            if (e.RowIndex == 0 || e.RowIndex == 1)
            {e.Cancel = true;}
        }

        private void InitalspreadsheetControlByMdb(DevExpress.XtraSpreadsheet.SpreadsheetControl SpreadsheetControlx, DataSet Ds, string tableName)
        {
            IList<string> strGroupName1 = new List<string>();
            string TableGV_LINE_XX = "[GV_LINE_XX]";
            IList<string> strGrouptableName = new List<string>();
            strGrouptableName.Add(tableName);
            strGrouptableName.Add(TableGV_LINE_XX);
            
            strGroupName1.Add("线路基本信息");
            strGroupName1.Add("线路线型表");
            int col1=0;
            int col2 = 0;
            int col=0;
            int Start = 0;
            Range range = spreadsheetControl1.Document.Range["A1:A2"];
            IList<string> strColumnName1 = new List<string>();
            IList<string> strColumnName2=new List<string>();
            IList<string> strColumnName1en = new List<string>();
            IList<string> strColumnName2en = new List<string>();
            for (int j = 0; j < strGrouptableName.Count; j++)
            {
                if (Ds.Tables[strGrouptableName[j]] != null)
                {
                    if (j > 0)
                    { 
                        col += Ds.Tables[strGrouptableName[j - 1]].Columns.Count;
                        string strcol = col.ToString();
                        string strcol1 = (col+Ds.Tables[strGrouptableName[j ]].Columns.Count).ToString();
                        range = spreadsheetControl1.Document.Range.FromLTRB( col,0, (col+Ds.Tables[strGrouptableName[j ]].Columns.Count)-1,0);
                        range.FillColor = DevExpress.Utils.DXColor.DarkBlue;
                    }
                    else
                    {
                        range = spreadsheetControl1.Document.Range.FromLTRB(0, 0,Ds.Tables[strGrouptableName[j]].Columns.Count-1,0);
                        range.FillColor = DevExpress.Utils.DXColor.SteelBlue;
                    }
                    spreadsheetControl1.BeginUpdate();
                    
                    range.Merge();               
                    SpreadsheetControlx.ActiveWorksheet.Cells[0, col].Value = strGroupName1[j];
                    range.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center;
                    range.Alignment.Vertical = SpreadsheetVerticalAlignment.Center;
                    spreadsheetControl1.EndUpdate();
                    if (j > 0)
                    { Start = col1 + col2; }  
                    for (int i = 0; i < Ds.Tables[strGrouptableName[j]].Columns.Count; i++)
                    {
                        string TableMETADATA_FIELD = "[METADATA_FIELD]";
                        DataSet ds = new DataSet();
                        System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("SELECT   ALIAS  FROM " + TableMETADATA_FIELD + "WHERE FIELDNAME =" + "'" + Ds.Tables[strGrouptableName[j]].Columns[i].ColumnName + "'" + " AND " + "TABLENAME =" + "'" + strGrouptableName[j].Replace("[", "").Replace("]", "") + "'", "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + DBFileName);
                        DataBaseOp.SetWaitDialogCaption("Loading Order Details...");
                        oleDbDataAdapter.Fill(ds, TableMETADATA_FIELD);
                        if (Ds.Tables[strGrouptableName[j]].Rows.Count > 0)
                        {

                            if (!(Ds.Tables[strGrouptableName[j]].Rows[0][Ds.Tables[strGrouptableName[j]].Columns[i].ColumnName] is System.DBNull) & ds.Tables[TableMETADATA_FIELD].Rows[0] != null)
                            {
                                col1 += 1;
                                strColumnName1.Add(ds.Tables[TableMETADATA_FIELD].Rows[0]["ALIAS"].ToString());
                                strColumnName1en.Add(Ds.Tables[strGrouptableName[j]].Columns[i].ColumnName);
                                //SpreadsheetControlx.ActiveWorksheet.Cells[1, col1 - 1].Value = ds.Tables[TableMETADATA_FIELD].Rows[0]["ALIAS"].ToString();
                            }
                            else if (Ds.Tables[strGrouptableName[j]].Rows[0][Ds.Tables[strGrouptableName[j]].Columns[i].ColumnName] is System.DBNull & ds.Tables[TableMETADATA_FIELD].Rows[0] != null)
                            {
                                col2 += 1;
                                strColumnName2.Add(ds.Tables[TableMETADATA_FIELD].Rows[0]["ALIAS"].ToString());
                                strColumnName2en.Add(Ds.Tables[strGrouptableName[j]].Columns[i].ColumnName);
                            }
                            //else
                            //{
                            //    this.mEditorRow.Properties.Caption = Ds.Tables[strGrouptableName[j]].Columns[i].ColumnName;
                            //    this.mCategoryRow.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] { this.mEditorRow });
                            //}
                        }
                        
                    }               
                                      
                    for (int k = Start; k < (col1 + col2); k++)
                    {
                        if (k<col1)
                        {
                            SpreadsheetControlx.ActiveWorksheet.Cells[1, k].Value = "*"+strColumnName1[k];
                            SpreadsheetControlx.ActiveWorksheet.Cells[1, k].Name = strColumnName1en[k];
                        }
                        if (k >= col1)
                        {
                            SpreadsheetControlx.ActiveWorksheet.Cells[1, k].Value = strColumnName2[k-col1];
                            SpreadsheetControlx.ActiveWorksheet.Cells[1, k].Name = strColumnName2en[k - col1];
                        }
                    }
                }
            }
            SpreadsheetControlx.SaveDocument(Application.StartupPath + @"\Model\GV_LINE\GV_LINE2\" + ".xlsx");
        }

        private void toolDB_Click(object sender, EventArgs e)
        {
            //string TableMETADATA_FIELD = "[METADATA_FIELD]";
            //DataSet ds = new DataSet();
            //System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter = new System.Data.OleDb.OleDbDataAdapter("SELECT   ALIAS  FROM " + TableMETADATA_FIELD + "WHERE FIELDNAME =" + "'" + Ds.Tables[strGrouptableName[j]].Columns[i].ColumnName + "'" + " AND " + "TABLENAME =" + "'" + strGrouptableName[j].Replace("[", "").Replace("]", "") + "'", "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + DBFileName);
            //DataBaseOp.SetWaitDialogCaption("Loading Order Details...");
            //oleDbDataAdapter.Fill(ds, TableMETADATA_FIELD);
                    
            //sheet.DataBindings.BindToDataSource(dataSet.Suppliers, 11, 1);
            Worksheet worksheet = spreadsheetControl1.ActiveWorksheet;
            //spreadsheetControl1.DataBindings.;
            DataTable dtData = new DataTable();//worksheet.Cells as DataTable;
            dtData = WorksheetToTable(worksheet);
            DataBaseOp.DataOperator(dtData);
        }

        private void Line_Load(object sender, EventArgs e)
        {
            // TODO:  这行代码将数据加载到表“湖北省2012年地理接线图DataSet1.GV_LINE”中。您可以根据需要移动或删除它。
            this.gV_LINETableAdapter.Fill(this.湖北省2012年地理接线图DataSet1.GV_LINE);

        }
        private void getsheet(Worksheet worksheet)
        {
            DataTable dt = new DataTable();
        }

        /// <summary>
        /// 将worksheet转成datatable
        /// </summary>
        /// <param name="worksheet">待处理的worksheet</param>
        /// <returns>返回处理后的datatable</returns>
        public static DataTable WorksheetToTable(Worksheet worksheet)
        {
            //获取worksheet的行数
            int rows = 8;// worksheet.Dimension.End.Row;
            //获取worksheet的列数
            int cols = 5;// worksheet.Dimension.End.Column;

            DataTable dt = new DataTable(worksheet.Name);
            DataRow dr = null;
            for (int i = 1; i <= rows; i++)
            {
                if (i > 1)
                    dr = dt.Rows.Add();

                for (int j = 1; j <= cols; j++)
                {
                    //默认将第一行设置为datatable的标题
                    if (i == 2)
                        dt.Columns.Add(worksheet.Cells[i, j].Name);
                    //剩下的写入datatable
                    else
                        dr[j - 1] = worksheet.Cells[i, j].Value;
                }
            }
            return dt;
        }
    }
}
