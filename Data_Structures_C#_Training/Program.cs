using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace LinearDataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfElementsForTest = 10000;

            //Array
            Console.WriteLine("------------Array List------------");

            var arr = new ArrayList<int>();


            arr.AddToEnd(0);
            arr.AddToEnd(1);

            Stopwatch swArrAdd = new Stopwatch();

            swArrAdd.Start();
            for (int i = countOfElementsForTest; i > 0; i--)
            {
                arr.AddAtPosition(1, i);
            }

            swArrAdd.Stop();

            Console.WriteLine("Adding 1000 elements in the middle of array : {0}", swArrAdd.Elapsed);

            Stopwatch swGet = new Stopwatch();
            swGet.Start();
            int temp = arr.GetElementAt(arr.Count - 1);
            swGet.Stop();
            Console.WriteLine("Getting element at the end of array : {0} {1}", swGet.Elapsed, temp);

            Stopwatch swArrRemove = new Stopwatch();

            swArrRemove.Start();
            for (int i = 0; i < countOfElementsForTest; i++)
            {
                arr.RemoveAt(1);
            }
            swArrRemove.Stop();

            Console.WriteLine("Removing 1000 elements in the middle of array : {0}", swArrRemove.Elapsed);


            //Linked List
            Console.WriteLine("------------Linked List------------");


            var lst = new LinkedListPresentation<int>();

            lst.Add(0);
            lst.Add(1);

            Stopwatch swLstAdd = new Stopwatch();

            swLstAdd.Start();
            for (int i = countOfElementsForTest; i > 0; i--)
            {
                lst.AddAt(i, 1);
            }

            swLstAdd.Stop();

            Console.WriteLine("Adding 1000 elements in the middle of list : {0}", swLstAdd.Elapsed);

            Stopwatch swGetLst = new Stopwatch();
            swGetLst.Start();
            temp = lst.GetElementAt(lst.Count - 1);
            swGetLst.Stop();
            Console.WriteLine("Getting element at the end of list : {0} {1}", swGetLst.Elapsed, temp);

            Stopwatch swLstRemove = new Stopwatch();

            swLstRemove.Start();
            for (int i = 0; i < countOfElementsForTest; i++)
            {
                lst.RemoveAt(1);
            }
            swLstRemove.Stop();

            Console.WriteLine("Removing 1000 elements in the middle of list : {0}", swLstRemove.Elapsed);


            //Stack
            Console.WriteLine("------------Stack------------");

            var stack = new Stack<int>();

            for (int i = 0; i < 20; i++)
            {
                stack.Push(i);
            }

            for (int i = 0; i < 20; i++)
            {
                //Console.WriteLine(stack.Peek());
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
                //Console.WriteLine(queue.Peek());
                queue.Dequeue();
            }
        }
    }
}
