using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Library.Helpers.PlaceShips.Models
{
    public class Point
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(Object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Point point = (Point)obj;
                return (X == point.X) && (Y == point.Y);
            }
        }

        public override int GetHashCode()
        {
            return (X << 2) ^ Y;
        }
    }
}
