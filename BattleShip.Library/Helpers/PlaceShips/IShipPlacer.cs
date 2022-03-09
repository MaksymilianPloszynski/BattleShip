using BattleShip.Library.Fields;
using BattleShip.Library.Ships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Library.Helpers.PlaceShips
{
    public interface IShipPlacer
    {
        Field[,] PlaceShips(IEnumerable<Ship> ships);
    }
}
