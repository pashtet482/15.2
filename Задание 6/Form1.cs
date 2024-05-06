using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;

namespace GradientRectangleApp
{
    public partial class Form1 : Form
    {
        private Button drawButton;
        private Rectangle rectangle;
        private bool isGradientOne = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            drawButton.Enabled = false;
            rectangle = new Rectangle(50, 50, 200, 100);
            DrawGradientRectangle();
        }

        private void DrawGradientRectangle()
        {
            Graphics g = this.CreateGraphics();
            LinearGradientBrush brush;

            if (isGradientOne)
                brush = new LinearGradientBrush(rectangle, Color.Blue, Color.Red, LinearGradientMode.Horizontal);
            else
                brush = new LinearGradientBrush(rectangle, Color.Yellow, Color.Green, LinearGradientMode.Horizontal);

            g.FillRectangle(brush, rectangle);

            Thread.Sleep(5000);

            g.Clear(Color.White);

            isGradientOne = !isGradientOne;

            drawButton.Enabled = true;
        }




    }
}
