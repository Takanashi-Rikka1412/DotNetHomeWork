namespace Homework1_2
{
    partial class FormCalculator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCalculator));
            this.label_name = new System.Windows.Forms.Label();
            this.label_author = new System.Windows.Forms.Label();
            this.textBox_op1 = new System.Windows.Forms.TextBox();
            this.textBox_op2 = new System.Windows.Forms.TextBox();
            this.label_result = new System.Windows.Forms.Label();
            this.button_equal = new System.Windows.Forms.Button();
            this.radioButton_sub = new System.Windows.Forms.RadioButton();
            this.radioButton_mul = new System.Windows.Forms.RadioButton();
            this.radioButton_min = new System.Windows.Forms.RadioButton();
            this.radioButton_plus = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Font = new System.Drawing.Font("黑体", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_name.Location = new System.Drawing.Point(18, 14);
            this.label_name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(330, 60);
            this.label_name.TabIndex = 6;
            this.label_name.Text = "简易计算器";
            // 
            // label_author
            // 
            this.label_author.AutoSize = true;
            this.label_author.Font = new System.Drawing.Font("宋体", 12F);
            this.label_author.Location = new System.Drawing.Point(360, 50);
            this.label_author.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_author.Name = "label_author";
            this.label_author.Size = new System.Drawing.Size(118, 24);
            this.label_author.TabIndex = 7;
            this.label_author.Text = "by 郭派锋";
            // 
            // textBox_op1
            // 
            this.textBox_op1.Font = new System.Drawing.Font("黑体", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_op1.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textBox_op1.Location = new System.Drawing.Point(18, 108);
            this.textBox_op1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_op1.Name = "textBox_op1";
            this.textBox_op1.Size = new System.Drawing.Size(490, 64);
            this.textBox_op1.TabIndex = 8;
            this.textBox_op1.TabStop = false;
            this.textBox_op1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_op1_KeyPress);
            // 
            // textBox_op2
            // 
            this.textBox_op2.Font = new System.Drawing.Font("黑体", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_op2.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textBox_op2.Location = new System.Drawing.Point(18, 336);
            this.textBox_op2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_op2.Name = "textBox_op2";
            this.textBox_op2.Size = new System.Drawing.Size(490, 64);
            this.textBox_op2.TabIndex = 8;
            this.textBox_op2.TabStop = false;
            this.textBox_op2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_op2_KeyPress);
            // 
            // label_result
            // 
            this.label_result.Font = new System.Drawing.Font("宋体", 25F);
            this.label_result.Location = new System.Drawing.Point(18, 567);
            this.label_result.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_result.Name = "label_result";
            this.label_result.Size = new System.Drawing.Size(492, 69);
            this.label_result.TabIndex = 9;
            this.label_result.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_equal
            // 
            this.button_equal.BackColor = System.Drawing.Color.Transparent;
            this.button_equal.FlatAppearance.BorderSize = 0;
            this.button_equal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_equal.Image = global::Homework1_2.Properties.Resources.等于;
            this.button_equal.Location = new System.Drawing.Point(213, 435);
            this.button_equal.Margin = new System.Windows.Forms.Padding(4);
            this.button_equal.Name = "button_equal";
            this.button_equal.Size = new System.Drawing.Size(99, 99);
            this.button_equal.TabIndex = 10;
            this.button_equal.UseVisualStyleBackColor = false;
            this.button_equal.Click += new System.EventHandler(this.button_equal_Click);
            // 
            // radioButton_sub
            // 
            this.radioButton_sub.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton_sub.AutoSize = true;
            this.radioButton_sub.BackColor = System.Drawing.Color.Transparent;
            this.radioButton_sub.FlatAppearance.BorderSize = 0;
            this.radioButton_sub.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton_sub.Image = global::Homework1_2.Properties.Resources.除;
            this.radioButton_sub.Location = new System.Drawing.Point(386, 207);
            this.radioButton_sub.Name = "radioButton_sub";
            this.radioButton_sub.Size = new System.Drawing.Size(66, 66);
            this.radioButton_sub.TabIndex = 5;
            this.radioButton_sub.UseVisualStyleBackColor = false;
            this.radioButton_sub.CheckedChanged += new System.EventHandler(this.radioButton_sub_CheckedChanged);
            // 
            // radioButton_mul
            // 
            this.radioButton_mul.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton_mul.AutoSize = true;
            this.radioButton_mul.BackColor = System.Drawing.Color.Transparent;
            this.radioButton_mul.FlatAppearance.BorderSize = 0;
            this.radioButton_mul.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton_mul.Image = global::Homework1_2.Properties.Resources.乘;
            this.radioButton_mul.Location = new System.Drawing.Point(282, 207);
            this.radioButton_mul.Name = "radioButton_mul";
            this.radioButton_mul.Size = new System.Drawing.Size(66, 66);
            this.radioButton_mul.TabIndex = 5;
            this.radioButton_mul.UseVisualStyleBackColor = false;
            this.radioButton_mul.CheckedChanged += new System.EventHandler(this.radioButton_mul_CheckedChanged);
            // 
            // radioButton_min
            // 
            this.radioButton_min.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton_min.AutoSize = true;
            this.radioButton_min.BackColor = System.Drawing.Color.Transparent;
            this.radioButton_min.FlatAppearance.BorderSize = 0;
            this.radioButton_min.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton_min.Image = global::Homework1_2.Properties.Resources.减;
            this.radioButton_min.Location = new System.Drawing.Point(173, 207);
            this.radioButton_min.Name = "radioButton_min";
            this.radioButton_min.Size = new System.Drawing.Size(66, 66);
            this.radioButton_min.TabIndex = 5;
            this.radioButton_min.UseVisualStyleBackColor = false;
            this.radioButton_min.CheckedChanged += new System.EventHandler(this.radioButton_min_CheckedChanged);
            // 
            // radioButton_plus
            // 
            this.radioButton_plus.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton_plus.AutoSize = true;
            this.radioButton_plus.FlatAppearance.BorderSize = 0;
            this.radioButton_plus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton_plus.Image = global::Homework1_2.Properties.Resources.加;
            this.radioButton_plus.Location = new System.Drawing.Point(68, 207);
            this.radioButton_plus.Name = "radioButton_plus";
            this.radioButton_plus.Size = new System.Drawing.Size(66, 66);
            this.radioButton_plus.TabIndex = 5;
            this.radioButton_plus.UseVisualStyleBackColor = false;
            this.radioButton_plus.CheckedChanged += new System.EventHandler(this.radioButton_plus_CheckedChanged);
            // 
            // FormCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(528, 694);
            this.Controls.Add(this.button_equal);
            this.Controls.Add(this.label_result);
            this.Controls.Add(this.textBox_op2);
            this.Controls.Add(this.textBox_op1);
            this.Controls.Add(this.label_author);
            this.Controls.Add(this.label_name);
            this.Controls.Add(this.radioButton_sub);
            this.Controls.Add(this.radioButton_mul);
            this.Controls.Add(this.radioButton_min);
            this.Controls.Add(this.radioButton_plus);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCalculator";
            this.Text = "简易计算器";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton radioButton_plus;
        private System.Windows.Forms.RadioButton radioButton_min;
        private System.Windows.Forms.RadioButton radioButton_mul;
        private System.Windows.Forms.RadioButton radioButton_sub;
        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.Label label_author;
        private System.Windows.Forms.TextBox textBox_op1;
        private System.Windows.Forms.TextBox textBox_op2;
        private System.Windows.Forms.Label label_result;
        private System.Windows.Forms.Button button_equal;
    }
}

