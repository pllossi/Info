using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StruttureDati
{
    public class MyStack<T>
    {
        private List<T> elements;
        public MyStack()
        {
            elements = new List<T>();
        }
        public void Push(T item)
        {
            elements.Add(item);
        }
        public T Pop()
        {
            if (elements.Count == 0)
                throw new InvalidOperationException("Stack is empty.");
            T item = elements[elements.Count - 1];
            elements.RemoveAt(elements.Count - 1);
            return item;
        }
        public T Peek()
        {
            if (elements.Count == 0)
                throw new InvalidOperationException("Stack is empty.");
            return elements[elements.Count - 1];
        }
    }
}
