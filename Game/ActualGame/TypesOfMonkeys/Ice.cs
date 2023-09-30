using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActualGame.TypesOfMonkeys
{
    internal class Ice : Monkey
    {
        //free code camp.org, cs 50 harvard
        public (int, int) FrozenUpgradeCostandLvl;
        public IceThrowable throwable;
        public (int, int) IncreaseRangeCostAndLvl;
        Zombie Target;
        bool HasHit;
        int total;
        Texture2D SlowZombie;
        public Ice(Vector2 Position, ContentManager Content, Vector2 Origin, Screen screen, int baseRange
            , int baseDamage, int baseDamageUpgradeCost, int baseCooldown,int baseCooldownUpgradeCost, int baseRangeCost, int MaxLvl, int addCost, int baseFrozenCost) 
            : base(screen, TypeOfMonkey.IceMonk, new Position(-1, -1), baseRange, baseDamage, baseDamageUpgradeCost, baseCooldown, baseCooldownUpgradeCost, MaxLvl, addCost)
        {
            FrozenUpgradeCostandLvl = (baseFrozenCost,0);
            IncreaseRangeCostAndLvl = (baseRangeCost,0);
            throwable = new IceThrowable(Position, Content.Load<Texture2D>("Ice"),Origin,0.2f,Vector2.Zero);
            sprite = new Sprite(Color.White,Position, Content.Load<Texture2D>("IceMonkey"),0,Origin,Vector2.One);
            RemoveCost = 150;
            SlowZombie = Content.Load<Texture2D>("ColdZombie");
        }
        public bool IncreaseRangeByOne(ref int Money, int CostIncrement, Screen screen)
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
        public override void Draw(SpriteBatch spriteB, GameTime gameTime, Screen screen)
        {
            if(ShouldFire)
            {
                if (total == 0)
                {
                    total += throwable.DrawThing(spriteB, sprite.Position, DamageAndCostAndLvl.Item1, ref Target, ref HasHit,SlowZombie);
                }
                if(total == 1)
                {
                    total = 0;
                    ShouldFire = false;
                    throwable.HasHit = false;
                }
            }
            sprite.Draw(spriteB);
        }
        public bool UpgradeFrozen(ref int Money, int CostIncrement,int TimeDecrement, int DamageIncrease, ref AllEnemies allZombies)
        {
            if (FrozenUpgradeCostandLvl.Item1 >= Money || FrozenUpgradeCostandLvl.Item2 == MaxUpgradeLvl || allZombies == null) return false;
            RemoveCost += CostIncrement / 3;
            Money -= FrozenUpgradeCostandLvl.Item1;
            FrozenUpgradeCostandLvl.Item1 += CostIncrement;
            switch(FrozenUpgradeCostandLvl.Item2)
            {
                case 0:
                    foreach(var item in allZombies.Zombies)
                    {
                        item.MaxFrozenTime += TimeDecrement;
                    }
                    break;
                case 1:
                    foreach (var item in allZombies.Zombies)
                    {
                        item.MaxFrozenTime += TimeDecrement;
                    }
                    break;
                case 2:
                    DamageAndCostAndLvl.Item1 += DamageIncrease;
                    break;
            }
            IncreaseRangeCostAndLvl.Item2++;
            return true;
        }
        public override bool Update(ref List<Zombie> Zombies)
        {
            sprite.Rotation = (float)(Math.Atan2(Zombies[0].Position.Y - sprite.Position.Y, Zombies[0].Position.X - sprite.Position.X));
            if (Zombies == null || FiringTimer.ElapsedMilliseconds < CooldownAndCostAndLvl.Item1) return false;
            FiringTimer.Restart();
            ShouldFire = true;
            HasHit = false;
            Target = Zombies[0];
            throwable.Target = new Vector2(Zombies[0].Position.X + sprite.Origin.X, Zombies[0].Position.Y + sprite.Origin.Y);
            throwable.Rotation = sprite.Rotation;
            return true;
        }
    }
}
