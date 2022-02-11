using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesigningClasses
{
    public class Instructor: Person
    {

        public override void Performance()
        {
            Console.WriteLine("Teaching.");
        }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
