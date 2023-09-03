using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;


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
        public List<Zombie> Zombies = new List<Zombie>();
        Position[] path;
        public AllEnemies(ScreenSquare Start,int offSet,ContentManager Content)
        {
            path = JsonConvert.DeserializeObject<Position[]>(File.ReadAllText(@"..\..\..\..\MapEditor\Path.txt"));
            Zombies = new List<Zombie>();
        }
        public void AddAZombie(int Level, ScreenSquare Start, int offSet, ContentManager Content)
        {
            Zombies.Add(new Zombie(Level, new Vector2(Start.Sprite.Position.X * Start.Sprite.Image.Width + offSet, Start.Sprite.Position.Y * Start.Sprite.Image.Width + offSet),
                Content.Load<Texture2D>("Zombie"), 0, Vector2.Zero
                , Vector2.One, path));
        }
        public void IncreaseSpeedOfAllZombies()
        {
            foreach(var zombie in Zombies) 
            {
                zombie.LerpIncrement *= 2;
            }
        }
        public void DecreaseSpeedOfAllZombies()
        {
            foreach( var zombie in Zombies)
            {
                zombie.LerpIncrement /= 2;
            }
        }
        public bool UpdateAllZombies(int SizeOfSquare, int offset,Screen screen,SideScreen sideScreen)
        {
            // logic for removing and adding zombies 
            if (Zombies.Count == 0) return true;
            Zombie Prev = Zombies[0];
            int index = 0;
            
            for(int i = 0;i < Zombies.Count;i++)
            {
                if (Zombies[i].Health <= 0)
                {
                    sideScreen.Money += Zombies[i].LevelToReward[Zombies[i].Level];
                    if (Zombies[i].Level == 0)
                    {
                        screen.Map[Zombies[i].Path[Zombies[i].currentPosition].Y, Zombies[i].Path[Zombies[i].currentPosition].X].OneContained = null;
                        screen.Map[Zombies[i].Path[Zombies[i].currentPosition].Y, Zombies[i].Path[Zombies[i].currentPosition].X].DoesContainZombie = false;
                        Zombies.RemoveAt(i);
                    }
                    else
                    {
                        Zombies[i].UpdateLevel();
                    }
                    continue;
                }
                if (index != 0 && !Prev.HasLerpedOnce) continue;

                if(!Zombies[i].MoveEnemyAlongPathOnce(SizeOfSquare, offset,screen))//Only handles when the zombies go off screen no killing involved
                {
                    Zombies.Remove(Zombies[i]);
                    sideScreen.Lives--;
                    if (Zombies.Count == 0) return true;
                }
                Prev = Zombies[index];
                index++;
            }
            return false;
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
