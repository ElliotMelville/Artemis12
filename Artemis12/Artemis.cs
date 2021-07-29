using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace Artemis12
{
    public partial class Artemis : Form
    {
        public Paddle leftPaddle;
        public Paddle rightPaddle;
        public Ball mainBall;
        Graphics g;
        public Artemis()
        {
            InitializeComponent();
            //double buffering
            //stypeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, this, new object[] { true });

            leftPaddle = new Paddle(0, 0);
            rightPaddle = new Paddle(650, 0);
            mainBall = new Ball(352, 255);

            rightPaddle.x = this.Width - rightPaddle.width * 2;
            mainBall.Start(leftPaddle, rightPaddle, this);

            pnlGame.Invalidate();
        }
        private void pnlGame_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            leftPaddle.Draw(g);
            rightPaddle.Draw(g);
            mainBall.Draw(g);
        }
        public int GetGameWidth()
        {
            return pnlGame.Width;
        }
        public int GetGameHeight()
        {
            return pnlGame.Height;
        }

        //PADDLE MOVEMENT (up/down)
        bool paddle1Up = false;
        bool paddle1Down = false;
        bool paddle2Up = false;
        bool paddle2Down = false;

        //SPEEDS (px/16ms)
        const int defaultSpeed = 10;

        private void tmrMovement_Tick(object sender, EventArgs e)
        {
             mainBall.MoveBall();

             if(paddle1Up == true && leftPaddle.y > 0)
             {
                leftPaddle.y -= defaultSpeed;
             }
             //the 40 is to account for the title bar height
             if(paddle1Down == true && (leftPaddle.y + leftPaddle.height + 40) < this.Height)
             {
                leftPaddle.y += defaultSpeed;
             }

             if (paddle2Up == true && rightPaddle.y > 0)
             {
                rightPaddle.y -= defaultSpeed;
             }
             if (paddle2Down == true && (rightPaddle.y + rightPaddle.height + 40) < this.Height)
             {
                rightPaddle.y += defaultSpeed;
             }

            pnlGame.Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.W)
            {
                paddle1Up = true;
            }
            if (e.KeyCode == Keys.S)
            {
                paddle1Down = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                paddle2Up = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                paddle2Down = true;
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                paddle1Up = false;
            }
            if (e.KeyCode == Keys.S)
            {
                paddle1Down = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                paddle2Up = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                paddle2Down = false;
            }
        }

        public void Loss(bool isLeft)
        {
            Console.WriteLine("lose!");
        }


    }
}
