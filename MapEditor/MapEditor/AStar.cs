using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapEditor
{
    public class Position
    {
        public int IndexX;
        public int IndexY;
        public Position(int x, int y)
        {
            IndexX = x;
            IndexY = y;
        }
    }
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
        public Position Value { get; set; }
        public List<Edge> Neighbors { get; set; }

        public float FinalDistance;

        public int NeighborCount => Neighbors.Count;

        public Vertex(Position value)
        {
            CumlativeDistance = float.PositiveInfinity;
            FinalDistance = float.PositiveInfinity;
            Founder = null;
            HasBeenVisited = false;
            Neighbors = new List<Edge>();
            Value = value;
        }
    }
    internal class AStar : GraphStuff
    {
        PriorityQueue<Vertex,float> Queue;
        public AStar() 
        {
            Queue = new PriorityQueue<Vertex, float>();
        }
        public static int HeurManhattan(int nodeX, int nodeY, int goalX, int goalY, int Scalar)
        {
            int dx = Math.Abs(nodeX - goalX);
            int dy = Math.Abs(nodeY - goalY);
            return Scalar * (dx + dy);
        }
        public void InitializeAllVertices(Square[,] Grass)
        {

        }
        public static List<Vertex> AStar()
        {

        }
    }
}
