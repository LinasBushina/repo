using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galina_Graph
{
    sealed class AdjacencyListGraph : Graph
    {
        private List<List<int>> list;
        public AdjacencyListGraph(bool isDirected, int vertexCount)
            : base(isDirected)
        {
            this.list = new List<List<int>>();
            for (int i = 0; i < vertexCount; i++)
            { list.Add(new List<int>()); }
        }
        public override void AddEdge(int fromId, int toId)
        {
            list[fromId].Add(toId);
            if (!isDirected) list[toId].Add(fromId);
        }
        public override string ToString()
        {
            string res = "";
            for (int i = 0; i < list.Count; i++)
            {
                res += i + "| ";
                if (list[i].Count != 0)
                { res += list[i][0]; }
                for (int j = 1; j < list[i].Count; j++)
                { res += ", " + list[i][j]; }
                if (i != list.Count - 1)
                { res += "\n"; } 
            }
            return res;
        }
    }
}
