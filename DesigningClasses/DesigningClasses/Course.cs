using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesigningClasses
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Student> EnrolledStudent { get; set; }

    }
}
