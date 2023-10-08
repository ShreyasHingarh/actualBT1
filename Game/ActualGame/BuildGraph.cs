using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActualGame
{
    internal class BuildGraph
    {
        public AStar Graph;
        public BuildGraph()
        {
            Graph = new AStar();
        }
        public void InitializeVerticies(Vertex[,] Grasses)
        {
            //AddAllVertices
            for (int i = 0; i < Grasses.GetLength(1); i++)
            {
                for (int z = 0; z < Grasses.GetLength(0); z++)
                {
                    Graph.AddVertex(Grasses[i, z]);
                }
            }
        }
        private void compareForTheGreater(bool isForX, int ypos, int xpos, int yamount, int xamount, float horDistance, Vertex[,] Grasses)
        {
            int posToChance = isForX ? xpos : ypos;
            int amountToChance = isForX ? xamount : yamount;
            if (posToChance + 1 < amountToChance)
            {
                if (!isForX)
                {
                    Graph.AddEdge(Grasses[ypos, xpos], Grasses[ypos + 1, xpos], horDistance);
                }
                else
                {
                    Graph.AddEdge(Grasses[ypos, xpos], Grasses[ypos, xpos + 1], horDistance);
                }
            }

        }
        private void compareForTheLower(bool isForX, int ypos, int xpos, float horDistance, Vertex[,] Grasses)
        {
            int posToChance = isForX ? xpos : ypos;
            if (posToChance - 1 >= 0)
            {
                if (!isForX)
                {
                    Graph.AddEdge(Grasses[ypos, xpos], Grasses[ypos - 1, xpos], horDistance);
                }
                else
                {
                    Graph.AddEdge(Grasses[ypos, xpos], Grasses[ypos, xpos - 1], horDistance);
                }
            }
        }
        public void CreateEdgesForAVertex(int xpos, int ypos, Vertex[,] Grasses)
        {
            if (xpos < 0 || xpos >= Grasses.GetLength(0) || ypos < 0 || ypos >= Grasses.GetLength(1)) return;

            compareForTheLower(true, ypos, xpos, 1, Grasses);
            compareForTheLower(false, ypos, xpos, 1, Grasses);
            compareForTheGreater(true, ypos, xpos, Grasses.GetLength(1), Grasses.GetLength(0), 1, Grasses);
            compareForTheGreater(false, ypos, xpos, Grasses.GetLength(1), Grasses.GetLength(0), 1, Grasses);
        }
        public void InitializeEdges(Vertex[,] Grasses)
        {
            //AddAllEdges
            for (int i = 0; i < Grasses.GetLength(1); i++)
            {
                for (int z = 0; z < Grasses.GetLength(0); z++)
                {
                    CreateEdgesForAVertex(z, i, Grasses);
                }
            }
        }
    }
}
