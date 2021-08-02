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
    public class VisualObject
    {
        // declare fields to use in the class
        public int x, y, width, height;//variables for the rectangle

        public Rectangle rect;//variable for a rectangle to place our image in

        //Create a constructor (initialises the values of the fields)
        public VisualObject()
        {

        }
        public int Bottom()
        {
            return y + height;
        }
        public int Right()
        {
            return x + width;
        }

        public void Draw(Graphics g)
        {
            
        }
    }

    public class Paddle : VisualObject
    {
        public Image paddleImage = Properties.Resources.test;

        //constructor
        public Paddle(int _x, int _y)
        {
            x = _x;
            y = _y;
            width = 15;
            height = 80;
        }

        public void Draw(Graphics g)
        {
            Rectangle paddleRec = new Rectangle(x, y, width, height);
            g.DrawImage(paddleImage, paddleRec);
        }
    }

    public class Ball : VisualObject
    {
        public Image ballImage = Properties.Resources.test;
        //constructor
        public Ball(int _x, int _y)
        {
            x = _x;
            y = _y;
            width = 40;
            height = 40;
        }
        public void Draw(Graphics g)
        {
            Rectangle ballRec = new Rectangle(x, y, width, height);
            g.DrawImage(ballImage, ballRec);
        }

        int xSpeed = 0;
        int ySpeed = 0;
        Paddle leftPaddle;
        Paddle rightPaddle;
        Artemis mainForm;
        Random random = new Random();

        int speed = 7;
        double angle;

        public void Start(Paddle paddleLeft, Paddle paddleRight, Artemis form)
        {
            int angleDegrees = random.Next(-45, 46);
            if(random.Next(0, 2) == 0)
            {
                //launch to right
                angle = angleDegrees * Math.PI / 180;
            }
            else
            {
                //launch to left
                angle = (angleDegrees + 180) * Math.PI / 180;
            }


            //collect paddles and form
            leftPaddle = paddleLeft;
            rightPaddle = paddleRight;
            mainForm = form;

            this.x = form.GetGameWidth() / 2 - width / 2;
            this.y = (form.GetGameHeight() / 2 - height / 2);

            //selects reasonable starting x speed, avoids anything between -5 and 5
            this.xSpeed = this.random.Next(-10, 11);
            if (xSpeed <= 0 && xSpeed > -5)
            {
                xSpeed = -5;
            }
            else if (xSpeed >= 0 && xSpeed < 5)
            {
                xSpeed = 5;
            }
            this.ySpeed = this.random.Next(-10, 11);
        }

        public void MoveBall()
        {
            double adjacent = Math.Cos(angle) * speed;
            double opposite = Math.Sin(angle) * speed;

            int newX = x + Convert.ToInt32(adjacent);
            int newY = y + Convert.ToInt32(opposite);
            //if the ball hits the left or right wall
            if (newX < 0)
            {
                newX = HitLeft(newX);
            }
            else if (newX + width > mainForm.GetGameWidth())
            {
                newX = HitRight(newX);
            }

            if (newY < 0)
            {
                angle *= -1;
            }
            else if(newY + height > mainForm.GetGameHeight())
            {
                angle *= -1;
            }

            x = newX;
            y = newY;
        }

        private int HitLeft(int newX)
        {
            bool hitPaddle = false;
            string whereHit = null;
            //checking if the ball has hit the paddle
            if (y < leftPaddle.Bottom() && y > leftPaddle.y)
            {
                hitPaddle = true;
            }
            else if (this.Bottom() < leftPaddle.Bottom() && this.Bottom() > leftPaddle.y)
            {
                hitPaddle = true;
            }

            if (hitPaddle)
            {
                angle -= Math.PI + angle * 2;
                //making sure the ball doesn't overlap with the paddle
                if (newX < leftPaddle.Right())
                {
                    newX = leftPaddle.Right();
                }
            }
            else
            {
                //tell the main form that the game has been lost, and stop the ball from moving
                mainForm.Loss(true);
               speed = 0;
            }

            return newX;
        }
        private int HitRight(int newX)
        {
            bool hitPaddle = false;
            //checking if the ball has hit the paddle
            if (y < rightPaddle.Bottom() && y > rightPaddle.y)
            {
                hitPaddle = true;
            }
            else if (this.Bottom() < leftPaddle.Bottom() && this.Bottom() > leftPaddle.y)
            {
                hitPaddle = true;
            }

            if (hitPaddle)
            {
                angle += Math.PI - angle * 2;
                //making sure the ball doesn't overlap with the paddle
                if (newX - this.width < rightPaddle.x)
                {
                    newX = rightPaddle.x - this.width;
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
