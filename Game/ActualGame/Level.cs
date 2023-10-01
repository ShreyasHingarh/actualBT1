using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ActualGame.TypesOfMonkeys;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ActualGame
{
    internal class Level
    {
        public AllEnemies Enemies;
        public AllMonkeys allMonkeys;
        public SideScreen SideScreen;

        public Stopwatch LevelSwitchTimer;
        bool hasClicked;

        Monkey OneToAdd;
        public bool TooLittleMoney;
        public bool MaxLevelReached;
        public Stopwatch DisplayTimer;
        int OffSet;
        public bool MousePressed = false;
        public bool ShouldUpgrade = false;
        public Level(int offSet, ContentManager Content, int cash,int Lives)
        {
            SideScreen = new SideScreen(Lives, cash, 1, Content);
            allMonkeys = new AllMonkeys();
            Enemies = new AllEnemies(); 
            LevelSwitchTimer = new Stopwatch();
            TooLittleMoney = false;
            MaxLevelReached = false;
            OffSet = offSet;
            DisplayTimer = new Stopwatch();
        }
        public bool UpdateLvlScreen(int SizeOfSquare, Screen screen, ContentManager Content)
        {
            if (LevelSwitchTimer.ElapsedMilliseconds > 2000 || SideScreen.Lives <= 0) return false;
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
                if (MousePressed) continue;
                if (SideScreen.UpgradeMonkey(item))
                {
                    foreach(var thing in SideScreen.MonkeyAddAndCost)
                    {
                        thing.Item1.CanClick = false;
                    }
                    SideScreen.Home.CanClick = true;
                    SideScreen.Remove.CanClick = true;
                    ShouldUpgrade = true;
                    break;
                }
            }
            if (ShouldUpgrade)
            {
                switch (SideScreen.OneClicked.Type)
                {
                    case TypeOfMonkey.DartMonk:
                        SideScreen.UpRange.CanClick = true;
                        SideScreen.UpDamage.CanClick = true;
                        SideScreen.UpCooldown.CanClick = true;
                        if (Mouse.GetState().LeftButton == ButtonState.Released)
                        {
                            hasClicked = false;
                        }
                        if (!hasClicked && SideScreen.UpRange.HasPressed(MousePosition))
                        {
                            Dart monk = (Dart)SideScreen.OneClicked;
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
                        else if (!hasClicked && SideScreen.UpDamage.HasPressed(MousePosition))
                        {
                            Dart monk = (Dart)SideScreen.OneClicked;
                            if (!monk.UpgradeDamage(ref SideScreen.Money, 5, monk.DamageAndCostAndLvl.Item2))
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
                        else if (!hasClicked && SideScreen.UpCooldown.HasPressed(MousePosition))
                        {
                            Dart monk = (Dart)SideScreen.OneClicked;
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
                        else if (SideScreen.Home.HasPressed(MousePosition))
                        {
                            hasClicked = false;
                            SideScreen.OneClicked = null;
                            ShouldUpgrade = false;
                            SideScreen.UpRange.CanClick = false;
                            SideScreen.Home.CanClick = false;
                            SideScreen.Remove.CanClick = false;
                            SideScreen.UpDamage.CanClick = false;
                            SideScreen.UpCooldown.CanClick = false; 
                            foreach (var thing in SideScreen.MonkeyAddAndCost)
                            {
                                thing.Item1.CanClick = true;
                            }
                        }
                        else if (SideScreen.Remove.HasPressed(MousePosition))
                        {
                            hasClicked = false;
                            SideScreen.Money += SideScreen.OneClicked.RemoveCost;
                            allMonkeys.Monkeys.Remove(SideScreen.OneClicked);
                            SideScreen.OneClicked = null;
                            ShouldUpgrade = false;
                            SideScreen.UpRange.CanClick = false;
                            SideScreen.Home.CanClick = false;
                            SideScreen.Remove.CanClick = false;
                            SideScreen.UpDamage.CanClick = false;
                            SideScreen.UpCooldown.CanClick = false;
                            foreach (var thing in SideScreen.MonkeyAddAndCost)
                            {
                                thing.Item1.CanClick = true;
                            }
                        }
                        break;
                    case TypeOfMonkey.SpikeMonk:
                        SideScreen.UpRange.CanClick = true;
                        SideScreen.UpDamage.CanClick = true;
                        SideScreen.UpCooldown.CanClick = true;
                        if (Mouse.GetState().LeftButton == ButtonState.Released)
                        {
                            hasClicked = false;
                        }
                        if (!hasClicked && SideScreen.UpRange.HasPressed(MousePosition))
                        {
                            Spike monk = (Spike)SideScreen.OneClicked;
                            if (!monk.IncreaseRangeByOne(ref SideScreen.Money, monk.IncreaseRangeCostAndLvl.Item1/2, screen))
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
                        else if (!hasClicked && SideScreen.UpDamage.HasPressed(MousePosition))
                        {
                            Spike monk = (Spike)SideScreen.OneClicked;
                            if (!monk.UpgradeDamage(ref SideScreen.Money, 5, monk.DamageAndCostAndLvl.Item2 / 2))
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
                        else if (!hasClicked && SideScreen.UpCooldown.HasPressed(MousePosition))
                        {
                            Spike monk = (Spike)SideScreen.OneClicked;
                            int CooldownDecrement = 200;
                            if (SideScreen.SpeedUp) CooldownDecrement = 100;
                            if (!monk.UpgradeCooldown(ref SideScreen.Money, CooldownDecrement, monk.CooldownAndCostAndLvl.Item2 / 2))
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
                        else if (SideScreen.Home.HasPressed(MousePosition))
                        {
                            hasClicked = false;
                            SideScreen.OneClicked = null;
                            ShouldUpgrade = false;
                            SideScreen.UpRange.CanClick = false;
                            SideScreen.Home.CanClick = false;
                            SideScreen.Remove.CanClick = false;
                            SideScreen.UpDamage.CanClick = false;
                            SideScreen.UpCooldown.CanClick = false; 
                            foreach (var thing in SideScreen.MonkeyAddAndCost)
                            {
                                thing.Item1.CanClick = true;
                            }
                        }
                        else if (SideScreen.Remove.HasPressed(MousePosition))
                        {
                            hasClicked = false;
                            SideScreen.Money += SideScreen.OneClicked.RemoveCost;
                            allMonkeys.Monkeys.Remove(SideScreen.OneClicked);
                            SideScreen.OneClicked = null;
                            ShouldUpgrade = false;
                            SideScreen.UpRange.CanClick = false;
                            SideScreen.Home.CanClick = false;
                            SideScreen.Remove.CanClick = false;
                            SideScreen.UpDamage.CanClick = false;
                            SideScreen.UpCooldown.CanClick = false;
                            foreach (var thing in SideScreen.MonkeyAddAndCost)
                            {
                                thing.Item1.CanClick = true;
                            }
                        }
                        break;
                    case TypeOfMonkey.BombMonk:
                        SideScreen.BombRangeButton.CanClick = true;
                        SideScreen.UpDamage.CanClick = true;
                        SideScreen.UpCooldown.CanClick = true;
                        SideScreen.UpRange.CanClick = true;
                        Bomb bomb = (Bomb)SideScreen.OneClicked;
                        if (Mouse.GetState().LeftButton == ButtonState.Released)
                        {
                            hasClicked = false;
                        }
                        if (!hasClicked && SideScreen.UpRange.HasPressed(MousePosition))
                        {
                            if (!bomb.IncreaseRangeOfBomb(ref SideScreen.Money, bomb.UpgradeCostandLevel.Item1/2, screen, Content))
                            {
                                if (bomb.UpgradeCostandLevel.Item2 == bomb.MaxUpgradeLvl)
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
                        else if (!hasClicked && SideScreen.UpDamage.HasPressed(MousePosition))
                        {
                            if (!bomb.UpgradeDamage(ref SideScreen.Money, 5, bomb.DamageAndCostAndLvl.Item2/2))
                            {
                                if (bomb.DamageAndCostAndLvl.Item3 == bomb.MaxUpgradeLvl)
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
                        else if (!hasClicked && SideScreen.UpCooldown.HasPressed(MousePosition))
                        {
                            int CooldownDecrement = 300;
                            if (SideScreen.SpeedUp) CooldownDecrement = 150;
                            if (!bomb.UpgradeCooldown(ref SideScreen.Money, CooldownDecrement, bomb.CooldownAndCostAndLvl.Item2/2))
                            {
                                if (bomb.CooldownAndCostAndLvl.Item3 == bomb.MaxUpgradeLvl)
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
                        else if (SideScreen.Home.HasPressed(MousePosition))
                        {
                            hasClicked = false;
                            SideScreen.OneClicked = null;
                            ShouldUpgrade = false;
                            SideScreen.BombRangeButton.CanClick = false;
                            SideScreen.AddBombButton.CanClick = false;
                            SideScreen.Home.CanClick = false;
                            SideScreen.Remove.CanClick = false;
                            SideScreen.UpDamage.CanClick = false;
                            SideScreen.UpCooldown.CanClick = false;
                            foreach (var thing in SideScreen.MonkeyAddAndCost)
                            {
                                thing.Item1.CanClick = true;
                            }
                        }
                        else if (SideScreen.Remove.HasPressed(MousePosition))
                        {
                            hasClicked = false;
                            SideScreen.Money += SideScreen.OneClicked.RemoveCost;
                            allMonkeys.Monkeys.Remove(SideScreen.OneClicked);
                            SideScreen.OneClicked = null;
                            ShouldUpgrade = false; 
                            SideScreen.BombRangeButton.CanClick = false;
                            SideScreen.AddBombButton.CanClick = false;
                            SideScreen.Home.CanClick = false;
                            SideScreen.Remove.CanClick = false;
                            SideScreen.UpDamage.CanClick = false;
                            SideScreen.UpCooldown.CanClick = false;
                            foreach (var thing in SideScreen.MonkeyAddAndCost)
                            {
                                thing.Item1.CanClick = true;
                            }
                        }
                        break;
                    case TypeOfMonkey.IceMonk:
                        SideScreen.UpIce.CanClick = true;
                        SideScreen.UpCooldown.CanClick = true;
                        SideScreen.UpRange.CanClick = true;

                        Ice ice = (Ice)SideScreen.OneClicked;
                        if (Mouse.GetState().LeftButton == ButtonState.Released)
                        {
                            hasClicked = false;
                        }
                        if (!hasClicked && SideScreen.UpIce.HasPressed(MousePosition))
                        {
                            if (!ice.UpgradeFrozen(ref SideScreen.Money, (int)(0.5f * ice.FrozenUpgradeCostandLvl.Item1), 250, 10, ref Enemies))
                            {
                                if (ice.FrozenUpgradeCostandLvl.Item2 == ice.MaxUpgradeLvl)
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
                        else if (!hasClicked && SideScreen.UpRange.HasPressed(MousePosition))
                        {
                            if (!ice.IncreaseRangeByOne(ref SideScreen.Money, ice.IncreaseRangeCostAndLvl.Item1 / 2, screen))
                            {
                                if (ice.DamageAndCostAndLvl.Item3 == ice.MaxUpgradeLvl)
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
                        else if (!hasClicked && SideScreen.UpCooldown.HasPressed(MousePosition))
                        {
                            int CooldownDecrement = 300;
                            if (SideScreen.SpeedUp) CooldownDecrement = 150;
                            if (!ice.UpgradeCooldown(ref SideScreen.Money, CooldownDecrement, ice.CooldownAndCostAndLvl.Item2 / 2))
                            {
                                if (ice.CooldownAndCostAndLvl.Item3 == ice.MaxUpgradeLvl)
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
                        else if (SideScreen.Home.HasPressed(MousePosition))
                        {
                            hasClicked = false;
                            SideScreen.OneClicked = null;
                            ShouldUpgrade = false;
                            SideScreen.UpIce.CanClick = false;
                            SideScreen.Home.CanClick = false;
                            SideScreen.Remove.CanClick = false;
                            SideScreen.UpDamage.CanClick = false;
                            SideScreen.UpCooldown.CanClick = false;
                            foreach (var thing in SideScreen.MonkeyAddAndCost)
                            {
                                thing.Item1.CanClick = true;
                            }
                        }
                        else if (SideScreen.Remove.HasPressed(MousePosition))
                        {
                            hasClicked = false;
                            SideScreen.Money += SideScreen.OneClicked.RemoveCost;
                            allMonkeys.Monkeys.Remove(SideScreen.OneClicked);
                            SideScreen.OneClicked = null;
                            ShouldUpgrade = false; 
                            SideScreen.UpIce.CanClick = false;
                            SideScreen.Home.CanClick = false;
                            SideScreen.Remove.CanClick = false;
                            SideScreen.UpDamage.CanClick = false;
                            SideScreen.UpCooldown.CanClick = false;
                            foreach (var thing in SideScreen.MonkeyAddAndCost)
                            {
                                thing.Item1.CanClick = true;
                            }
                        }
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
                            OneToAdd = new Dart(MousePosition, Content, new Vector2(15, 15), screen, 4, 5, 50, 1250, 50, 50, 3);
                            MousePressed = true;
                            break;
                        case 1:
                            OneToAdd = new Spike(MousePosition, Content, new Vector2(15, 15), screen, 3, 5, 75, 1500, 75, 75, 3);
                            MousePressed = true;
                            break;
                        case 2:
                            OneToAdd = new Bomb(screen, 3, 10, 100, 2500, 100, 3, 150, Content, MousePosition, new Vector2(15, 15));
                            MousePressed = true;
                            break;
                        case 3:
                            OneToAdd = new Ice(MousePosition, Content, new Vector2(15, 15), screen, 3, 0, 0, 1500, 100, 100, 3, 150, 100);
                            MousePressed = true;
                            break;
                    }
                }
                else
                {
                    OneToAdd.sprite.Position = MousePosition;
                    if (Mouse.GetState().LeftButton == ButtonState.Released)
                    {
                        MousePressed = false;
                        Position Grid = new Position((sbyte)(MousePosition.X / SizeOfSquare), (sbyte)(MousePosition.Y / SizeOfSquare));
                        if (Grid.X < screen.Map.GetLength(1) && Grid.Y < screen.Map.GetLength(0))
                        {
                            if (screen.Map[Grid.Y, Grid.X].Type != TypeOfImage.Path)
                            {
                                OneToAdd.GridPosition = Grid;
                                OneToAdd.sprite.Position = new Vector2(Grid.X * SizeOfSquare + 15, Grid.Y * SizeOfSquare + 15);
                                foreach (var item in allMonkeys.Monkeys)
                                {
                                    if (item.sprite.Position == OneToAdd.sprite.Position)
                                    {
                                        OneToAdd = null;
                                        break;
                                    }
                                }
                                if (OneToAdd != null)
                                {
                                    OneToAdd.AddRange(screen);
                                    switch (OneToAdd.Type)
                                    {
                                        case TypeOfMonkey.DartMonk:
                                            Dart temp = (Dart)OneToAdd;
                                            temp.Bullet.sprite.Position = temp.sprite.Position;
                                            break;
                                        case TypeOfMonkey.SpikeMonk:
                                            Spike spike = (Spike)OneToAdd;
                                            spike.CreateAllBullets(Content);
                                            break;
                                        case TypeOfMonkey.BombMonk:
                                            Bomb bomb = (Bomb)OneToAdd;
                                            bomb.TheBomb1.Position = bomb.sprite.Position;
                                            break;
                                        case TypeOfMonkey.IceMonk:
                                            Ice ice = (Ice)OneToAdd;
                                            ice.throwable.Position = ice.sprite.Position;
                                            break;
                                    }
                                    allMonkeys.AddMonkey(OneToAdd);
                                    SideScreen.Money -= OneToAdd.AddCost;
                                }
                            }
                        }
                        OneToAdd = null;
                    }
                }

            }
            if (SideScreen.HasStarted)
            {
                allMonkeys.UpdateAllMonkeys();
                if (Enemies.UpdateAllZombies(SizeOfSquare, OffSet, screen, SideScreen))
                {
                    LevelSwitchTimer.Start();
                }
            }
            return true;
        }
        public void DrawLvlScreen(SpriteBatch spriteBatch, ContentManager Content,GameTime gameTime, Screen screen)
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
                OneToAdd.Draw(spriteBatch, gameTime, screen);
            }
            SideScreen.Draw(spriteBatch, Content);
            Enemies.DrawAllZombies(spriteBatch);
            allMonkeys.DrawAllMonkeys(spriteBatch, gameTime, screen);
        }
    }
}
