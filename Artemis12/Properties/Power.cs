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
    class Power : PictureBox
    {
        enum Type
        {
            //default values start at 0
            BallGrow, //0
            BallClone, //1
            PaddleGrow, //2
            PaddleShrink, //3
            PaddleFast, //4
            Cloud, //5
            Comet, //6
            BallInvis, //7
            BallPortal, //8
            MultiBall, //9
            BallFast, //10
            BallSlow //11
        };
        int typeCount = Enum.GetNames(typeof(Type)).Length;
        Random random = new Random();
        Type myType;
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            myType = (Type)random.Next(0, typeCount + 1);
            Console.WriteLine(myType.ToString());
        }
    }
}
