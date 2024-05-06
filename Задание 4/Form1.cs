using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Задание_4
{
    public partial class Form1 : Form
    {

        private string[] colors = { "Red", "Blue", "Green", "Orange", "Purple" };
        private string[] fonts = { "Arial", "Times New Roman", "Calibri", "Verdana" };
        private int colorIndex = 0;
        private int fontIndex = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            button1.Click += new EventHandler(button1_Click);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            ThreadPool.QueueUserWorkItem(new WaitCallback(ChangeText));
        }

        private void ChangeText(object state)
        {
            for (int i = 0; i < 5; i++)
            {
                Color color = Color.FromName(colors[colorIndex]);
                Font font = new Font(fonts[fontIndex], 12, FontStyle.Regular);

                // Invoking UI thread to update the label
                Invoke((MethodInvoker)delegate
                {
                    label1.ForeColor = color;
                    label1.Font = font;
                    label1.Text = $"Color: {colors[colorIndex]}, Font: {fonts[fontIndex]}";
                });

                Thread.Sleep(10000); // Wait for 10 seconds

                // Update color and font indexes
                colorIndex = (colorIndex + 1) % colors.Length;
                fontIndex = (fontIndex + 1) % fonts.Length;
            }

            // Enable button after all iterations are done
            Invoke((MethodInvoker)delegate
            {
                button1.Enabled = true;
            });
        }
    }
}
