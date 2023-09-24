using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ActualGame.TypesOfMonkeys
{
    internal class Spike : Monkey
    {
        public (int, int) IncreaseRangeCostAndLvl;
        Bullet[] Bullets;
        public List<Zombie> zombies;
        List<bool> HasHitZombie = new List<bool>();
        
        int total = 0;
        public Spike(Vector2 Position, ContentManager Content, Vector2 Origin, Screen screen, Position gridpos,
            int baseRange, int baseDamage, int baseDamageUpgradeCost, int baseCooldown, int baseCooldownUpgradeCost, int baseRangeCost, int MaxLvl)
            : base(screen, TypeOfMonkey.SpikeMonk, gridpos, baseRange, baseDamage, baseDamageUpgradeCost, baseCooldown, baseCooldownUpgradeCost, MaxLvl, 150)
        {
            RemoveCost = 100;
            sprite = new Sprite(Color.White, Position, Content.Load<Texture2D>("KirboSpike"), 0, Origin, Vector2.One);
            IncreaseRangeCostAndLvl = (baseRangeCost, 0);
        }
        public void CreateAllBullets(ContentManager Content)
        {
            Texture2D Dart = Content.Load<Texture2D>("Dart");
            int size = RangeSize * 30;
            Bullets = new Bullet[]
            {
                new Bullet(new Sprite(Color.White,sprite.Position,Dart,0,sprite.Origin,Vector2.One), 0.1f, new Vector2(sprite.Position.X + size + sprite.Origin.Y, sprite.Position.Y + sprite.Origin.Y)),
                new Bullet(new Sprite(Color.White,sprite.Position,Dart,(float)(Math.PI/4),sprite.Origin,Vector2.One), 0.1f,new Vector2(sprite.Position.X + size + sprite.Origin.Y, sprite.Position.Y + size + sprite.Origin.Y)),
                new Bullet(new Sprite(Color.White,sprite.Position,Dart,(float)(Math.PI/2),sprite.Origin,Vector2.One), 0.1f,new Vector2(sprite.Position.X + sprite.Origin.Y, sprite.Position.Y+ size + sprite.Origin.Y)),
                new Bullet(new Sprite(Color.White,sprite.Position,Dart,(float)(3 * Math.PI/4),sprite.Origin,Vector2.One), 0.1f,new Vector2(sprite.Position.X - size + sprite.Origin.Y, sprite.Position.Y +size+ sprite.Origin.Y)),
                new Bullet(new Sprite(Color.White,sprite.Position,Dart,(float)(Math.PI),sprite.Origin,Vector2.One), 0.1f,new Vector2(sprite.Position.X - size + sprite.Origin.Y, sprite.Position.Y + sprite.Origin.Y)),
                new Bullet(new Sprite(Color.White,sprite.Position,Dart,(float)(5 * Math.PI/4),sprite.Origin,Vector2.One), 0.1f,new Vector2(sprite.Position.X - size + sprite.Origin.Y, sprite.Position.Y - size + sprite.Origin.Y)),
                new Bullet(new Sprite(Color.White,sprite.Position,Dart,(float)(3 * Math.PI/2),sprite.Origin,Vector2.One), 0.1f,new Vector2(sprite.Position.X + sprite.Origin.Y, sprite.Position.Y - size + sprite.Origin.Y)),
                new Bullet(new Sprite(Color.White,sprite.Position,Dart,(float)(7 * Math.PI/4),sprite.Origin,Vector2.One), 0.1f,new Vector2(sprite.Position.X + size  + sprite.Origin.Y, sprite.Position.Y - size + sprite.Origin.Y))
            };
        }
        void UpdateTargets()
        {
            Bullets[0].Target.X += 30;

            Bullets[1].Target.X += 30;
            Bullets[1].Target.Y += 30;

            Bullets[2].Target.Y += 30;

            Bullets[3].Target.X -= 30;
            Bullets[3].Target.Y += 30;

            Bullets[4].Target.X -= 30;

            Bullets[5].Target.X -= 30;
            Bullets[5].Target.Y -= 30;

            Bullets[6].Target.Y -= 30;

            Bullets[7].Target.X += 30;
            Bullets[7].Target.Y -= 30;

        }
        public bool IncreaseRangeByOne(ref int Money, int CostIncrement,Screen screen)
        {
            if (IncreaseRangeCostAndLvl.Item1 >= Money || IncreaseRangeCostAndLvl.Item2 == MaxUpgradeLvl) return false;
            RemoveCost += CostIncrement / 3;
            Money -= IncreaseRangeCostAndLvl.Item1;
            IncreaseRangeCostAndLvl.Item1 += CostIncrement;
            IncreaseRangeCostAndLvl.Item2++;
            RangeSize++;
            UpdateTargets();
            
            Position CurrentPos = new Position(GridPosition.X, GridPosition.Y);
            int indexX = 0;
            while (indexX < RangeSize && CurrentPos.X > 0)
            {
                CurrentPos.X--;
                indexX++;
            }
            int indexY = 0;
            while (indexY < RangeSize && CurrentPos.Y > 0)
            {
                CurrentPos.Y--;
                indexY++;
            }
            indexX += RangeSize + 1;
            indexY += RangeSize + 1;
            sbyte originalX = CurrentPos.X;
            for (int i = 0; i < indexY; i++)
            {
                for (int x = 0; x < indexX; x++)
                {
                    if (!RangeSquares.Contains(screen.Map[CurrentPos.Y, CurrentPos.X]))
                    {
                        RangeSquares.Add(screen.Map[CurrentPos.Y, CurrentPos.X]);

                    }
                    CurrentPos.X++;
                    if (CurrentPos.X == screen.Map.GetLength(0)) break;
                }
                CurrentPos.X = originalX;
                CurrentPos.Y++;
                if (CurrentPos.Y == screen.Map.GetLength(1)) break;
            }
            return true;
        }

        public override void Draw(SpriteBatch spriteB, GameTime gameTime, Screen screen)
        {
            if(ShouldFire)
            {
                for(int i = 0; i < Bullets.Length;i++)
                {
                    total += Bullets[i].Draw(spriteB, sprite.Position, DamageAndCostAndLvl.Item1,ref zombies,ref HasHitZombie);
                }
                if(total == Bullets.Length)
                {
                    total = 0;
                    ShouldFire = false;
                    foreach (var item in Bullets)
                    {
                        item.HasHit = false;
                    }
                }
            }
            sprite.Draw(spriteB);
        }

        public override bool Update(ref List<Zombie> zombie)
        {
            if (zombie == null || FiringTimer.ElapsedMilliseconds < CooldownAndCostAndLvl.Item1) return false;
            FiringTimer.Restart();
            ShouldFire = true;
            HasHitZombie.Clear();
            for(int i = 0;i < zombie.Count;i++) { HasHitZombie.Add(false); }
            zombies = zombie;
            return true;
        }
    }
}
