using System;
using System.Collections.Generic;
using System.Text;
using MinesfieldApplication.Interfaces;

namespace MinesfieldApplication.LogicImplementation
{
    public class FinishBlock : Block
    {
        public FinishBlock(int x, int y, string xLabel = null, string yLabel = null) : base(x, y, xLabel, yLabel)
        {
        }

        public override void InitiateBlocks(IPlayerDetails player, IRenderer renderer)
        {
            renderer.DrawFinalScore(player.GetMoves());
        }
    }
}
