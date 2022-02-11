using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorBall
{
    public class Ball
    {
        public Ball(byte red, byte green, byte blue)
        {
            BallColor = new Color(red, green, blue);
        }

        public Ball(byte red, byte green, byte blue, byte alpha)
        {
            BallColor = new Color(red, green, blue, alpha);
        }

        public Color BallColor;

        public int Size { get; set; }

        public int ThrowCount = 0;

        public void Pop()
        {
            Size = 0;
        }

        public void Throw()
        {
            if (Size > 0) 
            { 
                ThrowCount++;
            }
        }




        

    }
}
