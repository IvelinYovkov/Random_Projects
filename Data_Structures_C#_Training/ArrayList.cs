using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearDataStructures
{
    class ArrayList<T>
    {
        //Setting inital capacity
        private static int capacity = 4;
        private T[] arr;
        private int count;
        public int Count => this.count;        //C-tor
        public ArrayList()
        {
            this.arr = new T[capacity];
            this.count = 0;
        }

        //Methods

        private void Resize()
        {
            capacity *= 2;
            T[] temp = new T[capacity];

            for (int i = 0; i < count; i++)
                temp[i] = this.arr[i];

            this.arr = temp;
        }

        public void AddToEnd(T item)
        {
            if(count >= capacity)
                this.Resize();

            this.arr[this.count] = item;
            this.count++;
        }

        public void AddAtPosition(int index, T item)
        {
            if (index > this.count || index < 0)
            {
                throw new IndexOutOfRangeException("Invalid index: " + index);
            }

            if(count >= capacity)
                this.Resize();

            //Optional
            Array.Copy(this.arr, index, this.arr, index + 1, this.count - index);

            this.arr[index] = item;
            this.count++;
        }        public int IndexOf(T item)
        {
            for (int i = 0; i < this.arr.Length; i++)
            {
                if (object.Equals(item, this.arr[i]))
                {
                    return i;
                }
            }

            return -1;
        }        public T GetElementAt(int index)
        {
            if (index >= this.count || index < 0)
            {
                throw new ArgumentOutOfRangeException(
                "Invalid index: " + index);
            }

            return this.arr[index];
        }


        public void RemoveAt(int index)
        {
            if (index >= this.count || index < 0)
            {
                throw new ArgumentOutOfRangeException(
                 "Invalid index: " + index);
            }

            Array.Copy(this.arr, index + 1, this.arr, index, this.count - index - 1);

            this.arr[this.count - 1] = default(T);
            this.count--;
        }

        public void print()
        {
            for(int i = 0; i < count; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }
    }
}
