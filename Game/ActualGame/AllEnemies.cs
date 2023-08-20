using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;

using SharpDX.MediaFoundation;

namespace ActualGame
{
    public class Position
    {
        public int X;
        public int Y;
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
        public Position(Vector2 thing)
        {
            X = (int)thing.X;
            Y = (int)thing.Y;
        }
    }
    internal class AllEnemies
    {
        public int Lives;
        public List<Zombie> Zombies = new List<Zombie>();
        public AllEnemies(ScreenSquare Start,int offSet,ContentManager Content)
        {
            Lives = 100;
            Position[] path = JsonConvert.DeserializeObject<Position[]>(File.ReadAllText(@"C:\Users\shrey\OneDrive\Documents\GitHub\Github\BT1\Game\MapEditor\Path.txt"));
            Zombies = new List<Zombie>()
            {
                new Zombie(0, new Vector2(Start.Sprite.Position.X * Start.Sprite.Image.Width + offSet, Start.Sprite.Position.Y * Start.Sprite.Image.Width + offSet),
                Content.Load<Texture2D>("Zombie"), 0, Vector2.Zero
                , Vector2.One, 10, path),

                new Zombie(1, new Vector2(Start.Sprite.Position.X * Start.Sprite.Image.Width + offSet, Start.Sprite.Position.Y * Start.Sprite.Image.Width + offSet),
                Content.Load<Texture2D>("Zombie"), 0, Vector2.Zero
                , Vector2.One, 20, path),
                
                new Zombie(2, new Vector2(Start.Sprite.Position.X * Start.Sprite.Image.Width + offSet, Start.Sprite.Position.Y * Start.Sprite.Image.Width + offSet),
                Content.Load<Texture2D>("Zombie"), 0, Vector2.Zero
                , Vector2.One, 30, path),
                
                new Zombie(3, new Vector2(Start.Sprite.Position.X * Start.Sprite.Image.Width + offSet, Start.Sprite.Position.Y * Start.Sprite.Image.Width + offSet),
                Content.Load<Texture2D>("Zombie"), 0, Vector2.Zero
                , Vector2.One, 40, path)
            };
        }
        public bool UpdateAllZombies(int SizeOfSquare, int offset,Screen screen)
        {
            // logic for removing and adding zombies 
            if (Zombies.Count == 0) return true;
            Zombie Prev = Zombies[0];
            int index = 0;
            for(int i = 0;i < Zombies.Count;i++)
            {
                if (index != 0 && !Prev.HasLerpedOnce) continue;

                if(!Zombies[i].MoveEnemyAlongPathOnce(SizeOfSquare, offset,screen))//Only handles when the zombies go off screen no killing involved
                {
                    Zombies.Remove(Zombies[i]);
                    Lives--;
                    if (Zombies.Count == 0) return true;//switch to next level
                }
                Prev = Zombies[index];
                index++;
            }
            return false;
        }
        public void DrawAllZombies(SpriteBatch sprite,ContentManager Content)
        {
            sprite.DrawString(Content.Load<SpriteFont>("File"),$"{Lives}",new Vector2(900,100),Color.Black);
            foreach(var item in Zombies)
            {
                item.Draw(sprite);
            }
        }
    }
}
