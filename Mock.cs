using System;
using System.Collections.Generic;
using System.Text;
using MinesfieldApplication.Interfaces;
using MinesfieldApplication.LogicImplementation;

namespace MinesfieldApplication.Tests
{
    public class Mock : IMinesFieldBoard
    {
        private IBlock[,] tiles;
        private IBlock currentTile;
        private IBlock finishTile;
        private int boardWidth;
        private int boardHeight;

        public IBlock GenerateFinishChess(int endPosX, int boardHeight)
        {
            return new Block(0, 0);
        }

        public IBlock[,] GenerateChess(int boardWidth, int boardHeight, int startPosX = 0)
        {
            return new Block[0, 0];
        }

        public IBlock GetLiveBlock()
        {
            return new Block(0, 0);
        }

        public IBlock GetFinishedBlock()
        {
            return new Block(0, 0);
        }

        public void GetMineProximity()
        {
        }

        public void SetLiveBlock(int xPos, int yPos)
        {

        }

        public void Create(int width, int height)
        {
            boardWidth = width;
            boardHeight = height;
            tiles = new Block[boardWidth, boardHeight];
            currentTile = new FinishBlock(0, 0);
            finishTile = new FinishBlock(width == 0 ? 0 : 1, 0);
        }

        public bool BlockDown()
        {
            return true;
        }

        public bool BlockLeft()
        {
            return true;
        }

        public bool BlockRight()
        {
            return true;
        }

        public bool BlockUp()
        {
            return true;
        }
    }
}
