using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BreakBall
{
    public partial class Form1 : Form
    {
        Timer timer;
        Ball ball;
        RectDolu rectdolu;
        Brick brick, brick1, brick2, brick3, brick4;
        Graphics graphics;
        Brush brush;
        Pen pen;


        Bitmap doubleBuffer;

        static readonly int FRAMES_PER_SECOND = 30;
        Size sizeball = new Size(20, 20);
        Size sizerect = new Size(100, 10);
        Size sizebrick = new Size(50, 10);
        int ballVelocityX = 5;
        int ballVelocityY = 5;
        public Form1()
        {
            InitializeComponent();


            doubleBuffer = new Bitmap(Width, Height);
            graphics = CreateGraphics();
            ball = new Ball(sizeball, ballVelocityX, ballVelocityY);
            ball.pb.Location = new Point(ClientSize.Width / 2 - ball.pb.Width / 2, ClientSize.Height / 2 - ball.pb.Height / 2);
            ball.pb.BackColor = Color.Red;
            this.Controls.Add(ball.pb);

            rectdolu = new RectDolu(sizerect);
            rectdolu.pb1.Location = new Point(200, ClientSize.Height - 10);
            rectdolu.pb1.BackColor = Color.Black;
            this.Controls.Add(rectdolu.pb1);

            brick = new Brick(sizebrick);
            brick.pb2.Location = new Point(100, 10);
            brick.pb2.BackColor = Color.Black;
            this.Controls.Add(brick.pb2);

            brick1 = new Brick(sizebrick);
            brick1.pb2.Location = new Point(15, 90);
            brick1.pb2.BackColor = Color.Black;
            this.Controls.Add(brick1.pb2);

            brick2 = new Brick(sizebrick);
            brick2.pb2.Location = new Point(180, 70);
            brick2.pb2.BackColor = Color.Black;
            this.Controls.Add(brick2.pb2);


            brick3 = new Brick(sizebrick);
            brick3.pb2.Location = new Point(200, 50);
            brick3.pb2.BackColor = Color.Black;
            this.Controls.Add(brick3.pb2);

            brick4 = new Brick(sizebrick);
            brick4.pb2.Location = new Point(160, 30);
            brick4.pb2.BackColor = Color.Black;
            this.Controls.Add(brick4.pb2);
            Show();
            brush = new SolidBrush(Color.Gray);
            pen = new Pen(Color.Red);
            timer = new Timer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Enabled = true;
            timer.Interval = 1000 / FRAMES_PER_SECOND;
            timer.Start();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromImage(doubleBuffer);
            g.Clear(Color.White);
            Brush b = new SolidBrush(Color.Gray);
            ball.pb.Location = new Point(ball.pb.Location.X - ball.velocityX, ball.pb.Location.Y - ball.velocityY);
            if (ball.pb.Location.X > this.ClientSize.Height - ball.pb.Height || ball.pb.Location.X < 0)
            {
                ball.velocityX = -ball.velocityX;
            }
            if (ball.pb.Location.Y < 0)
            {
                ball.velocityY = -ball.velocityY;
            }
            if (ball.pb.Bounds.IntersectsWith(brick.pb2.Bounds))
            {
                ball.velocityY = -ball.velocityY;
                brick.pb2.Location = new Point(1000, 1000);
            }
            if (ball.pb.Bounds.IntersectsWith(brick1.pb2.Bounds))
            {
                ball.velocityY = -ball.velocityY;
                brick1.pb2.Location = new Point(1000, 1000);
            }
            if (ball.pb.Bounds.IntersectsWith(brick2.pb2.Bounds))
            {
                ball.velocityY = -ball.velocityY;
                brick2.pb2.Location = new Point(1000, 1000);
            }
            if (ball.pb.Bounds.IntersectsWith(brick3.pb2.Bounds))
            {
                ball.velocityY = -ball.velocityY;
                brick3.pb2.Location = new Point(1000, 1000);
            }
            if (ball.pb.Bounds.IntersectsWith(brick4.pb2.Bounds))
            {
                ball.velocityY = -ball.velocityY;
                brick4.pb2.Location = new Point(1000, 1000);
            }
            if (ball.pb.Bounds.IntersectsWith(rectdolu.pb1.Bounds))
            {
                ball.velocityY = -ball.velocityY;

            }
            graphics.DrawImageUnscaled(doubleBuffer, 0, 0);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                int pom1 = rectdolu.pb1.Location.X + 10;
                int pom2 = rectdolu.pb1.Location.Y;

                rectdolu.pb1.Location = new Point(pom1,pom2);

            }
            if (e.KeyCode == Keys.Left)
            {
                int pom1 = rectdolu.pb1.Location.X - 10;
                int pom2 = rectdolu.pb1.Location.Y;

                rectdolu.pb1.Location = new Point(pom1,pom2);

            }

            if (e.KeyCode == Keys.Up)
            {
                
                int pom1 = rectdolu.pb1.Location.X;
                int pom2 = rectdolu.pb1.Location.Y-5;
                rectdolu.pb1.Location = new Point(pom1,pom2);

            }
        }

 
    }
}
