class ConnectedComponents {
    numberOfConnectedComponents(adjList: Map<string, string[]>): number {
        // variable to keep track of the count of connected components in the given graph
        let count: number = 0;

        // connected components
        let allConnectedComponents: string[][] = [];
        // Map/hash-table to keep track of visited vertices
        let visited: Set<string> = new Set<string>();

        // Loop through each vertex in the given graph
        adjList.forEach((edges, vertex) => {
            if (!visited.has(vertex)) {
                // List to keep track of vertices of each connected components
                let vertices: string[] = [];
                this.DFS(vertex, adjList, visited, vertices);
                count++;
                allConnectedComponents.push(vertices);
            }

        });
        console.log("Vertices in each connected component of a given graph: ");
        allConnectedComponents.forEach(v => { console.log(v) });
        return count;
    }

    DFS(current: string, adjList: Map<string, string[]>, visited: Set<string>, vertices: string[]) {
        // Mark the current vertex as visited
        visited.add(current);
        vertices.push(current);

        // Perform DFS on the edges of current,  if the vertex of the edge is not visited
        adjList.get(current).forEach(v => {
            if (!visited.has(v)) {
                this.DFS(v, adjList, visited, vertices);
            }
        });
    }
}

const graph = new Map();
graph.set("A", ["B", "C"]);
graph.set("B", ["A", "C"]);
graph.set("C", ["B", "A"]);
graph.set("D", ["E", "F"]);
graph.set("E", ["D", "G"]);
graph.set("F", ["D", "G"]);
graph.set("G", ["F", "E"]);
graph.set("H", ["I", "J"]);
graph.set("I", ["H", "J"]);
graph.set("J", ["I", "H"]);

let ccFinder = new ConnectedComponents();
console.log("Number of Contented Components in the given graph: " + ccFinder.numberOfConnectedComponents(graph));

graph.clear();
graph.set("A", ["B", "C"]);
graph.set("B", ["A", "C"]);
graph.set("C", ["B", "A"]);
graph.set("D", ["E", "F"]);
graph.set("E", ["D", "G"]);
graph.set("F", ["D", "G"]);
graph.set("G", ["F", "E"]);
graph.set("H", ["I", "J"]);
graph.set("I", ["H", "J"]);
graph.set("J", ["I", "H"]);
graph.set("K", []);
console.log("Number of Contented Components in the given graph: " + ccFinder.numberOfConnectedComponents(graph));