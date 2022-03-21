using BattleShip.Library.Helpers.PlaceShips.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Library.Helpers.Position
{
    public interface IPositionConverter
    {
        public Point Convert(string collumnName, int rowNumber); 
    }
}
