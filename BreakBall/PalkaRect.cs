using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace KoStoSakaTomce
{
    public class PalkaRect
    {
        public float X { get; set; }
        public float Y { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public Color color { get; set; }
        public bool flag { get; set; }

        public PalkaRect(float x , float y,int w, int h)
        {
            X = x;
            Y = y;
            width = w;
            height = h;
            
            color = Color.Olive;
            flag = false;

        }
        public void Draw(Graphics g)
        {
            Brush brush = new SolidBrush(color);
            g.FillRectangle(brush, X - width / 2, Y - height / 2, width, height);
        }
        public void ResetPosition()
        {
            this.X = 360;
            this.Y = 600;
        }
        
    }

}
