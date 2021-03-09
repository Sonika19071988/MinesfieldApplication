using System;
using System.Collections.Generic;
using System.Text;
using MinesfieldApplication.Interfaces;

namespace MinesfieldApplication.LogicImplementation
{
    public class Originator : IOriginator
    {
        public void End()
        {
            var input = Console.ReadKey();

            switch (input.Key)
            {
                case ConsoleKey.Enter:
                    {
                        var renderer = new Renderer();
                        var board = new MinesFieldBoard(renderer);
                        Start(board, new PlayerDetails(board, renderer));
                        break;
                    }
                case ConsoleKey.Escape: { return; }
                default: { End(); break; }
            }
        }

        public void Start(IMinesFieldBoard board, IPlayerDetails player)
        {
            board.Create(8, 8);

            while (player.Alive() && !player.Finished())
            {
                var input = Console.ReadKey();

                switch (input.Key)
                {
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                        {
                            player.MoveUp();
                            break;
                        }
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                        {
                            player.MoveDown();
                            break;
                        }
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.A:
                        {
                            player.MoveLeft();
                            break;
                        }
                    case ConsoleKey.RightArrow:
                    case ConsoleKey.D:
                        {
                            player.MoveRight();
                            break;
                        }
                    case ConsoleKey.Enter:
                        {
                            board.Create(8, 8);
                            player.Reset();
                            break;
                        }
                    case ConsoleKey.Escape:
                        {
                            return;
                        }
                }
            }

            End();
        }
    }
}
