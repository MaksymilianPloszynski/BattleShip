using BattleShip.Library.Fields;
using BattleShip.Library.Helpers.PlaceShips.Models;
using BattleShip.Library.Ships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Library.Helpers.PlaceShips
{
    public class ShipPlacer : IShipPlacer
    {
        private readonly Field[,] _battlefieldArea = new Field[10, 10];
        private List<ShipLocation> _shipLocation;
        public Field[,] PlaceShips(IEnumerable<Ship> ships)
        {
            _shipLocation = new List<ShipLocation> { };
            foreach (var ship in ships)
            {
                var shipLocation = PlaceShip(ship);
                _shipLocation.Add(shipLocation);
            }

            for (int i = 0; i < _battlefieldArea.GetLength(0); i++)
            {
                for (int j = 0; j < _battlefieldArea.GetLength(1); j++)
                {
                    _battlefieldArea[i, j] = new Field();
                }

            }

            foreach (var shipLocation in _shipLocation)
            {
                var points = Convert(shipLocation);
                foreach (var point in points)
                {
                    _battlefieldArea[point.X, point.Y] = new Field(shipLocation.Ship);
                }
            }


            return _battlefieldArea;
        }

        private List<Point> Convert(ShipLocation ship)
        {
            var points = new List<Point>();
            if (ship.IsVertical)
            {
                for (int i = 0; i < ship.Ship.Width; i++)
                {
                    points.Add(new Point(ship.StartingPoint.X, ship.StartingPoint.Y + i));
                }
            }
            else
            {
                for (int i = 0; i < ship.Ship.Width; i++)
                {
                    points.Add(new Point(ship.StartingPoint.X + i, ship.StartingPoint.Y));
                }
            }
            return points;
        }



        private ShipLocation PlaceShip(Ship ship)
        {
            var numbersGenerator = new Random();

            var shipLocation = new ShipLocation()
            {
                Ship = ship,
                IsVertical = numbersGenerator.Next(0, 2) == 0
            };

            int x;
            int y;

            do
            {
                if (shipLocation.IsVertical)
                {
                    x = numbersGenerator.Next(0, _battlefieldArea.GetLength(0) - 1);
                    y = numbersGenerator.Next(0, _battlefieldArea.GetLength(1) - ship.Width);
                }
                else
                {
                    x = numbersGenerator.Next(0, _battlefieldArea.GetLength(0) - ship.Width);
                    y = numbersGenerator.Next(0, _battlefieldArea.GetLength(1) - 1);
                }

                shipLocation.StartingPoint = new Point(x, y);
            }
            while (!CheckIfPointCanBePlaced(shipLocation));

            return shipLocation;
        }

        private bool CheckIfPointCanBePlaced(ShipLocation shipLocation)
        {
            if (!_shipLocation.Any()) return true;

            foreach (var item in _shipLocation)
            {
                bool canBePlaced = false;
                if (!shipLocation.IsVertical && !item.IsVertical)
                {
                    if (shipLocation.StartingPoint.Y > item.StartingPoint.Y + 1 || shipLocation.StartingPoint.Y < item.StartingPoint.Y - 1)
                    {
                        canBePlaced = true;
                    }
                    else if (shipLocation.StartingPoint.X < item.StartingPoint.X - shipLocation.Ship.Width - 1 || shipLocation.StartingPoint.X > item.StartingPoint.X + item.Ship.Width)
                    {
                        canBePlaced = true;
                    }
                }
                else if (shipLocation.IsVertical && !item.IsVertical)
                {


                    if (shipLocation.StartingPoint.X < item.StartingPoint.X - 1 || shipLocation.StartingPoint.X > item.StartingPoint.X + item.Ship.Width + 1)
                    {
                        canBePlaced = true;
                    }
                    else if (shipLocation.StartingPoint.Y + shipLocation.Ship.Width < item.StartingPoint.Y || shipLocation.StartingPoint.Y > item.StartingPoint.Y + 1)
                    {
                        canBePlaced = true;
                    }
                }
                else if (shipLocation.IsVertical && item.IsVertical)
                {
                    if (shipLocation.StartingPoint.X > item.StartingPoint.X + 1 || shipLocation.StartingPoint.X < item.StartingPoint.X - 1)
                    {
                        canBePlaced = true;
                    }
                    else if (shipLocation.StartingPoint.Y < item.StartingPoint.Y - shipLocation.Ship.Width - 1 || shipLocation.StartingPoint.Y > item.StartingPoint.Y + item.Ship.Width)
                    {
                        canBePlaced = true;
                    }
                }
                else if (!shipLocation.IsVertical && item.IsVertical)
                {
                    if (shipLocation.StartingPoint.X > item.StartingPoint.X + 1 || shipLocation.StartingPoint.X + shipLocation.Ship.Width < item.StartingPoint.X - 1)
                    {
                        canBePlaced = true;
                    }
                    else if (shipLocation.StartingPoint.Y < item.StartingPoint.Y - 1 || shipLocation.StartingPoint.Y > item.StartingPoint.Y + item.Ship.Width + 1)
                    {
                        canBePlaced = true;
                    }
                }
                if (!canBePlaced)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
