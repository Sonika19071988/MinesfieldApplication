using MinesfieldApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinesfieldApplication.LogicImplementation
{
    public class MinesFieldBoard : IMinesFieldBoard
    {
        private Dictionary<int, string> boardFlagMap;
        private const int randomMatch = 5;
        private const int startPosY = 0;
        private IRenderer renderer;
        private IBlock[,] block;
        private IBlock currentTile;
        private IBlock finishTile;
        private int boardWidth;
        private int boardHeight;

        public MinesFieldBoard(IRenderer render)
        {
            renderer = render;
        }

        public bool BlockDown()
        {
            if (currentTile.GetYCord() > 0)
            {
                currentTile = block[currentTile.GetXCord(), currentTile.GetYCord() - 1];
                Redraw();
                return true;
            }
            return false;
        }

        public bool BlockLeft()
        {
            if (currentTile.GetXCord() > 0)
            {
                currentTile = block[currentTile.GetXCord() - 1, currentTile.GetYCord()];
                Redraw();
                return true;
            }
            return false;
        }

        public bool BlockRight()
        {
            if (currentTile.GetXCord() < boardWidth - 1)
            {
                currentTile = block[currentTile.GetXCord() + 1, currentTile.GetYCord()];
                Redraw();
                return true;
            }
            return false;
        }

        public bool BlockUp()
        {
            if (currentTile.GetYCord() < boardHeight - 1)
            {
                currentTile = block[currentTile.GetXCord(), currentTile.GetYCord() + 1];
                Redraw();
                return true;
            }
            return false;
        }

        public void Create(int width, int height)
        {
            boardWidth = width;
            boardHeight = height;

            var startPosX = GetRandomNumber(0, boardWidth);
            var endPosX = GetRandomNumber(0, boardWidth);
            var endPosY = height - 1;

            block = GenerateChess(boardWidth, boardHeight, startPosX);

            //Set start tile
            currentTile = block[startPosX, startPosY];

            //Set finish tile
            finishTile = GenerateFinishChess(endPosX, boardHeight);
            block[endPosX, endPosY] = finishTile;

            Redraw();
        }

        public IBlock[,] GenerateChess(int boardWidth, int boardHeight, int startPosX = 0)
        {
            var block = new IBlock[boardWidth, boardHeight];

            if (boardFlagMap == null) GenerateBoardFlagMap();

            for (var x = 0; x < boardWidth; x++)
            {
                for (var y = 0; y < boardHeight; y++)
                {
                    //Allocate mines randomly
                    var rolledMine = GetRandomNumber(1, randomMatch + 1) == randomMatch ? true : false;

                    if (x == startPosX & y == startPosY || !rolledMine)
                    {
                        block[x, y] = new Block(x, y, boardFlagMap[x]);
                    }
                    else
                    {
                        block[x, y] = new MineBlock(x, y, boardFlagMap[x]);
                    }
                }
            }

            return block;
        }

        public IBlock GenerateFinishChess(int endPosX, int boardHeight)
        {

            if (boardFlagMap == null) GenerateBoardFlagMap();

            return new FinishBlock(endPosX, boardHeight - 1, boardFlagMap[endPosX]);
        }

        public IBlock GetFinishedBlock()
        {
            return finishTile;
        }

        public IBlock GetLiveBlock()
        {
            return currentTile;
        }

        public void GetMineProximity()
        {
            int xPos = currentTile.GetXCord();
            int yPos = currentTile.GetYCord();

            if (CheckMineTiles(xPos, yPos, (int)MineProximity.VeryClose))
            {
                renderer.DrawProximity((int)MineProximity.VeryClose);
            }
            else if (CheckMineTiles(xPos, yPos, (int)MineProximity.Close))
            {
                renderer.DrawProximity((int)MineProximity.Close);
            }
        }

        public void SetLiveBlock(int xPos, int yPos)
        {
            currentTile = block[xPos, yPos];
        }

        public void Redraw()
        {
            renderer.Clear();
            renderer.DrawHeader();
            renderer.DrawGrid(block, currentTile, finishTile);
            renderer.DrawCurrentPos(currentTile);
        }

        public enum MineProximity
        {
            VeryClose = 1,
            Close = 2
        }

        private bool CheckMineTiles(int xPos, int yPos, int distance)
        {
            return CheckMineTile(xPos + distance, yPos)
                || CheckMineTile(xPos - distance, yPos)
                || CheckMineTile(xPos, yPos + distance)
                || CheckMineTile(xPos, yPos - distance);
        }

        private bool CheckMineTile(int xPos, int yPos)
        {
            if (xPos >= 0 && xPos < boardWidth && yPos > 0 && yPos < boardHeight)
                return block[xPos, yPos] is MineBlock;
            return false;
        }

        private void GenerateBoardFlagMap()
        {
            boardFlagMap = new Dictionary<int, string>()
            {
                { 0, "A"}, { 1, "B"}, { 2, "C"}, { 3, "D"},
                { 4, "E"}, { 5, "F"}, { 6, "G"}, { 7, "H"},
                { 8, "I"}, { 9, "J"}, { 10, "K"}, { 11, "L"},
                { 12, "M"}, { 13, "N"}, { 14, "O"}, { 15, "P"},
                { 16, "Q"}, { 17, "R"}, { 18, "S"}, { 19, "T"},
                { 20, "U"}, { 21, "V"}, { 22, "W"}, { 23, "X"},
                { 24, "Y"}, { 25, "Z"}
            };
        }
        private int GetRandomNumber(int min = 0, int max = 0)
        {
            return new Random().Next(min, max);
        }
    }
}
