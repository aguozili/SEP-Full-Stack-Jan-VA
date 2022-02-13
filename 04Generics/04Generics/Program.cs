

using _04Generics;


/*
 * Create a custom Stack class  MyStack<T> that can be used with any data type which has following methods
 * 1.int Count()
 * 2.T Pop()
 * 3.Void Push()
 */


MyStack<int> stack = new MyStack<int>();

stack.Stack = new Stack<int>();

stack.Push(1);
stack.Push(2);
stack.Push(3);
stack.Push(4);

foreach (int i in stack.Stack)
{
    Console.WriteLine(i);
}

Console.WriteLine("---------------");
stack.Pop();
foreach (int i in stack.Stack)
{
    Console.WriteLine(i);
}



MyList<int> list = new MyList<int>();
list.List = new List<int>();

list.Add(1);
list.Add(2);
list.Add(3);
list.Add(4);
list.Add(5);
list.Add(6);
list.Add(7);
list.Add(8);
list.Add(9);
list.Add(10);

foreach(int i in list.List)
{
    Console.WriteLine(i);
}

Console.WriteLine("-----------------------");

Console.WriteLine(list.Find(3));

list.InsertAt(50, 3);

Console.WriteLine("----------");

foreach (int i in list.List)
{
    Console.WriteLine(i);
}



