using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using ActualGame.Enemies;
using ActualGame.ScreenAndGraph;
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
        public LinkedL<Zombie> Zombies = new LinkedL<Zombie>();
        public int IndexOfZombie = 0;
        Position[] path;
        public AllEnemies()
        {
            path = JsonConvert.DeserializeObject<Position[]>(File.ReadAllText(@"..\..\..\..\MapEditor\Path.txt"));
            Zombies = new LinkedL<Zombie>();
        }
        public void AddANormalZombie(int Level, ScreenSquare Start, ContentManager Content, bool IsFast)
        {
            Zombies.AddLast(new NormalZombie(Level, new Vector2(Start.Sprite.Position.X + 15, Start.Sprite.Position.Y + 15),
                Content.Load<Texture2D>("Zombie"), 0, new Vector2(15, 15)
                , Vector2.One, path, IsFast, 1000));
            IndexOfZombie++;
        }
        public void AddaMinerZombie(ContentManager Content, ScreenSquare Start, ref Screen screen, ref AllMonkeys monkeys)
        {
            Zombies.AddLast(new PathMakerZombie(new Vector2(Start.Sprite.Position.X + 15, Start.Sprite.Position.Y + 15),
                Content.Load<Texture2D>("ZombieMiner"), 0, new Vector2(15, 15), Vector2.One, ref screen, ref monkeys, 75, 1000));
            IndexOfZombie++;
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
            Zombie Prev = Zombies.Tail.Value;
            //After Head has finished lerping move onto the next node and then when tail loop back to Head
            int index = 0;
            for(int i = 0;i < Zombies.Count;i++)
            {
                if (Zombies[i].Health <= 0)
                {
                    if (Zombies[i].ZombieType == TypeOfZombie.Normal)
                    {
                        NormalZombie temp = (NormalZombie)Zombies[i];
                        sideScreen.Money += temp.LevelToReward[Zombies[i].Level];
                        Zombies[i] = temp;
                    }
                    else
                    {
                        PathMakerZombie temp = (PathMakerZombie)Zombies[i];
                        sideScreen.Money += temp.Reward;
                        Zombies[i] = temp;
                    }
                    if (Zombies[i].Level == 0)
                    {
                        screen.Map[Zombies[i].Path[Zombies[i].currentPosition].Y, Zombies[i].Path[Zombies[i].currentPosition].X].Value.OneContained.Remove(Zombies[i]);
                        if (screen.Map[Zombies[i].Path[Zombies[i].currentPosition].Y, Zombies[i].Path[Zombies[i].currentPosition].X].Value.OneContained.Count == 0)
                        {
                            screen.Map[Zombies[i].Path[Zombies[i].currentPosition].Y, Zombies[i].Path[Zombies[i].currentPosition].X].Value.DoesContainZombie = false;
                        }
                        Zombies.Remove(Zombies[i]);
                    }
                    else
                    {
                        NormalZombie temp = (NormalZombie)Zombies[i];
                        temp.UpdateLevel();
                        Zombies[i] = temp;
                    }
                    continue;
                }
                
                if (index != 0 && !Prev.HasLerpedOnce) //Controls moving in suconly when the previous has moved
                {
                    continue;
                }
                if (!Zombies[i].MoveEnemyAlongPathOnce(SizeOfSquare, ref screen))//Only handles when the zombies go off screen no killing involved
                {
                    Zombies.Remove(Zombies[i]);
                    sideScreen.Lives--;
                    if (Zombies.Count == 0) return true;
                }
                LNode<Zombie> thing = Zombies.Search(Prev).Next;
                if (thing != null)
                {
                    Prev = thing.Value;
                }
                index++;
               
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
