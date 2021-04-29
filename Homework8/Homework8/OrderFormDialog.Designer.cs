namespace Homework8
{
    partial class OrderFormDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblOrderId = new System.Windows.Forms.Label();
            this.txtOrderId = new System.Windows.Forms.TextBox();
            this.lblOrderCustomer = new System.Windows.Forms.Label();
            this.txtOrderCustomer = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblOrderId
            // 
            this.lblOrderId.AutoSize = true;
            this.lblOrderId.Location = new System.Drawing.Point(37, 52);
            this.lblOrderId.Name = "lblOrderId";
            this.lblOrderId.Size = new System.Drawing.Size(62, 18);
            this.lblOrderId.TabIndex = 0;
            this.lblOrderId.Text = "订单号";
            // 
            // txtOrderId
            // 
            this.txtOrderId.Location = new System.Drawing.Point(115, 49);
            this.txtOrderId.MaxLength = 20;
            this.txtOrderId.Name = "txtOrderId";
            this.txtOrderId.Size = new System.Drawing.Size(176, 28);
            this.txtOrderId.TabIndex = 1;
            // 
            // lblOrderCustomer
            // 
            this.lblOrderCustomer.AutoSize = true;
            this.lblOrderCustomer.Location = new System.Drawing.Point(55, 108);
            this.lblOrderCustomer.Name = "lblOrderCustomer";
            this.lblOrderCustomer.Size = new System.Drawing.Size(44, 18);
            this.lblOrderCustomer.TabIndex = 0;
            this.lblOrderCustomer.Text = "客户";
            // 
            // txtOrderCustomer
            // 
            this.txtOrderCustomer.Location = new System.Drawing.Point(115, 105);
            this.txtOrderCustomer.MaxLength = 20;
            this.txtOrderCustomer.Name = "txtOrderCustomer";
            this.txtOrderCustomer.Size = new System.Drawing.Size(176, 28);
            this.txtOrderCustomer.TabIndex = 2;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(73, 180);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 31);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "确认";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(180, 180);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 31);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // OrderFormDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 244);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtOrderCustomer);
            this.Controls.Add(this.txtOrderId);
            this.Controls.Add(this.lblOrderCustomer);
            this.Controls.Add(this.lblOrderId);
            this.MaximumSize = new System.Drawing.Size(350, 300);
            this.MinimumSize = new System.Drawing.Size(350, 300);
            this.Name = "OrderFormDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " 添加订单";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblOrderId;
        private System.Windows.Forms.TextBox txtOrderId;
        private System.Windows.Forms.Label lblOrderCustomer;
        private System.Windows.Forms.TextBox txtOrderCustomer;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}