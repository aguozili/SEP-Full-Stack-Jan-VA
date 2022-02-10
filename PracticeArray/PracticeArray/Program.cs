/* 01.
 * Copying an ArrayWrite code to create a copy of an array. 
 * First, start by creating an initial array. (You can use whatever type of data you want.) 
 * Let’s start with 10 items. Declare an array variable and assign it a new array with 10 items in it.
 * Use the things we’ve discussed to put some values in the array. Now create a second array variable. 
 * Give it a new array with the same length as the first. Instead of using a number for this length,
 * use the Lengthproperty to get the size of the original array. Use a loop to read values from the 
 * original array and place them in the new array. Also print out the contents of both arrays, 
 * to be sure everything copied correctly. 
 */

using System.Collections;
using System.Text;

int[] a = new int[] { 1, 8, 5, 6, 2, 8, 5, 6, 6 , 10};


int[] b = new int[a.Length];



for (int i = 0; i < a.Length; i++)
{
    b[i] = a[i];
}


Console.WriteLine("Array a: ");
for (int i = 0; i < a.Length; i++)
{
    Console.Write(a[i]);
    Console.Write(" ");
}
Console.WriteLine("");
Console.WriteLine("Array b: ");
for (int i = 0; i < b.Length; i++)
{
    Console.Write(b[i]);
    Console.Write(" ");
}

Console.WriteLine("");
Console.WriteLine("-------------------------------------------");




/* 02.
 * Write a simple program that lets the user manage a list of elements. 
 * It can be a grocery list, "to do" list, etc. 
 * Refer to Looping Based on a Logical Expression if necessary to see how to implement an infinite loop. 
 * Each time through the loop, ask the user to perform an operation, and then show the current contents of their list. 
 * The operations available should be Add, Remove, and Clear. The syntax should be as follows:
 * + some item
 * - some item
 * --
 */






ArrayList GroceryList = new ArrayList();

while (true)
{
    Console.WriteLine("what do you need for grocery list? +, -, --");
    string read = Console.ReadLine();

    if (read.Substring(0, 1).Equals("+"))
    {
        GroceryList.Add(read.Substring(2));

    }
    else if (read.Substring(0, 2).Equals("- "))
    {
        GroceryList.Remove(read.Substring(2));

    }
    else if (read.Equals("--"))
    {
        Console.WriteLine("Your grocery list: ");
        foreach (var item in GroceryList)
        {
            Console.Write($"{item} ");
        }
        break;
    }
    else { break; }
}



/* 03.
 * Write a method that calculates all prime numbers in given range and returns them as array of integers
 */






static int[] FindPrimesInRange(int StartNum, int EndNum)
{
    int[] array = new int[] {};

    for (int i = StartNum; i <= EndNum; i++)
    {
        int flag = 0;

        int len = i / 2;

        for (int j = 2; j <= len; j++)
        {
            if (i % j == 0)
            {
                flag = 1;
            }
        }

        if (flag == 0)
        {
            array = array.Concat(new int[] { i }).ToArray();
        }
    }

    return array;
}

foreach (var item in FindPrimesInRange(2, 5))
{
    Console.Write($"{item} ");
}



Console.WriteLine();
Console.WriteLine("-------------------------------");




/* 04.
 * Write a program to read an array of nintegers (space separated on a single line) 
 * and an integer k, rotate the array right ktimes and sum the obtained arrays after each rotation as shown below.
 */



static int[] RotateArraySum(int[] array, int k)
{
    int[] rotated1 = RotateArray(array).ToArray();

    int len = rotated1.Length;

    for (int i = 0; i < k - 1; i++)
    {
        for (int j = 0; j < len - 1; j++)
        {
            rotated1[j] = rotated1[j] + rotated1[(i + len - 1) % (len - 1)];
        }

    }

    return rotated1;
}


static int[] RotateArray(int[] array)
{
    int[] newarray = new int[array.Length];
    for (int i = 0; i < array.Length - 1; i++)
    {
        newarray[i + 1] = array[i];
    }
    newarray[0] = array[array.Length - 1];

    return newarray;
}


int[] test = new int[] { 3, 2, 4 };
RotateArraySum(test, 2);



foreach (var item in RotateArraySum(test, 2))
{
    Console.Write($"{item} ");
}

Console.WriteLine("-------------------------------");






/* 05.
 * Write a program that finds the longest sequence of equal elements in an array of integers. If several longest sequences exist, print the leftmost one.
 */



static int[] longestele(int[] array)
{

    int maxnum = 0;
    int count = 0;
    int n = 0;

    for (int i = 0; i < array.Length; i++)
    {
        if (i != 0 && array[i] == array[i - 1])
        {
            count++;
        }
        else
        {
            if (count > maxnum)
            {
                maxnum = count + 1;
                n = array[i - 1];
                count = 0;
            }
            count = 0;
        }
    }

    int[] newarr = new int[maxnum];

    for (int i = 0; i < maxnum; i++)
    {
        newarr[i] = n;
    }

    return newarr;
}


int[] arr = new int[] { 1, 4, 6, 7, 7, 7, 10, 11 };
longestele(arr);

foreach (var item in longestele(arr))
{
    Console.Write($"{item} ");
}


/* 07.
 * Write a program that finds the most frequent number in a given sequence of numbers.  
 * In case of multiple numbers with the same maximal frequency, print the leftmost of them
 */




static int frequent(int[] arr)
{
    int maxValue = arr.Max();
    int[] countlist = new int[maxValue+1];

    for (int i = 0; i < countlist.Length; i++)
    {
        countlist[i] = 0;
    }

    for (int i = 0; i < arr.Length; i++)
    {
        countlist[arr[i]]++;
    }

    int max = 0;
    int maxIndex = 0;
    for (int i = 0; i < countlist.Length; i++)
    {
        if (countlist[i] > max)
        {
            max = countlist[i];
            maxIndex = i;
        }
    }
    return maxIndex;
}

int[] arr = new int[] { 2, 3, 2, 2, 2, 13, 3, 3, 3, 3, 3, 3, 3 };
Console.WriteLine(frequent(arr));