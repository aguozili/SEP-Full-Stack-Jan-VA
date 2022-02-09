using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02UnderstandingTypes
{
    public class Class1
    {
        public void CenturyConvert(uint a)
        {

            uint years = a * 100;
            uint days = years * 365;
            uint hours = days * 24;
            uint minutes = hours * 60;
            uint seconds = minutes * 60;
            uint milliseconds = seconds * 1000;
            uint microseconds = milliseconds * 1000;
            uint nanoseconds = microseconds * 1000;
            Console.WriteLine($"{a} centuries = {years} years = {days} days = {hours }hours = {minutes} minutes = {seconds} seconds = {milliseconds} milliseconds = {microseconds} microseconds = {nanoseconds} nanoseconds");

        }
    }
}

