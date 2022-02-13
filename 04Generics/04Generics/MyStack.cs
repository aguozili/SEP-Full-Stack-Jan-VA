using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Create a custom Stack class  MyStack<T> that can be used with any data type which has following methods
 * 1.int Count()
 * 2.T Pop()
 * 3.Void Push()
 */


namespace _04Generics
{
    public class MyStack<T>
    {
        public Stack<T> Stack { get; set; }

        public int Count()
        {
            return Stack.Count;
        }

        public void Pop()
        {
            Stack.Pop();
        }

        public void Push(T a)
        {
            Stack.Push(a);
        }
    }
}
