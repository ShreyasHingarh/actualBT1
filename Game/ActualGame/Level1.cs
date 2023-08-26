﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ActualGame
{
    internal class Level1
    {
        public AllEnemies Enemies;
        public AllMonkeys Monkeys;
        int OffSet;
        public SideScreen SideScreen;
        public Level1(ScreenSquare Start,int offSet, ContentManager Content, int cash,Screen screen)
        {
            SideScreen = new SideScreen(100,cash,1);
            OffSet = offSet;
            Enemies = new AllEnemies(Start,offSet,Content);
            Monkeys = new AllMonkeys();
            Monkeys.AddMonkey(screen, TypeOfMonkey.DartMonk, new Vector2(165, 495), Content, new Vector2(15,15), new Position(5, 16));
        }
        public void UpdateLvlScreen(int SizeOfSquare,Screen screen)
        {
            // handle adding removing, and upgrading monkeys and adding and removing enenmies
            Monkeys.UpdateAllMonkeys(screen);
            if (Enemies.UpdateAllZombies(SizeOfSquare,OffSet, screen,SideScreen))
            {

            }
        }
        public void DrawLvlScreen(SpriteBatch spriteBatch,ContentManager Content)
        {
            SideScreen.Draw(spriteBatch,Content);
            Enemies.DrawAllZombies(spriteBatch);
            Monkeys.DrawAllMonkeys(spriteBatch);
            
        }
    }
}
