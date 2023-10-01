using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        bool RunEndOfGame;
        public GameScreen(int height, ContentManager Content,int baseCash,int baseLives)
        {
            RunEndOfGame = false;
            screen = new Screen(height, sizeOfSquare, Content);
            RunGame = new RunGame(screen,Content,baseCash,baseLives,offSet);
        }
        public void Run(ContentManager Content)
        {
            //Run Start Screen
            if(!RunEndOfGame && !RunGame.RunLevel(Content,screen,sizeOfSquare,offSet))
            {
                RunEndOfGame = true;
                //run end of game screen
            }
        }
        public void Draw(SpriteBatch sprite, ContentManager Content, GameTime gameTime)
        {
            if (!RunEndOfGame)
            {
                screen.DrawScreen(sprite);
                RunGame.DrawLevel(sprite, Content, gameTime, screen);
            }
        }
    }
}
