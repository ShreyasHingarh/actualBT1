using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ActualGame.TypesOfMonkeys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ActualGame
{
    internal class SideScreen
    {
        public int Lives;
        public int Money;
        public int Level;
        public Monkey OneClicked;
        public SpriteFont Font;
        
        Texture2D Border;
        public Button UpCooldown;
        public Button UpDamage;
        public Button UpRange;
        public Button Home;
        public Button Remove;
        public Button StartButton;
        public Button PauseButton;
        public Button SpeedUpButton;
        public Button SpeedDownButton;
        public Button BombRangeButton;
        public Button AddBombButton;
        public Button UpIce;
        public bool HasStarted;
        public bool SpeedUp;
        public (Sprite,int,TypeOfMonkey)[] MonkeyAddAndCost;

        bool HasClicked;
        public SideScreen(int baseLive, int baseMoney, int baseLevel, ContentManager Content)
        {
            HasClicked = false;
            Font = Content.Load<SpriteFont>("File");
            Border = Content.Load<Texture2D>("Border");
            Texture2D Button = Content.Load<Texture2D>("Button");
            Remove = new Button(new Sprite(Color.BlanchedAlmond, new Vector2(860, 460), Content.Load<Texture2D>("PopeCoinRemove"), 0, Vector2.Zero, Vector2.One), "");
            Home = new Button(new Sprite(Color.BlanchedAlmond, new Vector2(880,400),Content.Load<Texture2D>("Home"),0,Vector2.Zero,Vector2.One), "");
            UpCooldown = new Button(new Sprite(Color.BlanchedAlmond, new Vector2(810, 220),Button,0,Vector2.Zero,Vector2.One),"Upgrade Cooldown");
            UpDamage = new Button(new Sprite(Color.BlanchedAlmond, new Vector2(810, 280), Button, 0, Vector2.Zero, Vector2.One),"Upgrade Damage");
            UpRange = new Button(new Sprite(Color.BlanchedAlmond, new Vector2(810, 340),Button,0,Vector2.Zero,Vector2.One),"UpgradeRange");
            StartButton = new Button(new Sprite(Color.BlanchedAlmond, new Vector2(810, 650), Content.Load<Texture2D>("StartButton"), 0, Vector2.Zero, Vector2.One),"");
            PauseButton = new Button(new Sprite(Color.BlanchedAlmond, new Vector2(810, 650), Content.Load<Texture2D>("PauseButton"), 0, Vector2.Zero, Vector2.One),"");
            SpeedUpButton = new Button(new Sprite(Color.BlanchedAlmond, new Vector2(810, 710), Content.Load<Texture2D>("SpeedButton"), 0, Vector2.Zero, Vector2.One),"");
            SpeedDownButton = new Button(new Sprite(Color.BlanchedAlmond, new Vector2(810, 710), Content.Load<Texture2D>("SlowButton"), 0, Vector2.Zero, Vector2.One),"");
            BombRangeButton = new Button(new Sprite(Color.BlanchedAlmond, new Vector2(810, 340), Button, 0, Vector2.Zero, Vector2.One),"Upgrade Bomb Range");
            AddBombButton = new Button(new Sprite(Color.BlanchedAlmond, new Vector2(810, 340), Button, 0, Vector2.Zero, Vector2.One),"Add A Bomb");
            UpIce = new Button(new Sprite(Color.BlanchedAlmond, new Vector2(810, 280), Button, 0, Vector2.Zero, Vector2.One),"Upgrade Ice");
            HasStarted = false;
            MonkeyAddAndCost = new (Sprite, int, TypeOfMonkey)[]
            {
                (new Sprite(Color.White, new Vector2(880, 200),Content.Load<Texture2D>("Monkey"),0,Vector2.Zero,new Vector2(2,2)),100,TypeOfMonkey.DartMonk),   
                (new Sprite(Color.White, new Vector2(880, 280),Content.Load<Texture2D>("IceMonkey"),0,Vector2.Zero,new Vector2(2,2)),125,TypeOfMonkey.IceMonk),
                (new Sprite(Color.White, new Vector2(880, 360),Content.Load<Texture2D>("BombMonkey"),0,Vector2.Zero,new Vector2(2,2)),150,TypeOfMonkey.BombMonk),
                (new Sprite(Color.White, new Vector2(880, 440),Content.Load<Texture2D>("KirboSpike"),0,Vector2.Zero,new Vector2(2,2)),150,TypeOfMonkey.SpikeMonk)
            };
            Lives = baseLive;
            Money = baseMoney;
            Level = baseLevel;
        }
        public int CheckSpeedButton(Vector2 MousePosition)
        {
            if (!HasClicked && !SpeedUp && SpeedUpButton.HasPressed(MousePosition))
            {
                HasClicked = true;
                SpeedUp = true;
                return 1;
            }
            else if(!HasClicked && SpeedDownButton.HasPressed(MousePosition))
            {
                HasClicked = true;
                SpeedUp = false;
                return 0;
            }
            else if (HasClicked && Mouse.GetState().LeftButton == ButtonState.Released)
            {
                HasClicked = false;
            }
            return -1;
        }
        public void CheckStartButton(Vector2 MousePosition)
        {
            if(!HasClicked && !HasStarted && StartButton.HasPressed(MousePosition))
            {
                HasClicked = true;
                HasStarted = true;
            }
            else if (!HasClicked && PauseButton.HasPressed(MousePosition))
            {
                HasClicked = true;
                HasStarted = false;
            }
            else if (HasClicked && Mouse.GetState().LeftButton == ButtonState.Released)
            {
                HasClicked = false;
            }
        }
        public int AddMonkey()
        {
            Vector2 MousePosition = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
            foreach(var item in MonkeyAddAndCost)
            {
                if (item.Item1.HitBox.Value.Contains(MousePosition) && Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    if (item.Item2 > Money)
                    {
                        return -2;
                    }
                    return (int)item.Item3;
                }
            }
            return -1;
        }
        public bool UpgradeMonkey(Monkey monkey)
        {
            Vector2 MousePosition = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
            if (monkey.sprite.HitBox.Value.Contains(MousePosition) && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                OneClicked = monkey;
                return true;
            }
            return false;
        }
        public void Draw(SpriteBatch sprite,ContentManager Content)
        {
            sprite.DrawString(Font, $"Lives: {Lives}", new Vector2(850, 10), Color.Black);
            sprite.DrawString(Font, $"Money: {Money}", new Vector2(850, 60), Color.Black);
            sprite.DrawString(Font, $"Level: {Level}", new Vector2(850, 110), Color.Black);
            sprite.Draw(Border, new Vector2(810, 150), Color.White);
            sprite.Draw(Border, new Vector2(810, 600), Color.White);
            if(HasStarted)
            {
                PauseButton.DrawButton(sprite,Content,new Vector2(PauseButton.BaseImage.Position.X + 10,PauseButton.BaseImage.Position.Y + 10));
            }
            else
            {
                StartButton.DrawButton(sprite, Content, new Vector2(StartButton.BaseImage.Position.X + 10, StartButton.BaseImage.Position.Y + 10));
            }
            if(SpeedUp)
            {
                SpeedDownButton.DrawButton(sprite, Content, new Vector2(SpeedDownButton.BaseImage.Position.X + 10, SpeedDownButton.BaseImage.Position.Y + 10));
            }
            else
            {
                SpeedUpButton.DrawButton(sprite, Content, new Vector2(SpeedUpButton.BaseImage.Position.X + 10, SpeedUpButton.BaseImage.Position.Y + 10));
            }
            if (OneClicked == null)
            {
                foreach(var item in MonkeyAddAndCost)
                {
                    item.Item1.Draw(sprite);
                    sprite.DrawString(Font, $"${item.Item2}", new Vector2(890, item.Item1.Position.Y + 60), Color.Black,0,Vector2.Zero,0.7f,SpriteEffects.None,0);
                }
            }
            else
            {
                sprite.DrawString(Font, $"Max Level is 3", new Vector2(870, 200), Color.Black, 0, Vector2.Zero, 0.5f, SpriteEffects.None, 0);
                switch (OneClicked.Type)
                {
                    case TypeOfMonkey.DartMonk:
                        Dart dart = (Dart)OneClicked;
                        UpCooldown.DrawButton(sprite, Content, new Vector2(UpCooldown.BaseImage.Position.X + 10, UpCooldown.BaseImage.Position.Y + 10)); 
                        sprite.DrawString(Font, $"Lvl: {dart.CooldownAndCostAndLvl.Item3}", new Vector2(890, UpCooldown.BaseImage.Position.Y + UpCooldown.BaseImage.Image.Height), Color.Black, 0, Vector2.Zero, 0.5f, SpriteEffects.None, 0);
                        UpDamage.DrawButton(sprite, Content, new Vector2(UpDamage.BaseImage.Position.X + 10, UpDamage.BaseImage.Position.Y + 10));
                        sprite.DrawString(Font, $"Lvl: {dart.DamageAndCostAndLvl.Item3}", new Vector2(890, UpDamage.BaseImage.Position.Y + UpDamage.BaseImage.Image.Height), Color.Black, 0, Vector2.Zero, 0.5f, SpriteEffects.None, 0);
                        UpRange.DrawButton(sprite, Content, new Vector2(UpRange.BaseImage.Position.X + 10, UpRange.BaseImage.Position.Y + 10));
                        sprite.DrawString(Font, $"Lvl: {dart.IncreaseRangeCostAndLvl.Item2}", new Vector2(890, UpRange.BaseImage.Position.Y + UpRange.BaseImage.Image.Height), Color.Black, 0, Vector2.Zero, 0.5f, SpriteEffects.None, 0);
                        break;
                    case TypeOfMonkey.SpikeMonk:
                        Spike spike = (Spike)OneClicked;
                        UpCooldown.DrawButton(sprite, Content, new Vector2(UpCooldown.BaseImage.Position.X + 10, UpCooldown.BaseImage.Position.Y + 10));
                        sprite.DrawString(Font, $"Lvl: {spike.CooldownAndCostAndLvl.Item3}", new Vector2(890, UpCooldown.BaseImage.Position.Y + UpCooldown.BaseImage.Image.Height), Color.Black, 0, Vector2.Zero, 0.5f, SpriteEffects.None, 0);
                        UpDamage.DrawButton(sprite, Content, new Vector2(UpDamage.BaseImage.Position.X + 10, UpDamage.BaseImage.Position.Y + 10));
                        sprite.DrawString(Font, $"Lvl: {spike.DamageAndCostAndLvl.Item3}", new Vector2(890, UpDamage.BaseImage.Position.Y + UpDamage.BaseImage.Image.Height), Color.Black, 0, Vector2.Zero, 0.5f, SpriteEffects.None, 0);
                        UpRange.DrawButton(sprite, Content, new Vector2(UpRange.BaseImage.Position.X + 10, UpRange.BaseImage.Position.Y + 10));
                        sprite.DrawString(Font, $"Lvl: {spike.IncreaseRangeCostAndLvl.Item2}", new Vector2(890, UpRange.BaseImage.Position.Y + UpRange.BaseImage.Image.Height), Color.Black, 0, Vector2.Zero, 0.5f, SpriteEffects.None, 0);
                        break;
                    case TypeOfMonkey.BombMonk:
                        Bomb bomb = (Bomb)OneClicked;
                        UpCooldown.DrawButton(sprite, Content, new Vector2(UpCooldown.BaseImage.Position.X + 10, UpCooldown.BaseImage.Position.Y + 10));
                        sprite.DrawString(Font, $"Lvl: {bomb.CooldownAndCostAndLvl.Item3}", new Vector2(890, UpCooldown.BaseImage.Position.Y + UpCooldown.BaseImage.Image.Height), Color.Black, 0, Vector2.Zero, 0.5f, SpriteEffects.None, 0);
                        UpDamage.DrawButton(sprite, Content, new Vector2(UpDamage.BaseImage.Position.X + 10, UpDamage.BaseImage.Position.Y + 10));
                        sprite.DrawString(Font, $"Lvl: {bomb.DamageAndCostAndLvl.Item3}", new Vector2(890, UpDamage.BaseImage.Position.Y + UpDamage.BaseImage.Image.Height), Color.Black, 0, Vector2.Zero, 0.5f, SpriteEffects.None, 0);
                        if(bomb.UpgradeCostandLevel.Item2 == 1)
                        {
                            AddBombButton.DrawButton(sprite, Content, new Vector2(AddBombButton.BaseImage.Position.X + 10, AddBombButton.BaseImage.Position.Y + 10));
                        }
                        else
                        {
                            BombRangeButton.DrawButton(sprite, Content, new Vector2(BombRangeButton.BaseImage.Position.X + 10, BombRangeButton.BaseImage.Position.Y + 10));
                        }
                        sprite.DrawString(Font, $"Lvl: {bomb.UpgradeCostandLevel.Item2}", new Vector2(890, AddBombButton.BaseImage.Position.Y + AddBombButton.BaseImage.Image.Height), Color.Black, 0, Vector2.Zero, 0.5f, SpriteEffects.None, 0);
                        break;
                    case TypeOfMonkey.IceMonk:
                        Ice ice = (Ice)OneClicked;
                        UpCooldown.DrawButton(sprite, Content, new Vector2(UpCooldown.BaseImage.Position.X + 10, UpCooldown.BaseImage.Position.Y + 10));
                        sprite.DrawString(Font, $"Lvl: {ice.CooldownAndCostAndLvl.Item3}", new Vector2(890, UpCooldown.BaseImage.Position.Y + UpCooldown.BaseImage.Image.Height), Color.Black, 0, Vector2.Zero, 0.5f, SpriteEffects.None, 0);
                        UpRange.DrawButton(sprite, Content, new Vector2(UpRange.BaseImage.Position.X + 10, UpRange.BaseImage.Position.Y + 10));
                        sprite.DrawString(Font, $"Lvl: {ice.IncreaseRangeCostAndLvl.Item2}", new Vector2(890, UpRange.BaseImage.Position.Y + UpRange.BaseImage.Image.Height), Color.Black, 0, Vector2.Zero, 0.5f, SpriteEffects.None, 0);
                        if(ice.FrozenUpgradeCostandLvl.Item2 == 2)
                        {
                            UpDamage.DrawButton(sprite, Content, new Vector2(UpDamage.BaseImage.Position.X + 10, UpDamage.BaseImage.Position.Y + 10));
                        }
                        else
                        {
                            UpIce.DrawButton(sprite, Content, new Vector2(UpIce.BaseImage.Position.X + 10, UpIce.BaseImage.Position.Y + 10));
                        }
                        sprite.DrawString(Font, $"Lvl: {ice.FrozenUpgradeCostandLvl.Item2}", new Vector2(890, UpIce.BaseImage.Position.Y + UpIce.BaseImage.Image.Height), Color.Black, 0, Vector2.Zero, 0.5f, SpriteEffects.None, 0);
                        
                        break;
                }
                Home.DrawButton(sprite, Content, new Vector2(Home.BaseImage.Position.X + 10, Home.BaseImage.Position.Y + 10));
                Remove.DrawButton(sprite, Content, new Vector2(Remove.BaseImage.Position.X + 10, Remove.BaseImage.Position.Y + 10));
            }
        }
    }
}
