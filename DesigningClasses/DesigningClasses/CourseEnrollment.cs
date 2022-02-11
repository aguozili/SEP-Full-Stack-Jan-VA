using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesigningClasses
{

    public enum Grade
    {
        A,
        B,
        C,
        D,
        E,
        F,
    }
    public class CourseEnrollment
    {

        public int StudentId { get; set; }
        public int CourseId { get; set; }

        public Student Student { get; set; }

        public Course Course { get; set; }

        public Grade Grade { get; set; }

        public double CalculateGPA()
        {
            throw new NotImplementedException();
        }



    }
}
