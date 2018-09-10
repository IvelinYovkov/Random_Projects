using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearDataStructures
{
    class Node<T>
    {
        public T Element { get; set; }
        public Node<T> NextNode { get; set; }

        public Node(T element)
        {
            this.Element = element;
            this.NextNode = null;
        }
    }
}
