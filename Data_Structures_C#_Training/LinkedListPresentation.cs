using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearDataStructures
{
    public class LinkedListPresentation<T>
    {
        private Node<T> firstNode;
        private Node<T> currentNode;
        private int elementsCounter;
        private int maxId;

        public int Length
        {
            get { return this.elementsCounter; }
            private set { }

        }

        public int MaxID
        {
            get { return maxId; }
            private set { }
        }

        public LinkedListPresentation()
        {
            firstNode = null;
            currentNode = null;
            this.elementsCounter = 0;
        }

        public void Add(T forAdd)
        {
            //Creating new node to add to the linked list
            Node<T> add = new Node<T>(forAdd);

            if (elementsCounter == 0)
            {
                this.firstNode = add;
                this.currentNode = add;
            }
            else
            {
                this.currentNode.NextNode = add;
                this.currentNode = add;
            }

            this.elementsCounter++;
            maxId++;
        }

        public bool Remove(T elemtForRemove)
        {
            Node<T> temp = firstNode;

            if (temp == null)
            {
                Console.WriteLine("The List Is Empty");

                return false;
            }

            if (object.Equals(temp.Value,elemtForRemove))
            {

                firstNode = firstNode.NextNode;
                elementsCounter--;

                return true;
            }


            while (temp.NextNode != null)
            {
                if (object.Equals(temp.NextNode.Value, elemtForRemove))
                {
                    temp.NextNode = temp.NextNode.NextNode;
                    elementsCounter--;

                    return true;
                }

                temp = temp.NextNode;
            }

            Console.WriteLine($"There is no {elemtForRemove} in this list");

            return false;
        }

        public T GetElementAt(int index)
        {
            if (index >= maxId && index < 0)
            {
                throw new IndexOutOfRangeException("Invalid index: " + index); ;
            }
            else
            {
                Node<T> forReturn = this.firstNode;

                int cnt = 0;
                while (cnt != index)
                {
                    forReturn = forReturn.NextNode;
                    cnt++;
                }

                return forReturn.Value;

            }
        }

        public void printAll()
        {
            Node<T> temp = firstNode;

            if (elementsCounter == 0)
            {
                Console.WriteLine("The List Is Empty");
            }

            while (temp != null)
            {
                Console.WriteLine("Int : {0} ", temp.Value);
                temp = temp.NextNode;
            }
        }
    }
}
