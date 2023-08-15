using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ActualGame
{
    internal class Zombie : Sprite
    {
        /*
         Color.White = lvl 1;
           
         */
        static Dictionary<int, Color> LevelToTintColor = new Dictionary<int, Color>()
        {
            { 0,Color.White },
            { 1,Color.Red },
            { 2,Color.Blue },
            { 3,Color.Orange },
        };
        float LerpAmount;
        float LerpIncrement;
        Position[] Location;
        public int Health;
        int currentPosition;
        public bool HasLerpedOnce;
        public Zombie(int level, Vector2 position, Texture2D image, float rotation, Vector2 origin, Vector2 scale,int health, Position[] locations,Rectangle? sourceRec = null) 
            : base(LevelToTintColor.GetValueOrDefault(level), position, image, rotation, origin, scale, sourceRec)
        {
            HasLerpedOnce = false;
            Location = locations.Reverse().ToArray();
            Health = health;
            currentPosition = 0;
            LerpAmount = 0f;
            LerpIncrement = 0.02f;
        }
        public bool MoveEnemyAlongPathOnce(int SizeOfSquare, int offSet)
        {
            if (currentPosition + 1 == Location.Length) return false;
            Position NextSquare = Location[currentPosition+1];
            if (LerpAmount < 1f)
            {
                Position = Vector2.Lerp(Position, new Vector2(NextSquare.X * SizeOfSquare + offSet, NextSquare.Y * SizeOfSquare + offSet), LerpAmount);
                LerpAmount += LerpIncrement;
                return true;
            }
            currentPosition += 1;
            LerpAmount = 0f;
            HasLerpedOnce = true;
            return true;
        }
    }
}
