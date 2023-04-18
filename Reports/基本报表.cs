using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Data;
using System.Text;

namespace Reports
{
    public partial class 基本报表 : DevExpress.XtraReports.UI.XtraReport 
    {
        public 基本报表()
        {
            InitializeComponent();
        }

        public 基本报表(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public virtual void 加载数据(DataSet 数据集)
        {
            //代码实现部分
        }

        public void 复制数据(DataSet 源数据集, DataSet 目标数据集)
        {
            目标数据集.Clear();
            DataRow drNew = null;
            foreach (DataTable dtSource in 源数据集.Tables)
            {
                try
                {
                    if (!目标数据集.Tables.Contains(dtSource.TableName)) continue;

                    int indexRow = 1;
                    foreach (DataRow dr in dtSource.Rows)
                    {
                        drNew = 目标数据集.Tables[dtSource.TableName].NewRow();
                        foreach (DataColumn dc in dtSource.Columns)
                        {
                            if (drNew.Table.Columns.Contains(dc.ColumnName) && dr[dc.ColumnName] != null)
                            {
                                try
                                {
                                    drNew[dc.ColumnName] = dr[dc.ColumnName];
                                }
                                catch
                                { }
                            }
                        }

                        if (drNew.Table.Columns.Contains("序号"))
                            drNew["序号"] = indexRow.ToString();

                        indexRow++;

                        目标数据集.Tables[dtSource.TableName].Rows.Add(drNew);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
