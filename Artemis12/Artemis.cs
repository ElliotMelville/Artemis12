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
        public Artemis()
        {
            InitializeComponent();
            //double buffering
            //stypeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, this, new object[] { true });

            picPaddle2.Left = this.Width - picPaddle2.Width * 2;
            ballMain.Start(picPaddle1, picPaddle2, this);
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
            ballMain.MoveBall();

            if(paddle1Up == true && picPaddle1.Top > 0)
            {
                picPaddle1.Top -= defaultSpeed;
            }
            //the 40 is to account for the title bar height
            if(paddle1Down == true && (picPaddle1.Top + picPaddle1.Height + 40) < this.Height)
            {
                picPaddle1.Top += defaultSpeed;
            }

            if (paddle2Up == true && picPaddle2.Top > 0)
            {
                picPaddle2.Top -= defaultSpeed;
            }
            if (paddle2Down == true && (picPaddle2.Top + picPaddle2.Height + 40) < this.Height)
            {
                picPaddle2.Top += defaultSpeed;
            }
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
