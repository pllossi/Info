using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StruttureDati
{
    public class MyQueue<T>
    {
        private List<T> elements;
        public MyQueue()
        {
            elements = new List<T>();
        }

        public void Enqueue(T item)
        {
            elements.Add(item);
        }
        public T Dequeue()
        {
            if (elements.Count == 0)
                throw new InvalidOperationException("Queue is empty.");
            T item = elements[0];
            elements.RemoveAt(0);
            return item;
        }
        public T Peek()
        {
            if (elements.Count == 0)
                throw new InvalidOperationException("Queue is empty.");
            return elements[0];
        }
    }
}
