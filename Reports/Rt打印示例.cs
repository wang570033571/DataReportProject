using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Reports
{
    public partial class Rt打印示例 : 基本报表
    {
        public Rt打印示例()
        {
            InitializeComponent();
        }

        public override void 加载数据(System.Data.DataSet 数据集)
        {
            this.复制数据(数据集, this.ds示例1);
        }
    }
}
