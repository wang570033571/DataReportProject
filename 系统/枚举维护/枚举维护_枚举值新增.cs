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
    public partial class 枚举维护_枚举值新增 : 基本查询窗体
    {
        public string fID = "0";
        public string 枚举ID = "0";

        public 枚举维护_枚举值新增()
        {
            InitializeComponent();
            this.Load += new EventHandler(枚举维护_枚举值新增_Load);
        }

        void 枚举维护_枚举值新增_Load(object sender, EventArgs e)
        {
            初始化();
        }

        private void 初始化()
        {
            SQL.脚本 = "Select * from v枚举值 With (Nolock) Where fID=" + SQL.引号(fID);
            SQL.设置控件值(SQL.DB.Report_DB, panel1, SQL.脚本);
            //新增,设置默认值
            if (fID == "0")
            {
                cb状态.Checked = true;
                txtfID.Text = fID;
                txt枚举ID.Text = 枚举ID;
                txt键.Text = SQL.取值(SQL.DB.Report_DB, "Select Max(键)+1 from 枚举值 With (Nolock) Where 枚举ID=" + SQL.引号(枚举ID), "获取枚举值键");
                if (txt键.Text == "") txt键.Text = "1";
            }
        }

        public void 保存()
        {
            string 状态 = "0"; if (cb状态.Checked) 状态 = "1";
            SQL.脚本 = "Exec p枚举值保存 " + SQL.引号(txtfID.Text) + ","
                                         + SQL.引号(txt枚举ID.Text) + ","
                                         + SQL.引号(txt键.Text) + ","
                                         + SQL.引号(txt值.Text) + ","
                                         + SQL.引号(SQL.操作员) + ","
                                         + SQL.引号(状态) + ","
                                         + SQL.引号(txt自定义1.Text) + ","
                                         + SQL.引号(txt自定义2.Text) + ","
                                         + SQL.引号(txt自定义3.Text) + ","
                                         + SQL.引号(txt自定义4.Text) + ","
                                         + SQL.引号(txt自定义5.Text);
            SQL.结果 = SQL.执行(SQL.DB.Report_DB, SQL.脚本, "枚举值保存");
            if (SQL.结果 == "成功")
            {
                //新增数据,询问是否继续添加,编辑数据则直接关闭
                if (fID == "0")
                {
                    if (消息.提示选择("操作成功,是否继续添加！", MessageBoxIcon.Question))
                    {
                        txt键.Text = SQL.取值(SQL.DB.Report_DB, "Select Max(键)+1 from 枚举值 With (Nolock) Where 枚举ID=" + SQL.引号(枚举ID), "获取枚举值键");
                        if (txt键.Text == "") txt键.Text = "1";
                        txt值.Text = "";
                        txt自定义1.Text = "";
                        txt自定义2.Text = "";
                        txt自定义3.Text = "";
                        txt自定义4.Text = "";
                        txt自定义5.Text = "";
                    }
                    else
                    {
                        Close();
                    }
                }
                else
                {
                    Close();
                }
            }
            else
            {
                消息.提示("操作" + SQL.结果);
            }
        }

        private void txt值_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) { 保存(); }
        }
    }
}
