// See https://aka.ms/new-console-template for more information


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

    //for (int i = 0; i < maxnum; i++)
    //{
    //    newarr[i] = n;
    //}

    Array.Fill(newarr, n);

    return newarr;
}


int[] arr = new int[] { 1, 4, 4, 4, 4, 4, 6, 4, 4, 6, 7, 7, 7, 10, 11 };
longestele(arr);

foreach (var item in longestele(arr))
{
    Console.Write($"{item} ");
}


Console.WriteLine("");
Console.WriteLine("-----------------------------");

/* 07.
 * Write a program that finds the most frequent number in a given sequence of numbers.  
 * In case of multiple numbers with the same maximal frequency, print the leftmost of them
 */




static int frequent(int[] arr)
{
    int maxValue = arr.Max();
    int[] countlist = new int[maxValue + 1];

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




void MostFrequentNumber(int[] arr)
{
    Dictionary<int, int> freq = new Dictionary<int, int>();
    Dictionary<int, int> firstOccurrence = new Dictionary<int, int>();
    int leftmost = int.MaxValue;
    for (int i = 0; i < arr.Length; i++)
    {
        if (!freq.ContainsKey(arr[i]))
        {
            freq.Add(arr[i], 1);
            firstOccurrence.Add(arr[i], i);
        }
        else
        {
            freq[arr[i]]++;
        }
    }
    int mostFreq = freq.Values.Max();
    int num = -1;
    foreach (var key in freq.Keys)
    {
        if (freq[key] == mostFreq && firstOccurrence[key] < leftmost)
        {
            leftmost = firstOccurrence[key];
            num = arr[leftmost];
        }
    }
    Console.WriteLine($"The number {num} is the most frequent (occurs {mostFreq} times)");
}


int[] arr2 = new int[] { 2, 3, 2, 13, 13, 13, 13, 13, 13, 13, 2, 2, 13, 3, 3 };
//Console.WriteLine(frequent(arr2));
MostFrequentNumber(arr2);