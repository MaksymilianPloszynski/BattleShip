using BattleShip.Library.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Library.Helpers.Print
{
    public interface IBattlefieldPrinter
    {
        void Print(Field[,] battlefieldArea);
    }
}
