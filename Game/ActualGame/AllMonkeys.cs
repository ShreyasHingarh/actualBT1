using Microsoft.Xna.Framework.Content;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ActualGame
{
   
    internal class AllMonkeys
    {
        List<Monkey> Monkeys;
        public AllMonkeys()
        {
            Monkeys = new List<Monkey>();
        }
        public void AddMonkey(Screen screen,TypeOfMonkey type,Vector2 Position,ContentManager Content,Vector2 Origin,Position GridPosition) 
        {
            switch (type)
            {
                case TypeOfMonkey.DartMonk:
                    Monkeys.Add(new TypesOfMonkeys.Dart(Position,Content,Origin,screen,4,GridPosition,5,50,1500,50,50,3));
                    break;
                case TypeOfMonkey.SpikeMonk:
                    break;
                case TypeOfMonkey.BombMonk:
                    break;
                case TypeOfMonkey.IceMonk:
                    break;
            }
        }
        public void UpdateAllMonkeys(Screen screen)
        {
            foreach(var item in Monkeys)
            {
                foreach(var square in item.RangeSquares)
                {
                    if (!square.DoesContainZombie) continue;
                    item.Update(square.OneContained);
                }
            }
        }
    }
}
