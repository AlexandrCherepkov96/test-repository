using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test_repository
{
    public partial class Form1 : Form
    {

        private Point pos;
        private bool dragging, lose = false;
                
        public Form1()
        {
            InitializeComponent();

            pb1.MouseDown += MouseClickDown;
            pb1.MouseUp += MouseClickUp;
            pb1.MouseMove += MouseClickMove;
            pb2.MouseDown += MouseClickDown;
            pb2.MouseUp += MouseClickUp;
            pb2.MouseMove += MouseClickMove;
            pb3.MouseDown += MouseClickDown;
            pb3.MouseUp += MouseClickUp;
            pb3.MouseMove += MouseClickMove;

            labelLose.Visible = false;
            restart.Visible = false;
            KeyPreview = true;
        }



        private void MouseClickDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            pos.X = e.X;
            pos.Y = e.Y;
        }
        private void MouseClickUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
        private void MouseClickMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point currPoint = PointToScreen(new Point(e.X, e.Y));
                this.Location = new Point(currPoint.X - pos.X, currPoint.Y - pos.Y + pb1.Top);
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
                this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int speed = 3;
            pb1.Top += speed;
            pb2.Top += speed;
            pb3.Top += speed;

            int carSpeed = 1;
            car2.Top += speed;
            car3.Top += speed;
            car4.Top += speed;

            if (pb1.Top >= 650)
            {
                pb1.Top = 0;
                pb2.Top = -650;
                pb3.Top = -400;
            }

            if (car2.Top >= 650)
            {
                car2.Top = -200;
                Random rand = new Random();
                car2.Left = rand.Next(150, 300);
            }

            if (car3.Top >= 650)
            {
                car3.Top = -130;
                Random rand = new Random();
                car3.Left = rand.Next(300, 640);
            }

            if (car4.Top >= 650)
            {
                car4.Top = -400;
                Random rand = new Random();
                car4.Left = rand.Next(200, 360);

            }

            if(car1.Bounds.IntersectsWith(car2.Bounds)
                || car1.Bounds.IntersectsWith(car3.Bounds)
                || car1.Bounds.IntersectsWith(car4.Bounds))
            {
                timer1.Enabled = false;
                labelLose.Visible = true;
                restart.Visible = true;
                lose = true;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(lose) return;

            int speed = 10;
            if ((e.KeyCode == Keys.Left || e.KeyCode == Keys.A) && car1.Left > 150 )
                car1.Left -= speed;
            else if ((e.KeyCode == Keys.Right || e.KeyCode == Keys.D) && car1.Right < 690)
                car1.Left += speed;
            

        }

        private void restart_Click(object sender, EventArgs e)
        {
            car2.Top = -200;
            car3.Top = -130;
            car4.Top = -400;
            labelLose.Visible = false;
            restart.Visible = false;
            timer1.Enabled = true;
            lose = false;
        }
    }
}
