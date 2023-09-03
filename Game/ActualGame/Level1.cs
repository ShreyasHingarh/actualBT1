using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ActualGame
{
    internal class Level1 : Level
    {
        int OffSet;
        bool MousePressed = false;
        bool ShouldUpgrade = false;
        Monkey OneToAdd;
        bool TooLittleMoney;
        bool MaxLevelReached;
        Stopwatch DisplayTimer;
        bool hasClicked;

        public Level1(ScreenSquare Start, int offSet, ContentManager Content, int cash,int Lives) 
            : base(Start,offSet,Content,cash,Lives)
        {
            SideScreen = new SideScreen(Lives, cash, 1, Content);
            allMonkeys = new AllMonkeys();
            TooLittleMoney = false;
            MaxLevelReached = false;
            OffSet = offSet;
            Enemies.AddAZombie(0, Start, offSet, Content);
            DisplayTimer = new Stopwatch();
        }
        public override bool UpdateLvlScreen(int SizeOfSquare, Screen screen, ContentManager Content)
        {
            if (SideScreen.Lives <= 0) return false;
            // Need adding 
            Vector2 MousePosition = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
            SideScreen.CheckStartButton(MousePosition);
            switch (SideScreen.CheckSpeedButton(MousePosition))
            {
                case -1://Does Nothing
                    break;
                case 0:// SlowDown
                    allMonkeys.DecreaseSpeedOfAllMonkeys();
                    Enemies.DecreaseSpeedOfAllZombies();
                    break;
                case 1://SpeedUp
                    allMonkeys.IncreaseSpeedOfAllMonkeys();
                    Enemies.IncreaseSpeedOfAllZombies();
                    break;
            }
            //Handles Adding and upgrading and removing Monkeys
            foreach (var item in allMonkeys.Monkeys)
            {
                if (SideScreen.UpgradeMonkey(item))
                {
                    ShouldUpgrade = true;
                    break;
                }
            }
            if (ShouldUpgrade)
            {
                switch (SideScreen.OneClicked.Type)
                {
                    case TypeOfMonkey.DartMonk:
                        if (Mouse.GetState().LeftButton == ButtonState.Released)
                        {
                            hasClicked = false;
                        }
                        if (!hasClicked && SideScreen.UpRange.HitBox.Value.Contains(MousePosition) && Mouse.GetState().LeftButton == ButtonState.Pressed)
                        {
                            TypesOfMonkeys.Dart monk = (TypesOfMonkeys.Dart)SideScreen.OneClicked;
                            if (!monk.IncreaseRangeByOne(ref SideScreen.Money, monk.IncreaseRangeCostAndLvl.Item1, screen))
                            {
                                if (monk.IncreaseRangeCostAndLvl.Item2 == monk.MaxUpgradeLvl)
                                {
                                    MaxLevelReached = true;
                                }
                                else
                                {
                                    TooLittleMoney = true;
                                }
                                DisplayTimer.Start();
                                DisplayTimer.Restart();
                            }
                            hasClicked = true;
                        }
                        else if (!hasClicked && SideScreen.UpDamage.HitBox.Value.Contains(MousePosition) && Mouse.GetState().LeftButton == ButtonState.Pressed)
                        {
                            TypesOfMonkeys.Dart monk = (TypesOfMonkeys.Dart)SideScreen.OneClicked;
                            if (!monk.UpgradeDamage(ref SideScreen.Money,10,monk.DamageAndCostAndLvl.Item2))
                            {
                                if (monk.DamageAndCostAndLvl.Item3 == monk.MaxUpgradeLvl)
                                {
                                    MaxLevelReached = true;
                                }
                                else
                                {
                                    TooLittleMoney = true;
                                }
                                DisplayTimer.Start();
                                DisplayTimer.Restart();
                            }
                            hasClicked = true;
                        }
                        else if (!hasClicked && SideScreen.UpCooldown.HitBox.Value.Contains(MousePosition) && Mouse.GetState().LeftButton == ButtonState.Pressed)
                        {
                            TypesOfMonkeys.Dart monk = (TypesOfMonkeys.Dart)SideScreen.OneClicked;
                            int CooldownDecrement = 300;
                            if (SideScreen.SpeedUp) CooldownDecrement = 150;
                            if (!monk.UpgradeCooldown(ref SideScreen.Money, CooldownDecrement, monk.CooldownAndCostAndLvl.Item2))
                            {
                                if (monk.CooldownAndCostAndLvl.Item3 == monk.MaxUpgradeLvl)
                                {
                                    MaxLevelReached = true;
                                }
                                else
                                {
                                    TooLittleMoney = true;
                                }
                                DisplayTimer.Start();
                                DisplayTimer.Restart();
                            }
                            hasClicked = true;
                        }
                        else if (SideScreen.Home.HitBox.Value.Contains(MousePosition) && Mouse.GetState().LeftButton == ButtonState.Pressed)
                        {
                            hasClicked = false;
                            SideScreen.OneClicked = null;
                            ShouldUpgrade = false;
                        }
                        else if (SideScreen.Remove.HitBox.Value.Contains(MousePosition) && Mouse.GetState().LeftButton == ButtonState.Pressed)
                        {
                            hasClicked = false;
                            SideScreen.Money += SideScreen.OneClicked.RemoveCost;
                            allMonkeys.Monkeys.Remove(SideScreen.OneClicked);
                            
                            SideScreen.OneClicked = null;
                            ShouldUpgrade = false;
                        }
                        break;
                    case TypeOfMonkey.SpikeMonk:
                        break;
                    case TypeOfMonkey.BombMonk:
                        break;
                    case TypeOfMonkey.IceMonk:
                        break;
                }
            }
            else
            {
                if (!MousePressed)
                {

                    switch (SideScreen.AddMonkey())
                    {
                        case -2:
                            if (!TooLittleMoney)
                            {
                                TooLittleMoney = true;
                                DisplayTimer.Start();
                                DisplayTimer.Restart();
                            }
                            break;
                        case -1:
                            break;
                        case 0:
                            OneToAdd = new TypesOfMonkeys.Dart(MousePosition, Content, new Vector2(15, 15), screen, 4, new Position(-1, -1), 5, 50, 1500, 50, 50, 3);

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
                    if (Mouse.GetState().LeftButton == ButtonState.Released)
                    {
                        MousePressed = false;
                        Position Grid = new Position((int)(MousePosition.X) / SizeOfSquare, (int)(MousePosition.Y) / SizeOfSquare);
                        if (Grid.X < screen.Map.GetLength(1) && Grid.Y < screen.Map.GetLength(0))
                        {
                            foreach (var item in allMonkeys.Monkeys)
                            {
                                if (item.GridPosition == Grid)
                                {
                                    OneToAdd = null;
                                    break;
                                }
                            }
                            if (OneToAdd != null && screen.Map[Grid.Y, Grid.X].Type != TypeOfImage.Path)
                            {
                                OneToAdd.GridPosition = Grid;
                                OneToAdd.AddRange(screen);
                                OneToAdd.sprite.Position = new Vector2(Grid.X * SizeOfSquare + 15, Grid.Y * SizeOfSquare + 15);
                                allMonkeys.AddMonkey(OneToAdd);
                                SideScreen.Money -= 100;
                                OneToAdd = null;
                            }

                        }
                        OneToAdd = null;
                    }
                }

            }
            ///


            if(SideScreen.HasStarted)
            {
                allMonkeys.UpdateAllMonkeys(screen);
                if (Enemies.UpdateAllZombies(SizeOfSquare, OffSet, screen, SideScreen)) return false;
            }
            return true;
        }
        public override void DrawLvlScreen(SpriteBatch spriteBatch, ContentManager Content)
        {
            if (DisplayTimer.ElapsedMilliseconds < 2000)
            {
                if (TooLittleMoney)
                {
                    spriteBatch.DrawString(SideScreen.Font, "Too Little Money", new Vector2(840, 575), Color.Black, 0, Vector2.Zero, 0.75f, SpriteEffects.None, 0);
                }
                else if (MaxLevelReached)
                {
                    spriteBatch.DrawString(SideScreen.Font, "Max Level Reached", new Vector2(820, 575), Color.Black, 0, Vector2.Zero, 0.75f, SpriteEffects.None, 0);
                }
            }
            else
            {
                TooLittleMoney = false;
                MaxLevelReached = false;
                DisplayTimer.Stop();
            }
            if (OneToAdd != null)
            {
                OneToAdd.Draw(spriteBatch);
            }
            SideScreen.Draw(spriteBatch, Content);
            Enemies.DrawAllZombies(spriteBatch);
            allMonkeys.DrawAllMonkeys(spriteBatch);
        }
    }
}
