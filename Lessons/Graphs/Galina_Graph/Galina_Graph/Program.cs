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
            AdjacencyMatrixGraph g1 = new AdjacencyMatrixGraph(false, 5);
            Console.WriteLine(Sample_1(g1));
            Console.WriteLine();
            AdjacencyListGraph g2 = new AdjacencyListGraph(false, 5);
            Console.WriteLine(Sample_1(g2));
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
    }
}
