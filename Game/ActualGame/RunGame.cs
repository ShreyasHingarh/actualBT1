using Microsoft.Xna.Framework;
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
    internal class RunGame
    {
        int LevelIndex;
        Dictionary<int, Level> LevelsDictionary;
        public RunGame(Screen screen,ContentManager Content,int BaseCash,int BaseLives,int offSet)
        { 
            LevelsDictionary = new Dictionary<int, Level>()
            {
                { 0, new Level1(screen.Start, offSet, Content, BaseCash,BaseLives) }
                //rest of Levels}
            };
            LevelIndex = 0;
        }
        public bool SwitchLevel()
        {
            LevelIndex++;
            if (!LevelsDictionary.ContainsKey(LevelIndex) || LevelsDictionary[LevelIndex--].SideScreen.Lives <= 0) return false;
            LevelsDictionary[LevelIndex].SideScreen = LevelsDictionary[LevelIndex--].SideScreen;
            LevelsDictionary[LevelIndex].allMonkeys = LevelsDictionary[LevelIndex--].allMonkeys;
            return true;
        }
        public bool RunLevel(ContentManager Content,Screen screen,int sizeOfSquare)
        {
            bool MoveOn = true;
            if (!LevelsDictionary[LevelIndex].UpdateLvlScreen(sizeOfSquare, screen, Content))
            {
                MoveOn = SwitchLevel();
            }
            return MoveOn;
        }
        public void DrawLevel(SpriteBatch sprite, ContentManager content,GameTime gameTime, Screen screen)
        {
            LevelsDictionary[LevelIndex].DrawLvlScreen(sprite, content,gameTime,screen);
        }
    }
}
