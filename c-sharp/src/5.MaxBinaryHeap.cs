using System;
using System.Collections.Generic;

namespace DataStructures
{
    public class MaxBinaryHeap
    {
        public List<int> Values { get; private set; }

        public MaxBinaryHeap()
        {
            Values = new List<int>();
        }

        /// <summary>
        /// Adds a new element to the heap and balances it to be a maxHeap
        /// </summary>
        /// <param name="value">Integer value to be added to the maxHeap</param>
        /// <returns>Returns the success of the operation</returns>
        public bool Insert(int value)
        {
            if(Values.Count == 0)
            {
                Values.Add(value);
                return true;
            }

            // Add the new element to the end of the list
            Values.Add(value);

            // Find the correct spot for the new node in the max heap
            return BubbleUp();
        }

        private bool BubbleUp()
        {
            int elemIndex = Values.Count - 1;
            int element = Values[elemIndex];
            int parentIndex = (elemIndex - 1) / 2;

            // Loop through the heap until we find the correct spot for the element
            while(parentIndex >= 0 && element > Values[parentIndex])
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

        public int ExtractMax()
        {
            if(Values.Count == 0)
            {
                return -1; // Or throw an exception
            }

            int max = Values[0];
            // Move the last elemnt into the from of the list
            int last = Values[Values.Count - 1];
            Values.RemoveAt(Values.Count - 1);

            if(Values.Count > 0)
            {
                Values[0] = last;
                SinkDown();
            }
            return max;
        }

        private void SinkDown()
        {
            int index = 0;
            int nodeToSinkDown = Values[index];

            int leftChildIndex, rightChildIndex;
            int leftChildNode = int.MinValue;
            int rightChildNode = int.MinValue;
            int swapIndex = index;

            while (true)
            {
                bool swap = false;
                leftChildIndex = (2 * index) +1;
                rightChildIndex = (2 * index) + 2;

                // We need to compare node to sink with both left and right child and find the max between both.

                // Copmare the node to sink with left child if the left child index is valid
                if(leftChildIndex < Values.Count)
                {
                    leftChildNode = Values[leftChildIndex];
                    if(leftChildNode > nodeToSinkDown)
                    {
                        swap = true;
                        swapIndex = leftChildIndex;
                    }
                }

                // Copmare the node to sink with right child if the right child index is valid
                if(rightChildIndex < Values.Count)
                {
                    rightChildNode = Values[rightChildIndex];
                    if((!swap && rightChildNode > nodeToSinkDown) ||
                       (swap && rightChildNode > leftChildNode))
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
