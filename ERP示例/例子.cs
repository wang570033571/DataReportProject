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
    public partial class 例子 : 基本操作窗体
    {
        public 例子()
        {
            InitializeComponent();
            gridView.Tag = "v例子视图";
            panel查询.Tag = "v例子视图";
            this.Load += new EventHandler(例子_Load);
        }

        void 例子_Load(object sender, EventArgs e)
        {
            设置记录数显示();
        }
    }
}
