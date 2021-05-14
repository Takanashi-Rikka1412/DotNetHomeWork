namespace OrderForm
{
    partial class DetailFormDialog
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtDetailUnitPrice = new System.Windows.Forms.TextBox();
            this.txtDetailName = new System.Windows.Forms.TextBox();
            this.lblDetailUnitPrice = new System.Windows.Forms.Label();
            this.lblDetailName = new System.Windows.Forms.Label();
            this.lblDetailCount = new System.Windows.Forms.Label();
            this.txtDetailCount = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(180, 216);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 31);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(73, 216);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 31);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "确认";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtDetailUnitPrice
            // 
            this.txtDetailUnitPrice.Location = new System.Drawing.Point(115, 102);
            this.txtDetailUnitPrice.MaxLength = 20;
            this.txtDetailUnitPrice.Name = "txtDetailUnitPrice";
            this.txtDetailUnitPrice.Size = new System.Drawing.Size(176, 28);
            this.txtDetailUnitPrice.TabIndex = 8;
            this.txtDetailUnitPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDetailUnitPrice_KeyPress);
            // 
            // txtDetailName
            // 
            this.txtDetailName.Location = new System.Drawing.Point(115, 46);
            this.txtDetailName.MaxLength = 20;
            this.txtDetailName.Name = "txtDetailName";
            this.txtDetailName.Size = new System.Drawing.Size(176, 28);
            this.txtDetailName.TabIndex = 7;
            // 
            // lblDetailUnitPrice
            // 
            this.lblDetailUnitPrice.AutoSize = true;
            this.lblDetailUnitPrice.Location = new System.Drawing.Point(55, 105);
            this.lblDetailUnitPrice.Name = "lblDetailUnitPrice";
            this.lblDetailUnitPrice.Size = new System.Drawing.Size(44, 18);
            this.lblDetailUnitPrice.TabIndex = 5;
            this.lblDetailUnitPrice.Text = "单价";
            // 
            // lblDetailName
            // 
            this.lblDetailName.AutoSize = true;
            this.lblDetailName.Location = new System.Drawing.Point(19, 49);
            this.lblDetailName.Name = "lblDetailName";
            this.lblDetailName.Size = new System.Drawing.Size(80, 18);
            this.lblDetailName.TabIndex = 6;
            this.lblDetailName.Text = "商品名称";
            // 
            // lblDetailCount
            // 
            this.lblDetailCount.AutoSize = true;
            this.lblDetailCount.Location = new System.Drawing.Point(55, 161);
            this.lblDetailCount.Name = "lblDetailCount";
            this.lblDetailCount.Size = new System.Drawing.Size(44, 18);
            this.lblDetailCount.TabIndex = 5;
            this.lblDetailCount.Text = "数量";
            // 
            // txtDetailCount
            // 
            this.txtDetailCount.Location = new System.Drawing.Point(115, 158);
            this.txtDetailCount.MaxLength = 20;
            this.txtDetailCount.Name = "txtDetailCount";
            this.txtDetailCount.Size = new System.Drawing.Size(176, 28);
            this.txtDetailCount.TabIndex = 8;
            this.txtDetailCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDetailCount_KeyPress);
            // 
            // DetailFormDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 294);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtDetailCount);
            this.Controls.Add(this.txtDetailUnitPrice);
            this.Controls.Add(this.lblDetailCount);
            this.Controls.Add(this.txtDetailName);
            this.Controls.Add(this.lblDetailUnitPrice);
            this.Controls.Add(this.lblDetailName);
            this.MaximumSize = new System.Drawing.Size(350, 350);
            this.MinimumSize = new System.Drawing.Size(350, 350);
            this.Name = "DetailFormDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加商品";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtDetailUnitPrice;
        private System.Windows.Forms.TextBox txtDetailName;
        private System.Windows.Forms.Label lblDetailUnitPrice;
        private System.Windows.Forms.Label lblDetailName;
        private System.Windows.Forms.Label lblDetailCount;
        private System.Windows.Forms.TextBox txtDetailCount;
    }
}