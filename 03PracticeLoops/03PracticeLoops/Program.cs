//What will happen if this code executes? 


/*
int max = 500;
for (byte i = 0; i < max; i++)
{
    WriteLine(i);
}

*/

using Microsoft.OData.Edm;

int max = 500;
for (byte i = 0; i < max; i++)
{
    Console.WriteLine(i);
    if (i == byte.MaxValue)
    {
        Console.WriteLine("Exceed maximum.End the loop.");
        break;
    }
}


Console.WriteLine("------------------------------------------------");
/* 02.
 * Write a program that generates a random number between 1 and 3 
 * and asks the user to guess what the number is. 
 * Tell the user if they guess low, high, or get the correct answer. 
 * Also, tell the user if their answer is outside of the range of numbers 
 *          that are valid guesses (less than 1 or more than 3).
 */




Random rnd = new Random();
int numb = rnd.Next(3) + 1;

String a;
Console.WriteLine("Please guess a number between 1 - 3");

a = Console.ReadLine();
int b = int.Parse(a);

if (numb == b)
{
    Console.WriteLine("You get the correct answer!");
}
else if (b > numb)
{
    Console.WriteLine("You guess high");
}
else { Console.WriteLine("you guess low"); }

Console.WriteLine("The number is " + numb);



Console.WriteLine("------------------------------------------------");


/* 03.
 * Print-a-Pyramid.Like the star pattern examples that we saw earlier,
 * create a program that will print the following pattern: If you find yourself getting stuck, 
 * try recreating the two examples that we just talked about in this chapter first. 
 * They’re simpler, and you can compare your results with the code included above. 
 * 
 */



int line = 3;


for (int i = 1; i <= line; i++)
{
    for (int j = 0; j <= line - i; j++)
    {
        Console.Write(" ");
    }

    for (int k = 1; k <= i * 2 - 1; k++)
    {
        Console.Write("*");
    }
    Console.WriteLine("");
}

Console.WriteLine("------------------------------------------------");




/* 04.
 * Write a simple program that defines a variable representing a birth date 
 * and calculates how many days old the person with that birth date is currently.
 * For extra credit, output the date of their next 10,000 day (about 27 years) anniversary. 
 * 
 */


Date today = DateTime.Today;

Console.WriteLine("When is you birthday? (Format:　Year-month-date)");

String bday = Console.ReadLine();

Date Birthday = Date.Parse(bday);

Console.WriteLine("Your birthday is " + Birthday);

TimeSpan myAge = DateTime.Now.Subtract(Birthday);

Console.WriteLine($"You are {myAge.Days} days old.");

int daysToNextAnniversary = 10000 - (myAge.Days % 10000);

Console.WriteLine("Days to next Anniversary: " + daysToNextAnniversary);

Console.WriteLine("------------------------------------------------");

/* 05.
 * Write a program that greets the user using the appropriate greeting 
 * for the time of day. Use onlyif, notelse orswitch, statements to do so. 
 * Be sure to include the following greetings:
 * "Good Morning"
 * "Good Afternoon"
 * "Good Evening"
 * "Good Night"
 */

DateTime time = new DateTime();
time = DateTime.Now;


if (time.Hour < 12)
{
    Console.WriteLine("Good Morning");
}else if (time.Hour < 17)
{
    Console.WriteLine("Good Afternoon");
}else if (time.Hour < 20)
{
    Console.WriteLine("Good Evening");
}
else
{
    Console.WriteLine("Good Night");
}


Console.WriteLine("------------------------------------------------");


/* 06.
 * Write a program that prints the result of counting up 
 * to 24 using four different increments. First, count by 1s,
 * then by 2s, by 3s, and finally by 4s.Use nestedfor loops with
 * your outer loop counting from 1 to 4. You inner loop should count from 0 to 24,
 * but increase the value of its /loop control variable/ by the value of the /loop control variable/ from the outer loop.
 * This means the incrementing in the /afterthought/ expression will be based on a variable.
 */

for (int i = 1; i <= 4; i++)
{
    for (int j = 0; j <= 24; j= j + i)
    {
        Console.Write(j);
        Console.Write(" ");
    }
    Console.WriteLine("");
}

