using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActualGame
{
    internal class Bullet
    {
        public Sprite sprite;
        float LerpAmount; 
        float LerpIncrement;
        public bool HasHit;
        public Vector2 Target;
        public Bullet(Sprite prite, float lerpIncrement)
        {
            sprite = prite;
            LerpAmount = 0;
            LerpIncrement = lerpIncrement;
            HasHit = false;
        }
        public int Draw(SpriteBatch spriteB, Vector2 Position,List<ScreenSquare> RangeSquares,int DamageToDeal)
        {
            if (HasHit) return 1;
            if (LerpAmount < 1)
            {
                foreach (var item in RangeSquares)
                {
                    if (item.OneContained.HitBox.Value.Contains(sprite.Position))
                    {
                        item.OneContained.Health -= DamageToDeal;
                        sprite.Position = Position;
                        LerpAmount = 0;
                        HasHit = true;
                        return 1;
                    }
                }
                sprite.Position = Vector2.Lerp(sprite.Position, Target, LerpAmount);
                LerpAmount += LerpIncrement;
                sprite.Draw(spriteB);
            }
            else
            {
                sprite.Position = Position;
                LerpAmount = 0;
                HasHit = true;
                return 1;
            }
            return 0;
        }
    }
}
