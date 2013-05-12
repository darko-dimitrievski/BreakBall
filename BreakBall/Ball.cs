using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace BreakBall
{
    class Ball
    {
        public int velocityX;
        public int velocityY;
        public PictureBox pb { get; set; }

        public Ball(Size golemina, int x, int y)
        {
            velocityX = x;
            velocityY = y;
            pb = new PictureBox();
            pb.Size = golemina;

        }


    }
}