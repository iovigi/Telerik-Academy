<!-- section start -->
<!-- attr: { class:'slide-title', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Graphs
##  Fundamentals, Terminology, Traversal, Algorithms
<div class="signature">
    <p class="signature-course">Data Structures and Algorithms</p>
    <p class="signature-initiative">Telerik Software Academy</p>
    <a href = "http://academy.telerik.com " class="signature-link">http://academy.telerik.com </a>
</div>

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Table of Contents
* Graph Definitions and Terminology
* Representing Graphs 
* Graph Traversal Algorithms
* Connectivity
* Dijkstra’s Algorithm
* Topological sorting
* Prim and Kruskal

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Graphs
##  Definitions and Terminology

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Graph Data Structure
* Set of nodes with many-to-many relationship between them is called `graph`
  * Each node has `multiple` predecessors
  * Each node has `multiple` successors
* 7
* 19
* 21
* 14
* 1
* 12
* 31
* 4
* 11
<div class="fragment balloon">Node with multiple predecessors</div>
<div class="fragment balloon">Node with multiple successors</div>

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Graph Definitions
* `Node `(`vertex`)
  * Element of graph
  * Can have name or value
  * Keeps a list of adjacent nodes
* `Edge`
  * Connection between two nodes
  * Can be directed / undirected
  * Can be weighted / unweighted
  * Can have name / value
* A
<div class="fragment balloon">Node</div>
* A
<div class="fragment balloon">Edge</div>
* B

<!-- attr: { showInPresentation:true, style:'' } -->
# Graph Definitions (2)
* `Directed graph`
  * Edges have direction
* `Undirected graph`
  * Undirected edges
* 7
* 19
* 21
* 1
* 12
* 4
* 3
* 22
* 2
* 3
* G
* J
* F
* D
* A
* E
* C
* H

<!-- attr: { showInPresentation:true, style:'' } -->
# Graph Definitions (3)
* `Weighted graph`
  * Weight (cost) is associated with each edge
* G
* J
* F
* D
* A
* E
* C
* H
* Q
* K
* N
* 10
* 4
* 14
* 6
* 16
* 9
* 8
* 7
* 5
* 22
* 3

<!-- attr: { showInPresentation:true, style:'' } -->
# Graph Definitions (4)
* `Path `(in undirected graph)
  * Sequence of nodes n1, n2, … nk
  * Edge exists between each pair of nodes ni, ni+1
  * Examples:
    * `A, B, C `is a path
    * `H, K, C `is not a path
* G
* C
* B
* A
* H
* N
* K

<!-- attr: { showInPresentation:true, style:'' } -->
# Graph Definitions (5)
* `Path `(in directed graph)
  * Sequence of nodes n1, n2, … nk
  * Directed edge exists between each pair of nodes ni, ni+1
  * Examples:
    * `A, B, C `is a path
    * `A, G, K `is not a path
* G
* C
* B
* A
* H
* N
* K

<!-- attr: { showInPresentation:true, style:'' } -->
# Graph Definitions (6)
* `Cycle`
  * Path that ends back at the starting node
  * Example:
    * `A, B, C, G, A`
* `Simple path`
  * No cycles in path
* `Acyclic graph`
  * Graph with no cycles
  * Acyclic undirected graphs are trees
* G
* C
* B
* A
* H
* N
* K

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
<div class="fragment balloon">Unconnected graph with two connected components</div>
# Graph Definitions (7)
* Two nodes are `reachable` if
  * Path exists between them
* `Connected graph`
  * Every node is reachable from any other node
* G
* J
* F
* D
* A
<div class="fragment balloon">Connected graph</div>
* G
* J
* F
* D
* A
* E
* C
* H

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Graphs and Their Applications
* Graphs have many real-world applications
  * Modeling a computer network like Internet
    * Routes are simple paths in the network
  * Modeling a city map
    * Streets are edges, crossings are vertices
  * Social networks
    * People are nodes and their connections are edges
  * State machines
    * States are nodes, transitions are edges

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Representing Graphs
##  Classic and OOP Ways

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, style:'' } -->
# Representing Graphs
* `Adjacency list`
  * Each node holds a   list of its neighbors
