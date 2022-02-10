/* 01.
 * Let’s make a program that uses methods to accomplisha task. 
 * Let’s take an array andreverse the contents of it. For example, 
 * if you have 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 
 * it would become 10, 9, 8, 7, 6, 5, 4, 3, 2, 1.
 * To accomplish this, you’ll create three methods: one to create the array, one to reverse the array, and one to print the array at the end.
 * 
 */

static int[] GenerateNumbers(int size)              //Function Generate an Array with random number
{
    int[] numbers = new int[size];
    for (int i = 0; i < size; i++)
    {
        Random rnd = new Random();
        numbers[i] = rnd.Next(10) + 1;
    }

    return numbers;
}

static int[] ReverseNumbers(int[] numbers)          //ReverseNumbers Function
{
    int len = numbers.Length;
    int[] newNum = new int[len];
    for (int i = 0; i < len; i++)
    {
        newNum[i] = numbers[len - 1 - i];
    }

    return newNum;
}

static void PrintNumbers(int[] numbers)             //Print out number using foreach
{
    foreach (int i in numbers)
    {
        Console.Write($"{i}, ");
    }
}

//demo

int[] a = GenerateNumbers(6);
PrintNumbers(a);
Console.WriteLine("");
Console.WriteLine("---");
PrintNumbers(ReverseNumbers(a));


/* 02.
 * The Fibonacci sequence is a sequence of numberswhere the first two numbers are 1 and  1,
 * and every other number in the sequence after it is the sum of the two numbers before it.  
 * Sothe third number is 1 + 1, which is 2. The fourth number is the 2nd number plus the 3rd,
 * which is 1 + 2. So the fourth number is 3. The 5th number is the 3rd number plus the 4th
 * number: 2 + 3 = 5. This keeps going forever.
 * The first few numbers of the Fibonacci sequence are: 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, ...
 * Because one number is defined by the numbers before it, this sets up a perfectopportunity 
 * for using recursion.Your mission, should you choose to accept it, is to create a method calledFibonacci,
 * whichtakes in a number and returns that number of the Fibonacci sequence. So if someone callsFibonacci(3),
 * it would return the 3rd number in theFibonacci sequence, which is 2. Ifsomeone callsFibonacci(8), it would return 21.
 */


static int Fibonacci(int num)
{
    if (num == 1)
    {
        return 1;
    }
    if (num == 0)
    {
        return 0;
    }

    return Fibonacci(num - 1) + Fibonacci(num - 2);
}


// Print first ten of Fibonaccit
for (int i = 1; i <= 10; i++)
{
    Console.WriteLine(Fibonacci(i));
}