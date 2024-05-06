using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Задание_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void DrawBubble()
        {
            Graphics g = this.CreateGraphics();
            Random rnd = new Random();
            int x = rnd.Next(0, this.Width); // генерируем случайные координаты X
            int y = rnd.Next(0, this.Height); // генерируем случайные координаты Y
            int diameter = rnd.Next(20, 100); // генерируем случайный диаметр пузыря

            Pen pen = new Pen(Color.Blue);
            g.DrawEllipse(pen, x, y, diameter, diameter);
            g.Dispose();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            DrawBubble();
        }
    }
}
