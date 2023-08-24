using Assimp;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using SharpDX.Direct3D9;
using SharpDX.MediaFoundation;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ActualGame.TypesOfMonkeys
{
    internal class Dart : Monkey
    {
        (int, int,int) DamageAndCostAndLvl;
        (int, int,int) CooldownAndCostAndLvl;
        (int,int) IncreaseRangeCostAndLvl;
        int MaxUpgradeLvl;
        Stopwatch FiringTimer;
        Sprite Bullet;
        Vector2 Target;
        bool ShouldFire;
        float LerpAmount;
        float LerpIncrement;
        public Dart(Vector2 Position,ContentManager Content,Vector2 Origin,Screen screen, int baseRange,Position Grid, 
            int baseDamage,int baseDamageUpgradeCost,int baseCooldown,int baseCooldownUpgradeCost,int baseRangeCost,int MaxLvl) 
            : base(screen,TypeOfMonkey.DartMonk,Grid,baseRange)
        {
            Bullet = new Sprite(Color.White, Position, Content.Load<Texture2D>("Dart"),0,Origin,Vector2.One) ;
            ShouldFire = false;
            MaxUpgradeLvl = MaxLvl;
            FiringTimer = new Stopwatch();
            sprite = new Sprite(Color.White,Position,Content.Load<Texture2D>("Monkey"),0,Origin,Vector2.One);
            DamageAndCostAndLvl = (baseDamage, baseDamageUpgradeCost,0);
            CooldownAndCostAndLvl = (baseCooldown, baseCooldownUpgradeCost,0);
            IncreaseRangeCostAndLvl = (baseRangeCost,0);
            LerpAmount = 0;
            LerpIncrement = 0.2f;
            FiringTimer.Start();
        }
        
        public override void Draw(SpriteBatch spriteb,ContentManager Content)
        {
            spriteb.DrawString(Content.Load<SpriteFont>("File"), $"{sprite.Rotation }", new Vector2(1000, 100), Color.Black);
            if (ShouldFire)
            {
                if(LerpAmount < 1)
                {
                    Bullet.Position = Vector2.Lerp(Bullet.Position, Target, LerpAmount);
                    LerpAmount += LerpIncrement;
                    Bullet.Draw(spriteb);
                }
                else
                {
                    Bullet.Position = sprite.Position;
                    LerpAmount = 0;
                    ShouldFire = false;
                }
            }
            sprite.Draw(spriteb);
        }
        public bool UpgradeDamage(ref int Money,int Increment,int CostIncrement)
        {
            if (DamageAndCostAndLvl.Item2 >= Money || DamageAndCostAndLvl.Item3 == MaxUpgradeLvl) return false;
            Money -= DamageAndCostAndLvl.Item2;
            DamageAndCostAndLvl.Item1 += Increment;
            DamageAndCostAndLvl.Item2 += CostIncrement;
            DamageAndCostAndLvl.Item3++;
            return true;
        }
        public bool UpgradeCooldown(ref int Money, int Decrement,int CostIncrement)
        {
            if(CooldownAndCostAndLvl.Item2 >= Money || CooldownAndCostAndLvl.Item3 == MaxUpgradeLvl) return false;
            Money -= CooldownAndCostAndLvl.Item2;
            CooldownAndCostAndLvl.Item1 -= Decrement;
            CooldownAndCostAndLvl.Item2 += CostIncrement;
            CooldownAndCostAndLvl.Item3++;
            return true;
        }
        public bool IncreaseRangeByOne(ref int Money,int CostIncrement,Screen screen)
        {
            if (IncreaseRangeCostAndLvl.Item1 >= Money || IncreaseRangeCostAndLvl.Item2 == MaxUpgradeLvl) return false;
            Money -= IncreaseRangeCostAndLvl.Item1;
            IncreaseRangeCostAndLvl.Item1 += CostIncrement;
            IncreaseRangeCostAndLvl.Item2++;
            RangeSize++;
            Position CurrentPos = GridPosition;
            int indexX = 0;
            while (indexX < RangeSize && CurrentPos.X >= 0)
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
            int originalX = CurrentPos.X;
            for (int i = 0; i < indexY; i++)
            {
                for (int x = 0; x < indexX; x++)
                {
                    if (RangeSquares.Contains(screen.Map[CurrentPos.Y, CurrentPos.X])) continue;
                    RangeSquares.Add(screen.Map[CurrentPos.Y, CurrentPos.X]);
                    CurrentPos.X++;
                    if (CurrentPos.X == screen.Map.GetLength(0)) break;
                }
                CurrentPos.X = originalX;
                CurrentPos.Y++;
                if (CurrentPos.Y == screen.Map.GetLength(1)) break;
            }
            return true;
        }
        public override bool Update(ref Zombie zombie)
        {
            sprite.Rotation = (float)(Math.Atan2(zombie.Position.Y - sprite.Position.Y, zombie.Position.X - sprite.Position.X));
            if (zombie == null || FiringTimer.ElapsedMilliseconds < CooldownAndCostAndLvl.Item1) return false;
            Target = zombie.Position;
            zombie.Health -= DamageAndCostAndLvl.Item1;
            Bullet.Rotation = sprite.Rotation;
            FiringTimer.Restart();
            ShouldFire = true;
            return true;
        }
    }
}
