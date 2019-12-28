using System;
using System.Collections.Generic;

namespace DataStructures.BST
{
    public class TreeNode
    {
        public int Value { get; set; }

        public TreeNode Left { get; set; }

        public TreeNode Right { get; set; }

        public TreeNode(int value)
        {
            Value = value;
            Right = null;
            Left = null;
        }
    }


    public class BinarySearchTree
    {
        private List<int> DFSRecursiveData;
        public TreeNode Root { get; set; }

        public BinarySearchTree()
        {
            Root = null;
        }


        /// <summary>
        /// Adds new node to the BST
        /// </summary>
        /// <param name="value">Data to be added to the queue</param>
        /// <returns>Returns the success of the operation</returns>
        public bool AddToTree(int value)
        {
            TreeNode newNode = new TreeNode(value);

            // If tree is empty, set the new node to Root
            if(Root == null)
            {
                Root = newNode;
                return true;
            }

            // If tree is not empty, traverse the tree until we find the correct spot for the new node
            bool traversing = true;
            TreeNode currentNode = Root;
            while(traversing)
            {
                // Small values will be to the left
                if (newNode.Value < currentNode.Value)
                {
                    // Check to see if there is a left node already
                    if(currentNode.Left != null)
                    {
                        currentNode = currentNode.Left;
                    }
                    else
                    {
                        // Add new node to the left and return
                        currentNode.Left = newNode;
                        traversing = false;
                    }
                }
                // Large values will be to the right
                else if(newNode.Value > currentNode.Value)
                {
                    // Check to see if there is a right node already
                    if (currentNode.Right != null)
                    {
                        currentNode = currentNode.Right;
                    }
                    else
                    {
                        // Add new node to the left and return
                        currentNode.Right = newNode;
                        traversing = false;
                    }
                }
                //New node and current node are equal, Duplicates are not allowed in BST
                else
                {
                    traversing = false;
                }
            }
            return true;
        }

        /// <summary>
        /// Breadth First Search traversal.
        /// </summary>
        /// <returns>Returns the tree data in BFS order</returns>
        public List<int> BFS()
        {
            // If tree is empty, return null
            if (Root == null)
                return null;

            List<int> bfsData = new List<int>();
            Queue<TreeNode> visited = new Queue<TreeNode>();
            visited.Enqueue(Root);

            TreeNode currentNode = Root;
            while (visited.Count > 0)
            {
                currentNode = visited.Dequeue();
                bfsData.Add(currentNode.Value);

                // Add the left node and right node to the queue
                if (currentNode.Left != null)
                    visited.Enqueue(currentNode.Left);
                if (currentNode.Right != null)
                    visited.Enqueue(currentNode.Right);
            }


            return bfsData;
        }


        #region " DFS PreOrder Traversal "

        /// <summary>
        /// Depth First Search Traversal - PreOrder
        /// </summary>
        /// <returns>Returns the tree data in DFS Preorder</returns>
        public List<int> DFS_PreOrder_Iterative()
        {
            List<int> dfsData = new List<int>();

            Stack<TreeNode> visited = new Stack<TreeNode>();
            TreeNode currentNode;
            visited.Push(Root);

            while(visited.Count > 0)
            {
                currentNode = visited.Pop();
                dfsData.Add(currentNode.Value);

                if (currentNode.Right != null)
                    visited.Push(currentNode.Right);
                if (currentNode.Left != null)
                    visited.Push(currentNode.Left);
            }

            return dfsData;
        }
        
        public List<int> DFS_PreOrder_Recursive()
        {
            DFSRecursiveData = new List<int>();
            DFSPreOrderRecursive(Root);
            return DFSRecursiveData;
        }

        private void DFSPreOrderRecursive(TreeNode node)
        {
            if (node == null)
                return;
            DFSRecursiveData.Add(node.Value);
            DFSPreOrderRecursive(node.Left);
            DFSPreOrderRecursive(node.Right);
        }

        #endregion

        #region " DFS InOrder Traversal "

        /// <summary>
        /// Depth First Search Traversal - InOrder
        /// </summary>
        /// <returns>Returns the tree data in DFS InOrder</returns>
        public List<int> DFS_InOrder_Iterative()
        {
            List<int> dfsData = new List<int>();
            Stack<TreeNode> visited = new Stack<TreeNode>();

            // start from root node (set current node to root node)
            TreeNode current = Root;

            // if current node is null and stack is also empty, we're done
            while (visited.Count > 0 || current != null)
            {
                // if current node is not null, push it to the stack (defer it)
                // and move to its left child
                if (current != null)
                {
                    visited.Push(current);
                    current = current.Left;
                }
                else
                {
                    // else if current node is null, we pop an element from the stack,
                    // print it and finally set current node to its right child
                    current = visited.Pop();
                    dfsData.Add(current.Value);

                    current = current.Right;
                }
            }
            return dfsData;
        }



        public List<int> DFS_InOrder_Recursive()
        {
            DFSRecursiveData = new List<int>();
            DFSInOrderRecursive(Root);
            return DFSRecursiveData;
        }

        private void DFSInOrderRecursive(TreeNode node)
        {
            if (node == null)
                return;
            DFSInOrderRecursive(node.Left);
            DFSRecursiveData.Add(node.Value);
            DFSInOrderRecursive(node.Right);
        }

        #endregion

        #region " DFS PostOrder Traversal "

        /// <summary>
        /// Depth First Search Traversal - PostOrder
        /// </summary>
        /// <returns>Returns the tree data in DFS Postorder</returns>
        public List<int> DFS_PostOrder_Iterative()
        {
            List<int> dfsData = new List<int>();
            // create an empty stack and push root node
            Stack<TreeNode> visited = new Stack<TreeNode>();
            visited.Push(Root);

            // create another stack to store post-order traversal
            Stack<TreeNode> output = new Stack<TreeNode>();

            // run till stack is not empty
            while (visited.Count > 0)
            {
                // we pop a node from the stack and push the data to output stack
                TreeNode curr = visited.Pop();
                output.Push(curr);

                // push left and right child of popped node to the stack
                if (curr.Left != null)
                {
                    visited.Push(curr.Left);
                }

                if (curr.Right != null)
                {
                    visited.Push(curr.Right);
                }
            }

            // print post-order traversal
            while (output.Count > 0) {
                dfsData.Add(output.Pop().Value);
            }
            return dfsData;
        }



        public List<int> DFS_PostOrder_Recursive()
        {
            DFSRecursiveData = new List<int>();
            DFSPostOrderRecursive(Root);
            return DFSRecursiveData;
        }

        private void DFSPostOrderRecursive(TreeNode node)
        {
            if (node == null)
                return;
            DFSPostOrderRecursive(node.Left);
            DFSPostOrderRecursive(node.Right);
            DFSRecursiveData.Add(node.Value);
        }

        #endregion
    }
}