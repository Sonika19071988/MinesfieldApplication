using System;
using System.Collections.Generic;
using System.Text;

namespace MinesfieldApplication.Interfaces
{
    public interface IOriginator
    {
        void Start(IMinesFieldBoard board, IPlayerDetails player);

        void End();
    }
}
