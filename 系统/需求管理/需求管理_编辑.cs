using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 框架;

namespace 系统
{
    public partial class 需求管理_编辑 : 基本查询窗体
    {
        public string fID = "0";
        RichTextBox 需求描述 = new RichTextBox();

        public 需求管理_编辑()
        {
            InitializeComponent();
            this.Load += new EventHandler(需求管理_编辑_Load);
        }

        void 需求管理_编辑_Load(object sender, EventArgs e)
        {
            if (工作流 != null)
            {
                fID = 工作流["单号"].ToString();
                SQL.设置控件只读(this);
            }
            SQL.脚本 = "Select * from v需求管理 With (Nolock) Where fID=" + SQL.引号(fID);
            SQL.设置控件值(SQL.DB.Report_DB, panel1, SQL.脚本);

            需求描述.Rtf = txt内容.Text.Replace("‘", "'");
            txt内容.Text = 需求描述.Text;
        }

        public void 保存()
        {
            需求描述.Text = txt内容.Text;

            SQL.脚本 = "Exec p需求保存 "
                        + SQL.引号(fID) + ","
                        + SQL.引号(cmb类型.Text) + ","
                        + SQL.引号(txt标题.Text) + ","
                        + SQL.引号(需求描述.Rtf.ToString().Replace("'", "‘")) + ","
                        + SQL.引号(txt内容.Text) + ","
                        + SQL.引号(cmb级别.Text) + ","
                        + SQL.引号(dt完成日期.Text) + ","
                        + SQL.引号(txt开发人.Text) + ","
                        + SQL.引号(SQL.操作员);
            SQL.结果 = SQL.执行(SQL.DB.Report_DB, SQL.脚本, "需求保存");
            if (SQL.结果 == "成功")
            {
                消息.提示("操作" + SQL.结果);
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
        }

        private void cmb类型_DropDown(object sender, EventArgs e)
        {
            SQL.加载下拉框(SQL.DB.Report_DB, cmb类型, "Select '功能新增' 名称 union Select 'Bug修改' 名称", false);
        }

        private void cmb级别_DropDown(object sender, EventArgs e)
        {
            SQL.加载下拉框(SQL.DB.Report_DB, cmb级别, "Select '一般' 名称 union Select '紧急' 名称", false);
        }

        private void btn选择_Click(object sender, EventArgs e)
        {
            DataTable dt= SQL.选择数据集(SQL.DB.Report_DB, "v用户", "名称", "名称", "部门='IT'", false);
            if (dt.Rows.Count > 0)
            {
                string 开发人 = "";
                for (int i = 0; i < dt.Rows.Count;i++ )
                {
                    开发人 += dt.Rows[i]["名称"].ToString() + ",";
                }
                txt开发人.Text = 开发人.Remove(开发人.LastIndexOf(","), 1);
            }
        }
    }
}
