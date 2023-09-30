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
        public Sprite UpCooldown;
        public Sprite UpDamage;
        public Sprite UpRange;
        public Sprite Home;
        public Sprite Remove;
        public Sprite StartButton;
        public Sprite PauseButton;
        public Sprite SpeedUpButton;
        public Sprite SpeedDownButton;
        public Sprite BombRangeButton;
        public Sprite AddBombButton;
        public Sprite UpIce;
        public bool HasStarted;
        public bool SpeedUp;
        public (Sprite,int,TypeOfMonkey)[] MonkeyAddAndCost;

        bool HasClicked;
        public SideScreen(int baseLive, int baseMoney, int baseLevel, ContentManager Content)
        {
            HasClicked = false;
            Font = Content.Load<SpriteFont>("File");
            Border = Content.Load<Texture2D>("Border");
            Remove = new Sprite(Color.BlanchedAlmond,new Vector2(860,460),Content.Load<Texture2D>("PopeCoinRemove"),0,Vector2.Zero,Vector2.One);
            Home = new Sprite(Color.BlanchedAlmond, new Vector2(880,400),Content.Load<Texture2D>("Home"),0,Vector2.Zero,Vector2.One);
            UpCooldown = new Sprite(Color.BlanchedAlmond, new Vector2(810, 220),Content.Load<Texture2D>("upgradeCoolDownButton"),0,Vector2.Zero,Vector2.One);
            UpDamage = new Sprite(Color.BlanchedAlmond, new Vector2(810, 280), Content.Load<Texture2D>("upgradeDamageButton"), 0, Vector2.Zero, Vector2.One);
            UpRange = new Sprite(Color.BlanchedAlmond, new Vector2(810, 340),Content.Load<Texture2D>("upgradeRangeButton"),0,Vector2.Zero,Vector2.One);
            StartButton = new Sprite(Color.BlanchedAlmond, new Vector2(810, 650), Content.Load<Texture2D>("StartButton"), 0, Vector2.Zero, Vector2.One);
            PauseButton = new Sprite(Color.BlanchedAlmond, new Vector2(810, 650), Content.Load<Texture2D>("PauseButton"), 0, Vector2.Zero, Vector2.One);
            SpeedUpButton = new Sprite(Color.BlanchedAlmond, new Vector2(810, 710), Content.Load<Texture2D>("SpeedButton"), 0, Vector2.Zero, Vector2.One);
            SpeedDownButton = new Sprite(Color.BlanchedAlmond, new Vector2(810, 710), Content.Load<Texture2D>("SlowButton"), 0, Vector2.Zero, Vector2.One);
            BombRangeButton = new Sprite(Color.BlanchedAlmond, new Vector2(810, 340), Content.Load<Texture2D>("upgradeBombRangeButton"), 0, Vector2.Zero, Vector2.One);
            AddBombButton = new Sprite(Color.BlanchedAlmond, new Vector2(810, 340), Content.Load<Texture2D>("AddABombButton"), 0, Vector2.Zero, Vector2.One);
            UpIce = new Sprite(Color.BlanchedAlmond, new Vector2(810, 280), Content.Load<Texture2D>("UpgradeIce"), 0, Vector2.Zero, Vector2.One);
            HasStarted = false;
            MonkeyAddAndCost = new (Sprite, int, TypeOfMonkey)[]
            {
                (new Sprite(Color.White, new Vector2(880, 200),Content.Load<Texture2D>("Monkey"),0,Vector2.Zero,new Vector2(2,2)),100,TypeOfMonkey.DartMonk),   
                (new Sprite(Color.White, new Vector2(860, 280),Content.Load<Texture2D>("IceMonkey"),0,Vector2.Zero,new Vector2(2,2)),125,TypeOfMonkey.IceMonk),
                (new Sprite(Color.White, new Vector2(880, 360),Content.Load<Texture2D>("BombMonkey"),0,Vector2.Zero,new Vector2(2,2)),150,TypeOfMonkey.BombMonk),
                (new Sprite(Color.White, new Vector2(880, 440),Content.Load<Texture2D>("KirboSpike"),0,Vector2.Zero,new Vector2(2,2)),150,TypeOfMonkey.SpikeMonk)
            };
            Lives = baseLive;
            Money = baseMoney;
            Level = baseLevel;
        }
        public int CheckSpeedButton(Vector2 MousePosition)
        {
            if (!HasClicked && !SpeedUp && SpeedUpButton.HitBox.Value.Contains(MousePosition) && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                HasClicked = true;
                SpeedUp = true;
                return 1;
            }
            else if(!HasClicked && SpeedDownButton.HitBox.Value.Contains(MousePosition) && Mouse.GetState().LeftButton == ButtonState.Pressed)
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
            if(!HasClicked && !HasStarted && StartButton.HitBox.Value.Contains(MousePosition) && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                HasClicked = true;
                HasStarted = true;
            }
            else if (!HasClicked && PauseButton.HitBox.Value.Contains(MousePosition) && Mouse.GetState().LeftButton == ButtonState.Pressed)
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
                PauseButton.Draw(sprite);
            }
            else
            {
                StartButton.Draw(sprite);
            }
            if(SpeedUp)
            {
                SpeedDownButton.Draw(sprite);
            }
            else
            {
                SpeedUpButton.Draw(sprite);
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
                        UpCooldown.Draw(sprite); 
                        sprite.DrawString(Font, $"Lvl: {dart.CooldownAndCostAndLvl.Item3}", new Vector2(890, UpCooldown.Position.Y + UpCooldown.Image.Height), Color.Black, 0, Vector2.Zero, 0.5f, SpriteEffects.None, 0);
                        UpDamage.Draw(sprite);
                        sprite.DrawString(Font, $"Lvl: {dart.DamageAndCostAndLvl.Item3}", new Vector2(890, UpDamage.Position.Y + UpDamage.Image.Height), Color.Black, 0, Vector2.Zero, 0.5f, SpriteEffects.None, 0);
                        UpRange.Draw(sprite);
                        sprite.DrawString(Font, $"Lvl: {dart.IncreaseRangeCostAndLvl.Item2}", new Vector2(890, UpRange.Position.Y + UpRange.Image.Height), Color.Black, 0, Vector2.Zero, 0.5f, SpriteEffects.None, 0);
                        break;
                    case TypeOfMonkey.SpikeMonk:
                        Spike spike = (Spike)OneClicked;
                        UpCooldown.Draw(sprite);
                        sprite.DrawString(Font, $"Lvl: {spike.CooldownAndCostAndLvl.Item3}", new Vector2(890, UpCooldown.Position.Y + UpCooldown.Image.Height), Color.Black, 0, Vector2.Zero, 0.5f, SpriteEffects.None, 0);
                        UpDamage.Draw(sprite);
                        sprite.DrawString(Font, $"Lvl: {spike.DamageAndCostAndLvl.Item3}", new Vector2(890, UpDamage.Position.Y + UpDamage.Image.Height), Color.Black, 0, Vector2.Zero, 0.5f, SpriteEffects.None, 0);
                        UpRange.Draw(sprite);
                        sprite.DrawString(Font, $"Lvl: {spike.IncreaseRangeCostAndLvl.Item2}", new Vector2(890, UpRange.Position.Y + UpRange.Image.Height), Color.Black, 0, Vector2.Zero, 0.5f, SpriteEffects.None, 0);
                        break;
                    case TypeOfMonkey.BombMonk:
                        Bomb bomb = (Bomb)OneClicked;
                        UpCooldown.Draw(sprite);
                        sprite.DrawString(Font, $"Lvl: {bomb.CooldownAndCostAndLvl.Item3}", new Vector2(890, UpCooldown.Position.Y + UpCooldown.Image.Height), Color.Black, 0, Vector2.Zero, 0.5f, SpriteEffects.None, 0);
                        UpDamage.Draw(sprite);
                        sprite.DrawString(Font, $"Lvl: {bomb.DamageAndCostAndLvl.Item3}", new Vector2(890, UpDamage.Position.Y + UpDamage.Image.Height), Color.Black, 0, Vector2.Zero, 0.5f, SpriteEffects.None, 0);
                        if(bomb.UpgradeCostandLevel.Item2 == 1)
                        {
                            AddBombButton.Draw(sprite);
                        }
                        else
                        {
                            BombRangeButton.Draw(sprite);
                        }
                        sprite.DrawString(Font, $"Lvl: {bomb.UpgradeCostandLevel.Item2}", new Vector2(890, AddBombButton.Position.Y + AddBombButton.Image.Height), Color.Black, 0, Vector2.Zero, 0.5f, SpriteEffects.None, 0);
                        break;
                    case TypeOfMonkey.IceMonk:
                        Ice ice = (Ice)OneClicked;
                        UpCooldown.Draw(sprite);
                        sprite.DrawString(Font, $"Lvl: {ice.CooldownAndCostAndLvl.Item3}", new Vector2(890, UpCooldown.Position.Y + UpCooldown.Image.Height), Color.Black, 0, Vector2.Zero, 0.5f, SpriteEffects.None, 0);
                        UpRange.Draw(sprite);
                        sprite.DrawString(Font, $"Lvl: {ice.IncreaseRangeCostAndLvl.Item2}", new Vector2(890, UpRange.Position.Y + UpRange.Image.Height), Color.Black, 0, Vector2.Zero, 0.5f, SpriteEffects.None, 0);
                        if(ice.FrozenUpgradeCostandLvl.Item2 == 2)
                        {
                            UpDamage.Draw(sprite);
                        }
                        else
                        {
                            UpIce.Draw(sprite);
                        }
                        sprite.DrawString(Font, $"Lvl: {ice.FrozenUpgradeCostandLvl.Item2}", new Vector2(890, UpIce.Position.Y + UpIce.Image.Height), Color.Black, 0, Vector2.Zero, 0.5f, SpriteEffects.None, 0);
                        
                        break;
                }
                Home.Draw(sprite);
                Remove.Draw(sprite);
            }
        }
    }
}
