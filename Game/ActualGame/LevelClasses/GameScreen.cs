using ActualGame.ScreenAndGraph;
using ActualGame.Sprites;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ActualGame.LevelClasses
{
    internal class GameScreen
    {
        RunGame RunGame;
        public Screen screen;
        int sizeOfSquare = 30;
        int offSet = 4;
        bool RunStartOfGame;
        bool RunEndOfGame;
        Button StartButton;
        Button Retry;
        bool EndByWin = false;
        bool EndByLose = false;
        Button EndButton;
        List<Sprite> Monkeys;
        List<float> LerpAmounts;
        float LerpIncrement = 0.01f;
        public GameScreen(int height, ContentManager Content, int baseCash, int baseLives, int WidthofScreen)
        {
            Monkeys = new List<Sprite>()
            {
                new Sprite(Color.White,new Vector2(WidthofScreen,65),Content.Load<Texture2D>("DartMonkey"),0,new Vector2 (  0,0),new Vector2(4,4)), 
                new Sprite(Color.White,new Vector2(WidthofScreen,235),Content.Load<Texture2D>("DartMonkey"),0,new Vector2(  0,0),new Vector2(4,4)),
                new Sprite(Color.White,new Vector2(WidthofScreen,405),Content.Load<Texture2D>("DartMonkey"),0,new Vector2(  0,0),new Vector2(4,4)),
                new Sprite(Color.White,new Vector2(WidthofScreen,575),Content.Load<Texture2D>("DartMonkey"),0,new Vector2(  0,0),new Vector2(4,4)),
                new Sprite(Color.White,new Vector2(WidthofScreen,745),Content.Load<Texture2D>("DartMonkey"),0,new Vector2(  0,0),new Vector2(4,4)),
            };
            LerpAmounts = new List<float>()
            {
                0,
                0,
                0,
                0,
                0,
            };
            StartButton = new Button(new Sprite(Color.BlanchedAlmond, new Vector2(400, 500), Content.Load<Texture2D>("Button"), 0, Vector2.Zero, new Vector2(2, 2)), "Start Game", true);
            //EndButton = ;
            //Retry = ;
            RunStartOfGame = true;
            RunEndOfGame = false;
            screen = new Screen(height, sizeOfSquare, Content);
            RunGame = new RunGame(screen, Content, baseCash, baseLives, offSet);
        }
        public void Run(ContentManager Content,int Width)
        {
            //Run Start Screen
            Vector2 MousePosition = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);

            if (RunStartOfGame)
            {
                for (int i = 0; i < Monkeys.Count; i++)
                {
                    if (LerpAmounts[i] >= 1)
                    {
                        Monkeys[i].Position = new Vector2(Width, Monkeys[i].Position.Y);
                        LerpAmounts[i] = 0;
                    }
                    //Monkeys[i].Rotation += (float)(Math.PI / 32);
                    if (Monkeys[i].Rotation >= 2*Math.PI)
                    {
                        Monkeys[i].Rotation = 0;
                    }
                    Vector2.Lerp(Monkeys[i].Position, new Vector2(0, Monkeys[i].Position.Y), LerpAmounts[i]);
                    LerpAmounts[i] += LerpIncrement;
                }
                if (StartButton.HasPressed(MousePosition))
                {
                    RunStartOfGame = false;
                }
            }
            else if (!RunStartOfGame && !RunEndOfGame)
            {
                int x = RunGame.RunLevel(Content, screen, sizeOfSquare, offSet);
                if (x == 1)
                {
                    //run end of game screen
                    RunEndOfGame = true;
                    EndByWin = true;
                }
                if (x == 2)
                {
                    //run end of game screen
                    RunEndOfGame = true;
                    EndByLose = true;
                }
            }
            else if (RunEndOfGame)
            {

            }
        }
        public void Draw(SpriteBatch sprite, ContentManager Content, GameTime gameTime)
        {
            if (RunStartOfGame)
            {
                foreach (var item in Monkeys)
                {
                    item.Draw(sprite);
                }

                StartButton.DrawButton(sprite, Content, new Vector2(500, 500));
            }
            else if (!RunEndOfGame && !RunStartOfGame)
            {
                screen.DrawScreen(sprite);
                RunGame.DrawLevel(sprite, Content, gameTime, screen);
            }
            else if (RunEndOfGame)
            {

            }
        }
    }
}
