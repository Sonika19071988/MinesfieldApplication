using System;
using MinesfieldApplication.LogicImplementation;

namespace MinesfieldApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var renderer = new Renderer();
            var board = new MinesFieldBoard(renderer);
            new Originator().Start(board, new PlayerDetails(board, renderer));
        }
    }
}
