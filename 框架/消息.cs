using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 框架
{
    public static class 消息
    {
        private static 消息窗体 frmEdit = null;

        public static void 提示(string 提示信息)
        {
            MessageBox.Show(提示信息, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void 提示(string 提示信息, MessageBoxIcon boxIcon)
        {
            MessageBox.Show(提示信息, "系统提示", MessageBoxButtons.OK, boxIcon);
        }

        public static bool 选择(string 提示信息)
        {
            if (MessageBox.Show(提示信息, "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                return true;
            else
                return false;
        }

        public static bool 提示选择(string 提示信息, MessageBoxIcon boxIcon)
        {
            if (MessageBox.Show(提示信息, "系统提示", MessageBoxButtons.YesNo, boxIcon) == DialogResult.Yes)
                return true;
            else
                return false;
        }

        public static void 显示()
        {
            frmEdit = new 消息窗体();
            frmEdit.ShowDialog();
        }

        public static void 显示(string 提示信息)
        {
            frmEdit = new 消息窗体(提示信息);
            frmEdit.ShowDialog();
        }

        public static void 显示(Exception ex)
        {
            frmEdit = new 消息窗体(ex);
            frmEdit.ShowDialog();
        }

        public static void 显示(Exception ex, string message)
        {
            frmEdit = new 消息窗体(ex, message);
            frmEdit.ShowDialog();
        }

        public static void 显示(string 类型, string 提示信息, Exception ex)
        {
            frmEdit = new 消息窗体(类型, 提示信息, ex);
            frmEdit.ShowDialog();
        }
    }
}
