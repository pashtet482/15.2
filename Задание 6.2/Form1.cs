using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Задание_6._2
{
    public partial class Form1 : Form
    {

        private Rectangle rectangle;
        private bool isGradientOne = true;
        

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Создаем прямоугольник
            rectangle = new Rectangle(50, 50, 200, 100);
            // Запускаем таймер
            
            timer1.Interval = 5000; // 5 секунд
            timer1.Tick += timer1_Tick;
            timer1.Start();
            // Рисуем прямоугольник
            DrawGradientRectangle();
        }

        

        private void timer1_Tick(object sender, EventArgs e)
        {
            // После каждого тика таймера меняем флаг и перерисовываем прямоугольник
            isGradientOne = !isGradientOne;
            DrawGradientRectangle();
        }

        private void DrawGradientRectangle()
        {
            // Получаем Graphics объект
            Graphics g = this.CreateGraphics();
            // Создаем LinearGradientBrush в зависимости от значения флага isGradientOne
            LinearGradientBrush brush = isGradientOne ?
                new LinearGradientBrush(rectangle, Color.Blue, Color.Red, LinearGradientMode.Horizontal) :
                new LinearGradientBrush(rectangle, Color.Yellow, Color.Green, LinearGradientMode.Horizontal);
            // Заливаем прямоугольник градиентом
            g.FillRectangle(brush, rectangle);
            // Освобождаем ресурсы
            g.Dispose();
        }
    }
}
