using BattleShip.Library.Ships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Library.Fields
{
    public class Battlefield
    {
        private bool[,] hitBoxes = new bool[10, 10];

        private List<Ship> ships = new List<Ship>();
        public List<ShipLocation> _shipLocation;

        private string emptyField = "| |";
        private string fieldWithShip = "|O|";
        private string fieldWithHitSHip = "|X|";

        private string[] alfabet = new string[] { " A ", " B ", " C ", " D ", " E ", " F ", " G ", " H ", " I ", " J " };






        public void AddShip(Ship ship)
        {
            ships.Add(ship);
        }

        public void PrintBattlefield()
        {
            foreach (var character in alfabet)
            {
                Console.Write(" ");
                Console.Write(character); 
            }

            foreach (var item in hitBoxes)
            {
                Console.WriteLine("X");
            }

        }

        public void PrepareField()
        {
            _shipLocation = new List<ShipLocation> { };
            foreach (var ship in ships)
            {
                var shipLocation = PlaceShip(ship);
                _shipLocation.Add(shipLocation);
            }
        }

        private ShipLocation PlaceShip(Ship ship)
        {
            var numbersGenerator = new Random();

            var shipLocation = new ShipLocation()
            {
                Ship = ship,
                IsVertical = numbersGenerator.Next(0,2) == 0
            };

            int x;
            int y;

            do 
            {
                if (shipLocation.IsVertical)
                {
                    x = numbersGenerator.Next(0, hitBoxes.GetLength(0) - 1);
                    y = numbersGenerator.Next(0, hitBoxes.GetLength(1) - ship.Width);
                }
                else
                {
                    x = numbersGenerator.Next(0, hitBoxes.GetLength(0) - ship.Width);
                    y = numbersGenerator.Next(0, hitBoxes.GetLength(1) - 1);
                }

                shipLocation.StartingPoint = new StartingPoint(x, y);
            }
            while (!CheckIfPointCanBePlaced(shipLocation));

            return shipLocation;
        }

        public bool CheckIfPointCanBePlaced(ShipLocation shipLocation)
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
