using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace OrderForm
{
    public partial class MainForm : Form
    {
        public OrderService orderService;
        public List<Order> orders;
        public string[] queryTypes = { "全部订单", "按订单号", "按客户名", "按商品名", "总价大于" };
        public string sortType;
        public string SelectedQueryType { get; set; }
        public MainForm()
        {
            InitializeComponent();
            orderService = new OrderService();

            //bdsOrder.DataSource = orderService.orderList;
            orders = orderService.QueryAllOrder().ToList();


            bdsOrder.DataSource = orders;
            lstOrder.DataSource = bdsOrder;
            lstOrder.DisplayMember = "OrderID";
            lblOrderId.DataBindings.Add("Text", bdsOrder, "OrderID");
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


            cmbQueryType.DataSource = queryTypes;
            cmbQueryType.DataBindings.Add("SelectedItem", this, "SelectedQueryType");
            SelectedQueryType = queryTypes[0];
            sortType = queryTypes[0];
            txtQuery.Enabled = false;

            IndexRefresh();
        }
        //刷新绑定
        public void BindingRefresh(bool needSort)
        {
            orders = orderService.QueryAllOrder().ToList();
            if (sortType != queryTypes[0] && sortType != queryTypes[1] && needSort)
                Sort(sortType);
            bdsOrder.DataSource = orders;
            //bdsOrder.ResetBindings(false);
            bdsDetail.DataSource = (lstOrder.SelectedIndex >= 0) ?
                                    orders[lstOrder.SelectedIndex].Details
                                    : null;
            dgvDetail.DataSource = bdsDetail;
            //bdsDetail.ResetBindings(false);
            dgvDetail.ClearSelection();
        }
        //刷新lstOrder索引
        public void IndexRefresh(int index = -1)
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

            //BindingRefresh();
            //IndexRefresh();
        }
        //添加商品
        private void btnAddGoods_Click(object sender, EventArgs e)
        {
            DetailFormDialog dialog = new DetailFormDialog(this, ((Order)lstOrder.SelectedItem).OrderID);
            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            BindingRefresh(true);
        }

        //删除订单
        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            string id = ((Order)lstOrder.SelectedItem).OrderID;
            if (MessageBox.Show($"确定要删除订单号为：{id}的订单吗", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                orderService.DeleteOrder(id);
                BindingRefresh(false);
                IndexRefresh();
            }
        }
        //删除商品
        private void btnDeleteGoods_Click(object sender, EventArgs e)
        {
            string id = ((Order)lstOrder.SelectedItem).OrderID;
            string name = ((OrderDetails)dgvDetail.CurrentRow.DataBoundItem).Name;
            if (MessageBox.Show($"确定要删除商品名称为：{name}的商品吗", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                orderService.DeleteGoods(id, name);
                BindingRefresh(true);
            }
            //Programm.Show(orderService.orderList.ToArray());
        }
        //修改订单
        private void btnModifyOrder_Click(object sender, EventArgs e)
        {
            OrderFormDialog dialog = new OrderFormDialog(this, ((Order)lstOrder.SelectedItem).OrderID);
            if (dialog.ShowDialog() != DialogResult.OK)
                return;
            //BindingRefresh();
            //IndexRefresh();
        }
        //修改商品
        private void btnModifyGoods_Click(object sender, EventArgs e)
        {
            DetailFormDialog dialog = new DetailFormDialog(this, ((Order)lstOrder.SelectedItem).OrderID, ((OrderDetails)dgvDetail.CurrentRow.DataBoundItem).Name);
            if (dialog.ShowDialog() != DialogResult.OK)
                return;
            BindingRefresh(true);
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
            BindingRefresh(true);
        }

        //排序
        private void btnSort_Click(object sender, EventArgs e)
        {
            int index = lstOrder.SelectedIndex;
            sortType = SelectedQueryType;
            BindingRefresh(true);
            IndexRefresh(index);
        }
        public void Sort(string type)
        {
            switch (type)
            {
                case "全部订单": orders.Sort((o1, o2) => string.Compare(o1.OrderID, o2.OrderID)); break;
                case "按订单号": orders.Sort((o1, o2) => string.Compare(o1.OrderID, o2.OrderID)); break;
                case "按客户名": orders.Sort((o1, o2) => string.Compare(o1.Customer, o2.Customer)); break;
                case "按商品名":
                    orders.Where(o => o.OrderID == ((Order)lstOrder.SelectedItem).OrderID)
                        .SingleOrDefault().Details.Sort((d1, d2) => string.Compare(d1.Name, d2.Name));
                    break;
                case "总价大于": orders.Sort((o1, o2) => (int)(o2.TotalPrice - o1.TotalPrice)); break;
                default: break;
            }
        }

        //导入订单
        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Console.WriteLine(openFileDialog.FileName);
                Order[] order = orderService.Import(openFileDialog.FileName);
                //Programm.Show(order);
                using (var db = new OrderContext())
                {
                    foreach (var o in db.Orders.Include("Details"))
                    {
                        db.Orders.Remove(o);
                    }
                    foreach (var o in order)
                    {
                        db.Orders.Add(o);
                        foreach (var d in o.Details)
                            db.Details.Add(d);
                    }
                    db.SaveChanges();
                }
                BindingRefresh(true);
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
                bdsDetail.DataSource = orders[lstOrder.SelectedIndex].Details;
                dgvDetail.DataSource = bdsDetail;
                dgvDetail.ClearSelection();
                dgvDetail.Columns[0].Visible = false;
                dgvDetail.Columns[4].Visible = false;
                dgvDetail.Columns[5].Visible = false;

                if (dgvDetail.Columns.Count != 0 && dgvDetail.Columns[1].HeaderText != "商品名称")
                {
                    dgvDetail.Columns[1].HeaderText = "商品名称";
                    dgvDetail.Columns[2].HeaderText = "单价";
                    dgvDetail.Columns[3].HeaderText = "数量";
                }
                if (dgvDetail.RowCount == 0)
                {
                    btnDeleteGoods.Enabled = false;
                    btnModifyGoods.Enabled = false;
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
                    Order order = new Order { OrderID = ((Order)lstQuery.SelectedItem).OrderID, Customer = ((Order)lstQuery.SelectedItem).Customer };
                    int index = orders.IndexOf(order);
                    lstOrder.SelectedIndex = index;
                }
                else if (lstQuery.SelectedItem.GetType() == typeof(OrderService.Info))
                {
                    Order order = new Order
                    {
                        OrderID = ((OrderService.Info)lstQuery.SelectedItem).id,
                        Customer = ((OrderService.Info)lstQuery.SelectedItem).customer
                    };
                    int index = orders.IndexOf(order);
                    lstOrder.SelectedIndex = index;

                    OrderDetails detail = new OrderDetails
                    {
                        Name = ((OrderService.Info)lstQuery.SelectedItem).goodsName,
                        UnitPrice = ((OrderService.Info)lstQuery.SelectedItem).unitPrice,
                        Count = ((OrderService.Info)lstQuery.SelectedItem).count
                    };
                    int index1 = orders[index].Details.IndexOf(detail);
                    dgvDetail.Rows[index1].Selected = true;
                }
            }

        }

    }
}

