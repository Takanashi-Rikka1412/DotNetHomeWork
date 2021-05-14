using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace OrderForm
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
            txtOrderId.Text = originalOrder.OrderID;
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
                    int i = form.orderService.AddOrder(id, customer);
                    form.BindingRefresh(true);
                    form.IndexRefresh(i);
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
                    int i = form.orderService.ModifyOrder(originalOrder.OrderID, id, customer);
                    form.BindingRefresh(true);
                    form.IndexRefresh(i);
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
