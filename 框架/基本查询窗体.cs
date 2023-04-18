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
    public partial class 基本查询窗体 : 基本窗体
    {
        public bool 查询标志 = false;

        protected int intCount = 1000;

        public 基本查询窗体()
        {
            InitializeComponent();
            this.Load += new EventHandler(基本查询窗体_Load);
        }

        void 基本查询窗体_Load(object sender, EventArgs e)
        {
            初始化按钮();
            SQL.设置查询控件(panel1);
            txt记录数.TextChanged += new EventHandler(txt记录数_TextChanged);
        }

        void txt记录数_TextChanged(object sender, EventArgs e)
        {
            if (this.txt记录数.Text.Trim().Length <= 0)
                this.txt记录数.Text = "1000";

            this.intCount = Convert.ToInt32(this.txt记录数.Text.Trim());
        }

        private void AddToolButton(string 名称, string 图标名称)
        {
            System.Windows.Forms.ToolStripButton tsb = new System.Windows.Forms.ToolStripButton(名称);
            tsb.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            if (按钮图标.ResourceManager.GetObject(图标名称) != null)
                tsb.Image = (System.Drawing.Image)(((System.Drawing.Icon)(按钮图标.ResourceManager.GetObject(图标名称))).ToBitmap());
            else
                tsb.Image = (System.Drawing.Image)(((System.Drawing.Icon)(按钮图标.ResourceManager.GetObject("设置"))).ToBitmap());
            tsb.ImageTransparentColor = System.Drawing.Color.Magenta;

            string 快捷键 = "";
            switch (名称)
            {
                case "查询": 快捷键 = "(&Q)"; break;
                case "新增": 快捷键 = "(&A)"; break;
                case "编辑": 快捷键 = "(&E)"; break;
                case "删除": 快捷键 = "(&D)"; break;
                case "提交": 快捷键 = "(&S)"; break;
                case "打印": 快捷键 = "(&P)"; break;
                case "确认": 快捷键 = "(&C)"; break;
                case "保存": 快捷键 = "(&S)"; break;
                case "驳回": 快捷键 = "(&B)"; break;
                case "打开": 快捷键 = "(&O)"; break;
            }
            tsb.Text = 名称 + 快捷键;
            tsb.ToolTipText = 名称;
            tsb.Click += new EventHandler(tsb_Click);
            ts工具栏.Items.Add(tsb);
        }

        void tsb_Click(object sender, EventArgs e)
        {
            try
            {
                if ((sender as System.Windows.Forms.ToolStripButton).Text.ToString().Equals("关闭"))
                {
                    try
                    {
                        this.GetType().GetMethod((sender as System.Windows.Forms.ToolStripButton).ToolTipText).Invoke(this, null);
                    }
                    catch
                    {
                        this.Close();
                    }
                }
                else if (工作流 != null)
                {
                    this.GetType().GetMethod((sender as System.Windows.Forms.ToolStripButton).ToolTipText).Invoke(this, null);
                }
                else
                {
                    if ((sender as System.Windows.Forms.ToolStripButton).ToolTipText.ToString().Contains("删除"))
                    {
                        if (!消息.提示选择("是否确认删除?", MessageBoxIcon.Warning)) return;
                    }

                    this.GetType().GetMethod((sender as System.Windows.Forms.ToolStripButton).ToolTipText).Invoke(this, null);
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException is NullReferenceException) throw ex;
                else throw ex.InnerException;
            }
        }

        private void 初始化按钮()
        {
            try
            {
                if (查询标志 == false)
                {
                    if (工作流 == null)
                    {
                    SQL.脚本 = "Exec p获取用户按钮 " + SQL.引号(SQL.操作员ID) + "," + SQL.引号(菜单ID);

                    using (DataTable 按钮 = SQL.查询(SQL.DB.Report_DB, SQL.脚本, "文本日志").Tables[0])
                    {
                        if (按钮 != null && 按钮.Columns.Count > 0)
                        {
                            foreach (DataRow dr in 按钮.Rows)
                            {
                                this.AddToolButton(dr["名称"].ToString(), dr["图标"].ToString());
                            }
                        }
                    }
                    }
                    else
                    {
                        //this.AddToolButton("确认", "确认");
                        //this.AddToolButton("驳回", "驳回");
                    }
                }
                else
                {
                    SQL.设置控件只读(this);
                }

                this.AddToolButton("关闭", "关闭");
                if (ts工具栏.Items.Count > 0)
                {
                    ts工具栏.Visible = true;
                }
                else
                {
                    ts工具栏.Visible = false;
                }
            }
            catch
            { }
        }

        public void 设置记录数显示()
        {
            lbl记录数.Visible = true;
            this.lbl记录数.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            txt记录数.Visible = true;
            this.txt记录数.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        }
    }
}
