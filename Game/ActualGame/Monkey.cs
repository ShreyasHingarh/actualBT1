using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActualGame
{
    enum TypeOfMonkey
    {
        DartMonk,
        SpikeMonk,
        BombMonk,
        IceMonk
    }
    abstract class Monkey
    {
        public (int, int, int) DamageAndCostAndLvl;
        public (int, int, int) CooldownAndCostAndLvl;
        public Position GridPosition;
        public List<ScreenSquare> RangeSquares;
        public TypeOfMonkey Type;
        public Sprite sprite;
        public int RangeSize;
        public int RemoveCost;
        public int MaxUpgradeLvl;
        public Monkey(Screen screen, TypeOfMonkey type, Position gridpos, int baseRange,
            int baseDamage, int baseDamageUpgradeCost, int baseCooldown, int baseCooldownUpgradeCost, int MaxLvl)
        {
            MaxUpgradeLvl = MaxLvl;
            GridPosition = gridpos;
            RangeSquares = new List<ScreenSquare>();
            RangeSize = baseRange;
            Type = type;
            AddRange(screen);
            DamageAndCostAndLvl = (baseDamage, baseDamageUpgradeCost, 0);
            CooldownAndCostAndLvl = (baseCooldown, baseCooldownUpgradeCost, 0);
        }
        public void AddRange(Screen screen)
        {
            if (GridPosition.X == -1 && GridPosition.Y == -1) return;
            Position CurrentPos = new Position(GridPosition.X,GridPosition.Y);
            //Gets Top Left
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
                    RangeSquares.Add(screen.Map[CurrentPos.Y, CurrentPos.X]);
                    CurrentPos.X++;
                    if (CurrentPos.X == screen.Map.GetLength(0)) break;
                }
                CurrentPos.X = originalX;
                CurrentPos.Y++;
                if (CurrentPos.Y == screen.Map.GetLength(1)) break;
            }
        }
        public bool UpgradeDamage(ref int Money, int Increment, int CostIncrement)
        {
            if (DamageAndCostAndLvl.Item2 >= Money || DamageAndCostAndLvl.Item3 == MaxUpgradeLvl) return false;
            RemoveCost += CostIncrement / 3;
            Money -= DamageAndCostAndLvl.Item2;
            DamageAndCostAndLvl.Item1 += Increment;
            DamageAndCostAndLvl.Item2 += CostIncrement;
            DamageAndCostAndLvl.Item3++;
            return true;
        }
        public bool UpgradeCooldown(ref int Money, int Decrement, int CostIncrement)
        {
            if (CooldownAndCostAndLvl.Item2 >= Money || CooldownAndCostAndLvl.Item3 == MaxUpgradeLvl) return false;
            RemoveCost += CostIncrement / 3;
            Money -= CooldownAndCostAndLvl.Item2;
            CooldownAndCostAndLvl.Item1 -= Decrement;
            CooldownAndCostAndLvl.Item2 += CostIncrement;
            CooldownAndCostAndLvl.Item3++;
            return true;
        }
        public abstract bool Update(ref Zombie Zombie);
        public abstract void Draw(SpriteBatch sprite);
    }
}
