using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataStructures.LinkedList;

namespace DataStructures {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine ("============= Singly Linked List =============");
            SinglyLinkedList<int> ls = new SinglyLinkedList<int> ();
            ls.Push (0);
            ls.Push (1);
            ls.Push (2);
            ls.Push (3);
            ls.Print ();
            ls.Reverse ();
            ls.Print ();
            Console.WriteLine ($"Popped Value: {ls.Pop().Value}");
            Console.WriteLine ($"Popped Value: {ls.Pop().Value}");
            Console.WriteLine ($"Popped Value: {ls.Pop().Value}");
            Console.WriteLine ($"Popped Value: {ls.Pop().Value}");
            ls.Print ();
        }
    }
}