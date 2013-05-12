using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;


namespace BreakBall
{
    class Brick
    {
        public PictureBox pb2 { get; set; }
        public Size golemina { get; set; }
       // private Form1 f;
        public Brick() { }
        public Brick(Size g)
        {
            pb2 = new PictureBox();
            this.pb2.Size = g;
            this.golemina = g;

        }





    }

}