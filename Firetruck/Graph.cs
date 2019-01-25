using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firetruck
{
    public class Graph
    {
        private int _V;  ////The number of vertices
        LinkedList<int>[] _adj;  //Use a LinkedList for the adjacency-list representation


        public Graph(int V)
        {
            _adj = new LinkedList<int>[V];

            for (int i = 0; i < _adj.Length; i++)
            {
                _adj[i] = new LinkedList<int>();
            }

            _V = V;
        }

        public void AddEdge(int v, int w)
        {
            _adj[v].AddLast(w);
            _adj[w].AddLast(v);
        }

        public void PrintAllpath(int s, int d)
        {
            // Mark all the vertices as not visited
            bool[] visited = new bool[_V];

            for (int i = 0; i < _V; i++)
                visited[i] = false;
            // Create an array to store paths 
            int[] path = new int[_V];
            int path_index = 0;
            PrintAllPathUtil(s, d, visited, path, path_index);
        }

        public void PrintAllPathUtil(int u, int d, bool[] visited, int[] path, int path_index)
        {
            // Mark the current node and store it in path[] 
            visited[u] = true;
            path[path_index] = u;
            path_index++;

            // If current vertex is same as destination, then print 
            // current path[] 
            if (u == d)
            {
                for (int i = 0; i < path_index; i++)
                    cout << path[i] << " ";
            }
            else // If current vertex is not destination 
            {
                // Recur for all the vertices adjacent to current vertex 
                for (int i = 0; i != _adj[u].Count; ++i)
                    if (!visited[i])
                        PrintAllPathUtil(i, d, visited, path, path_index);
            }

            // Remove current vertex from path[] and mark it as unvisited 
            path_index--;
            visited[u] = false;
        }

        /*
        public void DepthFirstSearch(int v)
        {
            // Mark all the vertices as not visited
            bool[] visited = new bool[_V];

            for (int i = 0; i < _V; i++)
                visited[i] = false;

            // Call the recursive helper function to print DFS traversal
            DFSUtil(v, visited);
        }

        private void DFSUtil(int v, bool[] visited)
        {
            // Mark the current node as visited and print it
            visited[v] = true;
            Console.Write(v + " ");

            // Recur for all the vertices adjacent to this vertex
            LinkedList<int> list = _adj[v];

            foreach (var val in list)
            {
                if (!visited[val])
                    DFSUtil(val, visited);
            }
        }*/
    }
}
