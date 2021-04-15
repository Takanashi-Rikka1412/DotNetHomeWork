using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework7
{
    public partial class CayleyForm : System.Windows.Forms.Form
    {
        private Graphics graphics;
        double th1;// = 30 * Math.PI / 180;
        double th2;// = 20 * Math.PI / 180;
        double per1;// = 0.6;
        double per2;// = 0.7;

        public CayleyForm()
        {
            InitializeComponent();
        }

        void drawCayleyTree(int n, double x0, double y0, double leng,
            double th, Pen penColor)
        {
            if (n == 0) return;

            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);

            drawLine(x0, y0, x1, y1, penColor);
            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1, penColor);
            drawCayleyTree(n - 1, x1, y1, per2 * leng, th - th2, penColor);
        }

        void drawLine(double x0, double y0, double x1, double y1, Pen penColor)
        {
            graphics.DrawLine(
                penColor,
                (int)x0, (int)y0, (int)x1, (int)y1);
        }

        private void buttonDraw_Click(object sender, EventArgs e)
        {
            if (graphics == null)
                graphics = this.panelCayley.CreateGraphics();
            else
            {
                graphics.Clear(this.panelCayley.BackColor);
                graphics.Dispose();
                graphics = this.panelCayley.CreateGraphics();
            }

            per1 = (double)numericUpDown3.Value;
            per2 = (double)numericUpDown4.Value;
            th1 = (double)numericUpDown5.Value * Math.PI / 180;
            th2 = (double)numericUpDown6.Value * Math.PI / 180;
            Pen penColor;
            switch (comboBoxPenColor.Text)
            {
                case "黑色": penColor = Pens.Black; break;
                case "蓝色": penColor = Pens.Blue; break;
                case "红色": penColor = Pens.Red; break;
                case "绿色": penColor = Pens.Green; break;
                case "黄色": penColor = Pens.Yellow; break;
                default:
                    comboBoxPenColor.Text = (string)comboBoxPenColor.Items[0];
                    penColor = Pens.Black;
                    break;
            }
            drawCayleyTree((int)numericUpDown1.Value,
                0.5 * panelCayley.Width, panelCayley.Height,
                (double)numericUpDown2.Value, -Math.PI / 2, penColor);
        }

        private void comboBoxBackgroundColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxBackgroundColor.SelectedItem)
            {
                case "黑色":
                    labelBackgroundColor.ForeColor = Color.White;
                    panelCayley.BackColor = Color.Black;
                    break;
                case "白色":
                    labelBackgroundColor.ForeColor = Color.Black;
                    panelCayley.BackColor = Color.White;
                    break;
                case "浅蓝色":
                    labelBackgroundColor.ForeColor = Color.Black;
                    panelCayley.BackColor = Color.LightBlue;
                    break;
                case "浅灰色":
                    labelBackgroundColor.ForeColor = Color.Black;
                    panelCayley.BackColor = Color.LightGray;
                    break;
                case "浅黄色":
                    labelBackgroundColor.ForeColor = Color.Black;
                    panelCayley.BackColor = Color.LightYellow;
                    break;
                default:
                    labelBackgroundColor.ForeColor = Color.Black;
                    panelCayley.BackColor = Color.White;
                    break;
            }

        }
    }
}
