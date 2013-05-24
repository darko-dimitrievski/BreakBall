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
    public partial class Form1 : Form
    {

        bool Invert {set;get;}
        //bool gamestop;


        Game game;
        public Form1()
        {
            InitializeComponent();
            Invert = false;
            game = new Game(this,this);
      
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            this.Invert = game.Invert;
           // this.gamestop = game.gamestop;
            //if (!gamestop)
            if (game.START)
            {
                if (e.KeyCode == Keys.Left)
                {
                    if (game.palka.X - game.palka.width / 2 >= game.bounds.Left)
                    {
                        if (!Invert)
                            game.palka.X -= 20;
                        else game.palka.X += 20;
                    }
                }

                if (e.KeyCode == Keys.Right)
                {

                    if (game.palka.X + game.palka.width / 2 <= game.bounds.Right)
                    {
                        if (!Invert)
                            game.palka.X += 20;
                        else game.palka.X -= 20;
                    }
                }
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            //game.gamestop = false;
            game.start();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!game.START)
            {
                
            if ((e.X>= 50) && (e.X <=635))
                 {
                    game.palka.X = e.X;
                    game.ball.X = e.X;
                }
            }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sender == newGameToolStripMenuItem)
            {
                game.CloseGame();
                game = new Game(this,this);
            }
        }

        private void closeGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sender == closeGameToolStripMenuItem)
            {
                if (MessageBox.Show("Дали сте сигурни дека сакате да ја ислучите играта?", "Close",
                       MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    this.Close();
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
        
            pictureBox1.Hide();
            pictureBox2.Hide();
            pictureBox3.Hide();
            pictureBox4.Hide();
            pictureBox5.Hide();
            pictureBox6.Hide();
            pictureBox7.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            
            pictureBox4.Hide();
            pictureBox5.Hide();
            pictureBox6.Hide();
            pictureBox7.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pictureBox1.Hide();
            pictureBox2.Hide();
            pictureBox3.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Close();
        }

  

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand; 
        }

        private void pictureBox5_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pictureBox7_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;

        }

        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

    }
}