* `Adjacency matrix`
  * Each cell keeps whether and how two nodes are connected
* `Set of edges`
* 1
* 2
* 3
* 4
* 1
* 2
* 3
* 4
* {1,2} {1,4} {2,3} {3,1} {4,2}
* 1 &rarr; {2, 4}
* 2 &rarr; {3}
* 3 &rarr; {1}
* 4 &rarr; {2}
* 2
* 4
* 1
* 3

<!-- attr: { showInPresentation:true, style:'' } -->
# Simple C# Representation

```cs
public class Graph
{
  List<int>[] childNodes;
  public Graph(List<int>[] nodes)
  {
    this.childNodes = nodes;
  }
}
```

```cs
Graph g = new Graph(new List<int>[] {
  new List<int> {3, 6}, // successors of vertice 0
  new List<int> {2, 3, 4, 5, 6},// successors of vertice 1
  new List<int> {1, 4, 5}, // successors of vertice 2
  new List<int> {0, 1, 5}, // successors of vertice 3
  new List<int> {1, 2, 6}, // successors of vertice 4
  new List<int> {1, 2, 3}, // successors of vertice 5
  new List<int> {0, 1, 4}  // successors of vertice 6
});
```
* 0
* 6
* 4
* 1
* 5
* 2
* 3

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Advanced C# Representation
* Using OOP:
  * Class `Node`
  * Class `Connection` (`Edge`)
  * Class `Graph`
  * Optional classes
* Using external library:
  * `QuickGraph `- http://quickgraph.codeplex.com/

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { class:'slide-section demo', showInPresentation:true, style:'' } -->
# Representing Graphs
##  [Demo]()

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Traversing Graphs
##  Good old DFS and BFS

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, style:'' } -->
# Graph Traversal Algorithms
* Depth-First Search (DFS) and Breadth-First Search (BFS) can traverse graphs
  * Each vertex should be visited at most once

```cs
BFS(node)
{
  queue  node
  visited[node] = true
  while queue not empty
    v  queue
    print v
    for each child c of v
      if not visited[c]
        queue  c
        visited[c] = true
}
```

```cs
DFS(node)
{
  stack  node
  visited[node] = true
  while stack not empty
    v  stack
    print v
    for each child c of v
      if not visited[c]
        stack  c
        visited[c] = true
}
```

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Recursive DFS Graph Traversal

```cs
void TraverseDFSRecursive(node)
{
  if (not visited[node])
  {
    visited[node] = true;
    print node;
    foreach child node c of node
    {
       TraverseDFSRecursive(c);
    }
  }
}
vois Main()
{
  TraverseDFS(firstNode);
}
```

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { class:'slide-section demo', showInPresentation:true, style:'' } -->
# Graphs and Traversals
##  [Demo]()

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Connectivity
##  Connecting the chain

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Connectivity
* `Connected component `of undirected graph
  *  A sub-graph in which any two nodes are connected to each other by paths

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Connectivity (2)
* A simple way to find number of connected components
  * A loop through all nodes and start a `DFS` or `BFS `traversing from any unvisited node
* Each time you start a new traversing
  * You find a new connected component!

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, style:'' } -->
# Connectivity (3)
* foreach node from graph G
* {
*    if node is unvisited
*    {
*       DFS(node);
*       countOfComponents++;
*    }
* }
* Algorithm:
* xNote: Do not forget to mark each node in the DFS as visited!
* F
* D
* A
* G
* C
* H

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Connectivity (4)
* `Connected` `graph`
  * A graph with only `one `connected component
