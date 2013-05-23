using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KoStoSakaTomce
{
    public class Gift
    {
        public float X { get; set; }
        public float Y { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public Color color { get; set; }
        public bool flag { get; set; }
        private float velocityY=10;
        public Game game { set; get; }
        int numberGift;
        Random R;
        public Form f;


        

        public Gift(int w, int h, float x, float y,Game game,Form f)
        {
            R = new Random();
            this.f = f;
            numberGift = R.Next() %6;
            this.game = game;
            X = x;
            Y = y;
            width = w;
            height = h;
            color = Color.Red;

            if (numberGift == 0)
            {
                color = Color.Black;
                velocityY = 13;
            }
            if (numberGift == 1)
            {
                color = Color.Chocolate;
                velocityY = 6;
            }
            if (numberGift == 2)
            {
                color = Color.Green;
                velocityY = 15;
            }
            if (numberGift == 3)
            {
                color = Color.Violet;
                velocityY = 5;
            }
            if(numberGift==4)
                color = Color.Red;
            if(numberGift==5)
                color = Color.Purple;


        }

        public void RandomGift(){
            if (numberGift == 0) {
                game.palka.width +=20;
                game.palka.color = Color.Black;
                game.brojacGolema = 0;
            }
            if (numberGift == 1)
            {
                game.Invert = true;
                game.brojacInvert = 0;
            }
            if (numberGift == 2) {
                game.Lives++;
            }//zivoti
            if (numberGift == 3) {//mala palka
                game.palka.width -= 40;
                game.palka.color = Color.Blue;
                game.brojacMala = 0;
            }
            if (numberGift == 4)//score
            {
                game.Score(150);
            }
            if (numberGift == 5)//score
            {
                game.Score(200);
            }


        }

        public void Draw(Graphics g)
        {
            Brush b = new SolidBrush(color);
            g.FillRectangle(b, X - width / 2, Y - height / 2, width, height);
        }

       public bool Move(PalkaRect palka)
        {
                float nextY = Y + velocityY;
                Y += velocityY;
                return RectangleCollision(palka);
        }
       bool RectangleCollision(PalkaRect palka)
        {
            if (this.isTouching(palka))
            {
                return true;
            }
            return false;
        }
        public bool isTouching(PalkaRect palka)
        {

            return (Math.Abs(palka.Y - Y) <= (palka.height / 2) + 2 ) && (Math.Abs(palka.X - X) <= (palka.width / 2) + 2);

        }

    }
}
