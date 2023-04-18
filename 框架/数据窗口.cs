using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Columns;
using System.Drawing;
using DevExpress.Data.Filtering;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using System.Data;
using System.IO;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.BandedGrid;


namespace 框架
{
    public class 数据窗口
    {
        private static ContextMenu _contextMenu;

        public static void 初始化(Control control, ContextMenu contextMenu)
        {
            _contextMenu = contextMenu;
            if (control is DevExpress.XtraGrid.GridControl)
            {
                control.ContextMenu = _contextMenu;

                foreach (DevExpress.XtraGrid.Views.Base.BaseView view in (control as DevExpress.XtraGrid.GridControl).Views)
                {
                    if (view.GetType().Name.Equals("BandedGridView"))
                    {
                        InitBandGrid(view as DevExpress.XtraGrid.Views.BandedGrid.BandedGridView);
                    }
                    else if (view is DevExpress.XtraGrid.Views.Grid.GridView)
                    {
                        InitGridView(view as DevExpress.XtraGrid.Views.Grid.GridView);
                    }
                }
            }
            else if (control.HasChildren)
            {
                foreach (Control c in control.Controls) 初始化(c, contextMenu);
            }
        }

        /// <summary>
        /// 初始化GridView
        /// </summary>
        /// <param name="gridView">gridView控件</param>
        /// <param name="dtLookUpEdit">加载下拉列表框的数据</param>
        /// <param name="blLoadLay">是否加载本地布局</param>
        private static void InitGridView(DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            gridView.Columns.Clear();

            // 默认格式设置
            gridView.IndicatorWidth = 50;
            gridView.OptionsBehavior.Editable = true;
            gridView.OptionsSelection.MultiSelect = true;
            //gridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            gridView.OptionsView.RowAutoHeight = true;
            gridView.OptionsView.ColumnAutoWidth = false;
            gridView.OptionsView.ShowGroupPanel = false;
            gridView.OptionsView.ShowFooter = true;

            //默认事件设置
            gridView.ShowGridMenu += new GridMenuEventHandler(gridView_ShowGridMenu);
            gridView.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(gridView_CustomDrawRowIndicator);
            gridView.FocusedColumnChanged += new DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventHandler(gridView_FocusedColumnChanged);
            gridView.KeyDown += new KeyEventHandler(gridView_KeyDown);

            if (gridView.Tag == null) return;
            string 命名空间 = gridView.GridControl.FindForm().GetType().FullName.ToString();

            //绑定列
            using (DataTable dtFileSetInfo = 系统字段(命名空间,gridView.Tag.ToString()))
            {
                if (dtFileSetInfo == null) return;
                    foreach (DataRow dr in dtFileSetInfo.Rows)
                    {
                        if (dr["字段"].ToString().ToUpper().Equals("FID")) gridView.ViewCaption = dr["字段"].ToString();
                        DevExpress.XtraGrid.Columns.GridColumn gc = gridView.Columns.Add();
                        SetGridColumn(gc, dr);
                        gc.Width = 90;
                    }
            }


            //获取布局本地
            try { 恢复布局(gridView); }
            catch { };
        }

        public static DataTable 系统字段(string 窗体,string 视图)
        {
            if (视图.Length <= 0) return null;
            SQL.脚本 = "Select * From v字段 With (Nolock) Where 是否显示=1 And 窗体="+SQL.引号(窗体);
            SQL.脚本 += "\n"+"And 视图 = " + SQL.引号(视图);
            SQL.脚本 += "\n" + "Order By 排序 Asc";

            using (DataSet ds = SQL.查询(SQL.DB.Report_DB, SQL.脚本, "不记日志"))
            {
                return ds.Tables[0];
            }
        }

        public static DataTable 更多查询字段(string 视图, string 条件)
        {
            if (视图.Length <= 0) return null;
            SQL.脚本 = "Select * From v字段 With (Nolock) Where " + 条件;
            SQL.脚本 += "\n" + " And 视图 = " + SQL.引号(视图);
            SQL.脚本 += "\n" + " Order By 排序 Asc";

            using (DataSet ds = SQL.查询(SQL.DB.Report_DB, SQL.脚本, "不记日志"))
            {
                return ds.Tables[0];
            }
        }