* In every connected graph a path exists between any two nodes
* Checking whether a graph is connected
  * If DFS / BFS passes through all vertices &rarr; graph is connected!

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { class:'slide-section demo', showInPresentation:true, style:'' } -->
# Connectivity
##  [Demo]()

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Dijkstra’s Algorithm
##  Shortest path in graph

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, style:'' } -->
# Dijkstra’s Algorithm
* Find the `shortest path `from vertex `A` to vertex `B` - a directed path between them such that no other path has a lower weight.
* `Assumptions`
  * Edges can be directed or not
  * Weight does not have to be distance
  * Weights are positive or zero
  * Shortest path is not necessary unique
  * Not all edges need to be reachable

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Dijkstra’s Algorithm (2)
* In non-weighted graphs or edges with same weight finding shortest path can be done with BFS
  * xNote: Path from A to B does not matter –        triangle inequality

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Dijkstra’s Algorithm (3)
* In weighted graphs – simple solution can be done with breaking the edges in sub-vertexes
  * xToo much memory usage even for smaller graphs!

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Dijkstra’s Algorithm (4)
* Solution to this problem – priority queue instead of queue + keeping information about the shortest distance so far
* Steps:
  * Enqueue all distances from S
  * Get the lowest in priority - B
  * If edge B-A exists, check (S-B) + (B-A) and save the lower one
  * Overcome the triangle inequality miss

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, style:'' } -->
# Dijkstra’s Algorithm (5)
* `Dijkstra’s algorithm:`
  * Set the distance to every node to Infinity except the source node – must be zero
  * Mark every node as unprocessed
  * Choose the first unprocessed node with smallest non-infinity distance as current. If such does not exist, the algorithm has finished
  * At first we set the current node our `Source`

<!-- attr: { showInPresentation:true, style:'' } -->
# Dijkstra’s Algorithm (6)
* Dijkstra’s algorithm:
  * Calculate the distance for all unprocessed neighbors by adding the current distance to the already calculated one
  * If the new distance is smaller than the previous one – set the new value
  * Mark the current node as processed
  * Repeat step `3.`

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Dijkstra’s Algorithm (7)
* Example graph:

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, style:'' } -->
# Dijkstra’s Algorithm (8)
* Pseudo code
* set all nodes DIST = INFINITY;
* set current node the source and distance = 0;
* Q -> all nodes from graph, ordered by distance;
* while (Q is not empty)
* {
*   a = dequeue the smallest element (first in PriorityQueue);
*      if (distance of a == INFINITY) break;
*      foreach neighbour v of a
* 	{
* 	    potDistance = distance of a + distance of (a-v);
* 	    if (potDistance < distance of v)
* 	    {
* 		distance of v = potDistance;
* 		reorder Q;
* 	    }
* 	}
* }

<!-- attr: { showInPresentation:true, style:'' } -->
# Dijkstra’s Algorithm (9)
* Modifications
  * Saving the route
  * Having a target node
  * Array implementation, Queue, Priority Queue
  * Ax
* Complexity
  * `O((|V| + |E|).log(|V|))`
* Applications –GPS, Networks, Air travels, etc.

<!-- attr: { class:'slide-section demo', showInPresentation:true, style:'' } -->
# Dijkstra’s Algorithm
##  [Demo]()

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Topological Sorting
##  Order it!

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Topological Sorting
* Topological ordering of a `directed graph `
  * linear ordering of its vertices 
  * for every directed edge from vertex u to vertex v, u comes before v in the ordering
* Example:
  * 7, 5, 3, 11, 8, 2, 9, 10
  * 3, 5, 7, 8, 11, 2, 9, 10
  * 5, 7, 3, 8, 11, 10, 9, 2

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Topological Sorting (2)
* `Rules`
  * Undirected graph cannot be sorted
  * Directed graphs with cycles cannot be sorted
  * Sorting is not unique
  * Various sorting algorithms exists and they give different results

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, style:'' } -->
# Topological Sorting (3)
* `Source removal algorithm`
  * Create an Empty List 
  * Find a Node without incoming Edges
  * Add this Node to the end of the List
  * Remove the Edge from the Graph
  * Repeat until the Graph is empty

