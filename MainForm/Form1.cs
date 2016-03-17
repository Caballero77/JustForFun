using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainForm
{
    public partial class Form1 : Form
    {
        private double R = 250;

        private int r = 50;

        private double angle = 0;

        private Brush b = Brushes.Red;

        private int count = 0;

        public Form1()
        {
            InitializeComponent();

            MainTimer.Enabled = true;

            MainTimer.Tick += MainTimer_Tick;

            MouseClick += Form1_MouseClick;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (Math.Sqrt(Math.Pow(e.X - (int)(R * Math.Cos(angle) + R) - r / 2, 2) + Math.Pow(e.Y - (int)(R * Math.Sin(angle) + R) - r / 2, 2)) <= r/2)
            {
                if(b == Brushes.Red)
                {
                    b = Brushes.Blue;
                }
                else
                {
                    b = Brushes.Red;
                }
                count++;
                Count.Text = Convert.ToString(count);
            }
        }

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            Graphics mgr = CreateGraphics();

            mgr.Clear(Color.DarkGray);

            mgr.FillEllipse(b, new Rectangle((int)(R * Math.Cos(angle) + R), (int)(R * Math.Sin(angle) + R), r, r));

            angle += Math.PI / 180;

            if(angle == Math.PI * 2)

            {
                angle = 0;
            }

        }
    }
}
