using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Xna.Framework.Content;

namespace ActualGame
{

    internal class Screen 
    {
        public BuildGraph buildGraph;
        public Vertex[,] Map;
        public Vertex Start;
        public Vertex End;
        public Screen(int ScreenSize, int ImageSize,ContentManager Content)
        {
            buildGraph = new BuildGraph();
            Map = new Vertex[ScreenSize/ImageSize, ScreenSize / ImageSize];
            int[] ints = JsonConvert.DeserializeObject<int[]>(File.ReadAllText(@"..\..\..\..\MapEditor\Background.txt"));
            int x = 0;
            int y = 0;
            int ImageIndex = 0;
            bool hasWentToStart = false;
            bool hasWentToEnd = false;
            for(int i = 0; i < Map.GetLength(1);i++)
            {
                //C:\Users\shrey\OneDrive\Documents\GitHub\Github\BT1\Game\ActualGame\Content\Grass.png
                //"C:\Users\shrey\OneDrive\Documents\GitHub\Github\BT1\Game\ActualGame\Content\Grass.png"
                Texture2D image = Content.Load<Texture2D>("Grass");
                TypeOfImage type = TypeOfImage.Grass;
                for (int z = 0;z < Map.GetLength(0);z++)
                {
                    switch(ints[ImageIndex])
                    {
                        case 0://eraser
                            type = TypeOfImage.Grass; 
                            image = Content.Load<Texture2D>("Grass");
                            break;
                        case 1://start
                            type = TypeOfImage.Start;
                            image = Content.Load<Texture2D>("Path");
                            hasWentToStart = true;
                            break;
                        case 2://end
                            type = TypeOfImage.End;
                            image = Content.Load<Texture2D>("Path");
                            hasWentToEnd = true;
                            break;
                        case 3://path
                            type = TypeOfImage.Path;
                            image = Content.Load<Texture2D>("Path");
                            break;
                    }
                    Sprite Current = new Sprite(Color.White, new Vector2(x,y),image,0,Vector2.Zero,Vector2.One);
                    Map[i, z] = new Vertex(new ScreenSquare(Current,type,new Position((sbyte)z, (sbyte)i),Content.Load<Texture2D>("Path")));
                    if (hasWentToStart)
                    {
                        Start = Map[i, z];
                        hasWentToStart = false;
                    }
                    if(hasWentToEnd)
                    {
                        End = Map[i, z];
                        hasWentToEnd = false;
                    }
                    x += ImageSize;
                    ImageIndex++;
                }
                y += ImageSize;
                x = 0;
            }
            buildGraph.InitializeVerticies(Map);
            buildGraph.InitializeEdges(Map);
        }
        public void DrawScreen(SpriteBatch spriteBatch)
        {
            foreach(var item in Map)
            {
                item.Value.CheckShouldBePath();
                item.Value.Sprite.Draw(spriteBatch);
            }
        }
    }
}
