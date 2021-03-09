using System;
using System.Collections.Generic;
using System.Text;

namespace MinesfieldApplication.Interfaces
{
    public interface IPlayerDetails
    {
        void LivesLeft(int numOfLives);
        int GetMoves();
        bool Alive();
        void Reset();
        bool Finished();
        void MoveUp();
        void MoveDown();
        void MoveLeft();
        void MoveRight();
    }
}
