using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesigningClasses
{
    public abstract class Person
    {
        public int Id { get; set; }

        private double salary;

        public double Salary 
        { 
            get { return salary; }
            set
            {
                if (Salary < 0)
                {
                    throw new ArgumentOutOfRangeException("Only positive values are allowed");
                }
            }
        }

        public string Name { get; set; }
        //public string Birthday { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int Age
        {
            get { return DateTime.Now.Year - DateOfBirth.Year; }
        }

        public List<String> Address { get; set; } 

        public void GetAddress(List<String> Address)
        {
            foreach ( var item in Address)
            {
                Console.WriteLine(item);
            }
        }
        public void Information()
        {
            Console.WriteLine($"Name: {Name}, Id: {Id}");
        }
        //public void CalculateAge()
        //{
        //    DateTime bd = DateTime.Parse(Birthday);
        //    var age = DateTime.Today.Year - bd.Year;
        //    if (bd.Date > DateTime.Today.AddYears(-age)) { age--; }
        //    Console.WriteLine($"The age is {age}.");
        //}

        public virtual void Performance()
        {
            Console.WriteLine("Hi Performance Function");
        }

    }
}
