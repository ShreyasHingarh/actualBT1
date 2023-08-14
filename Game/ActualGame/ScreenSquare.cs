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
        public Vector2 GridLocation;
        public Sprite Sprite;
        public ScreenSquare(Sprite sprite,TypeOfImage type, Vector2 location)
        {
            Type = type;
            GridLocation = location;
            Sprite = sprite;
        }
    }
}
