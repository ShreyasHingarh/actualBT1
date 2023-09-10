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
        public Bullet(Sprite prite, float lerpIncrement,Vector2 target)
        {
            Target = target;
            sprite = prite;
            LerpAmount = 0;
            LerpIncrement = lerpIncrement;
            HasHit = false;
        }
        public int Draw(SpriteBatch spriteB, Vector2 Position,int DamageToDeal,ref List<Zombie> zombies,ref List<bool> Bools)
        {
            if (LerpAmount < 1)
            {
                byte index = 0;
                foreach (var item in zombies)
                {
                    if (!Bools[index] && item.HitBox.Value.Contains(sprite.Position))
                    {
                        item.Health -= DamageToDeal;
                        Bools[index] = true;
                        HasHit = true;
                    }
                    index++;
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
