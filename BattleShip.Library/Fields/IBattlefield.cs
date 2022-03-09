using BattleShip.Library.Ships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Library.Fields
{
    public interface IBattlefield
    {
        void AddShip(Ship ship);
        void PrepareField();
        void GetHit(string collumnName, int rowNumber);
        bool AllShipsAreSunk();
    }
}
