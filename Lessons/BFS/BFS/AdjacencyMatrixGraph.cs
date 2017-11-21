using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFS
{
    class AdjacencyMatrixGraph
    {
        private bool[,] matrix;
        public AdjacencyMatrixGraph(int vertexCount)
        { this.matrix = new bool[vertexCount, vertexCount]; }
        public void AddEdge(int fromId, int toId)
        {
            matrix[fromId, toId] = true;
            matrix[toId, fromId] = true;
        }
        public int GetCountVertexes()
        { return matrix.GetLength(0); }
        public IEnumerable<int> GetNeighbors(int v)
        {
            for (int j = 0; j < matrix.GetLength(0); j++)
            { if (matrix[v, j]) yield return j; }
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
                { res += String.Format("{0,2}", matrix[i, j] ? 1 : 0); }
            }
            return res;
        }
    }
}
