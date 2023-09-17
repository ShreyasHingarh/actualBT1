using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Reflection.Metadata.BlobBuilder;

namespace ActualGame.TypesOfMonkeys
{
    internal class Bomb : Monkey
    {
        //Special Upgrades Bomb: Increase in range, fire two in two different directions at a time,
        Texture2D MonkeyWithBomb;
        Texture2D MonkeyWithNoBomb;
        public ActualBomb TheBomb;
        List<Zombie> Targets;
        Stopwatch FiringTimer;
        bool ShouldFire;
        bool HasLerped = false;
        float LerpIncrement = 0.1f;
        float LerpAmount = 0;

        public Bomb(Screen screen, Position gridpos, int baseRange, int baseDamage, int baseDamageUpgradeCost, 
            int baseCooldown, int baseCooldownUpgradeCost, int MaxLvl, int addCost, ContentManager Content,Vector2 Position, Vector2 Origin) 
            : base(screen, TypeOfMonkey.BombMonk, gridpos, baseRange, baseDamage, baseDamageUpgradeCost, baseCooldown, baseCooldownUpgradeCost, MaxLvl, addCost)
        {
            RemoveCost = 200;
            FiringTimer = new Stopwatch();
            TheBomb = new ActualBomb(Color.White,Position,Content.Load<Texture2D>("Bomb"),0,Vector2.Zero,Vector2.One);
            MonkeyWithBomb = Content.Load<Texture2D>("BombMonkey");
            MonkeyWithNoBomb = Content.Load<Texture2D>("NoBombMonkey");
            sprite = new Sprite(Color.White,Position,MonkeyWithBomb,0,Origin,Vector2.One);
            FiringTimer.Start();
        }

        public override void Draw(SpriteBatch spriteB,GameTime gameTime,Screen screen)
        {
            if (ShouldFire)
            {
                TheBomb.DrawBomb(spriteB);
                if (!HasLerped)
                {
                    if(LerpAmount < 1)
                    {
                        TheBomb.Position = Vector2.Lerp(TheBomb.Position, new Vector2(Targets[0].Position.X + Targets[0].Origin.X, Targets[0].Position.Y + Targets[0].Origin.Y), LerpAmount);
                        LerpAmount += LerpIncrement;
                    }
                    else
                    {
                        LerpAmount = 0;
                        TheBomb.stopwatch = TimeSpan.Zero;
                        TheBomb.GridPosition = new Position((sbyte)(Targets[0].Position.X / 30), (sbyte)(Targets[0].Position.Y / 30));
                        TheBomb.BombRange.Clear();
                        TheBomb.AddRange(screen,1);
                        TheBomb.Scale = new Vector2(2f, 2f);
                        HasLerped = true;
                    }
                }
                else if(TheBomb.UpdateBomb(gameTime))
                {
                    TheBomb.Scale = Vector2.One;
                    ShouldFire = false;
                    foreach (var square in TheBomb.BombRange)
                    {
                        if (!square.DoesContainZombie) continue;
                        square.OneContained.Health -= DamageAndCostAndLvl.Item1;
                    }
                    TheBomb.Position = sprite.Position;
                }
            }
            sprite.Draw(spriteB);
        }

        public override bool Update(ref List<Zombie> Zombies)
        {
            sprite.Rotation = (float)(Math.Atan2(Zombies[0].Position.Y - sprite.Position.Y, Zombies[0].Position.X - sprite.Position.X));
            if (Zombies == null || FiringTimer.ElapsedMilliseconds < CooldownAndCostAndLvl.Item1) return false;
            FiringTimer.Restart();
            Targets = Zombies;
            ShouldFire = true;
            HasLerped = false;
            sprite.Image = MonkeyWithNoBomb;
            return true;
        }
    }
}
