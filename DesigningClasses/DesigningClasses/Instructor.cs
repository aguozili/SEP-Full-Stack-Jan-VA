﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesigningClasses
{
    public class Instructor: Person
    {
       public decimal Salary { get; set; }

        public override void Performance()
        {
            Console.WriteLine("Teaching.");
        }
    }
}