<!-- attr: { showInPresentation:true, style:'' } -->
# Topological Sorting (4)
* Pseudo code
* L ← Empty list that will contain the sorted elements
* S ← Set of all nodes with no incoming edges
* while S is non-empty do
*     remove a node n from S
*     insert n into L
*     for each node m with an edge e from n to m do
*         remove edge e from the graph
*         if m has no other incoming edges then
*             insert m into S
* if graph has edges then
*     return error (graph has at least one cycle)
* else 
*     return L (a topologically sorted order)

<!-- attr: { showInPresentation:true, style:'' } -->
# Step #1-2
* A
* E
* D
* B
* F
* C
* The Node A is the only Node without Incoming Edges

<!-- attr: { showInPresentation:true, style:'' } -->
# Step #3-4
* A
* E
* D
* B
* F
* C
* L

<!-- attr: { showInPresentation:true, style:'' } -->
# Step #2-3
* A
* E
* D
* B
* F
* C
* L

<!-- attr: { showInPresentation:true, style:'' } -->
# Step #2-3
* A
* E
* D
* B
* F
* C
* L

<!-- attr: { showInPresentation:true, style:'' } -->
# Step #2-3
* A
* E
* D
* B
* F
* C
* L

<!-- attr: { showInPresentation:true, style:'' } -->
# Step #2-3
* A
* E
* D
* B
* F
* C
* L

<!-- attr: { showInPresentation:true, style:'' } -->
# Step #2-3
* A
* E
* D
* B
* F
* C
* L

<!-- attr: { showInPresentation:true, style:'' } -->
# Step #2-3
* A
* E
* D
* B
* F
* C
* L

<!-- attr: { showInPresentation:true, style:'' } -->
# Step #2-3
* A
* E
* D
* B
* F
* C
* L

<!-- attr: { showInPresentation:true, style:'' } -->
# Result:TS
* A
* E
* D
* B
* F
* C

<!-- attr: { showInPresentation:true, style:'' } -->
# Topological Sorting (5)
* `DFS algorithm`
  * Create an empty List
  * Find a Node without Outgoing Edges
  * Mark the Node as visited
  * Add the node to the List
  * Stop when reach visited node
  * Reverse the List and get the TS of the Elements

<!-- attr: { showInPresentation:true, style:'' } -->
# Topological Sorting (6)
* Pseudo code
* http://www.geeksforgeeks.org/topological-sorting/
* L ← Empty list that will contain the sorted nodes
* while there are unmarked nodes do
*     select an unmarked node n
*     visit(n) 
* function visit(node n)
*     if n has a temporary mark then stop (not a DAG)
*     if n is not marked (i.e. has not been visited yet) then
*         mark n temporarily
*         for each node m with an edge from n to m do
*             visit(m)
*         mark n permanently
*         add n to head of L

<!-- attr: { class:'slide-section demo', showInPresentation:true, style:'' } -->
# TS Using DFS
##  [Demo]()

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Minimum Spanning Tree

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Minimum Spanning Tree
* Spanning Tree
  * Subgraph (Tree)
  * Connects all vertices together
* All connected graphs have spanning tree

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Minimum Spanning Tree
* Minimum Spanning Tree
  * weight <= 
  *      weight(all other spanning trees)
* First used in electrical network
  * Minimal cost of wiring

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Minimum Spanning Forest

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Minimum Spanning Forest
* Minimum Spanning Forest – set of all minimum spanning trees (when the graph is not connected)

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Prim’s Algorithm

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, style:'' } -->
# Prim’s Algorithm
* Create a tree T containing a single vertex (chosen randomly)
* Create a set S from all the edges in the graph
* Loop until every edge in the set connects two vertices in the tree
  * Remove from the set an edge with minimum weight that connects a vertex in the tree with a vertex not in the tree
  * Add that edge to the tree
* Note: the graph must be connected

<!-- attr: { showInPresentation:true, style:'' } -->
* Note: at every step before adding an edge to the tree we check if it makes a cycle in the tree or if it is already in the queue
* When we add a vertex we check if it is the last which is not visited
* 4
* 2
* 9
* 12
* 8
* 7
* 5
* A
* B
* C
* D
* E
* F
* 20
# Prim’s Algorithm

