using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapEditor
{
    
    internal class AStar : GraphStuff
    {
        PriorityQueue<Vertex,float> Queue;
        public AStar() 
        {
            Queue = new PriorityQueue<Vertex, float>();
        }
        public int HeurManhattan(int nodeX, int nodeY, int goalX, int goalY, int Scalar)
        {
            int dx = Math.Abs(nodeX - goalX);
            int dy = Math.Abs(nodeY - goalY);
            return Scalar * (dx + dy);
        }
        public void InitializeVerticies(Vertex a, Vertex b)
        {
            if (a == null || b == null || a == b || a.NeighborCount == 0)
            {
                return;
            }
            foreach (var vertex in vertices)
            {
                vertex.HasBeenVisited = false;
                vertex.CumlativeDistance = float.PositiveInfinity;
                vertex.FinalDistance = float.PositiveInfinity;
                vertex.Founder = null;
            }
            a.CumlativeDistance = 0;

            a.FinalDistance = a.CumlativeDistance + HeurManhattan(a.Value.Picture.Location.X);

            Queue = new PriorityQueue<Vertex<T>, float>();
        }
        public List<Square> AStar(Square start, Square end)
        {
        }
    }
}
