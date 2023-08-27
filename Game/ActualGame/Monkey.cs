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
        //ShouldAlsoHaveASideScreen
        public Position GridPosition;
        public List<ScreenSquare> RangeSquares;
        public TypeOfMonkey Type;
        public Sprite sprite;
        public int RangeSize;
        public Monkey(Screen screen, TypeOfMonkey type, Position gridpos, int baseRange)
        {
            GridPosition = gridpos;
            RangeSquares = new List<ScreenSquare>();
            RangeSize = baseRange;
            AddRange(screen);
            Type = type;
        }
        void AddRange(Screen screen)
        {
            Position CurrentPos = GridPosition;
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
            indexX += RangeSize+1;
            indexY += RangeSize+1;
            int originalX = CurrentPos.X;
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
        public abstract bool Update(ref Zombie Zombie);
        public abstract void Draw(SpriteBatch sprite);
    }
}
