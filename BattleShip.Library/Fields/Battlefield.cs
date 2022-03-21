using BattleShip.Library.Helpers.PlaceShips;
using BattleShip.Library.Helpers.Position;
using BattleShip.Library.Ships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Library.Fields
{
    public class Battlefield : IBattlefield
    {
        public Field[,] Area { get; private set; }
        private readonly IShipPlacer _shipPlacer;
        private readonly IPositionConverter _positionConverter;
        private List<Ship> _ships;

        public Battlefield(IShipPlacer shipPlacer, IPositionConverter positionConverter)
        {           
            _shipPlacer = shipPlacer;
            _positionConverter = positionConverter;
            _ships = new List<Ship>();
            Area = new Field[10, 10];
        }

        public bool GetHit(string collumnName, int rowNumber)
        {
            var target = FindTarget(collumnName, rowNumber);
            return target.Hit();
        }

        public bool AllShipsAreSunk()
        {
            return _ships.All(n => n.IsSunk());
        }


        public void PrepareField()
        {
            Area = _shipPlacer.PlaceShips(_ships);
        }

        public void AddShip(Ship ship)
        {
            _ships.Add(ship);
        }
        private Field FindTarget(string collumnName, int rowNumber)
        {
            var point = _positionConverter.Convert(collumnName, rowNumber);
            return Area[point.X, point.Y];
        }
    }
}
