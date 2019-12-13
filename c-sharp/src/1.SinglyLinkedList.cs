using System;
using System.Text;

namespace DataStructures.LinkedList {
    public class Node<T> {
        public T Value { get; set; }
        public Node<T> Next { get; set; }

        public Node (T value) {
            this.Value = value;
            this.Next = null;
        }
    }

    public class SinglyLinkedList<T> {
        #region Properties

        public int Length { get; set; }

        public Node<T> Head { get; set; }

        public Node<T> Tail { get; set; }

        #endregion

        public SinglyLinkedList () {
            this.Length = 0;
            this.Head = null;
            this.Tail = null;
        }

        /// <summary>
        /// Adds a node at the end of the linked list
        /// </summary>
        /// <param name="value">Value for the new node that needs to be added the linked list</param>
        public bool Push (T value) {
            Node<T> newNode = new Node<T> (value);

            if (this.Length == 0) {
                this.Head = newNode;
                this.Tail = newNode;
            } else {
                this.Tail.Next = newNode;
                this.Tail = newNode;
            }
            this.Length++;
            return true;
        }

        /// <summary>
        /// Removes a node at the end of the linked list and returns the node
        /// </summary>
        public Node<T> Pop () {
            if (this.Length == 0) {
                return null;
            } else if (this.Head == this.Tail) {
                var temp = this.Head;
                this.Head = null;
                this.Tail = null;
                this.Length--;

                return temp;
            } else {
                // Find the node just before the tail node
                Node<T> prevNode = null;
                Node<T> currentNode = this.Head;
                while (currentNode.Next != null) {
                    prevNode = currentNode;
                    currentNode = currentNode.Next;
                }
                // Set the tail to the previous node
                var temp = this.Tail;
                this.Tail = prevNode;
                this.Tail.Next = null;
                this.Length--;

                return temp;
            }
        }

        /// <summary>
        /// Removes a node from the beginning of the list and returns the node.
        /// </summary>
        public Node<T> Shift () {
            if (this.Length == 0) return null;
            else if (this.Head == this.Tail) {
                var temp = this.Head;
                this.Head = null;
                this.Tail = null;
                this.Length = 0;

                return temp;
            } else {
                var temp = this.Head;
                this.Head = temp.Next;
                temp.Next = null;
                this.Length--;

                return temp;
            }
        }

        /// <summary>
        /// Adds a node at the begining of the linked list
        /// </summary>
        /// <param name="value">Value for the new node that needs to be added the linked list</param>
        public bool UnShift (T value) {
            Node<T> newNode = new Node<T> (value);
            if (this.Length == 0) {
                this.Head = newNode;
                this.Tail = newNode;
            } else {
                newNode.Next = this.Head;
                this.Head = newNode;
            }
            this.Length++;
            return true;
        }

        ///<summary>
        ///Returns the node at the specified index of the linked list.
        ///If index = 0; first element in the list is returned.
        ///If index = 3; fourth element in the list is returned.
        /// </summary>
        /// <param name="index">Index of the node to be retrieved</param>
        public Node<T> Get (int index) {
            if (this.Length == 0 || index < 0 || index > this.Length - 1) return null;

            var currentNode = this.Head;
            for (int i = 1; i <= index; i++) {
                currentNode = currentNode.Next;
            }
            return currentNode;
        }

        /// <summary>
        /// Updates the value of the node at the specified index.
        /// If index = 0; first element in the list is returned.
        /// If index = 3; fourth element in the list is returned.
        /// </summary>
        /// <param name="index">Index of the node to be updated</param>
        /// <param name="newValue">New value for the node to be updated</param>
        public bool Set (int index, T newValue) {
            var node = this.Get (index);
            if (node == null) {
                return false;
            } else {
                node.Value = newValue;
                return true;
            }
        }

        /// <summary>
        /// Inserts a new node at the specified index.
        /// </summary>
        /// <param name="index">Index of the node to be inserted</param>
        /// <param name="value">Value for the node to be inserted</param>
        public bool Insert (int index, T value) {
            if (index < 0 || index > this.Length) return false;

            if (index == 0) {
                this.UnShift (value);
                return true;
            } else if (index == this.Length) {
                this.Push (value);
                return true;
            } else {
                var newNode = new Node<T> (value);
                var pervNode = this.Get (index - 1);

                if (pervNode == null) {
                    return false;
                } else {
                    var nextNode = pervNode.Next;
                    pervNode.Next = newNode;
                    newNode.Next = nextNode;
                    this.Length++;

                    return true;
                }
            }
        }

        /// <summary>
        /// Removes a node at the specified index and returns the node.
        /// </summary>
        /// <param name="index">Index of the node to be removed</param>
        public Node<T> Remove (int index) {
            if (index < 0 || index > this.Length - 1) return null;
            if (index == 0) {
                return this.Shift ();
            } else if (index == this.Length - 1) {
                return this.Pop ();
            } else {
                var prevNode = this.Get (index - 1);
                var removedNode = prevNode.Next;
                prevNode.Next = removedNode.Next;
                removedNode.Next = null;
                this.Length--;

                return removedNode;
            }
        }

        /// <summary>
        /// Reverses the linked list. 1 -> 2 -> 3 -> 4
        /// </summary>
        public void Reverse () {
            if (this.Length != 0) {
                Node<T> prevNode = null;
                // Swap Head and Tail
                Node<T> currentNode = this.Head;
                this.Head = this.Tail;
                this.Tail = currentNode;

                // Reverse the list
                for (int i = 0; i < this.Length; i++) {
                    var nextNode = currentNode.Next;
                    currentNode.Next = prevNode;

                    prevNode = currentNode;
                    currentNode = nextNode;
                }
            }
        }

        public void Print () {
            StringBuilder data = new StringBuilder ();
            var currentNode = this.Head;
            while (currentNode != null) {
                data.Append (currentNode.Value + "   ");
                currentNode = currentNode.Next;
            }
            Console.WriteLine (data.ToString ());
        }
    }
}