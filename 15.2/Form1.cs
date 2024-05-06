using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _15._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(canvasPictureBox.Width, canvasPictureBox.Height);
            g = Graphics.FromImage(bmp);
            rand = new Random();
        }

        private Bitmap bmp;
        private Graphics g;
        private Random rand;

        private void button1_Click(object sender, EventArgs e)
        {
            DrawRaindrop();
            timer1.Start();
        }

        private void DrawRaindrop()
        {
            // Закрашиваем фон
            g.Clear(Color.White);

            // Рисуем дождь
            Pen pen = new Pen(Color.Blue, 1);
            for (int i = 0; i < 100; i++)
            {
                int x = rand.Next(0, canvasPictureBox.Width);
                int y = rand.Next(0, canvasPictureBox.Height);
                g.DrawLine(pen, x, y, x, y + 5);
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            DrawRaindrop();
            canvasPictureBox.Image = bmp;
        }
    }
}
