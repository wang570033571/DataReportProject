using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 框架
{
    public partial class 消息窗体 : Form
    {
        #region 构造函数
        public 消息窗体()
        {
            InitializeComponent();

            this.btn详细.Click += new EventHandler(btn详细_Click);
            this.btn确定.Click += new EventHandler(btn确定_Click);
            this.btn发送报告.Click += new EventHandler(btn发送报告_Click);
            this.Height = 200;
            this.btn确定.Focus();

            this.Cursor = Cursors.Default;
        }

        public 消息窗体(string ex):this()
		{
			ShowException(ex);
		}


        public 消息窗体(Exception ex): this()
		{
			ShowException(ex);
		}


        public 消息窗体(Exception ex, string message): this()
		{
			ShowException(ex,message);
		}


        public 消息窗体(System.Threading.ThreadExceptionEventArgs ex): this()
		{
			ShowException(ex);
		}


        public 消息窗体(System.Threading.ThreadExceptionEventArgs ex, string message): this()
		{
			ShowException(ex,message);
		}

        public 消息窗体(string 类型, string 提示信息, Exception ex) : this()
        {
            ShowException(类型, 提示信息, ex);
        }

        public 消息窗体(string caption, string messageDetail): this()
		{
			string message=messageDetail;;
			string detail=messageDetail;

			int index=messageDetail.IndexOf("##\n");
			if (index>1)
			{
				message=messageDetail.Substring(0,index);
			}
			else if (messageDetail.Length>2000)
			{

			}
			txt类型.Text=caption;
			txt信息.Text=message;
			txtMessageDetail.Text=detail.Replace("##\n","\n");
			tabPageProperty.Visible=false;
		}

        public 消息窗体(string caption, string message, string detail): this()
		{
			txt类型.Text=caption;
			txt信息.Text=message;
			txtMessageDetail.Text=detail;
			tabPageProperty.Visible=false;
		}
		#endregion

        #region ShowException

        private void ShowException(string Message)
        {
            txt类型.Text = Message;
            txt信息.Text = Message;
            txtMessageDetail.Text = Message;
        }

        private void ShowException(Exception ex)
        {
            txt类型.Text = ex.GetType().FullName;
            txt信息.Text = ex.Message;
            txtMessageDetail.Text = ex.ToString();
            propertyGrid.SelectedObject = ex;
        }

        private void ShowException(Exception ex, string message)
        {
            txt类型.Text = ex.GetType().FullName;
            txt信息.Text = message;
            txtMessageDetail.Text = ex.ToString();
            propertyGrid.SelectedObject = ex;
        }

        private void ShowException(System.Threading.ThreadExceptionEventArgs ex)
        {
            txt类型.Text = ex.GetType().FullName;
            txt信息.Text = ex.Exception.Message;
            txtMessageDetail.Text = ex.Exception.ToString();
            propertyGrid.SelectedObject = ex;
        }

        private void ShowException(System.Threading.ThreadExceptionEventArgs ex, string message)
        {
            txt类型.Text = ex.GetType().FullName;
            txt信息.Text = message;
            txtMessageDetail.Text = ex.Exception.ToString();
            propertyGrid.SelectedObject = ex;
        }

        private void ShowException(string 类型, string 提示信息, Exception ex)
        {
            txt类型.Text = 类型;
            txt信息.Text = 提示信息;
            if (ex != null)
            {
                txt信息.Text = ex.ToString();
                propertyGrid.SelectedObject = ex;
            }
            else
            {
                btn详细.Enabled = false;
            }
        }

        #endregion

        #region 按钮事件
        void btn确定_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void btn详细_Click(object sender, EventArgs e)
        {
            if (btn详细.Text.Equals("详细 >>"))
            {
                btn详细.Text = "详细 <<";
                this.Height = 400;
            }
            else
            {
                btn详细.Text = "详细 >>";
                this.Height = 200;
            }
            try
            {
                this.Top = (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2;
                this.Left = (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2;
            }
            catch
            {
            }
        }

        void btn发送报告_Click(object sender, EventArgs e)
        {
            MessageBox.Show("发送成功","提示");
            this.Close();
        }
        #endregion

        private void 消息提示_Load(object sender, EventArgs e)
        {
            btn确定.Focus();
        }

    }
}
