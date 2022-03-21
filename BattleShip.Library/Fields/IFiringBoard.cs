using BattleShip.Library.Helpers.PlaceShips.Models;
using System.Collections.Generic;

namespace BattleShip.Library.Fields
{
    public interface IFiringBoard
    {
        List<Point> Shots { get; }

        void Shot(string collumnName, int rowNumber);
    }
}