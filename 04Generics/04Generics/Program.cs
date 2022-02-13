

using _04Generics;

/*
 * 1.Describe the problem generics address.
 * 
 * Cannot declare static fields whose types are type parameters.
 * 
 * 2.How would you create a list of strings, using the generic List class?
 * 
 * List<strign> lstString = new List<string>
 * 
 * 3.How many generic type parameters does the Dictionary class have?
 * 
 * Dictionary<TKey,TValue> generic type has two type parameters, TKey and TValue , that represent the types of its keys and values.
 * 
 * 4.True/False. When a generic class has multiple type parameters, they must all match.
 * 
 * True
 * 
 * 5.What method is used to add items to a List object?
 * 
 * list.add()
 * 
 * 6.Name two methods that cause items to be removed from a List.
 * 
 * remove(item)
 * removeat(index)
 * 
 * 7.How do you indicate that a class has a generic type parameter?
 * 
 * a <T> has to come after the class name
 * 
 * 8.True/False. Generic classes can only have one generic type parameter.
 * 
 * False
 * 
 * 9.True/False. Generic type constraints limit what can be used for the generic type.
 * 
 * True
 * 
 * 10.True/False. Constraints let you use the methods of the thing you are constraining to.
 * 
 * True
 * 
 */





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



