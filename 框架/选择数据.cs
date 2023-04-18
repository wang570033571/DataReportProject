using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 框架
{
    internal partial class 选择数据 : Form
    {
        public DataRow drSelect;
        public DataTable dtData;
        private string SQL脚本;
        private SQL.DB _数据库;
        private string[] strQueryColumn;
        private bool _是否加载数据 = false;
        private bool _是否多选 = false;
        private string _查询条件 ="";

        public 选择数据(SQL.DB 数据库, string 表名,string 列名,string 查询字段,string 查询条件,bool 是否加载数据,bool 是否多选)
        {
            InitializeComponent();

            _查询条件 = 查询条件;
            _是否多选 = 是否多选;
            _是否加载数据 = 是否加载数据;

            _数据库 = 数据库;
            strQueryColumn = 查询字段.Split(';');

            if (列名.Trim().Length <= 0)  SQL脚本 = "Select * From " + 表名 +" With(Nolock) ";
            else SQL脚本 = "Select "+ 列名 +" From "+ 表名 +" With(Nolock) ";

            //if (查询条件.Trim().Length > 0) SQL脚本 = SQL脚本 + " Where " + 查询条件;

            this.Load += new EventHandler(选择数据_Load);
        }

        void 选择数据_Load(object sender, EventArgs e)
        {
            初始化();
        }

        private void 初始化()
        {
            if (_是否加载数据) 查询(" 1=1");
            else 查询(" 1=0");

            if (gv.Columns.Count <= 4) gv.OptionsView.ColumnAutoWidth = true;
            else gv.OptionsView.ColumnAutoWidth = false;

            this.gv.OptionsView.ShowGroupPanel = false;
            this.gv.OptionsBehavior.Editable = false;

            if (_是否多选)
            {
                this.gv.OptionsSelection.MultiSelect = true;
                this.gv.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            }
            else
            {
                this.gv.OptionsSelection.MultiSelect = false;
                this.gv.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;
            }

            SetQueryCondition(0);

            tsb更多查询.Click += new EventHandler(tsb更多查询_Click);
            tsb查询.Click += new EventHandler(tsb查询_Click);
            tsb确认.Click += new EventHandler(tsb确认_Click);
            tsb关闭.Click += new EventHandler(tsb关闭_Click);

            gv.DoubleClick += new EventHandler(gv_DoubleClick);
        }

        void txt名称_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 查询("");
        }

        void tsb更多查询_Click(object sender, EventArgs e)
        {
            SetQueryCondition(1);
        }

        int columnIndex = 1;
        /// <summary>
        /// 设置查询条件布局
        /// </summary>
        /// <param name="intType"></param>
        private void SetQueryCondition(int intType)
        {
            if (intType == 1 && tsb更多查询.Text.Equals("更多查询"))
            {
                tsb更多查询.Text = "收起查询";
                tsb更多查询.Image = (System.Drawing.Image)(((System.Drawing.Icon)(按钮图标.ResourceManager.GetObject("最上"))).ToBitmap());
            }
            else if (intType == 1 && tsb更多查询.Text.Equals("收起查询"))
            {
                foreach (Control ctl in this.gbTop.Controls)
                {
                    if (ctl.TabIndex <= strQueryColumn.Length) continue;
                    ctl.Visible = false;
                }

                columnIndex = strQueryColumn.Length+1;
                this.gbTop.Height = columnIndex / 2 * 24+20;

                tsb更多查询.Text = "更多查询";
                tsb更多查询.Image = (System.Drawing.Image)(((System.Drawing.Icon)(按钮图标.ResourceManager.GetObject("最下"))).ToBitmap());
                return;
            }

            string[] strColumns;

            if (intType == 0) strColumns = strQueryColumn;
            else
            {
                StringBuilder sb = new StringBuilder();
                foreach (DevExpress.XtraGrid.Columns.GridColumn gc in gv.Columns)
                {
                    if (!strQueryColumn.Contains(gc.FieldName)) sb.Append(";" + gc.FieldName);
                }

                if (sb.ToString().Trim().Length >0) strColumns = sb.ToString().Substring(1).Split(';');
                else strColumns = new string[0];
            }
            
            foreach (string strName in strColumns)
            {
                DevExpress.XtraGrid.Columns.GridColumn gc = gv.Columns[strName];
                if (gc == null) continue;
                if (gc.Visible == false) continue;

                if (!this.gbTop.Controls.ContainsKey(gc.FieldName))
                {
                    Label lblTitle = new Label();
                    lblTitle.Text = gc.FieldName;
                    lblTitle.Name = gc.FieldName;
                    lblTitle.Top = (columnIndex % 2 == 0 ? (int)(columnIndex / 2) - 1 : (int)(columnIndex / 2)) * 24 + 18;
                    lblTitle.Left = columnIndex % 2 == 1 ? 20 : 280;
                    lblTitle.Width = 80;
                    lblTitle.TabIndex = columnIndex;
                    lblTitle.BackColor = Color.Transparent;
                    lblTitle.Visible = true;
                    this.gbTop.Controls.Add(lblTitle);

                    TextBox txtContent = new TextBox();
                    txtContent.Name = gc.FieldName + "1";
                    txtContent.Top = (columnIndex % 2 == 0 ? (int)(columnIndex / 2) - 1 : (int)(columnIndex / 2)) * 24 + 14;
                    txtContent.Left = columnIndex % 2 == 1 ? 100 : 370;
                    txtContent.Width = 150;
                    txtContent.Visible = true;
                    txtContent.TabIndex = columnIndex;
                    txtContent.Tag = gc.FieldName + " Like '%@值%'";
                    if (gc.ColumnType == typeof(System.Int32) || gc.ColumnType == typeof(System.Decimal) || gc.ColumnType == typeof(System.Double)) txtContent.RightToLeft = RightToLeft.Yes;
                    txtContent.KeyDown += new KeyEventHandler(txtContent_KeyDown);
                    this.gbTop.Controls.Add(txtContent);
                }
                else
                {
                    this.gbTop.Controls[gc.FieldName].Visible = true;
                    this.gbTop.Controls[gc.FieldName+"1"].Visible = true;
                }

                columnIndex++;
            }

            this.gbTop.Height =  columnIndex / 2 * 24+20;
        }

        void txtContent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 查询("");
        }

        void tsb查询_Click(object sender, EventArgs e)
        {
            查询("");
        }

        void tsb确认_Click(object sender, EventArgs e)
        {
            确认();
        }

        void tsb关闭_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        void gv_DoubleClick(object sender, EventArgs e)
        {
            确认();
        }

        private void 查询(string strWhere)
        {
            string strSQL = "";

            if (strWhere.Trim().Length <= 0) strWhere = " 1=1 "+ this.获取查询脚本(this.gbTop); 

            if (SQL脚本.ToLower().Contains("where")) strSQL = SQL脚本 + " And " + strWhere;
            else strSQL = SQL脚本 + " Where " + strWhere;

            if (_查询条件.Trim().Length > 0)
            {
                if (_查询条件.Trim().ToUpper().StartsWith("ORDER")) strSQL += " " + _查询条件;
                else strSQL += " And " + _查询条件;
            }

            SQL.查询(_数据库, strSQL, "查询数据", gv);
            gv.BestFitColumns();
        }

        private void 确认()
        {
            if (this.gv.GridControl.DataSource != null)
            {
                if (!_是否多选)
                {
                    if (gv.GetFocusedDataRow() != null) drSelect = gv.GetFocusedDataRow();
                }
                else
                {
                    dtData = (this.gv.GridControl.DataSource as DataTable).Clone();

                    if ((this.gv.GridControl.DataSource as DataTable).Columns.Contains("选择"))
                    {
                        DataRow[] drData = (this.gv.GridControl.DataSource as DataTable).Select("选择=True");
                        foreach (DataRow dr in drData)
                        {
                            dtData.ImportRow(dr);
                        }
                    }
                    else
                    {
                        foreach (int index in this.gv.GetSelectedRows())
                        {
                            dtData.ImportRow(this.gv.GetDataRow(index));
                        }
                    }
                }
            }

            this.DialogResult = DialogResult.Yes;
            this.Close();
        }
        
        private string 获取查询脚本(Control 控件)
        {
            string 返回值 = "";
            foreach (Control c in 控件.Controls)
            {
                if (!(c is TextBox) && !(c is ComboBox) && !(c is DateTimePicker) && !(c is CheckBox) && !(c is MaskedTextBox)
                    || c.Tag == null || c.Text.Trim().Length <= 0) continue;

                if (c.Visible == false) continue;
                if (c.Tag.ToString().Length <= 0) continue;

                if (c.Tag.ToString().ToUpper().IndexOf("BETWEEN") >= 0)
                {
                    返回值 += "\n And " + c.Tag.ToString().Replace("@值", SQL.获取日期范围(c.Text.Trim()));
                }
                else
                {
                    string value = SQL.获取查询值(c); // 不过滤空格等字符

                    if (value.Trim().Length > 0)
                        返回值 += "\n And " + c.Tag.ToString().Replace("@值", value);
                }
            }
            return 返回值;
        }
    }
}
