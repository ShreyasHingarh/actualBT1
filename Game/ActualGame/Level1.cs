using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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
        public AllMonkeys allMonkeys;
        int OffSet;
        public SideScreen SideScreen;
        bool MousePressed = false;
        Monkey OneToAdd;
        public Level1(ScreenSquare Start,int offSet, ContentManager Content, int cash,Screen screen)
        {
            SideScreen = new SideScreen(100,cash,1,Content);
            OffSet = offSet;
            Enemies = new AllEnemies(Start,offSet,Content);
            allMonkeys = new AllMonkeys();
        }
        public void UpdateLvlScreen(int SizeOfSquare,Screen screen,ContentManager Content)
        {
            // handle adding removing, and upgrading monkeys and adding and removing enenmies
            Vector2 MousePosition = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
            if (!MousePressed)
            {
                switch (SideScreen.AddMonkey())
                {
                    case -1:
                        break;
                    case 0:
                        OneToAdd = new TypesOfMonkeys.Dart(MousePosition, Content, new Vector2(15, 15), screen, 4, new Position(-1,-1), 5, 50, 1500, 50, 50, 3);

                        MousePressed = true;
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                }
            }
            else 
            {
                OneToAdd.sprite.Position = MousePosition;
                if(Mouse.GetState().LeftButton == ButtonState.Released)
                {
                    MousePressed = false;
                    Position Grid = new Position((int)(MousePosition.X) / SizeOfSquare, (int)(MousePosition.Y) / SizeOfSquare); 
                    foreach(var item in allMonkeys.Monkeys)
                    {
                        if(item.GridPosition == Grid)
                        {
                            OneToAdd = null;
                            break;
                        }
                    }
                    if(OneToAdd != null && screen.Map[Grid.Y, Grid.X].Type != TypeOfImage.Path)
                    {
                        OneToAdd.GridPosition = Grid;
                        OneToAdd.AddRange(screen);
                        OneToAdd.sprite.Position = new Vector2(Grid.X * SizeOfSquare + 15,Grid.Y * SizeOfSquare + 15);
                        allMonkeys.AddMonkey(OneToAdd);
                        SideScreen.Money -= 100;
                        OneToAdd = null;
                    }
                    OneToAdd = null;
                }
            }
            
            allMonkeys.UpdateAllMonkeys(screen);
            if (Enemies.UpdateAllZombies(SizeOfSquare,OffSet, screen,SideScreen))
            {
                //next level
            }
        }
        public void DrawLvlScreen(SpriteBatch spriteBatch,ContentManager Content)
        {
            if(OneToAdd != null)
            {
                OneToAdd.Draw(spriteBatch);
            }
            SideScreen.Draw(spriteBatch,Content);
            Enemies.DrawAllZombies(spriteBatch);
            allMonkeys.DrawAllMonkeys(spriteBatch);   
        }
    }
}
