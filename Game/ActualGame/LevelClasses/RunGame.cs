using ActualGame.ScreenAndGraph;
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

namespace ActualGame.LevelClasses
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
        void Level2(Screen screen, ContentManager Content)
        {
            ActualLevelCode.Enemies.AddANormalZombie(0, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(0, screen.Start.Value, Content, false);
        }
        void Level3(Screen screen, ContentManager Content)
        {
            ActualLevelCode.Enemies.AddANormalZombie(0, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(0, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(0, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(0, screen.Start.Value, Content, false);
        }
        void Level4(Screen screen, ContentManager Content)
        {
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, false);
        }
        void Level5(Screen screen, ContentManager Content)
        {
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, false);
        }
        void Level6(Screen screen, ContentManager Content)
        {
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(2, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(2, screen.Start.Value, Content, false);
        }
        void Level7(Screen screen, ContentManager Content)
        {
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(2, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(2, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(2, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(2, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(2, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, false);

        }
        void Level8(Screen screen, ContentManager Content)
        {

            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(2, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(3, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(3, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(3, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(3, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(2, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(3, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(3, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(2, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(3, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(3, screen.Start.Value, Content, false);
        }
        void Level9(Screen screen, ContentManager Content)
        {
            ActualLevelCode.Enemies.AddANormalZombie(2, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(2, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(2, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(2, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(2, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(2, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(2, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(2, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(2, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(3, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(3, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(3, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(3, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(3, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(2, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(2, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(2, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(2, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(3, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(3, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(3, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(3, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(3, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(3, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(3, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(3, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(3, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(3, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(3, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(3, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(3, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(3, screen.Start.Value, Content, false);
        }
        void Level10(Screen screen, ContentManager Content)
        {

            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(2, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(2, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(2, screen.Start.Value, Content, true); 
            ActualLevelCode.Enemies.AddANormalZombie(2, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(2, screen.Start.Value, Content, true); 
            ActualLevelCode.Enemies.AddANormalZombie(2, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(2, screen.Start.Value, Content, true);
        }
        void Level11(Screen screen, ContentManager Content)
        {
            ActualLevelCode.Enemies.AddANormalZombie(3, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(2, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(2, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(2, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(3, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(3, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(2, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(2, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(3, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(4, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(4, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(5, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(4, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(5, screen.Start.Value, Content, true);
        }
        void Level12(Screen screen, ContentManager Content)
        {
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(2, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(3, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(3, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(2, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(2, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(3, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(3, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(3, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(3, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(4, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(5, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(5, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(4, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(5, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(5, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(4, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(5, screen.Start.Value, Content, true);
        }
        void Level13(Screen screen, ContentManager Content)
        {
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(4, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(2, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(3, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(4, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(2, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(3, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(4, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(2, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(3, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(4, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(2, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(3, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(4, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(2, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(3, screen.Start.Value, Content, true);
        }
        void Level14(Screen screen, ContentManager Content)
        {
            ActualLevelCode.Enemies.AddANormalZombie(2, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(3, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(4, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(2, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(3, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(4, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(2, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(3, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(4, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(2, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(3, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(4, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(2, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(2, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(3, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(4, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(2, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(3, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(4, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(2, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(3, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(4, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(2, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(3, screen.Start.Value, Content, true);
        }
        void Level15(Screen screen, ContentManager Content)
        {
            ActualLevelCode.Enemies.AddaMinerZombie(Content, screen.Start.Value, ref screen, ref ActualLevelCode.allMonkeys);
            ActualLevelCode.Enemies.AddaMinerZombie(Content, screen.Start.Value, ref screen, ref ActualLevelCode.allMonkeys);
            ActualLevelCode.Enemies.AddaMinerZombie(Content, screen.Start.Value, ref screen, ref ActualLevelCode.allMonkeys);
            ActualLevelCode.Enemies.AddANormalZombie(3, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(4, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(2, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(2, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(3, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(3, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(5, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(5, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(5, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(5, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddaMinerZombie(Content, screen.Start.Value, ref screen, ref ActualLevelCode.allMonkeys);
            ActualLevelCode.Enemies.AddaMinerZombie(Content, screen.Start.Value, ref screen, ref ActualLevelCode.allMonkeys);
            ActualLevelCode.Enemies.AddaMinerZombie(Content, screen.Start.Value, ref screen, ref ActualLevelCode.allMonkeys);
            ActualLevelCode.Enemies.AddaMinerZombie(Content, screen.Start.Value, ref screen, ref ActualLevelCode.allMonkeys);
            ActualLevelCode.Enemies.AddaMinerZombie(Content, screen.Start.Value, ref screen, ref ActualLevelCode.allMonkeys);
            ActualLevelCode.Enemies.AddaMinerZombie(Content, screen.Start.Value, ref screen, ref ActualLevelCode.allMonkeys);
        }
        void Level16(Screen screen, ContentManager Content)
        {
            ActualLevelCode.Enemies.AddANormalZombie(3, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(3, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(3, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(3, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(3, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(3, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(3, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(3, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(3, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(3, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(3, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(3, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddaMinerZombie(Content, screen.Start.Value, ref screen, ref ActualLevelCode.allMonkeys);
            ActualLevelCode.Enemies.AddaMinerZombie(Content, screen.Start.Value, ref screen, ref ActualLevelCode.allMonkeys);
            ActualLevelCode.Enemies.AddANormalZombie(4, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(4, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(4, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(4, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(4, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(4, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(4, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(4, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(4, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(4, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(4, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(4, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddaMinerZombie(Content, screen.Start.Value, ref screen, ref ActualLevelCode.allMonkeys);
            ActualLevelCode.Enemies.AddaMinerZombie(Content, screen.Start.Value, ref screen, ref ActualLevelCode.allMonkeys);
        }
        void Level17(Screen screen, ContentManager Content)
        {
            ActualLevelCode.Enemies.AddaMinerZombie(Content, screen.Start.Value, ref screen, ref ActualLevelCode.allMonkeys);
            ActualLevelCode.Enemies.AddaMinerZombie(Content, screen.Start.Value, ref screen, ref ActualLevelCode.allMonkeys);
            ActualLevelCode.Enemies.AddaMinerZombie(Content, screen.Start.Value, ref screen, ref ActualLevelCode.allMonkeys);
            ActualLevelCode.Enemies.AddaMinerZombie(Content, screen.Start.Value, ref screen, ref ActualLevelCode.allMonkeys);
            ActualLevelCode.Enemies.AddaMinerZombie(Content, screen.Start.Value, ref screen, ref ActualLevelCode.allMonkeys);
            ActualLevelCode.Enemies.AddaMinerZombie(Content, screen.Start.Value, ref screen, ref ActualLevelCode.allMonkeys);
            ActualLevelCode.Enemies.AddaMinerZombie(Content, screen.Start.Value, ref screen, ref ActualLevelCode.allMonkeys);
            ActualLevelCode.Enemies.AddaMinerZombie(Content, screen.Start.Value, ref screen, ref ActualLevelCode.allMonkeys);
            ActualLevelCode.Enemies.AddaMinerZombie(Content, screen.Start.Value, ref screen, ref ActualLevelCode.allMonkeys);
            ActualLevelCode.Enemies.AddaMinerZombie(Content, screen.Start.Value, ref screen, ref ActualLevelCode.allMonkeys);

            ActualLevelCode.Enemies.AddANormalZombie(4, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(4, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(4, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(4, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(4, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(4, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(4, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(4, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(4, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(4, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(4, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(4, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(4, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(4, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(4, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(4, screen.Start.Value, Content, false);
        }
        void Level18(Screen screen, ContentManager Content)
        {
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(1, screen.Start.Value, Content, true);
        }
        void Level19(Screen screen, ContentManager Content)
        {
            ActualLevelCode.Enemies.AddANormalZombie(5, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(5, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(5, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(5, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(5, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(6, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(6, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(6, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddANormalZombie(6, screen.Start.Value, Content, false);
            ActualLevelCode.Enemies.AddaMinerZombie(Content, screen.Start.Value, ref screen, ref ActualLevelCode.allMonkeys);
            ActualLevelCode.Enemies.AddaMinerZombie(Content, screen.Start.Value, ref screen, ref ActualLevelCode.allMonkeys);
        }
        void Level20(Screen screen, ContentManager Content)
        {
            ActualLevelCode.Enemies.AddANormalZombie(7, screen.Start.Value, Content, true);
            ActualLevelCode.Enemies.AddANormalZombie(7, screen.Start.Value, Content, true);
        }
        public RunGame(Screen screen, ContentManager Content, int BaseCash, int BaseLives, int offSet)
        {
            LevelIndex = Levels.Level1;
            ActualLevelCode = new Level(offSet, Content, BaseCash, BaseLives);
            ActualLevelCode.Enemies.AddANormalZombie(0, screen.Start.Value, Content, false);
        }
        public int SwitchLevel(Screen screen, ContentManager Content)
        {
            if ((int)LevelIndex >= MaxLevel) return 1; // YOU WIN
            if (ActualLevelCode.SideScreen.Lives <= 0) return 2;//YOU LOSE
            LevelIndex++;
            switch (LevelIndex)
            {
                case Levels.Level2:
                    Level2(screen,Content);
                    break;
                case Levels.Level3:
                    Level3(screen, Content);
                    break;
                case Levels.Level4:
                    Level4(screen,Content);
                    break;
                case Levels.Level5:
                    Level5(screen, Content);
                    break;
                case Levels.Level6:
                    Level6(screen,Content);
                    break;
                case Levels.Level7:
                    Level7(screen,Content);
                    break;
                case Levels.Level8:
                    Level8(screen,Content);
                    break;
                case Levels.Level9:
                    Level9(screen,Content);
                    break;
                case Levels.Level10:
                    //Add Zomibes that Move Faster
                    Level10(screen, Content);
                    break;
                case Levels.Level11:
                    Level11(screen, Content);
                    break;
                case Levels.Level12:
                    Level12(screen,Content);
                    break;
                case Levels.Level13:
                    Level13(screen,Content);
                    break;
                case Levels.Level14:
                    Level14(screen,Content);
                    break;
                case Levels.Level15:
                    //Add Path Makers
                    Level15(screen,Content);
                    break;
                case Levels.Level16:
                    Level16(screen,Content);
                    break;
                case Levels.Level17:
                    Level17(screen,Content);
                    break;
                case Levels.Level18:
                    Level18(screen,Content);
                    break;
                case Levels.Level19:
                    Level19(screen,Content);
                    break;
                case Levels.Level20:
                    //First Boss
                    Level20(screen, Content);
                    break;
            }
            if (ActualLevelCode.Enemies.Zombies.Count == 0) return 1; //YOU WIN
            if (ActualLevelCode.SideScreen.SpeedUp)
            {
                ActualLevelCode.Enemies.IncreaseSpeedOfAllZombies();
            }
            return 0;
        }

        public int RunLevel(ContentManager Content, Screen screen, int sizeOfSquare, int offset)
        {
            int MoveOn = 0;
            if (!ActualLevelCode.UpdateLvlScreen(sizeOfSquare, screen, Content))
            {
                ActualLevelCode.SideScreen.Level++;
                ActualLevelCode.Enemies.Zombies.Clear();
                ActualLevelCode.LevelSwitchTimer.Reset();
                MoveOn = SwitchLevel(screen, Content);
            }
            return MoveOn;
        }
        public void DrawLevel(SpriteBatch sprite, ContentManager content, GameTime gameTime, Screen screen)
        {
            ActualLevelCode.DrawLvlScreen(sprite, content, gameTime, screen);
        }
    }
}
