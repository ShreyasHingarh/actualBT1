using ActualGame.Enemies;
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
    enum TypeOfImage
    {
        Grass,
        Path,
        Start,
        End
    }
    internal class ScreenSquare
    {
        public TypeOfImage Type;
        public Position GridLocation;
        Texture2D Path;
        public Sprite Sprite;
        public bool DoesContainZombie;
        public List<Zombie> OneContained;
        public bool IsWall;
        public bool ShouldStartBeingPath;
        bool HasStarted;
        Stopwatch stopwatch;
        int timeToStayAsPath;
        public ScreenSquare(Sprite sprite,TypeOfImage type, Position location,Texture2D path)
        {
            Path = path;
            timeToStayAsPath = 2000;
            HasStarted = false;
            stopwatch = new Stopwatch();
            OneContained = new List<Zombie>();
            DoesContainZombie = false;
            Type = type;
            GridLocation = location;
            Sprite = sprite;
        }
        public void CheckShouldBePath()
        {
            if (!ShouldStartBeingPath) return;
            if (!HasStarted)
            {
                stopwatch.Restart();
                HasStarted = true;
                Texture2D temp = Sprite.Image;
                Sprite.Image = Path;
                Path = temp;
            }
            else if(stopwatch.ElapsedMilliseconds >= timeToStayAsPath)
            {
                Texture2D temp = Sprite.Image;
                Sprite.Image = Path;
                Path = temp;
                HasStarted = false;
                ShouldStartBeingPath = false;
            }
        }
    }
}
