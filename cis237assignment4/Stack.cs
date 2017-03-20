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
        // create a new node class within this class
        protected class Node
        {
            public T Data { get; set; }
            public Node Next { get; set; }
        }

        protected Node _head; // head node
        protected Node _tail; // tail node
        protected int _size; // variable to store the size

        // check if the list is empty
        public bool IsEmpty
        {
            get
            {
                return _head == null;
            }
        }


        // get the size ofthe list
        public int Size
        {
            get
            {
                return _size;
            }
        }


        // add to the front of the list
        public void AddToFront(T Data) // push
        {
            Node oldHead = _head; // assigne the head to the old head

            _head = new Node(); // create the new head node

            _head.Data = Data; // assigne the new head node some data

            _head.Next = oldHead; // set the old head to the next head

            _size++;    // increment the size

            if (_size == 1) // check if there is only 1 node, if so then the head and tail are the same
            {
                _tail = _head;
            }
        }

        // remove from the front
        public T RemoveFromFront() // pop
        {
            // check if the node is empty
            if (IsEmpty)
            {
                throw new Exception("List is empty");
            }

            T returnData = _head.Data;  // return the data from the head

            _head = _head.Next; // set the next head to head

            _size--; // decrement the size

            // check if it's empty, if so then assign null to the 
            if (IsEmpty)
                _tail = null;

            return returnData; // return the data
        }

        // display all node's data
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
