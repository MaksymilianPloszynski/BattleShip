using BattleShip.Library.Helpers.PlaceShips.Models;
using BattleShip.Library.Helpers.Position;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Library.Fields
{
    public class FiringBoard : IFiringBoard
    {
        public List<Point> Shots { get; private set; }


        private readonly IPositionConverter _positionConverter;
        public FiringBoard(IPositionConverter positionConverter)
        {
            _positionConverter = positionConverter;
            Shots = new List<Point>();
        }
        public void Shot(string collumnName, int rowNumber)
        {
            var point = _positionConverter.Convert(collumnName, rowNumber);
            if (Shots.Any(n => n == point)) return;
            Shots.Add(point);
        }
    }
}
