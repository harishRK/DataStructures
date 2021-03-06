﻿using System;

namespace DataStructures.Queue
{
    public class QNode<T>
    {
        public T Value { get; set; }
        public QNode<T> Next { get; set; }

        public QNode(T value)
        {
            Value = value;
            Next = null;
        }
    }

    // We will be implementing Queue using LinkedList.
    // Here we will be adding the elements to the end of the list and removing the elements from the top of the list
    public class Queue<T>
    {
        // Used to track the first element in the stack.
        private QNode<T> Head { get; set; }

        // Used to track the end of the list
        private QNode<T> Tail { get; set; }

        /// <summary>
        /// Count of number of elements in the Stack
        /// </summary>
        public int Count { get; set; }

        public Queue()
        {
            Count = 0;
            Head = null;
            Tail = null;
        }

        /// <summary>
        /// Adds a new element to the end of the Queue
        /// </summary>
        /// <param name="value">Value to be added to the Queue</param>
        /// <returns>Returns the success of the operation</returns>
        public bool Enqueue(T value)
        {
            //Create a new node
            QNode<T> newNode = new QNode<T>(value);
            if (Count == 0)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                // Set Top with new node
                Tail.Next = newNode;
                Tail = newNode;
            }
            // Increment the counter
            Count++;
            return true;
        }

        /// <summary>
        /// Removes an element from the begining of the Queue and returns its data.
        /// </summary>
        /// <returns>Returns the top Node<T></returns>
        public QNode<T> Dequeue()
        {
            if (Count > 0)
            {
                // Remove Top node and change the Top to Top.Next
                QNode<T> temp = Head;
                Head = Head.Next;
                temp.Next = null;

                // Decrement the counter
                Count--;

                return temp;
            }
            return null;
        }

        /// <summary>
        /// Used to find the first element in the Queue.
        /// </summary>
        /// <returns></returns>
        public QNode<T> Peek()
        {
            if (Count > 0)
            {
                QNode<T> temp = Head;
                temp.Next = null;

                return temp;
            }
            return null;
        }

    }
}