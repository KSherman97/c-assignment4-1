using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    class Queue<Droid>
    {
        protected class Node
        {
            public Droid Data { get; set; }
            public Node Next { get; set; }
        }

        protected Node _head;
        protected Node _tail;
        protected int _size;

        public bool IsEmpty
        {
            get { return _head == null; }
        }

        public int Size
        {
            get { return _size; }
        }

        public void AddToBack(Droid Data)
        {
            Node oldTail = _tail;
            _tail = new Node();
            _tail.Data = Data;
            _tail.Next = null;

            if (IsEmpty)
                _head = _tail;
            else
                oldTail.Next = _tail;
        }

        public Droid RemoveFromFront()
        {
            if (IsEmpty)
                throw new Exception("List is empty");

            Droid returnData = _head.Data;

            _head = _head.Next;
            _size--;

            if (IsEmpty)
                _tail = null;

            return returnData;
        }

        public void Display()
        {
            Console.WriteLine("The list is: ");
            Node currentNode = _head;
            while(currentNode != null)
            {
                Console.WriteLine(currentNode.Data);
                currentNode = currentNode.Next;
            }
        }
    } 
}
