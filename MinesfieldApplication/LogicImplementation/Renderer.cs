using System;
using System.Collections.Generic;
using System.Text;
using MinesfieldApplication.Interfaces;

namespace MinesfieldApplication.LogicImplementation
{
    public class Renderer : IRenderer
    {
        public void Clear()
        {
            Console.Clear();
        }

        public void DrawCurrentPos(IBlock currentTile)
        {
            Console.WriteLine($" your Current position: {currentTile.GetId()}");
        }

        public void DrawFinalScore(int score)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(" *********Congratulations!********");
            Console.WriteLine(" You reached the end of the game with lives left");
            Console.WriteLine($" Final Score (moves taken): {score}");
            Console.WriteLine(" Press Enter to play again, or Escape to exit");
        }

        public void DrawGameOver()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(" ***GAME OVER!***");
            Console.WriteLine(" You have ran out of lives!");
            Console.WriteLine(" Press Enter to play again, or Escape to exit");
        }

        public void DrawGrid(IBlock[,] blocks, IBlock currentTile, IBlock finishTile)
        {
            Console.CursorVisible = false;

            var width = blocks.GetLength(0);
            var height = blocks.GetLength(1) - 1;

            Console.WriteLine();

            for (var y = height; y >= 0; y--)
            {
                Console.Write(" ");
                Console.Write(blocks[0, y].GetYFlag());
                Console.Write(" ");
                for (var x = 0; x < width; x++)
                {
                    if (blocks[x, y] == currentTile)
                        Console.Write("[x]");
                    else if (blocks[x, y] == finishTile)
                        Console.Write("[o]");
                    else
                        Console.Write("[ ]");
                }
                Console.WriteLine();
            }

            Console.Write("    ");

            for (var x = 0; x < width; x++)
            {
                Console.Write(blocks[x, 0].GetXFlag());
                Console.Write("  ");
            }

            Console.WriteLine();
            Console.WriteLine();
        }

        public void DrawHeader()
        {
            Console.WriteLine();
            Console.WriteLine(" Welcome to Minefield! Reach the end while avoiding the mines");
            Console.WriteLine(" Press Enter to restart, or Escape to exit");
        }

        public void DrawHitByMine()
        {
            Console.WriteLine(" ****You've been hit by a mine!****");
        }

        public void DrawLives(int livesLeft)
        {
            Console.WriteLine($" Lives left: {livesLeft}");
        }

        public void DrawMoves(int movesTaken)
        {
            Console.WriteLine($" Moves taken: {movesTaken}");
        }

        public void DrawProximity(int distance)
        {
            switch (distance)
            {
                case 1:
                    {
                        Console.WriteLine(" You are very close to a mine");
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine(" You are close to a mine");
                        break;
                    }
            }
        }
    }
}
