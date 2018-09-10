using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearDataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            //Array
            Console.WriteLine("------------Array List------------");
            var arr = new ArrayList<int>();

            arr.AddToEnd(0);
            arr.AddToEnd(20);

            for (int i = 19; i > 0; i--)
            {
                arr.AddAtPosition(1, i);
            }

            arr.print();

            for (int i = 0; i < 5; i++)
            {
                arr.RemoveAt(11);
            }

            arr.print();

            //Linked List
            Console.WriteLine("------------Linked List------------");

            //Stack
            Console.WriteLine("------------Stack------------");

            var stack = new Stack<int>();

            for (int i = 0; i < 20; i++)
            {
                stack.Push(i);
            }

            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine(stack.Peek());
                stack.Pop();
            }

            //Queue
            Console.WriteLine("------------Queue------------");

            var queue = new Queue<int>();

            for (int i = 0; i < 20; i++)
            {
                queue.Enqueue(i);
            }

            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine(queue.Peek());
                queue.Dequeue();
            }
        }
    }
}
