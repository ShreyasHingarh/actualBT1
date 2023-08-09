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
    public class Square
    {
        public PictureBox Picture;
        public Draw Type;
        public Square() 
        {
            Picture = new PictureBox();
            Type = Draw.Eraser;
        }
    }
}
