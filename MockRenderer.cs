using System;
using System.Collections.Generic;
using System.Text;
using MinesfieldApplication.Interfaces;

namespace MinesfieldApplication.Tests
{
    class MockRenderer : IRenderer
    {
        public void Clear()
        {
        }

        public void DrawCurrentPos(IBlock currentTile)
        {
        }

        public void DrawFinalScore(int score)
        {
        }

        public void DrawGameOver()
        {
        }

        public void DrawGrid(IBlock[,] tiles, IBlock currentTile, IBlock finishTile)
        {
        }

        public void DrawHeader()
        {
        }

        public void DrawHitByMine()
        {
        }

        public void DrawLives(int livesLeft)
        {
        }

        public void DrawMoves(int movesTaken)
        {
        }

        public void DrawProximity(int distance)
        {
        }
    }
}
