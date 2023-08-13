using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace MapEditor
{
    public class Edge
    {
        public Vertex StartingPoint { get; set; }
        public Vertex EndingPoint { get; set; }
        public float Distance { get; set; }

        public Edge(Vertex startingPoint, Vertex endingPoint, float distance)
        {
            StartingPoint = startingPoint;
            EndingPoint = endingPoint;
            Distance = distance;
        }
    }
    public class Vertex
    {
        public float CumlativeDistance;
        public Vertex Founder;
        public bool HasBeenVisited;
        public Square Value { get; set; }
        public List<Edge> Neighbors { get; set; }

        public bool IsWall;
        public float FinalDistance;

        public int NeighborCount => Neighbors.Count;

        public Vertex(Square value)
        {
            CumlativeDistance = float.PositiveInfinity;
            FinalDistance = float.PositiveInfinity;
            Founder = null;
            HasBeenVisited = false;
            Neighbors = new List<Edge>();
            Value = value;
        }
    }
    public class GraphStuff
    {
        public List<Vertex> vertices;
        public List<Edge> edges;
        private List<Square> verticesValues;

        public int VertexCount => vertices.Count;

        public GraphStuff()
        {
            vertices = new List<Vertex>();
            edges = new List<Edge>();
            verticesValues = new List<Square>();
        }
        public void AddVertex(Square Value)
        {
            AddVertex(new Vertex(Value));
        }
        public void AddVertex(Vertex vertex)
        {
            if (vertex == null || vertex.NeighborCount != 0 || vertices.Contains(vertex) || verticesValues.Contains(vertex.Value))
            {
                return;
            }
            vertices.Add(vertex);
            verticesValues.Add(vertex.Value);
        }
        public bool RemoveVertex(Vertex vertex)
        {
            if (!vertices.Contains(vertex))
            {
                return false;
            }

            for (int i = 0; i < edges.Count; i++)
            {
                if (edges[i].EndingPoint == vertex)
                {
                    RemoveEdge(edges[i].StartingPoint, vertex);
                    i--;
                }
                else if (edges[i].StartingPoint == vertex)
                {
                    RemoveEdge(vertex, edges[i].EndingPoint);
                    i--;
                }
            }
            vertices.Remove(vertex);
            verticesValues.Remove(vertex.Value);
            return true;
        }
        public bool AddEdge(Vertex a, Vertex b, float distance)
        {
            if (a == null || b == null || a == b || !vertices.Contains(a) || !vertices.Contains(b) || GetEdge(a, b) != null)
            {
                return false;
            }
            Edge edge = new Edge(a, b, distance);
            edges.Add(edge);
            a.Neighbors.Add(edge);
            return true;
        }
        public bool RemoveEdge(Vertex a, Vertex b)
        {
            if (a == null || b == null || GetEdge(a, b) == null)
            {
                return false;
            }
            a.Neighbors.Remove(GetEdge(a, b));
            edges.Remove(GetEdge(a, b));

            return true;
        }
        public bool RemoveEdge(Edge edge)
        {
            if (edge == null)
            {
                return false;
            }
            edge.StartingPoint.Neighbors.Remove(edge);
            edges.Remove(edge);

            return true;
        }
        public int SearchForVertexIndex(Square value)
        {
            for (int i = 0; i < vertices.Count; i++)
            {
                if (vertices[i].Value.Equals(value))
                {
                    return i;
                }
            }
            return -1;
        }
        public Vertex Search(Square value)
        {
            for (int i = 0; i < vertices.Count; i++)
            {
                if (vertices[i].Value.Equals(value))
                {
                    return vertices[i];
                }
            }
            return null;
        }
        public int GetEdgeIndex(Vertex a, Vertex b)
        {
            if (a == null || b == null)
            {
                return -1;
            }
            for (int i = 0; i < edges.Count; i++)
            {
                if (edges[i].StartingPoint == a && edges[i].EndingPoint == b)
                {
                    return i;
                }
            }
            return -1;
        }
        public Edge GetEdge(Vertex a, Vertex b)
        {
            if (a == null || b == null)
            {
                return null;
            }

            for (int i = 0; i < edges.Count; i++)
            {
                if (edges[i].StartingPoint == a && edges[i].EndingPoint == b)
                {
                    return edges[i];
                }
            }
            return null;
        }

    }
}
