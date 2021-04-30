using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Homework9;

namespace SimpleCrawlerForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SimpleCrawler.MessageAction += ShowMessage;
            SimpleCrawler.ButtonAction += EnableButton;
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
            txtMessage.Text += message;
        }
        private void EnableButton()
        {
            btnStart.Enabled = true;
        }
    }

}
