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
        public Position GridPosition;
        public List<ScreenSquare> RangeSquares;
        public TypeOfMonkey Type;
        public Sprite sprite;
        public Monkey(TypeOfMonkey type)
        {
            Type = type;
        }
        public abstract void Update();
        public abstract void Draw();
    }
}