        /// <summary>
        /// 设置gridColumn列
        /// </summary>
        /// <param name="gcColumn">列</param>
        /// <param name="dr">设置信息</param>
        public static void SetGridColumn(GridColumn gcColumn, DataRow dr)
        {
            string filedType = dr["数据类型"].ToString().ToLower();

            gcColumn.Tag = dr;
            gcColumn.Name = dr["字段"].ToString();
            gcColumn.FieldName = dr["字段"].ToString();
            gcColumn.Caption = dr["字段"].ToString();
            gcColumn.VisibleIndex = Convert.ToInt16(dr["排序"]);
            gcColumn.OptionsColumn.AllowEdit = Convert.ToBoolean(dr["是否可编辑"]);
            gcColumn.Visible = Convert.ToBoolean(dr["是否显示"]);
            if (Convert.ToBoolean(dr["是否可编辑"]) && !gcColumn.GetType().Name.Equals("BandedGridColumn"))
                gcColumn.AppearanceCell.BackColor = Color.LightPink;

            if (Convert.ToBoolean(dr["是否可编辑"]))
            {
                // gcColumn.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gcColumn.SummaryItem.DisplayFormat = "{0:#,###,###,##0}";
            }

            switch (filedType)
            {
                case "date":
                    DevExpress.XtraEditors.Repository.RepositoryItemDateEdit ride = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
                    gcColumn.ColumnEdit = ride;
                    break;
                case "datetime":
                    DevExpress.XtraEditors.Repository.RepositoryItemTextEdit ridt = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
                    gcColumn.ColumnEdit = ridt;
                    break;
                case "numeric":
                case "decimal":
                case "float":
                case "money":
                    DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rite = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
                    //rite.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
                    rite.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
                    rite.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    if (!filedType.Equals("float"))
                    {
                        if (dr["小数位数"].ToString().Trim().Equals("0"))
                            rite.DisplayFormat.FormatString = "#,###,###,##0";
                        else
                            rite.DisplayFormat.FormatString = "#,###,###,##0." + string.Format("{0:D" + Convert.ToInt32(dr["小数位数"]) + "}", 0);
                    }
                    rite.NullText = "0";

                    gcColumn.ColumnEdit = rite;

                    break;
                case "bit":
                    DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rice = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
                    rice.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
                    rice.ValueGrayed = false;
                    gcColumn.ColumnEdit = rice;

                    break;
                case "int":
                    DevExpress.XtraEditors.Repository.RepositoryItemTextEdit riteInt = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
                    //riteInt.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
                    riteInt.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
                    riteInt.NullText = "0";
                    gcColumn.ColumnEdit = riteInt;

                    break;
                default:
                    DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
                    gcColumn.ColumnEdit = rit;

                    break;
            }
        }

        static void gridView_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView gv = sender as DevExpress.XtraGrid.Views.Grid.GridView;

            if (gv.Columns.Count <= 0) return;
            if (e.FocusedColumn == null) return;
            if ((e.FocusedColumn.Caption.Equals("选择") || e.FocusedColumn.ColumnType.FullName.Equals("System.Boolean") 
                || e.FocusedColumn.ColumnType.FullName.Equals("System.DateTime") || e.FocusedColumn.ColumnEdit != null)
                && e.FocusedColumn.OptionsColumn.AllowEdit == true)
                gv.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect;
            else
                gv.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CellSelect;
        }

