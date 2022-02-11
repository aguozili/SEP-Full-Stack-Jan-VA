using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesigningClasses
{
    public class Student:Person
    {
        public override void Performance()
        {
            Console.WriteLine("Doing Assignment.");
        }
    }
}
