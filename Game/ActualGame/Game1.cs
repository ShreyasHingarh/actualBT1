﻿using ActualGame.LevelClasses;
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
        GameScreen gameScreen;
        //Plan: darts more accurate, Add a win and lose screen (Alterating paths using astar,adjust all the prices and health)
        //
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
            gameScreen = new GameScreen(GraphicsDevice.Viewport.Height, Content, 800, 50,graphics.PreferredBackBufferWidth,GraphicsDevice);
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if(!gameScreen.Run(Content,graphics.PreferredBackBufferWidth,800,50))
            {
                Exit();
            }
            // TODO: Add your update logic here
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            GraphicsDevice.Clear(Color.BlanchedAlmond);
            gameScreen.Draw(spriteBatch,Content, gameTime);
            base.Draw(gameTime);
            spriteBatch.End();
        }
    }
}