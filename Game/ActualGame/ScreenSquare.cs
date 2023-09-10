using Microsoft.Xna.Framework;

using System;
using System.Collections.Generic;
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
        public Sprite Sprite;
        public bool DoesContainZombie;
        public Zombie OneContained;
        //public ref struct OneContained
        //{
        //    Zombie it;
        //}

        public ScreenSquare(Sprite sprite,TypeOfImage type, Position location)
        {
            DoesContainZombie = false;
            Type = type;
            GridLocation = location;
            Sprite = sprite;
        }
    }
}
