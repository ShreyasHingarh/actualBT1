using ActualGame.Enemies;
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
                    
                    if(square.DoesContainZombie)
                    {
                        Console.WriteLine("thing");
                        square.Sprite.Tint = Color.Red;
                    }
                    if (!square.DoesContainZombie) continue;
                    
                    foreach(var zombie in square.OneContained)
                    {
                        zombieList.Add(zombie);
                    }
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
                switch (item.Type)
                {
                    case TypeOfMonkey.DartMonk:
                        Dart dart = (Dart)item;
                        dart.Bullet.LerpIncrement *= 2;
                        break;
                    case TypeOfMonkey.SpikeMonk:
                        Spike spike = (Spike)item;
                        foreach(var thing in spike.Bullets)
                        {
                            thing.LerpIncrement *= 2;
                        }
                        break;
                    case TypeOfMonkey.BombMonk:
                        Bomb bomb = (Bomb)item;
                        bomb.LerpIncrement *= 2;
                        bomb.Bomb2CoolDown /= 2;
                        bomb.TheBomb1.compare /= 2;
                        bomb.TheBomb2.compare /= 2;

                        Console.WriteLine(bomb.OneToCompare);
                        break;
                    case TypeOfMonkey.IceMonk:
                        Ice ice = (Ice)item;
                        ice.throwable.LerpIncrement *= 2;
                        break;
                }
            }
        }
        public void DecreaseSpeedOfAllMonkeys()
        {
            foreach (var item in Monkeys) 
            {
                item.CooldownAndCostAndLvl.Item1 *= 2; 
                switch (item.Type)
                {
                    case TypeOfMonkey.DartMonk:
                        Dart dart = (Dart)item;
                        dart.Bullet.LerpIncrement /= 2;
                        break;
                    case TypeOfMonkey.SpikeMonk:
                        Spike spike = (Spike)item;
                        foreach (var thing in spike.Bullets)
                        {
                            thing.LerpIncrement /= 2;
                        }
                        break;
                    case TypeOfMonkey.BombMonk:
                        Bomb bomb = (Bomb)item;
                        bomb.LerpIncrement /= 2;
                        bomb.Bomb2CoolDown *= 2;
                        bomb.TheBomb1.compare *= 2;
                        bomb.TheBomb2.compare *= 2;

                        Console.WriteLine(bomb.OneToCompare);
                        break;
                    case TypeOfMonkey.IceMonk:
                        Ice ice = (Ice)item;
                        ice.throwable.LerpIncrement /= 2;
                        break;
                }
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
