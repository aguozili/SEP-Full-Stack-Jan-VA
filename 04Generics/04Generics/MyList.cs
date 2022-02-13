using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Create a Generic List data structure  MyList<T> that can store any data type.
 * Implement the following methods.
 * 1.void Add (T element)
 * 2.T Remove(int index)
 * 3.bool Contains(T element)
 * 4.void Clear()
 * 5.void InsertAt(T element, int index)
 * 6.void DeleteAt(int index)
 * 7.T  Find(int index)
 */

namespace _04Generics
{
    public class MyList<T>
    {
        public List<T> List { get; set; }

        public void Add(T element)
        {
            List.Add(element);
        }

        public T Remove(int index)
        {
            List.RemoveAt(index);
            return List[index];
        }

        public bool Contains(T element)
        {
            return List.Contains(element);
        }

        public void Clear()
        {
            List.Clear();
        }

        public void InsertAt(T element, int index)
        {
            List.Insert(index, element);
        }

        public void DeleteAt(int index)
        {
            List.RemoveAt(index);
        }

        public T Find(int index)
        {
            return List[index];
        }

    }
}
