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

            //Console.WriteLine ("============= Singly Linked List =============");
            //SinglyLinkedList<int> ls = new SinglyLinkedList<int> ();
            //ls.Push (0);
            //ls.Push (1);
            //ls.Push (2);
            //ls.Push (3);
            //ls.Print ();
            //ls.Reverse ();
            //ls.Print ();
            //Console.WriteLine ($"Popped Value: {ls.Pop().Value}");
            //Console.WriteLine ($"Popped Value: {ls.Pop().Value}");
            //Console.WriteLine ($"Popped Value: {ls.Pop().Value}");
            //Console.WriteLine ($"Popped Value: {ls.Pop().Value}");
            //ls.Print ();

            #endregion

            #region " Stack "

            //Console.WriteLine("============= Stack =============");
            //Stack<int> data = new Stack<int>();
            //data.Push(1);
            //data.Push(2);
            //data.Push(3);
            //data.Push(4);

            //Console.WriteLine($"Number of elements in Stack is {data.Count}");
            //Console.WriteLine(data.Pop().Value);
            //Console.WriteLine(data.Pop().Value);
            //Console.WriteLine(data.Pop().Value);
            //Console.WriteLine(data.Pop().Value);
            //Console.WriteLine($"Number of elements in Stack is {data.Count}");

            #endregion

            #region " Queue "

            //Console.WriteLine("============= Queue =============");
            //Queue<int> data = new Queue<int>();
            //data.Enqueue(1);
            //data.Enqueue(2);
            //data.Enqueue(3);
            //data.Enqueue(4);

            //Console.WriteLine($"Number of elements in Queue is {data.Count}");
            //Console.WriteLine(data.Dequeue().Value);
            //Console.WriteLine(data.Dequeue().Value);
            //Console.WriteLine(data.Dequeue().Value);
            //Console.WriteLine(data.Dequeue().Value);
            //Console.WriteLine($"Number of elements in Queue is {data.Count}");

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