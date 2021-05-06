using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Homework10;

namespace SimpleCrawlerForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SimpleCrawler.MessageAction += ShowMessage;
            SimpleCrawler.ButtonAction += EnableButton;
            txtUrl.Text = "http://www.mooc.whu.edu.cn";
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (txtUrl.Text == "")
                return;
            txtMessage.Clear();
            btnStart.Enabled = false;
            SimpleCrawler.StartCrawl(txtUrl.Text);
        }

        private void ShowMessage(string message)
        {
            if (txtMessage.InvokeRequired)
            {
                Action<string> action = ShowMessageAction;
                this.Invoke(action, new object[] { message });
            }
            else
                ShowMessageAction(message);
            
        }
        private void ShowMessageAction(string message)
        {
            txtMessage.Text += message;
        }
        private void EnableButton()
        {
            if (btnStart.InvokeRequired)
            {
                Action action = EnableButtonAction;
                this.Invoke(action);
            }
            else
                EnableButtonAction();
        }
        private void EnableButtonAction()
        {
            btnStart.Enabled = true;
        }

        private void txtMessage_TextChanged(object sender, EventArgs e)
        {
            txtMessage.Select(txtMessage.TextLength, 0);
            txtMessage.ScrollToCaret();
        }
    }

}
