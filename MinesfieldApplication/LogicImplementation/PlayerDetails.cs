using System;
using System.Collections.Generic;
using System.Text;
using MinesfieldApplication.Interfaces;

namespace MinesfieldApplication.LogicImplementation
{
    public class PlayerDetails : IPlayerDetails
    {
        private readonly IRenderer render;
        private readonly IMinesFieldBoard minesField;
        private int movesTaken = 0;
        private int maxLives;
        private int livesRemaining;


        public PlayerDetails(IMinesFieldBoard minesFieldBoard, IRenderer renderer, int lives = 3)
        {
            minesField = minesFieldBoard;
            render = renderer;
            livesRemaining = lives;
            maxLives = lives;
        }

        public bool Alive()
        {
            return livesRemaining > 0 ? true : false;
        }

        public bool Finished()
        {
            return minesField.GetLiveBlock() == minesField.GetFinishedBlock();
        }

        public int GetMoves()
        {
            return movesTaken;
        }

        public void LivesLeft(int numOfLives)
        {
            livesRemaining -= numOfLives;
        }

        public void MoveDown()
        {
            if (minesField.BlockDown())
            {
                Move();
            }
        }

        public void MoveLeft()
        {
            if (minesField.BlockLeft())
            {
                Move();
            }
        }

        public void MoveRight()
        {
            if (minesField.BlockRight())
            {
                Move();
            }
        }

        public void MoveUp()
        {
            if (minesField.BlockUp())
            {
                Move();
            }
        }

        public void Reset()
        {
            livesRemaining = maxLives;
            movesTaken = 0;
        }

        private void Move()
        {
            movesTaken++;
            render.DrawMoves(movesTaken);
            minesField.GetMineProximity();
            minesField.GetLiveBlock().InitiateBlocks(this, render);

            if (!Finished()) render.DrawLives(livesRemaining);

            if (livesRemaining == 0) render.DrawGameOver();
        }
    }
}
