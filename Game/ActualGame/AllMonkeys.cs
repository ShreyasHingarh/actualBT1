using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Collections.Generic;
using System.Linq;
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
                    Monkeys.Add(new TypesOfMonkeys.Dart(Position,Content,Origin,screen,20,GridPosition,5,50,500,50,50,3));
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
                    square.Sprite.Tint = Color.Red;
                    if (!square.DoesContainZombie) continue;
                    item.Update(ref square.OneContained);
                }
            }
        }
        public void DrawAllMonkeys(SpriteBatch spriteB,ContentManager Content)
        {
            foreach(var item in Monkeys)
            {
                item.Draw(spriteB, Content);
            }
        }
    }
}
