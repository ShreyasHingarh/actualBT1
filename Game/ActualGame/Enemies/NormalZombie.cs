using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Diagnostics;

namespace ActualGame.Enemies
{
    internal class NormalZombie : Zombie
    {
        static Dictionary<int, Color> LevelToTintColor = new Dictionary<int, Color>()
        {
            { 0,Color.White },
            { 1,Color.DarkGreen },
            { 2,Color.Blue },
            { 3,Color.Orange },
            { 4,Color.Yellow },
            { 5,Color.Red },
            { 6, Color.Purple},
            { 7, Color.White }
        };
        public Dictionary<int, int> LevelToHealth = new Dictionary<int, int>()
        {
            {0, 5},
            {1, 5},
            {2, 10},
            {3, 10},
            {4, 15},
            {5, 20},
            {6, 50},
            {7, 100}
        };
        public Dictionary<int, int> LevelToReward = new Dictionary<int, int>()
        {
            {0, 5},
            {1, 5},
            {2, 5},
            {3, 10},
            {4, 10},
            {5, 15},
            {6, 40},
            {7, 80}
        };
        
        public int Level;
        

        Texture2D OriginalZombieImage;
        public NormalZombie(int level, Vector2 position, Texture2D image, float rotation, Vector2 origin, Vector2 scale, Position[] locations, bool isAFastZombie,int maxFrozenTime)
            : base(LevelToTintColor[level], position, image, rotation, origin, scale,0.04f, TypeOfZombie.Normal,maxFrozenTime)
        {
            OriginalZombieImage = image;
            Level = level;
            Path = locations.Reverse().ToArray();
            Health = LevelToHealth[level];
            
            if (isAFastZombie)
            {
                LerpIncrement *= 2;
            }
            if (Level == 7)
            {
                Scale = new Vector2(2.5f, 2.5f);
            }
            else if (Level == 6)
            {
                Scale = new Vector2(1.5f, 1.5f);
            }
        }
        public void UpdateLevel()
        {
            Level--;
            Tint = LevelToTintColor[Level];
            Health = LevelToHealth[Level];
            switch (Level)
            {
                case 6:
                    Scale = new Vector2(1.5f, 1.5f);
                    break;
                case 5:
                    Scale = Vector2.One;
                    break;
            }
        }
        public override bool MoveEnemyAlongPathOnce(int SizeOfSquare, ref Screen screen)
        {
            if (currentPosition + 1 == Path.Length) return false;
            if (FrozenTimer.ElapsedMilliseconds >= MaxFrozenTime)
            {
                FrozenTimer.Reset();
                LerpIncrement *= 2;
                Image = OriginalZombieImage;
            }
            Position NextSquare = Path[currentPosition + 1];

            screen.Map[Path[currentPosition].Y, Path[currentPosition].X].Value.DoesContainZombie = true;
            if (!screen.Map[Path[currentPosition].Y, Path[currentPosition].X].Value.OneContained.Contains(this))
            {
                screen.Map[Path[currentPosition].Y, Path[currentPosition].X].Value.OneContained.Add(this);
            }
            if (LerpAmount < 1f)
            {
                Position = Vector2.Lerp(PreviousPosition, new Vector2(NextSquare.X * SizeOfSquare + 15, NextSquare.Y * SizeOfSquare + 15), LerpAmount);
                LerpAmount += LerpIncrement;
                return true;
            }
           
            screen.Map[Path[currentPosition].Y, Path[currentPosition].X].Value.OneContained.Remove(this);
            if(screen.Map[Path[currentPosition].Y, Path[currentPosition].X].Value.OneContained.Count == 0)
            {
                screen.Map[Path[currentPosition].Y, Path[currentPosition].X].Value.DoesContainZombie = false;
            }
            currentPosition += 1;
            LerpAmount = 0f;
            HasLerpedOnce = true;
            PreviousPosition = Position;
            return true;
        }
    }
}
