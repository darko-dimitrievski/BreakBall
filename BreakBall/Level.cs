using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace KoStoSakaTomce
{
    public class Level
    {
        public List<Brick> bricks;
        Random R;
        public int MAXLEVELS=5;//MAXIMUM LEVELS
        public int MaxGifts;//MAXIMUM GIFTS BY LEVEL

        public Level(int lvl) {
            R = new Random();
            bricks = new List<Brick>();
            Levels(lvl);
        }
        public bool Draw(Graphics g)
        {
            int i;
            for (i = 0; i < bricks.Count; i++)
            {
                bricks[i].Draw(g);
            }
            if (bricks.Count>0) return true;
            return false;
        }
        void Levels(int lvl) {
            /*if (lvl == 0)
            {
                bricks.Add(new Brick(50, 50, 100 + (1 * 80) + 2 * 70, 70 + (4 * 35), R));
                bricks[0].gift = new Gift(20, 20, bricks[0].X, bricks[0].Y, R);
            }
                if(lvl==1) bricks.Add(new Brick(50, 50, 100 + (1 * 80) +2*70, 70 + (1 * 35), R));
                    if(lvl==2) bricks.Add(new Brick(50, 50, 100 + (1 * 80) +2*70, 70 + (1 * 35), R));
             */
            if (lvl == 0) {
                MaxGifts = 3;
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        Brick b;
                        b = new Brick(40, 10, 100 + (i * 80) +j*70, 70 + (i * 35), R);
                        bricks.Add(b);
                    }
                }
                //bricks[0].gift = new Gift(20, 20, bricks[0].X, bricks[0].Y, R);
            }
             
            if (lvl == 1)
            {
                MaxGifts = 4;
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        Brick b;
                        if (i % 2 != 0) b = new Brick(40, 10, 100 + (j * 80) - 20, 70 + (i * 35), R);
                        else b = new Brick(40, 10, 150 + (j * 80), 70 + (i * 35), R);

                        bricks.Add(b);

                    }
                }
            }
            if (lvl == 2)
            {
                MaxGifts = 4;
                for (int i = 0; i < 7; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        Brick b;
                        if (i % 2 != 0) b = new Brick(40, 10, 100 + (j * 80) - 20, 70 + (i * 35), R);
                        else b = new Brick(40, 10, 150 + (j * 80), 70 + (i * 35), R);

                        bricks.Add(b);

                    }
                }
            }
            if (lvl == 3)
            {
                MaxGifts = 6;
                for (int i = 0; i < 7; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        Brick b;
                        if (i % 2 != 0) b = new Brick(40, 10, 100 + (j * 80) - 20, 90 + (i * 35), R);
                        else b = new Brick(40, 10, 150 + (j * 80), 90 + (i * 35), R);

                        bricks.Add(b);

                    }
                }
            }
            if (lvl == 4)
            {
                MaxGifts = 7;
                for (int i = 0; i < 7; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        Brick b;
                        if (i % 2 != 0) b = new Brick(40, 10, 100 + (j * 80) - 20, 20 + (i * 35), R);
                        else b = new Brick(40, 10, 150 + (i * 80), 15 + (j * 35), R);

                        bricks.Add(b);

                    }
                }
            }
             
        
        }
    }
}
