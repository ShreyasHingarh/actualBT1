using ActualGame.Enemies;
using ActualGame.ScreenAndGraph;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ActualGame.Sprites;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

using static System.Reflection.Metadata.BlobBuilder;

namespace ActualGame.TypesOfMonkeys
{
    internal class Bomb : Monkey
    {
        Texture2D MonkeyWithBomb;
        Texture2D MonkeyWithNoBomb;
        public ActualBomb TheBomb1;
        public ActualBomb TheBomb2; 

        List<Zombie> Targets;
        bool HasLerped = false;
        public (int,int) UpgradeCostandLevel;
        public float LerpIncrement = 0.1f;
        float LerpAmount = 0;
        bool WhichBomb = false;
        public int OneToCompare;
        public int Bomb2CoolDown = 500;
        public Bomb(Screen screen, int baseRange, int baseDamage, int baseDamageUpgradeCost, 
            int baseCooldown, int baseCooldownUpgradeCost, int MaxLvl, int addCost, ContentManager Content,Vector2 Position, Vector2 Origin) 
            : base(screen, TypeOfMonkey.BombMonk, new Position(-1, -1), baseRange, baseDamage, baseDamageUpgradeCost, baseCooldown, baseCooldownUpgradeCost, MaxLvl, addCost)
        {
            OneToCompare = CooldownAndCostAndLvl.Item1;
            UpgradeCostandLevel = (200,0);
            RemoveCost = 200;
            TheBomb1 = new ActualBomb(Color.White, Position, Content.Load<Texture2D>("Bomb"), 0, Vector2.Zero, Vector2.One);
            MonkeyWithBomb = Content.Load<Texture2D>("BombMonkey");
            MonkeyWithNoBomb = Content.Load<Texture2D>("NoBombMonkey");
            sprite = new Sprite(Color.White,Position,MonkeyWithBomb,0,Origin,Vector2.One);
        }
        
        public override void Draw(SpriteBatch spriteB,GameTime gameTime,Screen screen)
        {
            if (ShouldFire)
            {
                ActualBomb bomb = TheBomb1;
                
                if(TheBomb2 != null && WhichBomb)
                {
                    bomb = TheBomb2;
                    OneToCompare = Bomb2CoolDown;
                }
                else
                {
                    OneToCompare = CooldownAndCostAndLvl.Item1;
                }
                bomb.DrawBomb(spriteB);
                if (!HasLerped)
                {
                    if (LerpAmount < 1)
                    {
                        bomb.Position = Vector2.Lerp(bomb.Position, new Vector2(Targets[0].Position.X + Targets[0].Origin.X, Targets[0].Position.Y + Targets[0].Origin.Y), LerpAmount);
                        LerpAmount += LerpIncrement;
                    }
                    else
                    {
                        LerpAmount = 0;
                        bomb.stopwatch = TimeSpan.Zero;
                        bomb.GridPosition = new Position((sbyte)(Targets[0].Position.X / 30), (sbyte)(Targets[0].Position.Y / 30));
                        bomb.BombRange.Clear();
                        bomb.AddRange(screen);
                        bomb.Scale = new Vector2(2f, 2f);
                        HasLerped = true;
                    }
                }
                else if (bomb.UpdateBomb(gameTime))
                {
                    bomb.Scale = Vector2.One;
                    ShouldFire = false;
                    foreach (var square in bomb.BombRange)
                    {
                        if (!square.DoesContainZombie) continue;
                        foreach(var zombie in square.OneContained)
                        {
                            zombie.Health -= DamageAndCostAndLvl.Item1;
                        }
                    }
                    WhichBomb = !WhichBomb;
                    bomb.Position = sprite.Position;
                }
            }
        
            sprite.Draw(spriteB);
        }
        public bool IncreaseRangeOfBomb(ref int Money, int CostIncrement, Screen screen,ContentManager Content)
        {
            if (UpgradeCostandLevel.Item1 >= Money || UpgradeCostandLevel.Item2 == MaxUpgradeLvl) return false;
            RemoveCost += CostIncrement / 3;
            Money -= UpgradeCostandLevel.Item1;
            UpgradeCostandLevel.Item1 += CostIncrement;

            RangeSize++;
            switch (UpgradeCostandLevel.Item2)
            {
                case 0:// increase bomb size by 1
                    TheBomb1.RangeSize = 2;
                    break;
                case 1:// increase bomb count by 1
                    TheBomb2 = new ActualBomb(Color.White, sprite.Position, Content.Load<Texture2D>("Bomb"), 0, Vector2.Zero, Vector2.One);
                    break;
                case 2:// increase bomb2 size by 1
                    TheBomb2.RangeSize = 2;
                    break;
            }
            UpgradeCostandLevel.Item2++;

            return true;
        }
        public override bool Update(ref List<Zombie> Zombies, bool IsFast)
        {
            sprite.Rotation = (float)(Math.Atan2(Zombies[0].Position.Y - sprite.Position.Y, Zombies[0].Position.X - sprite.Position.X));
            if (Zombies == null || FiringTimer.ElapsedMilliseconds < OneToCompare) return false;
            
            FiringTimer.Restart();
            Targets = Zombies;
            ShouldFire = true;
            HasLerped = false;
            sprite.Image = MonkeyWithNoBomb;
            return true;
        }
    }
}
