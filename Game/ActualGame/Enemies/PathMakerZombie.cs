using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActualGame.Enemies
{
    internal class PathMakerZombie : Zombie
    {
        Random gen = new Random();
        public int Reward;
        public PathMakerZombie(Vector2 position, Texture2D image, float rotation, Vector2 origin, Vector2 scale, ref Screen screen, ref AllMonkeys monkeys, int health,int maxFrozenTime)
            : base(Color.White, position, image, rotation, origin, scale,0.1f,TypeOfZombie.Miner,maxFrozenTime)
        {
            Reward = 75;
            Path = GeneratePath(ref screen,ref monkeys);
            Health = health;
        }

        Position[] GeneratePath(ref Screen screen,ref AllMonkeys monkeys)
        {
            List<Vertex> Path = new List<Vertex>();
            do
            {
                foreach (var Vertex in screen.Map)
                {
                    Vertex.IsWall = false;
                    int chance = gen.Next(0, 3);
                    if (chance == 1)
                    {
                        Vertex.IsWall = true;
                    }
                }
                foreach (var monkey in monkeys.Monkeys)
                {
                    screen.Map[monkey.GridPosition.Y, monkey.GridPosition.X].IsWall = true;
                }
                screen.buildGraph.Graph.InitializeVerticies(ref screen.Start, ref screen.End);
                Path = screen.buildGraph.Graph.AStarThing(screen.Start, screen.End);

            } while (Path == null);


            Position[] paths = new Position[Path.Count];
            int index = 0;
            foreach(var item in Path)
            {
                paths[index] = item.Value.GridLocation;
                index++;
            }
            return paths;
        }
        public override bool MoveEnemyAlongPathOnce(int SizeOfSquare, ref Screen screen)
        {
            if (currentPosition + 1 == Path.Length) return false;
            
            Position NextSquare = Path[currentPosition + 1];

            screen.Map[Path[currentPosition].Y, Path[currentPosition].X].Value.DoesContainZombie = true;
            screen.Map[Path[currentPosition].Y, Path[currentPosition].X].Value.OneContained.Add(this);
            screen.Map[Path[currentPosition].Y, Path[currentPosition].X].Value.ShouldStartBeingPath = true;
            if (LerpAmount < 1f)
            {
                Position = Vector2.Lerp(PreviousPosition, new Vector2(NextSquare.X * SizeOfSquare + 15, NextSquare.Y * SizeOfSquare + 15), LerpAmount);
                LerpAmount += LerpIncrement;
                return true;
            }
            screen.Map[Path[currentPosition].Y, Path[currentPosition].X].Value.OneContained.Remove(this);
            if (screen.Map[Path[currentPosition].Y, Path[currentPosition].X].Value.OneContained.Count == 0)
            {
                screen.Map[Path[currentPosition].Y, Path[currentPosition].X].Value.DoesContainZombie = false;
            }
            currentPosition += 1;
            LerpAmount = 0f;
            HasLerpedOnce = true;
            PreviousPosition = Position;
            return true;
        }
    }
}
