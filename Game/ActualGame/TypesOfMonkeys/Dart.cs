using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActualGame.TypesOfMonkeys
{
    internal class Dart : Monkey
    {
        public Dart(Screen screen,Vector2 Position,ContentManager Content,Vector2 Origin,Position gridpos) : base(TypeOfMonkey.DartMonk)
        {
            GridPosition = gridpos;
            sprite = new Sprite(Color.White,Position,Content.Load<Texture2D>("Dart"),0,Origin,Vector2.One);
            RangeSquares = new List<ScreenSquare>()
            {
               screen.Map[gridpos.Y,gridpos.X],
               screen.Map[gridpos.Y + 1,gridpos.X],
               screen.Map[gridpos.Y - 1,gridpos.X],
               screen.Map[gridpos.Y,gridpos.X +1],
               screen.Map[gridpos.Y,gridpos.X - 1],
               screen.Map[gridpos.Y,gridpos.X],
               screen.Map[gridpos.Y,gridpos.X],
            };
            
        }

        public override void Draw()
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
