using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesigningClasses
{
    public class Department
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public DateTime JoinDate { get; set; }
        public int YearOfExperience
        { get { return DateTime.Now.Year - JoinDate.Year; } }
        public decimal Budget { get; set; }
        public int HeadId { get; set; }
        public Instructor Head { get; set; }
        public List<Course> ProvidedCourses { get; set; }

    }
}
