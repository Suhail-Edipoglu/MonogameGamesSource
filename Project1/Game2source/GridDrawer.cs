using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Threading;

namespace MonogameGamesSource.Game2source
{
    public class GridDrawer
    {
        private Texture2D pixel;
        private GraphicsDevice graphicsDevice;

        public GridDrawer(GraphicsDevice graphicsDevice)
        {
            this.graphicsDevice = graphicsDevice;
            pixel = new Texture2D(graphicsDevice, 1, 1);
            pixel.SetData(new[] { Color.White });
        }

        public void Draw(SpriteBatch spriteBatch, List<List<int>> grid, int cellSize)
        {
            for (int y = 0; y < grid.Count; y++)
            {
                for (int x = 0; x < grid[y].Count; x++)
                {
                    var position = new Vector2(x * cellSize, y * cellSize);
                    var rectangle = new Rectangle((int)position.X, (int)position.Y + 20, cellSize, cellSize);
                    if (grid[y][x] == 0)
                    {
                        spriteBatch.Draw(pixel, rectangle, Color.Black);
                    }
                    else if (grid[y][x] == 1)
                    {
                        spriteBatch.Draw(pixel, rectangle, Color.White);
                    }
                    else if (grid[y][x] == 2)
                    {
                        spriteBatch.Draw(pixel, rectangle, Color.Red);
                    }
                    else if (grid[y][x] == 3)
                    {
                        spriteBatch.Draw(pixel, rectangle, Color.Blue);
                    }
                    else if (grid[y][x] == 4)
                    {
                        spriteBatch.Draw(pixel, rectangle, Color.Green);
                    }
                    else if (grid[y][x] == 5)
                    {
                        spriteBatch.Draw(pixel, rectangle, Color.Yellow);
                    }
                    else if (grid[y][x] == 6)
                    {
                        spriteBatch.Draw(pixel, rectangle, Color.Pink);
                    }
                    else if (grid[y][x] == 7)
                    {
                        spriteBatch.Draw(pixel, rectangle, Color.Violet);
                    }
                    else if (grid[y][x] == 8)
                    {
                        spriteBatch.Draw(pixel, rectangle, Color.Orange);
                    }
                    else if (grid[y][x] == 9)
                    {
                        spriteBatch.Draw(pixel, rectangle, Color.YellowGreen);
                    }
                    else
                    {
                        spriteBatch.Draw(pixel, rectangle, Color.Gray);
                    }
                }
            }
        }
    }
}
