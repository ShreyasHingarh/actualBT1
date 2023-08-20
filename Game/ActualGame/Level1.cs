using Microsoft.Xna.Framework.Content;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActualGame
{
    internal class Level1
    {
        AllEnemies Enemies;
        AllMonkeys Monkeys;
        int Cash;
        int OffSet;
        public Level1(ScreenSquare Start,int offSet, ContentManager Content, int cash)
        {
            Cash = cash;
            OffSet = offSet;
            Enemies = new AllEnemies(Start,offSet,Content);
            Monkeys = new AllMonkeys();
        }
        public void UpdateLvlScreen(int SizeOfSquare,Screen screen)
        {
            // handle adding removing, and upgrading monkeys and adding and removing enenmies
            Enemies.UpdateAllZombies(SizeOfSquare,OffSet, screen);
            Monkeys.UpdateAllMonkeys(screen);
        }
    }
}
