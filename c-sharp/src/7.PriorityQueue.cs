using System;
using System.Collections.Generic;

namespace DataStructures
{
    /// <summary>
    /// Priroty queue based on max heap. First element that will be returned will always the node with highest priority
    /// </summary>
    public class PriorityQueue
    {
        public class Node
        {
            public string Value { get; set; }
            public int Priority { get; set; }

            public Node(string val, int p)
            {
                Value = val;
                Priority = p;
            }
        }

        public List<Node> Values { get; set; }

        public PriorityQueue()
        {
            Values = new List<Node>();
        }

        /// <summary>
        /// Adds a new element to the queue and balances it to be a max Heap
        /// </summary>
        /// <param name="value">Integer value to be added to the maxHeap</param>
        /// <returns>Returns the success of the operation</returns>
        public bool Enqueue(string value, int priority)
        {
            if (Values.Count == 0)
            {
                Values.Add(new Node(value, priority));
                return true;
            }

            // Add the new element to the end of the list
            Values.Add(new Node(value, priority));

            // Find the correct spot for the new node in the max heap
            return BubbleUp();
        }

        private bool BubbleUp()
        {
            int elemIndex = Values.Count - 1;
            Node element = Values[elemIndex];
            int parentIndex = (elemIndex - 1) / 2;

            // Loop through the heap until we find the correct spot for the element
            while (parentIndex >= 0 && element.Priority > Values[parentIndex].Priority)
            {
                // Swap the element with the parent
                Values[elemIndex] = Values[parentIndex];
                Values[parentIndex] = element;

                // Set the index to the new values
                elemIndex = parentIndex;
                parentIndex = (elemIndex - 1) / 2;
            }

            return true;
        }

        // Returns the node with highest priority
        public Node Dequeue()
        {
            if(Values.Count == 0)
            {
                return null; // Or throw an exception
            }

            Node max = Values[0];
            // Move the last elemnt into the from of the list
            Node last = Values[Values.Count - 1];
            Values.RemoveAt(Values.Count - 1);

            if (Values.Count > 0)
            {
                Values[0] = last;
                SinkDown();
            }
            return max;
        }

        private void SinkDown()
        {
            int index = 0;
            Node nodeToSinkDown = Values[index];

            int leftChildIndex, rightChildIndex;
            Node leftChildNode = null;
            Node rightChildNode = null;
            int swapIndex = index;

            while (true)
            {
                bool swap = false;
                leftChildIndex = (2 * index) + 1;
                rightChildIndex = (2 * index) + 2;

                // We need to compare node to sink with both left and right child and find the max between both.

                // Copmare the node to sink with left child if the left child index is valid
                if (leftChildIndex < Values.Count)
                {
                    leftChildNode = Values[leftChildIndex];
                    if (leftChildNode.Priority > nodeToSinkDown.Priority)
                    {
                        swap = true;
                        swapIndex = leftChildIndex;
                    }
                }

                // Copmare the node to sink with right child if the right child index is valid
                if (rightChildIndex < Values.Count)
                {
                    rightChildNode = Values[rightChildIndex];
                    if ((!swap && rightChildNode.Priority > nodeToSinkDown.Priority) ||
                       (swap && rightChildNode.Priority > leftChildNode.Priority))
                    {
                        swap = true;
                        swapIndex = rightChildIndex;
                    }
                }

                // If there was no swap required, we found the correct spot for the node to sink.
                // Break the loop and return.
                if (!swap)
                {
                    return;
                }

                // Swap the node to sink with the max child node between its left and right childs
                Values[index] = Values[swapIndex];
                Values[swapIndex] = nodeToSinkDown;
                index = swapIndex;
            }
        }
    }
}
