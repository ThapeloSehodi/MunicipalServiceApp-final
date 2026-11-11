using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalServicesApp.Generic
{
    public class GraphEdge<T>
    {
        public T From { get; private set; }

        public T To { get; private set; }

        public double Weight { get; private set; }

        public GraphEdge(T from, T to, double weight)
        {
            From = from;
            To = to;
            Weight = weight;
        }
    }

    // An undirected, weighted graph stored as an adjacency list.
    // In this application the vertices are municipal service areas
    // and the weights are road distances in kilometres.
    public class Graph<T>
    {
        private readonly Dictionary<T, List<GraphEdge<T>>> adjacency;
        private readonly List<T> vertexOrder;
        private readonly List<GraphEdge<T>> edges;

        public Graph()
        {
            adjacency = new Dictionary<T, List<GraphEdge<T>>>();
            vertexOrder = new List<T>();
            edges = new List<GraphEdge<T>>();
        }

        public int VertexCount
        {
            get
            {
                return vertexOrder.Count;
            }
        }

        public int EdgeCount
        {
            get
            {
                return edges.Count;
            }
        }

        public List<T> Vertices
        {
            get
            {
                return new List<T>(vertexOrder);
            }
        }

        // Each connection once (not once per direction).
        public List<GraphEdge<T>> Edges
        {
            get
            {
                return new List<GraphEdge<T>>(edges);
            }
        }

        public bool Contains(T vertex)
        {
            return adjacency.ContainsKey(vertex);
        }

        public void AddVertex(T vertex)
        {
            if (adjacency.ContainsKey(vertex))
            {
                return;
            }

            adjacency.Add(vertex, new List<GraphEdge<T>>());
            vertexOrder.Add(vertex);
        }

        public void AddEdge(T a, T b, double weight)
        {
            AddVertex(a);
            AddVertex(b);

            GraphEdge<T> edge = new GraphEdge<T>(a, b, weight);
            edges.Add(edge);

            adjacency[a].Add(edge);
            adjacency[b].Add(new GraphEdge<T>(b, a, weight));
        }

        public List<GraphEdge<T>> GetNeighbours(T vertex)
        {
            return new List<GraphEdge<T>>(adjacency[vertex]);
        }

        // Breadth-first search: visits the start vertex, then all of its
        // neighbours, then their neighbours, and so on (using a queue).
        // Returns each vertex with its distance from the start in "hops".
        public List<KeyValuePair<T, int>> BreadthFirst(T start)
        {
            List<KeyValuePair<T, int>> result = new List<KeyValuePair<T, int>>();

            if (!adjacency.ContainsKey(start))
            {
                return result;
            }

            Dictionary<T, int> distance = new Dictionary<T, int>();
            Queue<T> queue = new Queue<T>();

            distance[start] = 0;
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                T current = queue.Dequeue();
                result.Add(new KeyValuePair<T, int>(current, distance[current]));

                foreach (GraphEdge<T> edge in adjacency[current])
                {
                    if (!distance.ContainsKey(edge.To))
                    {
                        distance[edge.To] = distance[current] + 1;
                        queue.Enqueue(edge.To);
                    }
                }
            }

            return result;
        }

        // Depth-first search: goes as deep as possible along one path
        // before backing up (using the call stack).
        public List<T> DepthFirst(T start)
        {
            List<T> order = new List<T>();

            if (!adjacency.ContainsKey(start))
            {
                return order;
            }

            HashSet<T> visited = new HashSet<T>();
            DepthFirst(start, visited, order);

            return order;
        }

        private void DepthFirst(T vertex, HashSet<T> visited, List<T> order)
        {
            visited.Add(vertex);
            order.Add(vertex);

            foreach (GraphEdge<T> edge in adjacency[vertex])
            {
                if (!visited.Contains(edge.To))
                {
                    DepthFirst(edge.To, visited, order);
                }
            }
        }

        // Kruskal's algorithm: take the shortest edges first and skip any
        // edge that would create a loop. The result connects every vertex
        // using the smallest possible total weight.
        public List<GraphEdge<T>> MinimumSpanningTree()
        {
            List<GraphEdge<T>> tree = new List<GraphEdge<T>>();

            Dictionary<T, T> parent = new Dictionary<T, T>();
            Dictionary<T, int> rank = new Dictionary<T, int>();

            foreach (T vertex in vertexOrder)
            {
                parent[vertex] = vertex;
                rank[vertex] = 0;
            }

            List<GraphEdge<T>> sorted = edges.OrderBy(e => e.Weight).ToList();

            foreach (GraphEdge<T> edge in sorted)
            {
                T rootA = Find(parent, edge.From);
                T rootB = Find(parent, edge.To);

                if (EqualityComparer<T>.Default.Equals(rootA, rootB))
                {
                    continue;
                }

                // Union by rank
                if (rank[rootA] < rank[rootB])
                {
                    parent[rootA] = rootB;
                }
                else if (rank[rootA] > rank[rootB])
                {
                    parent[rootB] = rootA;
                }
                else
                {
                    parent[rootB] = rootA;
                    rank[rootA]++;
                }

                tree.Add(edge);

                if (tree.Count == vertexOrder.Count - 1)
                {
                    break;
                }
            }

            return tree;
        }

        private static T Find(Dictionary<T, T> parent, T vertex)
        {
            while (!EqualityComparer<T>.Default.Equals(parent[vertex], vertex))
            {
                parent[vertex] = parent[parent[vertex]];
                vertex = parent[vertex];
            }

            return vertex;
        }

        public static double TotalWeight(IEnumerable<GraphEdge<T>> edgeList)
        {
            double total = 0;

            foreach (GraphEdge<T> edge in edgeList)
            {
                total += edge.Weight;
            }

            return total;
        }
    }
}
