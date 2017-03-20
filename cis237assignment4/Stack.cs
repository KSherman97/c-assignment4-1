// Kyle Sherman
// Assignment 4
// Due 3/20/17

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    class Stack<T>
    {
        protected class Node
        {
            public T Data { get; set; }
            public Node Next { get; set; }
        }

        protected Node _head;
        protected Node _tail;
        protected int _size;

        public bool IsEmpty
        {
            get
            {
                return _head == null;
            }
        }

        public int Size
        {
            get
            {
                return _size;
            }
        }

        public void AddToFront(T Data) // push
        {
            Node oldHead = _head;

            _head = new Node();

            _head.Data = Data;

            _head.Next = oldHead;

            _size++;

            if (_size == 1)
            {
                _tail = _head;
            }
        }

        public T RemoveFromFront() // pop
        {
            if (IsEmpty)
            {
                throw new Exception("List is empty");
            }

            T returnData = _head.Data;

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

            while (currentNode != null)
            {
                Console.WriteLine(currentNode.Data);
                currentNode = currentNode.Next;
            }
        }
    }
}
