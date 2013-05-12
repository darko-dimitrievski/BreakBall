using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
namespace BreakBall
{
    class RectDolu
    {
        public PictureBox pb1 { get; set; }
        public Size golemina { get; set; }
        //private Form1 f;
        public RectDolu() { }
        public RectDolu(Size g)
        {
            pb1 = new PictureBox();
            this.pb1.Size = g;
            this.golemina = g;
        }
    }

}