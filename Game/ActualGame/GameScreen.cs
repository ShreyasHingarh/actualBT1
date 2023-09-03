using Microsoft.Xna.Framework.Content;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ActualGame
{
    internal class GameScreen
    {
        RunGame RunGame;
        public Screen screen;
        int sizeOfSquare = 30;
        int offSet = 4;
        public GameScreen(int height, ContentManager Content,int baseCash,int baseLives)
        { 
            screen = new Screen(height, sizeOfSquare, Content);
            RunGame = new RunGame(screen,Content,baseCash,baseLives,offSet);
        }
        public void Run()
        {
            RunGame.RunLevel();
        }
    }
}
