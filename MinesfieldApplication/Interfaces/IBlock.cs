using System;
using System.Collections.Generic;
using System.Text;

namespace MinesfieldApplication.Interfaces
{
    public interface IBlock
    {
        void InitiateBlocks(IPlayerDetails player, IRenderer renderer);
        int GetXCord();
        int GetYCord();
        string GetXFlag();
        string GetYFlag();
        string GetId();
    }
}
