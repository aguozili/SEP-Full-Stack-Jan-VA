using System.Collections;

/* 01.
 * Write a program that reads a string from the console, 
 * reverses its letters and prints the result back at the console.
 * Write in two waysConvert the string to char array, reverse it, 
 * then convert it to string againPrint the letters of the string in back direction 
 * (from the last to the first) in a for-loop
 */



//String str = Console.ReadLine();
//char[] characters = str.ToCharArray();
//char[] char2 = new char[characters.Length];

//for (int i = 0; i < characters.Length; i++)
//{
//    char2[i] = characters[characters.Length - 1 - i];
//}

//String str2 = String.Join("", char2);

//Console.WriteLine(str2);



string ReverseStringOne(String s)
{
    char[] charStr = s.ToCharArray();

    for (int i = 0, j = charStr.Length - 1; i < j; i++, j--)
    {
        char c = charStr[i];
        charStr[i] = charStr[j];
        charStr[j] = c;
    }
    string res = new string(charStr);
    return res;
}

string b = "banana";
Console.WriteLine(ReverseStringOne(b));



/* 02.
 * Write a program that reverses the words in a given sentence without changing the punctuation and spaces
 */


String str = "hello, food! asd. ff!";
String str2 = String.Join(" ", str.Split(' ').Reverse()).ToString();
Console.WriteLine(str2);




/* 03.
 * Write a program that extracts from a given text all  palindromes, 
 * e.g. “ABBA”, “lamal”, “exe” and prints them on the console on a single line, 
 * separated by comma and space.Print all unique palindromes (no duplicates), sorted
 */




String s = "hello, goodbye, hi! auua, exe";
string[] sentence = s.Split(' ', ',', '!');

foreach (var item in sentence)
{
    Console.Write(" " + item);

}

Console.WriteLine("");
Console.WriteLine(sentence[2]);

ArrayList arrlist = new ArrayList();



for (int i = 0; i < sentence.Length; i++)
{
    char[] char1 = sentence[i].ToCharArray();
    char[] char2 = new char[char1.Length];

    if (char2.Equals(" "))
    {
        continue;
    }

    for (int j = 0; i < char1.Length; j++)
    {
        char2[j] = char1[char1.Length - 1 - j];
    }

    String str2 = String.Join("", char2);

    if (str2.Equals(sentence[i]))
    {
        arrlist.Add(sentence[i]);
    }

}

Console.WriteLine(arrlist);



/* 04.
 * Write a program that parses an URL given in the following format:[protocol]://[server]/[resource]
 */



String url1 = "http://www.apple.com/iphone";
string[] url2 = url1.Split(new[] { '/', ':' }, StringSplitOptions.RemoveEmptyEntries);




if (url2.Length == 1)
{
    Console.WriteLine("protocol = ");
    Console.WriteLine("server = " + url2[0]);
    Console.WriteLine("resource = ");
}
else if (url2.Length == 2)
{
    Console.WriteLine("protocol = ");
    Console.WriteLine("server = " + url2[0]);
    Console.WriteLine("resource = " + url2[1]);
}
else if (url2.Length == 3)
{
    Console.WriteLine("protocol = " + url2[0]);
    Console.WriteLine("server = " + url2[1]);
    Console.WriteLine("resource = " + url2[2]);
}






