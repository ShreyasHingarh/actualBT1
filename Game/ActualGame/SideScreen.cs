using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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
        Monkey OneClicked;
        SpriteFont Font;
        Texture2D Border;
        public (Sprite,int,TypeOfMonkey)[] DartMonkeyAddAndCost;
        public SideScreen(int baseLive, int baseMoney, int baseLevel, ContentManager Content)
        {
            Font = Content.Load<SpriteFont>("File");
            Border = Content.Load<Texture2D>("Border");
            DartMonkeyAddAndCost = new (Sprite, int, TypeOfMonkey)[]
            {
                (new Sprite(Color.White, new Vector2(860, 200),Content.Load<Texture2D>("Monkey"),0,Vector2.Zero,new Vector2(2,2)),100,TypeOfMonkey.DartMonk)   
                //new Sprite(Color.White, new Vector2(860, 280),Content.Load<Texture2D>("IceMonkey"),0,Vector2.Zero,new Vector2(2,2));
                //new Sprite(Color.White, new Vector2(860, 360),Content.Load<Texture2D>("BombMonkey"),0,Vector2.Zero,new Vector2(2,2));
                //new Sprite(Color.White, new Vector2(860, 440),Content.Load<Texture2D>("SpikeMonkey"),0,Vector2.Zero,new Vector2(2,2));
            };
            Lives = baseLive;
            Money = baseMoney;
            Level = baseLevel;
        }
        public int AddMonkey()
        {
            Vector2 MousePosition = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
            foreach(var item in DartMonkeyAddAndCost)
            {//item.Item1.HitBox.Value.Contains(MousePosition) && Mouse.GetState().LeftButton == ButtonState.Pressed 
                if (item.Item1.HitBox.Value.Contains(MousePosition) && Mouse.GetState().LeftButton == ButtonState.Pressed && item.Item2 < Money)
                {
                    return (int)item.Item3;
                }
            }
            return -1;
        }
        public bool UpgradeMonkey(Monkey monkey)
        {
            Vector2 MousePosition = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
            if (!monkey.sprite.HitBox.Value.Contains(MousePosition)) return false;
            OneClicked = monkey;
            return true;
        }
        public void Draw(SpriteBatch sprite,ContentManager Content)
        {
            sprite.DrawString(Font, $"Lives: {Lives}", new Vector2(850, 10), Color.Black);
            sprite.DrawString(Font, $"Money: {Money}", new Vector2(850, 60), Color.Black);
            sprite.DrawString(Font, $"Level: {Level}", new Vector2(850, 110), Color.Black);
            sprite.Draw(Border, new Vector2(810, 150), Color.White);
            if(OneClicked == null)
            {
                foreach(var item in DartMonkeyAddAndCost)
                {
                    item.Item1.Draw(sprite);
                    sprite.DrawString(Font, $"${item.Item2}", new Vector2(930, 220), Color.Black);
                }
            }
            else
            {
                //upgrades
            }
        }
    }
}
