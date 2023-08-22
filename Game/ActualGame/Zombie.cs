﻿using Microsoft.Xna.Framework;
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
        static Dictionary<int, Color> LevelToTintColor = new Dictionary<int, Color>()
        {
            { 0,Color.White },
            { 1,Color.DarkGreen },
            { 2,Color.Blue },
            { 3,Color.Orange },
        };
        float LerpAmount;
        public int Level;
        public float LerpIncrement;

        Position[] Path;
        public int Health;
        int currentPosition;
        public bool HasLerpedOnce;
        Vector2 PreviousPosition;
        public Zombie(int level, Vector2 position, Texture2D image, float rotation, Vector2 origin, Vector2 scale,int health, Position[] locations,Rectangle? sourceRec = null) 
            : base(LevelToTintColor.GetValueOrDefault(level), position, image, rotation, origin, scale, sourceRec)
        {
            Level = level;
            HasLerpedOnce = false;
            Path = locations.Reverse().ToArray();
            Health = health;
            currentPosition = 0;
            LerpAmount = 0f;
            LerpIncrement = 0.02f;
            PreviousPosition = Position;
        }
        public bool MoveEnemyAlongPathOnce(int SizeOfSquare, int offSet, Screen screen)
        {
            if (currentPosition + 1 == Path.Length) return false;
            Position NextSquare = Path[currentPosition+1];
            if (LerpAmount < 1f)
            {
                Position = Vector2.Lerp(PreviousPosition, new Vector2(NextSquare.X * SizeOfSquare + offSet, NextSquare.Y * SizeOfSquare + offSet), LerpAmount);
                LerpAmount += LerpIncrement;
                return true;
            }
            screen.Map[Path[currentPosition].Y, Path[currentPosition].X].DoesContainZombie = false;
            screen.Map[Path[currentPosition].Y, Path[currentPosition].X].OneContained = null;
            currentPosition += 1;
            screen.Map[Path[currentPosition].Y, Path[currentPosition].X].DoesContainZombie = true;
            screen.Map[Path[currentPosition].Y, Path[currentPosition].X].OneContained = this;
            LerpAmount = 0f;
            HasLerpedOnce = true;
            PreviousPosition = Position;
            return true;
        }
    }
}