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
    internal class RunGame
    {
        enum Levels
        {
            Level1,
            Level2, 
            Level3,
            Level4,
            Level5,
            Level6,
            Level7,
            Level8,
            Level9,
            Level10,
            Level11,
            Level12,
            Level13,
            Level14,
            Level15,
            Level16,
            Level17,
            Level18,
            Level19,
            Level20
        }
        int MaxLevel = 20;
        Levels LevelIndex;
        Level ActualLevelCode;
        public RunGame(Screen screen,ContentManager Content,int BaseCash,int BaseLives,int offSet)
        {
            LevelIndex = Levels.Level1;
            ActualLevelCode = new Level(offSet,Content,BaseCash,BaseLives);
            ActualLevelCode.Enemies.AddAZombie(0, screen.Start, offSet, Content,false);
        }
        public bool SwitchLevel(Screen screen, ContentManager Content, int offSet)
        {
            if ((int)LevelIndex >= MaxLevel || ActualLevelCode.SideScreen.Lives <= 0) return false;
            LevelIndex++;
            switch (LevelIndex)
            {
                case Levels.Level2:
                    ActualLevelCode.Enemies.AddAZombie(0, screen.Start, offSet, Content,false);
                    ActualLevelCode.Enemies.AddAZombie(0, screen.Start, offSet, Content, false);
                    break;
                case Levels.Level3:
                    ActualLevelCode.Enemies.AddAZombie(0, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(0, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(0, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(0, screen.Start, offSet, Content, false);
                    break;
                case Levels.Level4:
                    ActualLevelCode.Enemies.AddAZombie(1, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(1, screen.Start, offSet, Content, false);
                    break;
                case Levels.Level5:
                    ActualLevelCode.Enemies.AddAZombie(1, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(1, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(1, screen.Start, offSet, Content, false);
                    break;      
                case Levels.Level6:
                    ActualLevelCode.Enemies.AddAZombie(1, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(1, screen.Start, offSet, Content, false);   
                    ActualLevelCode.Enemies.AddAZombie(2, screen.Start, offSet, Content, false);
                    break;
                case Levels.Level7:
                    ActualLevelCode.Enemies.AddAZombie(1, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(1, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(1, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(2, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(1, screen.Start, offSet, Content, false);
                    break;
                case Levels.Level8:
                    ActualLevelCode.Enemies.AddAZombie(1, screen.Start, offSet, Content,false);
                    ActualLevelCode.Enemies.AddAZombie(1, screen.Start, offSet, Content,false);
                    ActualLevelCode.Enemies.AddAZombie(1, screen.Start, offSet, Content,false);
                    ActualLevelCode.Enemies.AddAZombie(2, screen.Start, offSet, Content,false);
                    ActualLevelCode.Enemies.AddAZombie(1, screen.Start, offSet, Content,false);
                    ActualLevelCode.Enemies.AddAZombie(1, screen.Start, offSet, Content,false);
                    ActualLevelCode.Enemies.AddAZombie(2, screen.Start, offSet, Content,false);
                    ActualLevelCode.Enemies.AddAZombie(1, screen.Start, offSet, Content,false);
                    ActualLevelCode.Enemies.AddAZombie(1, screen.Start, offSet, Content,false);
                    break;
                case Levels.Level9:
                    ActualLevelCode.Enemies.AddAZombie(2, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(2, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(2, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(2, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(2, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(2, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(2, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(2, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(2, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(3, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(3, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(3, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(3, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(3, screen.Start, offSet, Content, false);
                    break;
                case Levels.Level10:
                    //Add Zomibes that Move Faster
                    ActualLevelCode.Enemies.AddAZombie(1, screen.Start, offSet, Content,false);
                    ActualLevelCode.Enemies.AddAZombie(1, screen.Start, offSet, Content,false);
                    ActualLevelCode.Enemies.AddAZombie(1, screen.Start, offSet, Content,false);
                    ActualLevelCode.Enemies.AddAZombie(2, screen.Start, offSet, Content,false);
                    ActualLevelCode.Enemies.AddAZombie(1, screen.Start, offSet, Content,false);
                    ActualLevelCode.Enemies.AddAZombie(1, screen.Start, offSet, Content,false);
                    ActualLevelCode.Enemies.AddAZombie(2, screen.Start, offSet, Content,true);
                    ActualLevelCode.Enemies.AddAZombie(1, screen.Start, offSet, Content,true);
                    ActualLevelCode.Enemies.AddAZombie(1, screen.Start, offSet, Content,true);
                    ActualLevelCode.Enemies.AddAZombie(1, screen.Start, offSet, Content,true);
                    ActualLevelCode.Enemies.AddAZombie(2, screen.Start, offSet, Content,true);
                    break;
                case Levels.Level11:
                    ActualLevelCode.Enemies.AddAZombie(3, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(2, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(2, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(2, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(3, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(3, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(2, screen.Start, offSet, Content, true);
                    ActualLevelCode.Enemies.AddAZombie(2, screen.Start, offSet, Content, true);
                    ActualLevelCode.Enemies.AddAZombie(3, screen.Start, offSet, Content, true);
                    ActualLevelCode.Enemies.AddAZombie(4, screen.Start, offSet, Content, true);
                    ActualLevelCode.Enemies.AddAZombie(4, screen.Start, offSet, Content, true);
                    ActualLevelCode.Enemies.AddAZombie(1, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(5, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(4, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(5, screen.Start, offSet, Content, true);
                    break;
                case Levels.Level12:
                    ActualLevelCode.Enemies.AddAZombie(1, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(1, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(2, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(3, screen.Start, offSet, Content, false); 
                    ActualLevelCode.Enemies.AddAZombie(3, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(1, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(2, screen.Start, offSet, Content, true);
                    ActualLevelCode.Enemies.AddAZombie(2, screen.Start, offSet, Content, true);
                    ActualLevelCode.Enemies.AddAZombie(3, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(3, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(3, screen.Start, offSet, Content, true);
                    ActualLevelCode.Enemies.AddAZombie(3, screen.Start, offSet, Content, true);
                    ActualLevelCode.Enemies.AddAZombie(4, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(5, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(5, screen.Start, offSet, Content, true);
                    ActualLevelCode.Enemies.AddAZombie(4, screen.Start, offSet, Content, true);
                    ActualLevelCode.Enemies.AddAZombie(5, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(5, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(4, screen.Start, offSet, Content, true);
                    ActualLevelCode.Enemies.AddAZombie(5, screen.Start, offSet, Content, true);
                    break;
                case Levels.Level13:
                    ActualLevelCode.Enemies.AddAZombie(1, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(4, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(2, screen.Start, offSet, Content, true);
                    ActualLevelCode.Enemies.AddAZombie(3, screen.Start, offSet, Content, true);
                    ActualLevelCode.Enemies.AddAZombie(4, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(1, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(2, screen.Start, offSet, Content, true);
                    ActualLevelCode.Enemies.AddAZombie(3, screen.Start, offSet, Content, true);
                    ActualLevelCode.Enemies.AddAZombie(4, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(1, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(2, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(3, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(4, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(1, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(2, screen.Start, offSet, Content, true);
                    ActualLevelCode.Enemies.AddAZombie(3, screen.Start, offSet, Content, true);
                    ActualLevelCode.Enemies.AddAZombie(4, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(1, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(2, screen.Start, offSet, Content, true);
                    ActualLevelCode.Enemies.AddAZombie(3, screen.Start, offSet, Content, true);
                    break;
                case Levels.Level14:
                    ActualLevelCode.Enemies.AddAZombie(2, screen.Start, offSet, Content, true);
                    ActualLevelCode.Enemies.AddAZombie(3, screen.Start, offSet, Content, true);
                    ActualLevelCode.Enemies.AddAZombie(4, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(1, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(2, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(3, screen.Start, offSet, Content, true);
                    ActualLevelCode.Enemies.AddAZombie(4, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(1, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(2, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(3, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(4, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(1, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(2, screen.Start, offSet, Content, true);
                    ActualLevelCode.Enemies.AddAZombie(3, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(4, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(1, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(2, screen.Start, offSet, Content, true);
                    ActualLevelCode.Enemies.AddAZombie(2, screen.Start, offSet, Content, true);
                    ActualLevelCode.Enemies.AddAZombie(3, screen.Start, offSet, Content, true);
                    ActualLevelCode.Enemies.AddAZombie(4, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(1, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(2, screen.Start, offSet, Content, true);
                    ActualLevelCode.Enemies.AddAZombie(3, screen.Start, offSet, Content, true);
                    ActualLevelCode.Enemies.AddAZombie(4, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(1, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(2, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(3, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(4, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(1, screen.Start, offSet, Content, false);
                    ActualLevelCode.Enemies.AddAZombie(2, screen.Start, offSet, Content, true);
                    ActualLevelCode.Enemies.AddAZombie(3, screen.Start, offSet, Content, true);
                    break;
                case Levels.Level15:
                    //Add Path Makers
                    break;
                case Levels.Level16:
                    break;
                case Levels.Level17:
                    break;
                case Levels.Level18:
                    break;
                case Levels.Level19:
                    break;
                case Levels.Level20:
                    //First Boss
                    break;
            }
            if (ActualLevelCode.Enemies.Zombies.Count == 0) return false;
            if(ActualLevelCode.SideScreen.SpeedUp)
            {
                ActualLevelCode.Enemies.IncreaseSpeedOfAllZombies();
            }
            return true;
        }
        public bool RunLevel(ContentManager Content,Screen screen,int sizeOfSquare,int offset)
        {
            bool MoveOn = true;
            if (!ActualLevelCode.UpdateLvlScreen(sizeOfSquare, screen, Content))
            {
                ActualLevelCode.SideScreen.Level++;
                ActualLevelCode.Enemies.Zombies.Clear();
                ActualLevelCode.LevelSwitchTimer.Reset();
                MoveOn = SwitchLevel(screen,Content,offset);
            }
            return MoveOn;
        }
        public void DrawLevel(SpriteBatch sprite, ContentManager content,GameTime gameTime, Screen screen)
        {
            ActualLevelCode.DrawLvlScreen(sprite, content,gameTime,screen);
        }
    }
}
