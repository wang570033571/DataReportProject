using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 框架;

namespace ERP示例
{
    public partial class 示例_编辑 : 基本查询窗体
    {
        /// <summary>
        /// fID申明
        /// </summary>
        public string fID = "0";

        public 示例_编辑()
        {
            InitializeComponent();
            this.Load += new EventHandler(示例_编辑_Load);
        }

        void 示例_编辑_Load(object sender, EventArgs e)
        {
            //1.设置控件Tag值;(Tag值需和视图列对应)
            //2.通过设置控件值方法自动绑定数据
            //SQL.脚本 = "Select * from v示例 With (Nolock) Where fID=" + SQL.引号(fID);
            //SQL.设置控件值(SQL.DB.Report_DB, panel1, SQL.脚本);
        }

        //下拉框数据加载事件
        //private void cmb类型_DropDown(object sender, EventArgs e)
        //{
        //    SQL.加载下拉框(SQL.DB.Report_DB, cmb类型, "Select '功能新增' 名称 union Select 'Bug修改' 名称", false);
        //}

        public void 保存()
        {
            SQL.脚本 = "Exec p存储过程 "
                        + SQL.引号(fID) + ","
                        + SQL.引号(SQL.操作员);
            SQL.结果 = SQL.执行(SQL.DB.Report_DB, SQL.脚本, "日志描述");
            if (SQL.结果 == "成功")
            {
                消息.提示("操作" + SQL.结果);
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
        }
    }
}
