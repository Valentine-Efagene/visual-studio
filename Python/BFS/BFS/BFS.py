# Python3 Program to print BFS traversal 
# from a given source vertex. BFS(int s) 
# traverses vertices reachable from s. 

from collections import defaultdict

# This class represents a directed graph 
# using adjacency list representation 

class V:
    distance = 0;
    pi = float('inf')
    color = 'white'

    def __init__(this, label):
        this.label = label

class Graph:
    def __init__(this):
        # default dictionary to store graph 
        this.graph = defaultdict(list) 

    # function to add an edge to graph 
    def addEdge(this,u,v): 
        this.graph[u].append(v) 

    # Function to print a BFS of graph 
    def BFS(this, s): 
        # Create a queue for BFS 
        queue = [] 
        # Mark the source node as
        # visited and enqueue it 
        queue.append(s) 
        s.color = 'gray' 

        while queue:
            # Dequeue a vertex from
            # queue and print it 
            u = queue.pop(0) 
            print ("Label = ", u.label, ",", "distance = ", u.distance, sep = ' ',  end = "\n") 
            # Get all adjacent vertices of the 
            # dequeued vertex s. If a adjacent 
            # has not been visited, then mark it 
            # visited and enqueue it 

            for v in this.graph[u]: 
                if v.color == "white": 
                    queue.append(v) 
                    v.color = "gray"
                    v.distance = u.distance + 1
                    
            u.color = "black"

# Driver code 
# Create a graph given in 
# the above diagram

v0, v1, v2, v3, v4, v5 = V(0), V(1), V(2), V(3), V(4), V(5)
startVertex = v1 

g = Graph() 
g.addEdge(v0, v1) 
g.addEdge(v0, v2)
g.addEdge(v1, v2) 
g.addEdge(v2, v0)
g.addEdge(v2, v3) 
g.addEdge(v3, v3) 
print ("Following is Breadth First Traversal (starting from vertex", startVertex.label, ")") 
g.BFS(startVertex) 