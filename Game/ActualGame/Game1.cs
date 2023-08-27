using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System.Collections.Generic;

namespace ActualGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        Screen screen;
        Level1 LevelOne;
        int sizeOfSquare = 30;
        int offSet = 4;
        bool HasPressedSpace = false;
        //Plan: CreateSideMenu, FinishUpLvl1 (Adjust Health), AddAllOtherMonkeys, Make next 30 levels, Add a win and lose screen
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            graphics.PreferredBackBufferWidth = 1010;
            graphics.PreferredBackBufferHeight = 810;
            graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            screen = new Screen(GraphicsDevice.Viewport.Height, sizeOfSquare, Content);
            LevelOne = new Level1(screen.Start,offSet,Content,500,screen);
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            
            // TODO: Add your update logic here
            LevelOne.UpdateLvlScreen(sizeOfSquare, screen,Content);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            GraphicsDevice.Clear(Color.BlanchedAlmond);
            screen.DrawScreen(spriteBatch);
            LevelOne.DrawLvlScreen(spriteBatch, Content);
            base.Draw(gameTime);
            spriteBatch.End();
        }
    }
}