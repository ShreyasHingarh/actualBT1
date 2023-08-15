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
    }
    internal class AllEnemies
    {
        List<Zombie> Zombies = new List<Zombie>();
        public AllEnemies(ScreenSquare Start,int offSet,ContentManager Content)
        {
            Position[] path = JsonConvert.DeserializeObject<Position[]>(File.ReadAllText(@"C:\Users\shrey\OneDrive\Documents\GitHub\Github\BT1\Game\MapEditor\Path.txt"));
            Zombies = new List<Zombie>()
            {
                new Zombie(0, new Vector2(Start.Sprite.Position.X * Start.Sprite.Image.Width + offSet, Start.Sprite.Position.Y * Start.Sprite.Image.Width + offSet),
                Content.Load<Texture2D>("Zombie"), 0, Vector2.Zero
                , Vector2.One, 10, path),

                new Zombie(1, new Vector2(Start.Sprite.Position.X * Start.Sprite.Image.Width + offSet, Start.Sprite.Position.Y * Start.Sprite.Image.Width + offSet),
                Content.Load<Texture2D>("Zombie"), 0, Vector2.Zero
                , Vector2.One, 10, path),
                
                new Zombie(2, new Vector2(Start.Sprite.Position.X * Start.Sprite.Image.Width + offSet, Start.Sprite.Position.Y * Start.Sprite.Image.Width + offSet),
                Content.Load<Texture2D>("Zombie"), 0, Vector2.Zero
                , Vector2.One, 10, path),
                
                new Zombie(3, new Vector2(Start.Sprite.Position.X * Start.Sprite.Image.Width + offSet, Start.Sprite.Position.Y * Start.Sprite.Image.Width + offSet),
                Content.Load<Texture2D>("Zombie"), 0, Vector2.Zero
                , Vector2.One, 10, path)
            };
        }
        public void UpdateAllZombies(int SizeOfSquare, int offset)
        {
            // logic for removing and adding zombies 
            Zombie Prev = Zombies[0];
            int index = 0;
            foreach (var item in Zombies)
            {
                if (index != 0 && !Prev.HasLerpedOnce) continue;

                item.MoveEnemyAlongPathOnce(SizeOfSquare, offset);
                Prev = Zombies[index];
                index++;
            }    
        }
        public void DrawAllZombies(SpriteBatch sprite)
        {
            foreach(var item in Zombies)
            {
                item.Draw(sprite);
            }
        }
    }
}
