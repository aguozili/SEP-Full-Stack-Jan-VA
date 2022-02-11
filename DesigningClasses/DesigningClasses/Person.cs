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
        public string Name { get; set; }
        public string Birthday { get; set; }
        
        public void Information()
        {
            Console.WriteLine($"Name: {Name}, Id: {Id}");
        }
        public void CalculateAge()
        {
            DateTime bd = DateTime.Parse(Birthday);
            var age = DateTime.Today.Year - bd.Year;
            if (bd.Date > DateTime.Today.AddYears(-age)) { age--; }
            Console.WriteLine($"The age is {age}.");
        }

        public virtual void Performance()
        {
            Console.WriteLine("Do what a peopple do.");
        }

    }
}
