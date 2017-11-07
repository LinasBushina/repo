using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galina_Graph
{
    abstract class Graph
    {
        protected bool isDirected;
        public Graph(bool isDirected)
        { this.isDirected = isDirected; }
        public abstract void AddEdge(int fromId, int toId);
        public override string ToString()
        { throw new NotImplementedException(); }
    }
}
