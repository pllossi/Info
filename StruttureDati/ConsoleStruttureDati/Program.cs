using StruttureDati;
using System;
using System.Diagnostics;

namespace ConsoleStruttureDati
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var stack = new MyStack<int>();
            var queue = new MyQueue<int>();

            Console.WriteLine("=== Test MyStack<int> ===");
            Console.WriteLine("Push: 1, 2, 3");
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Console.WriteLine($"Peek() => {stack.Peek()}"); // aspettato: 3
            Console.WriteLine($"Pop()  => {stack.Pop()}");  // 3
            Console.WriteLine($"Pop()  => {stack.Pop()}");  // 2
            Console.WriteLine($"Pop()  => {stack.Pop()}");  // 1

            try
            {
                Console.WriteLine("Pop() su stack vuoto (atteso InvalidOperationException)...");
                stack.Pop();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Eccezione catturata: {ex.Message}");
            }

            Console.WriteLine();
            Console.WriteLine("=== Test MyQueue<int> ===");
            Console.WriteLine("Enqueue: 10, 20, 30");
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);

            Console.WriteLine($"Peek() => {queue.Peek()}"); // aspettato: 10
            Console.WriteLine($"Dequeue() => {queue.Dequeue()}"); // 10
            Console.WriteLine($"Dequeue() => {queue.Dequeue()}"); // 20
            Console.WriteLine($"Dequeue() => {queue.Dequeue()}"); // 30

            try
            {
                Console.WriteLine("Dequeue() su queue vuota (atteso InvalidOperationException)...");
                queue.Dequeue();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Eccezione catturata: {ex.Message}");
            }
        }
    }
}
