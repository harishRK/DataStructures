using System;

namespace DataStructures.Stack {
    public class Node<T> {
        public T Value { get; set; }
        public Node<T> Next { get; set; }

        public Node(T value)
        {
            Value = value;
            Next = null;
        }
    }

    // We will be implementing stack using LinkedList.
    // Here we will be adding and removing the elements to stack from the top of the LinkedList
    public class Stack<T> {
        // Used to track the first element in the stack.
        private Node<T> Top { get; set; }

        /// <summary>
        /// Count of number of elements in the Stack
        /// </summary>
        public int Count { get; set; }

        public Stack()
        {
            Count = 0;
            Top = null;
        }

        /// <summary>
        /// Adds a new element to the top of the Stack
        /// </summary>
        /// <param name="value">Value to be added to the Stack</param>
        /// <returns>Returns the success of the operation</returns>
        public bool Push(T value)
        {
            //Create a new node
            Node<T> newNode = new Node<T>(value);
            if(Count == 0)
            {
                Top = newNode;
            }
            else
            {
                // Set Top with new node
                Node<T> temp = Top;
                newNode.Next = Top;
                Top = newNode;
            }
            // Increment the counter
            Count++;
            return true;
        }

        /// <summary>
        /// Removes an element from the top of the stack and returns its data.
        /// </summary>
        /// <returns>Returns the top Node<T></returns>
        public Node<T> Pop()
        {
            if (Count > 0)
            {
                // Remove Top node and change the Top to Top.Next
                Node<T> temp = Top;
                Top = Top.Next;
                temp.Next = null;

                // Decrement the counter
                Count--;

                return temp;
            }
            return null;
        }

        /// <summary>
        /// Used to find the top element of the Stack.
        /// </summary>
        /// <returns></returns>
        public Node<T> Peek()
        {
            if (Count > 0)
            {
                Node<T> temp = Top;
                temp.Next = null;

                return temp;
            }
            return null;
        }

    }
}