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
        Button EndButton;
        List<Sprite> Monkeys;
        List<float> LerpAmounts;
        float LerpIncrement = 0.002f;
        string EndScreenText = "";
        Texture2D pixel;
        public GameScreen(int height, ContentManager Content, int baseCash, int baseLives, int WidthofScreen,GraphicsDevice device)
        {
            Texture2D monkey = Content.Load<Texture2D>("DartMonkey");
            Monkeys = new List<Sprite>()
            {
                new Sprite(Color.White,new Vector2(0,50), monkey ,0, new Vector2((monkey.Width/2),(monkey.Height/2)),new Vector2(4,4)), 
                new Sprite(Color.White,new Vector2(0,220),monkey ,0, new Vector2((monkey.Width)/2,(monkey.Height)/2 ),new Vector2(4,4)),
                new Sprite(Color.White,new Vector2(0,390),monkey ,0, new Vector2((monkey.Width)/2,(monkey.Height)/2 ),new Vector2(4,4)),
                new Sprite(Color.White,new Vector2(0,560),monkey ,0, new Vector2((monkey.Width)/2,(monkey.Height)/2 ),new Vector2(4,4)),
                new Sprite(Color.White,new Vector2(0,730),monkey ,0, new Vector2((monkey.Width)/2,(monkey.Height)/2 ),new Vector2(4,4)),
            };
            pixel = new Texture2D(device,1,1);
            pixel.SetData(new Color[] { Color.Red });
            LerpAmounts = new List<float>()
            {
                0,
                0,
                0,
                0,
                0,
            };
            StartButton = new Button(new Sprite(Color.BlanchedAlmond, new Vector2(400, 500), Content.Load<Texture2D>("Button"), 0, Vector2.Zero, new Vector2(2, 2)), "Start Game", true);
            EndButton = new Button(new Sprite(Color.BlanchedAlmond, new Vector2(400, 300), Content.Load<Texture2D>("Button"),0, Vector2.Zero, new Vector2(2,2)),"End Game", false);
            Retry = new Button(new Sprite(Color.BlanchedAlmond, new Vector2(400, 450), Content.Load<Texture2D>("Button"), 0, Vector2.Zero, new Vector2(2, 2)), "Restart Game", false);
            RunStartOfGame = true;
            RunEndOfGame = false;
            screen = new Screen(height, sizeOfSquare, Content);
            RunGame = new RunGame(screen, Content, baseCash, baseLives, offSet);
        }
        public bool Run(ContentManager Content,int Width,int baseCash,int baseLives)
        {
            //Run Start Screen
            Vector2 MousePosition = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);

            if (RunStartOfGame)
            {
                Vector2 Target = new Vector2(Width + 75, Monkeys[0].Position.Y);
                for (int i = 0; i < Monkeys.Count; i++)
                {
                    Target.Y = Monkeys[i].Position.Y;
                    if (LerpAmounts[i] >= 1)
                    {
                        Monkeys[i].Position = new Vector2(0, Monkeys[i].Position.Y); 
                        LerpAmounts[i] = 0;
                    }
                    Monkeys[i].Rotation += (float)(Math.PI / 64);
                    if (Monkeys[i].Rotation >= 2*Math.PI)
                    {
                        Monkeys[i].Rotation = 0;
                    }

                    Monkeys[i].Position = Vector2.Lerp(new Vector2(-75, Monkeys[i].Position.Y), Target, LerpAmounts[i]);
                    LerpAmounts[i] += LerpIncrement;
                }
                if (StartButton.HasPressed(MousePosition))
                {
                    RunStartOfGame = false;
                    StartButton.CanClick = false;
                }
            }
            else if (!RunStartOfGame && !RunEndOfGame)
            {
                int x = RunGame.RunLevel(Content, screen, sizeOfSquare, offSet);
                if (x == 1)
                {
                    //run end of game screen

                    RunEndOfGame = true;
                    EndScreenText = "YOU WIN!!!!!";
                    EndButton.CanClick = true;
                    Retry.CanClick = true;
                }
                if (x == 2)
                {
                    //run end of game screen
                    RunEndOfGame = true;
                    EndButton.CanClick = true;
                    Retry.CanClick = true;
                    EndScreenText = "u Lose Bozo, u suck a s s";
                }
            }
            else if (RunEndOfGame)
            {
                Vector2 Target = new Vector2(Width + 75, Monkeys[0].Position.Y);
                for (int i = 0; i < Monkeys.Count; i++)
                {
                    Target.Y = Monkeys[i].Position.Y;
                    if (LerpAmounts[i] >= 1)
                    {
                        Monkeys[i].Position = new Vector2(0, Monkeys[i].Position.Y);
                        LerpAmounts[i] = 0;
                    }
                    Monkeys[i].Rotation += (float)(Math.PI / 64);
                    if (Monkeys[i].Rotation >= 2 * Math.PI)
                    {
                        Monkeys[i].Rotation = 0;
                    }

                    Monkeys[i].Position = Vector2.Lerp(new Vector2(-75, Monkeys[i].Position.Y), Target, LerpAmounts[i]);
                    LerpAmounts[i] += LerpIncrement;
                }
                if(EndButton.HasPressed(MousePosition))
                {
                    return false;
                }
                else if(Retry.HasPressed(MousePosition))
                {
                    RunGame = new RunGame(screen, Content, baseCash, baseLives, offSet);
                    RunEndOfGame = false;
                }
            }
            return true;
        }
        public void Draw(SpriteBatch sprite, ContentManager Content, GameTime gameTime)
        {
           
            if (RunStartOfGame)
            {
                foreach (var item in Monkeys)
                {
                    sprite.Draw(pixel, new Vector2(item.Position.X + item.Origin.X, item.Position.Y + item.Origin.Y), Color.Red);
                    item.Draw(sprite);
                }

                StartButton.DrawButton(sprite, Content, new Vector2(500, 525));
            }
            else if (!RunEndOfGame && !RunStartOfGame)
            {
                screen.DrawScreen(sprite);
                RunGame.DrawLevel(sprite, Content, gameTime, screen);
            }
            else if (RunEndOfGame)
            {
                foreach (var item in Monkeys)
                {
                    sprite.Draw(pixel, new Vector2(item.Position.X + item.Origin.X, item.Position.Y + item.Origin.Y), Color.Red);
                    item.Draw(sprite);
                }
                sprite.DrawString(Content.Load<SpriteFont>("File"),EndScreenText,new Vector2(75,100),Color.Red,0,Vector2.Zero,3,SpriteEffects.None,1);
                EndButton.DrawButton(sprite, Content, new Vector2(500, 325));
                Retry.DrawButton(sprite, Content, new Vector2(500, 475));
            }
        }
    }
}
