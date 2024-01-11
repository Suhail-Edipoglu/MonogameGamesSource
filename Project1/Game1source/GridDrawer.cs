using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Threading;

namespace MonogameGamesSource.Game1source
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
                }
            }
        }

        public void UpdateBoard(List<List<int>> boardlist, int height, int width)
        {
            int neighbours;
            List<List<int>> newBoard = new List<List<int>>();
            List<List<int>> neighbourcount = new List<List<int>>();

            // fill neighbourcount list with 0
            for (int i = 0; i < height; i++)
            {
                List<int> row = new List<int>();
                for (int j = 0; j < width; j++)
                {
                    row.Add(0);
                }
                neighbourcount.Add(row);
            }

            // fill newBoard with 0
            for (int i = 0; i < height; i++)
            {
                List<int> row = new List<int>();
                for (int j = 0; j < width; j++)
                {
                    row.Add(0);
                }
                newBoard.Add(row);
            }

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    neighbours = 0;
                    if ((i == 0) && (j == 0))
                    {
                        if (boardlist[i + 1][j] == 1)
                        { neighbours++; }
                        if (boardlist[i][j + 1] == 1)
                        { neighbours++; }
                        if (boardlist[i + 1][j + 1] == 1)
                        { neighbours++; }

                        neighbourcount[i][j] = neighbours;
                    }
                    else if ((i == (height - 1)) && (j == 0))
                    {
                        if (boardlist[i - 1][j] == 1)
                        { neighbours++; }
                        if (boardlist[i][j + 1] == 1)
                        { neighbours++; }
                        if (boardlist[i - 1][j + 1] == 1)
                        { neighbours++; }

                        neighbourcount[i][j] = neighbours;
                    }
                    else if ((i == (height - 1)) && (j == (width - 1)))
                    {
                        if (boardlist[i - 1][j] == 1)
                        { neighbours++; }
                        if (boardlist[i][j - 1] == 1)
                        { neighbours++; }
                        if (boardlist[i - 1][j - 1] == 1)
                        { neighbours++; }

                        neighbourcount[i][j] = neighbours;
                    }
                    else if ((i == 0) && (j == (width - 1)))
                    {
                        if (boardlist[i + 1][j] == 1)
                        { neighbours++; }
                        if (boardlist[i][j - 1] == 1)
                        { neighbours++; }
                        if (boardlist[i + 1][j - 1] == 1)
                        { neighbours++; }

                        neighbourcount[i][j] = neighbours;
                    }
                    else if ((i != 0) && (i != (height - 1)) && (j == 0))
                    {
                        if (boardlist[i - 1][j] == 1)
                        { neighbours++; }
                        if (boardlist[i - 1][j + 1] == 1)
                        { neighbours++; }
                        if (boardlist[i][j + 1] == 1)
                        { neighbours++; }
                        if (boardlist[i + 1][j + 1] == 1)
                        { neighbours++; }
                        if (boardlist[i + 1][j] == 1)
                        { neighbours++; }

                        neighbourcount[i][j] = neighbours;
                    }
                    else if ((i == (height - 1)) && (j != 0) && (j != (width - 1)))
                    {
                        if (boardlist[i][j - 1] == 1)
                        { neighbours++; }
                        if (boardlist[i - 1][j - 1] == 1)
                        { neighbours++; }
                        if (boardlist[i - 1][j] == 1)
                        { neighbours++; }
                        if (boardlist[i - 1][j + 1] == 1)
                        { neighbours++; }
                        if (boardlist[i][j + 1] == 1)
                        { neighbours++; }

                        neighbourcount[i][j] = neighbours;
                    }
                    else if ((i != 0) && (i != (height - 1)) && (j == (width - 1)))
                    {
                        if (boardlist[i + 1][j] == 1)
                        { neighbours++; }
                        if (boardlist[i + 1][j - 1] == 1)
                        { neighbours++; }
                        if (boardlist[i][j - 1] == 1)
                        { neighbours++; }
                        if (boardlist[i - 1][j - 1] == 1)
                        { neighbours++; }
                        if (boardlist[i - 1][j] == 1)
                        { neighbours++; }

                        neighbourcount[i][j] = neighbours;
                    }
                    else if ((i == 0) && (j != 0) && (j != (width - 1)))
                    {
                        if (boardlist[i][j - 1] == 1)
                        { neighbours++; }
                        if (boardlist[i + 1][j - 1] == 1)
                        { neighbours++; }
                        if (boardlist[i + 1][j] == 1)
                        { neighbours++; }
                        if (boardlist[i + 1][j + 1] == 1)
                        { neighbours++; }
                        if (boardlist[i][j + 1] == 1)
                        { neighbours++; }

                        neighbourcount[i][j] = neighbours;
                    }
                    else
                    {
                        if (boardlist[i][j - 1] == 1)
                        { neighbours++; }
                        if (boardlist[i + 1][j - 1] == 1)
                        { neighbours++; }
                        if (boardlist[i + 1][j] == 1)
                        { neighbours++; }
                        if (boardlist[i + 1][j + 1] == 1)
                        { neighbours++; }
                        if (boardlist[i][j + 1] == 1)
                        { neighbours++; }
                        if (boardlist[i - 1][j + 1] == 1)
                        { neighbours++; }
                        if (boardlist[i - 1][j] == 1)
                        { neighbours++; }
                        if (boardlist[i - 1][j - 1] == 1)
                        { neighbours++; }

                        neighbourcount[i][j] = neighbours;
                    }
                }
            }

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if ((boardlist[i][j] == 0) && (neighbourcount[i][j] == 3))
                    {
                        newBoard[i][j] = 1;
                    }
                    else if ((boardlist[i][j] == 1) && (neighbourcount[i][j] < 2))
                    {
                        newBoard[i][j] = 0;
                    }
                    else if ((boardlist[i][j] == 1) && ((neighbourcount[i][j] == 2) || (neighbourcount[i][j] == 3)))
                    {
                        newBoard[i][j] = 1;
                    }
                    else if ((boardlist[i][j] == 1) && (neighbourcount[i][j] > 3))
                    {
                        newBoard[i][j] = 0;
                    }
                    else
                    {
                        newBoard[i][j] = boardlist[i][j];
                    }


                }
            }

            // replace boardlist with newboard and clear newboard
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    boardlist[i][j] = newBoard[i][j];
                }
            }
        }
    }
}
