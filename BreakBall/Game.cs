using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KoStoSakaTomce//Brakja Score e napraven samo u labeu da napravite da se prikazue i jos ednu labelu za lives :)
{
    public class Game
    {
        public List<Gift> gift;
        public Timer timer;
        public Ball ball;
        public PalkaRect palka;
        Graphics graphics;
        Brush brush;
        Pen pen;
       public Rectangle bounds;
        Bitmap doubleBuffer;
        static readonly int FRAMES_PER_SECOND = 1;
        public Level level;
        int LVL;
        public Form f;
        public  bool Invert=false;
        public int  brojacInvert;
        public int  brojacMala;
        public int  brojacGolema;
        public Form1 ff;
        public bool gamestop { set; get; }

        public  bool START = false;

       public int intScore;
         public int Lives;

        public Game(Form f,Form1 ff) {
            this.f = f;
            this.ff = ff;
            NewGame();
        }
        public void CloseGame(){
            graphics.Dispose();
            //graphics = f.CreateGraphics();
            timer.Dispose();
        }

        public void NewGame() {
            //bricks = new List<Brick>();
            //DoubleBuffered = true;
            //gamestop = true;

            bounds = new Rectangle(0, 25, f.Bounds.Width - 18, f.Bounds.Height - 40);
            doubleBuffer = new Bitmap(f.Width, f.Height);
            graphics = f.CreateGraphics();
            ball = new Ball(360, 564, 15, 60, 30,this,f,ff);
            f.Show();
            palka = new PalkaRect(360, 600, 100, 10);
            brush = new SolidBrush(Color.Blue);
            pen = new Pen(Color.White);

            LVL = 0;
            level = new Level(LVL);
            intScore = 0;
            Lives = 3;
            intScore = 0;

            brojacInvert=0;
            brojacMala=0;
            brojacGolema=0;




            timer = new Timer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = 50 / FRAMES_PER_SECOND;
            timer.Start();
        }

       public void start() {
           if (!START) START = true;
        }

       public void Score() {
           intScore += 1;
       }
       public void Score(int score)
       {
           intScore += score;
           
       }

       public bool nivo = true;
       
        void timer_Tick(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromImage(doubleBuffer);
            g.Clear(Color.Beige);

            g.DrawRectangle(pen, bounds);
            ball.Draw(g);
            palka.Draw(g);
            //Score();
            ff.lbLives.Text = "Lives : " + Lives.ToString();
            ff.lbScore.Text = "Score : " + intScore.ToString();
            

            gift = ball.g;

            for (int i = 0; i < gift.Count; i++) {
                gift[i].Draw(g);
            }


            if (brojacGolema <100) {brojacGolema++;}
            else if (brojacGolema == 100) { palka.width =100 ; palka.color = Color.Olive; brojacGolema = 101; }
            if (brojacInvert < 70) {brojacInvert++;}
            else if (brojacInvert == 70) {Invert = false;brojacInvert=71;}
            if (brojacMala < 50) { brojacMala++; }
            else if (brojacMala == 50) { palka.width =100; palka.color = Color.Olive; brojacMala = 51; }


            
            if (START) 
                level.bricks = ball.Move(palka, level.bricks);
            
            if (!level.Draw(g)) {
                if (nivo)
                {
                    nivo = false;
                    START=false;
                    if (MessageBox.Show("Дали сакаш да одиш на наредното ниво?", "Ниво " + LVL,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        LVL++;
                        if (LVL < level.MAXLEVELS)
                        {
                            level = new Level(LVL);
                            level.Draw(g);
                            ball.ResetPosition();
                            palka.ResetPosition();
                            nivo = true;
                        }
                        else MessageBox.Show("Играта заврши");
                    }

                }
            }

            
            ///150 denara 5 minuta 
            
            
            graphics.DrawImageUnscaled(doubleBuffer, 0, 0);

        }
    }
}
