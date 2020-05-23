using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wolfram.NETLink;

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MathKernel k = mathKernel1;
            k.Compute("f[x_] := -0.75 x^2 - 6*x + 7.5;");
            k.Compute("xm = f[4]*Sqrt[121]");
            textBox1.Text = k.Result.ToString();

            string c = k.Result.ToString();
            char[] chars = c.ToCharArray();
            for (int i = 0; i < c.Length; i++)
                if (chars[i] == '.')
                    chars[i] = ',';
            c = new string(chars);
            double x = Convert.ToDouble(c);
            k.Compute("aa = Det[{{x,x+1},{x-1,x}}]");
            textBox2.Text = k.Result.ToString();
            if (x < 0)
                MessageBox.Show("x<0");
            else
            {
                k.Compute("t = Sqrt[xm]*Sin[xm]//N");
                textBox3.Text = k.Result.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MathKernel k = mathKernel1;
            k.GraphicsHeight = pictureBox1.Height;
            k.GraphicsWidth = pictureBox1.Width;
            k.CaptureGraphics = true;
            k.GraphicsFormat = "JPEG";
            k.Compute("Show[Plot[-0.75 x^2 - 6*x + 7.5,{x,-3,3}]]");
            pictureBox1.Image = k.Graphics[0];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Image.FromFile("test.jpg");
        }
    }
}
