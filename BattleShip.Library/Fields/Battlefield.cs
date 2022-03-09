using BattleShip.Library.Helpers.PlaceShips;
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
        private List<Ship> _ships;
        private string[] collumnNames = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
        private readonly IShipPlacer _shipPlacer;

        public Battlefield(IShipPlacer shipPlacer)
        {           
            _shipPlacer = shipPlacer;
            _ships = new List<Ship>();
            Area = new Field[10, 10];
        }

        public void GetHit(string collumnName, int rowNumber)
        {
            int collumnNumber = Array.FindIndex(collumnNames, n => n == collumnName);
            if (collumnNumber == -1) throw new ArgumentException(collumnName);

            var field = Area[collumnNumber,rowNumber -1];

            field.Hit();
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
    }
}
