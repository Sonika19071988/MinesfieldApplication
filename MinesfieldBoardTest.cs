using System;
using Xunit;
using MinesfieldApplication.LogicImplementation;

namespace MinesfieldApplication.Tests
{
    public class MinesfieldBoardTest
    {
        /// <summary>
        /// Check active or finish
        /// </summary>
        [Fact]
        public void Setup()
        {
            int boardWidth = 8, boardHeight = 8;
            var board = new MinesFieldBoard(new MockRenderer());
            board.Create(boardWidth, boardHeight);
            var activeTile = board.GetLiveBlock();
            var finishTile = board.GetFinishedBlock();

            Assert.Equal(typeof(Block), activeTile.GetType());
            Assert.Equal(0, activeTile.GetYCord());
            Assert.True(activeTile.GetXCord() >= 0 && activeTile.GetXCord() < boardWidth);

            Assert.Equal(typeof(FinishBlock), finishTile.GetType());
            Assert.Equal(boardHeight - 1, finishTile.GetYCord());
            Assert.True(finishTile.GetXCord() >= 0 && finishTile.GetXCord() < boardWidth);
        }

        /// <summary>
        /// Check correct number of tiles were generated with correct Ids
        /// </summary>
        [Fact]
        public void GenerateTiles()
        {
            var tiles = new MinesFieldBoard(new MockRenderer()).GenerateChess(8, 8);

            Assert.Equal("A1", tiles[0, 0].GetId());
            Assert.Equal("H8", tiles[7, 7].GetId());
            Assert.Equal(8, tiles.GetLength(0));
            Assert.Equal(8, tiles.GetLength(1));
        }

        /// <summary>
        /// Check tile with correct Id and Type is generated
        /// </summary>
        [Fact]
        public void GenerateFinishTile()
        {
            var boardHeight = 8;
            var tile = new MinesFieldBoard(new MockRenderer()).GenerateFinishChess(2, boardHeight);

            Assert.Equal(typeof(FinishBlock), tile.GetType());
            Assert.Equal("C8", tile.GetId());
        }

        /// <summary>
        /// Check current tile gets changed correctly for each direction
        /// </summary>
        [Fact]
        public void ShiftTile()
        {
            int boardWidth = 2, boardHeight = 2;

            var board = new MinesFieldBoard(new MockRenderer());

            board.Create(boardWidth, boardHeight);

            board.SetLiveBlock(0, 0);
            Assert.True(board.GetLiveBlock().GetId() == "A1");

            board.BlockRight();
            Assert.True(board.GetLiveBlock().GetId() == "B1");

            board.BlockUp();
            Assert.True(board.GetLiveBlock().GetId() == "B2");

            board.BlockLeft();
            Assert.True(board.GetLiveBlock().GetId() == "A2");

            board.BlockDown();
            Assert.True(board.GetLiveBlock().GetId() == "A1");
        }
    }
}
