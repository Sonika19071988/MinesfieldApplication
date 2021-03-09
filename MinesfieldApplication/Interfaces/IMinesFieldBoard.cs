using System;
using System.Collections.Generic;
using System.Text;

namespace MinesfieldApplication.Interfaces
{
    public interface IMinesFieldBoard
    {
        void Create(int width, int height);
        IBlock[,] GenerateChess(int boardWidth, int boardHeight, int startPosX = 0);
        IBlock GenerateFinishChess(int endPosX, int boardHeight);
        bool BlockUp();
        bool BlockDown();
        bool BlockLeft();
        bool BlockRight();
        void GetMineProximity();
        void SetLiveBlock(int xPos, int yPos);
        IBlock GetLiveBlock();
        IBlock GetFinishedBlock();
    }
}