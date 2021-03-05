using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework1_2
{
    public partial class FormCalculator : Form
    {
        public FormCalculator()
        {
            InitializeComponent();
        }

        private void radioButton_plus_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_plus.Checked == true)
            {
                radioButton_plus.Image = Properties.Resources.加选;
            }
            else
            {
                radioButton_plus.Image = Properties.Resources.加;
            }
            button_equal.Image = Properties.Resources.等于;
        }

        private void radioButton_min_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_min.Checked == true)
            {
                radioButton_min.Image = Properties.Resources.减选;
            }
            else
            {
                radioButton_min.Image = Properties.Resources.减;
            }
            button_equal.Image = Properties.Resources.等于;
        }

        private void radioButton_mul_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_mul.Checked == true)
            {
                radioButton_mul.Image = Properties.Resources.乘选;
            }
            else
            {
                radioButton_mul.Image = Properties.Resources.乘;
            }
            button_equal.Image = Properties.Resources.等于;
        }

        private void radioButton_sub_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_sub.Checked == true)
            {
                radioButton_sub.Image = Properties.Resources.除选;
            }
            else
            {
                radioButton_sub.Image = Properties.Resources.除;
            }
            button_equal.Image = Properties.Resources.等于;
        }

        private void button_equal_Click(object sender, EventArgs e)
        {
            if (textBox_op1.Text == String.Empty || textBox_op2.Text == String.Empty)
                return;

            button_equal.Image = Properties.Resources.等于选;

            double result;

            if (radioButton_plus.Checked == true)
            {
                result = Double.Parse(textBox_op1.Text) + Double.Parse(textBox_op2.Text);
                label_result.Text = result.ToString();
            }
            else if (radioButton_min.Checked == true)
            {
                result = Double.Parse(textBox_op1.Text) - Double.Parse(textBox_op2.Text);
                label_result.Text = result.ToString();
            }
            else if (radioButton_mul.Checked == true)
            {
                result = Double.Parse(textBox_op1.Text) * Double.Parse(textBox_op2.Text);
                label_result.Text = result.ToString();
            }
            else if (radioButton_sub.Checked == true)
            {
                if (Double.Parse(textBox_op2.Text) != 0)
                {
                    result = Double.Parse(textBox_op1.Text) / Double.Parse(textBox_op2.Text);
                    label_result.Text = result.ToString();
                }
                else if (Double.Parse(textBox_op2.Text) == 0 && Double.Parse(textBox_op1.Text) == 0)
                    label_result.Text = "结果未定义";
                else if (Double.Parse(textBox_op2.Text) == 0 && Double.Parse(textBox_op1.Text) != 0)
                    label_result.Text = "除数不能为0";
            }
        }

        private void textBox_op1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != '.' && e.KeyChar != (char)8)
                e.Handled = true;
            if (textBox_op1.Text.Contains('.') && e.KeyChar == '.')
                e.Handled = true;

            button_equal.Image = Properties.Resources.等于;
        }

        private void textBox_op2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != '.' && e.KeyChar != (char)8)
                e.Handled = true;
            if (textBox_op1.Text.Contains('.') && e.KeyChar == '.')
                e.Handled = true;

            button_equal.Image = Properties.Resources.等于;
        }
    }
}
