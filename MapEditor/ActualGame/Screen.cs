﻿using Microsoft.Xna.Framework;
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
        public ScreenSquare[,] Map;
        public Screen(int ScreenSize, int ImageSize,ContentManager Content)
        {
            Map = new ScreenSquare[ScreenSize/ImageSize, ScreenSize / ImageSize];
            List<int> ints = (List<int>)JsonConvert.DeserializeObject(File.ReadAllText(@"\\GMRDC1\Folder Redirection\shreyas.hingarh\Documents\Github\ActualBT1\MapEditor\MapEditor\Background.txt"));
            int x = 0;
            int y = 0;
            int ImageIndex = 0;
            for(int i = 0; i < Map.GetLength(1);i++)
            {
                Sprite Current;
                Texture2D image = Content.Load<Texture2D>("Grass.png");
                TypeOfImage type = TypeOfImage.Grass;
                for (int z = 0;z < Map.GetLength(0);z++)
                {
                    switch(ints[ImageIndex])
                    {
                        case 0://eraser
                            type = TypeOfImage.Grass; 
                            image = Content.Load<Texture2D>("Grass.png");
                            break;
                        case 1://start
                            type = TypeOfImage.Start;
                            image = Content.Load<Texture2D>("Path.png");
                            break;
                        case 2://end
                            type = TypeOfImage.End;
                            image = Content.Load<Texture2D>("Path.png");
                            break;
                        case 3://path
                            type = TypeOfImage.Path;
                            image = Content.Load<Texture2D>("Path.png");
                            break;
                    }
                    Current = new Sprite(Color.White, new Vector2(x,y),image,0,Vector2.Zero,Vector2.One);
                    Map[i, z] = new ScreenSquare(Current,type,new Vector2(z,i));
                    x += ImageSize;
                    ImageIndex++;
                }
                y += ImageSize;
                x = 0;
            }
        }
        public void DrawScreen(SpriteBatch spriteBatch)
        {
            foreach(var item in Map)
            {
                item.Sprite.Draw(spriteBatch);
            }
        }
    }
}
