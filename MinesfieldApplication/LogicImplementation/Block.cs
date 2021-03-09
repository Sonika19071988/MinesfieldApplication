using System;
using MinesfieldApplication.Interfaces;

namespace MinesfieldApplication.LogicImplementation
{
    public class Block : IBlock
    {
        private string id;
        private int xCord;
        private int yCord;
        private string xFlag;
        private string yFlag;

        public Block(int x, int y, string xLabel = null, string yLabel = null)
        {
            xCord = x;
            yCord = y;

            if (xLabel != null)
                xFlag = xLabel;
            else xFlag = x.ToString();

            if (yLabel != null)
                yFlag = yLabel;
            //Need to set this to + 1 here as the console needs to print starting from 1 not 0
            else yFlag = (y + 1).ToString();

            id = xFlag + yFlag;
        }

        public string GetId() { return id; }

        public int GetXCord()
        {
            return xCord;
        }

        public string GetXFlag()
        {
            return xFlag;
        }

        public int GetYCord()
        {
            return yCord;
        }

        public string GetYFlag()
        {
            return yFlag;
        }

        public virtual void InitiateBlocks(IPlayerDetails player, IRenderer renderer)
        {
            
        }
    }
}
