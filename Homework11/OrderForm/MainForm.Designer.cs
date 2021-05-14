namespace OrderForm
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnModifyGoods = new System.Windows.Forms.Button();
            this.btnModifyOrder = new System.Windows.Forms.Button();
            this.btnDeleteGoods = new System.Windows.Forms.Button();
            this.btnDeleteOrder = new System.Windows.Forms.Button();
            this.btnAddGoods = new System.Windows.Forms.Button();
            this.btnAddOrder = new System.Windows.Forms.Button();
            this.splData = new System.Windows.Forms.SplitContainer();
            this.lstOrder = new System.Windows.Forms.ListBox();
            this.lblOrderTitle = new System.Windows.Forms.Label();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.tlpOrderInfo = new System.Windows.Forms.TableLayoutPanel();
            this.lblOrderIdTitle = new System.Windows.Forms.Label();
            this.lblOrderId = new System.Windows.Forms.Label();
            this.lblOrderCustomerTitle = new System.Windows.Forms.Label();
            this.lblOrderCustomer = new System.Windows.Forms.Label();
            this.lblOrderTotalPriceTitle = new System.Windows.Forms.Label();
            this.lblOrderTotalPrice = new System.Windows.Forms.Label();
            this.lblDetailTitle = new System.Windows.Forms.Label();
            this.bdsOrder = new System.Windows.Forms.BindingSource(this.components);
            this.bdsDetail = new System.Windows.Forms.BindingSource(this.components);
            this.flpOperation = new System.Windows.Forms.FlowLayoutPanel();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.lstQuery = new System.Windows.Forms.ListBox();
            this.splQuery = new System.Windows.Forms.SplitContainer();
            this.flpQuery = new System.Windows.Forms.FlowLayoutPanel();
            this.cmbQueryType = new System.Windows.Forms.ComboBox();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.btnSort = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splData)).BeginInit();
            this.splData.Panel1.SuspendLayout();
            this.splData.Panel2.SuspendLayout();
            this.splData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.tlpOrderInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDetail)).BeginInit();
            this.flpOperation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splQuery)).BeginInit();
            this.splQuery.Panel1.SuspendLayout();
            this.splQuery.Panel2.SuspendLayout();
            this.splQuery.SuspendLayout();
            this.flpQuery.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnModifyGoods
            // 
            this.btnModifyGoods.Font = new System.Drawing.Font("宋体", 12F);
            this.btnModifyGoods.Location = new System.Drawing.Point(653, 23);
            this.btnModifyGoods.Name = "btnModifyGoods";
            this.btnModifyGoods.Size = new System.Drawing.Size(120, 40);
            this.btnModifyGoods.TabIndex = 0;
            this.btnModifyGoods.Text = "修改商品";
            this.btnModifyGoods.UseVisualStyleBackColor = true;
            this.btnModifyGoods.Click += new System.EventHandler(this.btnModifyGoods_Click);
            // 
            // btnModifyOrder
            // 
            this.btnModifyOrder.Font = new System.Drawing.Font("宋体", 12F);
            this.btnModifyOrder.Location = new System.Drawing.Point(527, 23);
            this.btnModifyOrder.Name = "btnModifyOrder";
            this.btnModifyOrder.Size = new System.Drawing.Size(120, 40);
            this.btnModifyOrder.TabIndex = 0;
            this.btnModifyOrder.Text = "修改订单";
            this.btnModifyOrder.UseVisualStyleBackColor = true;
            this.btnModifyOrder.Click += new System.EventHandler(this.btnModifyOrder_Click);
            // 
            // btnDeleteGoods
            // 
            this.btnDeleteGoods.Font = new System.Drawing.Font("宋体", 12F);
            this.btnDeleteGoods.Location = new System.Drawing.Point(401, 23);
            this.btnDeleteGoods.Name = "btnDeleteGoods";
            this.btnDeleteGoods.Size = new System.Drawing.Size(120, 40);
            this.btnDeleteGoods.TabIndex = 0;
            this.btnDeleteGoods.Text = "删除商品";
            this.btnDeleteGoods.UseVisualStyleBackColor = true;
            this.btnDeleteGoods.Click += new System.EventHandler(this.btnDeleteGoods_Click);
            // 
            // btnDeleteOrder
            // 
            this.btnDeleteOrder.Font = new System.Drawing.Font("宋体", 12F);
            this.btnDeleteOrder.Location = new System.Drawing.Point(149, 23);
            this.btnDeleteOrder.Name = "btnDeleteOrder";
            this.btnDeleteOrder.Size = new System.Drawing.Size(120, 40);
            this.btnDeleteOrder.TabIndex = 0;
            this.btnDeleteOrder.Text = "删除订单";
            this.btnDeleteOrder.UseVisualStyleBackColor = true;
            this.btnDeleteOrder.Click += new System.EventHandler(this.btnDeleteOrder_Click);
            // 
            // btnAddGoods
            // 
            this.btnAddGoods.Font = new System.Drawing.Font("宋体", 12F);
            this.btnAddGoods.Location = new System.Drawing.Point(275, 23);
            this.btnAddGoods.Name = "btnAddGoods";
            this.btnAddGoods.Size = new System.Drawing.Size(120, 40);
            this.btnAddGoods.TabIndex = 0;
            this.btnAddGoods.Text = "添加商品";
            this.btnAddGoods.UseVisualStyleBackColor = true;
            this.btnAddGoods.Click += new System.EventHandler(this.btnAddGoods_Click);
            // 
            // btnAddOrder
            // 
            this.btnAddOrder.Font = new System.Drawing.Font("宋体", 12F);
            this.btnAddOrder.Location = new System.Drawing.Point(23, 23);
            this.btnAddOrder.Name = "btnAddOrder";
            this.btnAddOrder.Size = new System.Drawing.Size(120, 40);
            this.btnAddOrder.TabIndex = 0;
            this.btnAddOrder.Text = "创建订单";
            this.btnAddOrder.UseVisualStyleBackColor = true;
            this.btnAddOrder.Click += new System.EventHandler(this.btnAddOrder_Click);
            // 
            // splData
            // 
            this.splData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splData.Location = new System.Drawing.Point(0, 0);
            this.splData.Name = "splData";
            // 
            // splData.Panel1
            // 
            this.splData.Panel1.Controls.Add(this.lstOrder);
            this.splData.Panel1.Controls.Add(this.lblOrderTitle);
            this.splData.Panel1.Padding = new System.Windows.Forms.Padding(5, 5, 0, 5);
            this.splData.Panel1MinSize = 100;
            // 
            // splData.Panel2
            // 
            this.splData.Panel2.Controls.Add(this.dgvDetail);
            this.splData.Panel2.Controls.Add(this.tlpOrderInfo);
            this.splData.Panel2.Controls.Add(this.lblDetailTitle);
            this.splData.Panel2.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.splData.Panel2MinSize = 420;
            this.splData.Size = new System.Drawing.Size(1048, 407);
            this.splData.SplitterDistance = 184;
            this.splData.TabIndex = 1;
            // 
            // lstOrder
            // 
            this.lstOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstOrder.Font = new System.Drawing.Font("宋体", 12F);
            this.lstOrder.FormattingEnabled = true;
            this.lstOrder.HorizontalScrollbar = true;
            this.lstOrder.IntegralHeight = false;
            this.lstOrder.ItemHeight = 24;
            this.lstOrder.Location = new System.Drawing.Point(5, 38);
            this.lstOrder.Name = "lstOrder";
            this.lstOrder.Size = new System.Drawing.Size(175, 360);
            this.lstOrder.TabIndex = 2;
            this.lstOrder.SelectedIndexChanged += new System.EventHandler(this.lstOrder_SelectedIndexChanged);
            // 
            // lblOrderTitle
            // 
            this.lblOrderTitle.BackColor = System.Drawing.SystemColors.Info;
            this.lblOrderTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblOrderTitle.Font = new System.Drawing.Font("宋体", 12F);
            this.lblOrderTitle.Location = new System.Drawing.Point(5, 5);
            this.lblOrderTitle.Name = "lblOrderTitle";
            this.lblOrderTitle.Size = new System.Drawing.Size(175, 33);
            this.lblOrderTitle.TabIndex = 1;
            this.lblOrderTitle.Text = "订单号";
            this.lblOrderTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AllowUserToDeleteRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetail.Location = new System.Drawing.Point(0, 83);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.ReadOnly = true;
            this.dgvDetail.RowTemplate.Height = 30;
            this.dgvDetail.Size = new System.Drawing.Size(851, 315);
            this.dgvDetail.TabIndex = 2;
            this.dgvDetail.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDetail_RowPostPaint);
            this.dgvDetail.SelectionChanged += new System.EventHandler(this.dgvDetail_SelectionChanged);
            // 
            // tlpOrderInfo
            // 
            this.tlpOrderInfo.ColumnCount = 6;
            this.tlpOrderInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpOrderInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpOrderInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpOrderInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpOrderInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpOrderInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpOrderInfo.Controls.Add(this.lblOrderIdTitle, 0, 0);
            this.tlpOrderInfo.Controls.Add(this.lblOrderId, 1, 0);
            this.tlpOrderInfo.Controls.Add(this.lblOrderCustomerTitle, 2, 0);
            this.tlpOrderInfo.Controls.Add(this.lblOrderCustomer, 3, 0);
            this.tlpOrderInfo.Controls.Add(this.lblOrderTotalPriceTitle, 4, 0);
            this.tlpOrderInfo.Controls.Add(this.lblOrderTotalPrice, 5, 0);
            this.tlpOrderInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpOrderInfo.Location = new System.Drawing.Point(0, 38);
            this.tlpOrderInfo.Name = "tlpOrderInfo";
            this.tlpOrderInfo.RowCount = 1;
            this.tlpOrderInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpOrderInfo.Size = new System.Drawing.Size(851, 45);
            this.tlpOrderInfo.TabIndex = 3;
            // 
            // lblOrderIdTitle
            // 
            this.lblOrderIdTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblOrderIdTitle.AutoSize = true;
            this.lblOrderIdTitle.Location = new System.Drawing.Point(30, 13);
            this.lblOrderIdTitle.Name = "lblOrderIdTitle";
            this.lblOrderIdTitle.Size = new System.Drawing.Size(80, 18);
            this.lblOrderIdTitle.TabIndex = 0;
            this.lblOrderIdTitle.Text = "订单号：";
            // 
            // lblOrderId
            // 
            this.lblOrderId.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblOrderId.AutoSize = true;
            this.lblOrderId.Location = new System.Drawing.Point(211, 13);
            this.lblOrderId.Name = "lblOrderId";
            this.lblOrderId.Size = new System.Drawing.Size(0, 18);
            this.lblOrderId.TabIndex = 0;
            // 
            // lblOrderCustomerTitle
            // 
            this.lblOrderCustomerTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblOrderCustomerTitle.AutoSize = true;
            this.lblOrderCustomerTitle.Location = new System.Drawing.Point(321, 13);
            this.lblOrderCustomerTitle.Name = "lblOrderCustomerTitle";
            this.lblOrderCustomerTitle.Size = new System.Drawing.Size(62, 18);
            this.lblOrderCustomerTitle.TabIndex = 0;
            this.lblOrderCustomerTitle.Text = "客户：";
            // 
            // lblOrderCustomer
            // 
            this.lblOrderCustomer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblOrderCustomer.AutoSize = true;
            this.lblOrderCustomer.Location = new System.Drawing.Point(493, 13);
            this.lblOrderCustomer.Name = "lblOrderCustomer";
            this.lblOrderCustomer.Size = new System.Drawing.Size(0, 18);
            this.lblOrderCustomer.TabIndex = 0;
            // 
            // lblOrderTotalPriceTitle
            // 
            this.lblOrderTotalPriceTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblOrderTotalPriceTitle.AutoSize = true;
            this.lblOrderTotalPriceTitle.Location = new System.Drawing.Point(585, 13);
            this.lblOrderTotalPriceTitle.Name = "lblOrderTotalPriceTitle";
            this.lblOrderTotalPriceTitle.Size = new System.Drawing.Size(98, 18);
            this.lblOrderTotalPriceTitle.TabIndex = 0;
            this.lblOrderTotalPriceTitle.Text = "订单总额：";
            // 
            // lblOrderTotalPrice
            // 
            this.lblOrderTotalPrice.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblOrderTotalPrice.AutoSize = true;
            this.lblOrderTotalPrice.Location = new System.Drawing.Point(778, 13);
            this.lblOrderTotalPrice.Name = "lblOrderTotalPrice";
            this.lblOrderTotalPrice.Size = new System.Drawing.Size(0, 18);
            this.lblOrderTotalPrice.TabIndex = 1;
            // 
            // lblDetailTitle
            // 
            this.lblDetailTitle.BackColor = System.Drawing.SystemColors.Info;
            this.lblDetailTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDetailTitle.Font = new System.Drawing.Font("宋体", 12F);
            this.lblDetailTitle.Location = new System.Drawing.Point(0, 5);
            this.lblDetailTitle.Name = "lblDetailTitle";
            this.lblDetailTitle.Size = new System.Drawing.Size(851, 33);
            this.lblDetailTitle.TabIndex = 0;
            this.lblDetailTitle.Text = "订单明细";
            this.lblDetailTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flpOperation
            // 
            this.flpOperation.AutoSize = true;
            this.flpOperation.Controls.Add(this.btnAddOrder);
            this.flpOperation.Controls.Add(this.btnDeleteOrder);
            this.flpOperation.Controls.Add(this.btnAddGoods);
            this.flpOperation.Controls.Add(this.btnDeleteGoods);
            this.flpOperation.Controls.Add(this.btnModifyOrder);
            this.flpOperation.Controls.Add(this.btnModifyGoods);
            this.flpOperation.Controls.Add(this.btnImport);
            this.flpOperation.Controls.Add(this.btnExport);
            this.flpOperation.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpOperation.Location = new System.Drawing.Point(0, 0);
            this.flpOperation.Name = "flpOperation";
            this.flpOperation.Padding = new System.Windows.Forms.Padding(20, 20, 20, 5);
            this.flpOperation.Size = new System.Drawing.Size(1048, 71);
            this.flpOperation.TabIndex = 0;
            // 
            // btnImport
            // 
            this.btnImport.Font = new System.Drawing.Font("宋体", 12F);
            this.btnImport.Location = new System.Drawing.Point(779, 23);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(120, 40);
            this.btnImport.TabIndex = 0;
            this.btnImport.Text = "导入订单";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnExport
            // 
            this.btnExport.Font = new System.Drawing.Font("宋体", 12F);
            this.btnExport.Location = new System.Drawing.Point(905, 23);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(120, 40);
            this.btnExport.TabIndex = 0;
            this.btnExport.Text = "导出订单";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Font = new System.Drawing.Font("宋体", 12F);
            this.btnQuery.Location = new System.Drawing.Point(367, 8);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(74, 35);
            this.btnQuery.TabIndex = 0;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // lstQuery
            // 
            this.lstQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstQuery.Font = new System.Drawing.Font("宋体", 12F);
            this.lstQuery.FormattingEnabled = true;
            this.lstQuery.HorizontalScrollbar = true;
            this.lstQuery.IntegralHeight = false;
            this.lstQuery.ItemHeight = 24;
            this.lstQuery.Location = new System.Drawing.Point(5, 5);
            this.lstQuery.Name = "lstQuery";
            this.lstQuery.Size = new System.Drawing.Size(140, 36);
            this.lstQuery.TabIndex = 2;
            this.lstQuery.SelectedIndexChanged += new System.EventHandler(this.lstQuery_SelectedIndexChanged);
            // 
            // splQuery
            // 
            this.splQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splQuery.Location = new System.Drawing.Point(0, 137);
            this.splQuery.Name = "splQuery";
            this.splQuery.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splQuery.Panel1
            // 
            this.splQuery.Panel1.Controls.Add(this.splData);
            // 
            // splQuery.Panel2
            // 
            this.splQuery.Panel2.Controls.Add(this.lstQuery);
            this.splQuery.Panel2.Font = new System.Drawing.Font("宋体", 9F);
            this.splQuery.Panel2.Padding = new System.Windows.Forms.Padding(5);
            this.splQuery.Panel2Collapsed = true;
            this.splQuery.Size = new System.Drawing.Size(1048, 407);
            this.splQuery.SplitterDistance = 363;
            this.splQuery.TabIndex = 3;
            // 
            // flpQuery
            // 
            this.flpQuery.AutoSize = true;
            this.flpQuery.Controls.Add(this.cmbQueryType);
            this.flpQuery.Controls.Add(this.txtQuery);
            this.flpQuery.Controls.Add(this.btnQuery);
            this.flpQuery.Controls.Add(this.btnSort);
            this.flpQuery.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpQuery.Location = new System.Drawing.Point(0, 71);
            this.flpQuery.Name = "flpQuery";
            this.flpQuery.Padding = new System.Windows.Forms.Padding(20, 5, 20, 20);
            this.flpQuery.Size = new System.Drawing.Size(1048, 66);
            this.flpQuery.TabIndex = 4;
            // 
            // cmbQueryType
            // 
            this.cmbQueryType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQueryType.Font = new System.Drawing.Font("宋体", 12F);
            this.cmbQueryType.FormattingEnabled = true;
            this.cmbQueryType.Location = new System.Drawing.Point(23, 8);
            this.cmbQueryType.Name = "cmbQueryType";
            this.cmbQueryType.Size = new System.Drawing.Size(141, 32);
            this.cmbQueryType.TabIndex = 1;
            this.cmbQueryType.SelectedIndexChanged += new System.EventHandler(this.cmbQueryType_SelectedIndexChanged);
            // 
            // txtQuery
            // 
            this.txtQuery.Font = new System.Drawing.Font("宋体", 12F);
            this.txtQuery.Location = new System.Drawing.Point(170, 8);
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(191, 35);
            this.txtQuery.TabIndex = 2;
            this.txtQuery.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuery_KeyPress);
            // 
            // btnSort
            // 
            this.btnSort.Font = new System.Drawing.Font("宋体", 12F);
            this.btnSort.Location = new System.Drawing.Point(447, 8);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(74, 35);
            this.btnSort.TabIndex = 0;
            this.btnSort.Text = "排序";
            this.btnSort.UseVisualStyleBackColor = true;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1048, 544);
            this.Controls.Add(this.splQuery);
            this.Controls.Add(this.flpQuery);
            this.Controls.Add(this.flpOperation);
            this.MinimumSize = new System.Drawing.Size(570, 440);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "订单管理系统(数据库版)";
            this.splData.Panel1.ResumeLayout(false);
            this.splData.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splData)).EndInit();
            this.splData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.tlpOrderInfo.ResumeLayout(false);
            this.tlpOrderInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDetail)).EndInit();
            this.flpOperation.ResumeLayout(false);
            this.splQuery.Panel1.ResumeLayout(false);
            this.splQuery.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splQuery)).EndInit();
            this.splQuery.ResumeLayout(false);
            this.flpQuery.ResumeLayout(false);
            this.flpQuery.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.SplitContainer splData;
        private System.Windows.Forms.ListBox lstOrder;
        private System.Windows.Forms.Label lblOrderTitle;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.Label lblDetailTitle;
        private System.Windows.Forms.TableLayoutPanel tlpOrderInfo;
        private System.Windows.Forms.Label lblOrderIdTitle;
        private System.Windows.Forms.Label lblOrderId;
        private System.Windows.Forms.Label lblOrderCustomerTitle;
        private System.Windows.Forms.Label lblOrderCustomer;
        private System.Windows.Forms.Label lblOrderTotalPriceTitle;
        private System.Windows.Forms.Button btnAddOrder;
        private System.Windows.Forms.BindingSource bdsOrder;
        private System.Windows.Forms.Button btnAddGoods;
        private System.Windows.Forms.BindingSource bdsDetail;
        private System.Windows.Forms.Label lblOrderTotalPrice;
        private System.Windows.Forms.Button btnDeleteOrder;
        private System.Windows.Forms.Button btnDeleteGoods;
        private System.Windows.Forms.Button btnModifyGoods;
        private System.Windows.Forms.Button btnModifyOrder;
        private System.Windows.Forms.FlowLayoutPanel flpOperation;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.ListBox lstQuery;
        private System.Windows.Forms.SplitContainer splQuery;
        private System.Windows.Forms.FlowLayoutPanel flpQuery;
        private System.Windows.Forms.ComboBox cmbQueryType;
        private System.Windows.Forms.TextBox txtQuery;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnExport;
    }
}

