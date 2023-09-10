
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


namespace ActualGame.TypesOfMonkeys
{
    internal class Dart : Monkey
    {
        public (int, int) IncreaseRangeCostAndLvl;
        Stopwatch FiringTimer;
        public Bullet Bullet;
        bool ShouldFire;
        List<Zombie> zombies;
        List<bool> Bools;
        int total = 0;
        public Dart(Vector2 Position,ContentManager Content,Vector2 Origin,Screen screen, int baseRange,Position Grid,
            int baseDamage, int baseDamageUpgradeCost, int baseCooldown, int baseCooldownUpgradeCost, int baseRangeCost, int MaxLvl) 
            : base(screen,TypeOfMonkey.DartMonk,Grid,baseRange,baseDamage,baseDamageUpgradeCost,baseCooldown,baseCooldownUpgradeCost,MaxLvl,100)
        {
            IncreaseRangeCostAndLvl = (baseRangeCost, 0);
            RemoveCost = 50;
            Bullet = new Bullet(new Sprite(Color.White, Position, Content.Load<Texture2D>("Dart"),0,Origin,Vector2.One),0.1f,Vector2.Zero);
            ShouldFire = false;
            FiringTimer = new Stopwatch();
            sprite = new Sprite(Color.White,Position,Content.Load<Texture2D>("DartMonkey"),0,Origin,Vector2.One);
            Bools = new List<bool>();
            FiringTimer.Start();
        }
        
        public override void Draw(SpriteBatch spriteb)
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
        public override bool Update(ref List<Zombie> zombie)
        {
            sprite.Rotation = (float)(Math.Atan2(zombie[0].Position.Y - sprite.Position.Y, zombie[0].Position.X - sprite.Position.X));
            if (zombie == null || FiringTimer.ElapsedMilliseconds < CooldownAndCostAndLvl.Item1) return false;
            Bullet.Target = new Vector2(zombie[0].Position.X + sprite.Origin.X, zombie[0].Position.Y + sprite.Origin.Y);
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
