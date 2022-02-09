//Practice number sizes and ranges

/* 01
 * Create a console application project named /02UnderstandingTypes/ that outputs the 
 * number of bytes in memory that each of the following number types uses, and the minimum and 
 * maximum values they can have: sbyte, byte, short, ushort, int, uint, long, ulong, float, double, and decimal. 
 */

using _02UnderstandingTypes;

Console.WriteLine("sbyte - memory size: {0}, maxvalue: {1}, minvalue: {2}", sizeof(sbyte), sbyte.MaxValue, sbyte.MinValue);
Console.WriteLine("byte - memory size: {0}, maxvalue: {1}, minvalue: {2}", sizeof(byte), byte.MaxValue, byte.MinValue);
Console.WriteLine("short - memory size: {0}, maxvalue: {1}, minvalue: {2}", sizeof(short), short.MaxValue, short.MinValue);
Console.WriteLine("ushort - memory size: {0}, maxvalue: {1}, minvalue: {2}", sizeof(ushort), ushort.MaxValue, ushort.MinValue);
Console.WriteLine("int - memory size: {0}, maxvalue: {1}, minvalue: {2}", sizeof(int), int.MaxValue, int.MinValue);
Console.WriteLine("uint - memory size: {0}, maxvalue: {1}, minvalue: {2}", sizeof(uint), uint.MaxValue, uint.MinValue);
Console.WriteLine("long - memory size: {0}, maxvalue: {1}, minvalue: {2}", sizeof(long), long.MaxValue, long.MinValue);
Console.WriteLine("ulong - memory size: {0}, maxvalue: {1}, minvalue: {2}", sizeof(ulong), ulong.MaxValue, ulong.MinValue);
Console.WriteLine("float - memory size: {0}, maxvalue: {1}, minvalue: {2}", sizeof(float), float.MaxValue, float.MinValue);
Console.WriteLine("double - memory size: {0}, maxvalue: {1}, minvalue: {2}", sizeof(double), double.MaxValue, double.MinValue);
Console.WriteLine("decimal - memory size: {0}, maxvalue: {1}, minvalue: {2}", sizeof(decimal), decimal.MaxValue, decimal.MinValue);


Console.WriteLine("---------------------------------");

/* 02
 * Write program to enter an integer number of centuries 
 * and convert it to years, days, hours, minutes, seconds, milliseconds, microseconds, nanoseconds.  
 * Use an appropriate data type for every data conversion. Beware of overflows!
 */

Class1 c = new Class1();
string s = "sam";
c.CenturyConvert(2);