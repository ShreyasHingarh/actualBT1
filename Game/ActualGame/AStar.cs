using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActualGame
{
    
    internal class AStar : GraphStuff
    {
        PriorityQueue<Vertex,float> Queue;

        int Scalar;
        List<Vertex> AreInQueue;
        public AStar() 
        {
            Queue = new PriorityQueue<Vertex, float>();
            AreInQueue = new List<Vertex>();
            Scalar = 1;
        }
        public int HeurManhattan(int nodeX, int nodeY, int goalX, int goalY)
        {
            int dx = Math.Abs(nodeX - goalX);
            int dy = Math.Abs(nodeY - goalY);
            return Scalar * (dx + dy);
        }
        public void InitializeVerticies(ref Vertex a, ref Vertex b)
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

            a.FinalDistance = a.CumlativeDistance + HeurManhattan(a.Value.GridLocation.X,a.Value.GridLocation.Y,b.Value.GridLocation.X, b.Value.GridLocation.Y);

            Queue = new PriorityQueue<Vertex, float>();
            AreInQueue.Clear();
            Queue.Enqueue(a,a.FinalDistance);
            AreInQueue.Add(a);
        }
        public List<Vertex> AStarThing(Vertex start, Vertex end)
        {
            InitializeVerticies(ref start, ref end);
            Vertex Current;
            while(!end.HasBeenVisited && Queue.Count != 0)
            {
                Current = Queue.Dequeue();
                foreach(var item in Current.Neighbors)
                {
                    if (item.EndingPoint.IsWall || item.EndingPoint.HasBeenVisited || AreInQueue.Contains(item.EndingPoint)) continue;
                    float tentativeDistance = Current.CumlativeDistance + item.Distance;
                    if(tentativeDistance < item.EndingPoint.CumlativeDistance)
                    {
                        item.EndingPoint.CumlativeDistance = tentativeDistance;
                        item.EndingPoint.Founder = Current;
                        item.EndingPoint.FinalDistance = item.EndingPoint.CumlativeDistance + 
                            HeurManhattan(item.EndingPoint.Value.GridLocation.X, item.EndingPoint.Value.GridLocation.Y,end.Value.GridLocation.X,end.Value.GridLocation.Y);
                    }
                    Queue.Enqueue(item.EndingPoint, item.EndingPoint.FinalDistance);
                    AreInQueue.Add(item.EndingPoint);
                }
                Current.HasBeenVisited = true;
                AreInQueue.Remove(Current);
            }
            List<Vertex> vertices = new List<Vertex>();
            Current = end;
            if(end.Founder == null || !end.HasBeenVisited)
            {
                return null;
            }
            while (Current.Founder != null)
            {
                vertices.Add(Current);
                Current = Current.Founder;
            }
            vertices.Add(start);
            vertices.Add(start.Neighbors[2].EndingPoint);
            return vertices;
        }
    }
}
