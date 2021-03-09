using System;
using System.Collections.Generic;
using System.Text;
using MinesfieldApplication.Interfaces;

namespace MinesfieldApplication.LogicImplementation
{
    public class MineBlock : Block
    {
        public MineBlock(int x, int y, string _xLabel = null, string _yLabel = null) : base(x, y, _xLabel, _yLabel)
        {
        }

        public override void InitiateBlocks(IPlayerDetails player, IRenderer renderer)
        {
            player.LivesLeft(1);
            renderer.DrawHitByMine();
        }
    }
}
