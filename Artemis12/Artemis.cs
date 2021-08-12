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
        public List<Powerup> powerups = new List<Powerup>();
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
            mainBall.Start(leftPaddle, rightPaddle, this, powerups);

            pnlGame.Invalidate();

            AddPowerup();
        }
        private void pnlGame_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            leftPaddle.Draw(g);
            rightPaddle.Draw(g);
            mainBall.Draw(g);
            foreach(var power in powerups)
            {
                power.Draw(g);
            }
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
        public int defaultSpeed = 15;

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

        public void AddPowerup()
        {
            Random random = new Random();
            //number of power types
            int randomType = random.Next(1, 7);
            if (randomType == 1)
            {
                PaddleGrow power = new PaddleGrow(random.Next(0, this.Width - 40), random.Next(0, this.Height - 40));
                powerups.Add(power);
            }
            else if (randomType == 2)
            {
                PaddleShrink power = new PaddleShrink(random.Next(0, this.Width - 40), random.Next(0, this.Height - 40));
                powerups.Add(power);
            }
            else if (randomType == 3)
            {
                BallShrink power = new BallShrink(random.Next(0, this.Width - 40), random.Next(0, this.Height - 40));
                powerups.Add(power);
            }
            else if (randomType == 4)
            {
                BallGrow power = new BallGrow(random.Next(0, this.Width - 40), random.Next(0, this.Height - 40));
                powerups.Add(power);
            }
            else if (randomType == 5)
            {
                SpeedUp power = new SpeedUp(random.Next(0, this.Width - 40), random.Next(0, this.Height - 40));
                powerups.Add(power);
            }
            else if (randomType == 6)
            {
                SlowDown power = new SlowDown(random.Next(0, this.Width - 40), random.Next(0, this.Height - 40));
                powerups.Add(power);
            }
        }
        public void RunPower(Powerup power)
        {
            power.Execute(leftPaddle, rightPaddle, mainBall, this);
        }

        public void Loss(bool isLeft)
        {
            Console.WriteLine("lose!");
            tmrMovement.Enabled = false;
        }

        private void tmrPowers_Tick(object sender, EventArgs e)
        {
            AddPowerup();
        }
    }
}
