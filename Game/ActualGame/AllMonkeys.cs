using ActualGame.TypesOfMonkeys;

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
        public List<Monkey> Monkeys;
        public AllMonkeys()
        {
            Monkeys = new List<Monkey>();
        }
      
        public void AddMonkey(Monkey monkey)
        {
            Monkeys.Add(monkey);
        }
        public void UpdateAllMonkeys()
        {
            foreach(var item in Monkeys)
            {
                List<Zombie> zombieList = new List<Zombie>();
                foreach(var square in item.RangeSquares)
                {
                    if (!square.DoesContainZombie) continue;
                    zombieList.Add(square.OneContained);
                }
                if(zombieList.Count != 0)
                {
                    item.Update(ref zombieList);
                }
            }
        }
        public void IncreaseSpeedOfAllMonkeys()
        {
            foreach(var item in Monkeys)
            {
                item.CooldownAndCostAndLvl.Item1 /= 2;
            }
        }
        public void DecreaseSpeedOfAllMonkeys()
        {
            foreach (var item in Monkeys) 
            {
                item.CooldownAndCostAndLvl.Item1 *= 2;
            }
        }
        public void DrawAllMonkeys(SpriteBatch spriteB,GameTime gameTime, Screen screen)
        {
            foreach(var item in Monkeys)
            {
                item.Draw(spriteB,gameTime,screen);
            }
        }
    }
}