<!-- attr: { showInPresentation:true, style:'' } -->
* We build a tree with the single vertex A
* Priority queue which contains all edges that connect A with the other nodes (AB, AC, AD)
* 4
* 2
* 9
* 12
* 8
* 7
* 5
* A
* B
* C
* D
* E
* F
* 20
# Prim’s Algorithm

<!-- attr: { showInPresentation:true, style:'' } -->
* The tree still contains the only vertex A
* We dequeue the first edge from the priority queue (4) and we add the edge and the other vertex (B) form that edge to the tree
* We push all edges that connect B with other nodes in the queue
  * Note that the edges 5
  * and 9 are still
  * in the queue
* 4
* 2
* 9
* 12
* 8
* 7
* 5
* A
* B
* C
* D
* E
* F
* 20
# Prim’s Algorithm

<!-- attr: { showInPresentation:true, style:'' } -->
* Now the tree contains vertices A and B and the edge between them
* We dequeue the first edge from the priority queue (2) and we add the edge and the other vertex (D) from that edge to the tree
* We push all edges that connect D with other nodes in the queue
* 4
* 2
* 9
* 12
* 8
* 7
* 5
* A
* B
* C
* D
* E
* F
* 20
# Prim’s Algorithm

<!-- attr: { showInPresentation:true, style:'' } -->
* Now the tree contains vertices A, B and D and the edges (4, 2) between them
* We dequeue the first edge from the priority queue (5) and we add the edge and the other vertex (C) from that edge to the tree
* We push all edges that connect C with other nodes in the queue
* 4
* 2
* 9
* 12
* 8
* 7
* 5
* A
* B
* C
* D
* E
* F
* 20
# Prim’s Algorithm

<!-- attr: { showInPresentation:true, style:'' } -->
* Now the tree contains vertices A, B, D and C and the edges (4, 2, 5) between them
* We dequeue the first edge from the priority queue (7) and we add the edge and the other vertex (E) from that edge to the tree
* We push all edges that connect C with other nodes in the queue
* 4
* 2
* 9
* 12
* 8
* 7
* 5
* A
* B
* C
* D
* E
* F
* 20
# Prim’s Algorithm

<!-- attr: { showInPresentation:true, style:'' } -->
* Now the tree contains vertices A, B, D, C and E and the edges (4, 2, 5, 7) between them
* We dequeue the first edge from the priority queue (8)
* 4
* 2
* 9
* 12
* 8
* 7
* 5
* A
* B
* C
* D
* E
* F
* 20
# Prim’s Algorithm

<!-- attr: { showInPresentation:true, style:'' } -->
* This edge will cost a cycle
* So we get the next one – 9
  * This edge will also cost a cycle
* So we get the next one – 12
  * We add it to the tree 
  * We add the vertex F to the tree
* 4
* 2
* 9
* 12
* 8
* 7
* 5
* A
* B
* C
* D
* E
* F
* 20
# Prim’s Algorithm

<!-- attr: { class:'slide-section demo', showInPresentation:true, style:'' } -->
# Prim
##  [Demo]()

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Kruskal’s Algorithm

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Kruskal’s Algorithm
* The graph may not be connected
  * If the graph is not connected – minimum spanning forest

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, style:'' } -->
# Kruskal’s Algorithm
* Create forest F (each tree is a vertex)
* Set S – all edges in the graph
* While S if nonempty and F is not spanning
  * Remove edge with min cost from S
  * If that edge connects two different trees – add it to the forest (these two trees are now a single tree)
  * Else discard the edge
* The graph may not be connected

<!-- attr: { showInPresentation:true, style:'' } -->
* We build a forest containing all vertices from the graph
* We sort all edges 
* Edges are – 2, 4, 5, 7, 8, 9, 12, 20
* 4
* 2
* 9
* 12
* 8
* 7
* 5
* A
* B
* C
* D
* E
* F
* 20
# Kruskal’s Algorithm

