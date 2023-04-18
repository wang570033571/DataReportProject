using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 系统
{
    public partial class 流程代理明细 : Form
    {
        private string 表名;
        private string 制单人;

        public 流程代理明细(string _表名, string _制单人)
        {
            InitializeComponent();

            表名 = _表名;
            制单人 = _制单人;

            this.Shown += new EventHandler(流程代理明细_Shown);
        }

        void 流程代理明细_Shown(object sender, EventArgs e)
        {
            gvData.Columns.Clear();

            // 默认格式设置
            gvData.IndicatorWidth = 50;
            gvData.OptionsBehavior.Editable = true;
            gvData.OptionsSelection.MultiSelect = true;
            gvData.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            gvData.OptionsView.RowAutoHeight = true;
            gvData.OptionsView.ColumnAutoWidth = false;
            gvData.OptionsView.ShowGroupPanel = false;
            gvData.OptionsView.ShowFooter = true;

            框架.SQL.查询(框架.SQL.DB.OA, "SELECT * FROM " + 表名 + " WITH(NOLOCK) WHERE 制单人 = " + 框架.SQL.引号(制单人), "查询表信息_流程代理", gvData);
        }
    }
}
