using System;
using System.Collections.Generic;
using System.Text;

namespace MinesfieldApplication.Interfaces
{
    public interface IRenderer
    {
        void Clear();
        void DrawGrid(IBlock[,] tiles, IBlock currentTile, IBlock finishTile);
        void DrawLives(int livesLeft);
        void DrawCurrentPos(IBlock currentTile);
        void DrawMoves(int movesTaken);
        void DrawHitByMine();
        void DrawProximity(int distance);
        void DrawGameOver();
        void DrawFinalScore(int score);
        void DrawHeader();
    }
}
