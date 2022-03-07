using BattleShip.Library.Fields;
using BattleShip.Library.Ships;
using System;

namespace BattleShip.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var field = new Battlefield();

            field.AddShip(new Destroyer());
            field.AddShip(new Destroyer());
            field.AddShip(new Destroyer());
            field.AddShip(new Destroyer());
            field.AddShip(new Battleship());

            field.PrepareField();

            field.PrintBattlefield();

            Console.ReadKey();
        }
    }
}
