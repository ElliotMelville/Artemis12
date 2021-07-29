using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Artemis12.Properties
{
    class Ball : PictureBox
    {
        int xSpeed = 0;
        int ySpeed = 0;
        PictureBox leftPaddle, rightPaddle;
        Artemis mainForm;
        Random random = new Random();
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            this.BackColor = System.Drawing.Color.Blue;
        }

        public void Start(PictureBox paddle1, PictureBox paddle2, Artemis form)
        {
            //collect paddles and form
            leftPaddle = paddle1;
            rightPaddle = paddle2;
            mainForm = form;

            this.Left = Parent.Width / 2 - this.Width / 2;
            this.Top = (Parent.Height / 2 - this.Height / 2) - 40;

            //selects reasonable starting x speed, avoids anything between -5 and 5
            this.xSpeed = this.random.Next(-10, 11);
            if(xSpeed <= 0 && xSpeed > -5)
            {
                xSpeed = -5;
            }
            else if(xSpeed >= 0 && xSpeed < 5)
            {
                xSpeed = 5;
            }
            this.ySpeed = this.random.Next(-10, 11);
        }

        public void MoveBall()
        {
            int newX = this.Left + xSpeed;
            int newY = this.Top + ySpeed;
            //if the ball hits the left or right wall
            if(newX < 0)
            {
                newX = HitLeft(newX);
            }
            else if(newX + this.Width > Parent.Width)
            {
                newX = HitRight(newX);
            }

            if (newY < 0 || newY + this.Height > Parent.Height - 40)
            {
                ySpeed *= -1;
            }

            this.Left = newX;
            this.Top = newY;
        }

        private int HitLeft(int newX)
        {
            bool hitPaddle = false;
            string whereHit = null;
            //checking if the ball has hit the paddle
            if(this.Top < leftPaddle.Bottom && this.Top > leftPaddle.Top)
            {
                hitPaddle = true;
            }
            else if(this.Bottom < leftPaddle.Bottom && this.Bottom > leftPaddle.Top)
            {
                hitPaddle = true;
            }

            if (hitPaddle)
            {
                if(this.Top < leftPaddle.Top && xSpeed > 0)
                {
                    ySpeed *= -1;
                }
                if(this.Bottom > leftPaddle.Bottom && xSpeed > 0)
                {
                    ySpeed *= -1;
                }


                xSpeed *= -1;
                //making sure the ball doesn't overlap with the paddle
                if (newX < leftPaddle.Right)
                {
                    newX = leftPaddle.Right;
                }
            }
            else
            {
                //tell the main form that the game has been lost, and stop the ball from moving
                mainForm.Loss(true);
                xSpeed = 0;
                ySpeed = 0;
            }

            return newX;
        }
        private int HitRight(int newX)
        {
            bool hitPaddle = false;
            //checking if the ball has hit the paddle
            if (this.Top < rightPaddle.Bottom && this.Top > rightPaddle.Top)
            {
                hitPaddle = true;
            }
            else if (this.Bottom < leftPaddle.Bottom && this.Bottom > leftPaddle.Top)
            {
                hitPaddle = true;
            }

            if (hitPaddle)
            {
                xSpeed *= -1;
                //making sure the ball doesn't overlap with the paddle
                if (newX - this.Width < rightPaddle.Left)
                {
                    newX = rightPaddle.Left - this.Width;
                }
            }
            else
            {
                //tell the main form that the game has been lost, and stop the ball from moving
                mainForm.Loss(false);
                xSpeed = 0;
                ySpeed = 0;
            }

            return newX;
        }
    }
}
