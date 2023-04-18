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
    public partial class 基本窗体 : Form
    {
        public string 菜单ID = "0";
        public DataRow 工作流;

        public 基本窗体()
        {
            InitializeComponent();
            SQL.当前工程 = this.GetType().Namespace == "ERP" ? "SHS-ERP.exe" : this.GetType().Namespace + ".dll";
            SQL.当前窗体 = this.GetType().Name.ToString();
            try
            {
                菜单ID = SQL.获取菜单ID(this.GetType().FullName);
                
            }
            catch
            { }
        }

        private void 基本窗体_Shown(object sender, EventArgs e)
        {
            try
            {
                设置控件默认属性(this);
            }
            catch
            { }
        }

        private void 设置控件默认属性(Control 控件)
        {
            foreach (Control 子控件 in 控件.Controls)
            {
                if (子控件.Controls.Count > 0)
                {
                    设置控件默认属性(子控件);
                }
                if (子控件 is DevExpress.XtraGrid.GridControl)
                {
                    if ((子控件 as DevExpress.XtraGrid.GridControl).Tag == null
                            || string.IsNullOrEmpty((子控件 as DevExpress.XtraGrid.GridControl).Tag.ToString()))
                    {
                        数据窗口.初始化(子控件 as DevExpress.XtraGrid.GridControl, this.cmData);
                    }
                }
                if (子控件 is ComboBox)
                {
                    (子控件 as ComboBox).MaxDropDownItems = 50;
                }
            }
        }

        private void mi导出到Excel_Click(object sender, EventArgs e)
        {
            try
            {
                DevExpress.XtraGrid.Views.Grid.GridView gv = (cmData.SourceControl as DevExpress.XtraGrid.GridControl).FocusedView as DevExpress.XtraGrid.Views.Grid.GridView;
                数据窗口.导出到Excel(gv);
            }
            catch (Exception ex)
            {
                消息窗体 msg = new 消息窗体(ex, ex.Message);
                msg.ShowDialog();
            }
        }

        private void mi字段配置_Click(object sender, EventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView gv = (cmData.SourceControl as DevExpress.XtraGrid.GridControl).FocusedView as DevExpress.XtraGrid.Views.Grid.GridView;
            字段配置.窗体 = this.GetType().FullName;
            if (gv.Tag == null) return;
            字段配置.视图 = gv.Tag.ToString();
            字段配置 frm = new 字段配置();
            frm.ShowDialog();
        }

        private void mi保存布局_Click(object sender, EventArgs e)
        {
            try
            {
                DevExpress.XtraGrid.Views.Grid.GridView gv = (cmData.SourceControl as DevExpress.XtraGrid.GridControl).FocusedView as DevExpress.XtraGrid.Views.Grid.GridView;
                数据窗口.保存布局(gv);
            }
            catch (Exception ex)
            {
                消息窗体 msg = new 消息窗体(ex, ex.Message);
                msg.ShowDialog();
            }
        }

        private void mi复制数据_Click(object sender, EventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView gridView = (cmData.SourceControl as DevExpress.XtraGrid.GridControl).FocusedView as DevExpress.XtraGrid.Views.Grid.GridView;
            try
            {
                gridView.CopyToClipboard();
                string copyData = Clipboard.GetText();
                if (copyData.Length > 2) copyData = copyData.Substring(0, copyData.Length - 2);
                Clipboard.Clear();
                if (copyData.Trim().Length > 2) Clipboard.SetText(copyData.Substring(copyData.IndexOf("\r") + 2));
                else if (copyData.Trim().Length > 0) Clipboard.SetText(copyData);
            }
            catch (Exception ex) { throw ex; }
        }

        private void mu全选_Click(object sender, EventArgs e)
        {
            try
            {
                DevExpress.XtraGrid.Views.Grid.GridView gv = (cmData.SourceControl as DevExpress.XtraGrid.GridControl).FocusedView as DevExpress.XtraGrid.Views.Grid.GridView;
                gv.SelectAll();
            }
            catch (Exception ex)
            {
                消息窗体 msg = new 消息窗体(ex, ex.Message);
                msg.ShowDialog();
            }
        }

        private void mu相同_Click(object sender, EventArgs e)
        {
            try
            {
                DevExpress.XtraGrid.Views.Grid.GridView gv = (cmData.SourceControl as DevExpress.XtraGrid.GridControl).FocusedView as DevExpress.XtraGrid.Views.Grid.GridView;
                string fieldName = gv.FocusedColumn.FieldName;
                string fieldValue = gv.GetFocusedRowCellValue(fieldName).ToString();
                gv.ClearSelection();
                for (int i = 0; i < gv.RowCount; i++)
                {
                    if (fieldValue.Equals(gv.GetRowCellValue(i, fieldName).ToString())) gv.SelectRow(i);
                }
            }
            catch (Exception ex)
            {
                消息窗体 msg = new 消息窗体(ex, ex.Message);
                msg.ShowDialog();
            }
        }

        private void cmData_Popup(object sender, EventArgs e)
        {
            if (!SQL.岗位.ContainsValue("系统管理员")) mi字段配置.Visible = false;
        }

        private void mi字体设置_Click(object sender, EventArgs e)
        {
            DevExpress.XtraGrid.Views.Base.BaseView view = (cmData.SourceControl as DevExpress.XtraGrid.GridControl).FocusedView;
            FontDialog fd = new FontDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                foreach (DevExpress.Utils.AppearanceObject ap in view.Appearance)
                    ap.Font = fd.Font;
            }
        }

    }
}
