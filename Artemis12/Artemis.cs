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
        public List<Ball> balls = new List<Ball>();
        public List<Powerup> powerups = new List<Powerup>();
        Graphics g;
        int score = 0;
        public Artemis()
        {
            InitializeComponent();
            //double buffering
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, pnlGame, new object[] { true });
            leftPaddle = new Paddle(0, 0);
            rightPaddle = new Paddle(650, 0);
            mainBall = new Ball(352, 255);
            picHelp.Visible = false;
            picStory.Visible = false;
            btnBack.Visible = false;
            lblScore.Visible = false;
            picGameOver.Visible = false;
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            pnlGame.BringToFront();

            rightPaddle.x = this.Width - rightPaddle.width * 2;
            rightPaddle.y = pnlGame.Height / 2 - rightPaddle.height / 2;
            leftPaddle.y = pnlGame.Height / 2 - leftPaddle.height / 2;
            mainBall.Start(leftPaddle, rightPaddle, this, powerups);

            pnlGame.Invalidate();

            AddPowerup();

            balls.Add(mainBall);

            tmrMovement.Enabled = true;
            tmrPowers.Enabled = true;
            btnStart.Visible = false;
            btnStart.Enabled = false;
            btnHelp.Visible = false;
            btnHelp.Enabled = false;
            btnStory.Visible = false;
            btnStory.Enabled = false;
            picHome.Visible = false;
            btnBack.Enabled = false;
            picGameOver.Visible = false;

            tmrSeconds.Enabled = true;
            lblScore.Visible = true;

            lblScore.Top = 490;

            score = 0;
        }

        private void pnlGame_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            leftPaddle.Draw(g);
            rightPaddle.Draw(g);
            //mainBall.Draw(g);
            foreach (var ball in balls)
            {
                ball.Draw(g);
            }
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
            List<Ball> tempBalls = new List<Ball>();
            foreach(var ball in balls)
            {
                tempBalls.Add(ball);
            }
            foreach (var ball in tempBalls)
            {
                ball.MoveBall();
            }
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
            int randomType = random.Next(1, 9);
            if (randomType == 1)
            {
                PaddleGrow power = new PaddleGrow(random.Next(0, pnlGame.Width - 40), random.Next(0, pnlGame.Height - 40));
                powerups.Add(power);
            }
            else if (randomType == 2)
            {
                PaddleShrink power = new PaddleShrink(random.Next(0, pnlGame.Width - 40), random.Next(0, pnlGame.Height - 40));
                powerups.Add(power);
            }
            else if (randomType == 3)
            {
                BallShrink power = new BallShrink(random.Next(0, pnlGame.Width - 40), random.Next(0, pnlGame.Height - 40));
                powerups.Add(power);
            }
            else if (randomType == 4)
            {
                BallGrow power = new BallGrow(random.Next(0, pnlGame.Width - 40), random.Next(0, pnlGame.Height - 40));
                powerups.Add(power);
            }
            else if (randomType == 5)
            {
                MultiBall power = new MultiBall(random.Next(0, pnlGame.Width - 40), random.Next(0, pnlGame.Height - 40));
                powerups.Add(power);
            }
            else if (randomType > 5)
            {
                BallDuplicate power = new BallDuplicate(random.Next(0, pnlGame.Width - 40), random.Next(0, pnlGame.Height - 40));
                powerups.Add(power);
            }
        }
        public void RunPower(Powerup power, Ball ball)
        {
            power.Execute(leftPaddle, rightPaddle, ball, this);
        }

        public void BallOut(Ball ball)
        {
            balls.Remove(ball);
            if (balls.Count == 0)
            {
                tmrMovement.Enabled = false;
                //restart form
                tmrMovement.Enabled = false;
                tmrPowers.Enabled = false;
                btnStart.Visible = true;
                btnStart.Enabled = true;
                btnHelp.Visible = true;
                btnHelp.Enabled = true;
                btnStory.Visible = true;
                btnStory.Enabled = true;
                btnBack.Enabled = true;

                //picBackground.Visible = false;
                //picBackground.SendToBack();

                tmrSeconds.Enabled = false;
                lblScore.Visible = false;

                //GAME OVER SCREEN
                picGameOver.Visible = true;
                picGameOver.BringToFront();
                btnStart.BringToFront();
                btnHelp.BringToFront();
                btnStory.BringToFront();
                lblScore.BringToFront();

                //HOME SCREEN START
                leftPaddle = new Paddle(0, 0);
                rightPaddle = new Paddle(650, 0);
                mainBall = new Ball(352, 255);
                picHelp.Visible = false;
                picStory.Visible = false;
                btnBack.Visible = false;


                //SCORE
                tmrSeconds.Enabled = false;
                lblScore.Visible = true;
                lblScore.Top -= 100;

                powerups.Clear();
;            }

        }

        private void tmrPowers_Tick(object sender, EventArgs e)
        {
            AddPowerup();
        }

        public void AddBall(Ball parentBall, int count)
        {
            int i = 0;
            while(i < count)
            {
                Ball newBall = new Ball(parentBall.x, parentBall.y);
                newBall.Start(leftPaddle, rightPaddle, this, powerups);
                balls.Add(newBall);

                i++;
            }

        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            picHelp.BringToFront();
            picHelp.Visible = true;
            btnBack.Visible = true;
            btnBack.Enabled = true;
            btnBack.BringToFront();
        }
        private void btnStory_Click(object sender, EventArgs e)
        {
            picStory.BringToFront();
            picStory.Visible = true;
            btnBack.Visible = true;
            btnBack.Enabled = true;
            btnBack.BringToFront();
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            picHelp.Visible = false;
            picStory.Visible = false;
            btnBack.Visible = false;
        }

        private void tmrSeconds_Tick(object sender, EventArgs e)
        {
            score++;
            lblScore.Text = "SCORE: " + score.ToString();
        }
    }
}
