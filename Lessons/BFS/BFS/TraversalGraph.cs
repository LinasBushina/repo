using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFS
{
    class TraversalGraph
    {
        public static List<int> BFS(int startVertex, AdjacencyMatrixGraph g)
        {
            List<int> path = new List<int>();
            bool[] visited = new bool[g.GetCountVertexes()];
            Queue<int> q = new Queue<int>();
            q.Enqueue(startVertex);
            visited[startVertex] = true;
            path.Add(startVertex);

            while (q .Count!= 0)
            {
                int node = q.Dequeue();
                foreach (var child in g.GetNeighbors(node))
                {
                    if (!visited[child])
                    {
                        q.Enqueue(child);
                        visited[child] = true;
                        path.Add(child);
                    }
                }
            }

            return path;
        }

        public static List<int> DFS(int startVertex, AdjacencyMatrixGraph g)
        {
            List<int> path = new List<int>();
            bool[] visited = new bool[g.GetCountVertexes()];
            Stack<int> s = new Stack<int>();
            s.Push(startVertex);
            visited[startVertex] = true;
            path.Add(startVertex);

            while (s.Count != 0)
            {
                int node = s.Peek();
                bool flag = true;
                foreach (var child in g.GetNeighbors(node))
                {
                    if (!visited[child])
                    {
                        s.Push(child);
                        visited[child] = true;
                        path.Add(child);
                        flag = false;
                        break;
                    }
                }
                if (flag) s.Pop();
            }

            return path;
        }
    }
}
