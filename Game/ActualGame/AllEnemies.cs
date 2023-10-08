using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

using ActualGame.Enemies;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using Newtonsoft.Json;


namespace ActualGame
{
    public class Position
    {
        public sbyte X;
        public sbyte Y;
        public Position(sbyte x, sbyte y)
        {
            X = x;
            Y = y;
        }
    }
    internal class AllEnemies
    {
        public List<Zombie> Zombies = new List<Zombie>();
        Position[] path;
        public AllEnemies()
        {
            path = JsonConvert.DeserializeObject<Position[]>(File.ReadAllText(@"..\..\..\..\MapEditor\Path.txt"));
            Zombies = new List<Zombie>();
        }
        public void AddANormalZombie(int Level, ScreenSquare Start, ContentManager Content, bool IsFast)
        {
            Zombies.Add(new NormalZombie(Level, new Vector2(Start.Sprite.Position.X + 15, Start.Sprite.Position.Y + 15),
                Content.Load<Texture2D>("Zombie"), 0, new Vector2(15, 15)
                , Vector2.One, path, IsFast, 1000));
        }
        public void AddaMinerZombie(ContentManager Content, ScreenSquare Start, ref Screen screen, ref AllMonkeys monkeys)
        {
            Zombies.Add(new PathMakerZombie(new Vector2(Start.Sprite.Position.X + 15, Start.Sprite.Position.Y + 15),
                Content.Load<Texture2D>("ZombieMiner"), 0, new Vector2(15, 15), Vector2.One, ref screen, ref monkeys, 75,1000));
        }
        public void IncreaseSpeedOfAllZombies()
        {
            foreach (var zombie in Zombies)
            {
                zombie.LerpIncrement *= 2;
            }
        }
        public void DecreaseSpeedOfAllZombies()
        {
            foreach (var zombie in Zombies)
            {
                zombie.LerpIncrement /= 2;
            }
        }
        public bool UpdateAllZombies(int SizeOfSquare, int offset, Screen screen, SideScreen sideScreen)
        {
            // logic for removing and adding zombies 
            if (Zombies.Count == 0) return true;
            NormalZombie Prev = (NormalZombie)Zombies[0];
            int index = 0;
            for (int i = 0; i < Zombies.Count; i++)
            {
                if (Zombies[i].ZombieType == TypeOfZombie.Normal)
                {
                    NormalZombie current = (NormalZombie)Zombies[i];
                    if (current.Health <= 0)
                    {
                        sideScreen.Money += current.LevelToReward[current.Level];
                        if (current.Level == 0)
                        {
                            screen.Map[current.Path[current.currentPosition].Y, current.Path[current.currentPosition].X].Value.OneContained.Remove(current);
                            if (screen.Map[current.Path[current.currentPosition].Y, current.Path[current.currentPosition].X].Value.OneContained.Count == 0)
                            {
                                screen.Map[current.Path[current.currentPosition].Y, current.Path[current.currentPosition].X].Value.DoesContainZombie = false;
                            }
                            Zombies.RemoveAt(i);
                        }
                        else
                        {
                            current.UpdateLevel();
                        }
                        continue;
                    }
                    if (index != 0 && !Prev.HasLerpedOnce) //Controls moving in suconly when the previous has moved
                    {
                        continue;
                    }
                    if (!current.MoveEnemyAlongPathOnce(SizeOfSquare, ref screen))//Only handles when the zombies go off screen no killing involved
                    {
                        Zombies.Remove(current);
                        sideScreen.Lives--;
                        if (Zombies.Count == 0) return true;
                    }
                    Prev = (NormalZombie)Zombies[index];
                    index++;
                }
                else
                {
                    PathMakerZombie current = (PathMakerZombie)Zombies[i];
                    if (current.Health <= 0)
                    {
                        sideScreen.Money += current.Reward;

                        screen.Map[current.Path[current.currentPosition].Y, current.Path[current.currentPosition].X].Value.OneContained.Remove(current);
                        if (screen.Map[current.Path[current.currentPosition].Y, current.Path[current.currentPosition].X].Value.OneContained.Count == 0)
                        {
                            screen.Map[current.Path[current.currentPosition].Y, current.Path[current.currentPosition].X].Value.DoesContainZombie = false;
                        }
                        Zombies.RemoveAt(i);

                        continue;
                    }
                    if (index != 0 && !Prev.HasLerpedOnce) //Controls moving in suconly when the previous has moved
                    {
                        continue;
                    }
                    if (!current.MoveEnemyAlongPathOnce(SizeOfSquare, ref screen))//Only handles when the zombies go off screen no killing involved
                    {
                        Zombies.Remove(current);
                        sideScreen.Lives--;
                        if (Zombies.Count == 0) return true;
                    }
                    Prev = (NormalZombie)Zombies[index];
                    index++;
                }


            }
            return false;
        }
        public void DrawAllZombies(SpriteBatch sprite)
        {
            foreach (var item in Zombies)
            {
                item.Draw(sprite);
            }
        }
    }
}
