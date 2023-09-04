using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActualGame.TypesOfMonkeys
{
    internal class Spike : Monkey
    {
        public (int, int) IncreaseRangeCostAndLvl;
        Stopwatch FiringTimer;
        Bullet[] Bullets;
        bool ShouldFire;
        int total = 0;
        public Spike(Vector2 Position, ContentManager Content, Vector2 Origin, Screen screen, TypeOfMonkey type, Position gridpos,
            int baseRange, int baseDamage, int baseDamageUpgradeCost, int baseCooldown, int baseCooldownUpgradeCost, int baseRangeCost, int MaxLvl)
            : base(screen, type, gridpos, baseRange, baseDamage, baseDamageUpgradeCost, baseCooldown, baseCooldownUpgradeCost, MaxLvl)
        {
            ShouldFire = false;
            RemoveCost = 100;
            Texture2D Dart = Content.Load<Texture2D>("Dart");
            Bullets = new Bullet[]
            {
                new Bullet(new Sprite(Color.White,Position,Dart,0,Origin,Vector2.One), 0.1f),
                new Bullet(new Sprite(Color.White,Position,Dart,(float)(Math.PI/4),Origin,Vector2.One), 0.1f),
                new Bullet(new Sprite(Color.White,Position,Dart,(float)(Math.PI/2),Origin,Vector2.One), 0.1f),
                new Bullet(new Sprite(Color.White,Position,Dart,(float)(3 * Math.PI/4),Origin,Vector2.One), 0.1f),
                new Bullet(new Sprite(Color.White,Position,Dart,(float)(Math.PI),Origin,Vector2.One), 0.1f),
                new Bullet(new Sprite(Color.White,Position,Dart,(float)(5 * Math.PI/4),Origin,Vector2.One), 0.1f),
                new Bullet(new Sprite(Color.White,Position,Dart,(float)(3 * Math.PI/2),Origin,Vector2.One), 0.1f),
                new Bullet(new Sprite(Color.White,Position,Dart,(float)(7 * Math.PI/4),Origin,Vector2.One), 0.1f)
            }; 
            for (int i = 0; i < Bullets.Length; i++)
            {
                ///////////////////////////////////////////////////////////////////////////////////////////////////// Figure out the targets
                Bullets[i].Target = new Vector2();
            }
            sprite = new Sprite(Color.White, Position, Content.Load<Texture2D>("SpikeMonkey"), 0, Origin, Vector2.One);
            IncreaseRangeCostAndLvl = (baseRangeCost, 0);
            FiringTimer.Start();
        }
        
        
        public bool IncreaseRangeByOne(ref int Money, int CostIncrement,Screen screen)
        {
            if (IncreaseRangeCostAndLvl.Item1 >= Money || IncreaseRangeCostAndLvl.Item2 == MaxUpgradeLvl) return false;
            RemoveCost += CostIncrement / 3;
            Money -= IncreaseRangeCostAndLvl.Item1;
            IncreaseRangeCostAndLvl.Item1 += CostIncrement;
            IncreaseRangeCostAndLvl.Item2++;
            RangeSize++;
            Position CurrentPos = new Position(GridPosition.X, GridPosition.Y);
            int indexX = 0;
            while (indexX < RangeSize && CurrentPos.X > 0)
            {
                CurrentPos.X--;
                indexX++;
            }
            int indexY = 0;
            while (indexY < RangeSize && CurrentPos.Y > 0)
            {
                CurrentPos.Y--;
                indexY++;
            }
            indexX += RangeSize + 1;
            indexY += RangeSize + 1;
            sbyte originalX = CurrentPos.X;
            for (int i = 0; i < indexY; i++)
            {
                for (int x = 0; x < indexX; x++)
                {
                    if (!RangeSquares.Contains(screen.Map[CurrentPos.Y, CurrentPos.X]))
                    {
                        RangeSquares.Add(screen.Map[CurrentPos.Y, CurrentPos.X]);

                    }
                    CurrentPos.X++;
                    if (CurrentPos.X == screen.Map.GetLength(0)) break;
                }
                CurrentPos.X = originalX;
                CurrentPos.Y++;
                if (CurrentPos.Y == screen.Map.GetLength(1)) break;
            }
            return true;
        }

        public override void Draw(SpriteBatch spriteB)
        {
            if(ShouldFire)
            {
                for(int i = 0; i < Bullets.Length;i++)
                {
                    if (Bullets[i].HasHit) continue;
                    total += Bullets[i].Draw(spriteB, sprite.Position, RangeSquares, DamageAndCostAndLvl.Item1);
                }
                if(total == Bullets.Length)
                {
                    total = 0;
                    ShouldFire = false;
                    foreach(var item in Bullets)
                    {
                        item.HasHit = false;
                    }
                }
            }
            sprite.Draw(spriteB);
        }

        public override bool Update(ref Zombie zombie)
        {
            if (zombie == null || FiringTimer.ElapsedMilliseconds < CooldownAndCostAndLvl.Item1) return false;
            FiringTimer.Restart();
            ShouldFire = true;
            return true;
        }
    }
}
