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
        public Field[,] Area { get;}
        void AddShip(Ship ship);
        void PrepareField();
        bool GetHit(string collumnName, int rowNumber);
        bool AllShipsAreSunk();
    }
}
