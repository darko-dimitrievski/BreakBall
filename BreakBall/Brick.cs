using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace KoStoSakaTomce
{
    public class Brick
    {
        public float X { get; set; }
        public float Y { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public Color color { get; set; }
        public bool flag { get; set; }
        public Gift gift { set; get; }

        public Brick(int w, int h, float x, float y,Random R)
        {
            X = x;
            Y = y;
            width = w;
            height = h;
            color = Color.FromArgb(R.Next(50,250), R.Next(70, 255), R.Next(90,190));
        }
        public void Draw(Graphics g)
        {
            
            Brush b = new SolidBrush(color);
            g.FillRectangle(b, X - width / 2, Y - height / 2, width, height);
        }


    }

}
