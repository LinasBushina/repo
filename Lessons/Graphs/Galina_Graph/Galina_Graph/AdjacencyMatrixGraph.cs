using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galina_Graph
{
    sealed class AdjacencyMatrixGraph : Graph
    {
        private bool[,] matrix;
        public AdjacencyMatrixGraph(bool isDirected, int vertexCount)
            : base(isDirected)
        { this.matrix = new bool[vertexCount, vertexCount]; }
        public override void AddEdge(int fromId, int toId)
        {
            matrix[fromId, toId] = true;
            if (!isDirected) matrix[toId, fromId] = true;
        }
        public override string ToString()
        {
            string res = "  ";
            for (int i = 0; i < matrix.GetLength(0); i++)
            { res += String.Format("{0,2}", i); }
            res += "\n  ";
            for (int i = 0; i < matrix.GetLength(0); i++)
            { res += "--"; }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                res += "\n" + i + "|";
                for (int j = 0; j < matrix.GetLength(0); j++)
                { res += String.Format("{0,2}", matrix[i,j]?1:0); }
            }
            return res;
        }
    }
}
