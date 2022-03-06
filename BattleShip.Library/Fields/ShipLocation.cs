using BattleShip.Library.Ships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Library.Fields
{
    public class ShipLocation
    {
        public Ship Ship { get; set; }
        public StartingPoint StartingPoint { get; set; }
        public bool IsVertical { get; set; }
    }

    public class StartingPoint
    {
        public int X { get; set; }
        public int Y { get; set; }
        public StartingPoint(int x, int y)
        {
            X = x;  
            Y = y;
        }
    }
}
