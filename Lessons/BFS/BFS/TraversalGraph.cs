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

            while (q.Count!= 0)
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

        public static List<Tuple<int, int>> BFSwithTier(int startVertex, AdjacencyMatrixGraph g)
        {
            List<Tuple<int, int>> path = new List<Tuple<int, int>>();
            bool[] visited = new bool[g.GetCountVertexes()];
            Queue<Tuple<int, int>> q = new Queue<Tuple<int, int>>();
            q.Enqueue(Tuple.Create(startVertex, 0));
            visited[startVertex] = true;
            path.Add(Tuple.Create(startVertex, 0));

            while (q.Count != 0)
            {
                Tuple<int, int> pair = q.Dequeue();
                int node = pair.Item1;
                int tier = pair.Item2;
                foreach (var child in g.GetNeighbors(node))
                {
                    if (!visited[child])
                    {
                        q.Enqueue(Tuple.Create(child, tier + 1));
                        visited[child] = true;
                        path.Add(Tuple.Create(child, tier + 1));
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
