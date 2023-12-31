﻿
using ActualGame.Enemies;
using ActualGame.ScreenAndGraph;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using ActualGame.Sprites;


namespace ActualGame.TypesOfMonkeys
{
    internal class Dart : Monkey
    {
        public (int, int) IncreaseRangeCostAndLvl;
        public Bullet Bullet;
        List<Zombie> zombies;
        List<bool> Bools;
        int total = 0;
        public Dart(Vector2 Position,ContentManager Content,Vector2 Origin,Screen screen, int baseRange,
            int baseDamage, int baseDamageUpgradeCost, int baseCooldown, int baseCooldownUpgradeCost, int baseRangeCost, int MaxLvl) 
            : base(screen,TypeOfMonkey.DartMonk, new Position(-1, -1),baseRange,baseDamage,baseDamageUpgradeCost,baseCooldown,baseCooldownUpgradeCost,MaxLvl,100)
        {
            IncreaseRangeCostAndLvl = (baseRangeCost, 0);
            RemoveCost = 50;
            Bullet = new Bullet(new Sprite(Color.White, Position, Content.Load<Texture2D>("Dart"),0,Origin,Vector2.One),0.1f,Vector2.Zero);
            sprite = new Sprite(Color.White,Position,Content.Load<Texture2D>("DartMonkey"),0,Origin,Vector2.One);
            Bools = new List<bool>();
        }
        
        public override void Draw(SpriteBatch spriteb,GameTime gameTime, Screen screen)
        {
            if (ShouldFire)
            {
                if(total == 0)
                {
                    total += Bullet.Draw(spriteb, sprite.Position, DamageAndCostAndLvl.Item1, ref zombies, ref Bools);
                }
                if (total == 1)
                {
                    total = 0;
                    ShouldFire = false;
                    Bullet.HasHit = false;
                }
            }
            sprite.Draw(spriteb);
        }
        
        public bool IncreaseRangeByOne(ref int Money,int CostIncrement,Screen screen)
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
                    if (!RangeSquares.Contains(screen.Map[CurrentPos.Y, CurrentPos.X].Value))
                    {
                        RangeSquares.Add(screen.Map[CurrentPos.Y, CurrentPos.X].Value);
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
        public override bool Update(ref List<Zombie> zombie, bool IsFast)
        {
            sprite.Rotation = (float)(Math.Atan2(zombie[0].Position.Y - sprite.Position.Y, zombie[0].Position.X - sprite.Position.X));
            if (zombie == null || FiringTimer.ElapsedMilliseconds < CooldownAndCostAndLvl.Item1) return false;
            int temp = 1;
            if(IsFast)
            {
                temp *= 2;
            }
            Bullet.Target = new Vector2(zombie[0].Path[zombie[0].currentPosition + temp].X * 30 + zombie[0].Origin.X, zombie[0].Path[zombie[0].currentPosition + temp].Y * 30 + zombie[0].Origin.Y);
            Bullet.sprite.Rotation = sprite.Rotation;
            zombies = zombie;
            Bools.Clear();

            for (int i = 0; i < zombie.Count; i++) { Bools.Add(false); }

            FiringTimer.Restart();
            ShouldFire = true;
            return true;
        }
    }
}