        static void gridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.W)
                {
                    DevExpress.XtraGrid.Views.Grid.GridView gv = sender as DevExpress.XtraGrid.Views.Grid.GridView;
                    消息.显示(gv.GridControl.FindForm().GetType().FullName.ToString() + "\r\n" + (gv.Tag == null ? "没有绑定视图！" : (gv.Tag.ToString() == "" ? "没有绑定视图！" : gv.Tag.ToString())) + "\r\n");
                }
            }
        }

        //添加菜单
        static void gridView_ShowGridMenu(object sender, GridMenuEventArgs e)
        {
            if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Column)
            {
                DevExpress.XtraGrid.Menu.GridViewColumnMenu menu = e.Menu as DevExpress.XtraGrid.Menu.GridViewColumnMenu;

                if (menu.Column != null)
                {
                    if (menu.Items.Count > 9)
                    {
                        menu.Items.Add(CreateCheckItem("取消冻结", menu.Column, DevExpress.XtraGrid.Columns.FixedStyle.None, null));
                        menu.Items.Add(CreateCheckItem("靠左冻结", menu.Column, DevExpress.XtraGrid.Columns.FixedStyle.Left, null));
                        menu.Items.Add(CreateCheckItem("靠右冻结", menu.Column, DevExpress.XtraGrid.Columns.FixedStyle.Right, null));
                    }
                }
            }
        }

        /// 冻结/取消冻结
        static DXMenuCheckItem CreateCheckItem(string caption, GridColumn column, DevExpress.XtraGrid.Columns.FixedStyle style, Image image)
        {
            DXMenuCheckItem item = new DXMenuCheckItem(caption, column.Fixed == style, image, new EventHandler(OnFixedClick));
            item.Tag = new MenuInfo(column, style);
            return item;
        }

        static void OnFixedClick(object sender, EventArgs e)
        {
            DXMenuItem item = sender as DXMenuItem;
            MenuInfo info = item.Tag as MenuInfo;
            if (info == null) return;
            info.Column.Fixed = info.Style;
        }

        /// 显示行号
        static void gridView_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            if (e.Info.IsRowIndicator)
            {
                if (e.RowHandle >= 0)
                {
                    e.Info.DisplayText = (e.RowHandle + 1).ToString();
                }
                else if (e.RowHandle < 0 && e.RowHandle > -1000)
                {
                    e.Info.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
                    e.Info.DisplayText = "G" + e.RowHandle.ToString();
                }
            }
        }
        
        public static void 保存布局(DevExpress.XtraGrid.Views.Grid.GridView 数据窗口)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string 路径 = Application.StartupPath + "/布局/";
                string 文件名 = 数据窗口.GridControl.FindForm().GetType().FullName.ToLower() + "." + 数据窗口.Name + ".xml";

                if (!Directory.Exists(路径)) Directory.CreateDirectory(路径);

                数据窗口.SaveLayoutToXml(路径 + 文件名);

                FileInfo 文件 = new FileInfo(路径 + 文件名);
                string 名称 = 文件.Name;
                string 大小 = Convert.ToString(文件.Length / 1000);
                byte[] 内容 = 文件操作.文件转换成文件流(文件.FullName);
                SQL.脚本 = "Exec p用户字段上传 " + SQL.引号(SQL.操作员ID) + "," 
                                                + SQL.引号(名称) + ","
                                                + SQL.引号(大小) + ","
                                                + "@附件" + ","
                                                + SQL.引号(SQL.操作员);
                SQL.结果 = SQL.上传(SQL.DB.Report_DB, SQL.脚本, "用户字段上传", 内容);
                if (SQL.结果 != "成功") throw new Exception(SQL.结果);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        public static void 恢复布局(DevExpress.XtraGrid.Views.Grid.GridView 数据窗口)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string 路径 = Application.StartupPath + @"\布局\";
                string 文件名 = 数据窗口.GridControl.FindForm().GetType().FullName.ToLower() + "." + 数据窗口.Name + ".xml";
                string 路径文件名 = 路径 + 文件名;
                
                if (!File.Exists(路径文件名))
                {
                    SQL.脚本 = "Exec p获取用户字段文件 " + SQL.引号(SQL.操作员ID) + "," + SQL.引号(文件名);
                    DataSet ds = SQL.查询(SQL.DB.Report_DB, SQL.脚本, "下载用户字段");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        byte[] 文件流 = (byte[])ds.Tables[0].Rows[0][0];
                        文件操作.文件流转换成文件(路径, 文件名, 文件流);
                    }
                }

                数据窗口.RestoreLayoutFromXml(路径 + 文件名);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        public static void 清除布局(DevExpress.XtraGrid.Views.Grid.GridView 数据窗口)
        {
            数据窗口.Columns.Clear();
            数据窗口.GridControl.DataSource = null;
        }

        public static void 导出到Excel(DevExpress.XtraGrid.Views.Grid.GridView gv)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                DateTime 开始时间 = SQL.当前时间();
                string 路径 = Application.StartupPath + @"\导出\";
                if (!Directory.Exists(路径)) Directory.CreateDirectory(路径);

                string 名称 = gv.GridControl.FindForm().GetType().FullName.ToLower() + "." + gv.Name + "(" + SQL.当前时间().Ticks.ToString() + ")" + ".xls";

                gv.ExportToXls(路径 + 名称);

                System.Diagnostics.Process.Start(路径 + 名称);

                //if (MessageBox.Show("导出成功，是否现在打开？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                //{
                //    System.Diagnostics.Process.Start(路径 + 名称);
                //}
                //else
                //{
                //    MessageBox.Show("文件保存在" + 路径 + 名称, "提示");
                //}

                文件操作.记日志("导出(" + gv.GridControl.FindForm().GetType().FullName.ToLower() + "." + gv.Name + ")到Excel成功" + ",执行时间为:" + SQL.执行秒数(开始时间, SQL.当前时间()) + "秒");
            }
            catch (Exception ex)
            {
                消息窗体 msg = new 消息窗体(ex, ex.Message);
                msg.ShowDialog();
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        
        /// <summary>
        /// 初始化BandedGridView
        /// </summary>
        /// <param name="bandGridView"></param>
        public static void InitBandGrid(DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bandGridView)
        {
            if (bandGridView.Tag == null) return;
            string 命名空间 = bandGridView.GridControl.FindForm().GetType().FullName.ToString();
            using (DataTable dtFiledSetInfo = 系统字段(命名空间, bandGridView.Tag.ToString()))
            {
                InitBandGridInfo(bandGridView, dtFiledSetInfo);
            }
        }

        /// <summary>
        /// 加载BandGridView布局
        /// </summary>
        /// <param name="bandGridView">BandGridView控件</param>
        public static void InitBandGrid(DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bandGridView, DataTable dtFileInfo)
        {
            using (DataTable dtFile = CopFileData(dtFileInfo).Copy())
            {
                InitBandGridInfo(bandGridView, dtFile);

                int i = bandGridView.FocusedRowHandle;
                if (dtFileInfo == null || dtFileInfo.Rows.Count == 0)
                {
                    bandGridView.GridControl.DataSource = null;
                }
                else
                {
                    bandGridView.GridControl.DataSource = dtFileInfo;
                    bandGridView.SelectRow(i);
                    bandGridView.FocusedRowHandle = i;
                }
            }
        }

        private static DataTable CopFileData(DataTable dtSource)
        {
            DataTable dtNewTable = new DataTable();
            dtNewTable.Columns.Add("字段", typeof(string));
            dtNewTable.Columns.Add("是否显示", typeof(bool));
            dtNewTable.Columns.Add("是否可编辑", typeof(bool));
            dtNewTable.Columns.Add("数据类型", typeof(string));
            dtNewTable.Columns.Add("排序", typeof(int));
            //dtNewTable.Columns.Add("整数位数", typeof(int));
            dtNewTable.Columns.Add("小数位数", typeof(int));
            //dtNewTable.Columns.Add("长度", typeof(int));

            foreach (DataColumn dc in dtSource.Columns)
            {
                DataRow drNew = dtNewTable.NewRow();
                drNew["字段"] = dc.Caption.ToString();
                drNew["是否显示"] = "True";
                drNew["是否可编辑"] = "False";
                drNew["数据类型"] = "String";
                //drNew["是否可为空"] = "True";
                drNew["排序"] = dtNewTable.Rows.Count;
                //drNew["整数位数"] = 18;
                drNew["小数位数"] = 3;
                //drNew["长度"] = 255;

                dtNewTable.Rows.Add(drNew);
            }

            return dtNewTable;
        }

        /// <summary>
        /// 初始化BandedGridView
        /// </summary>
        /// <param name="bandGridView"></param>
        private static void InitBandGridInfo(DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bandGridView, DataTable dataTableFiled)
        {
            bandGridView.Columns.Clear();

            bandGridView.BeginUpdate(); //开始视图的编辑，防止触发其他事件
            bandGridView.Bands.Clear();

            //修改附加选项
            bandGridView.OptionsView.ShowColumnHeaders = false;                         //因为有Band列了，所以把ColumnHeader隐藏
            bandGridView.OptionsView.ShowGroupPanel = false;                            //如果没必要分组，就把它去掉
            //gvEdit.OptionsView.EnableAppearanceEvenRow = false;                       //是否启用偶数行外观
            //gvEdit.OptionsView.EnableAppearanceOddRow = true;                         //是否启用奇数行外观
            //gvEdit.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;   //是否显示过滤面板
            bandGridView.OptionsCustomization.AllowColumnMoving = false;                //是否允许移动列
            //gvEdit.OptionsCustomization.AllowColumnResizing = true;                   //是否允许调整列宽
            bandGridView.OptionsCustomization.AllowGroup = false;                       //是否允许分组
            bandGridView.OptionsCustomization.AllowFilter = false;                      //是否允许过滤
            bandGridView.OptionsCustomization.AllowSort = false;                        //是否允许排序
            bandGridView.OptionsSelection.EnableAppearanceFocusedCell = true;

            bandGridView.OptionsView.RowAutoHeight = true;
            bandGridView.OptionsView.ColumnAutoWidth = false;
            bandGridView.OptionsView.ShowFooter = true;
            bandGridView.OptionsBehavior.Editable = true;
            bandGridView.OptionsSelection.MultiSelect = true;
            bandGridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;

            //默认事件设置
            bandGridView.ShowGridMenu += new GridMenuEventHandler(gridView_ShowGridMenu);
            bandGridView.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(gridView_CustomDrawRowIndicator);
            bandGridView.FocusedColumnChanged += new DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventHandler(gridView_FocusedColumnChanged);
            bandGridView.KeyDown += new KeyEventHandler(gridView_KeyDown);

            if (bandGridView.Tag == null)
            {
                bandGridView.EndUpdate();
                return;
            }

            //string 命名空间 = bandGridView.GridControl.FindForm().GetType().FullName.ToString();
            using (DataTable dtFiledSetInfo = dataTableFiled)
            {
                if (dtFiledSetInfo == null) return;

                foreach (DataRow dr in dtFiledSetInfo.Rows)
                {
                    //添加列标题
                    GridBand bandName = null;
                    BandedGridColumn bgc = new BandedGridColumn();
                    SetGridColumn(bgc, dr);

                    int index = dr["字段"].ToString().IndexOf("|");
                    if (index > 0)
                    {
                        InitGridBrand(bandGridView, bandName, bgc, dr["字段"].ToString(), dr["是否显示"].ToString());

                        //bandName = bandGridView.Bands[dr["字段"].ToString().Substring(0, index)];
                        //if (bandName == null)
                        //{
                        //    bandName = bandGridView.Bands.AddBand(dr["字段"].ToString().Substring(0, index));
                        //    bandName.Name = dr["字段"].ToString().Substring(0, index);
                        //    //if (dr["是否可见"].ToString().Equals("False")) bandName.Visible = false;
                        //}

                        ////添加子项
                        //GridBand gbC = bandName.Children.AddBand(dr["字段"].ToString().Substring(index + 1, dr["字段"].ToString().Length - index - 1));
                        //gbC.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        //gbC.Name = dr["字段"].ToString().Substring(index + 1, dr["字段"].ToString().Length - index - 1);
                        //if (dr["是否显示"].ToString().Equals("False")) gbC.Visible = false;
                        //gbC.Columns.Add(bgc);
                    }
                    else
                    {
                        bandName = bandGridView.Bands.AddBand(dr["字段"].ToString());
                        bandName.Name = dr["字段"].ToString();
                        bandName.Columns.Add(bgc);
                        if (dr["是否显示"].ToString().Equals("False")) bandName.Visible = false;
                        bandName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    }

                    if (Convert.ToBoolean(dr["是否可编辑"])) bgc.AppearanceCell.BackColor = Color.LightPink;
                }
            }

            //获取表格布局
            //if (blLoadLay) InitGridControlLayOut(bandGridView);

            try { 恢复布局(bandGridView); }
            catch { };

            //结束视图的编辑
            bandGridView.EndUpdate();
        }

        /// <summary>
        /// 初始化GridBand
        /// </summary>
        /// <param name="bandedGridView"></param>
        /// <param name="gridBand"></param>
        /// <param name="bandedGridColumn"></param>
        /// <param name="name"></param>
        private static void InitGridBrand(BandedGridView bandedGridView, GridBand gridBand, BandedGridColumn bandedGridColumn, string name,string strShow)
        {
            int index = name.IndexOf("|");

            if (index > 0)
            {
                if (gridBand == null)
                {
                    gridBand = bandedGridView.Bands[name.Substring(0, index)];
                    if (gridBand == null)
                    {
                        gridBand = bandedGridView.Bands.AddBand(name.Substring(0, index));
                        gridBand.Name = name.Substring(0, index);
                        gridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    }
                }
                else
                {
                    bool blTrue = false;
                    if (gridBand.HasChildren)
                    {
                        foreach (GridBand gcc in gridBand.Children)
                        {
                            if (gcc.Caption.Equals(name.Substring(0, index)))
                            {
                                blTrue = true;
                                gridBand = gcc;
                                break;
                            }
                        }
                    }

                    if (blTrue == false)
                    {
                        gridBand = gridBand.Children.AddBand(name.Substring(0, index));
                        gridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    }
                }

                if (name.Split('|').Length == 2)
                {
                    gridBand = gridBand.Children.AddBand(name.Substring(index + 1, name.Length - index - 1));
                    gridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                    if (strShow.Equals("False")) gridBand.Visible = false;
                }

                InitGridBrand(bandedGridView, gridBand, bandedGridColumn, name.Substring(index + 1, name.Length - index - 1), strShow);
            }
            else
            {
                gridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gridBand.Columns.Add(bandedGridColumn);
            }
        }
    }

    class MenuInfo
    {
        public MenuInfo(GridColumn column, DevExpress.XtraGrid.Columns.FixedStyle style)
        {
            this.Column = column;
            this.Style = style;
        }
        public FixedStyle Style;
        public GridColumn Column;
    }

}
