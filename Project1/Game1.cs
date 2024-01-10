using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;
using SharpDX.Direct2D1;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;
using System.Drawing;
using Color = Microsoft.Xna.Framework.Color;
using Microsoft.VisualBasic;
using static System.Net.Mime.MediaTypeNames;

namespace MonogameGamesSource
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        GridDrawer gridDrawer;
        List<List<int>> grid;
        int gridHeight = 50;
        int gridWidth = 100;
        double updateInterval = 0.0; // Update every 1 second
        double timeSinceLastUpdate = 0.0;

        SpriteFont font;
        string text = "Generation: ";
        int generation = 0;
        Vector2 position = new Vector2(0, 0);

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1000;  // set this to the desired width
            _graphics.PreferredBackBufferHeight = 520; // set this to the desired height
            _graphics.ApplyChanges();
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            grid = new List<List<int>>();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            FillGrid(gridHeight, gridWidth);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            gridDrawer = new GridDrawer(GraphicsDevice);

            // Load the font in the LoadContent method
            font = Content.Load<SpriteFont>("NewFont");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                grid.Clear();
                FillGrid(gridHeight, gridWidth);
                generation = 0;
            }

            timeSinceLastUpdate += gameTime.ElapsedGameTime.TotalSeconds;
            if (timeSinceLastUpdate > updateInterval)
            {

                // TODO: Add your update logic here
                gridDrawer.UpdateBoard(grid, gridHeight, gridWidth);
                generation++;

                timeSinceLastUpdate -= updateInterval;
            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            _spriteBatch.DrawString(font, (text + generation), position, Color.Blue);
            gridDrawer.Draw(_spriteBatch, grid, 10);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public void FillGrid(int height, int width)
        {
            Random rnd = new Random();
            for (int i = 0; i < height; i++)
            {
                List<int> row = new List<int>();
                for (int j = 0; j < width; j++)
                {
                    // 33.33% chance of being alive
                    if (rnd.Next(0, 3) == 0)
                    {
                        row.Add(1);
                    }
                    else
                    {
                        row.Add(0);
                    }
                }
                grid.Add(row);
            }
        }
    }
}
