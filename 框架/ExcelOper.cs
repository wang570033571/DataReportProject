using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace 框架
{
    /// <summary>
    /// Excel操作
    /// </summary>
    public static class ExcelOper
    {
        /// <summary>
        /// 读取EXCEL
        /// </summary>
        /// <param name="sheetName">读取工作薄的名称</param>
        /// <returns>数据集</returns>
        public static DataSet ExcelRead(string sheetName)
        {
            DataSet dsSource = new DataSet();
            OpenFileDialog ofg = new OpenFileDialog();

            ofg.FilterIndex = 1;            //设置默认文件类型显示顺序
            ofg.RestoreDirectory = true;    //保存对话框是否记忆上次打开的目录
            ofg.Filter = "Excel-xlsx(*.xlsx)|*.xlsx|Excel-xls(*.xls)|*.xls"; //设置文件类型 

            if (ofg.ShowDialog() == DialogResult.OK && ofg.FileName != string.Empty)
            {
                dsSource = ExcelRead(ofg.FileName,sheetName);
            }
            return dsSource;
        }

        /// <summary>
        /// 读取EXCEL
        /// </summary>
        /// <param name="excelFilePath">Execl文件路径</param>
        /// <param name="sheetName">读取工作薄的名称</param>
        /// <returns>数据集</returns>
        public static DataSet ExcelRead(string excelFilePath, string sheetName)
        {
            System.Data.OleDb.OleDbConnection myConn = null;
            string strConnection = string.Empty;
            string strSQL = string.Empty;
            DataSet dsSource = new DataSet();
            DataTable dt = null;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                try
                {
                    strConnection = " Provider = Microsoft.Jet.OLEDB.4.0 ; Data Source = " + excelFilePath + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1'";//2003
                    myConn = new System.Data.OleDb.OleDbConnection(strConnection);
                    myConn.Open();
                }
                catch
                {
                    try
                    {
                        strConnection = " Provider = Microsoft.ACE.OLEDB.12.0 ; Data Source =" + excelFilePath + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1';";//2007        
                        myConn = new System.Data.OleDb.OleDbConnection(strConnection);
                        myConn.Open();
                    }
                    catch (Exception ex1)
                    {
                        throw new Exception("打开EXCEL时报错：" + ex1.Message);
                    }
                }

                if (sheetName.Trim().Length <= 0)
                {
                    dt = myConn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, new object[] { null, null, null, "Table" });
                    sheetName = dt.Rows[0]["TABLE_NAME"].ToString().Replace("$","");
                }

                strSQL = " Select * From [" + sheetName + "$]";
                System.Data.OleDb.OleDbDataAdapter myCommand = new System.Data.OleDb.OleDbDataAdapter(strSQL, myConn);
                myCommand.Fill(dsSource, "[" + sheetName + "]");
                myConn.Close();
            }
            catch (Exception ex2)
            {
                MessageBox.Show("导入失败,失败原因如下:" + ex2.Message.ToString(), "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
            return dsSource;
        }

        /// <summary>
        /// 导出数量
        /// </summary>
        /// <param name="gridView"></param>
        /// <param name="blExcelAll">True：导出所有数据，False：导出选择的数据</param>
        /// <returns></returns>
        public static bool ExportToExcel(DevExpress.XtraGrid.Views.Grid.GridView gridView, bool blExcelAll)
        {
            return ExportToExecl(gridView,blExcelAll,"导出数据");
        }

        /// <summary>
        /// 导出数量
        /// </summary>
        /// <param name="gridView"></param>
        /// <param name="blExcelAll">True：导出所有数据，False：导出选择的数据</param>
        /// <returns></returns>
        public static bool ExportToExecl(DevExpress.XtraGrid.Views.Grid.GridView gridView, bool blExcelAll,string sheetName)
        {
            if (gridView.RowCount <= 0) return false;

            try
            {
                gridView.OptionsPrint.AutoWidth = false;

                DataTable dtNew = (gridView.GridControl.DataSource as DataTable).Clone();

                if (blExcelAll) dtNew = gridView.GridControl.DataSource as DataTable;
                else
                {
                    foreach (int i in gridView.GetSelectedRows())
                    {
                        dtNew.ImportRow(gridView.GetDataRow(i));
                    }
                }

                //存储列名称
                DataTable dtColumns = new DataTable();
                dtColumns.Columns.Add("名称");
                dtColumns.Columns.Add("序号", typeof(int));

                DataTable dt = dtNew.Copy();

                foreach (DataColumn dc in dtNew.Columns)
                {
                    try
                    {
                        if (gridView.Columns[dc.Caption].Visible == true)
                            dtColumns.Rows.Add(new object[] { dc.Caption, gridView.Columns[dc.Caption].VisibleIndex });
                        else
                            dt.Columns.Remove(dc.Caption);
                    }
                    catch { dt.Columns.Remove(dc.Caption); }
                }

                dtColumns.DefaultView.Sort = "序号 ASC";
                DataTable dtt = dtColumns.DefaultView.ToTable();

                foreach (DataRow dr in dtt.Rows)
                {
                    dt.Columns[dr["名称"].ToString()].SetOrdinal(Convert.ToInt32(dr["序号"]));
                }

                return ExportToExecl(dt, sheetName);
            }
            catch (Exception ex) { 消息.提示(ex.Message); }

            return false;
        }
        
        ///// <summary>
        ///// 数据导出
        ///// </summary>
        ///// <param name="dtNew"></param>
        ///// <param name="path"></param>
        //public static bool ExportToExecl(DataTable dtNew)
        //{
        //    return ExportToExecl(dtNew, "导出数据");
        //}

        /// <summary>
        /// 数据导出
        /// </summary>
        /// <param name="dtNew"></param>
        /// <param name="path"></param>
        public static bool ExportToExecl(DataTable dtNew,string sheetName)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            //设置文件类型 
            sfd.Filter = "Excel-xlsx(*.xlsx)|*.xlsx|Excel-xls(*.xls)|*.xls";
            //设置默认文件类型显示顺序
            sfd.FilterIndex = 1;
            //保存对话框是否记忆上次打开的目录 
            sfd.RestoreDirectory = true;
            //点了保存按钮进入 
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                return ExportToExecl(dtNew, sfd.FileName,sheetName);
            }

            return false;
        }
        
        /// <summary>
        /// 数据导出
        /// </summary>
        /// <param name="dtNew"></param>
        /// <param name="path"></param>
        private static bool ExportToExecl(DataTable dtNew, string path, string sheetName)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application appexcel = new Microsoft.Office.Interop.Excel.Application();
                System.Reflection.Missing miss = System.Reflection.Missing.Value;

                Microsoft.Office.Interop.Excel.Workbook workbookdata;
                Microsoft.Office.Interop.Excel.Worksheet worksheetdata;
                Microsoft.Office.Interop.Excel.Range rangedata;

                //设置对象不可见
                appexcel.Visible = false;

                System.Globalization.CultureInfo currentci = System.Threading.Thread.CurrentThread.CurrentCulture;

                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-us");

                workbookdata = appexcel.Workbooks.Add(miss);

                worksheetdata = (Microsoft.Office.Interop.Excel.Worksheet)workbookdata.Worksheets.Add(miss, miss, miss, miss);

                //设置文字自动换行
                //worksheetdata.Cells.WrapText = true;

                //给工作表赋名称
                worksheetdata.Name = sheetName;
                DataTable dt = dtNew.Copy();

                int index = 1;
                foreach (DataColumn dc in dtNew.Columns)
                {
                    worksheetdata.Cells[1, index] = dc.Caption;
                    index++;

                    //设置导出的列宽
                    //((Microsoft.Office.Interop.Excel.Range)worksheetdata.Cells[1, 6]).ColumnWidth = 80;
                }

                //因为第一行已经写了表头，所以所有数据都应该从a2开始
                rangedata = worksheetdata.get_Range("a2", miss);

                Microsoft.Office.Interop.Excel.Range xlrang = null;

                //irowcount为实际行数，最大行
                int irowcount = dt.Rows.Count;
                int iparstedrow = 0, icurrsize = 0;

                //ieachsize为每次写行的数值，可以自己设置
                int ieachsize = 1000;

                //icolumnaccount为实际列数，最大列数
                int icolumnaccount = dt.Columns.Count;

                //在内存中声明一个ieachsize×icolumnaccount的数组，ieachsize是每次最大存储的行数，icolumnaccount就是存储的实际列数
                object[,] objval = new object[ieachsize, icolumnaccount];

                icurrsize = ieachsize;
                while (iparstedrow < irowcount)
                {
                    if ((irowcount - iparstedrow) < ieachsize)
                        icurrsize = irowcount - iparstedrow;

                    //用for循环给数组赋值
                    for (int i = 0; i < icurrsize; i++)
                    {
                        for (int j = 0; j < icolumnaccount; j++)
                            objval[i, j] = dt.Rows[i + iparstedrow][j].ToString();

                        System.Windows.Forms.Application.DoEvents();
                    }

                    string X = "A" + ((int)(iparstedrow + 2)).ToString();
                    string col = "";

                    if (icolumnaccount <= 26)
                    {
                        col = ((char)('A' + icolumnaccount - 1)).ToString() + ((int)(iparstedrow + icurrsize + 1)).ToString();
                    }
                    else
                    {
                        col = ((char)('A' + (icolumnaccount / 26 - 1))).ToString() + ((char)('A' + (icolumnaccount % 26 - 1))).ToString() + ((int)(iparstedrow + icurrsize + 1)).ToString();
                    }

                    xlrang = worksheetdata.get_Range(X, col);

                    // 调用range的value2属性，把内存中的值赋给excel
                    xlrang.Value2 = objval;
                    iparstedrow = iparstedrow + icurrsize;


                    xlrang.EntireColumn.AutoFit();
                    //xlrang.NumberFormat = "@";
                    //xlrang.NumberFormatLocal = "@";

                }
                //保存工作表
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlrang);
                xlrang = null;
                workbookdata.Saved = true;
                //appexcel.Save(path);
                workbookdata.SaveCopyAs(path);
                //appexcel.Save(path);
                appexcel.Quit();

                //调用方法关闭excel进程
                //appexcel.Visible = true; 

                return true;
            }
            catch (Exception ex) { 消息.提示(ex.Message); }

            return false;
        }
    }
}
