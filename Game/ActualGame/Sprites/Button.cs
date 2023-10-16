using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActualGame.Sprites
{
    internal class Button
    {
        public Sprite BaseImage;
        public string Text;
        public bool CanClick;
        public Button(Sprite baseImage, string text, bool canClick)
        {
            CanClick = canClick;
            BaseImage = baseImage;
            Text = text;
        }
        public bool HasPressed(Vector2 MousePosition) => CanClick && BaseImage.HitBox.Value.Contains(MousePosition) && Mouse.GetState().LeftButton == ButtonState.Pressed;
        public void DrawButton(SpriteBatch spriteBatch, ContentManager Content, Vector2 Position)
        {
            BaseImage.Draw(spriteBatch);
            spriteBatch.DrawString(Content.Load<SpriteFont>("File"), Text, Position, Color.Black, 0, Vector2.Zero, (float)(0.5 * BaseImage.Scale.X), SpriteEffects.None, 0);
        }
    }
}
