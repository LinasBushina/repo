using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galina_Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            //AdjacencyMatrixGraph g1 = new AdjacencyMatrixGraph(false, 5);
            //Console.WriteLine(Sample_1(g1));
            //Console.WriteLine();
            //AdjacencyListGraph g2 = new AdjacencyListGraph(false, 5);
            //Console.WriteLine(Sample_1(g2));
            AdjacencyMatrixGraph g3 = new AdjacencyMatrixGraph(false, 6);
            Console.WriteLine(Sample_2(g3));
            Console.WriteLine();
            AdjacencyListGraph g4 = new AdjacencyListGraph(false, 6);
            Console.WriteLine(Sample_2(g4));
            Console.WriteLine();
            AdjacencyMatrixGraph g5 = new AdjacencyMatrixGraph(true, 4);
            Console.WriteLine(Sample_3(g5));
            Console.WriteLine();
            AdjacencyListGraph g6 = new AdjacencyListGraph(true, 4);
            Console.WriteLine(Sample_3(g6));
        }

        static Graph Sample_1(Graph g)
        {
            g.AddEdge(0, 1);
            g.AddEdge(0, 2);
            g.AddEdge(1, 2);
            g.AddEdge(1, 3);
            g.AddEdge(2, 4);
            g.AddEdge(3, 4);
            return g;
        }
        static Graph Sample_2(Graph g)
        {
            g.AddEdge(0, 1);
            g.AddEdge(0, 2);
            g.AddEdge(0, 5);
            g.AddEdge(1, 3);
            g.AddEdge(1, 4);
            g.AddEdge(2, 4);
            g.AddEdge(3, 5);
            g.AddEdge(4, 5);
            return g;
        }
        static Graph Sample_3(Graph g)
        {
            g.AddEdge(0, 1);
            g.AddEdge(1, 3);
            g.AddEdge(2, 0);
            g.AddEdge(2, 1);
            g.AddEdge(3, 2);
            return g;
        }
    }
}

