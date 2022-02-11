using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorBall
{
    public class Ball
    {

        public Color BallColor { get; set; }

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
