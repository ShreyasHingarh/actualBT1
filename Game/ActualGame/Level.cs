using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ActualGame
{
    internal abstract class Level
    {
        public AllEnemies Enemies;
        public AllMonkeys allMonkeys;
        public SideScreen SideScreen;
        public Level(ScreenSquare Start, int offSet, ContentManager Content, int cash,int Lives)
        {
            SideScreen = new SideScreen(Lives, cash, 1, Content);
            allMonkeys = new AllMonkeys();
            Enemies = new AllEnemies(Start, offSet, Content);
        }
        public abstract bool UpdateLvlScreen(int SizeOfSquare, Screen screen, ContentManager Content);
        public abstract void DrawLvlScreen(SpriteBatch spriteBatch, ContentManager Content);
    }
}
