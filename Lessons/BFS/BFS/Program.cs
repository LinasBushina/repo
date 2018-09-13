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
            Graph4();
        }

        static void Graph1()
        {
            AdjacencyMatrixGraph g = new AdjacencyMatrixGraph(6);
            g.AddEdge(0, 1); g.AddEdge(0, 2); g.AddEdge(1, 3);
            g.AddEdge(1, 4); g.AddEdge(4, 5); //g.AddEdge(2, 4);
            foreach (var pair in TraversalGraph.BFSwithTier(0, g))
            { Console.WriteLine("{0} - {1}", pair.Item1, pair.Item2); }
            Console.WriteLine();
            foreach (var node in TraversalGraph.DFS(0, g))
            { Console.WriteLine(node); }
        }
        static void Graph2()
        {
            AdjacencyMatrixGraph g = new AdjacencyMatrixGraph(6);
            g.AddEdge(0, 1); g.AddEdge(0, 2); g.AddEdge(0, 3);
            g.AddEdge(0, 5); g.AddEdge(1, 2); g.AddEdge(2, 3);
            g.AddEdge(3, 4); g.AddEdge(4, 5);
            foreach (var pair in TraversalGraph.BFSwithTier(0, g))
            { Console.WriteLine("{0} - {1}", pair.Item1, pair.Item2); }
            Console.WriteLine();
            foreach (var node in TraversalGraph.DFS(0, g))
            { Console.WriteLine(node); }
        }
        static void Graph4()
        {
            AdjacencyMatrixGraph g = new AdjacencyMatrixGraph(6);
            g.AddEdge(0, 1); g.AddEdge(0, 2); g.AddEdge(0, 4);
            g.AddEdge(0, 5); g.AddEdge(1, 2); g.AddEdge(2, 3);
            g.AddEdge(2, 4); 
            foreach (var pair in TraversalGraph.BFSwithTier(0, g))
            { Console.WriteLine("{0} - {1}", pair.Item1, pair.Item2); }
            Console.WriteLine();
            foreach (var node in TraversalGraph.DFS(0, g))
            { Console.WriteLine(node); }
        }
        static void Graph3()
        {
            AdjacencyMatrixGraph g = new AdjacencyMatrixGraph(6);
            g.AddEdge(0, 5); g.AddEdge(1, 2); g.AddEdge(1, 4);
            g.AddEdge(1, 5); g.AddEdge(2, 4); g.AddEdge(2, 5);
            g.AddEdge(3, 4); g.AddEdge(4, 5);
            Console.WriteLine("Обход графа в ширину: ");
            Console.WriteLine();
            foreach (var pair in TraversalGraph.BFSwithTier(0, g))
            { Console.WriteLine("{0} - {1}", pair.Item1, pair.Item2); }
            Console.WriteLine();
            Console.WriteLine("Обход графа в глубину: ");
            Console.WriteLine();
            foreach (var node in TraversalGraph.DFS(0, g))
            { Console.WriteLine(node); }
        }
    }
}
