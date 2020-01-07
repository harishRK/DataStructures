using System;
using System.Text;
using System.Linq;
using DataStructures.BST;
using DataStructures.LinkedList;
using DataStructures.Queue;
using DataStructures.Stack;

namespace DataStructures {
    class Program {
        static void Main (string[] args) {

            #region " Singly Linked List "

            Console.WriteLine ("============= Singly Linked List =============");
            SinglyLinkedList<int> ls = new SinglyLinkedList<int> ();
            ls.Push (0);
            ls.Push (1);
            ls.Push (2);
            ls.Push (3);
            Console.Write("Singly linked List: ");
            ls.Print ();
            Console.Write("Singly linked List Reversed: ");
            ls.Reverse ();
            ls.Print ();
            Console.WriteLine ($"Popped Value: {ls.Pop().Value}");
            Console.WriteLine ($"Popped Value: {ls.Pop().Value}");
            Console.WriteLine ($"Popped Value: {ls.Pop().Value}");
            Console.WriteLine ($"Popped Value: {ls.Pop().Value}");
            ls.Print ();

            #endregion

            #region " Stack "

            Console.WriteLine("============= Stack =============");
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);

            Console.WriteLine($"Number of elements in Stack is {stack.Count}");
            Console.WriteLine(stack.Pop().Value);
            Console.WriteLine(stack.Pop().Value);
            Console.WriteLine(stack.Pop().Value);
            Console.WriteLine(stack.Pop().Value);
            Console.WriteLine($"Number of elements in Stack is {stack.Count}");

            #endregion

            #region " Queue "

            Console.WriteLine("============= Queue =============");
            Queue<int> data = new Queue<int>();
            data.Enqueue(1);
            data.Enqueue(2);
            data.Enqueue(3);
            data.Enqueue(4);

            Console.WriteLine($"Number of elements in Queue is {data.Count}");
            Console.WriteLine(data.Dequeue().Value);
            Console.WriteLine(data.Dequeue().Value);
            Console.WriteLine(data.Dequeue().Value);
            Console.WriteLine(data.Dequeue().Value);
            Console.WriteLine($"Number of elements in Queue is {data.Count}");

            #endregion

            #region " Binary Search Tree "

            Console.WriteLine("============= Binary Search Tree =============");
            /*
                                    10
                                   /  \
                                  6   15
                                 / \  / \
                                3  8 11  20
                               /
                              0
             */
            BinarySearchTree myBST = new BinarySearchTree();
            myBST.AddToTree(10);
            myBST.AddToTree(6);
            myBST.AddToTree(15);
            myBST.AddToTree(3);
            myBST.AddToTree(8);
            myBST.AddToTree(11);
            myBST.AddToTree(20);
            myBST.AddToTree(0);
            Console.WriteLine($"BFS Traversal Data: ");
            PrintArray(myBST.BFS()); // 10,6,15,3,8,11,20,0

            Console.WriteLine($"DFS-PreOrder Traversal Data: ");
            PrintArray(myBST.DFS_PreOrder_Iterative()); // 10,6,3,0,8,15,11,20
            PrintArray(myBST.DFS_PreOrder_Recursive());

            Console.WriteLine($"DFS-InOrder Traversal Data: ");
            PrintArray(myBST.DFS_InOrder_Iterative()); // 10,6,3,0,8,15,11,20
            PrintArray(myBST.DFS_InOrder_Recursive());

            Console.WriteLine($"DFS-PostOrder Traversal Data: ");
            PrintArray(myBST.DFS_PostOrder_Iterative()); // 0,3,8,6,11,20,15,10 
            PrintArray(myBST.DFS_PostOrder_Recursive());
            #endregion

            #region " Max Binary Heap "

            Console.WriteLine("============= Max Binary Heap =============");
            MaxBinaryHeap maxHeap = new MaxBinaryHeap();
            maxHeap.Insert(18);
            maxHeap.Insert(27);
            maxHeap.Insert(12);
            maxHeap.Insert(39);
            maxHeap.Insert(33);
            maxHeap.Insert(41);
            PrintArray(maxHeap.Values);
            Console.WriteLine(maxHeap.ExtractMax());
            Console.WriteLine(maxHeap.ExtractMax());
            Console.WriteLine(maxHeap.ExtractMax());
            Console.WriteLine(maxHeap.ExtractMax());
            Console.WriteLine(maxHeap.ExtractMax());
            Console.WriteLine(maxHeap.ExtractMax());

            #endregion

            #region " Min Binary Heap "

            Console.WriteLine("============= Min Binary Heap =============");
            MinBinaryHeap minHeap = new MinBinaryHeap();
            minHeap.Insert(18);
            minHeap.Insert(27);
            minHeap.Insert(12);
            minHeap.Insert(39);
            minHeap.Insert(33);
            minHeap.Insert(41);
            PrintArray(minHeap.Values);
            Console.WriteLine(minHeap.ExtractMin());
            Console.WriteLine(minHeap.ExtractMin());
            Console.WriteLine(minHeap.ExtractMin());
            Console.WriteLine(minHeap.ExtractMin());
            Console.WriteLine(minHeap.ExtractMin());
            Console.WriteLine(minHeap.ExtractMin());

            #endregion

            #region " Priority Queue "

            Console.WriteLine("============= Priority Queue =============");

            PriorityQueue queue = new PriorityQueue();
            queue.Enqueue("common cold", 1);
            queue.Enqueue("knife stab", 5);
            queue.Enqueue("high fever", 3);
            queue.Enqueue("dislocated arm", 4);
            queue.Enqueue("flu", 2);
            Console.WriteLine(queue.Dequeue().Value);
            Console.WriteLine(queue.Dequeue().Value);
            Console.WriteLine(queue.Dequeue().Value);
            Console.WriteLine(queue.Dequeue().Value);
            Console.WriteLine(queue.Dequeue().Value);

            #endregion

            Console.ReadLine();
        }


        public static void PrintArray(System.Collections.Generic.List<int> data)
        {
            if(data != null)
            {
                StringBuilder str = new StringBuilder();
                foreach (var ele in data)
                {
                    str.Append(ele.ToString() + " ");
                }

                Console.WriteLine(str.ToString());
            }
        }
    }
}