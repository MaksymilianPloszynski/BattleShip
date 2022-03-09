using BattleShip.Library.Ships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Library.Helpers.PlaceShips.Models
{
    public class ShipLocation
    {
        public Ship Ship { get; set; }
        public Point StartingPoint { get; set; }
        public bool IsVertical { get; set; }
    }
}
