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

        public bool Intersects(VisualObject friend)
        {
            //collision detection (used with powerups)
            if(this.x >= friend.x && this.x <= friend.Right() && this.y >= friend.y && this.y <= friend.Bottom())
            {
                return true;
            }
            if(this.Right() >= friend.x && this.Right() <= friend.Right() && this.y >= friend.y && this.y <= friend.Bottom())
            {
                return true;
            }
            if(this.x >= friend.x && this.x <= friend.Right() && this.Bottom() >= friend.y && this.Bottom() <= friend.Bottom())
            {
                return true;
            }
            if(this.Right() >= friend.x && this.Right() <= friend.Right() && this.Bottom() >= friend.y && this.Bottom() <= friend.Bottom())
            {
                return true;
            }

            return false;
        }
    }

    public class Paddle : VisualObject
    {
        public Image paddleImage = Properties.Resources.test;
        //imaginary radius of paddle - for bouncing
        public int paddleRadius;

        //constructor
        public Paddle(int _x, int _y)
        {
            x = _x;
            y = _y;
            width = 17;
            height = 90;
            SetPaddleRadius();
        }

        public void Draw(Graphics g)
        {
            Rectangle paddleRec = new Rectangle(x, y, width, height);
            g.DrawImage(paddleImage, paddleRec);
        }

        public void SetPaddleRadius()
        {
            paddleRadius = height * 2;
        }

        public double GetBounceAngle(double ballCentre)
        {
            //centre of paddle
            double paddleCentre = y + height / 2;
            //distance from centre of paddle
            double distCentre = ballCentre - paddleCentre;

            //angle = 90'-cos^-1(distCentre/paddleRadius)
            double bounceAngle = (Math.PI/2) - Math.Acos(distCentre/paddleRadius);

            return bounceAngle;
        }

        //GROW POWER
        public void Grow()
        {
            height += 50;
            y -= 25;
            SetPaddleRadius();
        }
        //SHRINK POWER
        public void Shrink()
        {
            height -= 30;
            y += 15;
            SetPaddleRadius();
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

        Paddle leftPaddle;
        Paddle rightPaddle;
        Artemis mainForm;
        List<Powerup> powerups;
        Random random = new Random();

        int speed = 9;
        double angle;

        public void Start(Paddle paddleLeft, Paddle paddleRight, Artemis form, List<Powerup> powerupsfromform)
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
            powerups = powerupsfromform;
        }

        public void MoveBall()
        {
            double adjacent = Math.Cos(angle) * speed;
            double opposite = Math.Sin(angle) * speed;

            int newX = x + Convert.ToInt32(adjacent);
            int newY = y + Convert.ToInt32(opposite);
            //if the ball hits the left or right wall
            if (newX < leftPaddle.x + leftPaddle.width)
            {
                newX = HitLeft(newX);
            }
            else if (newX + width > rightPaddle.x)
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

            //collision with powerups
            CheckPowerups();

        }
        public void CheckPowerups()
        {
            foreach(var powerup in powerups)
            {
                if(this.Intersects(powerup) || powerup.Intersects(this))
                {
                    //collided!
                    mainForm.RunPower(powerup, this);
                    powerups.Remove(powerup);
                    break;
                }
            }
        }
        private double FixAngle(double angle)
        {
            while(angle < 0 || angle > 2 * Math.PI)
            {
                if(angle < 0)
                {
                    angle += Math.PI * 2;
                }
                else
                {
                    angle -= Math.PI * 2;
                }
            }
            return angle;
        }
        private int HitLeft(int newX)
        {
            //checking if the ball has hit the paddle

            if (Intersects(leftPaddle) || leftPaddle.Intersects(this))
            {
                //making sure the ball doesn't overlap with the paddle
                if (newX < leftPaddle.Right())
                {
                    newX = leftPaddle.Right();
                }
                angle = angle + 2*(leftPaddle.GetBounceAngle(y + height / 2) - Math.PI/2 - angle);
                angle = FixAngle(angle);
                if (angle <= Math.PI && angle >= Math.PI / 2 - (15 * Math.PI / 180))
                {
                    angle = Math.PI / 2 - (15 * Math.PI / 180);
                }
                else if (angle >= Math.PI && angle <= 1.5*Math.PI/2 + (15 * Math.PI / 180))
                {
                    angle = 1.5 * Math.PI / 2 + (15 * Math.PI / 180);
                }

            }
            else if (newX <= 0)
            {
                mainForm.BallOut(this);
            }

            return newX;
        }
        private int HitRight(int newX)
        {
            //checking if the ball has hit the paddle
            if (Intersects(rightPaddle) || rightPaddle.Intersects(this))
            {
                //making sure the ball doesn't overlap with the paddle
                if (this.Right() >= rightPaddle.x)
                {
                    newX = rightPaddle.x - this.width;
                }
                //angle = angle - 2*(rightPaddle.GetBounceAngle(y + height / 2) + Math.PI/2 - angle);
                angle = angle - 2*(rightPaddle.GetBounceAngle(y + height / 2) - Math.PI/2 + angle);
                angle = FixAngle(angle);
                if (angle >= Math.PI / 2 && angle <= Math.PI / 2 + (15 * Math.PI / 180))
                {
                    angle = Math.PI / 2 + (15 * Math.PI / 180);
                }
                else if (angle <= 1.5 * Math.PI && angle >= 1.5 * Math.PI / 2 - (15 * Math.PI / 180))
                {
                    angle = 1.5 * Math.PI / 2 - (15 * Math.PI / 180);
                }
            }
            else if (newX >= mainForm.Width - width)
            {
                mainForm.BallOut(this);
            }

            return newX;
        }

        //GROW POWER
        public void Grow()
        {
            width += 5;
            height += 5;
            x -= width / 2;
            y -= height / 2;
        }
        //SHRINK POWER
        public void Shrink()
        {
            width -= 5;
            height -= 5;
            x += width / 2;
            y += height / 2;
        }
    }

    public abstract class Powerup : VisualObject
    {

        Random random = new Random();

        public Powerup(int _x, int _y)
        {
            x = _x;
            y = _y;
            width = 40;
            height = 40;
        }
        public void Draw(Graphics g)
        {
            Rectangle powerRec = new Rectangle(x, y, width, height);
            g.DrawImage(GetImage(), powerRec);
        }
        public abstract Image GetImage();

        public abstract void Execute(Paddle left, Paddle right, Ball balls, Artemis mainForm);
    }
    public class PaddleGrow : Powerup
    {
        public Image paddleGrowImage = Properties.Resources.PaddleGrow;
        public override Image GetImage()
        {
            return paddleGrowImage;
        }
        public PaddleGrow(int _x, int _y):base(_x, _y)
        {

        }
        public override void Execute(Paddle left, Paddle right, Ball balls, Artemis mainForm)
        {
            left.Grow();
            right.Grow();
        }
    }
    public class PaddleShrink : Powerup
    {
        public Image paddleGrowImage = Properties.Resources.PaddleShrink;
        public override Image GetImage()
        {
            return paddleGrowImage;
        }
        public PaddleShrink(int _x, int _y) : base(_x, _y)
        {

        }
        public override void Execute(Paddle left, Paddle right, Ball balls, Artemis mainForm)
        {
            left.Shrink();
            right.Shrink();
        }
    }
    public class BallGrow : Powerup
    {
        public Image ballGrowImage = Properties.Resources.BallShrink;
        public override Image GetImage()
        {
            return ballGrowImage;
        }
        public BallGrow(int _x, int _y) : base(_x, _y)
        {

        }
        public override void Execute(Paddle left, Paddle right, Ball ball, Artemis mainForm)
        {
            ball.Grow();
        }
    }
    public class BallShrink : Powerup
    {
        public Image ballShrinkImage = Properties.Resources.BallGrow;
        public override Image GetImage()
        {
            return ballShrinkImage;
        }
        public BallShrink(int _x, int _y) : base(_x, _y)
        {

        }
        public override void Execute(Paddle left, Paddle right, Ball ball, Artemis mainForm)
        {
            ball.Shrink();
        }
    }
    public class BallDuplicate : Powerup
    {
        public Image ballDupeImage = Properties.Resources.BallClone;
        public override Image GetImage()
        {
            return ballDupeImage;
        }
        public BallDuplicate(int _x, int _y) : base(_x, _y)
        {

        }
        public override void Execute(Paddle left, Paddle right, Ball ball, Artemis mainForm)
        {
            mainForm.AddBall(ball, 1);
        }
    }
    public class MultiBall : Powerup
    {
        public Image multiBallImage = Properties.Resources.Multiball;
        public override Image GetImage()
        {
            return multiBallImage;
        }
        public MultiBall(int _x, int _y) : base(_x, _y)
        {

        }
        public override void Execute(Paddle left, Paddle right, Ball ball, Artemis mainForm)
        {
            mainForm.AddBall(ball, 4);
        }
    }

    public class Cloud : VisualObject
    {
        public Image paddleImage = Properties.Resources.test;

        //constructor
        public Cloud(int _x, int _y)
        {
            x = _x;
            y = _y;
            width = 15;
            height = 160;
        }
    }
}
