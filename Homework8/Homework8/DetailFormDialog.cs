using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NSOrder;

namespace Homework8
{
    public partial class DetailFormDialog : Form
    {
        MainForm form;
        string id;
        OrderDetails originalDetail;
        State state;

        public DetailFormDialog(MainForm form, string id)
        {
            InitializeComponent();
            this.form = form;
            this.id = id;
            state = State.ADD;
        }
        public DetailFormDialog(MainForm form, string id, string name)
        {
            InitializeComponent();
            this.form = form;
            this.id = id;
            state = State.MODIFY;
            Text = "修改商品";
            originalDetail = new OrderDetails();
            originalDetail.Name = form.orderService.QueryOrderByGoods(name).FirstOrDefault().goodsName;
            originalDetail.UnitPrice = form.orderService.QueryOrderByGoods(name).FirstOrDefault().unitPrice;
            originalDetail.Count = form.orderService.QueryOrderByGoods(name).FirstOrDefault().count;
            txtDetailName.Text = originalDetail.Name;
            txtDetailUnitPrice.Text = originalDetail.UnitPrice.ToString();
            txtDetailCount.Text = originalDetail.Count.ToString();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string name = txtDetailName.Text;
            float.TryParse(txtDetailUnitPrice.Text, out float unitPrice);
            int.TryParse(txtDetailCount.Text, out int count);

            if (state == State.ADD)
            {
                try
                {
                    form.orderService.AddGoods(id, name, unitPrice, count);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "错误", MessageBoxButtons.OK);
                    if (exc.Message == "单价与先前不同，已修改为原单价！")
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            else
            {
                try
                {
                    form.orderService.ModifyGoods(id, originalDetail.Name, name, unitPrice, count);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "错误", MessageBoxButtons.OK);
                    if (exc.Message == "单价与先前不同，已修改为原单价！")
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDetailUnitPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != '.' && e.KeyChar != (char)8)
                e.Handled = true;
            if (txtDetailUnitPrice.Text.Contains('.') && e.KeyChar == '.')
                e.Handled = true;
        }

        private void txtDetailCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
                e.Handled = true;
        }
    }
}
