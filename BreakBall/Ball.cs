using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
namespace KoStoSakaTomce
{
    public class Ball
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Radius { get; set; }
        public float Velocity { get; set; }
        public float Angle { get; set; }
        private float velocityX;
        private float velocityY;
        public Color color { get; set; }
        bool GameOver = false;
        PalkaRect palka;
        List<Brick> b;
        public Game game { set; get; }
        public Form f;
        public Form1 ff;
        Random R;


        public Ball(int x, int y, float radius, float angle,float v,Game game,Form f,Form1 ff)
        {
            //*   center = p;
            this.ff = ff;
            R = new Random();
            this.game = game;
            this.f = f;
            X = x;
            Y = y;
            Radius = radius;
            color = Color.Red;
            Angle = angle;
            Velocity = v;

            velocityX = (float)Math.Cos(Angle) * Velocity;
            velocityY = (float)Math.Sin(Angle) * Velocity;

        }
        public List<Gift> g=new List<Gift>();
        public List<Brick> Move(PalkaRect palka, List<Brick> b)
        {
            game.Score();
            if (!GameOver)
            {
                //if (g != null) g.Move(palka);
                for (int i = 0; i < g.Count; i++) {
                    if (g[i].Move(palka)) {
                        g[i].RandomGift();
                        g.RemoveAt(i);
                    }
                }

                this.palka = palka;
                this.b = b;

                float nextX = X + velocityX;
                float nextY = Y + velocityY;

                if (nextY > palka.Y && game.Lives == 0)
                {
                    GameOver = true;
                    game.CloseGame();

                    //ff.textBox1.Enabled = true;
                    //if (ff.textBox1.Text.Trim().Length == 0) {
                    //    MessageBox.Show("Vneete ime");
                   // }
                    if (MessageBox.Show("Вкупно освоени поени " + game.intScore, "Дали сакате да се обидете повторно",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes) {
                        
                        game.NewGame();
                    }
                }
                else if(nextY>palka.Y)
                {
                    game.START = false;
                   // game.gamestop = true;
                    game.palka.ResetPosition();
                    game.ball.ResetPosition();
                    game.Lives--;

                }
                  WallCollision();
                  RectangleCollision();
                  BrickCollision();

                
                X += velocityX;
                Y += velocityY;
            }
        return b;
         }

        void WallCollision() {
            if (X + Radius <= 35 || (X + Radius >= 650))
            {
                velocityX = -velocityX;
            }
            if (Y - Radius <= 25)
            {
                velocityY = -velocityY;
            }
        }
        void RectangleCollision() {
            if (this.isTouching(palka))
            {
                velocityY = -velocityY;
            }
        }
        void BrickCollision() {
            for (int i = 0; i < b.Count; i++)
            {
                Brick bb = b[i] as Brick;
                if (isTouching(bb))
                {
                    velocityY = -velocityY;
                    //if (b[i].gift != null) {
                    //    g = b[i].gift as Gift;
                    //}
                    if(R.Next(100)%5==0)
                        if (game.level.MaxGifts > 0)
                        {
                            g.Add(new Gift(20, 20, b[i].X, b[i].Y, game, f));
                            game.level.MaxGifts--;
                        }
                    game.Score(100);
                    b.RemoveAt(i);
                }
            }
        }


        public void ResetPosition() {
            this.X = 360;
            this.Y = 564;
        }
        public void Draw(Graphics g)
        {
            Brush b = new SolidBrush(color);
            g.FillEllipse(b, X - Radius / 2, Y - Radius / 2, 2*Radius, 2*Radius);
        }

        public bool isTouching(PalkaRect palka)
        {
           
                return (Math.Abs(palka.Y - Y) <= (palka.height / 2) + 2 * Radius) && (Math.Abs(palka.X - X) <= (palka.width / 2) + 2 * Radius );
            
        }
        public bool isTouching(Brick b)
        {

            return (Math.Abs(b.Y - Y) <= (b.height / 2) + 2 * Radius / 2) && (Math.Abs(b.X - X) <= (b.width / 2) + 2 * Radius / 2);

        }
        
       
    }
}

    


