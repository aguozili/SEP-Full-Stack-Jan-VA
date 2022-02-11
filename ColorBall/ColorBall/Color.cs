using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorBall
{
    public class Color
    {
        public Color(byte red, byte green, byte blue, byte alpha)
        {
            Green = green;
            Blue = blue;
            Alpha = alpha;
        }

        public Color(byte red, byte green, byte blue)
        {
            Green = green;
            Blue = blue;
            Alpha = 255;
        }

        public byte Red { get; set; }
        public byte Green { get; set; }
        public byte Blue { get; set; }
        public byte Alpha { get; set; } 


        public void GetGrayScale()
        {
            Console.WriteLine("The grayscale is " + Convert.ToByte(Red + Green + Blue)/3); 
        }


    }
}
