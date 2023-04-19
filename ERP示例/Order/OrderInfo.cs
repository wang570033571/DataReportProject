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
    /// <summary>
    /// 数据库登录名.
    /// 数据库登录账号密码:sa/sa
    /// 系统管理员账号密码:wanghb/dabin121
    /// 1.添加windows窗体
    /// 2.窗体类继承 基本查询窗体
    /// 3.添加查询控件和Gridview控件
    /// 4.创建数据库表
    /// 5.创建表对应视图
    /// 6.设置Gridview.Tag视图名称
    /// 7.设置Panel.Tag视图名称
    /// 8.设置查询控件如TextBox的Tag(模糊查询：字段名 Like '%@值%' 或者 字段名 Like '@值%'; 精确查询：字段名 = '@值')
    /// 9.添加查询方法
    /// 10.添加菜单
    /// </summary>
    public partial class OrderInfo : 基本查询窗体
    {
        public OrderInfo()
        {
            InitializeComponent();
            gv1.Tag = "v_OrderInfo";
            panel1.Tag= "v_OrderInfo";
        }

        public void 查询()
        {
            SQL.脚本 = SQL.获取查询脚本(panel1, intCount.ToString());
            SQL.查询(SQL.DB.Report_DB, SQL.脚本, "查询订单信息", gv1);
        }

        public void 计算()
        {

        }

        public void 导入()
        {

        }

        public void 导出()
        {

        }
    }
}