<!-- attr: { showInPresentation:true, style:'' } -->
* At every step we select the edge with the smallest weight and remove it from the list with edges
* If it connects two different trees from the forest we add it and connect these trees
* 4
* 2
* 9
* 12
* 8
* 7
* 5
* A
* B
* C
* D
* E
* F
* 20
# Kruskal’s Algorithm

<!-- attr: { showInPresentation:true, style:'' } -->
* We select the edge 2
* This edge connects the vertices B and D (they are in different trees)
* We add it
* 4
* 2
* 9
* 12
* 8
* 7
* 5
* A
* B
* C
* D
* E
* F
* 20
# Kruskal’s Algorithm

<!-- attr: { showInPresentation:true, style:'' } -->
* We select the edge 4 
* This edge connects the vertices A and B (they are different trees)
* We add it
* 4
* 2
* 9
* 12
* 8
* 7
* 5
* A
* B
* C
* D
* E
* F
* 20
# Kruskal’s Algorithm

<!-- attr: { showInPresentation:true, style:'' } -->
* We select the edge 5
* This edge connects the vertices A and C (they are different trees)
* We add it
* 4
* 2
* 9
* 12
* 8
* 7
* 5
* A
* B
* C
* D
* E
* F
* 20
# Kruskal’s Algorithm

<!-- attr: { showInPresentation:true, style:'' } -->
* We select the edge 7
* This edge connects the vertices C and E (they are different trees)
* We add it
* 4
* 2
* 9
* 12
* 8
* 7
* 5
* A
* B
* C
* D
* E
* F
* 20
# Kruskal’s Algorithm

<!-- attr: { showInPresentation:true, style:'' } -->
* We select the edge 8
* This edge connects the vertices E and D (they are not different trees)
* We don’t add it
* 4
* 2
* 9
* 12
* 8
* 7
* 5
* A
* B
* C
* D
* E
* F
* 20
# Kruskal’s Algorithm

<!-- attr: { showInPresentation:true, style:'' } -->
* We select the edge 9
* This edge connects the vertices A and D (they are not different trees)
* We don’t add it
* 4
* 2
* 9
* 12
* 8
* 7
* 5
* A
* B
* C
* D
* E
* F
* 20
# Kruskal’s Algorithm

<!-- attr: { showInPresentation:true, style:'' } -->
* We select the edge 12
* This edge connects the vertices E and F (they are not different trees)
* We add it
* 4
* 2
* 9
* 12
* 8
* 7
* 5
* A
* B
* C
* D
* E
* F
* 20
# Kruskal’s Algorithm

<!-- attr: { showInPresentation:true, style:'' } -->
* We can have a function that checks at every step if all vertices are connected and the tree that we build is spanning
* If we have such function we stop
* Otherwise we check for the other edges
  * We just won’t add them to the tree
* 4
* 2
* 9
* 12
* 8
* 7
* 5
* A
* B
* C
* D
* E
* F
* 20
# Kruskal’s Algorithm

<!-- attr: { class:'slide-section demo', showInPresentation:true, style:'' } -->
# Kruskal
##  [Demo]()

<!-- attr: { showInPresentation:true, style:'' } -->
# Exercises
* Solve these problems from BGCoder:
  * Algo Academy March 2012 – Problem 05 – Friends of Pesho
  * Algo Academy February 2013 – Problem 04 – Salaries
* You are given a cable TV company. The company needs to lay cable to a new neighborhood (for every house). If it is constrained to bury the cable only along certain paths, then there would be a graph representing which points are connected by those paths. But the cost of some of the paths is more expensive because they are longer. If every house is a node and every path from house to house is an edge, find a way to minimize the cost for cables.

<!-- attr: { showInPresentation:true, style:'' } -->
# Trees and Graphs
* Questions?
* ?
* ?
* `?`
* ?
* ?
* ?
* ?
* ?
* ?
* ?
* http://algoacademy.telerik.com

