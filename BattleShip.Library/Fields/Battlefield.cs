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
        private List<ShipLocation> _ships;


        public Battlefield()
        {
            
        }

        private ShipLocation PlaceShip(Ship ship)
        {
            var numbersGenerator = new Random();

            var shipLocation = new ShipLocation()
            {
                Ship = ship,
                IsVertical = numbersGenerator.Next(1) == 0
            };

            int x;
            int y;

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
            
            shipLocation.StartingPoint = new StartingPoint(x,y);
            return shipLocation;
        }

        private bool CheckIfPointCanBePlaced(ShipLocation shipLocation)
        {
            if (!_ships.Any()) return true;

            foreach (var item in _ships)
            {
                if (!item.IsVertical && !shipLocation.IsVertical)
                {
                    if (shipLocation.StartingPoint.Y == item.StartingPoint.Y)
                    {
                        return (shipLocation.StartingPoint.X < item.StartingPoint.X - shipLocation.Ship.Width - 1) ||
                            (shipLocation.StartingPoint.X > item.Ship.Width);
                    }
                    else
                    {
                        return true;
                    }

                }
            }

            else
            {
                return true;
            }
            return false;
        }
    }
}
