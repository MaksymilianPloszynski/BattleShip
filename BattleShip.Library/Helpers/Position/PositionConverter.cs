using BattleShip.Library.Helpers.PlaceShips.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Library.Helpers.Position
{
    public class PositionConverter : IPositionConverter
    {
        private string[] _collumnNames = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
        public Point Convert(string collumnName, int rowNumber)
        {
            int collumnNumber = Array.FindIndex(_collumnNames, n => n == collumnName);
            if (collumnNumber == -1) throw new ArgumentException(collumnName);

            return new Point(collumnNumber, rowNumber -1);
        }
    }
}
