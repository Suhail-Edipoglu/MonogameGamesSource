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
using MonogameGamesSource.Game2source;

namespace MonogameGamesSource
{
    namespace Game2
    {
        public class Game2 : Game
        {
            private GraphicsDeviceManager _graphics;
            private SpriteBatch _spriteBatch;
            double updateInterval = 0.0; // Update every 1 second
            double timeSinceLastUpdate = 0.0;

            SpriteFont font;
            string text = "Welcome: ";
            Vector2 position = new Vector2(0, 0);

            GridDrawer gridDrawer;
            List<List<int>> grid;
            int gridHeight = 70;
            int gridWidth = 150;

            public Game2()
            {
                _graphics = new GraphicsDeviceManager(this);
                _graphics.PreferredBackBufferWidth = 1500;  // set this to the desired width
                _graphics.PreferredBackBufferHeight = 720; // set this to the desired height
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
                    
                }

                timeSinceLastUpdate += gameTime.ElapsedGameTime.TotalSeconds;
                if (timeSinceLastUpdate > updateInterval)
                {

                    // TODO: Add your update logic here
                    

                    timeSinceLastUpdate -= updateInterval;
                }


                base.Update(gameTime);
            }

            protected override void Draw(GameTime gameTime)
            {
                GraphicsDevice.Clear(Color.Gray);

                // TODO: Add your drawing code here
                _spriteBatch.Begin();

                _spriteBatch.DrawString(font, text, position, Color.Blue);
                gridDrawer.Draw(_spriteBatch, grid, 10);

                _spriteBatch.End();

                base.Draw(gameTime);
            }

            public void FillGrid(int height, int width)
            {
                Random rnd = new Random();
                grid = new List<List<int>>();
                for (int i = 0; i < height; i++)
                {
                    grid.Add(new List<int>());
                    for (int j = 0; j < width; j++)
                    {
                        grid[i].Add(0); // Initialize all elements to 0
                    }
                }

                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        if ((i == 0) || (j == 0) || (i == (height - 1)) || (j == (width - 1)))
                        {
                            grid[i][j] = 3;
                        }
                        else if (((i % 2) == 0) || ((j % 2) == 0))
                        {
                            if (rnd.Next(0, 2) == 0)
                            {
                                grid[i][j] = rnd.Next(4, 10);
                            }
                            else if (rnd.Next(0, 2) == 1)
                            {
                                grid[i][j] =rnd.Next(0, 3);
                            }
                        }
                        else
                        {
                            grid[i][j] = 10;
                        }
                    }
                }
            }
        }
    }
}
