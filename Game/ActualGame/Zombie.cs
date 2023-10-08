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
    enum TypeOfZombie
    {
        Miner,
        Normal
    }
    internal abstract class Zombie : Sprite
    {
        public float LerpAmount;
        public float LerpIncrement;
        public Position[] Path;
        public int Health; 
        public int currentPosition;
        public bool HasLerpedOnce;
        public TypeOfZombie ZombieType;
        public Vector2 PreviousPosition;
        public int MaxFrozenTime;
        public Stopwatch FrozenTimer;

        public Zombie(Color tint, Vector2 position, Texture2D image, float rotation, Vector2 origin, Vector2 scale,float increment,TypeOfZombie typeOfZombie, int maxFrozenTime) 
            : base(tint, position, image, rotation, origin, scale)
        {
            MaxFrozenTime = maxFrozenTime;
            ZombieType = typeOfZombie;
            currentPosition = 0;
            LerpAmount = 0f;
            HasLerpedOnce = false;
            PreviousPosition = position;
            LerpIncrement = increment;
            FrozenTimer = new Stopwatch();
        }
        public abstract bool MoveEnemyAlongPathOnce(int SizeOfSquare, ref Screen screen);
    }
}
