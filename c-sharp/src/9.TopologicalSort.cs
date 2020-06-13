using System.Collections.Generic;

namespace DataStructures.Graphs
{
    /// <summary>
    /// Identifies the topological order for a given directed acyclic graph represented as an adjacency list
    /// </summary>
    class TopologicalSort
    {
        public List<string> FindTopologicalSort(Dictionary<string, string[]> adjList)
        {
            // List to store the topological order for a given directed acyclic graph
            List<string> tOrder = new List<string>();

            // In-Degree map for the graph
            Dictionary<string, int> inDegree = new Dictionary<string, int>();
            foreach (var kvp in adjList)
            {
                // Add the vertex to the inDegree map
                if (!inDegree.ContainsKey(kvp.Key)) inDegree.Add(kvp.Key, 0);

                // For each edge, increase the inDegree for the vertex
                foreach (var edge in kvp.Value)
                {
                    if (inDegree.ContainsKey(edge))
                        inDegree[edge]++;
                    else
                        inDegree.Add(edge, 1);
                }
            }

            // A queue to hold the vertices with zero inDegree
            Queue<string> queue = new Queue<string>();
            foreach (var vertex in inDegree)
            {
                if (vertex.Value == 0)
                    queue.Enqueue(vertex.Key);
            }

            // Traverse the graph with BFS
            while (queue.Count > 0)
            {
                string currentVertex = queue.Dequeue();
                // Add the vertex to the list
                tOrder.Add(currentVertex);

                // If the current vertext and edges
                if (adjList.ContainsKey(currentVertex))
                {
                    // Mark the current vertex as visited and decrease the inDegree for the edges of the vertex.
                    // Imagine we are deleting this current vertex from our graph,
                    // by which the edges from this vertex also gets deleted. Once the edges are deleted, inDegree will also be reduced
                    foreach (string vertex in adjList[currentVertex])
                    {
                        if (inDegree[vertex] > 0)
                        {
                            // Decrease the inDegree
                            inDegree[vertex]--;

                            // If inDegree becomes zero, add it to the queue
                            if (inDegree[vertex] == 0)
                                queue.Enqueue(vertex);
                        }
                    }
                }
            }

            return tOrder;
        }

        public bool IsThereALoop(Dictionary<string, string[]> adjList)
        {
            // List to store the topological order for a given directed acyclic graph
            int visitedVertexCount = 0;

            // In-Degree map for the graph
            Dictionary<string, int> inDegree = new Dictionary<string, int>();
            foreach (var kvp in adjList)
            {
                // Add the vertex to the inDegree map
                if (!inDegree.ContainsKey(kvp.Key)) inDegree.Add(kvp.Key, 0);

                // For each edge, increase the inDegree for the vertex
                foreach (var edge in kvp.Value)
                {
                    if (inDegree.ContainsKey(edge))
                        inDegree[edge]++;
                    else
                        inDegree.Add(edge, 1);
                }
            }

            // A queue to hold the vertices with zero inDegree
            Queue<string> queue = new Queue<string>();
            foreach (var vertex in inDegree)
            {
                if (vertex.Value == 0)
                    queue.Enqueue(vertex.Key);
            }

            // Traverse the graph with BFS
            while (queue.Count > 0)
            {
                string currentVertex = queue.Dequeue();
                // Increase the visited vertex count
                visitedVertexCount++;

                // If the current vertext and edges
                if (adjList.ContainsKey(currentVertex))
                {
                    // Mark the current vertex as visited and decrease the inDegree for the edges of the vertex.
                    // Imagine we are deleting this current vertex from our graph,
                    // by which the edges from this vertex also gets deleted. Once the edges are deleted, inDegree will also be reduced
                    foreach (string vertex in adjList[currentVertex])
                    {
                        if (inDegree[vertex] > 0)
                        {
                            // Decrease the inDegree
                            inDegree[vertex]--;

                            // If inDegree becomes zero, add it to the queue
                            if (inDegree[vertex] == 0)
                                queue.Enqueue(vertex);
                        }
                    }
                }
            }

            // If the number of vertices visited and total number for vertices in the graph are equal,
            // then there is no loop
            return !(visitedVertexCount == inDegree.Count);
        }
    }
}