using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;

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

        public SideScreen(int baseLive,int baseMoney, int baseLevel)
        {
            Lives = baseLive;
            Money = baseMoney;
            Level = baseLevel;
        }
        public void Draw(SpriteBatch sprite,ContentManager Content)
        {
            sprite.DrawString(Content.Load<SpriteFont>("File"), $"Lives: {Lives}", new Vector2(900, 100), Color.Black);
            sprite.DrawString(Content.Load<SpriteFont>("File"), $"Money: {Money}", new Vector2(900, 200), Color.Black);
            sprite.DrawString(Content.Load<SpriteFont>("File"), $"Level: {Level}", new Vector2(900, 300), Color.Black);
        }
    }
}
