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
    public partial class 基本操作窗体_示例 : 基本操作窗体
    {
        public 基本操作窗体_示例()
        {
            InitializeComponent();
            //查询必备条件设置
            panel查询.Tag = "v视图";

            //Gridview视图导入必备设置
            gridView.Tag = "v视图";

            //三种Tag值设置
            //cmb日期.Tag = "制单日期 between @值";
            //txt标题.Tag = "标题 Like \'%@值%\'";
            //txt开发人.Tag = "开发人 = @值";

            //设置panel扩展可见,则可使用左边panel(默认不可见)
            panel扩展.Visible = true;

            //groupBox扩展设置可见,则可使用gridview控件下面的扩展区域(默认不可见)
            groupBox扩展.Visible = true;

            //splitter拓展设置可见,则可此扩展范围内添加其他内容(默认不可见)
            splitter拓展.Visible = true;
            
            this.Load += new EventHandler(基本操作窗体_示例_Load);
        }

        //日期下拉框设置
        //private void cmb日期_DropDown(object sender, EventArgs e)
        //{
        //    SQL.加载下拉框(SQL.DB.Report_DB, cmb日期, "Select 名称 from v日期周期 With (Nolock) Where ISNULL(备注,'') = '' Order By fID", false);
        //}

        void 基本操作窗体_示例_Load(object sender, EventArgs e)
        {
            //调用此方法会显示记录数(默认不显示)
            设置记录数显示();

            //调用此方法不显示基本信息page页面(默认显示)
            不显示基本信息();
        }

        public void 查询()
        {
            //如果调用:设置记录数显示();则使用带记录数的获取查询脚本方法
            //SQL.脚本 = SQL.获取查询脚本(panel查询,txt记录数.Text);


            //如果未调用设置记录数显示()使用如下方法
            //SQL.脚本 = SQL.获取查询脚本(panel查询);

            //数据绑定gridview的方法
            SQL.查询(SQL.DB.Report_DB, SQL.脚本, "日志描述", gridView);
        }


        /// <summary>
        /// 新增方法
        /// </summary>
        public void 新增()
        {
            using (示例_编辑 frm编辑 = new 示例_编辑())
            {
                if (frm编辑.ShowDialog() == DialogResult.Yes) 查询();
            }
        }
        
        /// <summary>
        /// 编辑方法
        /// </summary>
        public void 编辑()
        {
            if (gridView.RowCount == 0) return;
            if (gridView.GetSelectedRows().Length<1) return;
            using (示例_编辑 frm编辑 = new 示例_编辑())
            {
                frm编辑.fID = gridView.GetFocusedDataRow()["fID"].ToString();
                if (frm编辑.ShowDialog() == DialogResult.Yes) 查询();
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        public void 删除()
        {
            if (gridView.RowCount == 0) return;
            if (gridView.GetSelectedRows().Length < 1)
            SQL.脚本 = "Exec p删除 " + SQL.引号(gridView.GetFocusedDataRow()["fID"].ToString()) + ","
                                     + SQL.引号(SQL.操作员);
            SQL.结果 = SQL.执行(SQL.DB.Report_DB, SQL.脚本, "描述");
            消息.提示("操作" + SQL.结果);
            if (SQL.结果 == "成功") 查询();
        }

        //发起工作流
        public void 提交()
        {
            string 单号 = SQL.取值(SQL.DB.Report_DB, "Exec p获取单号 '类型说明'", "文本日志");//类型说明:是 单号表中的类型字段值
            bool blTrue = SQL.发起审批流程("流程ID", "流程内容", "单号");
            if (blTrue)
            {
                消息.提示("提示信息");
            }
        }
        
        //重写此方法实现gridview的click事件
        public override void 刷新其他明细()
        {
            //方法体代码
            //如:SQL.查询(SQL.DB.Report_DB, SQL.脚本, "日志描述", gv其他);
        }

        public void 打印()
        { 
            SQL.脚本 = "Select * From v示例 With (Nolock) ";
            DataSet ds = SQL.查询(SQL.DB.OA, SQL.脚本, "示例打印");
            ds.Tables[0].TableName = "v示例";
            SQL.打印(ds, "Reports.Rt打印示例");
        }
    }
}
