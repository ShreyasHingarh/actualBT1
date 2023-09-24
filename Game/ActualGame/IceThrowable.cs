using ActualGame.TypesOfMonkeys;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActualGame
{
    internal class IceThrowable : Sprite
    {
        float LerpAmount;
        float LerpIncrement;
        public bool HasHit;
        public Vector2 Target;
        public IceThrowable(Vector2 position, Texture2D image, Vector2 origin, float lerpIncrement, Vector2 target) 
            : base(Color.White, position, image, 0, origin, Vector2.One)
        {
            Target = target;
            LerpAmount = 0;
            LerpIncrement = lerpIncrement;
            HasHit = false;
        }
        
        public int DrawThing(SpriteBatch spriteB, Vector2 Position, int FrozenTime, ref Zombie zombie, ref bool Bool, Texture2D SlowZombieImage)
        {
            if (LerpAmount < 1)
            {
                if(!Bool && zombie.HitBox.Value.Contains(this.Position))
                {
                    zombie.FrozenTimer.Restart();
                    zombie.LerpIncrement /= 2;
                    zombie.MaxFrozenTime = FrozenTime;
                    zombie.Image = SlowZombieImage;
                    Bool = true;
                    HasHit = true;
                }
                this.Position = Vector2.Lerp(Position, Target, LerpAmount);
                LerpAmount += LerpIncrement;
                Draw(spriteB);
            }
            else
            {
                this.Position = Position;
                LerpAmount = 0;
                HasHit = true;
                return 1;
            }
            return 0;
        }
    }
}
