using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActualGame
{
    internal class ActualBomb : AnimatedSpriteClass
    {
        public List<ScreenSquare> BombRange;
        public Position GridPosition;
        public ActualBomb(Color tint, Vector2 position, Texture2D image, float rotation, Vector2 origin, Vector2 scale)
            : base(tint, position, image, rotation, origin, scale)
        {
            BombRange = new List<ScreenSquare>();
            Frames = new List<Frames>()
            {
                new Frames(1,0,11,14,  new Vector2(5,7)),
                new Frames(14,1,11,13, new Vector2(5,6)),
                new Frames(27,2,11,12, new Vector2(5,6)),
                new Frames(44,1,19,17, new Vector2(9,8)),
                new Frames(4,22,22,20, new Vector2(11,10)),
                new Frames(37,26,15,16,new Vector2(7,8)),
                new Frames(5,48,11,13, new Vector2(5,6)),
                new Frames(24,49,9,9,  new Vector2(4,4)),
                new Frames(42,51,5,5,  new Vector2(2,2)),
                new Frames(55,53,2,2,  new Vector2(1,1)),
                new Frames(15,64,2,2,  new Vector2(1,1)),
                new Frames(29,64,1,1,  new Vector2(0,0)),
            };
        }
        public void AddRange(Screen screen,int RangeSize)
        {
            if (GridPosition.X == -1 && GridPosition.Y == -1) return;
            //Make it a diamond range.
            /*
             * if (GridPosition.X == -1 && GridPosition.Y == -1) return;
            Position CurrentPosition = new Position(GridPosition.X, GridPosition.Y);
            ScreenSquare Current = screen.Map[GridPosition.Y,GridPosition.X];
            Stack<ScreenSquare> screenSquares = new Stack<ScreenSquare>();
            screenSquares.Push(Current);
            List<ScreenSquare> OnesToAdd = new List<ScreenSquare>();
            int currentSize = 0;
            //Create the 
            while(screenSquares != null && currentSize <= RangeSize)
            {

            }
             */
            Position CurrentPos = new Position(GridPosition.X, GridPosition.Y);
            //Gets Top Left
            int indexX = 0;
            while (indexX < RangeSize && CurrentPos.X > 0)
            {
                CurrentPos.X--;
                indexX++;
            }
            int indexY = 0;
            while (indexY < RangeSize && CurrentPos.Y > 0)
            {
                CurrentPos.Y--;
                indexY++;
            }
            indexX += RangeSize + 1;
            indexY += RangeSize + 1;
            sbyte originalX = CurrentPos.X;
            for (int i = 0; i < indexY; i++)
            {
                for (int x = 0; x < indexX; x++)
                {
                    BombRange.Add(screen.Map[CurrentPos.Y, CurrentPos.X]);
                    CurrentPos.X++;
                    if (CurrentPos.X == screen.Map.GetLength(0)) break;
                }
                CurrentPos.X = originalX;
                CurrentPos.Y++;
                if (CurrentPos.Y == screen.Map.GetLength(1)) break;
            }
        }
        public bool UpdateBomb(GameTime gameTime)
        {
            return UpdateAnimationFrame(gameTime);
        }
        public void DrawBomb(SpriteBatch spriteBatch)
        {
            DrawAnimation(spriteBatch);
        }
    }
}
