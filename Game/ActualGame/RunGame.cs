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
        public Level CurrentLevel;
        public List<Level> Levels;
        int LevelIndex;
        public RunGame(Screen screen,ContentManager Content,int BaseCash,int BaseLives,int offSet)
        {
            Levels = new List<Level>()
            {
                new Level1(screen.Start, offSet, Content, BaseCash,BaseLives)
                //rest of Levels
            };
            LevelIndex = 0;
            CurrentLevel = new Level1(screen.Start, offSet, Content, BaseCash,BaseLives);
        }
        public bool SwitchLevel()
        {
            LevelIndex++;
            if (Levels[LevelIndex] == null || CurrentLevel.SideScreen.Lives <= 0) return false;
            Levels[LevelIndex].SideScreen = CurrentLevel.SideScreen;
            Levels[LevelIndex].allMonkeys = CurrentLevel.allMonkeys;
            CurrentLevel = Levels[LevelIndex];
            return true;
        }
        public bool RunLevel(ContentManager Content,Screen screen,int sizeOfSquare)
        {
            bool MoveOn = true;
            if (!CurrentLevel.UpdateLvlScreen(sizeOfSquare, screen, Content))
            {
                MoveOn = SwitchLevel();
            }
            return MoveOn;
        }
        public void DrawLevel(SpriteBatch sprite, ContentManager content)
        {
            CurrentLevel.DrawLvlScreen(sprite, content);
        }
    }
}
