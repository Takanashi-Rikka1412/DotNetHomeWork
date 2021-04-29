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
    public partial class MainForm : Form
    {
        public OrderService orderService;
        public string[] queryType = { "全部订单", "按订单号", "按客户名", "按商品名", "总价大于" };
        public string SelectedQueryType { get; set; }
        public MainForm()
        {
            InitializeComponent();
            orderService = new OrderService();

            bdsOrder.DataSource = orderService.orderList;
            lstOrder.DataSource = bdsOrder;
            lstOrder.DisplayMember = "Id";
            lblOrderId.DataBindings.Add("Text", bdsOrder, "Id");
            lblOrderCustomer.DataBindings.Add("Text", bdsOrder, "Customer");
            lblOrderTotalPrice.DataBindings.Add("Text", bdsOrder, "TotalPrice");

            btnAddGoods.Enabled = false;
            btnDeleteOrder.Enabled = false;
            btnDeleteGoods.Enabled = false;
            btnModifyOrder.Enabled = false;
            btnModifyGoods.Enabled = false;
            btnQuery.Enabled = false;
            btnSort.Enabled = false;

            dgvDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            cmbQueryType.DataSource = queryType;
            cmbQueryType.DataBindings.Add("SelectedItem", this, "SelectedQueryType");
            SelectedQueryType = queryType[0];
            txtQuery.Enabled = false;
        }
        //刷新绑定
        protected void BindingRefresh()
        {
            bdsOrder.ResetBindings(false);
            bdsDetail.ResetBindings(false);
            dgvDetail.ClearSelection();
        }
        //刷新lstOrder索引
        protected void IndexRefresh(int index = -1)
        {
            lstOrder.SelectedIndex = -1;
            lstOrder.SelectedIndex = (index == -1) ? lstOrder.Items.Count - 1 : index;
        }


        //创建订单
        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            OrderFormDialog dialog = new OrderFormDialog(this);

            if (dialog.ShowDialog() != DialogResult.OK)
                return;
            //Console.WriteLine("!!!" + orderService.orderList[c++].Id);

            BindingRefresh();
            IndexRefresh();
        }
        //添加商品
        private void btnAddGoods_Click(object sender, EventArgs e)
        {
            DetailFormDialog dialog = new DetailFormDialog(this, ((Order)lstOrder.SelectedItem).Id);
            if (dialog.ShowDialog() != DialogResult.OK)
                return;
            //Console.WriteLine("!!!" + orderService.orderList[c++].Id);
            BindingRefresh();
        }
        //删除订单
        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            string id = ((Order)lstOrder.SelectedItem).Id;
            if (MessageBox.Show($"确定要删除订单号为：{id}的订单吗", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                orderService.DeleteOrder(id);
                BindingRefresh();
                IndexRefresh();

                if (lstOrder.Items.Count <= 0)
                {
                    //Console.WriteLine("00000");
                    bdsDetail.DataSource = null;
                    dgvDetail.DataSource = bdsDetail;
                }
            }
        }
        //删除商品
        private void btnDeleteGoods_Click(object sender, EventArgs e)
        {
            string id = ((Order)lstOrder.SelectedItem).Id;
            string name = ((OrderDetails)dgvDetail.CurrentRow.DataBoundItem).Name;
            if (MessageBox.Show($"确定要删除商品名称为：{name}的商品吗", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                orderService.DeleteGoods(id, name);
                BindingRefresh();
            }
            //Programm.Show(orderService.orderList.ToArray());
        }
        //修改订单
        private void btnModifyOrder_Click(object sender, EventArgs e)
        {
            OrderFormDialog dialog = new OrderFormDialog(this, ((Order)lstOrder.SelectedItem).Id);
            if (dialog.ShowDialog() != DialogResult.OK)
                return;
            BindingRefresh();
        }
        //修改商品
        private void btnModifyGoods_Click(object sender, EventArgs e)
        {
            DetailFormDialog dialog = new DetailFormDialog(this, ((Order)lstOrder.SelectedItem).Id, ((OrderDetails)dgvDetail.CurrentRow.DataBoundItem).Name);
            if (dialog.ShowDialog() != DialogResult.OK)
                return;
            BindingRefresh();
        }
        //查询
        private void btnQuery_Click(object sender, EventArgs e)
        {
            //Console.WriteLine(SelectedQueryType);

            Order[] results = null;
            OrderService.Info[] info = null;
            splQuery.Panel2Collapsed = false;

            try
            {
                switch (SelectedQueryType)
                {
                    case "全部订单":
                        splQuery.Panel2Collapsed = true;
                        break;
                    case "按订单号": results = orderService.QueryOrderById(txtQuery.Text); break;
                    case "按客户名": results = orderService.QueryOrderByCustomer(txtQuery.Text); break;
                    case "按商品名": info = orderService.QueryOrderByGoods(txtQuery.Text); break;
                    case "总价大于":
                        float.TryParse(txtQuery.Text, out float price);
                        results = orderService.QueryOrderByTotalPrice(price);
                        break;
                    default: break;
                }
                lstQuery.Items.Clear();
                if (results != null)
                    foreach (var result in results)
                        lstQuery.Items.Add(result);
                if (info != null)
                    foreach (var i in info)
                        lstQuery.Items.Add(i);
            }
            catch (Exception exc)
            {
                splQuery.Panel2Collapsed = false;
                lstQuery.Items.Clear();
                lstQuery.Items.Add(exc.Message);
            }
            int height = splQuery.Height - (lstQuery.Items.Count + 2) * lstQuery.ItemHeight;
            splQuery.SplitterDistance = (height > 0) ? height : 0;
            BindingRefresh();
        }
        //排序
        private void btnSort_Click(object sender, EventArgs e)
        {
            switch (SelectedQueryType)
            {
                case "全部订单": orderService.Sort(); break;
                case "按订单号": orderService.Sort((o1, o2) => string.Compare(o1.Id, o2.Id)); break;
                case "按客户名": orderService.Sort((o1, o2) => string.Compare(o1.Customer, o2.Customer)); break;
                case "按商品名": orderService.Sort(((Order)lstOrder.SelectedItem).Id, (d1, d2) => string.Compare(d1.Name, d2.Name)); break;
                case "总价大于": orderService.Sort((o1, o2) => (int)(o2.TotalPrice - o1.TotalPrice)); break;
                default: break;
            }
            BindingRefresh();
            IndexRefresh(0);
        }
        //导入订单
        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog()==DialogResult.OK)
            {
                //Console.WriteLine(openFileDialog.FileName);
                Order[] order = orderService.Import(openFileDialog.FileName);
                //Programm.Show(order);
                orderService.orderList = order.ToList();
                bdsOrder.DataSource = orderService.orderList;
                BindingRefresh();
                IndexRefresh(0);
            }
        }
        //导出订单
        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML文件(*.xml)|*.xml";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                orderService.Export(saveFileDialog.FileName);
            }
        }



        private void lstOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstOrder.SelectedIndex >= 0 && lstOrder.SelectedIndex < lstOrder.Items.Count)
            {
                btnAddGoods.Enabled = true;
                btnDeleteOrder.Enabled = true;
                btnModifyOrder.Enabled = true;
                btnQuery.Enabled = true;
                btnSort.Enabled = true;
                bdsDetail.DataSource = orderService.orderList[lstOrder.SelectedIndex].detailList;
                dgvDetail.DataSource = bdsDetail;
                dgvDetail.ClearSelection();
                if (dgvDetail.Columns[0].HeaderText != "商品名称")
                {
                    dgvDetail.Columns[0].HeaderText = "商品名称";
                    dgvDetail.Columns[1].HeaderText = "单价";
                    dgvDetail.Columns[2].HeaderText = "数量";
                }
            }
            else
            {
                btnAddGoods.Enabled = false;
                btnDeleteOrder.Enabled = false;
                btnModifyOrder.Enabled = false;
                btnQuery.Enabled = false;
                btnSort.Enabled = false;
            }
        }

        private void dgvDetail_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDetail.RowCount > 0)
            {
                btnDeleteGoods.Enabled = true;
                btnModifyGoods.Enabled = true;
            }
            else
            {
                btnDeleteGoods.Enabled = false;
                btnModifyGoods.Enabled = false;
            }

        }
        private void dgvDetail_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgvDetail.RowHeadersDefaultCellStyle.Padding = new Padding(dgvDetail.RowHeadersWidth);
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, dgvDetail.RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), dgvDetail.RowHeadersDefaultCellStyle.Font, rectangle,
                dgvDetail.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
        }
        private void cmbQueryType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbQueryType.Text == "全部订单")
            {
                txtQuery.Text = "";
                txtQuery.Enabled = false;
                return;
            }
            if (cmbQueryType.Text == "总价大于")
                txtQuery.Text = "";

            txtQuery.Enabled = true;
        }

        private void txtQuery_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (SelectedQueryType != "总价大于")
                return;

            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != '.' && e.KeyChar != (char)8)
                e.Handled = true;
            if (txtQuery.Text.Contains('.') && e.KeyChar == '.')
                e.Handled = true;
        }

        private void lstQuery_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstQuery.SelectedIndex >= 0 && lstQuery.SelectedIndex < lstQuery.Items.Count)
            {

                if (lstQuery.SelectedItem.GetType() == typeof(Order))
                {
                    Order order = new Order(((Order)lstQuery.SelectedItem).Id, ((Order)lstQuery.SelectedItem).Customer);
                    int index = orderService.orderList.IndexOf(order);
                    lstOrder.SelectedIndex = index;
                }
                else if (lstQuery.SelectedItem.GetType() == typeof(OrderService.Info))
                {
                    Order order = new Order(((OrderService.Info)lstQuery.SelectedItem).id,
                        ((OrderService.Info)lstQuery.SelectedItem).customer);
                    int index = orderService.orderList.IndexOf(order);
                    lstOrder.SelectedIndex = index;

                    OrderDetails detail = new OrderDetails(((OrderService.Info)lstQuery.SelectedItem).goodsName,
                        ((OrderService.Info)lstQuery.SelectedItem).unitPrice,
                        ((OrderService.Info)lstQuery.SelectedItem).count);
                    int index1 = orderService.orderList[index].detailList.IndexOf(detail);
                    dgvDetail.Rows[index1].Selected = true;
                }
            }
        }

    }
}

