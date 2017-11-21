using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFS
{
    class Program
    {
        static void Main(string[] args)
        {
            AdjacencyMatrixGraph g = new AdjacencyMatrixGraph(6);
            g.AddEdge(0, 1); g.AddEdge(0, 2); g.AddEdge(1, 3);
            g.AddEdge(1, 4); g.AddEdge(4, 5);
            foreach (var node in TraversalGraph.BFS(0, g))
            { Console.WriteLine(node); }
            Console.WriteLine();
            foreach (var node in TraversalGraph.DFS(0, g))
            { Console.WriteLine(node); }
        }
    }
}
