using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapEditor
{
    public enum Draw
    {
        Eraser = 0,
        Start = 1,
        End = 2,
        Path = 3
    }
    public class Position
    {
        public int X;
        public int Y;
        public Position(int x,int y)
        {
            X = x;
            Y = y;
        }
    }
    public class Square
    {
        public Position location;
        public bool IsWall;
        public PictureBox Picture;
        public Draw Type;
        public Square(int x, int y) 
        {
            location = new Position(x,y);
            IsWall = false;
            Picture = new PictureBox();
            Type = Draw.Eraser;
        }
    }
}
