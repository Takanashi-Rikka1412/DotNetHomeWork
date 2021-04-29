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
    enum State { ADD, MODIFY };
    public partial class OrderFormDialog : Form
    {
        MainForm form;
        State state;
        Order originalOrder;

        public OrderFormDialog(MainForm form)
        {
            InitializeComponent();
            this.form = form;
            state = State.ADD;
        }
        public OrderFormDialog(MainForm form, string id)
        {
            InitializeComponent();
            this.form = form;
            state = State.MODIFY;
            Text = "修改订单";
            originalOrder = form.orderService.QueryOrderById(id).FirstOrDefault();
            txtOrderId.Text = originalOrder.Id;
            txtOrderCustomer.Text = originalOrder.Customer;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string id = txtOrderId.Text;
            string customer = txtOrderCustomer.Text;

            if (state == State.ADD)
            {
                try
                {
                    form.orderService.AddOrder(id, customer);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "错误", MessageBoxButtons.OKCancel);
                }
            }
            else
            {
                try
                {
                    form.orderService.ModifyOrder(originalOrder.Id, id, customer);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "错误", MessageBoxButtons.OKCancel);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
