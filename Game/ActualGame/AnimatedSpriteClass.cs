using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActualGame
{
    internal class AnimatedSpriteClass : Sprite
    {
        public int currentFrameIndex;
        public Frames CurrentFrame { get; set; }
        public List<Frames> Frames { get; set; }
        public TimeSpan stopwatch;
        public TimeSpan compare = TimeSpan.FromMilliseconds(30);
        public AnimatedSpriteClass(Color tint, Vector2 position, Texture2D image, float rotation, Vector2 origin, Vector2 scale) 
            : base(tint, position, image, rotation, origin, scale)
        {
            currentFrameIndex = 0;
            stopwatch = TimeSpan.Zero;
        }
        public bool UpdateAnimationFrame(GameTime gameTime)
        {
            stopwatch += gameTime.ElapsedGameTime;
            if(stopwatch > compare && currentFrameIndex < Frames.Count - 1)
            {
                currentFrameIndex++;
                stopwatch = TimeSpan.Zero;
                return false;
            }
            if(currentFrameIndex == Frames.Count - 1)
            {
                CurrentFrame = null;
                currentFrameIndex = 0;
                stopwatch = TimeSpan.Zero;
                return true;
            }
            return false;
        }
        public void DrawAnimation(SpriteBatch spriteB)
        {
            CurrentFrame = Frames[currentFrameIndex];
            SourceRectangle = CurrentFrame.Frame;
            Origin = CurrentFrame.Origin;
            spriteB.Draw(Image, Position, SourceRectangle, Tint, Rotation, Origin, Scale, Effects, LayerDepth);
        }
    }
    class Frames
    {
        public Vector2 Origin;
        public Rectangle Frame;

        public Frames(int x, int y, int width, int height, Vector2 origin)
        {
            Frame = new Rectangle(x, y, width, height);
            Origin = origin;
        }
    }
}

